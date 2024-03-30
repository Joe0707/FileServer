using HotfixFrame.Resource;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace HotfixFrame.ResourceMgr
{
    /// <summary>
    /// manifest 
    /// </summary>
    public class ManifestLoder
    {
        /// <summary>
        /// 配置
        /// </summary>
        public ManifestConfig Manifest { get; private set; }

        /// <summary>
        /// 加载接口
        /// </summary>
        /// <param name="path"></param>
        /// <param name="onLoaded"></param>
        public void Load(string path)
        {
            if (File.Exists(path))
            {
                var content = File.ReadAllText(path);
                this.Manifest = JsonConvert.DeserializeObject<ManifestConfig>(content);
            }
            else
            {
                Debug.LogWarning("配置文件不存在:" + path);
            }
        }
    }
}