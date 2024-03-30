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
public class BuildWindow : EditorWindow
{
    // #if UNITY_ANDROID
    static int mCurSelectedChannel = 0; //当前选择的平台
    static string[] mChannelNames = null;
    static GUIStyle mRichTextStyle;
    static string mUmengXmlChannelName = "待刷新";
    static string mOutputFileName = "";//输出文件名称
    // static bool mExportProject = true; //是否输出工程
    // static string mCurBundleVersion = "";//当前版本号
    // static string mCurBundleVersionCode = "";//当前构建号
    // static string mProductName = "fireparty";
    public BuildVersionInfo mVersionInfo;//构建版本信息
    public BuildVersionInfo mOgVersionInfo;//原始构建版本信息

    [MenuItem("工具箱/Build Window")]
    static void ShowWindow()
    {
        //初始化
        mCurSelectedChannel = (int)VersionInfo.mCurChannel;
        mChannelNames = new string[(int)EChannel.Max];
        for (int i = 0; i < (int)EChannel.Max; i++)
        {
            mChannelNames[i] = VersionInfo.mChannelInfos[i].mName;
        }
        //字体
        mRichTextStyle = new GUIStyle();
        mRichTextStyle.richText = true;
        // //加载友盟渠道的配置信息
        // LoadUmengXmlChannelInfo();
        // 设定编译选项
        // SetupBuildSettings();
        //显示窗体
        var instance = EditorWindow.GetWindowWithRect(typeof(BuildWindow), new Rect(200, 200, 500, 500), true, "Build Window") as BuildWindow;
        instance.Init();
        instance.mVersionInfo = new BuildVersionInfo(PlayerSettings.productName, PlayerSettings.bundleVersion, PlayerSettings.Android.bundleVersionCode.ToString(), PlayerSettings.applicationIdentifier, BuildDebugType.Debug, BuildTargetType.Windows64, false, true, true);
        instance.mOgVersionInfo = new BuildVersionInfo(PlayerSettings.productName, PlayerSettings.bundleVersion, PlayerSettings.Android.bundleVersionCode.ToString(), PlayerSettings.applicationIdentifier, BuildDebugType.Debug, BuildTargetType.Windows64, false, true, true);
    }
    public void Init()
    {
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
        // 渠道列表
        // GUILayout.Label("<size=20>可选渠道信息:</size>", mRichTextStyle);
        // GUILayout.BeginHorizontal();
        // GUILayout.Label("选择渠道:");
        // mCurSelectedChannel = GUILayout.SelectionGrid(mCurSelectedChannel, mChannelNames, 6);
        // GUILayout.EndHorizontal();

        //当前渠道信息
        ChannelInfo curSelectedChannelInfo = VersionInfo.mChannelInfos[mCurSelectedChannel]; //当前窗口选择的渠道
        ChannelInfo curCodeConfigedChannelInfo = VersionInfo.CurChannelInfo(); //当前工程配置的渠道
        //当前配置的信息
        GUILayout.Label("<size=20>当前游戏信息:</size>", mRichTextStyle);
        GUILayout.BeginHorizontal();
        // GUILayout.Label("当前选择的渠道:" + curSelectedChannelInfo.mName);
        GUILayout.Label("游戏名:" + mOgVersionInfo.mAppName);
        GUILayout.Label("包名:" + mOgVersionInfo.mPackageName);
        GUILayout.Label("版本号:" + mOgVersionInfo.mVersion);
        GUILayout.Label("构建号:" + mOgVersionInfo.mBuildVersion);
        GUILayout.EndHorizontal();
        GUILayout.Space(5);//空行

        GUILayout.Label("<size=20>当前工程打包配置:</size>", mRichTextStyle);
        GUILayout.BeginHorizontal();
        GUILayout.Label("目标版本号:");
        mVersionInfo.mVersion = GUILayout.TextField(mVersionInfo.mVersion);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("目标构建号:");
        mVersionInfo.mBuildVersion = GUILayout.TextField(mVersionInfo.mBuildVersion);
        GUILayout.EndHorizontal();
        mVersionInfo.mDebugType = (BuildDebugType)EditorGUILayout.EnumPopup("目标版本类型:", mVersionInfo.mDebugType);
        mVersionInfo.mBuildTarget = (BuildTargetType)EditorGUILayout.EnumPopup("目标平台:", mVersionInfo.mBuildTarget);
        GUILayout.Label("是否是加密:    是");
        GUILayout.BeginHorizontal();
        mVersionInfo.mNeedAssetsHotFix = GUILayout.Toggle(mVersionInfo.mNeedAssetsHotFix, "是否打热更包");
        // mVersionInfo.mAssetBundleType = (AssetBundleType)EditorGUILayout.EnumPopup("热更包类型:", mVersionInfo.mAssetBundleType);
        GUILayout.EndHorizontal();
        // GUILayout.Space(5);//空行
        //TODO 等完成解密后开放功能
        // mVersionInfo.mNeedEncrypt = GUILayout.Toggle(mVersionInfo.mNeedEncrypt, "是否需要加密");
        // if (curSelectedChannelInfo == curCodeConfigedChannelInfo)
        // {//当前配置的与当前选择的渠道一直
        //     GUILayout.Label("渠道:<color=green>" + curCodeConfigedChannelInfo.mName + "</color>", mRichTextStyle);
        // }
        // else
        // {//不一致
        //     GUILayout.Label("渠道:<color=red>" + curCodeConfigedChannelInfo.mName + "</color>", mRichTextStyle);
        // }

        // //名称比较
        // if (curSelectedChannelInfo.mAppName == PlayerSettings.productName)
        // {//一致
        //     GUILayout.Label("游戏名:<color=green>" + PlayerSettings.productName + "</color>", mRichTextStyle);
        // }
        // else
        // {//不一致
        //     GUILayout.Label("游戏名:<color=red>" + PlayerSettings.productName + "</color>", mRichTextStyle);
        // }

        // //版本号比较
        // string projectVersion = PlayerSettings.bundleVersion;
        // if (projectVersion != curSelectedChannelInfo.mVersion)
        // {//不一致
        //     GUILayout.Label("版本号:<color=red>" + projectVersion + "</color>", mRichTextStyle);
        // }
        // else
        // {
        //     GUILayout.Label("版本号:" + projectVersion, mRichTextStyle);
        // }
        // //构建号比较
        // int buildVersion = PlayerSettings.Android.bundleVersionCode;
        // if (buildVersion != curSelectedChannelInfo.mBuildVersion)
        // {//不一致
        //     GUILayout.Label("构建号:<color=red>" + buildVersion + "</color>", mRichTextStyle);
        // }
        // else
        // {
        //     GUILayout.Label("构建号:" + buildVersion, mRichTextStyle);
        // }

        // //包名比较
        // string projectPackageName = PlayerSettings.applicationIdentifier;
        // if (projectPackageName != curSelectedChannelInfo.mPackageName)
        // {//不一致
        //     GUILayout.Label("包名:<color=red>" + projectPackageName + "</color>", mRichTextStyle);
        // }
        // else
        // {
        //     GUILayout.Label("包名:" + projectPackageName, mRichTextStyle);
        // }
        // //友盟渠道配置
        // GUILayout.BeginHorizontal();
        // if(mUmengXmlChannelName != curSelectedChannelInfo.mName)
        // {
        // 	GUILayout.Label("友盟渠道配置：<color=red>" + mUmengXmlChannelName + "</color>", mRichTextStyle);
        // }
        // else
        //     GUILayout.Label("友盟渠道配置:" + mUmengXmlChannelName);

        // if(GUILayout.Button("刷新"))
        // {
        // 	LoadUmengXmlChannelInfo();
        // }
        // GUILayout.EndHorizontal();

        // //转换按钮
        // if (GUILayout.Button("转换"))
        // {
        //     ConvertProjectConfiguration();
        // }

        // //编译按钮
        GUILayout.Space(10);
        mVersionInfo.mIsExport = GUILayout.Toggle(mVersionInfo.mIsExport, "导出工程");
        // if (GUILayout.Button("刷新热更资源meta文件"))
        // {
        //     UpdateHFAssets();
        // }
        // GUILayout.Space(10);
        GUILayout.Space(10);

        if (GUILayout.Button("(慎用)清空热更资源缓存"))
        {
            //显示窗体
            var instance = EditorWindow.GetWindowWithRect(typeof(ComfirmCleanWindow), new Rect(200, 200, 200, 100), true, "清空缓存") as ComfirmCleanWindow;
            instance.mVersionInfo = mVersionInfo;
        }
        GUILayout.Space(20);
        //确认窗口参数
        Rect confirmRect = new Rect(0, 0, 400, 400);
        if (GUILayout.Button("打热更数据包"))
        {
            // var time = System.DateTime.Now;
            // BuildHotFixFiles();
            // Debug.Log("花费时间" + (System.DateTime.Now - time).TotalSeconds);
            var instance = EditorWindow.GetWindowWithRect(typeof(ComfirmWindow), confirmRect, true, "打包确认") as ComfirmWindow;
            instance.Init(new ConfirmContext(ConfirmType.BuildHFData, this.mVersionInfo), this);
        }
        GUILayout.Space(10);

        if (GUILayout.Button("打热更资源包"))
        {
            // var time = System.DateTime.Now;
            // BuildHotFixAssets();
            // AssetDatabase.Refresh();
            // Debug.Log("资源刷新完毕");
            // Debug.Log("花费时间" + (System.DateTime.Now - time).TotalSeconds);
            var instance = EditorWindow.GetWindowWithRect(typeof(ComfirmWindow), confirmRect, true, "打包确认") as ComfirmWindow;
            instance.Init(new ConfirmContext(ConfirmType.BuildHFAsset, this.mVersionInfo), this);
        }
        GUILayout.Space(10);

        if (GUILayout.Button("打包应用"))
        {
            // var buildresult = SingleClickBuildApp();
            // if (buildresult.result == BuildResultType.Fail)
            // {
            //     DebugUtil.DebugError(buildresult.errorMessage);
            // }
            // AssetDatabase.Refresh();
            // Debug.Log("资源刷新完毕");
            var instance = EditorWindow.GetWindowWithRect(typeof(ComfirmWindow), confirmRect, true, "打包确认") as ComfirmWindow;
            instance.Init(new ConfirmContext(ConfirmType.BuildApplication, this.mVersionInfo), this);
        }
        GUILayout.Space(10);

        if (GUILayout.Button("打Lua文件包"))
        {
            // BuildLuas();
            var instance = EditorWindow.GetWindowWithRect(typeof(ComfirmWindow), confirmRect, true, "打包确认") as ComfirmWindow;
            instance.Init(new ConfirmContext(ConfirmType.BuildLua, this.mVersionInfo), this);
        }
        GUILayout.Space(10);

        if (GUILayout.Button("一键打包"))
        {
            // var time = System.DateTime.Now;
            // BuildPlayer();
            // AssetDatabase.Refresh();
            // Debug.Log("资源刷新完毕");
            // Debug.Log("花费时间" + (System.DateTime.Now - time).TotalSeconds);
            var instance = EditorWindow.GetWindowWithRect(typeof(ComfirmWindow), confirmRect, true, "打包确认") as ComfirmWindow;
            instance.Init(new ConfirmContext(ConfirmType.BuildWhole, this.mVersionInfo), this);
        }

    }
    //构建热更资源
    public void BuildHotFixAssets()
    {
        var buildresult = BuildHFAssets();
        if (buildresult.result == BuildResultType.Fail)
        {
            DebugUtil.DebugError("打热更资源失败");
            DebugUtil.DebugError(buildresult.errorMessage);
            ResetOGHFStatus();
            return;
        }
        ResetOGHFStatus();
    }

    //清空缓存资源
    void CleanHFAssetsCache()
    {
        var cleanPath = BuildApplication.mOutputABPath;
        cleanPath = Path.Combine(cleanPath, HFApplication.GetPlatformPath(GetPlatform()));
        //删除文件夹
        if (Directory.Exists(cleanPath))
        {
            Directory.Delete(cleanPath, true);
        }
    }

    //转换windows项目配置
    void ConvertProjectConfigurationForWindows(BuildVersionInfo sourceInfo)
    {
        //设定版本号
        PlayerSettings.bundleVersion = sourceInfo.mVersion;
        //设定包名
        PlayerSettings.applicationIdentifier = sourceInfo.mPackageName;
        //设定游戏名
        PlayerSettings.productName = sourceInfo.mAppName;
    }

    //转换工程的配置信息
    void ConvertProjectConfiguration(BuildVersionInfo sourceInfo)
    {
        // var curSelectedChannelInfo = VersionInfo.mChannelInfos[(int)mCurSelectedChannel];
        // //设定友盟渠道信息
        // SetUmengXmlChannelInfo(curSelectedChannelInfo.mName);
        //设定版本号
        PlayerSettings.bundleVersion = sourceInfo.mVersion;
        //设定构建号
        PlayerSettings.Android.bundleVersionCode = int.Parse(sourceInfo.mBuildVersion);
        //设定包名
        PlayerSettings.applicationIdentifier = sourceInfo.mPackageName;
        //设定游戏名
        PlayerSettings.productName = sourceInfo.mAppName;
        // //设定代码文件中当前选择平台
        // SetCodeFileCurChannel();
        //配置资源文件
        // //清除不用的SDK文件夹
        // CleanSDKs();
        // //拷贝需要的SDK进来
        // CopySDKs();
        // //设定编译选项
        // SetupBuildSettings();

        // //刷新资源
        // AssetDatabase.Refresh();
    }
    //加载Manifest xml 文件中友盟的渠道信息
    static void LoadUmengXmlChannelInfo()
    {
        mUmengXmlChannelName = "";
        XmlDocument doc = new XmlDocument();
        doc.Load("Assets/Plugins/Android/AndroidManifest.xml");
        //遍历所有meta-data 节点
        var metadataNodes = doc.GetElementsByTagName("meta-data");
        for (int i = 0; i < metadataNodes.Count; i++)
        {
            var metadata = metadataNodes[i];
            for (int j = 0; j < metadata.Attributes.Count; j++)
            {
                var attribute = metadata.Attributes[j];
                if (attribute.Value == "UMENG_CHANNEL")
                { //找到了这个metadata
                  //在这个Meta节点下重新遍历所有的Attributes,找渠道名称
                    for (int k = 0; k < metadata.Attributes.Count; k++)
                    {
                        var att2 = metadata.Attributes[k];
                        if (att2.Name == "android:value")
                        {
                            mUmengXmlChannelName = att2.Value;
                            break;
                        }
                    }
                    break;
                }
            }

            //判断是否已经找到
            if (mUmengXmlChannelName != "")
                break;
        }
    }
    //设定友盟渠道信息
    static void SetUmengXmlChannelInfo(string channelName)
    {
        XmlDocument doc = new XmlDocument();
        string xmlFileName = "Assets/Plugins/Android/AndroidManifest.xml";
        doc.Load(xmlFileName);
        bool dataAlreadySet = false;
        //遍历所有meta-data 节点
        var metadataNodes = doc.GetElementsByTagName("meta-data");
        for (int i = 0; i < metadataNodes.Count; i++)
        {
            var metadata = metadataNodes[i];
            for (int j = 0; j < metadata.Attributes.Count; j++)
            {
                var attribute = metadata.Attributes[j];
                if (attribute.Value == "UMENG_CHANNEL")
                { //找到了这个metadata
                  //在这个Meta节点下重新遍历所有的Attributes,找渠道名称
                    for (int k = 0; k < metadata.Attributes.Count; k++)
                    {
                        var att2 = metadata.Attributes[k];
                        if (att2.Name == "android:value")
                        {
                            att2.Value = channelName;
                            dataAlreadySet = true;
                            break;
                        }
                    }
                    break;
                }
            }
            if (dataAlreadySet)
                break;
        }
        doc.Save(xmlFileName);
        //再次刷新
        LoadUmengXmlChannelInfo();
    }

    //更新主Manifest文件中的版本号
    static void UpdateManafestVersion()
    {
        var curSelectedChannelInfo = VersionInfo.mChannelInfos[(int)mCurSelectedChannel];
        XmlDocument doc = new XmlDocument();
        string xmlFileName = "Assets/Plugins/Android/AndroidManifest.xml";
        doc.Load(xmlFileName);
        //遍历所有meta-data 节点
        var manifestNodes = doc.GetElementsByTagName("manifest");
        for (int i = 0; i < manifestNodes.Count; i++)
        {
            var manifest = manifestNodes[i];
            for (int j = 0; j < manifest.Attributes.Count; j++)
            {
                var attribute = manifest.Attributes[j];
                if (attribute.Name == "android:versionCode")
                {
                    attribute.Value = curSelectedChannelInfo.mBuildVersion.ToString();
                }
                else if (attribute.Name == "android:versionName")
                {
                    attribute.Value = curSelectedChannelInfo.mVersion;
                }
            }

        }
        doc.Save(xmlFileName);
    }

    //设定编译选项
    void SetupBuildSettings()
    {
        //设置图集设置
        EditorSettings.spritePackerMode = SpritePackerMode.BuildTimeOnlyAtlas;
        // var curSelectedChannelInfo = VersionInfo.mChannelInfos[(int)mCurSelectedChannel];
        Debug.Log("mExportProject = " + mVersionInfo.mIsExport);
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevelAuto;
        EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
        var debugInfo = "release";
        if (mVersionInfo.mDebugType == BuildDebugType.Debug)
        {
            debugInfo = "debug";
        }
        var hotfix = "";
        if (mVersionInfo.mNeedAssetsHotFix)
        {
            hotfix = "_hf";
        }
        if (mVersionInfo.mIsExport)
        {
            EditorUserBuildSettings.exportAsGoogleAndroidProject = true;
            mOutputFileName = "../OutputProj/" + mVersionInfo.mAppName + "_" + mVersionInfo.mVersion + "_build_" +
                 mVersionInfo.mBuildVersion + "_" + debugInfo + hotfix;
        }
        else
        {
            //EditorUserBuildSettings.development = true;
            //EditorUserBuildSettings.buildWithDeepProfilingSupport = true;
            EditorUserBuildSettings.exportAsGoogleAndroidProject = false;
            //文件名
            mOutputFileName = "../OutputApks/" + mVersionInfo.mAppName + "_" + mVersionInfo.mVersion + "_build_" +
                 mVersionInfo.mBuildVersion + "_" + debugInfo + hotfix + ".apk";
        }
        //设定签名

        PlayerSettings.Android.keystoreName = "../keystore/sm2g.keystore";
        PlayerSettings.Android.keystorePass = "123456";
        PlayerSettings.Android.keyaliasName = "starhalo";
        PlayerSettings.Android.keyaliasPass = "Qwer1234";

        //写入配置
        var outlogPath = BuildApplication.OutLogPath;
        var outlogConfig = new OutLogConfig();
        if (File.Exists(outlogPath))
        {
            var content = File.ReadAllText(outlogPath);
            outlogConfig = JsonConvert.DeserializeObject<OutLogConfig>(content);
        }
        if (mVersionInfo.mDebugType == BuildDebugType.Debug)
        {
            outlogConfig.OutLog = true;
        }
        else
        {
            outlogConfig.OutLog = false;
        }
        //写入
        FileHelper.WriteAllText(outlogPath, JsonConvert.SerializeObject(outlogConfig));

    }

    //设定代码文件中当前选择平台
    static void SetCodeFileCurChannel()
    {
        string filename = "Assets/__VersionDefine/_Version_Android.cs";
        //读文件内容
        FileStream fs = new FileStream(filename, FileMode.Open);
        var sr = new StreamReader(fs);
        string fileContent = sr.ReadToEnd();
        fs.Close();

        //修改内容
        //先找到标记位置
        int indexOfMark = fileContent.IndexOf("{*}"); //标记开始位
        if (indexOfMark < 0)
        {
            Debug.LogError("SetCodeFileCurChannel Error");
            return;
        }
        int indexOfChangeStart = fileContent.LastIndexOf("= EChannel", indexOfMark) + 2; //往回找到要替换的部分开始
        if (indexOfChangeStart < 2)
        {
            Debug.LogError("SetCodeFileCurChannel Error");
            return;
        }
        int indexOfChanngeEnd = fileContent.IndexOf(";", indexOfChangeStart);//往后找到分号
        if (indexOfChanngeEnd < 2)
        {
            Debug.LogError("SetCodeFileCurChannel Error");
            return;
        }
        //替换
        string oldValue = fileContent.Substring(indexOfChangeStart, indexOfChanngeEnd - indexOfChangeStart);
        string newValue = "EChannel." + ((EChannel)mCurSelectedChannel).ToString();
        fileContent = fileContent.Replace(oldValue, newValue);
        //保存文件
        fs = new FileStream(filename, FileMode.Create);
        var sw = new StreamWriter(fs);
        sw.Write(fileContent);
        sw.Close();
    }

    //清除工程中的SDK
    static void CleanSDKs()
    {
        var subfolders = Directory.GetDirectories("Assets/Plugins/Android");
        foreach (var folder in subfolders)
        {
            var folderName = Path.GetFileName(folder).ToLower();
            if (folderName.Contains("umeng"))
                continue;
            if (folderName.Contains("google"))
                continue;
            if (folderName.Contains("play"))
                continue;
            if (folderName.Contains("sdk"))
                Directory.Delete(folder, true);
        }
    }

    //拷贝需要的SDK进来
    static void CopySDKs()
    {
        var curSelectedChannelInfo = VersionInfo.mChannelInfos[(int)mCurSelectedChannel];
        //文件夹拷贝
        var sdkFolderList = curSelectedChannelInfo.mSDKFolderList;
        foreach (var sdkFolderName in sdkFolderList)
        {
            if (sdkFolderName == null || sdkFolderName == "")
                continue;
            DirectoryCopy("_SDKs/" + sdkFolderName, "Assets/Plugins/Android/" + sdkFolderName, true);
        }
    }

    //目录拷贝
    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();

        // If the source directory does not exist, throw an exception.
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        // If the destination directory does not exist, create it.
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the file contents of the directory to copy.
        FileInfo[] files = dir.GetFiles();

        foreach (FileInfo file in files)
        {
            // Create the path to the new copy of the file.
            string temppath = Path.Combine(destDirName, file.Name);

            // Copy the file.
            file.CopyTo(temppath, false);
        }

        // If copySubDirs is true, copy the subdirectories.
        if (copySubDirs)
        {

            foreach (DirectoryInfo subdir in dirs)
            {
                // Create the subdirectory.
                string temppath = Path.Combine(destDirName, subdir.Name);

                // Copy the subdirectories.
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
    //查找可用场景
    private string[] FindEnableEditorrScenes()
    {
        List<string> editorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            if (mVersionInfo.mNeedAssetsHotFix)
            {
                //需要热更则跳过热更目录下的场景
                var abpaths = HFApplication.GetAllABSceneDirects();
                bool isInABPath = false;
                for (var i = 0; i < abpaths.Count; i++)
                {
                    if (scene.path.Contains(abpaths[i]))
                    {
                        isInABPath = true;
                        break;
                    }
                }
                if (isInABPath == true)
                {
                    continue;
                }
            }
            editorScenes.Add(scene.path);
        }
        return editorScenes.ToArray();
    }
    //获取构建目标平台
    BuildTarget ConvertBuildTarget(BuildTargetType targetType)
    {
        BuildTarget result = BuildTarget.Android;
        switch (targetType)
        {
            case BuildTargetType.Android:
                result = BuildTarget.Android;
                break;
            case BuildTargetType.IOS:
                result = BuildTarget.iOS;
                break;
            case BuildTargetType.Windows64:
                result = BuildTarget.StandaloneWindows64;
                break;
        }
        return result;
    }

    //单独点击打应用 
    public BuildResult SingleClickBuildApp(bool prebuildProcessFiles = true)
    {
        var result = new BuildResult();
        if (prebuildProcessFiles)
        {
            //打包之前处理文件
            if (mVersionInfo.mNeedAssetsHotFix)
            {
                try
                {
                    PremoveHFFiles();
                }
                catch (System.Exception ex)
                {
                    Debug.LogError(ex.StackTrace);
                    result.result = BuildResultType.Fail;
                    result.errorMessage = ex.Message;
                    ResetOGHFStatus();
                    return result;
                }
            }
        }
        if (mVersionInfo.mBuildTarget == BuildTargetType.Android)
        {
            var buildresult = BuildApk();
            if (buildresult.result == BuildResultType.Fail)
            {
                result = buildresult;
                ResetOGStatus();
                return result;
            }
            ResetOGStatus();
        }
        else if (mVersionInfo.mBuildTarget == BuildTargetType.Windows64)
        {
            var buildresult = BuildWindowsApp();
            if (buildresult.result == BuildResultType.Fail)
            {
                result = buildresult;
                ResetOGAppStatus();
                return result;
            }
            ResetOGAppStatus();
        }
        //压缩文件
        try
        {
            CompressExe();
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.StackTrace);
            result.result = BuildResultType.Fail;
            result.errorMessage = ex.Message;
            return result;
        }
        return result;
    }


    //构建应用
    BuildResult BuildWindowsApp()
    {
        var result = new BuildResult();
        SetupBuildSettingForWindows();
        //编译选项
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        //获取当前编辑器内的Build场景
        buildPlayerOptions.scenes = FindEnableEditorrScenes();
        //apk名称
        buildPlayerOptions.locationPathName = mOutputFileName;
        buildPlayerOptions.target = ConvertBuildTarget(mVersionInfo.mBuildTarget);
        PlayerSettings.productName = mVersionInfo.mAppName;
        //设定版本
        if (mVersionInfo.mDebugType == BuildDebugType.Debug)
        {
            buildPlayerOptions.options = buildPlayerOptions.options | BuildOptions.AllowDebugging | BuildOptions.ConnectWithProfiler | BuildOptions.Development | BuildOptions.EnableDeepProfilingSupport;
        }
        //转换工程配置
        ConvertProjectConfigurationForWindows(mVersionInfo);
        //生成游戏加载配置
        GenResourcesLoadConfig((e) =>
        {
            result.result = BuildResultType.Fail;
            result.errorMessage = e;
            // DebugUtil.DebugError(e);
            // ResetApkStatus();
        });
        //如果已经失败则返回
        if (result.result == BuildResultType.Fail)
        {
            return result;
        }
        var buildresult = BuildPipeline.BuildPlayer(buildPlayerOptions).summary.result;
        if (buildresult != UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            // //还原工程配置
            // Debug.LogError("打包失败");
            result.result = BuildResultType.Fail;
            result.errorMessage = "打包失败";
            // ResetApkStatus();
        }
        else
        {
            Debug.Log("打包成功");
        }
        return result;
    }
    //设置windows平台的构建选项
    void SetupBuildSettingForWindows()
    {
        //设置图集设置
        EditorSettings.spritePackerMode = SpritePackerMode.BuildTimeOnlyAtlas;
        var debugInfo = "release";
        if (mVersionInfo.mDebugType == BuildDebugType.Debug)
        {
            debugInfo = "debug";
        }
        var hotfix = "";
        if (mVersionInfo.mNeedAssetsHotFix)
        {
            hotfix = "_hf";
        }
        //文件名
        mOutputFileName = "../OutputAppForWindows/" + mVersionInfo.mAppName + "_" + mVersionInfo.mVersion + "_build_" +
             mVersionInfo.mBuildVersion + "_" + debugInfo + hotfix + ".exe";
        //写入配置
        var outlogPath = BuildApplication.OutLogPath;
        var outlogConfig = new OutLogConfig();
        if (File.Exists(outlogPath))
        {
            var content = File.ReadAllText(outlogPath);
            outlogConfig = JsonConvert.DeserializeObject<OutLogConfig>(content);
        }
        if (mVersionInfo.mDebugType == BuildDebugType.Debug)
        {
            outlogConfig.OutLog = true;
        }
        else
        {
            outlogConfig.OutLog = false;
        }
        //写入
        FileHelper.WriteAllText(outlogPath, JsonConvert.SerializeObject(outlogConfig));
    }

    //打apk
    BuildResult BuildApk()
    {
        var result = new BuildResult();
        //设定编译选项
        SetupBuildSettings();
        // var curSelectedChannelInfo = VersionInfo.mChannelInfos[(int)mCurSelectedChannel];
        //编译选项
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        //获取当前编辑器内的Build场景
        buildPlayerOptions.scenes = FindEnableEditorrScenes();
        //apk名称
        buildPlayerOptions.locationPathName = mOutputFileName;
        buildPlayerOptions.target = ConvertBuildTarget(mVersionInfo.mBuildTarget);
        PlayerSettings.productName = mVersionInfo.mAppName;

        if (EditorUserBuildSettings.exportAsGoogleAndroidProject == true)
        {//导出工程
            buildPlayerOptions.options = BuildOptions.ShowBuiltPlayer | BuildOptions.AcceptExternalModificationsToPlayer;
        }
        else
        {//Apk
            buildPlayerOptions.options = BuildOptions.ShowBuiltPlayer;
        }
        //设定版本
        if (mVersionInfo.mDebugType == BuildDebugType.Debug)
        {
            buildPlayerOptions.options = buildPlayerOptions.options | BuildOptions.AllowDebugging | BuildOptions.ConnectWithProfiler | BuildOptions.Development | BuildOptions.EnableDeepProfilingSupport;
        }
        //转换工程配置
        ConvertProjectConfiguration(mVersionInfo);
        //生成游戏加载配置
        GenResourcesLoadConfig((e) =>
        {
            result.result = BuildResultType.Fail;
            result.errorMessage = e;
            // DebugUtil.DebugError(e);
            // ResetApkStatus();
        });
        //如果已经失败则返回
        if (result.result == BuildResultType.Fail)
        {
            return result;
        }
        var buildresult = BuildPipeline.BuildPlayer(buildPlayerOptions).summary.result;
        if (buildresult != UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            // //还原工程配置
            // Debug.LogError("打包失败");
            result.result = BuildResultType.Fail;
            result.errorMessage = "打包失败";
            // ResetApkStatus();
        }
        else
        {
            Debug.Log("打包成功");
        }
        return result;
    }

    public void BuildPlayer()
    {
        // //更新Manifest文件中的版本号
        // UpdateManafestVersion();
        if (mVersionInfo.mNeedAssetsHotFix)
        {
            //进行热更打包
            BuildHotFixAssets();
            //进行Lua文件打包
            BuildLuas();
            //进行热更数据打包
            BuildHotFixFiles();
        }
        var appresult = SingleClickBuildApp();
        if (appresult.result == BuildResultType.Fail)
        {
            DebugUtil.DebugError(appresult.errorMessage);
            return;
        }

    }

    //还原初始状态
    void ResetOGStatus()
    {
        if (mVersionInfo.mNeedAssetsHotFix)
        {
            ResetOGHFStatus();
        }
        ResetApkStatus();
    }
    //还原原始app状态
    void ResetOGAppStatus()
    {
        if (mVersionInfo.mNeedAssetsHotFix)
        {
            ResetOGHFStatus();
        }
        ResetAppStatus();
    }

    void ResetAppStatus()
    {
        if (mVersionInfo.mBuildTarget == BuildTargetType.Android)
        {
            ConvertProjectConfiguration(mOgVersionInfo);
        }
        else if (mVersionInfo.mBuildTarget == BuildTargetType.Windows64)
        {
            ConvertProjectConfigurationForWindows(mOgVersionInfo);
        }
        //加载配置还原
        ResetLoadConfig();
        //日志配置还原
        ResetOutlogConfig();
    }

    void ResetApkStatus()
    {
        ConvertProjectConfiguration(mOgVersionInfo);
        //加载配置还原
        ResetLoadConfig();
        //日志配置还原
        ResetOutlogConfig();
    }
    //重置加载配置
    void ResetLoadConfig()
    {
        //写入相应位置
        var filename = "";
        filename = filename.Replace('\\', '/');
        var folderName = filename.Substring(0, filename.LastIndexOf("/") + 1);
        if (Directory.Exists(folderName) == false)
        {
            Directory.CreateDirectory(folderName);
        }
        if (File.Exists(filename))
        {
            File.Delete(filename);
        }
        FileStream fs = new FileStream(filename, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        var resourceconfig = new ResourcesLoadConfig();
        string json = JsonConvert.SerializeObject(resourceconfig);
        // string json = JsonConvert.SerializeObject(levelModel);
        try
        {
            sw.Write(json);
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
        finally
        {
            sw.Close();
        }
    }
    //重置日志配置
    void ResetOutlogConfig()
    {
        //写入配置
        var outlogPath = BuildApplication.OutLogPath;
        var outlogConfig = new OutLogConfig();
        //写入
        FileHelper.WriteAllText(outlogPath, JsonConvert.SerializeObject(outlogConfig));
    }

    //还原热更状态
    void ResetOGHFStatus()
    {
        //热更资源位置还原
        //根据热更包类型决定移动资源
        if (mVersionInfo.mAssetBundleType == AssetBundleType.All)
        {
            //转移资源位置
            for (var i = 0; i < BuildApplication.mABPaths.Length; i++)
            {
                var abPath = BuildApplication.mABPaths[i];
                // var actorFiles = Directory.GetFiles(abPath, "*", SearchOption.AllDirectories);
                var resourcePath = BuildApplication.mResourcePaths[i];
                if (Directory.Exists(resourcePath) == true)
                {
                    Debug.LogError(resourcePath + "还原Resource文件夹已存在");
                    throw new System.Exception();
                }
                if (Directory.Exists(abPath) == false)
                {
                    Debug.LogError(abPath + "还原ab文件夹不存在");
                    throw new System.Exception();
                }
                var dir = new DirectoryInfo(abPath);
                dir.MoveTo(resourcePath);
                // Directory.Move(abPath, resourcePath);
                // for (var j = 0; j < actorFiles.Length; j++)
                // {
                //     var actorFile = actorFiles[j];
                //     actorFile = actorFile.Replace("\\", "/");
                //     var directory = actorFile.Substring(0, actorFile.LastIndexOf('/') + 1);
                //     directory = directory.Replace(abPath, resourcePath);
                //     var actorFileName = actorFile.Substring(actorFile.LastIndexOf('/') + 1);
                //     if (File.Exists(directory + actorFileName) == false)
                //     {
                //         File.Move(actorFile, directory + actorFileName);
                //     }
                // }
            }
        }
        else if (mVersionInfo.mAssetBundleType == AssetBundleType.Data)
        {
            //转移资源位置
            for (var i = 0; i < BuildApplication.mABDataPaths.Length; i++)
            {
                var abPath = BuildApplication.mABDataPaths[i];
                // var actorFiles = Directory.GetFiles(abPath, "*", SearchOption.AllDirectories);
                var resourcePath = BuildApplication.mResourceDataPaths[i];
                if (Directory.Exists(resourcePath) == true)
                {
                    Debug.LogError(resourcePath + "还原Resource文件夹已存在");
                    throw new System.Exception();
                }
                if (Directory.Exists(abPath) == false)
                {
                    Debug.LogError(abPath + "还原ab文件夹不存在");
                    throw new System.Exception();
                }
                var dir = new DirectoryInfo(abPath);
                dir.MoveTo(resourcePath);
            }
        }
        //设置图集设置
        EditorSettings.spritePackerMode = SpritePackerMode.BuildTimeOnlyAtlas;
    }
    //预移动热更文件
    void PremoveHFFiles()
    {
        //根据热更包类型决定移动资源
        if (mVersionInfo.mAssetBundleType == AssetBundleType.All)
        {
            //转移资源位置
            for (var i = 0; i < BuildApplication.mResourcePaths.Length; i++)
            {
                var resourcePath = BuildApplication.mResourcePaths[i];
                // var actorFiles = Directory.GetFiles(resourcePath, "*", SearchOption.AllDirectories);
                var abPath = BuildApplication.mABPaths[i];
                if (Directory.Exists(abPath) == true)
                {
                    Debug.LogError(abPath + "预移动ab文件夹已存在");
                    throw new System.Exception();
                }
                if (Directory.Exists(resourcePath) == false)
                {
                    Debug.LogError(resourcePath + "预移动Resource文件夹不存在");
                    throw new System.Exception();
                }
                var dir = new DirectoryInfo(resourcePath);
                dir.MoveTo(abPath);
            }
        }
        else if (mVersionInfo.mAssetBundleType == AssetBundleType.Data)
        {
            //转移资源位置
            for (var i = 0; i < BuildApplication.mResourceDataPaths.Length; i++)
            {
                var resourcePath = BuildApplication.mResourceDataPaths[i];
                // var actorFiles = Directory.GetFiles(resourcePath, "*", SearchOption.AllDirectories);
                var abPath = BuildApplication.mABDataPaths[i];
                if (Directory.Exists(abPath) == true)
                {
                    Debug.LogError(abPath + "预移动ab文件夹已存在");
                    throw new System.Exception();
                }
                if (Directory.Exists(resourcePath) == false)
                {
                    Debug.LogError(resourcePath + "预移动Resource文件夹不存在");
                    throw new System.Exception();
                }
                var dir = new DirectoryInfo(resourcePath);
                dir.MoveTo(abPath);
            }
        }

        //刷新资源
        AssetDatabase.Refresh();

    }
    //热更资源构建
    public bool BuildHotFixFiles()
    {
        Debug.Log("开始热更数据构建");
        try
        {
            RuntimePlatform platform = RuntimePlatform.Android;
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
            HotFixEditorTools.GenHofxFixAssets(BuildApplication.mOutputHotFixFilesPath, platform);
            //热更资源转Hash
            AssetUploadToServer.Assets2Hash(BuildApplication.mOutputHotFixFilesPath, "");
            //文件压缩
            CompressHFDatas();
        }
        catch (System.Exception e)
        {
            Debug.LogError("热更数据构建失败");
            Debug.LogError(e.Message);
            Debug.LogError(e.StackTrace);
            return false;
        }
        Debug.Log("热更数据构建完毕");
        return true;
    }
    //构建Lua文件
    public void BuildLuas()
    {
        LuaFileCollector.CollectLuaFiles();
        //文件压缩
        try
        {
            Debug.Log("开始压缩lua");
            FileHelper.CompressFolder(GetLuaPath(), BuildApplication.LuasCompressFilePath);
            Debug.Log("压缩lua完成");
        }
        catch (System.Exception ex)
        {
            throw;
        }
    }

    //进行热更包构建
    BuildResult BuildHFAssets()
    {
        var result = new BuildResult();
        result.result = BuildResultType.Success;
        try
        {
            //转移资源位置
            PremoveHFFiles();
            // // //进行Meta文件重写
            // AssetBundleEditorTools.UpdateAssetsMetas();
            //打包
            BuildAsset();
            //热更资源转Hash
            AssetUploadToServer.Assets2Hash(BuildApplication.mOutputABPath, "");
            //压缩热更资源
            CompressHFAsset();
        }
        catch (System.Exception ex)
        {
            result.result = BuildResultType.Fail;
            result.errorMessage = ex.Message + "\n" + ex.StackTrace;
        }
        return result;
    }
    //exe压缩
    void CompressExe()
    {
        Debug.Log("开始压缩exe");
        //移动exe文件到指定目录
        if (Directory.Exists(BuildApplication.ExeCompressPath) == true)
        {
            Directory.Delete(BuildApplication.ExeCompressPath, true);
        }
        Directory.CreateDirectory(BuildApplication.ExeCompressPath);
        var rootPath = "";
        if (mVersionInfo.mBuildTarget == BuildTargetType.Android)
        {
            rootPath = BuildApplication.OutputAppForAndroid;
            var apkFile = Path.GetFullPath(mOutputFileName);
            var shortName = Path.GetFileName(apkFile);
            var shortNameWithoutEx = Path.GetFileNameWithoutExtension(apkFile);
            var outputrootPath = BuildApplication.ExeCompressPath;
            File.Copy(apkFile, Path.Combine(outputrootPath, shortName));
            //压缩
            FileHelper.CompressFolder(BuildApplication.ExeCompressPath, Path.Combine(BuildApplication.CompressRootPath, shortNameWithoutEx + ".zip"), false);
        }
        else if (mVersionInfo.mBuildTarget == BuildTargetType.Windows64)
        {
            var exeFile = Path.GetFullPath(mOutputFileName);
            exeFile = exeFile.Replace("\\", "/");
            var exeFileShortName = exeFile.Substring(exeFile.LastIndexOf("/") + 1);
            var exeFilepathshortName = exeFileShortName.Substring(0, exeFileShortName.LastIndexOf("."));
            rootPath = BuildApplication.OutputAppForWindows;
            var handler64 = rootPath + "UnityCrashHandler64.exe";
            var dll = rootPath + "UnityPlayer.dll";
            var runtime = rootPath + "WinPixEventRuntime.dll";
            var monoDirectory = rootPath + "MonoBleedingEdge/";
            var dataDirectory = rootPath + exeFilepathshortName + "_Data";
            //进行移动和拷贝
            var outputexerootPath = BuildApplication.ExeCompressPath;
            var outputDataDirectory = outputexerootPath + "/" + exeFilepathshortName + "_Data";
            var outputMonoDirectory = outputexerootPath + "/MonoBleedingEdge/";
            Directory.CreateDirectory(outputexerootPath);
            File.Copy(handler64, outputexerootPath + "/UnityCrashHandler64.exe");
            File.Copy(dll, outputexerootPath + "/UnityPlayer.dll");
            File.Copy(runtime, outputexerootPath + "/WinPixEventRuntime.dll");
            File.Copy(exeFile, outputexerootPath + "/" + exeFileShortName);
            FileHelper.CopyDirectory(dataDirectory, outputDataDirectory);
            FileHelper.CopyDirectory(monoDirectory, outputMonoDirectory);
            //压缩
            FileHelper.CompressFolder(outputexerootPath, Path.Combine(BuildApplication.CompressRootPath, exeFilepathshortName + ".zip"), false);
        }
        //删除目录
        Directory.Delete(BuildApplication.ExeCompressPath, true);
        Debug.Log("压缩exe完成");
    }
    //压缩热更数据资源
    void CompressHFDatas()
    {
        Debug.Log("开始压缩数据");
        //根据平台处理对应逻辑
        var platform = HFApplication.GetPlatformPath(GetPlatform());
        var compressPath = Path.Combine(BuildApplication.CompressRootPath, platform);
        if (Directory.Exists(compressPath))
        {
            Directory.Delete(compressPath, true);
        }
        //文件压缩
        FileHelper.CopyDirectory(GetHFDataPath(), compressPath);
        FileHelper.CompressFolder(compressPath, BuildApplication.HFDatasCompressPath + ".zip");
        //删除文件夹
        Directory.Delete(compressPath, true);
        Debug.Log("压缩数据完成");
    }

    //压缩热更资源
    void CompressHFAsset()
    {
        Debug.Log("开始压缩热更资源");
        //根据平台处理对应逻辑
        var platform = HFApplication.GetPlatformPath(GetPlatform());
        var compressPath = Path.Combine(BuildApplication.CompressRootPath, platform);
        if (Directory.Exists(compressPath))
        {
            Directory.Delete(compressPath, true);
        }
        //文件压缩
        FileHelper.CopyDirectory(GetHFAssetPath(), compressPath);
        FileHelper.CompressFolder(compressPath, BuildApplication.HFAssetsCompressPath + ".zip");
        //删除文件夹
        Directory.Delete(compressPath, true);
        Debug.Log("压缩热更资源完成");
    }

    //获取Lua路径
    public string GetLuaPath()
    {
        var _outputPath = BuildApplication.mOutputLuaFilesPath;
        return _outputPath;
    }

    public string GetExePath()
    {
        return mOutputFileName;
    }

    //获取热更数据路径
    public string GetHFDataPath()
    {
        var _outputPath = Path.Combine(BuildApplication.mOutputHotFixFilesPath, HFApplication.GetPlatformPath(GetPlatform()));
        _outputPath += "_Hash";
        return _outputPath;
    }

    //获取热更路径
    public string GetHFAssetPath()
    {
        var _outputPath = Path.Combine(BuildApplication.mOutputABPath, HFApplication.GetPlatformPath(GetPlatform()));
        _outputPath += "_Hash";
        return _outputPath;
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

    /// <summary>
    /// 打包ab资源
    /// </summary>
    public void BuildAsset()
    {
        //设置图集设置
        EditorSettings.spritePackerMode = SpritePackerMode.Disabled;
        RuntimePlatform platform = RuntimePlatform.Android;
        BuildTarget buildTarget = BuildTarget.Android;

        if (mVersionInfo.mBuildTarget == BuildTargetType.Android)
        {
            platform = RuntimePlatform.Android;
            buildTarget = BuildTarget.Android;
        }
        else if (mVersionInfo.mBuildTarget == BuildTargetType.IOS)
        {
            platform = RuntimePlatform.IPhonePlayer;
            buildTarget = BuildTarget.iOS;
        }
        else if (mVersionInfo.mBuildTarget == BuildTargetType.Windows64)
        {
            platform = RuntimePlatform.WindowsPlayer;
            buildTarget = BuildTarget.StandaloneWindows64;
        }

        var assetConfig = HFEditorApplication.HFEditorSetting.BuildAssetConfig;
        //生成Assetbundlebunle
        AssetBundleEditorTools.GenAssetBundle(BuildApplication.mOutputABPath, platform, buildTarget, BuildAssetBundleOptions.ChunkBasedCompression, assetConfig.IsUseHashName);
        Debug.Log("资源打包完毕");
        AssetBundleEditorTools.EncryptionProcess(BuildApplication.mOutputABPath, platform, mVersionInfo.mNeedEncrypt);
        // //由于unity打ab包后会改写meta文件 打完包后进行Meta文件重写
        // AssetBundleEditorTools.UpdateAssetsMetas();
    }
    //生成资源加载配置
    public void GenResourcesLoadConfig(System.Action<string> errorFun)
    {
        var resourceconfig = new ResourcesLoadConfig();
        resourceconfig.mNeedAssetsHotFix = mVersionInfo.mNeedAssetsHotFix;
        //写入相应位置
        var filename = "";
        filename = filename.Replace('\\', '/');
        var folderName = filename.Substring(0, filename.LastIndexOf("/") + 1);
        if (Directory.Exists(folderName) == false)
        {
            Directory.CreateDirectory(folderName);
        }
        if (File.Exists(filename))
        {
            File.Delete(filename);
        }
        FileStream fs = new FileStream(filename, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        string json = JsonConvert.SerializeObject(resourceconfig);
        // string json = JsonConvert.SerializeObject(levelModel);
        try
        {
            sw.Write(json);
        }
        catch (System.Exception ex)
        {
            if (errorFun != null)
            {
                errorFun(ex.Message);
            }
        }
        finally
        {
            sw.Close();
        }
        AssetDatabase.Refresh();
    }
    //打包后处理
    void BuildPostProcess()
    {
        if (mVersionInfo.mNeedAssetsHotFix)
        {
            ResetOGHFStatus();
        }
        // //热更资源位置还原
        // if (mVersionInfo.mNeedAssetsHotFix)
        // {
        //     //转移资源位置
        //     for (var i = 0; i < BuildApplication.mResourcePaths.Length; i++)
        //     {
        //         var abPath = BuildApplication.mABPaths[i];
        //         var actorFiles = Directory.GetFiles(abPath, "*", SearchOption.AllDirectories);
        //         var resourcePath = BuildApplication.mResourcePaths[i];
        //         for (var j = 0; j < actorFiles.Length; j++)
        //         {
        //             var actorFile = actorFiles[j];
        //             actorFile = actorFile.Replace("\\", "/");
        //             var directory = actorFile.Substring(0, actorFile.LastIndexOf('/') + 1);
        //             directory = directory.Replace(abPath, resourcePath);
        //             var actorFileName = actorFile.Substring(actorFile.LastIndexOf('/') + 1);
        //             if (File.Exists(directory + actorFileName) == false)
        //             {
        //                 File.Move(actorFile, directory + actorFileName);
        //             }
        //         }
        //     }
        // }
        // AssetDatabase.Refresh();
    }

    //完成处理
    [PostProcessBuildAttribute(100)]
    public static void OnPostBuildProcessForAndroid(BuildTarget target, string pathToBuiltProject)
    {
        //if(target != BuildTarget.Android)
        //	return;
        //      ChannelInfo curSelectedChannelInfo = VersionInfo.mChannelInfos[mCurSelectedChannel]; //当前窗口选择的渠道
        //Debug.Log("PostBuildProcess:" + pathToBuiltProject);
        ////修改Proguard-unity.txt
        //string proguardFilePath = pathToBuiltProject + "/unityLibrary/proguard-unity.txt";
        //StreamReader sr = new StreamReader(proguardFilePath);
        //      string fileContent = sr.ReadToEnd();
        //      sr.Close();
        //      //fileContent += "\n-keep class com.sm2g.** {*;}";
        //      //fileContent += "\n-keep class com.google.** { *; }";
        ////友盟混淆
        //      fileContent += "\n-keep class com.umeng.** {*;}";
        //      fileContent += "\n-keepclassmembers class * { public <init> (org.json.JSONObject); }";
        //      fileContent += "\n-keepclassmembers enum * { public static **[] values(); public static ** valueOf(java.lang.String); }";
        //fileContent += "\n-keep public class " + curSelectedChannelInfo.mPackageName + ".R$*{ public static final int *; }";
        //      ////穿山甲广告sdk需要配置的混淆
        //      //fileContent += "\n-keep class com.bytedance.sdk.openadsdk.** { *; }";
        //      //fileContent += "\n-keep public interface com.bytedance.sdk.openadsdk.downloadnew.** {*;}";
        //      //fileContent += "\n-keep class com.ss.sys.ces.* {*;}";

        //      ////穿山甲以下类是原生广告的自定义java类，需要keep住，开发者自实现时，也需要keep住。
        //      //fileContent += "\n-keep class com.bytedance.android.NativeAdManager {*;}";
        //      //fileContent += "\n-keep class com.bytedance.android.IntersititialView {*;}";
        //      //fileContent += "\n-keep class com.bytedance.android.BannerView {*;}";

        //      StreamWriter sw = new StreamWriter(proguardFilePath);
        //      sw.Write(fileContent);
        //      sw.Close();

        //      //修改应用安装名称
        //      string stringXmlFilePath = pathToBuiltProject + "/" + "launcher" + "/src/main/res/values/strings.xml";
        //      sr = new StreamReader(stringXmlFilePath);
        //      fileContent = sr.ReadToEnd();
        //      sr.Close();
        //      //修改应用名称
        //      fileContent = fileContent.Replace(PlayerSettings.productName, curSelectedChannelInfo.mAppName);
        //      sw = new StreamWriter(stringXmlFilePath);
        //      sw.Write(fileContent);
        //      sw.Close();
        //      PlayerSettings.productName = curSelectedChannelInfo.mAppName;
        //      //拷贝中文名称的文件
        //      if (File.Exists("Assets/Plugins/Android/res/values-zh/values-zh.xml"))
        //      {
        //          string destResFolder = pathToBuiltProject + "/" + "launcher/src/main/res";
        //          Directory.CreateDirectory(destResFolder + "/values-zh");
        //          File.Copy("Assets/Plugins/Android/res/values-zh/values-zh.xml", destResFolder + "/values-zh/values-zh.xml");
        //      }
        ////拷贝繁体中文名称的文件
        //      if (File.Exists("Assets/Plugins/Android/res/values-zh-rTW/values-zh-rTW.xml"))
        //      {
        //          string destResFolder = pathToBuiltProject + "/" + "launcher/src/main/res";
        //          Directory.CreateDirectory(destResFolder + "/values-zh-rTW");
        //          File.Copy("Assets/Plugins/Android/res/values-zh-rTW/values-zh-rTW.。。", destResFolder + "/values-zh-rTW/values-zh-rTW.xml");
        //      }

        //      //修改gradle.properties
        //      string gradlepropertiesFilePath = pathToBuiltProject + "/gradle.properties";
        //StreamReader gradleSr = new StreamReader(gradlepropertiesFilePath);
        //      string gradlefileContent = gradleSr.ReadToEnd();
        //      gradleSr.Close();
        //gradlefileContent += "\nandroid.useAndroidX=true";
        //gradlefileContent += "\nandroid.enableJetifier=true";

        //      StreamWriter gradlesw = new StreamWriter(gradlepropertiesFilePath);
        //      gradlesw.Write(gradlefileContent);
        //      gradlesw.Close();
    }

    // #endif
}
