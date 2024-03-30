using HotfixFrame.Editor.BuildPackage;
using HotfixFrame.Editor.Tools;
using System;
using UnityEditor;
using UnityEngine;
using System.IO;
using HotfixFrame.Core.Tools;
namespace HotfixFrame.Editor.Asset
{
    public class EditorWindow_GenAssetBundle : EditorWindow
    {
        [MenuItem("工具箱/AssetBundle打包")]
        public static void Open()
        {
            var window = EditorWindow.GetWindow<EditorWindow_GenAssetBundle>(false, "AB打包工具");
            window.Show();
        }
        [MenuItem("工具箱/解密Ab资源")]
        public static void DecryptAB()
        {
            var rootPath = Application.dataPath;
            rootPath = rootPath.Replace("\\", "/");
            var path = rootPath.Substring(0, rootPath.LastIndexOf('/', rootPath.LastIndexOf("/") - 1)) + "/DecryptAB/";
            path = Path.Combine(path, HFApplication.GetPlatformPath(Application.platform));
            path = IPath.Combine(path, AssetBundleManager.ArtPath);
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            Debug.Log("开始解密");
            var count = 0;
            foreach (var file in files)
            {
                //不对json处理
                if (Path.GetExtension(file) != ".json")
                {
                    var filename = file.Replace("\\", "/");
                    //生成相对文件路径
                    var relativefile = filename.Replace(path + "/", "");
                    //如果是不加密并且加密过则解密
                    FileHelper.DecryptFile(file, relativefile);
                    count++;
                }
            }
            Debug.Log("解密完成" + count);
        }
        ///// <summary>
        ///// 资源下面根节点
        ///// </summary>
        //public string rootResourceDir = "Resource/Runtime/";

        private bool isSelectIOS = false;

        private bool isSelectAndroid = false;
        private bool isSelectWindows = true;


        //
        void DrawToolsBar()
        {
            GUILayout.Label("平台选择:");
            GUILayout.BeginHorizontal();
            {
                GUILayout.Space(30);
                isSelectAndroid = GUILayout.Toggle(isSelectAndroid, "生成Android资源(Windows共用)");
            }
            GUILayout.EndHorizontal();
            //
            GUILayout.BeginHorizontal();
            {
                GUILayout.Space(30);
                isSelectIOS = GUILayout.Toggle(isSelectIOS, "生成iOS资源");
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            {
                GUILayout.Space(30);
                isSelectWindows = GUILayout.Toggle(isSelectWindows, "生成Window64资源");
            }
            GUILayout.EndHorizontal();

            //
        }

        public void OnGUI()
        {
            GUILayout.BeginVertical(GUILayout.Height(220));
            TipsGUI();
            DrawToolsBar();
            GUILayout.Space(10);
            LastestGUI();
            GUILayout.Space(75);
            GUILayout.EndVertical();
        }

        private BuildAssetBundleOptions options = BuildAssetBundleOptions.ChunkBasedCompression;

        /// <summary>
        /// 提示UI
        /// </summary>
        void TipsGUI()
        {
            GUILayout.Label("资源打包", EditorGUIHelper.TitleStyle);
            GUILayout.Space(5);
            //GUILayout.Label("资源根目录:");
            //foreach (var root in BDApplication.GetAllRuntimeDirects())
            //{
            //    GUILayout.Label(root);
            //}

            GUILayout.Label(string.Format("AB输出目录:{0}", exportPath));
            options = (BuildAssetBundleOptions)EditorGUILayout.EnumPopup("压缩格式:", options);

            var assetConfig = HFEditorApplication.HFEditorSetting.BuildAssetConfig;
            //assetConfig.AESCode = EditorGUILayout.TextField("AES密钥(V2 only):",  assetConfig.AESCode );
            assetConfig.IsUseHashName = EditorGUILayout.Toggle("hash命名:", assetConfig.IsUseHashName);

        }


        //private void OnDestroy()
        //{
        //    //保存
        //    HFEditorApplication.HFEditorSetting?.Save();
        //}


        private string exportPath = "";

        /// <summary>
        /// 最新包
        /// </summary>
        void LastestGUI()
        {
            GUILayout.BeginVertical();


            if (GUILayout.Button("收集Shader keyword", GUILayout.Width(200)))
            {
                ShaderCollection.GenShaderVariant();
            }

            if (GUILayout.Button("一键打包[美术资源]", GUILayout.Width(380), GUILayout.Height(30)))
            {
                exportPath = EditorUtility.OpenFolderPanel("选择导出目录", Application.dataPath, "");
                if (string.IsNullOrEmpty(exportPath))
                {
                    return;
                }

                // 搜集keyword
                // ShaderCollection.GenShaderVariant();
                //开始打包
                BuildAsset();
            }

            //if (GUILayout.Button("AssetBundle还原目录", GUILayout.Width(380), GUILayout.Height(30)))
            //{
            //    exportPath = EditorUtility.OpenFolderPanel("选择资源目录", Application.dataPath, "");
            //    if (string.IsNullOrEmpty(exportPath))
            //    {
            //        return;
            //    }

            //    //AssetBundleEditorTools.HashName2AssetName(exportPath);
            //}
            if (GUILayout.Button("热更资源转Hash", GUILayout.Width(380), GUILayout.Height(30)))
            {
                //选择目录
                exportPath = EditorUtility.OpenFolderPanel("选择导出目录", exportPath, "");
                if (string.IsNullOrEmpty(exportPath))
                {
                    return;
                }

                //自动转hash
                AssetUploadToServer.Assets2Hash(exportPath, "");

            }
            GUILayout.EndVertical();
        }


        /// <summary>
        /// 打包资源
        /// </summary>
        public void BuildAsset()
        {
            RuntimePlatform platform = RuntimePlatform.Android;
            BuildTarget buildTarget = BuildTarget.Android;

            if (isSelectAndroid)
            {
                platform = RuntimePlatform.Android;
                buildTarget = BuildTarget.Android;
            }
            else if (isSelectIOS)
            {
                platform = RuntimePlatform.IPhonePlayer;
                buildTarget = BuildTarget.iOS;
            }
            else if (isSelectWindows)
            {
                platform = RuntimePlatform.WindowsPlayer;
                buildTarget = BuildTarget.StandaloneWindows64;
            }


            var assetConfig = HFEditorApplication.HFEditorSetting.BuildAssetConfig;
            //生成Assetbundlebunle
            AssetBundleEditorTools.GenAssetBundle(exportPath, platform, buildTarget, options, assetConfig.IsUseHashName);
            Debug.Log("资源打包完毕");
            AssetDatabase.Refresh();
            Debug.Log("资源刷新完毕");
        }
    }
}