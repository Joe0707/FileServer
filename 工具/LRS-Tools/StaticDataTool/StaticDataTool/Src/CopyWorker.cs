using System;
using System.IO;
using StaticData;
//拷贝输出文件到指定的目录
public class CopyWorker
{
    //拷贝Bin_x
    public static void CopyBin(string destFolder, bool forserver)
    {
        if(string.IsNullOrEmpty(destFolder))
            return;
        //清空目录
        // if(Directory.Exists(destFolder))
        //     Directory.Delete(destFolder, true);
        // Directory.CreateDirectory(destFolder);
        //拷贝文件
        string srcFolder = FolderCfg.OutputDir_Bin_C;
        if(forserver)
            srcFolder = FolderCfg.OutputDir_Bin_S;
        DirectoryCopy(srcFolder, destFolder, true);
    }

    //拷贝文件Code_x/Data
    public static void CopyDataCode(string destFolder, bool forserver)
    {
        if (string.IsNullOrEmpty(destFolder))
            return;
        //清空目录
        // if (Directory.Exists(destFolder))
        //     Directory.Delete(destFolder, true);
        // Directory.CreateDirectory(destFolder);
        //拷贝文件
        string srcFolder = FolderCfg.OutputDir_Code_C_Data;
        if (forserver)
            srcFolder = FolderCfg.OutputDir_Code_S_Data;
        DirectoryCopy(srcFolder, destFolder, true);
    }

    //拷贝文件Code_x/StaticDataMgr.cs
    public static void CopyStaticDataMgrCode(string destFolder, bool forserver)
    {
        if (string.IsNullOrEmpty(destFolder))
            return;
        //检查目标目录是否存在
        if (Directory.Exists(destFolder) == false)
            Directory.CreateDirectory(destFolder);

        var destFile = Path.Combine(destFolder, "StaticDataMgr.cs");
        if(File.Exists(destFile))
            File.Delete(destFile);
        var sourceFile = Path.Combine(FolderCfg.OutputDir_Code_C, "StaticDatamgr.cs");
        if(forserver)
            sourceFile = Path.Combine(FolderCfg.OutputDir_Code_S, "StaticDatamgr.cs");
        File.Copy(sourceFile, destFile);
        Console.WriteLine("Copy:" + sourceFile);
    }

    //拷贝Json_x
    public static void CopyJson(string destFolder, bool forserver)
    {
        if (string.IsNullOrEmpty(destFolder))
            return;
        //清空目录
        // if (Directory.Exists(destFolder))
        //     Directory.Delete(destFolder, true);
        // Directory.CreateDirectory(destFolder);
        //拷贝文件
        string srcFolder = FolderCfg.OutputDir_Json_C;
        if (forserver)
            srcFolder = FolderCfg.OutputDir_Json_S;
        DirectoryCopy(srcFolder, destFolder, true);
    }

    //目录拷贝
    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();

        //如果目录不存在
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        //创建目标目录
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }
        // 获得所有文件
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            // 路径拼接
            string temppath = Path.Combine(destDirName, file.Name);
            // 复制文件
            file.CopyTo(temppath, true);
            Console.WriteLine("Copy:" + temppath);
        }
        // 如果需要拷贝子目录
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                //路径拼接
                string temppath = Path.Combine(destDirName, subdir.Name);
                //拷贝子目录
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
}