//确认类型
public enum ConfirmType
{
    BuildApplication,   //构建应用
    BuildHFAsset,    //构建热更资源
    BuildHFData,     //构建热更数据
    BuildWhole,  //整体打包
    BuildLua      //打Lua
}
//确认上下文
public class ConfirmContext
{
    public ConfirmType mConfirmType;    //确认类型
    public BuildVersionInfo mVersionInfo;   //构建参数

    public ConfirmContext(ConfirmType ConfirmType, BuildVersionInfo VersionInfo)
    {
        this.mConfirmType = ConfirmType;
        this.mVersionInfo = VersionInfo;
    }

}