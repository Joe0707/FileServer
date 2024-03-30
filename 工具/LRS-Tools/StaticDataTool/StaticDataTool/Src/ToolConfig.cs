

//工具的配置，配置各种路径
public class ToolConfig
{
    public string InputXmlFolder {get;set;} = "";  //输入的Xml路径

    public string Copy_Bin_C_ToFolder {get;set;} = ""; //拷贝Bin_C到目录
    public string Copy_StaticDataMgr_C_ToFolder {get;set;} = ""; //拷贝Code_C/StaticDataMgr.cs到目录
    public string Copy_DataCode_C_ToFolder {get;set;} = ""; //拷贝Code_C/Data到目录
    public string Copy_Json_C_ToFolder {get;set;} = ""; //拷贝Json_C到目录

    public string Copy_Bin_S_ToFolder {get;set;} = ""; //拷贝Bin_S到目录
    public string Copy_StaticDataMgr_S_ToFolder {get;set;} = ""; //拷贝Code_S/StaticDataMgr.cs到目录
    public string Copy_DataCode_S_ToFolder {get;set;} = ""; //拷贝Code_S/Data到目录
    public string Copy_Json_S_ToFolder {get;set;} = ""; //拷贝Json_S到目录
    public bool LogOn {get;set;} = false; //Log开关
}