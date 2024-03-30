using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml;
using UnityEditor.Callbacks;
using HotfixFrame.Editor;
using HotfixFrame.Editor.Asset;
using HotfixFrame.Editor.BuildPackage;
using Newtonsoft.Json;
using HotfixFrame.Core.Tools;
public class ComfirmCleanWindow : EditorWindow
{
    public BuildVersionInfo mVersionInfo;//构建版本信息
    void OnGUI()
    {
        GUILayout.BeginVertical();
        //平台选择
        OnGUI_SelectChannel();
        GUILayout.EndVertical();
    }


    //平台选择
    void OnGUI_SelectChannel()
    {
        var mRichTextStyle = new GUIStyle();
        mRichTextStyle.richText = true;
        //当前配置的信息
        GUILayout.Label("<size=15>清空平台:" + mVersionInfo.mBuildTarget.ToString() + "</size>", mRichTextStyle);
        GUILayout.BeginHorizontal();
        GUILayout.Label("确认清空吗:");
        //清空按钮
        if (GUILayout.Button("确认"))
        {
            CleanHFAssetsCache();
        }
        GUILayout.EndHorizontal();
    }
    //清空缓存资源
    void CleanHFAssetsCache()
    {
        Debug.Log("开始清空热更缓存");
        var cleanPath = BuildApplication.mOutputABPath;
        cleanPath = Path.Combine(cleanPath, HFApplication.GetPlatformPath(GetPlatform()));
        //删除文件夹
        if (Directory.Exists(cleanPath))
        {
            Directory.Delete(cleanPath, true);
        }
        Debug.Log("清空热更缓存完毕");
    }

    public RuntimePlatform GetPlatform()
    {
        RuntimePlatform platform = RuntimePlatform.WindowsPlayer;
        if (mVersionInfo.mBuildTarget == BuildTargetType.Android)
        {
            platform = RuntimePlatform.Android;
        }
        else if (mVersionInfo.mBuildTarget == BuildTargetType.IOS)
        {
            platform = RuntimePlatform.IPhonePlayer;
        }
        else if (mVersionInfo.mBuildTarget == BuildTargetType.Windows64)
        {
            platform = RuntimePlatform.WindowsPlayer;
        }
        return platform;
    }

}
