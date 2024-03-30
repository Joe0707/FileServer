using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
public enum GUIEnum
{
    Label,
    Enum,
    Toggle,
    TextField
}
public class GUIObject
{
    public GUIObject(GUIEnum guiEnum, string fieldName, object value, int index)
    {
        mGuiType = guiEnum;
        mFieldName = fieldName;
        mValue = value;
        mIndex = index;
    }
    public GUIEnum mGuiType;
    public string mFieldName;
    public object mValue;
    public int mIndex;
}

public class GUIContext
{
    public List<GUIObject> mGuiObjects;
}

public class ResultContextObject
{
    public string mFieldName;
    public object mValue;
}

public class ResultContext
{
    List<ResultContextObject> mObjects;
}

public class BaseComfirmWindow : EditorWindow
{
    private GUIContext mContext;
    private Dictionary<int, object> mResult = new Dictionary<int, object>();
    public System.Action<Dictionary<int, object>> mConfirm;//确认按钮

    public void Init(GUIContext context)
    {
        this.mContext = context;
        for (var i = 0; i < context.mGuiObjects.Count; i++)
        {
            var obj = context.mGuiObjects[i];
            if (mResult.ContainsKey(obj.mIndex))
            {
                Debug.LogError("索引值相同" + obj.mIndex);
                this.Close();
            }
            mResult[obj.mIndex] = obj.mValue;
        }
    }
    void OnGUI()
    {
        GUILayout.BeginVertical();
        //平台选择
        UpdateGUI();
        GUILayout.EndVertical();
    }

    void UpdateGUI()
    {
        //根据GUI对象初始化
        var list = mContext.mGuiObjects;
        for (var i = 0; i < list.Count; i++)
        {
            var obj = list[i];
            CreateGUI(obj);
            GUILayout.Space(20);
        }
        //创建确认
        if (GUILayout.Button("确认", GUILayout.Width(50), GUILayout.Height(50)))
        {
            if (mConfirm != null)
            {
                mConfirm(mResult);
            }
            this.Close();
        }
    }

    void CreateGUI(GUIObject guiObj)
    {
        var richTextStyle = new GUIStyle();
        richTextStyle.richText = true;
        switch (guiObj.mGuiType)
        {
            case GUIEnum.Enum:
                break;
            case GUIEnum.Label:
                GUILayout.Label(guiObj.mValue.ToString(), richTextStyle);
                break;
            case GUIEnum.TextField:
                GUILayout.BeginHorizontal();
                GUILayout.Label(guiObj.mFieldName, richTextStyle);
                mResult[guiObj.mIndex] = GUILayout.TextField(mResult[guiObj.mIndex].ToString());
                GUILayout.EndHorizontal();
                break;
            case GUIEnum.Toggle:
                mResult[guiObj.mIndex] = GUILayout.Toggle((bool)mResult[guiObj.mIndex], guiObj.mFieldName);
                break;
        }
    }

}
