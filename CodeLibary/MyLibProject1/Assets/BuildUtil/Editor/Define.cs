public class BuildResult
{
    public BuildResultType result = BuildResultType.Success;  //构建结果
    public string errorMessage = ""; //错误消息
}

public enum BuildResultType
{
    Success,
    Fail
}