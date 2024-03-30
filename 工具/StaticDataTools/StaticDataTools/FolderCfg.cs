namespace StaticData { 

public class FolderCfg
{
	private static string BinPath = ".\\Bin\\";

	private static string XmlPath = ".\\Xml\\";

	public static string OutputDir { get; } = "./../Output";


	public static string OutputDir_Code_C { get; } = "./../Output/Code_C";


	public static string OutputDir_Code_C_Data { get; } = "./../Output/Code_C/Data";


	public static string OutputDir_Code_S { get; } = "./../Output/Code_S";


	public static string OutputDir_Code_S_Data { get; } = "./../Output/Code_S/Data";


	public static string OutputDir_Bin_C { get; } = "./../Output/Bin_C";


	public static string OutputDir_Bin_S { get; } = "./../Output/Bin_S";


	public static string OutputDir_Json_C { get; } = "./../Output/Json_C";


	public static string OutputDir_Json_S { get; } = "./../Output/Json_S";


	public static string XmlFolder()
	{
		return XmlPath;
	}

	public static void SetXmlFolder(string folder)
	{
		XmlPath = folder;
		if (XmlPath.Substring(XmlPath.Length - 2, 1) != "\\")
		{
			XmlPath += "\\";
		}
	}

	public static string BinFolder()
	{
		return BinPath;
	}

	public static void SetBinFolder(string folder)
	{
		BinPath = folder;
		if (BinPath.Substring(BinPath.Length - 2, 1) != "\\")
		{
			BinPath += "\\";
		}
	}
}
}