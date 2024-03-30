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
public class ComfirmWindow : EditorWindow
{
    public ConfirmContext mContext;//构建上下文
    public BuildWindow mBuildWindow;//构建窗口
    public void Init(ConfirmContext context, BuildWindow window)
    {
        mContext = context;
        mBuildWindow = window;
    }
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
        //打包信息展示
        //平台 打包类型 版本号 构建号 debug还是release包 是否是热更包 是否是导出包 
        string buildType = "";
        switch (mContext.mConfirmType)
        {
            case ConfirmType.BuildApplication:
                buildType = "构建<size=20><color=red>应用</color></size>";
                break;
            case ConfirmType.BuildHFAsset:
                buildType = "构建<size=20><color=red>热更资源</color></size>";
                break;
            case ConfirmType.BuildHFData:
                buildType = "构建<size=20><color=red>数据</color></size>";
                break;
            case ConfirmType.BuildWhole:
                buildType = "构建<size=20><color=red>整体包</color></size>";
                break;
            case ConfirmType.BuildLua:
                buildType = "构建<size=20><color=red>Lua</color></size>";
                break;
        }
        GUILayout.Label("打包方式:  " + buildType, mRichTextStyle);
        GUILayout.Label("平台:  " + mContext.mVersionInfo.mBuildTarget.ToString());
        GUILayout.Label("版本号:    " + mContext.mVersionInfo.mVersion);
        GUILayout.Label("构建号:    " + mContext.mVersionInfo.mBuildVersion);
        GUILayout.Label("构建类型:    " + mContext.mVersionInfo.mDebugType.ToString());
        GUILayout.Label("是否是热更包:    " + (mContext.mVersionInfo.mNeedAssetsHotFix ? "是" : "否"));
        GUILayout.Label("是否是导出包:    " + (mContext.mVersionInfo.mIsExport ? "是" : "否"));
        GUILayout.Label("是否是加密包:    是");


        GUILayout.Label("确认打包吗:");
        GUILayout.Space(20);
        //清空按钮
        if (GUILayout.Button("确认", GUILayout.Width(200), GUILayout.Height(50)))
        {
            StartBuild(mContext.mConfirmType);
            this.Close();
        }
    }

    void StartBuild(ConfirmType confirmType)
    {
        switch (mContext.mConfirmType)
        {
            case ConfirmType.BuildApplication:
                var buildresult = mBuildWindow.SingleClickBuildApp();
                if (buildresult.result == BuildResultType.Fail)
                {
                    DebugUtil.DebugError(buildresult.errorMessage);
                }
                AssetDatabase.Refresh();
                Debug.Log("资源刷新完毕");
                break;
            case ConfirmType.BuildHFAsset:
                var timeBuildHFAsset = System.DateTime.Now;
                mBuildWindow.BuildHotFixAssets();
                AssetDatabase.Refresh();
                Debug.Log("资源刷新完毕");
                Debug.Log("花费时间" + (System.DateTime.Now - timeBuildHFAsset).TotalSeconds);
                break;
            case ConfirmType.BuildHFData:
                var timeBuildHFData = System.DateTime.Now;
                mBuildWindow.BuildHotFixFiles();
                Debug.Log("花费时间" + (System.DateTime.Now - timeBuildHFData).TotalSeconds);
                break;
            case ConfirmType.BuildWhole:
                var timeBuildWhole = System.DateTime.Now;
                mBuildWindow.BuildPlayer();
                AssetDatabase.Refresh();
                Debug.Log("资源刷新完毕");
                Debug.Log("花费时间" + (System.DateTime.Now - timeBuildWhole).TotalSeconds);
                break;
            case ConfirmType.BuildLua:
                mBuildWindow.BuildLuas();
                break;
        }
    }
}
