using System.Collections.Generic;
using UnityEngine;

public class SkyBoxMgr : Singleton<SkyBoxMgr>
{
    public List<SkyboxData> SkyBoxDatas = new List<SkyboxData>();
    public string SkyBoxPath = "/LRS-BN-SceneRes/Table/SkyBox.xls";
    public override void Init()
    {
        //加载
        var skyboxpath = Application.dataPath + SkyBoxPath;
        try
        {
            SkyBoxDatas = ExcelUtil.LoadWorkbook<SkyboxData>(skyboxpath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("天空盒数据未找到");
            throw ex;
        }
    }
    //根据场景名获取天空盒数据
    public SkyboxData GetDataBySceneName(string scene)
    {
        SkyboxData result = null;
        foreach (var data in SkyBoxDatas)
        {
            if (data.SceneName == scene)
            {
                result = data;
            }
        }
        return result;
    }

}