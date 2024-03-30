using HotfixFrame.Core.Tools;
using HotfixFrame.Resource;
using HotfixFrame.ResourceMgr;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
using System.Reflection;
public class AssetBundleManager : IAssetBundleLoader
{
    static public string ArtPath = "Art";
    private ManifestLoder loder;
    readonly static public string CONFIGPATH = "Art/Config.json";
    readonly static public string ENCRYPTIONPATH = "Art/Encryption.json";
    //protected string m_ABConfigABName = "assetbundleconfig";

    //资源关系依赖配表，可以根据crc来找到对应资源块
    protected Dictionary<uint, List<ManifestResItem>> m_ResouceItemDic = new Dictionary<uint, List<ManifestResItem>>();

    //储存已加载的AB包，key为AB包名的crc 因为ab名不会有重复的所以用ab包名作为Key
    protected Dictionary<uint, AssetBundleItem> m_AssetBundleItemDic = new Dictionary<uint, AssetBundleItem>();

    //AssetBundleItem类对象池
    protected ClassObjectPool<AssetBundleItem> m_AssetBundleItemPool =
        ClassObjectManager.Instance.GetOrCreatClassPool<AssetBundleItem>(500);

    public string ABLoadPath
    {
        get
        {
            return Application.persistentDataPath + HFApplication.GetPlatformPath(Application.platform);
            // #if UNITY_ANDROID
            //             return Application.persistentDataPath;
            // #else
            //             return Application.persistentDataPath + "/Windows/";
            // #endif
        }
    }
    private Assembly unityengineAssembly;//Unity引擎程序集
    /// <summary>
    /// 加载ab配置表
    /// </summary>
    /// <returns></returns>
    public bool LoadAssetBundleConfig()
    {
        // #if UNITY_EDITOR
        if (!ResourcesManager.Instance.m_LoadFormAssetBundle)
            return false;
        // #endif

        m_ResouceItemDic.Clear();
        //string configPath = ABLoadPath + m_ABConfigABName;
        //string hotABPath = string.Format("{0}/{1}/Art", ABLoadPath, HFApplication.GetPlatformPath(Application.platform))
        //        .Replace("\\", "/");
        //configPath = string.IsNullOrEmpty(hotABPath) ? configPath : hotABPath;
        //byte[] bytes = AES.AESFileByteDecrypt(configPath, "Ocean");
        //AssetBundle configAB = AssetBundle.LoadFromMemory(bytes);
        //TextAsset textAsset = configAB.LoadAsset<TextAsset>(m_ABConfigABName);
        //if (textAsset == null)
        //{
        //    Debug.LogError("AssetBundleConfig is no exist!");
        //    return false;
        //}

        //MemoryStream stream = new MemoryStream(textAsset.bytes);
        //BinaryFormatter bf = new BinaryFormatter();
        //AssetBundleConfig config = (AssetBundleConfig) bf.Deserialize(stream);
        //加载Config
        var configPath = "";
        this.loder = new ManifestLoder();
        // if (Application.isEditor)
        // {
        configPath = string.Format("{0}/{1}/{2}", ABLoadPath, HFApplication.GetPlatformPath(Application.platform),
            AssetBundleManager.CONFIGPATH);
        // }
        // else
        // {
        //     //真机环境config在persistent，跟dll和db保持一致
        //     configPath = string.Format("{0}/{1}/{2}", ABLoadPath, HFApplication.GetPlatformPath(Application.platform),
        //         AssetBundleManager.CONFIGPATH);
        // }

        this.loder.Load(configPath);

        var config = this.loder.Manifest;
        if (config == null)
        {
            return false;
        }
        var map = config.ManifestMap;
        foreach (var pair in map)
        {
            List<ManifestResItem> list = null;
            var crc = Crc32.GetCrc32(pair.Key);
            if (m_ResouceItemDic.ContainsKey(crc))
            {
                list = m_ResouceItemDic[crc];
            }
            else
            {
                list = new List<ManifestResItem>();
                m_ResouceItemDic[crc] = list;
            }
            List<ManifestItem> abBaseList = pair.Value.List;
            for (var i = 0; i < abBaseList.Count; i++)
            {
                var abBase = abBaseList[i];
                var dependlist = new List<ManifestResDependItem>();
                for (var j = 0; j < abBase.Depend.Length; j++)
                {
                    dependlist.Add(new ManifestResDependItem(abBase.Depend[j].AssetClassName, abBase.Depend[j].DependPath));
                }
                ManifestResItem item = new ManifestResItem();
                item.m_Crc = crc;
                item.m_AssetName = abBase.AssetName;
                item.m_ABName = abBase.ABPath;
                item.m_DependAssetBundle = dependlist;
                item.AssetClassName = abBase.AssetClassName;
                item.m_Type = abBase.Type;
                if (list.FirstOrDefault((a) => { return a.m_Crc == crc; }) == null)
                {
                    list.Add(item);
                }
                else
                {
                    Debug.LogError("重复的Crc 资源名:" + abBase.AssetName + " ab包名：" + abBase.ABPath);
                }
            }
            // if (m_ResouceItemDic.ContainsKey(item.m_Crc))
            // {
            // }
            // else
            // {
            //     m_ResouceItemDic.Add(item.m_Crc, item);
            // }

        }
        unityengineAssembly = Assembly.GetAssembly(typeof(UnityEngine.Object));
        return true;
    }
    /// <summary>
    /// 寻找加载地址
    /// </summary>
    /// <param name="assetFileName"></param>
    /// <returns></returns>
    public string FindAsset(string assetFileName)
    {
        ////第一地址
        //var p = IPath.Combine(this.firstArtDirectory, assetFileName);
        ////寻址到第二路径,第二地址没有就放弃
        //if (!File.Exists(p))
        //{
        //    p = IPath.Combine(this.secArtDirectory, assetFileName);
        //}

        return string.Format("{0}/{1}/{2}/{3}", ABLoadPath, HFApplication.GetPlatformPath(Application.platform), ArtPath, assetFileName)
                .Replace("\\", "/"); ;
    }

    /// <summary>
    /// 根据路径的crc加载中间类ResoucItem
    /// </summary>
    /// <param name="crc"></param>
    /// <returns></returns>
    public ResouceItem LoadResouceAssetBundle(string path, string typeName, bool isClear = true)
    {
        ResouceItem result = null;
        List<ManifestResItem> list = null;
        ManifestResItem item = null;
        uint crc = Crc32.GetCrc32(path);
        if (!m_ResouceItemDic.TryGetValue(crc, out list) || list == null)
        {
            // Debug.LogWarning(string.Format("release can not find path {0} in AssetBundleConfig",
            //     path));
            return result;
        }
        else
        {
            item = list.FirstOrDefault((a) => { return a.AssetClassName == typeName; });
            if (item == null)
            {
                var resType = unityengineAssembly.GetType(typeName);
                //再判断是否是基类
                foreach (var resItem in list)
                {
                    //判断是否是场景类型
                    if (resItem.AssetClassName == "UnityEditor.SceneAsset")
                    {
                        //说明是场景类型
                        if (typeName == typeof(UnityEngine.Object).FullName)
                        {
                            //则找到
                            item = resItem;
                            break;
                        }
                    }
                    else
                    {

                        var itemType = unityengineAssembly.GetType(resItem.AssetClassName);
                        if (itemType.IsSubclassOf(resType))
                        {
                            //则找到
                            item = resItem;
                            break;
                        }
                    }
                }
                if (item == null)
                {
                    // Debug.LogWarning(string.Format("LoadResourceAssetBundle error: can not find path {0} in AssetBundleConfig",
                    //     path.ToString()));
                    return result;
                }
            }


            if (item.m_DependAssetBundle != null)
            {
                for (int i = 0; i < item.m_DependAssetBundle.Count; i++)
                {
                    //尝试加载资源表中资源
                    if (LoadResouceAssetBundle(item.m_DependAssetBundle[i].Depend, item.m_DependAssetBundle[i].AssetClassName, isClear) == null)
                    {
                        //失败则直接加载资源 加载资源的ab路径可能重复需要加类型
                        LoadAssetBundle(item.m_DependAssetBundle[i].Depend, isClear);
                    }
                }
            }
            //资源表内的资源ab路径名不会重复 类型名统一为""
            result = new ResouceItem();
            result.m_AssetBundle = LoadAssetBundle(item.m_ABName, isClear);
            result.m_AssetName = item.m_AssetName;
            result.m_Crc = item.m_Crc;
            result.AssetClassName = item.AssetClassName;
            result.m_Type = item.m_Type;
            return result;
        }
    }
    // /// <summary>
    // /// 加载资源集
    // /// </summary>
    // /// <param name="path"></param>
    // /// <returns></returns>
    // public List<ResouceItem> LoadResourceAssetBundles(string path)
    // {
    //     var result = new List<ResouceItem>();
    //     var items = m_ResouceItemDic.Values;
    //     //获取路径相关的资源
    //     foreach (var item in items)
    //     {
    //         if (item.m_AssetName.Contains(path))
    //         {
    //             result.Add(item);
    //         }
    //     }
    //     if (result.Count == 0)
    //     {
    //         Debug.LogError(string.Format("LoadResourceAssetBundle error: can not find {0} in AssetBundleConfig",
    //         path));
    //         return result;
    //     }
    //     for (var i = 0; i < result.Count; i++)
    //     {
    //         var item = result[i];
    //         if (item.m_DependAssetBundle != null)
    //         {
    //             for (int j = 0; j < item.m_DependAssetBundle.Count; j++)
    //             {
    //                 LoadAssetBundle(item.m_DependAssetBundle[j]);
    //             }
    //         }
    //         item.m_AssetBundle = LoadAssetBundle(item.m_ABName);

    //     }
    //     return result;
    // }

    /// <summary>
    /// 加载单个assetbundle根据名字
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private AssetBundle LoadAssetBundle(string name, bool isClear = true)
    {
        AssetBundleItem item = null;
        uint crc = Crc32.GetCrc32(name);
        // List<AssetBundleItem> list = null;
        bool isInCache = false;
        if (m_AssetBundleItemDic.TryGetValue(crc, out item))
        {
            // item = list.FirstOrDefault((a) => { return a.AssetClassName == assetClassName; });
            if (item != null)
            {
                isInCache = true;
                // if (item.isFileMemoryExsit == false)
                // {
                //     //如果abitem文件内存已经被删除并且再次加载item，则删除item重新加载
                //     UnLoadAssetBundle(name, assetClassName, true);
                //     isInCache = false;
                // }
            }
        }
        if (!isInCache)
        {
            AssetBundle assetBundle = null;

            //string hotABPath = HotPatchManager.Instance.ComputeABPath(name);
            ////如果有热更的，走热更，没有就走本地
            //string fullPath = string.IsNullOrEmpty(hotABPath) ? ABLoadPath + name : hotABPath;
            string fullPath = FindAsset(name);
            //byte[] bytes = AES.AESFileByteDecrypt(fullPath, "Ocean");
            ulong offset = 0;
            if (this.loder.Manifest.IsEncrypt)
            {
                //进行解密
                offset = FileHelper.GetEncryptionOffset(name);
            }
            assetBundle = AssetBundle.LoadFromFile(fullPath, 0, offset);
            if (assetBundle == null)
            {
                Debug.LogError(" Load AssetBundle Error:" + fullPath);
                return null;
            }

            item = m_AssetBundleItemPool.Spawn(true);
            item.assetBundle = assetBundle;
            item.RefCount++;
            // item.AssetClassName = assetClassName;
            item.isClear = isClear;
            item.ABName = name;
            // item.isFileMemoryExsit = true;
            // if (list == null)
            // {
            //     list = new List<AssetBundleItem>();
            m_AssetBundleItemDic[crc] = item;
            // }
            // list.Add(item);
        }
        else
        {
            item.RefCount++;
        }

        return item.assetBundle;
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    /// <param name="item"></param>
    public void ReleaseAsset(ResouceItem item, bool force = false)
    {
        if (item == null)
        {
            return;
        }
        //根据CRC获取依赖信息
        List<ManifestResItem> list = null;
        ManifestResItem maniItem = null;
        if (!m_ResouceItemDic.TryGetValue(item.m_Crc, out list) || list == null)
        {
            // Debug.LogWarning(string.Format("can not find crc {0} assetName {1} in AssetBundleConfig",
            //     item.m_Crc.ToString(), item.m_AssetName));
        }
        else
        {
            maniItem = list.FirstOrDefault((a) => { return a.AssetClassName == item.AssetClassName; });
        }
        if (maniItem != null)
        {
            if (maniItem.m_DependAssetBundle != null && maniItem.m_DependAssetBundle.Count > 0)
            {
                for (int i = 0; i < maniItem.m_DependAssetBundle.Count; i++)
                {
                    UnLoadAssetBundle(maniItem.m_DependAssetBundle[i].Depend, force);
                }
            }

            UnLoadAssetBundle(maniItem.m_ABName, force);
        }
    }
    // //卸载abitem的文件内存
    // public void UnLoadAssetBundleFileMemory(string name, string className)
    // {
    //     List<AssetBundleItem> itemList = null;
    //     AssetBundleItem item = null;
    //     uint crc = Crc32.GetCrc32(name);
    //     if (m_AssetBundleItemDic.TryGetValue(crc, out itemList))
    //     {
    //         item = itemList.FirstOrDefault((a) => { return a.AssetClassName == className; });
    //         item.assetBundle.Unload(false);
    //         // item.isFileMemoryExsit = false;
    //     }

    // }

    private void UnLoadAssetBundle(string name, bool force = false)
    {
        // List<AssetBundleItem> itemList = null;
        AssetBundleItem item = null;
        uint crc = Crc32.GetCrc32(name);
        if (m_AssetBundleItemDic.TryGetValue(crc, out item))
        {
            // item = itemList.FirstOrDefault((a) => { return a.AssetClassName == className; });
            if (item != null)
            {
                if (force && item.isClear)
                {
                    item.assetBundle.Unload(true);
                    item.Rest();
                    m_AssetBundleItemPool.Recycle(item);
                    m_AssetBundleItemDic.Remove(crc);
                }
                else
                {
                    item.RefCount--;
                    if (item.RefCount <= 0 && item.assetBundle != null)
                    {
                        item.assetBundle.Unload(true);
                        item.Rest();
                        m_AssetBundleItemPool.Recycle(item);
                        m_AssetBundleItemDic.Remove(crc);
                    }
                }
            }
        }
    }

    // /// <summary>
    // /// 根据crc朝赵ResouceItem
    // /// </summary>
    // /// <param name="crc"></param>
    // /// <returns></returns>
    // public ResouceItem FindResourceItme(uint crc)
    // {
    //     ResouceItem item = null;
    //     m_ResouceItemDic.TryGetValue(crc, out item);
    //     return item;
    // }
    /// <summary>
    /// 根据路径查找ResourceItems集合
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public List<string> FindResourceABPaths(string path)
    {
        var result = new List<string>();
        foreach (var item in m_ResouceItemDic)
        {
            var itemlist = item.Value;
            for (var i = 0; i < itemlist.Count; i++)
            {
                if (itemlist[i].m_AssetName.Contains(path))
                {
                    result.Add(itemlist[i].m_ABName);
                }
            }
        }
        // var items = m_ResouceItemDic.Values;
        // //获取路径相关的资源
        // foreach (var item in items)
        // {
        //     if (item.m_AssetName.Contains(path))
        //     {
        //         result.Add(item);
        //     }
        // }
        return result;
    }
}

public class AssetBundleItem
{
    public string ABName = "";//AB包名
    public AssetBundle assetBundle = null;
    public int RefCount;
    // public string AssetClassName = "";
    public bool isClear = true;
    // public bool isFileMemoryExsit = false;
    public void Rest()
    {
        assetBundle = null;
        RefCount = 0;
        ABName = "";
        isClear = true;
        // isFileMemoryExsit = false;
    }
}

public class ManifestResDependItem
{
    public ManifestResDependItem(string assetClassName, string depend)
    {
        this.AssetClassName = assetClassName;
        this.Depend = depend;
    }
    public string AssetClassName = "";
    public string Depend = "";
}

public class ManifestResItem
{
    //资源路径Crc
    public uint m_Crc = 0;
    //资源类型名
    public string AssetClassName = "";
    //该资源的文件名
    public string m_AssetName = string.Empty;

    //该资源所在的AssetBundle
    public string m_ABName = string.Empty;
    //资源类型
    public int m_Type = -1;
    //该资源所依赖的AssetBundle
    public List<ManifestResDependItem> m_DependAssetBundle = null;
}
