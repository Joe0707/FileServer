using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
namespace HotfixFrame.Core.Tools
{

    public class HFApplication
    {
        public static string ABAssetReplacePath = "/abtest/";
        static public string ABAssetPath = "";
        /// <summary>
        /// 项目根目录
        /// </summary>
        static public string ProjectRoot { get; private set; }
        static public void Init()
        {
            ProjectRoot = Application.dataPath.Replace("/Assets", "");
            ABAssetPath = Application.dataPath.Replace("\\", "/") + "/ABPackage/ABTest";
        }
        /// <summary>
        /// 获取所有AB的根目录
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllABRootDirects()
        {
            // //搜索所有资源
            // var root = Application.dataPath;

            // //获取根路径所有runtime
            // var directories = Directory.GetDirectories(root, "*", SearchOption.TopDirectoryOnly).ToList();
            // for (int i = directories.Count - 1; i >= 0; i--)
            // {
            //     var dir = directories[i].Replace(ProjectRoot + "/", "").Replace("\\", "/") + ABAssetPath;
            //     if (!Directory.Exists(dir))
            //     {
            //         directories.RemoveAt(i);
            //     }
            //     else
            //     {
            //         directories[i] = dir;
            //     }
            // }

            return new List<string>() { ABAssetPath.Replace(ProjectRoot + "/", "") };
        }
        //获取所有热更场景的路径 PlayerSetting格式的
        public static List<string> GetAllABSceneDirects()
        {
            return new List<string>() { ABAssetPath.Replace(ProjectRoot + "/", "") + "/Scene" };
        }

        // /// <summary>
        // /// 获取所有runtime的目录
        // /// </summary>
        // /// <returns></returns>
        // public static List<string> GetAllAssetsDirects()
        // {
        //     //搜索所有资源
        //     var root = Application.dataPath;

        //     //获取根路径所有runtime
        //     var directories = Directory.GetDirectories(root, "*", SearchOption.TopDirectoryOnly).ToList();
        //     for (int i = directories.Count - 1; i >= 0; i--)
        //     {
        //         var dir = directories[i].Replace(HFApplication.ProjectRoot + "/", "").Replace("\\", "/") + "/ABTest";
        //         if (!Directory.Exists(dir))
        //         {
        //             directories.RemoveAt(i);
        //         }
        //         else
        //         {
        //             directories[i] = dir;
        //         }
        //     }

        //     return directories;
        // }

        /// <summary>
        /// 获取所有热更资源
        /// </summary>
        /// <returns></returns>
        public static List<string> GetABAssetsPath()
        {
            List<string> allAssetsList = new List<string>();
            var directories = GetAllABRootDirects();
            //所有资源列表
            foreach (var dir in directories)
            {
                var rets = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                    .Where((s) => !s.EndsWith(".meta"));
                allAssetsList.AddRange(rets);
            }


            for (int i = 0; i < allAssetsList.Count; i++)
            {
                var res = allAssetsList[i];
                allAssetsList[i] = res.Replace("\\", "/");
            }

            return allAssetsList;
        }

        /// <summary>
        /// 平台资源的父路径
        /// </summary>
        public static string GetPlatformPath(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                case RuntimePlatform.Android:
                    return "Android";
                case RuntimePlatform.IPhonePlayer:
                    return "iOS";
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    return "Windows";
            }

            return "";
        }
    }
}