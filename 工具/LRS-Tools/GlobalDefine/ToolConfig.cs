using System;
using System.Collections.Generic;

//配置文件
public class ToolConfig
{
    public List<string> InputJSFile = new List<string>(); //输入的JS文件
    public List<string> OutputCSFile = new List<string>(); //输出的CS文件
    public List<string> CopyCSFileTo = new List<string>(); //拷贝输出的CS文件到哪里
    public string CopyJsFileTo = ""; //拷贝JS文件到目录
}