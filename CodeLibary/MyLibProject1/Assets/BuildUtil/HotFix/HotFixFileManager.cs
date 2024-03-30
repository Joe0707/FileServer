using UnityEngine;
using HotfixFrame.Core.Tools;
public class HotFixFileManager : Singleton<HotFixFileManager>
{
    public static string Path = "HotFixFiles";
    public string HotFixFileDownLoadPath
    {
        get
        {
            return Application.persistentDataPath + HFApplication.GetPlatformPath(Application.platform) + Path;
        }
    }

    public string HotFixFileLoadPath
    {
        get
        {
            return Application.persistentDataPath + HFApplication.GetPlatformPath(Application.platform) + Path + "/" + HFApplication.GetPlatformPath(Application.platform);
        }
    }
}