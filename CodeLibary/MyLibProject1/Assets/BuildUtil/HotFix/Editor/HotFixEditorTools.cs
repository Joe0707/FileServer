using HotfixFrame.Core.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;
using HotfixFrame.Resource;
using System.Text.RegularExpressions;
namespace HotfixFrame.Editor.Asset
{
    static public class HotFixEditorTools
    {
        const string replaceStr = "/Resources/";//替换字符串
        //加密处理
        public static void EncryptionProcess(string DirectoryPath)
        {
            DebugUtil.DebugInfo("开始文件加密处理");
            var files = Directory.GetFiles(DirectoryPath, "*.*", SearchOption.AllDirectories);
            int encryptionNum = 0;
            foreach (var file in files)
            {
                //不对json处理
                var filename = file.Replace("\\", "/");
                //获取短文件名
                var shortName = filename.Substring(filename.LastIndexOf("/") + 1);
                //如果是加密并且没加密过则加密
                FileHelper.EncryptFile(file, shortName);
                encryptionNum++;
            }
            DebugUtil.DebugInfo("加密文件数量 " + encryptionNum);
            DebugUtil.DebugInfo("文件加密处理完成");
        }



        /// <summary>
        /// 生成热更资源
        /// </summary>
        /// <param name="outputPath">导出目录</param>
        /// <param name="target">平台</param>
        /// <param name="options">打包参数</param>
        /// <param name="isHashName">是否为hash name</param>
        public static bool GenHofxFixAssets(string outputPath, RuntimePlatform platform)
        {
            if (Directory.Exists(outputPath) == true)
            {
                Directory.Delete(outputPath, true);
            }
            //文件转移到外部位置
            outputPath = Path.Combine(outputPath, HFApplication.GetPlatformPath(platform));
            Directory.CreateDirectory(outputPath);
            var hotfixPaths = BuildApplication.mResourceDataPaths;
            for (var i = 0; i < hotfixPaths.Length; i++)
            {
                var hotfixPath = hotfixPaths[i];
                //文件拷贝
                var files = Directory.GetFiles(hotfixPath, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    //文件过滤
                    if (CheckPath(file) == false)
                    {
                        continue;
                    }
                    var filepath = file.Replace("\\", "/");
                    //文件名修改为resources读取形式的文件名
                    if (filepath.Contains(replaceStr) == false)
                    {
                        Debug.LogError("文件名不在resources目录下" + filepath);
                        continue;
                    }
                    var shortName = filepath.Substring(filepath.LastIndexOf(replaceStr) + replaceStr.Length);
                    shortName = shortName.Substring(0, shortName.LastIndexOf("."));
                    if (string.IsNullOrEmpty(shortName) == true)
                    {
                        Debug.LogError("文件没有后缀名" + filepath);
                        continue;
                    }
                    var targetPath = outputPath + "/" + shortName;
                    var parent = Directory.GetParent(targetPath);
                    if (parent.Exists == false)
                    {
                        Directory.CreateDirectory(parent.FullName);
                    }
                    File.Copy(file, targetPath);
                }
            }
            //加密处理
            EncryptionProcess(outputPath);
            return true;
        }
        //检查路径
        static bool CheckPath(string path)
        {
            var result = true;
            //特殊后缀
            var ext = Path.GetExtension(path).ToLower();
            if (ext == ".meta")
            {
                result = false;
            }
            return result;
        }
    }
}