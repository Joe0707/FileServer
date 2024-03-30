using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HotfixFrame.Editor
{
    public class HFEditorSetting
    {
        public BuildAssetConfig BuildAssetConfig = new BuildAssetConfig();

    }
    /// <summary>
    /// 打包设置
    /// </summary>
    public class BuildAssetConfig
    {
        //[LabelText("ASE密钥")]
        //public string AESCode = "bdframe$#@!@#";
        // [LabelText("是否hash命名")]
        public bool IsUseHashName = false;
        // [LabelText("上传接口")]
        public string AssetBundleFileServerUrl = "http://127.0.0.1:20001";
        // [LabelText("自动生成热更DLL")]
        public bool IsAutoBuildDll = true;
    }
}