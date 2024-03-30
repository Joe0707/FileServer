using HotfixFrame.Core.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;
using HotfixFrame.Resource;
using System.Text.RegularExpressions;
namespace HotfixFrame.Editor.Asset
{
    /// <summary>
    /// build依赖信息
    /// </summary>
    public class BuildDependInfo
    {
        public string AssetClassName = "";
        public string DependPath = "";
    }
    /// <summary>
    /// build信息
    /// </summary>
    public class BuildInfo
    {
        public class AssetData
        {
            /// <summary>
            /// Id
            /// </summary>
            public int Id { get; set; } = -1;

            /// <summary>
            /// 资源类型
            /// </summary>
            public int Type { get; set; } = -1;

            /// <summary>
            /// AssetBundleName
            /// 默认AB是等于自己文件名
            /// 当自己自己处于某个ab中的时候这个不为null
            /// </summary>
            public string ABName { get; set; } = "";
            /// <summary>
            /// 资源名
            /// </summary>
            public string AssetName { get; set; } = "";
            /// <summary>
            /// 资源类型名
            /// </summary>
            /// <value></value>
            public string AssetClassName { get; set; } = "";
            /// <summary>
            /// 被依赖次数
            /// </summary>
            public int ReferenceCount { get; set; } = 0;

            /// <summary>
            /// hash
            /// </summary>
            public string Hash { get; set; } = "";

            /// <summary>
            /// 依赖列表
            /// </summary>
            public List<BuildDependInfo> DependList { get; set; } = new List<BuildDependInfo>();

            /// <summary>
            /// 是否被多次引用
            /// </summary>
            public bool IsRefrenceByOtherAsset()
            {
                return this.ReferenceCount > 1;
            }
        }

        /// <summary>
        /// time
        /// </summary>
        public string Time;

        /// <summary>
        /// 资源列表
        /// </summary>
        public Dictionary<string, AssetData> AssetDataMaps = new Dictionary<string, AssetData>();


        public enum ChangeABNameMode
        {
            Simple,
            ForceAll
        }

        /// <summary>
        /// 设置AB名
        /// </summary>
        public bool SetABName(string assetName, string newABName, ChangeABNameMode mode = ChangeABNameMode.Simple)
        {
            //1.如果ab名被修改过,说明有其他规则影响，需要理清打包规则。（比如散图打成图集名）
            //2.如果资源被其他资源引用，修改ab名，需要修改所有引用该ab的名字

            //AssetData assetdata = this.AssetDataMaps.


            return false;
        }
    }

    static public class AssetBundleEditorTools
    {
        //由于Unity问题需要刷新资源的Meta文件
        public static void UpdateAssetsMetas()
        {
            Debug.Log("开始刷新Meta文件");
            var assetPaths = HFApplication.GetABAssetsPath();
            for (int i = 0; i < assetPaths.Count; i++)
            {
                assetPaths[i] = assetPaths[i].ToLower();
            }
            //搜集所有的依赖
            foreach (var mainpath in assetPaths)
            {
                var dependeAssetsPath = GetDependencies(mainpath);
                //获取依赖 并加入build info
                foreach (var subAssetPath in dependeAssetsPath)
                {
                    //把所有回车符号改为换行符
                    var str = File.ReadAllText(subAssetPath + ".meta");
                    var newstr = str.Replace("\r\n", "\n");
                    newstr = newstr.Replace("\n", "\r\n");
                    if (newstr != str)
                    {
                        File.WriteAllText(subAssetPath + ".meta", newstr);
                    }
                }
            }
            Debug.Log("刷新Meta文件完成");
        }
        // //加密AB包
        // public static bool EncryptAssetBundles(string configpath)
        // {

        // }

        //加密处理
        public static void EncryptionProcess(string outputpath, RuntimePlatform platform, bool isEncryption)
        {
            DebugUtil.DebugInfo("开始加密处理");
            //读取config修改配置
            var _outputPath = Path.Combine(outputpath, HFApplication.GetPlatformPath(platform));
            _outputPath = _outputPath.Replace("\\", "/");
            var artOutputPath = IPath.Combine(_outputPath, AssetBundleManager.ArtPath);
            var encryptconfigPath = IPath.Combine(artOutputPath, "Encryption.json");
            var lastencryptConfigInfo = new EncryptionConfig();
            if (File.Exists(encryptconfigPath))
            {
                var content = File.ReadAllText(encryptconfigPath);
                lastencryptConfigInfo = JsonConvert.DeserializeObject<EncryptionConfig>(content);
            }
            var files = Directory.GetFiles(artOutputPath, "*.*", SearchOption.AllDirectories);
            int encryptionNum = 0;
            int decryptionNum = 0;
            foreach (var file in files)
            {
                //不对json处理
                if (Path.GetExtension(file) != ".json")
                {
                    bool isEncrypted = false;
                    var filename = file.Replace("\\", "/");
                    //生成相对文件路径
                    var relativefile = filename.Replace(artOutputPath + "/", "");
                    //判断文件是否加密过
                    string curhash = FileHelper.GetHashFromFile(file);
                    if (lastencryptConfigInfo.Encryptions.ContainsKey(relativefile))
                    {
                        var lasthash = lastencryptConfigInfo.Encryptions[relativefile];
                        //比较hash值
                        if (curhash == lasthash)
                        {
                            isEncrypted = true;
                        }
                    }

                    if (isEncryption == true && isEncrypted == false)
                    {
                        //如果是加密并且没加密过则加密
                        FileHelper.EncryptFile(file, relativefile);
                        curhash = FileHelper.GetHashFromFile(file);
                        if (lastencryptConfigInfo.Encryptions.ContainsKey(relativefile) == false)
                        {
                            lastencryptConfigInfo.Encryptions.Add(relativefile, curhash);
                        }
                        else
                        {
                            lastencryptConfigInfo.Encryptions[relativefile] = curhash;
                        }
                        encryptionNum++;
                    }
                    else if (isEncryption == false && isEncrypted == true)
                    {
                        //如果是不加密并且加密过则解密
                        FileHelper.DecryptFile(file, relativefile);
                        lastencryptConfigInfo.Encryptions.Remove(relativefile);
                        decryptionNum++;
                    }
                }
            }
            DebugUtil.DebugInfo("加密文件数量 " + encryptionNum);
            DebugUtil.DebugInfo("解密文件数量 " + decryptionNum);
            //写入
            FileHelper.WriteAllText(artOutputPath + "/Encryption.json", JsonConvert.SerializeObject(lastencryptConfigInfo));
            //读取config配置
            var configinfoPath = IPath.Combine(artOutputPath, "Config.json");
            var lastConfigInfo = new ManifestConfig();
            if (File.Exists(configinfoPath))
            {
                var content = File.ReadAllText(configinfoPath);
                lastConfigInfo = JsonConvert.DeserializeObject<ManifestConfig>(content);
            }
            lastConfigInfo.IsEncrypt = isEncryption;
            //写入config配置
            FileHelper.WriteAllText(artOutputPath + "/Config.json", JsonConvert.SerializeObject(lastConfigInfo));
            DebugUtil.DebugInfo("加密处理完成");
        }

        //进行加密
        public static void EncryptAssetBundle(string outputPath, RuntimePlatform platform)
        {
            //读取config修改配置
            var _outputPath = Path.Combine(outputPath, HFApplication.GetPlatformPath(platform));
            _outputPath = _outputPath.Replace("\\", "/");
            var artOutputPath = IPath.Combine(_outputPath, AssetBundleManager.ArtPath);
            var configPath = IPath.Combine(artOutputPath, "Encryption.json");
            var lastConfigInfo = new EncryptionConfig();
            if (File.Exists(configPath))
            {
                var content = File.ReadAllText(configPath);
                lastConfigInfo = JsonConvert.DeserializeObject<EncryptionConfig>(content);
            }
            else
            {
                DebugUtil.DebugError("没有Config.json文件,无法加密");
                return;
            }
            DebugUtil.DebugInfo("开始加密");
            var files = Directory.GetFiles(_outputPath, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                //不对json加密
                if (Path.GetExtension(file) != ".json")
                {
                    var filename = file.Replace("\\", "/");
                    filename = filename.Substring(filename.LastIndexOf("/") + 1);
                    //使用文件名作为key
                    FileHelper.EncryptFile(file, filename);
                }
            }
            //写入
            FileHelper.WriteAllText(artOutputPath + "/Config.json", JsonConvert.SerializeObject(lastConfigInfo));
            //读取config文件
            DebugUtil.DebugInfo("加密成功");
        }

        //清空资源ab名
        static void CleanABName()
        {
            var time = System.DateTime.Now;
            var rootPath = Application.dataPath;
            var fileList = new List<string>();
            var files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories).Where((s) => !s.EndsWith(".meta")).ToArray(); ;
            for (int i = 0; i < files.Length; i++)
            {
                var res = files[i];
                res = res.Replace("\\", "/");
                files[i] = res.Replace(HFApplication.ProjectRoot + "/", "");
            }

            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                if (CheckAssetPath(file))
                {
                    fileList.Add(file);
                }
            }
            for (int i = 0; i < fileList.Count; i++)
            {
                //读取资源
                var importer = AssetImporter.GetAtPath(fileList[i]);
                if (importer != null)
                {
                    if (string.IsNullOrEmpty(importer.assetBundleName) == false || string.IsNullOrEmpty(importer.assetBundleVariant) == false)
                    {
                        importer.SetAssetBundleNameAndVariant(string.Empty, string.Empty);
                        Debug.Log(string.Format("清空ab名 ab bundleName{0} ab variantName{1} file {2}", importer.assetBundleName, importer.assetBundleVariant, fileList[i]));
                        AssetDatabase.ImportAsset(fileList[i]);
                    }
                }
            }
            //清除AB包名，防止meta文件进行改变
            string[] oldABNames = AssetDatabase.GetAllAssetBundleNames();
            for (int i = 0; i < oldABNames.Length; i++)
            {
                AssetDatabase.RemoveAssetBundleName(oldABNames[i], true);
                Debug.Log(string.Format("删除ab名 ab bundleName {0}", oldABNames[i]));
            }
            Debug.Log("清空ab花费时间" + (System.DateTime.Now - time).TotalSeconds);
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 生成AssetBundle
        /// </summary>
        /// <param name="outputPath">导出目录</param>
        /// <param name="target">平台</param>
        /// <param name="options">打包参数</param>
        /// <param name="isHashName">是否为hash name</param>
        public static bool GenAssetBundle(string outputPath,
            RuntimePlatform platform,
            BuildTarget target,
            BuildAssetBundleOptions options = BuildAssetBundleOptions.ChunkBasedCompression,
            bool isHashName = false)
        {
            var _outputPath = Path.Combine(outputPath, HFApplication.GetPlatformPath(platform));
            //
            var artOutputPath = IPath.Combine(_outputPath, AssetBundleManager.ArtPath);
            var buildInfoPath = IPath.Combine(artOutputPath, "BuildInfo.json");
            //初始化
            allfileHashMap = new Dictionary<string, string>();
            var assetPaths = HFApplication.GetABAssetsPath();
            for (int i = 0; i < assetPaths.Count; i++)
            {
                assetPaths[i] = assetPaths[i].ToLower();
            }
            //清除掉所有资源的ab包名
            CleanABName();
            //资源的meta文件统一规格
            UpdateAssetsMetas();
            /***********************新老资源依赖生成************************/
            //获取老的配置
            BuildInfo lastBuildInfo = new BuildInfo();
            if (File.Exists(buildInfoPath))
            {
                var content = File.ReadAllText(buildInfoPath);
                lastBuildInfo = JsonConvert.DeserializeObject<BuildInfo>(content);
            }
            //获取当前配置
            var newbuildInfo = GetAssetsInfo(assetPaths);
            var buildinfoCahce = JsonConvert.SerializeObject(newbuildInfo);
            ////BD生命周期触发
            //BDEditorBehaviorHelper.OnBeginBuildAssetBundle(newbuildInfo);
            //获取改动的数据
            var changedBuildInfo = GetChangedAssets(lastBuildInfo, newbuildInfo);
            // newbuildInfo = null; //防止后面再用
            if (changedBuildInfo.AssetDataMaps.Count == 0)
            {
                Debug.Log("无资源改变,不需要打包!");
                return false;
            }
            #region 整理依赖关系

            //1.把依赖资源替换成AB Name，
            foreach (var asset in newbuildInfo.AssetDataMaps.Values)
            {
                for (int i = 0; i < asset.DependList.Count; i++)
                {
                    var da = asset.DependList[i];
                    var dependAssetData = newbuildInfo.AssetDataMaps[da.DependPath];
                    //替换成真正AB名
                    if (!string.IsNullOrEmpty(dependAssetData.ABName))
                    {
                        asset.DependList[i].DependPath = dependAssetData.ABName;
                        asset.DependList[i].AssetClassName = dependAssetData.AssetClassName;
                    }
                }

                //去重
                var depends = new List<BuildDependInfo>();
                for (var i = 0; i < asset.DependList.Count; i++)
                {
                    var depend = asset.DependList[i];
                    if (depends.FirstOrDefault<BuildDependInfo>((item) => { return item.DependPath == depend.DependPath; }) == null)
                    {
                        if (depend.DependPath != asset.ABName)
                        {
                            depends.Add(depend);
                        }
                    }
                }
                asset.DependList = depends;
            }

            var runtimeStr = HFApplication.ABAssetReplacePath;

            if (isHashName)
            {
                //使用guid 作为ab名

                foreach (var asset in newbuildInfo.AssetDataMaps)
                {
                    var abname = AssetDatabase.AssetPathToGUID(asset.Value.ABName);
                    if (!string.IsNullOrEmpty(abname)) //不存在的资源（如ab.shader之类）,则用原名
                    {
                        asset.Value.ABName = abname;
                    }
                    else
                    {
                        Debug.LogError("获取GUID失败：" + asset.Value.ABName);
                    }

                    for (int i = 0; i < asset.Value.DependList.Count; i++)
                    {
                        var dependAssetName = asset.Value.DependList[i].DependPath;

                        abname = AssetDatabase.AssetPathToGUID(dependAssetName);
                        if (!string.IsNullOrEmpty(abname)) //不存在的资源（如ab.shader之类）,则用原名
                        {
                            asset.Value.DependList[i].DependPath = abname;
                        }
                        else
                        {
                            Debug.LogError("获取GUID失败：" + dependAssetName);
                        }
                    }
                }
            }
            else
            {
                //2.整理AB路径 替换路径名为Resources规则加格式的名字

                foreach (var asset in newbuildInfo.AssetDataMaps)
                {
                    if (asset.Key.Contains(runtimeStr))
                    {
                        var newName = asset.Value.ABName;
                        //移除runtime之前的路径、后缀
                        var index = newName.IndexOf(runtimeStr);
                        newName = newName.Substring(index + runtimeStr.Length); //runtimeStr.Length);

                        var extension = Path.GetExtension(newName);
                        if (!string.IsNullOrEmpty(extension))
                        {
                            newName = newName.Replace(extension, "");
                        }
                        //刷新整个列表替换
                        foreach (var _asset in newbuildInfo.AssetDataMaps)
                        {
                            var oldName = asset.Key.ToLower();
                            //ab替换
                            if (_asset.Value.ABName == oldName)
                            {
                                _asset.Value.ABName = newName;
                            }

                            //依赖替换
                            for (int i = 0; i < _asset.Value.DependList.Count; i++)
                            {
                                if (_asset.Value.DependList[i].DependPath == oldName)
                                {
                                    _asset.Value.DependList[i].DependPath = newName;
                                }
                            }
                        }
                    }
                }
            }
            #endregion


            #region 生成Runtime使用的Config

            //根据buildinfo 生成加载用的 Config
            //1.只保留Runtime目录下的配置
            ManifestConfig config = new ManifestConfig();
            config.IsHashName = isHashName;
            //
            foreach (var item in newbuildInfo.AssetDataMaps)
            {
                //runtime路径下，
                //改成用Resources加载规则命名的key
                if (item.Key.Contains(runtimeStr))
                {
                    var key = item.Key;
                    //移除runtime之前的路径、后缀
                    var index = key.IndexOf(runtimeStr);
                    if (config.IsHashName)
                    {
                        key = key.Substring(index + runtimeStr.Length); //hash要去掉runtime
                    }
                    else
                    {
                        key = key.Substring(index + runtimeStr.Length); // 保留runtime
                    }

                    var exten = Path.GetExtension(key);
                    if (!string.IsNullOrEmpty(exten))
                    {
                        key = key.Replace(exten, "");
                    }

                    //添加manifest
                    var map = config.ManifestMap;
                    List<ManifestItem> list;
                    if (map.ContainsKey(key))
                    {
                        list = map[key].List;
                    }
                    else
                    {
                        list = new List<ManifestItem>();
                        map[key] = new ManifestItems(list);
                    }
                    var dependList = new List<ManifestDependItem>();
                    for (var i = 0; i < item.Value.DependList.Count; i++)
                    {
                        var depend = item.Value.DependList[i];
                        dependList.Add(new ManifestDependItem(depend.AssetClassName, depend.DependPath));
                    }
                    var mi = new ManifestItem(item.Value.ABName, (ManifestItem.AssetTypeEnum)item.Value.Type,
                        dependList.ToArray(), item.Value.AssetName, item.Value.AssetClassName);
                    list.Add(mi);
                }
            }
            //写入
            FileHelper.WriteAllText(artOutputPath + "/Config.json", JsonConvert.SerializeObject(config));
            #endregion


            #region 设置ABname

            /***********************开始设置build ab************************/
            AssetImpoterCacheMap.Clear();
            AssetMetaContentCacheMap.Clear();
            //设置AB name
            foreach (var changedAsset in changedBuildInfo.AssetDataMaps)
            {
                //根据改变的ChangedAssets,获取Asset的资源
                var key = changedAsset.Key;

                var asset = newbuildInfo.AssetDataMaps[changedAsset.Key];
                //设置ABName 有ab的则用ab ，没有就用configpath
                string abname = asset.ABName;
                //
                var ai = GetAssetImporter(key);
                if (ai)
                {
                    //记录下来Meta文件内容 Unity打ab包后会修改Meta 打包后再改回来
                    CacheMetaFile(key + ".meta");
                    ai.SetAssetBundleNameAndVariant(abname, "");
                }
                else
                {
                    Debug.LogError("未查找到资源" + key);
                    throw new Exception();
                }
            }
            #endregion
            //3.生成AssetBundle
            try
            {
                BuildAssetBundle(target, _outputPath, options);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                //4.清除AB Name
                RemoveAllAssetbundleName();
                //还原meta文件
                RevertMetaFiles();
                AssetImpoterCacheMap.Clear();
                AssetMetaContentCacheMap.Clear();
                throw e;
            }

            //4.清除AB Name
            EditorUtility.DisplayProgressBar("资源清理", "清理中...", 1);
            RemoveAllAssetbundleName();
            //还原meta文件
            RevertMetaFiles();
            AssetImpoterCacheMap.Clear();
            AssetMetaContentCacheMap.Clear();
            EditorUtility.ClearProgressBar();
            //the end.删除无用文件
            var delFiles = Directory.GetFiles(artOutputPath, "*", SearchOption.AllDirectories);
            foreach (var df in delFiles)
            {
                var ext = Path.GetExtension(df);
                if (ext == ".meta" || ext == ".manifest")
                {
                    File.Delete(df);
                }
            }
            //the end. BuildInfo写入
            if (File.Exists(buildInfoPath))
            {
                string targetPath = artOutputPath + "/BuildInfo.old.json";
                File.Delete(targetPath);
                File.Move(buildInfoPath, targetPath);
            }
            FileHelper.WriteAllText(buildInfoPath, buildinfoCahce);
            Debug.Log("写入BuildInfo.json成功");

            ////BD生命周期触发
            //BDEditorBehaviorHelper.OnEndBuildAssetBundle(outputPath);
            AssetHelper.AssetHelper.GenPackageBuildInfo(outputPath, platform);

            return true;
        }


        private static Dictionary<string, List<string>> packageAssetsMap = null;

        #region 包颗配置

        //将指定后缀或指定文件,打包到一个AssetBundle
        public class MakePackage
        {
            public List<string> FileExtens = new List<string>();
            public string AssetBundleName = "noname";
        }


        /// <summary>
        /// 包配置相关
        /// </summary>
        private static List<MakePackage> PackageConfigMap { get; set; } = new List<MakePackage>()
        {
            new MakePackage()
            {
               FileExtens = new List<string>() {".shader", ".shadervariants"},
               AssetBundleName =  (ShaderCollection.ALL_SHADER_AB_PATH).ToLower()
            }
                    };

        /// <summary>
        /// 资源类型配置
        /// </summary>
        static Dictionary<ManifestItem.AssetTypeEnum, List<string>> AssetTypeConfigMap =
            new Dictionary<ManifestItem.AssetTypeEnum, List<string>>()
            {
                {ManifestItem.AssetTypeEnum.Prefab, new List<string>() {".prefab"}}, //Prefab
                {ManifestItem.AssetTypeEnum.SpriteAtlas, new List<string>() {".spriteatlas"}}, //Atlas
            };
        //合并ab包的文件后缀类型
        static List<string> CombineExtensionList = new List<string>()
        {
            ".spriteatlas",
            // ".mat",
            // ".prefab",
        };

        #endregion

        /// <summary>
        /// 获取当前所有资源配置
        /// </summary>
        /// <returns></returns>
        static public BuildInfo GetAssetsInfo(List<string> paths)
        {
            packageAssetsMap = new Dictionary<string, List<string>>(); //统一ab资源
            var atlasAssets = new Dictionary<string, List<string>>();
            //1.获取图集信息
            var atlas = paths.FindAll((p) => Path.GetExtension(p) == ".spriteatlas");
            for (int i = 0; i < atlas.Count; i++)
            {
                var asset = atlas[i];
                //获取依赖中的textrue
                var dps = GetDependencies(asset).ToList();
                var textureList = new List<string>();
                foreach (var item in dps)
                {
                    if (item != asset)
                    {
                        textureList.Add(item);
                    }
                }
                atlasAssets[asset] = textureList;
            }
            for (var i = 0; i < paths.Count; i++)
            {
                //获取所有依赖资源
                var path = paths[i];
                var dps = GetDependencies(path).ToList();
                foreach (var dp in dps)
                {
                    //对合并文件进行判断
                    foreach (var combineExtension in CombineExtensionList)
                    {
                        if (Path.GetExtension(dp) == combineExtension)
                        {
                            //获取依赖中的资源
                            var assetdps = GetDependencies(dp).ToList();
                            var ogassetdps = GetDependencies(dp).ToList();
                            //过滤掉已经有的资源
                            var deletekeys = new List<string>();
                            foreach (var asset in assetdps)
                            {
                                if (packageAssetsMap.ContainsKey(asset))
                                {
                                    deletekeys.Add(asset);
                                }
                            }
                            foreach (var key in deletekeys)
                            {
                                var deleteassets = packageAssetsMap[key];
                                foreach (var deleteasset in deleteassets)
                                {
                                    if (assetdps.Contains(deleteasset))
                                    {
                                        assetdps.Remove(deleteasset);
                                    }
                                }
                            }
                            if (assetdps.Count != ogassetdps.Count)
                            {
                                Debug.Log("主资源" + dp);
                                foreach (var value in ogassetdps)
                                {
                                    if (assetdps.Contains(value) == false)
                                    {
                                        Debug.Log("删除资源" + value);
                                    }
                                }
                            }
                            //设置合并键值
                            packageAssetsMap[dp] = assetdps;
                        }
                    }

                }
            }

            // //2.搜集Package config信息
            // foreach (var config in PackageConfigMap)
            // {
            //     var rets = paths.FindAll((p) => config.FileExtens.Contains(Path.GetExtension(p)));
            //     packageAssetsMap[config.AssetBundleName] = rets.ToList();
            // }

            BuildInfo buildInfo = new BuildInfo();
            buildInfo.Time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            int id = 0;
            //搜集所有的依赖
            foreach (var mainpath in paths)
            {
                var dependeAssetsPath = GetDependencies(mainpath);
                //获取依赖 并加入build info
                foreach (var subAssetPath in dependeAssetsPath)
                {
                    var asset = new BuildInfo.AssetData();
                    asset.Id = id;
                    asset.Hash = GetHashFromAssets(subAssetPath);
                    asset.ABName = subAssetPath;
                    asset.AssetName = subAssetPath;
                    //判断资源类型
                    asset.Type = (int)ManifestItem.AssetTypeEnum.Others;
                    if (paths.Contains(subAssetPath))
                    {
                        //如果是ab资源则设置类型名
                        var assetObj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(subAssetPath);
                        if (assetObj != null)
                        {
                            asset.AssetClassName = assetObj.GetType().FullName;
                        }
                    }
                    var subAssetsExtension = Path.GetExtension(subAssetPath);
                    //设置资源类型
                    foreach (var item in AssetTypeConfigMap)
                    {
                        if (item.Value.Contains(subAssetsExtension))
                        {
                            asset.Type = (int)item.Key;
                            break;
                        }
                    }
                    //获取依赖
                    var dependeAssetList = GetDependencies(subAssetPath);
                    for (var i = 0; i < dependeAssetList.Length; i++)
                    {
                        //校验依赖的资源是否是ab资源
                        //如果是则设置类型名
                        var dependItem = new BuildDependInfo();
                        dependItem.DependPath = dependeAssetList[i];
                        if (paths.Contains(dependeAssetList[i]))
                        {
                            //如果是ab资源则设置类型名
                            var dependAssetObj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(dependeAssetList[i]);
                            if (dependAssetObj != null)
                            {
                                dependItem.AssetClassName = dependAssetObj.GetType().FullName;
                            }
                        }
                        asset.DependList.Add(dependItem);
                    }
                    //添加
                    buildInfo.AssetDataMaps[subAssetPath] = asset;
                    //判断package名 统一Ab名
                    foreach (var item in packageAssetsMap)
                    {
                        if (item.Value.Contains(subAssetPath))
                        {
                            //设置AB的名字
                            asset.ABName = item.Key;
                            break;
                        }
                    }

                    //自己规则的ab
                    foreach (var item in PackageConfigMap)
                    {
                        if (item.FileExtens.Contains(subAssetsExtension))
                        {
                            //设置AB的名字
                            asset.ABName = item.AssetBundleName;
                            break;
                        }
                    }
                    //图集类型设置
                    foreach (var item in atlasAssets)
                    {
                        if (item.Value.Contains(subAssetPath))
                        {
                            asset.Type = (int)ManifestItem.AssetTypeEnum.SpriteInSpriteAtlas;
                            asset.AssetClassName = typeof(UnityEngine.Sprite).FullName;
                            break;
                        }
                    }
                    id++;
                }
            }

            //TODO AB依赖关系纠正
            /// 已知Unity,bug/设计缺陷：
            ///   1.依赖接口，中会携带自己
            ///   2.如若a.png、b.png 依赖 c.atlas，则abc依赖都会是:a.png 、b.png 、 a.atlas
            foreach (var asset in buildInfo.AssetDataMaps)
            {
                var depends = asset.Value.DependList;
                asset.Value.DependList = depends.Where((a) => { return a.DependPath != asset.Value.ABName; }).ToList();
            }
            //图集类型资源根据依赖重新生成Hash值
            foreach (var asset in buildInfo.AssetDataMaps)
            {
                if (asset.Value.Type == (int)ManifestItem.AssetTypeEnum.SpriteAtlas)
                {
                    asset.Value.Hash = GetHashFromAssetsAndDependency(asset.Value);
                }
            }

            // //2.Package Config信息添加到BuildInfo
            // foreach (var config in PackageConfigMap)
            // {
            //     var asset = new BuildInfo.AssetData();
            //     asset.ABName = config.AssetBundleName;
            //     asset.Type = (int)ManifestItem.AssetTypeEnum.Custom;
            //     asset.Hash = GetHashFromString(config.AssetBundleName);
            //     // 添加依赖
            //     var rets = buildInfo.AssetDataMaps.Values.Where((a) => a.ABName == config.AssetBundleName);
            //     foreach (var ret in rets)
            //     {
            //         var dependitem = new BuildDependInfo();
            //         dependitem.AssetClassName = ret.AssetClassName;
            //         dependitem.DependPath = ret.AssetName;
            //         asset.DependList.Add(dependitem);
            //     }
            //     //根据整体资源重新计算Hash值
            //     var builder = new StringBuilder();
            //     builder.Append(asset.Hash);
            //     var assetMap = buildInfo.AssetDataMaps;
            //     for (var i = 0; i < asset.DependList.Count; i++)
            //     {
            //         BuildInfo.AssetData data = null;
            //         if (assetMap.TryGetValue(asset.DependList[i].DependPath, out data) == false)
            //         {
            //             throw new Exception(string.Format("依赖资源不存在" + asset.DependList[i].DependPath));
            //         }
            //         builder.Append(data.Hash);
            //     }
            //     var computeStr = builder.ToString();
            //     asset.Hash = GetHashFromString(computeStr);

            //     //压入列表
            //     buildInfo.AssetDataMaps[asset.ABName] = asset;
            // }
            // //整体的ab包资源根据依赖重新生成Hash值
            // foreach (var asset in packageAssetsMap)
            // {
            //     var item = buildInfo.AssetDataMaps.Values.FirstOrDefault((a) => a.ABName == asset.Key);
            //     if (item == null)
            //     {
            //         throw new Exception(string.Format("未找到资源{0}", asset.Key));
            //     }
            //     var builder = new StringBuilder();
            //     builder.Append(item.Hash);
            //     var assetMap = buildInfo.AssetDataMaps;
            //     for (var i = 0; i < item.DependList.Count; i++)
            //     {
            //         BuildInfo.AssetData data = null;
            //         if (assetMap.TryGetValue(item.DependList[i].DependPath, out data) == false)
            //         {
            //             throw new Exception(string.Format("依赖资源不存在" + item.DependList[i].DependPath));
            //         }
            //         builder.Append(data.Hash);
            //     }
            //     var computeStr = builder.ToString();
            //     item.Hash = GetHashFromString(computeStr);
            // }

            var runTimeStr = HFApplication.ABAssetReplacePath;
            //搜集引用的次数，以runtime内部引用为主
            foreach (var item in buildInfo.AssetDataMaps)
            {
                if (!item.Key.Contains(runTimeStr))
                    continue;
                //
                int count = 0;
                foreach (var assetdata in buildInfo.AssetDataMaps.Values)
                {
                    var dependList = assetdata.DependList;
                    for (var i = 0; i < dependList.Count; i++)
                    {
                        var depend = dependList[i];
                        if (depend.DependPath == item.Key)
                        {
                            count++;
                        }
                    }
                }

                item.Value.ReferenceCount = count;
            }

            return buildInfo;
        }

        /// <summary>
        /// 获取改动的Assets
        /// </summary>
        static BuildInfo GetChangedAssets(BuildInfo lastAssetsInfo, BuildInfo newAssetsInfo)
        {
            //根据变动的list 刷出关联
            //1.单ab 单资源，直接重打
            //2.单ab 多资源的 整个ab都要重新打包
            //3.如果不是(路径没有变只有内容变了) 则依赖它的资源包需要重新打
            if (lastAssetsInfo.AssetDataMaps.Count != 0)
            {
                Debug.Log("<color=red>开始增量分析...</color>");
                var changedAssetList = new List<KeyValuePair<string, BuildInfo.AssetData>>();
                //找出差异文件
                foreach (var newAssetItem in newAssetsInfo.AssetDataMaps)
                {
                    BuildInfo.AssetData lastAssetData = null;
                    if (lastAssetsInfo.AssetDataMaps.TryGetValue(newAssetItem.Key, out lastAssetData))
                    {
                        if (lastAssetData.Hash == newAssetItem.Value.Hash)
                        {
                            continue;
                        }
                    }

                    changedAssetList.Add(newAssetItem);
                    Debug.Log("变动文件:" + newAssetItem.Value.AssetName + "AB名:" + newAssetItem.Value.ABName);
                }
                //找出ab路径没变只有内容变的了资源
                var noPathChangeAssetList = new List<string>();
                for (var i = 0; i < changedAssetList.Count; i++)
                {
                    var newAssetItem = changedAssetList[i];
                    BuildInfo.AssetData lastAssetData = null;
                    if (lastAssetsInfo.AssetDataMaps.TryGetValue(newAssetItem.Value.ABName, out lastAssetData))
                    {
                        noPathChangeAssetList.Add(newAssetItem.Key);
                    }
                    else
                    {
                        //自定义路径的ab资源也是路径不改的资源
                        foreach (var value in PackageConfigMap)
                        {
                            if (value.AssetBundleName == newAssetItem.Value.ABName)
                            {
                                noPathChangeAssetList.Add(newAssetItem.Key);
                                break;
                            }
                        }
                    }
                }
                //从变动列表中分离出来需要依赖该资源的重打的资源和只需要自己重打的资源
                var onlyrebuildSelfList = new List<KeyValuePair<string, BuildInfo.AssetData>>();
                var otherList = new List<KeyValuePair<string, BuildInfo.AssetData>>();
                foreach (var assetItem in changedAssetList)
                {
                    if (noPathChangeAssetList.Contains(assetItem.Key))
                    {
                        //只有内容改动路径没有改动
                        onlyrebuildSelfList.Add(assetItem);
                        Debug.Log("路径未改的变动文件:" + assetItem.Value.AssetName + "AB名:" + assetItem.Value.ABName);
                    }
                    else
                    {
                        otherList.Add(assetItem);
                        Debug.Log("路径改动的变动文件:" + assetItem.Value.AssetName + "AB名:" + assetItem.Value.ABName);
                    }
                }
                Debug.LogFormat("<color=red>变动文件数:{0}</color>", changedAssetList.Count);
                Debug.LogFormat("<color=red>只有内容变动文件数:{0}</color>", onlyrebuildSelfList.Count);
                Debug.LogFormat("<color=red>内容和路径都变动文件数:{0}</color>", otherList.Count);
                //rebuild
                List<string> rebuildABNameList = new List<string>();
                //自己和依赖自己的资源都重新打
                foreach (var tempAsset in otherList)
                {
                    //1.添加自身的ab
                    rebuildABNameList.Add(tempAsset.Value.ABName);
                    // //2.添加所有依赖的ab
                    // foreach (var depend in tempAsset.Value.DependList)
                    // {
                    //     BuildInfo.AssetData dependAssetData = null;
                    //     if (newAssetsInfo.AssetDataMaps.TryGetValue(depend.DependPath, out dependAssetData))
                    //     {
                    //         rebuildABNameList.Add(dependAssetData.ABName);
                    //     }
                    //     else
                    //     {
                    //         Debug.LogError("不存在资源:" + depend);
                    //     }
                    // }
                    //3.添加所有依赖该资源的ab 只添加一级依赖
                    foreach (var pair in newAssetsInfo.AssetDataMaps)
                    {
                        var data = pair.Value;
                        var depends = data.DependList;
                        foreach (var depend in depends)
                        {
                            BuildInfo.AssetData dependAssetData = null;
                            if (newAssetsInfo.AssetDataMaps.TryGetValue(depend.DependPath, out dependAssetData) == false)
                            {
                                throw new Exception("不存在资源:" + depend.DependPath);
                            }
                            if (dependAssetData.ABName == tempAsset.Value.ABName)
                            {
                                //添加
                                rebuildABNameList.Add(data.ABName);
                                break;
                            }
                        }
                    }
                }
                //只有自己重新打
                foreach (var tempAsset in onlyrebuildSelfList)
                {
                    //1.添加自身的ab
                    rebuildABNameList.Add(tempAsset.Value.ABName);
                }

                //去重
                rebuildABNameList = rebuildABNameList.Distinct().ToList();
                //搜索依赖的ab，直到没有新ab为止
                int counter = 0;
                while (counter < rebuildABNameList.Count) //防死循环
                {
                    string abName = rebuildABNameList[counter];

                    var findAssets = newAssetsInfo.AssetDataMaps.Where((asset) => asset.Value.ABName == abName);
                    foreach (var asset in findAssets)
                    {
                        //添加本体
                        var assetdata = newAssetsInfo.AssetDataMaps[asset.Key];
                        if (!rebuildABNameList.Contains(assetdata.ABName))
                        {
                            rebuildABNameList.Add(assetdata.ABName);
                        }

                        //添加依赖文件
                        foreach (var depend in assetdata.DependList)
                        {
                            BuildInfo.AssetData dependAssetData = null;
                            if (newAssetsInfo.AssetDataMaps.TryGetValue(depend.DependPath, out dependAssetData))
                            {
                                if (!rebuildABNameList.Contains(dependAssetData.ABName))
                                {
                                    rebuildABNameList.Add(dependAssetData.ABName);
                                }
                            }
                            else
                            {
                                Debug.LogError("不存在资源:" + depend.DependPath);
                            }
                        }
                    }
                    counter++;
                }


                var allRebuildAssets = new List<KeyValuePair<string, BuildInfo.AssetData>>();
                //根据影响的ab，寻找出所有文件
                foreach (var abname in rebuildABNameList)
                {
                    var findAssets = newAssetsInfo.AssetDataMaps.Where((asset) => asset.Value.ABName == abname);
                    allRebuildAssets.AddRange(findAssets);
                }


                //去重
                var retBuildInfo = new BuildInfo();
                foreach (var kv in allRebuildAssets)
                {
                    retBuildInfo.AssetDataMaps[kv.Key] = kv.Value;
                    Debug.Log("影响文件:" + kv.Value.AssetName + "AB名:" + kv.Value.ABName);
                }

                Debug.LogFormat("<color=red>影响文件数:{0}</color>", retBuildInfo.AssetDataMaps.Count);

                return retBuildInfo;
            }


            return newAssetsInfo;
        }


        /// <summary>
        /// 创建assetbundle
        /// </summary>
        private static void BuildAssetBundle(BuildTarget target,
            string outPath,
            BuildAssetBundleOptions options = BuildAssetBundleOptions.ChunkBasedCompression)
        {
            AssetDatabase.RemoveUnusedAssetBundleNames();
            string path = IPath.Combine(outPath, "Art");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // BuildPipeline.BuildAssetBundles(path, options | BuildAssetBundleOptions.DeterministicAssetBundle, target);
            var manifest = BuildPipeline.BuildAssetBundles(path, options | BuildAssetBundleOptions.DisableWriteTypeTree, target);
            if (manifest == null)
            {
                Debug.LogError("打热更包失败");
                throw new Exception("打热更包失败");
            }
        }

        //当前保存的配置
        static ManifestConfig CurManifestConfig = null; //这个配置中 只会用Runtime的索引信息
        private static Dictionary<string, string> allfileHashMap = null;
        static private Dictionary<string, AssetImporter> AssetImpoterCacheMap = new Dictionary<string, AssetImporter>();
        static private Dictionary<string, string> AssetMetaContentCacheMap = new Dictionary<string, string>();
        /// <summary>
        /// 获取assetimpoter
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static private AssetImporter GetAssetImporter(string path)
        {
            AssetImporter ai = null;
            if (!AssetImpoterCacheMap.TryGetValue(path, out ai))
            {
                ai = AssetImporter.GetAtPath(path);
                AssetImpoterCacheMap[path] = ai;
                if (!ai)
                {
                    Debug.LogError("【打包】获取资源失败:" + path);
                }
            }


            return ai;
        }
        //缓存Meta文件
        static private void CacheMetaFile(string path)
        {
            if (AssetMetaContentCacheMap.ContainsKey(path) == false)
            {
                if (File.Exists(path))
                {
                    var content = File.ReadAllText(path);
                    AssetMetaContentCacheMap[path] = content;
                }
            }
            else
            {
                Debug.LogError("路径已存在" + path);
                throw new Exception();
            }
        }
        //还原Meta文件
        static private void RevertMetaFiles()
        {
            foreach (var pair in AssetMetaContentCacheMap)
            {
                File.WriteAllText(pair.Key, pair.Value);
            }
        }


        #region 依赖关系

        static Dictionary<string, List<string>> DependenciesMap = new Dictionary<string, List<string>>();

        /// <summary>
        /// 获取依赖
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static private string[] GetDependencies(string path)
        {
            //全部小写
            //path = path.ToLower();
            List<string> list = null;
            if (!DependenciesMap.TryGetValue(path, out list))
            {
                list = AssetDatabase.GetDependencies(path).Select((s) => s.ToLower()).ToList();
                //检测依赖路径
                CheckAssetsPath(list);
                DependenciesMap[path] = list;
            }


            return list.ToArray();
        }

        /// <summary>
        /// 获取可以打包的资源
        /// </summary>
        /// <param name="allDependObjectPaths"></param>
        static private void CheckAssetsPath(List<string> list)
        {
            if (list.Count == 0)
                return;

            for (int i = list.Count - 1; i >= 0; i--)
            {
                var path = list[i];

                //文件不存在,或者是个文件夹移除
                if (!File.Exists(path) || Directory.Exists(path))
                {
                    list.RemoveAt(i);
                    continue;
                }

                //判断路径是否为editor依赖
                if (path.Contains("/editor/"))
                {
                    list.RemoveAt(i);
                    continue;
                }

                //特殊后缀
                var ext = Path.GetExtension(path).ToLower();
                if (ext == ".cs" || ext == ".js" || ext == ".dll" || ext == ".txt" || ext == ".asset")
                {
                    list.RemoveAt(i);
                    continue;
                }

                //去除package/路径下的资源
                if (path.StartsWith("packages/"))
                {
                    list.RemoveAt(i);
                    continue;
                }
            }
        }
        //检测资源路径是否有效
        static private bool CheckAssetPath(string path)
        {
            var result = true;
            //判断路径是否为editor依赖
            if (path.Contains("/editor/"))
            {
                result = false;
            }

            //特殊后缀
            var ext = Path.GetExtension(path).ToLower();
            if (ext == ".cs" || ext == ".js" || ext == ".dll" || ext == ".txt" || ext == ".asset")
            {
                result = false;
            }

            //去除package/路径下的资源
            if (path.StartsWith("packages/"))
            {
                result = false;
            }
            return result;
        }

        #endregion


        #region 文件 md5
        /// <summary>
        /// 获取文件的md5
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string GetHashFromFiles(List<string> files)
        {
            try
            {
                List<byte> byteList = new List<byte>();
                for (var i = 0; i < files.Count; i++)
                {
                    //这里使用 asset + meta 生成hash,防止其中一个修改导致的文件变动 没更新
                    var dependassetBytes = File.ReadAllBytes(files[i]);
                    var dependmetaBytes = File.ReadAllBytes(files[i] + ".meta");
                    byteList.AddRange(dependassetBytes);
                    byteList.AddRange(dependmetaBytes);
                }
                //获取加密服务  
                System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
                //加密Byte[]数组  
                byte[] retVal = md5CSP.ComputeHash(byteList.ToArray());
                // //这里为了防止碰撞 考虑Sha256 512 但是速度会更慢
                // var sha1 = SHA1.Create();
                // byte[] retVal = sha1.ComputeHash(byteList.ToArray());
                //hash
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                var hash = sb.ToString();
                return hash;
            }
            catch (Exception ex)
            {
                Debug.LogError("hash计算错误:");
                throw ex;
            }
        }

        /// <summary>
        /// 获取文件的md5
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string GetHashFromAssetsAndDependency(BuildInfo.AssetData assetData)
        {
            var fileName = assetData.AssetName;
            try
            {
                //这里使用 asset + meta 生成hash,防止其中一个修改导致的文件变动 没更新
                var assetBytes = File.ReadAllBytes(fileName);
                var metaBytes = File.ReadAllBytes(fileName + ".meta");
                List<byte> byteList = new List<byte>();
                byteList.AddRange(assetBytes);
                byteList.AddRange(metaBytes);
                //把依赖项加入
                for (var i = 0; i < assetData.DependList.Count; i++)
                {
                    var depend = assetData.DependList[i];
                    var dependFileName = depend.DependPath;
                    var dependassetBytes = File.ReadAllBytes(dependFileName);
                    var dependmetaBytes = File.ReadAllBytes(dependFileName + ".meta");
                    byteList.AddRange(dependassetBytes);
                    byteList.AddRange(dependmetaBytes);
                }
                //获取加密服务  
                System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
                //加密Byte[]数组  
                byte[] retVal = md5CSP.ComputeHash(byteList.ToArray());
                // //这里为了防止碰撞 考虑Sha256 512 但是速度会更慢
                // var sha1 = SHA1.Create();
                // byte[] retVal = sha1.ComputeHash(byteList.ToArray());
                //hash
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                var hash = sb.ToString();
                allfileHashMap[fileName] = hash;
                return hash;
            }
            catch (Exception ex)
            {
                Debug.LogError("hash计算错误:" + fileName);
                throw ex;
            }
        }

        /// <summary>
        /// 获取文件的md5
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string GetHashFromAssets(string fileName)
        {
            var str = "";
            if (allfileHashMap.TryGetValue(fileName, out str))
            {
                return str;
            }

            try
            {
                //这里使用 asset + meta 生成hash,防止其中一个修改导致的文件变动 没更新
                var assetBytes = File.ReadAllBytes(fileName);
                var metaBytes = File.ReadAllBytes(fileName + ".meta");
                List<byte> byteList = new List<byte>();
                byteList.AddRange(assetBytes);
                byteList.AddRange(metaBytes);
                //获取加密服务  
                System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
                //计算hash值  
                byte[] retVal = md5CSP.ComputeHash(byteList.ToArray());
                // 将加密后的数组转化为字段(普通加密)  
                // return System.Text.Encoding.Unicode.GetString(resultBytes);

                // //这里为了防止碰撞 考虑Sha256 512 但是速度会更慢
                // var sha1 = SHA1.Create();
                // byte[] retVal = sha1.ComputeHash(byteList.ToArray());
                //hash
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                var hash = sb.ToString();
                allfileHashMap[fileName] = hash;
                return hash;
            }
            catch (Exception ex)
            {
                Debug.LogError("hash计算错误:" + fileName);
                throw ex;
            }
        }

        /// <summary>
        /// 获取字符串的md5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string GetHashFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new Exception("计算Hash值的字符串为空");
            }
            try
            {
                var byteList = System.Text.Encoding.UTF8.GetBytes(str);
                //获取加密服务  
                System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
                //计算hash值  
                byte[] retVal = md5CSP.ComputeHash(byteList.ToArray());
                // 将加密后的数组转化为字段(普通加密)  
                // return System.Text.Encoding.Unicode.GetString(resultBytes);

                // //这里为了防止碰撞 考虑Sha256 512 但是速度会更慢
                // var sha1 = SHA1.Create();
                // byte[] retVal = sha1.ComputeHash(byteList.ToArray());
                //hash
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                var hash = sb.ToString();
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Debug.LogError("hash计算错误:" + str);
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 移除无效资源
        /// </summary>
        public static void RemoveAllAssetbundleName()
        {

            foreach (var ai in AssetImpoterCacheMap)
            {
                if (ai.Value != null)
                {
                    // ai.Value.assetBundleVariant = "";
                    ai.Value.SetAssetBundleNameAndVariant("", "");
                }
            }
        }


        public static void HashName2AssetName(string path)
        {
            string android = "Android";
            string iOS = "iOS";

            android = IPath.Combine(path, android);
            iOS = IPath.Combine(path, iOS);

            string[] paths = new string[] { android, iOS };

            foreach (var p in paths)
            {
                if (!Directory.Exists(p))
                {
                    Debug.Log("不存在:" + p);
                    continue;
                }

                var cachePath = IPath.Combine(p, "Art/Cache.json");
                var cacheDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(cachePath));

                float i = 0;
                foreach (var cache in cacheDic)
                {
                    var source = IPath.Combine(p, "Art/" + cache.Value);
                    var index = cache.Key.IndexOf("/Assets/");
                    string t = "";
                    if (index != -1)
                    {
                        t = cache.Key.Substring(index);
                    }
                    else
                    {
                        t = cache.Key;
                    }

                    var target = IPath.Combine(p, "ArtEditor/" + t);
                    if (File.Exists(source))
                    {
                        FileHelper.WriteAllBytes(target, File.ReadAllBytes(source));
                    }

                    i++;
                    EditorUtility.DisplayProgressBar("进度", i + "/" + cacheDic.Count, i / cacheDic.Count);
                }
            }

            EditorUtility.ClearProgressBar();
            Debug.Log("还原完成!");
        }
    }
}