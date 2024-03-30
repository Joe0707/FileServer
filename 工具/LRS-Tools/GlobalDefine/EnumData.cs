using System.Collections.Generic;

//结构数据
public class StructData
{
    public class StructItem
    {
        public string Name = ""; //枚举条目
        public string Value = ""; //值
        public string Comment = ""; //注释
    }
    public string Name = ""; //名称
    public string Comment = ""; //注释
    public List<StructItem> ItemList = new List<StructItem>();
    public bool IsEnum = true;
}
