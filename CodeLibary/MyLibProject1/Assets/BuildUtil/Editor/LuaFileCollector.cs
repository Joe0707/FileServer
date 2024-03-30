using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

//
public class LuaFileCollector
{
    [MenuItem("XLua/打包所有Lua文件")]
    static void CollectAllLuaFiles()
    {
        CollectLuaFiles();
    }

    public static void CollectLuaFiles()
    {
        Debug.Log("提取所有Lua文件开始");
        //查找项目里所有的(.lua.txt) 文件
        List<string> luaFiles = new List<string>();
        FindLua("./Assets/", luaFiles);

        //复制文件到目标
        //创建文件夹 
        string destFolder = "../AllLuaFiles/" + Version.VersionName;
        if (Directory.Exists(destFolder) == true)
            Directory.Delete(destFolder, true);
        Directory.CreateDirectory(destFolder);
        Directory.CreateDirectory(destFolder + "/" + LuaJsonConfig.LuaFolderName);

        LuaJsonConfig config = new LuaJsonConfig();
        //拷贝文件
        foreach (var f in luaFiles)
        {
            Debug.Log("提取文件:" + f);
            config.AddFile(f);
            File.Copy(f, destFolder + "/" + LuaJsonConfig.LuaFolderName + "/" + Path.GetFileName(f));
        }
        //保存json文件
        var configJson = config.ToJson();
        var fs = new FileStream(destFolder + "/" + LuaJsonConfig.JsonFileName, FileMode.Create);
        var sw = new StreamWriter(fs);
        sw.Write(configJson);
        sw.Close();
        Debug.Log("提取Lua文件完毕，文件数量 ：" + luaFiles.Count + "。 所有lua文件存入:" + destFolder);
    }

    //查找目录下的Lua文件
    static void FindLua(string dir, List<string> list)
    {
        //查找文件
        var files = Directory.GetFiles(dir);
        foreach (var f in files)
        {
            int idx = f.IndexOf(".lua.txt");
            if (idx <= 0 || idx != f.Length - 8)
                continue; //不是以.lua.txt结尾
            if (f.Contains("Assets/XLua/"))
                continue; //XLua目录下排除
            if (list.Contains(f))
            {
                Debug.Log("有重名文件:" + f);
                continue;
            }
            list.Add(f);
        }

        //查找子目录 
        var subFolders = Directory.GetDirectories(dir);
        foreach (var f in subFolders)
        {
            FindLua(f, list);
        }
    }
}
