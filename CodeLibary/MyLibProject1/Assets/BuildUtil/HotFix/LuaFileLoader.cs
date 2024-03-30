using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class LuaFileLoader : MonoBehaviour
{
    //lua文件更新的进度回调
    public delegate void LoadingProgressDelegate(float progress);
    public enum EState
    {
        Unchecked, //未检查
        CheckingUpates, //检查更新中
        Error, //检查失败
        Ready, //更新完毕
    }
    static LuaFileLoader mInstance = null;
    public static LuaFileLoader Instance { get { return mInstance; } }
    [HideInInspector]
    public bool IsDownloading { get; protected set; } //是否正在更新

    [HideInInspector]
    public EState State { get; protected set; } //状态
    [HideInInspector]
    public bool IsReady { get { return State == EState.Ready; } } //是否更新完毕
    string mDataRootPath = ""; //本地存储目录
    string mLuaFilesPath = ""; //lua文件的目录

    // [Tooltip("服务器Lua根目录地址")]
    private string m_ServerRootUrl = "";
    string mServerJsonUrl = "http://127.0.0.1:3001/lua/luaconfig.json";
    LoadingProgressDelegate mProgressDelegate = null;
    public bool mLoadFromServer = false;
    const string HotfixConfigPath = "Load/HotfixConfig";
    void Awake()
    {
        mDataRootPath = Application.persistentDataPath + "/" + "Lua";
        if (Application.isEditor)
            mDataRootPath = "./LuaDownloads";
        mLuaFilesPath = mDataRootPath + "/" + LuaJsonConfig.LuaFolderName;
        mInstance = this;
        State = EState.Unchecked; //未检查
        if (Directory.Exists(mDataRootPath) == false)
        {
            Directory.CreateDirectory(mDataRootPath);
        }
    }

    public void InitHotfixUrl(string url)
    {
        m_ServerRootUrl = url;
        //拼接服务器的json地址
        if (m_ServerRootUrl.LastIndexOf("/") == m_ServerRootUrl.Length - 1) //如果最后一个字符是/，则去掉
            m_ServerRootUrl = m_ServerRootUrl.Substring(0, m_ServerRootUrl.Length - 1);
        mServerJsonUrl = m_ServerRootUrl + "/" + Version.VersionName + "/" + LuaJsonConfig.JsonFileName;

    }

    //从服务器更新
    public static void UpdateFilesFromServer(LoadingProgressDelegate progressCallback)
    {
        if (mInstance == null)
            return;
        mInstance.mProgressDelegate = progressCallback;
        mInstance.StopAllCoroutines();
        mInstance.StartCoroutine(mInstance._DownloadFilesFromServer());
    }

    //从服务器下载文件
    IEnumerator _DownloadFilesFromServer()
    {
        State = EState.CheckingUpates; //检查中
                                       //将luaconfig.json的uri拆解一下 
        int idx = mServerJsonUrl.LastIndexOf("/");
        string uriLuaRoot = mServerJsonUrl.Substring(0, idx);
        string jsonconfigName = mServerJsonUrl.Substring(idx + 1);
        if (mProgressDelegate != null)
            mProgressDelegate(0);//设置进度
                                 //获取json文件
        string serverJsonTxt = "";
        var readResult = new ReadFileResult();
        yield return StartCoroutine(_ReadServerFile(mServerJsonUrl, readResult));
        serverJsonTxt = readResult.Content;
        if (serverJsonTxt == "")
        {
            State = EState.Error;
            if (mProgressDelegate != null)
                mProgressDelegate(-1);//通知上层
            yield break;
        }
        LuaJsonConfig serverConfig = LuaJsonConfig.FromJson(serverJsonTxt);
        if (serverConfig == null)
        {
            State = EState.Error;
            if (mProgressDelegate != null)
                mProgressDelegate(-1);//通知上层
            yield break;
        }
        if (mProgressDelegate != null)
            mProgressDelegate(0.1f);//设置进度
        //比对本地的lua文件
        int count = 0;
        if (Directory.Exists(mLuaFilesPath) == false)
            Directory.CreateDirectory(mLuaFilesPath);
        foreach (var luaFileCfg in serverConfig.LuaFiles)
        {
            var filePathName = mLuaFilesPath + "/" + luaFileCfg.FileName;
            var fileUrl = uriLuaRoot + "/" + LuaJsonConfig.LuaFolderName + "/" + luaFileCfg.FileName;
            if (File.Exists(filePathName) == false)
            {//本地不存在的文件,直接下载
                var result = new ReadFileResult();
                yield return _ReadServerFile(fileUrl, result);
                if (result.Content == "")
                {
                    //错误处理
                    State = EState.Error;
                    if (mProgressDelegate != null)
                        mProgressDelegate(-1);//通知上层
                    yield break;
                }
                //保存
                WriteFile(filePathName, result.Content);
                if (mProgressDelegate != null)
                    mProgressDelegate(0.1f + 0.8f * (count / (float)serverConfig.LuaFiles.Count));//设置进度
                yield return null;
            }
            else
            {//本地有文件
             //读取
                var luaContent = ReadFile(filePathName);
                //计算本地文件的md5
                var md5 = LuaJsonConfig.CalculateMD5(luaContent);
                if (md5 != luaFileCfg.FileMD5)
                {//文件不一致
                 //从服务器读取
                    var result = new ReadFileResult();
                    yield return _ReadServerFile(fileUrl, result);
                    if (result.Content == "")
                    {
                        State = EState.Error;
                        if (mProgressDelegate != null)
                            mProgressDelegate(-1);//通知上层
                        yield break;
                    }
                    //保存
                    WriteFile(filePathName, result.Content);
                    if (mProgressDelegate != null)
                        mProgressDelegate(0.1f + 0.8f * (count / (float)serverConfig.LuaFiles.Count));//设置进度
                    yield return null;
                }
            }
            count++; //计数
        }

        //删除本地存在但是列表里没有的文件
        var localFiles = Directory.GetFiles(mLuaFilesPath);
        Debug.Log("localFiles:" + localFiles);
        foreach (var fn in localFiles)
        {
            var fileName = fn.Replace("\\", "/");
            fileName = fileName.Substring(fileName.LastIndexOf("/") + 1); //只保留最后的文件名
                                                                          // var fileName = fn.Substring(fn.LastIndexOf("/") + 1);
                                                                          // fileName = fn.Substring(fn.LastIndexOf("\\") + 1);
            if (serverConfig.GetLuaFileCfg(fileName) == null)
            {//本地有，但是服务器上没有的文件,删除本地的文件
                File.Delete(fileName);
            }
        }
        //更新本地的json文件
        var localJsonFileName = mDataRootPath + "/" + jsonconfigName;
        WriteFile(localJsonFileName, serverJsonTxt);

        if (mProgressDelegate != null)
            mProgressDelegate(1);//设置进度
        State = EState.Ready;
    }

    //从网络读取文件内容 
    class ReadFileResult { public string Content { get; set; } = ""; }
    IEnumerator _ReadServerFile(string url, ReadFileResult result)
    {
        result.Content = "";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
            result.Content = request.downloadHandler.text;
    }

    //获得Lua文件内容，从游戏中调用的 (abc.lua.txt)
    public static string LoadLuaFile(string luaFileName)
    {
        if (mInstance == null)
            return "";
        var filePathName = mInstance.mLuaFilesPath + "/" + luaFileName;
        if (File.Exists(filePathName))
        {
            return mInstance.ReadFile(filePathName);
        }
        else
        {
            return "";
        }
    }

    //从文件读取内容 
    string ReadFile(string filePathName)
    {
        string retValue = "";
        if (File.Exists(filePathName) != false)
        {
            var fs = new FileStream(filePathName, FileMode.Open);
            var sr = new StreamReader(fs);
            retValue = sr.ReadToEnd();
            sr.Close();
        }
        return retValue;
    }

    //把内容写入文件
    void WriteFile(string filePathName, string content)
    {
        var fs = new FileStream(filePathName, FileMode.Create);
        var sw = new StreamWriter(fs);
        sw.Write(content);
        sw.Close();
    }


}

//Lua版本的Json配置文件结构
public class LuaJsonConfig
{
    public class LuaFile
    {
        public string FileName { get; set; } //文件名
        public string FileMD5 { get; set; } //文件的MD5
    }
    public List<LuaFile> LuaFiles { get; set; } = new List<LuaFile>(); //文件列表

    public const string JsonFileName = "luaconfig.json";
    public const string LuaFolderName = "LuaFiles";

    //添加一个文件
    public void AddFile(string filePathName)
    {
        if (File.Exists(filePathName) == false)
            return;
        var name = Path.GetFileName(filePathName);
        //计算文件的MD5
        var fs = new FileStream(filePathName, FileMode.Open);
        var sr = new StreamReader(fs);
        var fileContent = sr.ReadToEnd();
        sr.Close();
        var md5 = CalculateMD5(fileContent);
        if (GetLuaFileCfg(name) != null)
        {
            Debug.LogError("Already have a file with the same name:" + name);
            return;
        }
        var fileItem = new LuaFile
        {
            FileName = name,
            FileMD5 = md5
        };
        LuaFiles.Add(fileItem);
    }

    //从Json解析
    public static LuaJsonConfig FromJson(string jsonText)
    {
        try
        {
            var obj = JsonConvert.DeserializeObject<LuaJsonConfig>(jsonText);
            if (obj == null)
                Debug.LogError("Deserialize json data failed:" + jsonText);
            return obj;
        }
        catch (Exception e)
        {
            Debug.LogError("Deserialize json data failed:" + jsonText);
            return null;
        }
    }

    //转Json
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    //查询是否有某个文件
    public LuaFile GetLuaFileCfg(string luaFileName)
    {
        foreach (var f in LuaFiles)
        {
            if (f.FileName == luaFileName)
                return f;
        }
        return null;
    }
    //明文计算MD5
    public static string CalculateMD5(string plainTxt)
    {
        //获取加密服务  
        System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
        //获取要加密的字段，并转化为Byte[]数组  
        byte[] plainBytes = System.Text.Encoding.Unicode.GetBytes(plainTxt);
        //加密Byte[]数组  
        byte[] resultBytes = md5CSP.ComputeHash(plainBytes);
        //将加密后的数组转化为字段(普通加密)  
        return System.Text.Encoding.Unicode.GetString(resultBytes);
    }
}