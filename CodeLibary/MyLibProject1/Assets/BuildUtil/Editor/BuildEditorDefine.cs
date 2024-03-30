using UnityEditor;
//打包配置信息
public class BuildVersionInfo
{
    public BuildVersionInfo(string appName, string version, string buildVersion, string packageName, BuildDebugType debugType, BuildTargetType buildTarget, bool isExport, bool needAssetsHotFix, bool needEncrypt)
    {
        mAppName = appName;
        mVersion = version;
        mBuildVersion = buildVersion;
        mPackageName = packageName;
        mDebugType = debugType;
        mBuildTarget = buildTarget;
        mIsExport = isExport;
        mNeedAssetsHotFix = needAssetsHotFix;
        mNeedEncrypt = needEncrypt;
        mAssetBundleType = AssetBundleType.All;
    }
    public string mAppName;//游戏名
    public string mVersion;//版本号
    public string mBuildVersion;//构建号
    public string mPackageName;//包名
    public BuildDebugType mDebugType;//调试类型
    public BuildTargetType mBuildTarget;//构建目标 
    public bool mIsExport;//需要导出工程
    public bool mNeedAssetsHotFix;//是否需要资源热更
    public AssetBundleType mAssetBundleType;//热更包类型
    public bool mNeedEncrypt;//是否需要加密
    public BuildVersionInfo Clone()
    {
        return new BuildVersionInfo(mAppName, mVersion, mBuildVersion, mPackageName, mDebugType, mBuildTarget, mIsExport, mNeedAssetsHotFix, mNeedEncrypt);
    }
}
//构建调试类型
public enum BuildDebugType
{
    Debug, //带调试信息
    Release //不带调试信息
}
//构建目标平台类型
public enum BuildTargetType
{
    Android,
    IOS,
    Windows64
}
//热更包类型
public enum AssetBundleType
{
    All,    //所有
    Data    //数据
}