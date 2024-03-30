using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//生成消息协议
public class MsgMaker
{
    static ToolConfig mConfig = null;
    static Dictionary<string, List<ClassData>> mClassDataDic = new Dictionary<string, List<ClassData>>(); //结构列表

    //读配置文件 
    public static void ReadConfig()
    {
        var cfgFileName = "./ToolConfig.json";
        if(File.Exists(cfgFileName) == false)
        {//配置文件不存在
            mConfig = new ToolConfig();
            mConfig.InputFolder = "./Input";
            mConfig.OutputJSFolder = "./Output";
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
        //清理输出目录
        if (Directory.Exists(mConfig.OutputJSFolder))
            Directory.Delete(mConfig.OutputJSFolder, true);
    }
    
    //读CS文件
    public static void ReadCS()
    {
        if(mConfig == null)
            return;
        if(string.IsNullOrEmpty(mConfig.InputFolder))
            return;
        if(Directory.Exists(mConfig.InputFolder) == false)
        {
            Console.WriteLine("错误：没有找到输入文件路径 " + mConfig.InputFolder);
            return;
        }
        //遍历路径中的文件
        var fileList = Directory.GetFiles(mConfig.InputFolder);
        foreach (var file in fileList)
        {
            if(Path.GetExtension(file) != ".cs")
                continue;
            var groupName = Path.GetFileNameWithoutExtension(file);
            //读文件
            var fs = new FileStream(file, FileMode.Open);
            var sr = new StreamReader(fs);
            string cs = sr.ReadToEnd();
            sr.Close();
            //解析文件 
            var pattern = @"^\s*public\s+class\s+[a-zA-Z0-9_]+\s*(:\s*MsgBase\s*)?(\r\n)*\s*\{";
            foreach (Match match in Regex.Matches(cs, pattern, RegexOptions.Multiline))
            {
                //看这个定义之前是否有注释
                int idx1 = cs.LastIndexOf("}", match.Index);
                int idx2 = cs.LastIndexOf("*/", match.Index);
                int idx3 = cs.LastIndexOf("//", match.Index);
                var comment = ""; //类型的注释
                if (idx2 > idx1)
                {// /* */ 类型的注释
                    int idx4 = cs.LastIndexOf("/*", idx2);
                    comment = cs.Substring(idx4, idx2 - idx4 + 2);
                }
                else if (idx3 > idx1)
                {// // 类型的注释
                    int idx4 = cs.IndexOf('\n', idx3);
                    comment = cs.Substring(idx3, idx4 - idx3);
                }
                comment = comment.Replace('\r', '|');
                comment = comment.Replace("|", "");
                int idx5 = cs.IndexOf("}", match.Index);
                //类的主体
                var strClass = cs.Substring(match.Index, idx5 - match.Index + 1);
                var classData = ParseClass(strClass);
                if (classData != null)
                {
                    classData.Comment = comment;
                    if(mClassDataDic.ContainsKey(groupName) == false)
                        mClassDataDic.Add(groupName, new List<ClassData>());
                    mClassDataDic[groupName].Add(classData);
                }
            }
        }

    }
    static ClassData ParseClass(string strClass)
    {
        var retValue = new ClassData();
        //解析类名字
        {
            int idx1 = strClass.IndexOf("class");
            int idx2 = strClass.IndexOf(":");
            if(idx2 < 0)
                idx2 = strClass.IndexOf("{");
            retValue.Name = strClass.Substring(idx1 + 6, idx2 - idx1 - 6);
            retValue.Name = retValue.Name.Replace('\r', ' '); //去除特殊字符
            retValue.Name = retValue.Name.Replace('\n', ' '); //去除特殊字符
            retValue.Name = retValue.Name.Replace('\t', ' '); //去除特殊字符
            retValue.Name = retValue.Name.Replace(" ", ""); //去除空格
            //判断是否是派生自MsgBase
            int idx3 = strClass.IndexOf("MsgBase");
            if(idx3 > 0 && idx3 < strClass.IndexOf('\n', idx1))
                retValue.IsMsg = true;
        }
        //解析内容
        int contentStartIdx = strClass.IndexOf("{");
        int contentEndIdx = strClass.IndexOf("}");
        var content = strClass.Substring(contentStartIdx + 1, contentEndIdx - contentStartIdx - 2);
        var pattern = @"^\s*public\s+([a-zA-Z0-9_\.]+((<[a-zA-Z0-9_\.\s,]+>)|(\s*\[\s*\]))?)\s+([a-zA-Z0-9_]+)\s*(=\s*(\d+(\.\d+)?|"".*""|[a-zA-Z0-9_\.\s\(\)\[\]<>,]+)\s*)?;";
        int lastReadCommentEndIdx = 0; //已经读过的注释的结尾
        MatchCollection m = Regex.Matches(content, pattern, RegexOptions.Multiline);
        foreach (Match match in Regex.Matches(content, pattern, RegexOptions.Multiline))
        {
            var line = match.Value;
            //用冒号拆分
            var type = match.Groups[1].Value;
            var name = match.Groups[5].Value; //名
            var value = match.Groups[7].Value; //值
            var comment = "";   //注释
            //向前寻找注释
            int idx1 = content.LastIndexOf(";", match.Index);
            int idx2 = content.LastIndexOf("*/", match.Index);
            int idx3 = content.LastIndexOf("//", match.Index);
            if (idx2 > idx1)
            {// /* */ 类型的注释
                int idx4 = content.LastIndexOf("/*", idx2);
                if (idx4 > lastReadCommentEndIdx)
                {
                    comment = content.Substring(idx4, idx2 - idx4 + 2);
                    lastReadCommentEndIdx = idx2;
                }
            }
            else if (idx3 > idx1)
            {// // 类型的注释
                if(idx3 > lastReadCommentEndIdx)
                {
                    int idx4 = content.IndexOf('\n', idx3);
                    comment = content.Substring(idx3, idx4 - idx3);
                    lastReadCommentEndIdx = idx4;
                }
            }
            if (comment == "")
            {//尝试本行后面的 //注释
                idx3 = content.IndexOf("//", match.Index);
                if (idx3 > 0)
                {
                    int idx4 = content.IndexOf('\n', idx3);
                    if (idx3 > 0 && idx3 < idx4 && idx3 > lastReadCommentEndIdx)
                    {//本行后面有注释
                        comment = content.Substring(idx3, idx4 - idx3);
                        lastReadCommentEndIdx = idx4;
                    }
                }
            }
            comment = comment.Replace('\r', '|');
            comment = comment.Replace("|", "");
            //记录
            retValue.ItemList.Add(new ClassData.ClassItem
            {
                Name = name,
                Type = type,
                Value = value,
                Comment = comment
            });
        }
        if (retValue.ItemList.Count > 0)
            return retValue;
        else
            return null;
    }

    //写TS
    public static void WriteTS()
    {
        Directory.CreateDirectory(mConfig.OutputJSFolder);
        //遍历文件
        foreach (var pair in mClassDataDic)
        {
            //拼接文件名
            var filename = Path.Combine(mConfig.OutputJSFolder, pair.Key + ".ts");
            string str = "";
            // if(pair.Value.Count > 0 && pair.Value[0].IsMsg)
            //     str += "var " + pair.Key + "= module.exports;\r\n";
            //遍历文件
            foreach (var classData in pair.Value)
            {
                string className = classData.Name + "ToClient";
                //类注释
                if (classData.Comment != "")
                    str += classData.Comment + "\r\n";
                //类名
                // if(classData.IsMsg)
                //     className = pair.Key + "_" + className;
                str += "export class " +  className + " {\r\n";
                //成员
                string typeStrContext = "";
                string constructorContext = "";
                string paramContext = "";
                string constructorStr =  "constructor(data?: " + className + "Format) {\r\n\tif(data){\r\n" + constructorContext + "\t}\n}\n";
                foreach (var item in classData.ItemList)
                {
                    if (item.Type.Contains("List<") || item.Type.Contains("List <"))
                    {//数组
                        string listType = item.Type.Split(new String[] {"<", ">"}, StringSplitOptions.RemoveEmptyEntries)[1];
                        if (listType == "string") {
                            typeStrContext += "\t\t" + item.Name + "?: string[];";
                            paramContext += "\t" + item.Name + ": string[] = [];";
                        } 
                        else if (listType == "int" || listType == "uint" || listType == "int16" || listType == "uint16"
                            || listType == "long" || listType == "ulong" || listType == "float" || listType == "double")
                        {
                            typeStrContext += "\t\t" + item.Name + "?: number[];";
                            paramContext += "\t" + item.Name + ": number[] = [];";
                        }
                        else
                        {
                            typeStrContext += "\t\t" + item.Name + "?: " + listType + "ToClientFormat[];";
                            paramContext += "\t" + item.Name + ": " + listType + "ToClientFormat[] = [];";
                        }
                    } 
                    else if (item.Type.Contains("[")) {
                        //数组
                        string listType = item.Type.Split(new String[] {"["}, StringSplitOptions.RemoveEmptyEntries)[0];
                        if (listType == "string") {
                            typeStrContext += "\t\t" + item.Name + "?: string[];";
                            paramContext += "\t" + item.Name + ": string[] = [];";
                        } 
                        else if (listType == "int" || listType == "uint" || listType == "int16" || listType == "uint16"
                            || listType == "long" || listType == "ulong" || listType == "float" || listType == "double")
                        {
                            typeStrContext += "\t\t" + item.Name + "?: number[];";
                            paramContext += "\t" + item.Name + ": number[] = [];";
                        }
                        else
                        {
                            typeStrContext += "\t\t" + item.Name + "?: " + listType + "ToClientFormat[];";
                            paramContext += "\t" + item.Name + ": " + listType + "ToClientFormat[] = [];";
                        }
                        
                    }
                    else if (item.Type.Contains("Dictionary<") || item.Type.Contains("Dictionary <"))
                    {//字典
                        string listType = item.Type.Split(new String[] {"<", ">"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(",")[1].Replace(" ", "");
                        if (listType == "int" || listType == "uint" || listType == "int16" || listType == "uint16"
                            || listType == "long" || listType == "ulong" || listType == "float" || listType == "double") {
                            typeStrContext += "\t\t" + item.Name + "?: {[key: string]: number};";
                            paramContext += "\t" + item.Name + ": {[key: string]: number} = {};";
                        }
                        else if (listType == "string") {

                            typeStrContext += "\t\t" + item.Name + "?: {[key: string]: string};";
                            paramContext += "\t" + item.Name + ": {[key: string]: string} = {};";
                        }
                        else {
                            typeStrContext += "\t\t" + item.Name + "?: {[key: string]: "+ listType + "ToClientFormat};";
                            paramContext += "\t" + item.Name + ": {[key: string]: " + listType + "ToClientFormat} = {};";
                        }
                    }
                    else if (item.Type.Contains("DateTime"))
                    {//时间
                        typeStrContext += "\t\t" + item.Name + "?: number;";
                        paramContext += "\t" + item.Name + ": number = Date.now();";
                    }
                    else
                    {//值类型变量
                        if (item.Value != "")
                        {//有赋初值
                            if (item.Type == "string") {
                                typeStrContext += "\t\t" + item.Name + "?: string;";
                                paramContext += "\t" + item.Name + ": string = " + item.Value + ";";
                            }
                            else if (item.Type == "int" || item.Type == "uint" || item.Type == "int16" || item.Type == "uint16"
                            || item.Type == "long" || item.Type == "ulong" || item.Type == "float" || item.Type == "double") {
                                typeStrContext += "\t\t" + item.Name + "?: number;";
                                paramContext += "\t" + item.Name + ": number = 0;";
                            } 
                            else
                            {
                                typeStrContext += "\t\t" + item.Name + "?: " + item.Type + "ToClientFormat;";
                                paramContext += "\t" + item.Name + ": " + item.Type + "ToClientFormat = {};";
                            }
                        }
                        else
                        {//没有初值
                            if (item.Type == "string") {
                                typeStrContext += "\t\t" + item.Name + "?: string;";
                                paramContext += "\t" + item.Name + ": string = \"\";";
                            } 
                            else if (item.Type == "int" || item.Type == "uint" || item.Type == "int16" || item.Type == "uint16"
                            || item.Type == "long" || item.Type == "ulong" || item.Type == "float" || item.Type == "double")
                            {
                                typeStrContext += "\t\t" + item.Name + "?: number;";
                                paramContext += "\t" + item.Name + ": number = 0;";
                            }
                            else {
                                typeStrContext += "\t\t" + item.Name + "?: " + item.Type + "ToClientFormat;";
                                paramContext += "\t" + item.Name + ": " + item.Type + "ToClientFormat = {};";
                            }
                        }
                    }
                    constructorContext += "\t\t\tthis." + item.Name + " = data."+ item.Name +" || this." + item.Name + ";\r\n";
                    paramContext += " " + item.Comment + " //" + item.Type + "\r\n";
                    typeStrContext += " " + item.Comment + " //" + item.Type + "\r\n";
                }
                str += paramContext;
                str += "\tconstructor(data?: " + className + "Format) {\r\n\t\tif(data){\r\n" + constructorContext + "\t\t}\n\t}\n";
                //类结束
                str += "}\r\n\r\n";
                //构造结构
                str += "declare global {\n\ttype " + className + "Format = {\r\n" + typeStrContext + "\t}\n}\n\n";
            }
            //写文件
            var fs = new FileStream(filename, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Close();
        }
    }

    //复制到目标路径
    public static void CopyToDestDirectory()
    {
        //拷贝CS文件
        {
            if (string.IsNullOrEmpty(mConfig.CopyCSTo))
                return;
            DirectoryCopy(mConfig.InputFolder, mConfig.CopyCSTo, false);
        }
        //拷贝JS文件到服务器
        {
            if (string.IsNullOrEmpty(mConfig.CopyJSTo))
                return;
            DirectoryCopy(mConfig.OutputJSFolder, mConfig.CopyJSTo, false);
        }
    }

    //目录拷贝
    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();

        //如果目录不存在
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        //创建目标目录
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }
        // 获得所有文件
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            // 路径拼接
            string temppath = Path.Combine(destDirName, file.Name);
            // 复制文件
            file.CopyTo(temppath, true);
            Console.WriteLine("Copy:" + temppath);
        }
        // 如果需要拷贝子目录
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                //路径拼接
                string temppath = Path.Combine(destDirName, subdir.Name);
                //拷贝子目录
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
}