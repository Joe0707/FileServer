using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #if UNITY_ANDROID
public class ChannelInfo
{
    public string mName = "";
    public string mAppName = "";
    public string mVersion = "";
    public int mBuildVersion = 1;
    public string mPackageName = "";
    public string mAppIcon = "";
    public string[] mSDKFolderList;
    public string mShareUrl = "";
    public ChannelInfo(string chanelName, string appName, string version, int buildVersion, string packageName, string appIcon, string[] sdkFolderListName, string shareUrl)
    {
        mName = chanelName;
        mAppName = appName;
        mVersion = version;
        mBuildVersion = buildVersion;
        mPackageName = packageName;
        mAppIcon = appIcon;
        mSDKFolderList = sdkFolderListName;
        mShareUrl = shareUrl;
    }
}

public class VersionInfo
{
    //当前选择的渠道 //不要手工改这句
    public static EChannel mCurChannel = EChannel.AppStore; //{*} //不要手工改这句,不要手工改这句
                                                            //渠道信息
    public static ChannelInfo[] mChannelInfos = {
        new ChannelInfo("AppStore", "LRSBNGame", "1.0.0", 1, "com.DefaultCompany.LRSBNGame", "Default", new string[]{""}, "")
        // new ChannelInfo("GooglePlay","Fire Party" ,"1.0.0", 1, "com.fanyoufu.fireparty", "Default", new string[]{""}, "https://play.google.com/store/apps/details?id=com.llstudio.thespark"),
        // new ChannelInfo("TapTap","Fire Party" ,"1.0.0", 1, "com.fanyoufu.fireparty", "Default", new string[]{""}, "https://www.taptap.com/app/174007"),
        // new ChannelInfo("Haoyou","Fire Party" ,"1.0.0", 1, "com.fanyoufu.fireparty", "Default", new string[]{""}, "https://www.3839.com/a/116074.htm"),
    };

    //当前的平台/渠道信息
    public static ChannelInfo CurChannelInfo()
    {
        return mChannelInfos[(int)mCurChannel];
    }
    //IAP是否启用
    public static bool IapEnabled
    {
        get
        {
            bool retValue = true;
            if (mCurChannel == EChannel.TapTap)
                retValue = false;
            return retValue;
        }
    }
}

public enum EChannel
{
    AppStore,
    Max,
    GooglePlay,
    TapTap,
    Haoyou,

}
// #endif