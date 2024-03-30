using System;
using System.IO;
using StaticData;

public class CopyWorker
{
	public static void CopyBin(string destFolder, bool forserver)
	{
		if (!string.IsNullOrEmpty(destFolder))
		{
			if (Directory.Exists(destFolder))
			{
				Directory.Delete(destFolder, recursive: true);
			}
			Directory.CreateDirectory(destFolder);
			string srcFolder = FolderCfg.OutputDir_Bin_C;
			if (forserver)
			{
				srcFolder = FolderCfg.OutputDir_Bin_S;
			}
			DirectoryCopy(srcFolder, destFolder, copySubDirs: true);
		}
	}

	public static void CopyDataCode(string destFolder, bool forserver)
	{
		if (!string.IsNullOrEmpty(destFolder))
		{
			if (Directory.Exists(destFolder))
			{
				Directory.Delete(destFolder, recursive: true);
			}
			Directory.CreateDirectory(destFolder);
			string srcFolder = FolderCfg.OutputDir_Code_C_Data;
			if (forserver)
			{
				srcFolder = FolderCfg.OutputDir_Code_S_Data;
			}
			DirectoryCopy(srcFolder, destFolder, copySubDirs: true);
		}
	}

	public static void CopyStaticDataMgrCode(string destFolder, bool forserver)
	{
		if (!string.IsNullOrEmpty(destFolder))
		{
			if (!Directory.Exists(destFolder))
			{
				Directory.CreateDirectory(destFolder);
			}
			string destFile = Path.Combine(destFolder, "DataToolMgr.cs");
			if (File.Exists(destFile))
			{
				File.Delete(destFile);
			}
			string sourceFile = Path.Combine(FolderCfg.OutputDir_Code_C, "DataToolMgr.cs");
			if (forserver)
			{
				sourceFile = Path.Combine(FolderCfg.OutputDir_Code_S, "StaticDatamgr.cs");
			}
			File.Copy(sourceFile, destFile);
			Console.WriteLine("Copy:" + sourceFile);
		}
	}

	public static void CopyJson(string destFolder, bool forserver)
	{
		if (!string.IsNullOrEmpty(destFolder))
		{
			if (Directory.Exists(destFolder))
			{
				Directory.Delete(destFolder, recursive: true);
			}
			Directory.CreateDirectory(destFolder);
			string srcFolder = FolderCfg.OutputDir_Json_C;
			if (forserver)
			{
				srcFolder = FolderCfg.OutputDir_Json_S;
			}
			DirectoryCopy(srcFolder, destFolder, copySubDirs: true);
		}
	}

	private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
	{
		DirectoryInfo dir = new DirectoryInfo(sourceDirName);
		DirectoryInfo[] dirs = dir.GetDirectories();
		if (!dir.Exists)
		{
			throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
		}
		if (!Directory.Exists(destDirName))
		{
			Directory.CreateDirectory(destDirName);
		}
		FileInfo[] files = dir.GetFiles();
		FileInfo[] array = files;
		foreach (FileInfo file in array)
		{
			string temppath = Path.Combine(destDirName, file.Name);
			file.CopyTo(temppath, overwrite: false);
			Console.WriteLine("Copy:" + temppath);
		}
		if (copySubDirs)
		{
			DirectoryInfo[] array2 = dirs;
			foreach (DirectoryInfo subdir in array2)
			{
				string temppath2 = Path.Combine(destDirName, subdir.Name);
				DirectoryCopy(subdir.FullName, temppath2, copySubDirs);
			}
		}
	}
}
