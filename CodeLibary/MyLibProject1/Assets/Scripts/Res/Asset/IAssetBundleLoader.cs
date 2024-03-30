using System.Collections.Generic;
//资源加载接口
public interface IAssetBundleLoader
{
    /// <summary>
    /// 根据路径的crc加载中间类ResoucItem
    /// </summary>
    /// <param name="crc"></param>
    /// <returns></returns>
    ResouceItem LoadResouceAssetBundle(string path, string typeName, bool isClear = true);
    /// <summary>
    /// 根据路径查找ResourceItems集合
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    List<string> FindResourceABPaths(string path);
    /// <summary>
    /// 释放资源
    /// </summary>
    /// <param name="item"></param>
    void ReleaseAsset(ResouceItem item, bool force = false);
    /// <summary>
    /// 加载ab配置表
    /// </summary>
    /// <returns></returns>
    bool LoadAssetBundleConfig();
    string ABLoadPath { get; }
}