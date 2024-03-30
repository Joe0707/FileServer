using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace HotfixFrame.Resource
{
    public class ManifestItems
    {
        public ManifestItems()
        {

        }
        public ManifestItems(List<ManifestItem> list)
        {
            this.List = list;
        }

        public List<ManifestItem> List = new List<ManifestItem>();
    }

    /// <summary>
    /// 配置文件
    /// </summary>
    public class ManifestConfig
    {

        /// <summary>
        /// 是否为hash命名
        /// </summary>
        public bool IsHashName { get; set; } = false;
        /// <summary>
        /// 是否是加密资源
        /// </summary>
        /// <value></value>
        public bool IsEncrypt { get; set; } = false;
        /// <summary>
        /// 加载路径名-资源数据
        /// </summary>
        public Dictionary<string, ManifestItems> ManifestMap { get; set; } = new Dictionary<string, ManifestItems>();


        // /// <summary>
        // /// 获取单个依赖
        // /// </summary>
        // /// <param name="menifestName"></param>
        // /// <returns>这个list外部不要修改</returns>
        // public List<string> GetDependenciesByName(string name)
        // {
        //     ManifestItem item = null;
        //     if (this.ManifestMap.TryGetValue(name, out item))
        //     {
        //         var list = new List<string>(item.Depend);
        //         return list;
        //     }

        //     Debug.LogError("【config】不存在资源:" + name);
        //     return null;
        // }


        // /// <summary>
        // /// 获取单个menifestItem
        // /// </summary>
        // /// <param name="manifestName"></param>
        // /// <returns></returns>
        // public ManifestItem GetManifest(string manifestName)
        // {
        //     if (!string.IsNullOrEmpty(manifestName))
        //     {
        //         ManifestItem item = null;
        //         this.ManifestMap.TryGetValue(manifestName, out item);
        //         return item;
        //     }

        //     return null;
        // }
    }
}