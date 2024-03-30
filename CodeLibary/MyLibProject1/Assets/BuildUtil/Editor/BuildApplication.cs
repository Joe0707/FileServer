using UnityEngine;
using UnityEditor;
public class BuildApplication
{
    // public static string mActorsResourcePath = "/Resources/Actor/";
    // public static string mEquipmentsResourcePath = "/Resources/Equipment/";
    // public static string mActorsABPath = "/ABPackage/ABTest/Actor/";
    // public static string mEquipmentsABPath = "/ABPackage/ABTest/Equipment/";
    //打包用的ab文件夹路径
    public static string[] mABPaths = { /*"/ABPackage/ABTest/Data/MapJson/""/ABPackage/ABTest/UI/", "/ABPackage/ABTest/Atlas/",*//* */ "/ABPackage/ABTest/Actor/", "/ABPackage/ABTest/Equipment/" };
    //需要打包的Resources文件夹路径
    public static string[] mResourcePaths = { /*"/LRS-BN-Common/Resources/Data/MapJson/""/Resources/UI/","/Resources/Atlas/",*/ /**/ "/Resources/Actor/", "/Resources/Equipment/" };
    public static string[] mABDataPaths = { /*"/ABPackage/ABTest/Data/Descent/"*/"/ABPackage/ABTest/Xml/", "/ABPackage/ABTest/Data/", "/ABPackage/ABTest/Tools/Xml" };
    public static string[] mResourceDataPaths = { /*"/LRS-BN-Common/Resources/Data/Descent/"*/  "/LRS-BN-Common/Resources/Xml/", "/LRS-BN-Common/Resources/Data/", "/LRS-BN-Common/Tools/Resources/Tools/Xml/" };
    public static string mOutputABPath = "";
    public static string mOutputHotFixFilesPath = "";    //热更数据输出路径
    public static string mOutputLuaFilesPath = "";    //Lua文件输出路径
    public static string OutputAppForWindows = "";//windows输出路径
    public static string OutputAppForAndroid = "";//Android输出路径
    public static string OutLogPath = "Resources/Load/OutLogConfig.json";//日志路径

    public const string HFAssetsCompressPath = "C:/Compress/HotfixAsset";//热更资源包压缩路径
    public const string HFDatasCompressPath = "C:/Compress/HofixData";//热更数据包压缩路径
    public const string HFDatasCompressLocalPath = "C:/Compress/Windows";//热更数据包移动路径
    public const string LuasCompressFilePath = "C:/Compress/AllLuaFiles.zip";//Lua压缩包路径
    public const string ExeCompressPath = "C:/Compress/Bin";//程序包路径
    public const string OutputApkPath = "C:/Compress/OutputApks";//输出apks
    public const string OutputWindowsPath = "C:/Compress/OutputWindows";//输出windows
    public const string CompressRootPath = "C:/Compress";//压缩根目录
    public static void Init()
    {
        var dataPath = Application.dataPath;
        for (var i = 0; i < mABPaths.Length; i++)
        {
            mABPaths[i] = dataPath + mABPaths[i];
        }
        for (var i = 0; i < mResourcePaths.Length; i++)
        {
            mResourcePaths[i] = dataPath + mResourcePaths[i];
        }
        for (var i = 0; i < mABDataPaths.Length; i++)
        {
            mABDataPaths[i] = dataPath + mABDataPaths[i];
        }
        for (var i = 0; i < mResourceDataPaths.Length; i++)
        {
            mResourceDataPaths[i] = dataPath + mResourceDataPaths[i];
        }
        var rootPath = Application.dataPath;
        rootPath = rootPath.Replace("\\", "/");
        mOutputABPath = rootPath.Substring(0, rootPath.LastIndexOf('/', rootPath.LastIndexOf("/") - 1)) + "/AssetBundles/";
        mOutputHotFixFilesPath = rootPath.Substring(0, rootPath.LastIndexOf('/', rootPath.LastIndexOf("/") - 1)) + "/HotFixFiles/";
        mOutputLuaFilesPath = rootPath.Substring(0, rootPath.LastIndexOf('/', rootPath.LastIndexOf("/") - 1)) + "/AllLuaFiles/";
        OutputAppForAndroid = rootPath.Substring(0, rootPath.LastIndexOf('/', rootPath.LastIndexOf("/") - 1)) + "/OutputApks/";
        OutputAppForWindows = rootPath.Substring(0, rootPath.LastIndexOf('/', rootPath.LastIndexOf("/") - 1)) + "/OutputAppForWindows/";
        //设置选项初始化
        EditorSettings.spritePackerMode = SpritePackerMode.BuildTimeOnlyAtlas;
        OutLogPath = System.IO.Path.Combine(Application.dataPath, OutLogPath);
    }
}