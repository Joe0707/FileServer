using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.UI;
using Newtonsoft.Json;
public class OutLog : MonoBehaviour
{
    List<string> mLines = new List<string>();
    List<string> mWriteTxt = new List<string>();
    private string outpath;
    public Button m_CloseLog;//关闭日志
    public Button m_OpenLog;//打开日志
    public GameObject m_LogPanel; //日志面板
    public TMPro.TextMeshProUGUI m_Text;//日志文本
    private bool mIsUpdatingLog;//正在更新日志
    public int mFrameInterval = 5;//写文件帧间隔
    private int mFrameCount = 0;//帧计数
    private OutLogConfig mConfig = new OutLogConfig();//输出日志
    public string mResourceLoadPath = "Load/OutLogConfig";
    void Awake()
    {
        m_CloseLog.onClick.AddListener(OnCloseLog);
        m_OpenLog.onClick.AddListener(OnOpenLog);
        m_LogPanel.SetActive(false);
        m_OpenLog.gameObject.SetActive(true);
        m_CloseLog.gameObject.SetActive(false);
        var resourceConfig = Resources.Load<TextAsset>(mResourceLoadPath);
        if (resourceConfig != null)
        {
            var json = resourceConfig.text;
            mConfig = JsonConvert.DeserializeObject<OutLogConfig>(json);
        }
        if (mConfig.OutLog == false)
        {
            Debug.unityLogger.logEnabled = false;
        }
    }

    void Start()
    {
        //Application.persistentDataPath Unity中只有这个路径是既可以读也可以写的。
        outpath = Application.persistentDataPath + "/outLog.txt";
        //每次启动客户端删除之前保存的Log
        if (System.IO.File.Exists(outpath))
        {
            File.Delete(outpath);
        }

        if (mConfig.OutLog)
        {
            //在这里做一个Log的监听
            Application.logMessageReceived += HandleLog;
        }
    }

    void OnDisable()
    {
        if (mConfig.OutLog)
        {
            Application.logMessageReceived -= HandleLog;
        }
        m_CloseLog.onClick.RemoveListener(OnCloseLog);
        m_OpenLog.onClick.RemoveListener(OnOpenLog);
    }

    void Update()
    {
        //有系统log暂时不增加该log
        // mFrameCount++;
        // if (mFrameCount >= mFrameInterval)
        // {
        //     //到达帧间隔的时候
        //     //清空帧数
        //     mFrameCount = 0;
        //     //因为写入文件的操作必须在主线程中完成，所以在Update中哦给你写入文件。
        //     //记录写入的位置从写入的位置进行追加
        //     if (mWriteTxt.Count > 0)
        //     {
        //         string[] temp = mWriteTxt.ToArray();
        //         using (StreamWriter writer = new StreamWriter(outpath, true, Encoding.UTF8))
        //         {
        //             foreach (string t in temp)
        //             {
        //                 writer.WriteLine(t);
        //                 mWriteTxt.Remove(t);
        //             }
        //         }
        //     }
        // }

    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        mWriteTxt.Add(logString);
        Log(type, logString);
        if (type == LogType.Error || type == LogType.Exception)
        {
            Log(type, stackTrace);
        }
    }

    //这里我把错误的信息保存起来，用来输出在手机屏幕上
    public void Log(LogType logType, params object[] objs)
    {
        string text = "";
        for (int i = 0; i < objs.Length; ++i)
        {
            if (i == 0)
            {
                text += objs[i].ToString();
            }
            else
            {
                text += ", " + objs[i].ToString();
            }
        }
        if (logType == LogType.Error || logType == LogType.Exception)
        {
            text = "<color=red>" + text + "</color>";
        }
        else if (logType == LogType.Warning)
        {
            text = "<color=yellow>" + text + "</color>";
        }

        if (Application.isPlaying)
        {
            if (mLines.Count > 100)
            {
                mLines.RemoveAt(0);
            }
            mLines.Add(text);
            UpdateLog();
        }
    }

    public void UpdateLog()
    {
        if (mIsUpdatingLog)
        {
            return;
        }
        mIsUpdatingLog = true;
        StartCoroutine(UpdateLogCoroutine());
    }

    IEnumerator UpdateLogCoroutine()
    {
        yield return new WaitForEndOfFrame();
        var stringbuilder = new StringBuilder();
        for (var i = 0; i < mLines.Count; i++)
        {
            stringbuilder.AppendLine(mLines[i]);
        }
        m_Text.text = stringbuilder.ToString();
        mIsUpdatingLog = false;
    }

    //点击关闭日志
    void OnCloseLog()
    {
        m_LogPanel.SetActive(false);
        m_OpenLog.gameObject.SetActive(true);
        m_CloseLog.gameObject.SetActive(false);
    }
    //点击打开日志
    void OnOpenLog()
    {
        m_LogPanel.SetActive(true);
        m_OpenLog.gameObject.SetActive(false);
        m_CloseLog.gameObject.SetActive(true);
    }

    // void OnGUI()
    // {
    //     // if (Application.isEditor == false)
    //     // {
    //     //     GUI.color = Color.red;
    //     //     for (int i = 0, imax = mLines.Count; i < imax; ++i)
    //     //     {
    //     //         GUILayout.Label(mLines[i]);
    //     //     }
    //     // }
    // }
}