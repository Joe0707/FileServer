using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//导出公共枚举
public class GlobalDefineMaker
{
    public static ToolConfig mConfig = null;
    static List<StructData> mStructDataList = new List<StructData>(); //枚举列表
    //读配置文件 
    public static void ReadConfig()
    {
        var cfgFileName = "./ToolConfig.json";
        if(File.Exists(cfgFileName) == false)
        {//配置文件不存在
            mConfig = new ToolConfig();
            mConfig.InputJSFile.Add("./input.js");
            mConfig.OutputCSFile.Add("./GlobalDefine.cs");
            //保存配置文件
            string json = JsonConvert.SerializeObject(mConfig);
            var fs = new FileStream(cfgFileName, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Write(json);
            sw.Close();
            Console.WriteLine("配置文件已生成，请修改:" + cfgFileName);
        }
        else
        {//找到配置文件
            var fs = new FileStream(cfgFileName, FileMode.Open);
            var sr = new StreamReader(fs);
            string json = sr.ReadToEnd();
            sr.Close();
            mConfig = JsonConvert.DeserializeObject<ToolConfig>(json);
        }
    }

    //读js文件
    public static void ReadJS(int fileIndex)
    {
        mStructDataList = new List<StructData>();
        if(mConfig == null)
            return;
        if(string.IsNullOrEmpty(mConfig.InputJSFile[fileIndex]))
            return;
        if(File.Exists(mConfig.InputJSFile[fileIndex]) == false)
        {
            Console.WriteLine("错误：没有找到输入文件 " + mConfig.InputJSFile[fileIndex]);
            return;
        }
        //读文件
        var fs = new FileStream(mConfig.InputJSFile[fileIndex], FileMode.Open);
        var sr = new StreamReader(fs);
        string js = sr.ReadToEnd();
        sr.Close();
        //解析文件 
        var pattern =@"^\s*[a-zA-Z0-9_]+\s*:\s*(\r\n)*\s*\{";
        foreach (Match match in Regex.Matches(js, pattern, RegexOptions.Multiline))
        {
            //看这个定义之前是否有注释
            int idx1 = js.LastIndexOf("}", match.Index);
            int idx2 = js.LastIndexOf("*/", match.Index);
            int idx3 = js.LastIndexOf("//", match.Index);
            var enumComment = ""; //类型的注释
            if(idx2 > idx1)
            {// /* */ 类型的注释
                int idx4 = js.LastIndexOf("/*", idx2);
                enumComment = js.Substring(idx4, idx2 - idx4 + 2);
            }
            else if(idx3 > idx1)
            {// // 类型的注释
                int idx4 = js.IndexOf('\n', idx3);
                enumComment = js.Substring(idx3, idx4 - idx3);
            }
            enumComment = enumComment.Replace('\r', '|');
            enumComment = enumComment.Replace("|", "");
            int idx5 = js.IndexOf("}", match.Index);
            //枚举的主体
            var strEnum = js.Substring(match.Index, idx5 - match.Index + 1);
            var structData = ParseEnum(strEnum);
            if(structData != null)
            {
                structData.Comment = enumComment;
                mStructDataList.Add(structData);
            }
        }
    }

    static StructData ParseEnum(string strEnum)
    {
        var retValue = new StructData();
        //解析名字
        retValue.Name = strEnum.Substring(0, strEnum.IndexOf(":"));
        retValue.Name = retValue.Name.Replace(" ", ""); //去除空格
        //解析内容
        int contentStartIdx = strEnum.IndexOf("{");
        int contentEndIdx = strEnum.IndexOf("}");
        string content = strEnum.Substring(contentStartIdx + 1, contentEndIdx - contentStartIdx - 2);
        var pattern = @"^\s*[a-zA-Z0-9_]+\s*:\s*(-?\d+(\.\d+)?|"".+"")";
        foreach (Match match in Regex.Matches(content, pattern, RegexOptions.Multiline))
        {
            var line = match.Value;
            line = line.Replace(" ", "");//消除空格
            line = line.Replace('\r', '|');
            line = line.Replace('\n', '|');
            line = line.Replace("|", "");
            //用冒号拆分
            var arr = line.Split(":");
            var name = arr[0]; //名
            var value = arr[1]; //值
            long outValue = 0;
            if(Int64.TryParse(value, out outValue) == false)
            {//不可以解析成枚举
                retValue.IsEnum = false; //有非数字成员
            }
            var comment = "";   //注释
            //向前寻找注释
            int idx1 = content.LastIndexOf(",", match.Index);
            int idx2 = content.LastIndexOf("*/", match.Index);
            int idx3 = content.LastIndexOf("//", match.Index);
            if (idx2 > idx1)
            {// /* */ 类型的注释
                int idx4 = content.LastIndexOf("/*", idx2);
                comment = content.Substring(idx4, idx2 - idx4 + 2);
            }
            else if (idx3 > idx1)
            {// // 类型的注释
                int idx4 = content.IndexOf('\n', idx3);
                comment = content.Substring(idx3, idx4 - idx3);
            }
            if (comment == "")
            {//尝试本行后面的 //注释
                idx3 = Math.Max(content.IndexOf("//", match.Index), 0);
                int idx4 = content.IndexOf('\n', idx3);
                if (idx3 > 0 && idx3 < idx4)
                {//本行后面有注释
                    comment = content.Substring(idx3, idx4 - idx3);
                }
            }
            comment = comment.Replace('\r', '|');
            comment = comment.Replace("|", "");
            //记录
            retValue.ItemList.Add(new StructData.StructItem
            {
                Name = arr[0],
                Value = arr[1],
                Comment = comment
            });
        }
        if(retValue.ItemList.Count > 0)
            return retValue;
        else 
            return null;
    }
    //写CS
    public static void WriteCS(int fileIndex)
    {
        string str = "namespace GlobalDefine{\r\n";
        foreach (var structData in mStructDataList)
        {
            //写注释
            if (structData.Comment != "")
                str += "\t" + structData.Comment + "\r\n";
            if(structData.IsEnum)
            {//写枚举名
                str += "\tpublic enum " + structData.Name + "{\r\n";
            }
            else
            { //写类名
                str += "\tpublic class " + structData.Name + "{\r\n";
            }
            //写成员
            foreach (var item in structData.ItemList)
            {
                if (item.Comment != "")
                    str += "\t\t" + item.Comment + "\r\n";
                if(structData.IsEnum) //枚举成员
                    str += "\t\t" + item.Name + " = " + item.Value + ", \r\n";
                else //类成员
                {
                    var typename = "string";
                    long numValue = 0;
                    double doubleValue = 0;
                    if(Int64.TryParse(item.Value, out numValue))
                        typename = "long";
                    else if(Double.TryParse(item.Value, out doubleValue))
                        typename = "double";
                    str += "\t\tpublic const " + typename + " " + item.Name + " = " + item.Value + ";\r\n";
                }
            }
            str += "\t}\r\n\r\n";
        }
        str += "}\r\n";
        var fs = new FileStream(mConfig.OutputCSFile[fileIndex], FileMode.Create);
        var sw = new StreamWriter(fs);
        sw.Write(str);
        sw.Close();
    }

    //复制到目标路径
    public static void CopyToDestDirectory(int fileIndex)
    {
        //拷贝CS文件
        foreach (var destFolder in mConfig.CopyCSFileTo)
        {
            if (string.IsNullOrEmpty(destFolder))
                return;
            //检查目标目录是否存在
            if (Directory.Exists(destFolder) == false)
                Directory.CreateDirectory(destFolder);

            var destFile = Path.Combine(destFolder, Path.GetFileName(mConfig.OutputCSFile[fileIndex]));
            if (File.Exists(destFile))
                File.Delete(destFile);
            var sourceFile = mConfig.OutputCSFile[fileIndex];
            File.Copy(sourceFile, destFile);
            Console.WriteLine("Copy:" + sourceFile);
        }
        //拷贝JS文件到服务器
        {
            var destFolder = mConfig.CopyJsFileTo;
            if (string.IsNullOrEmpty(destFolder))
                return;
            //检查目标目录是否存在
            if (Directory.Exists(destFolder) == false)
                Directory.CreateDirectory(destFolder);
            var destFile = Path.Combine(destFolder, Path.GetFileName(mConfig.InputJSFile[fileIndex]));
            if (File.Exists(destFile))
                File.Delete(destFile);
            var sourceFile = mConfig.InputJSFile[fileIndex];
            File.Copy(sourceFile, destFile);
            Console.WriteLine("Copy:" + sourceFile);
        }
    }
}