using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIMessageBox : MonoBehaviour
{

    public Text title;
    public Text message;

    public UnityAction OnMessageDestroy;
    // public Image[] icons;
    public Button buttonYes;
    public Button buttonNo;
    // public Button buttonClose;

    public Text buttonYesTitle;
    public Text buttonNoTitle;

    public UnityAction OnYes;
    public UnityAction OnNo;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void OnDestroy()
    {
        if (OnMessageDestroy != null)
        {
            OnMessageDestroy();
        }
    }
    public void Init(string message, MessageBoxType type = MessageBoxType.Information, string btnOk = "", string btnCancel = "")
    {
        var title = GetTitleByMessageType(type);
        this.title.text = title;
        this.message.color = GetMessageColorByMessageType(type);
        this.message.text = message;
        if (type == MessageBoxType.Confirm)
        {
            if (!string.IsNullOrEmpty(btnOk))
            {
                this.buttonYesTitle.text = btnOk;
                this.buttonYes.gameObject.SetActive(true);
                this.buttonYes.onClick.AddListener(OnClickYes);
            }
            if (!string.IsNullOrEmpty(btnCancel))
            {
                this.buttonNoTitle.text = btnCancel;
                this.buttonNo.gameObject.SetActive(true);
                this.buttonNo.onClick.AddListener(OnClickNo);
            }
        }
    }

    public void ShowWithDelay(float delaySeconds, MessageBoxType type = MessageBoxType.Information)
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
        if (type != MessageBoxType.Confirm && delaySeconds > 0)
        {
            StartCoroutine(HideDelay(delaySeconds));
        }
    }

    IEnumerator HideDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        GameObject.Destroy(gameObject);
    }

    //根据消息类型获取标题
    private string GetTitleByMessageType(MessageBoxType type)
    {
        var title = "";
        switch (type)
        {
            case MessageBoxType.Confirm:
            case MessageBoxType.Information:
                title = "消息";
                break;
            case MessageBoxType.Error:
                title = "错误";
                break;
            case MessageBoxType.Hint:
                title = "提示";
                break;
            case MessageBoxType.Succeed:
                title = "成功";
                break;
        }
        return title;
    }
    //根据消息类型获取提示信息颜色
    private Color GetMessageColorByMessageType(MessageBoxType type)
    {
        // var title = "";
        Color color = Color.black;
        switch (type)
        {
            case MessageBoxType.Confirm:
                color = Color.black;
                break;
            case MessageBoxType.Information:
                color = Color.black;
                break;
            case MessageBoxType.Error:
                color = Color.red;
                break;
            case MessageBoxType.Hint:
                color = Color.yellow;
                break;
            case MessageBoxType.Succeed:
                color = Color.blue;
                break;
        }
        return color;
    }

    // public void Init(string message, MessageBoxType type = MessageBoxType.Information/*, string btnOK = "", string btnCancel = ""*/)
    // {
    //    if (!string.IsNullOrEmpty(title)) this.title.text = title;
    //    this.message.text = message;
    //    // this.icons[0].enabled = type == MessageBoxType.Information;
    //    // this.icons[1].enabled = type == MessageBoxType.Confirm;
    //    // this.icons[2].enabled = type == MessageBoxType.Error;

    //    // if (!string.IsNullOrEmpty(btnOK)) this.buttonYesTitle.text = btnOK;
    //    // if (!string.IsNullOrEmpty(btnCancel)) this.buttonNoTitle.text = btnCancel;

    //    // this.buttonYes.onClick.AddListener(OnClickYes);
    //    // this.buttonNo.onClick.AddListener(OnClickNo);

    //    // this.buttonNo.gameObject.SetActive(type == MessageBoxType.Confirm);

    //    // if (type == MessageBoxType.Error)
    //    //    SoundManager.Instance.PlaySound(SoundDefine.SFX_Message_Error);
    //    // else
    //    //    SoundManager.Instance.PlaySound(SoundDefine.SFX_Message_Info);
    // }

    void OnClickYes()
    {
        // SoundManager.Instance.PlaySound(SoundDefine.SFX_UI_Confirm);
        Destroy(this.gameObject);
        if (this.OnYes != null)
            this.OnYes();
    }

    void OnClickNo()
    {
        // SoundManager.Instance.PlaySound(SoundDefine.SFX_UI_Win_Close);
        Destroy(this.gameObject);
        if (this.OnNo != null)
            this.OnNo();
    }
}
