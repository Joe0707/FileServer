using System.Collections.Generic;

public class ClassData
{
    public class ClassItem
    {
        public string Name = ""; //变量名条目
        public string Type = ""; //类型名
        public string Value = ""; //变量值
        public string Comment = ""; //注释
    }
    public string Name = ""; //类名称
    public string Comment = ""; //类注释
    public List<ClassItem> ItemList = new List<ClassItem>(); 
    public bool IsMsg = false; //是否是消息体，是否是MsgBase的子类
}