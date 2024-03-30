using UnityEngine;

class MessageBox
{
    static GameObject cacheObject = null;
    static GameObject cacheObjTip = null;
    // public static UIMessageBox Show(string message, string title = "", MessageBoxType type = MessageBoxType.Information, string btnOK = "", string btnCancel = "")
    // {
    //    if (cacheObject == null)
    //    {
    //       cacheObject = ResourceMgr.Instance.Load<Object>("UI/UIMessageBox");
    //    }

    //    GameObject go = (GameObject)GameObject.Instantiate(cacheObject);
    //    UIMessageBox msgbox = go.GetComponent<UIMessageBox>();
    //    msgbox.Init(title, message, type, btnOK, btnCancel);
    //    return msgbox;
    // }
    //显示Tip
    public static UITip ShowTip(string message, Vector3 position)
    {
        UITip tip = null;
        if (cacheObjTip == null)
        {
            var cacheObjTipRes = Resources.Load<GameObject>("UI/UITip");
            cacheObjTip = GameObject.Instantiate(cacheObjTipRes);
        }
        tip = cacheObjTip.GetComponent<UITip>();
        tip.Init(message, position);
        return tip;
    }

    public static UIMessageBox ShowOneMessage(string message, float delaySeconds = 1f, MessageBoxType type = MessageBoxType.Information, string btnOk = "", string btnCancel = "")
    {
        UIMessageBox msgbox = null;
        if (cacheObject == null)
        {
            // cacheObject = ResourcesManager.Instance.Load<GameObject>("UI/UIMessageBox");
            cacheObject = Resources.Load<GameObject>("UI/UIMessageBox");
        }
        var instanceObj = (GameObject)GameObject.Instantiate(cacheObject);
        msgbox = instanceObj.GetComponent<UIMessageBox>();
        msgbox.Init(message, type, btnOk, btnCancel);
        msgbox.ShowWithDelay(delaySeconds, type);
        return msgbox;
    }

}

public enum MessageBoxType
{
    /// <summary>
    /// Information Dialog with OK button
    /// </summary>
    Information = 1,

    /// <summary>
    /// Confirm Dialog whit OK and Cancel buttons
    /// </summary>
    Confirm = 2,

    /// <summary>
    /// Error Dialog with OK buttons
    /// </summary>
    Error = 3,
    /// <summary>
    /// Hint Dialog with OK buttons
    /// </summary>
    Hint = 4,
    /// <summary>
    /// Succeed Dialog with OK buttons
    /// </summary>
    Succeed = 5
}