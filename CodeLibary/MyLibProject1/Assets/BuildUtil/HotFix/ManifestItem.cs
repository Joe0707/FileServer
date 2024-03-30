using System.Collections.Generic;

namespace HotfixFrame.Resource
{
    public class ManifestDependItem
    {
        public ManifestDependItem(string AssetClassName, string DependPath)
        {
            this.AssetClassName = AssetClassName;
            this.DependPath = DependPath;
        }
        public ManifestDependItem()
        {

        }
        public string AssetClassName;
        public string DependPath;
        public int Type;
    }
    /// <summary>
    /// 存储单个资源的数据
    /// </summary>
    public class ManifestItem
    {
        public enum AssetTypeEnum
        {
            Others = 0,
            Prefab = 1,
            TextAsset = 2,
            Texture = 3,
            SpriteAtlas = 4,
            Mat = 5,
            Shader = 6,
            SpriteInSpriteAtlas = 7,
            Scene = 8,
            Custom = 9 //自定义类型 没有实际的资源
        }

        public ManifestItem(string path, AssetTypeEnum @enum, ManifestDependItem[] depend = null, string assetName = "", string assetClassName = "")
        {
            this.ABPath = path;
            //this.AB = ab;
            this.Type = (int)@enum;
            this.Depend = depend;
            this.AssetName = assetName;
            this.AssetClassName = assetClassName;
        }

        /// <summary>
        /// 给litjson 用的构造
        /// </summary>
        public ManifestItem()
        {

        }

        /// <summary>
        /// ab的资源路径名
        /// </summary>
        public string ABPath { get; set; }
        /// <summary>
        /// 加载ab的资源名
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 资源类型名
        /// </summary>
        /// <value></value>
        public string AssetClassName { get; set; }
        /// <summary>
        /// 依赖
        /// </summary>
        public ManifestDependItem[] Depend { get; set; } = null;
    }
}