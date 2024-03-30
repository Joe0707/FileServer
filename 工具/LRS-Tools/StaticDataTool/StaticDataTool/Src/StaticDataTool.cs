using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using Newtonsoft.Json;
using StaticData;
using System.Text;

namespace StaticDataTool
{
    //.net core 默认的当前路径是 dotnet 的当前目录，所以要动态设置当前运行程序的目录
    public class SetCurDir
    {
        public static void Set()
        {//设定运行目录为当前目录
            dynamic type = (new SetCurDir()).GetType();
            string currentDirectory = Path.GetDirectoryName(type.Assembly.Location);
            Directory.SetCurrentDirectory(currentDirectory);
        }
    }

    public class StaticDataTool
    {
        static string mDataFileTemplate = "";
        static List<XmlSheet> mSheetList = new List<XmlSheet>();
        static ToolConfig mToolConfig = new ToolConfig();
        static Dictionary<string, string> mType2ReadFunc = new Dictionary<string, string>(){
            { "long", "ReadInt64()" }, {"ulong", "ReadUInt64()"},
            { "int", "ReadInt32()" }, {"uint", "ReadUInt32()"},
            { "short", "ReadInt16()" }, {"ushort", "ReadUInt16()"},
            { "float", "ReadSingle()" }, {"double", "ReadDouble()"},
            { "string", "ReadString()" }, {"byte", "ReadByte()"},
        };

        static string mTempDefineDir = "./Defines";
        static void Main(string[] args)
        {
            var data = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            SetCurDir.Set(); //设定当前目录
            LoadConfig();
            if (args.Length > 0)
            {
                //处理所有文件
                foreach (var arg in args)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(arg);
                        if ((((ushort)fi.Attributes) & ((ushort)FileAttributes.Directory)) > 0)
                        {//是个路径
                            ReadFolder(arg);
                        }
                        else//是个文件
                            ReadFile(arg);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            else
            {
                ReadFolder(mToolConfig.InputXmlFolder);
            }
            Console.WriteLine($"Read Xml data done , use time: {new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - data}");
            //初始化输出目录
            InitOutputDirectory();
            var defines = LoadDefineCSFiles();
            //生成CS文件
            //加载Template
            var fs = new FileStream("./../Input/TemplateFiles/DataFileTemplate.txt", FileMode.Open);
            var sr = new StreamReader(fs);
            mDataFileTemplate = sr.ReadToEnd();
            sr.Close();
            //生成所有表对应的cs文件
            foreach (var sheet in mSheetList)
            {
                WriteSheet2CSFile(sheet, true);
                WriteSheet2CSFile(sheet, false);
            }
            Console.WriteLine($"build cs file done , use time: {new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - data}");
            //生成bin文件
            foreach (var sheet in mSheetList)
            {
                WriteSheet2BinFile(sheet, true, defines);
                WriteSheet2BinFile(sheet, false, defines);
            }
            Console.WriteLine($"build bytes file done , use time: {new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - data}");
            //生成Json文件
            Assembly gAss = null;
            foreach (var dllPath in defines) {
                var dirPath = System.IO.Path.GetFullPath(dllPath);
                if (dllPath == "./Defines/GlobalDefine.cs.dll") {
                    byte[] b = File.ReadAllBytes(dirPath);
                    gAss = Assembly.Load(b);
                }
            }
            foreach (var sheet in mSheetList)
            {
                WriteSheet2JsonFile(sheet, true, gAss, defines);
                WriteSheet2JsonFile(sheet, false, gAss, defines);
            }
            Console.WriteLine($"build json file done , use time: {new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - data}");
            //生成StaticDataMgr.cs文件
            WriteStaticDataFile(true);
            WriteStaticDataFile(false);

            Console.WriteLine("Convert finished!");
            //开始拷贝文件
            CopyWorker.CopyBin(mToolConfig.Copy_Bin_C_ToFolder, false);
            CopyWorker.CopyBin(mToolConfig.Copy_Bin_S_ToFolder, true);
            CopyWorker.CopyStaticDataMgrCode(mToolConfig.Copy_StaticDataMgr_C_ToFolder, false);
            CopyWorker.CopyStaticDataMgrCode(mToolConfig.Copy_StaticDataMgr_S_ToFolder, true);
            CopyWorker.CopyDataCode(mToolConfig.Copy_DataCode_C_ToFolder, false);
            CopyWorker.CopyDataCode(mToolConfig.Copy_DataCode_S_ToFolder, true);
            CopyWorker.CopyJson(mToolConfig.Copy_Json_C_ToFolder, false);
            CopyWorker.CopyJson(mToolConfig.Copy_Json_S_ToFolder, true);
            //删除临时文件
            if (Directory.Exists(mTempDefineDir))
                Directory.Delete(mTempDefineDir, true);
            Console.WriteLine($"build copy file done , use time: {new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - data}");
        }



        //加载路径
        static void ReadFolder(string folderPath)
        {
            DirectoryInfo folderInfo = new DirectoryInfo(folderPath);
            DirectoryInfo[] subfolders = folderInfo.GetDirectories();
            //遍历文件
            FileInfo[] files = folderInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension.ToLower() == ".xml")
                    ReadFile(file.FullName);
            }
            foreach (DirectoryInfo folder in subfolders)
            {//遍历子文件夹
                ReadFolder(folder.FullName);
            }
        }

        //加载文件
        static void ReadFile(string filePathName)
        {
            if (filePathName.Contains("._"))
                return;
            XmlFile xmlfile = new XmlFile();
            try
            {
                xmlfile.LoadXml(filePathName, mSheetList);
                Console.WriteLine("Read File Done! [" + Path.GetFileName(filePathName) + "]");
            }
            catch (Exception e)
            {
                Console.WriteLine("!!Error[" + Path.GetFileName(filePathName) + "] \n" + e.ToString());
            }
        }
        
        //初始化输出目录
        static void InitOutputDirectory()
        {
            if (Directory.Exists(FolderCfg.OutputDir) == true)
                Directory.Delete(FolderCfg.OutputDir, true);
            Directory.CreateDirectory(FolderCfg.OutputDir);
            Directory.CreateDirectory(FolderCfg.OutputDir_Code_C);
            Directory.CreateDirectory(FolderCfg.OutputDir_Code_C_Data);
            Directory.CreateDirectory(FolderCfg.OutputDir_Code_S);
            Directory.CreateDirectory(FolderCfg.OutputDir_Code_S_Data);
            Directory.CreateDirectory(FolderCfg.OutputDir_Bin_C);
            Directory.CreateDirectory(FolderCfg.OutputDir_Bin_S);
            Directory.CreateDirectory(FolderCfg.OutputDir_Json_C);
            Directory.CreateDirectory(FolderCfg.OutputDir_Json_S);
        }
        //生成CS文件
        static void WriteSheet2CSFile(XmlSheet sheet, bool isServer)
        {
            var csFileName = "./../Output/Code_"+ (isServer?"S":"C") +"/Data/" + sheet.mName + "Data.cs";
            var finalContent = mDataFileTemplate;//保存最终结果的变量
            //类名
            var className = sheet.mName + "Data";
            finalContent = finalContent.Replace("{$ClassName}", className);
            //成员和读数据
            string memberVars = "";//成员变量
            string readDataCode = "";//读数据的代码
            //读表格中所有的列
            for (int i = 0; i < sheet.mComments.Count; i++)
            {
                if(isServer)
                {//服务器
                    if (sheet.mRangeType[i] == XmlSheet.ERangeType.Client || sheet.mRangeType[i] == XmlSheet.ERangeType.None)
                        continue;
                }
                else
                {//客户端
                    if (sheet.mRangeType[i] == XmlSheet.ERangeType.Server || sheet.mRangeType[i] == XmlSheet.ERangeType.None)
                        continue;
                }
                var curTypeStr = sheet.mTypes[i];
                if (curTypeStr == "string reference")//字符串引用,转换成uint型的id
                    curTypeStr = "uint";
				if (curTypeStr == "long" || curTypeStr == "ulong" || curTypeStr == "int" || curTypeStr == "uint" ||
					curTypeStr == "short" || curTypeStr == "ushort" || curTypeStr == "byte" || curTypeStr == "float" || curTypeStr == "double")
				{//数字型
					if (i == 0)
					{//ID列，特殊处理
						sheet.mVarNames[i] = "mID";
					}
					else
						memberVars += "public " + curTypeStr + " " + sheet.mVarNames[i] + " = 0;\t//" + sheet.mComments[i];
					readDataCode += sheet.mVarNames[i] + " = br." + mType2ReadFunc[curTypeStr] + ";\t//" + sheet.mComments[i];
				}
				else if (curTypeStr == "string")
				{//字符串
					memberVars += "public " + sheet.mTypes[i] + " " + sheet.mVarNames[i] + " = \"\";\t//" + sheet.mComments[i];
					readDataCode += sheet.mVarNames[i] + " = br.ReadString()" + ";\t//" + sheet.mComments[i]; ;
				}
				else if (curTypeStr == "bool")
				{//布尔
					memberVars += "public " + sheet.mTypes[i] + " " + sheet.mVarNames[i] + " = false;\t//" + sheet.mComments[i];
					readDataCode += sheet.mVarNames[i] + " = br.ReadBoolean()" + ";\t//" + sheet.mComments[i]; ;
				}
                else if (curTypeStr.Contains("enum"))
                { //枚举
                    var enumArray = sheet.mTypes[i].Split(":".ToCharArray());
                    if (enumArray.Length < 2)
                        throw new Exception("header enum type error at col " + i);
                    string enumTypeStr = enumArray[1];
                    memberVars += "public " + enumTypeStr + " " + sheet.mVarNames[i] + ";\t//" + sheet.mComments[i];
                    readDataCode += sheet.mVarNames[i] + " = (" + enumTypeStr + ")br.ReadUInt16()" + ";\t//" + sheet.mComments[i];
                }
                else if(curTypeStr.Contains("["))
                {//数组
                    int startIdx_Bracket = curTypeStr.IndexOf('[');
                    int endIdx_Bracket = curTypeStr.IndexOf(']');
                    var arrayTypeStr = curTypeStr.Substring(0, startIdx_Bracket);
                    var arrayCount = 0;
                    if(false == Int32.TryParse(curTypeStr.Substring(startIdx_Bracket+1, endIdx_Bracket - startIdx_Bracket - 1), out arrayCount))
                        throw new Exception("Array Capacity is missing at col " + i);
                    memberVars += "public " + arrayTypeStr + "[] " + sheet.mVarNames[i] + " = new "+ arrayTypeStr + "["+ arrayCount+"];\t//" + sheet.mComments[i];
                    readDataCode += "ushort cnt" + arrayCount + "_"+i+" = br.ReadUInt16();\r\n\t\t\t";
                    readDataCode += "for(ushort i = 0; i < cnt" + arrayCount + "_" + i + "; i++)\r\n\t\t\t\t" + sheet.mVarNames[i] + "[i] = br." + mType2ReadFunc[arrayTypeStr] + ";\t//" + sheet.mComments[i];
                }
                else
                {//未识别类型
                    throw new Exception("Unrecognized type at col " + i);
                }
                //换行
                memberVars += "\r\n\t\t";
                readDataCode += "\r\n\t\t\t";
            }//for

            //替换模板文件中的内容
            finalContent = finalContent.Replace("{$MemberVars}", memberVars);
            finalContent = finalContent.Replace("{$ReadDataCode}", readDataCode);
            //保存到文件
            var fs = new FileStream(csFileName, FileMode.Create);
            var sWriter = new StreamWriter(fs);
            sWriter.Write(finalContent);
            sWriter.Close();
        }
      

        //生成Bin文件
        static void WriteSheet2BinFile(XmlSheet sheet, bool isServer, string[] defines)
        {
			try
			{
                Console.WriteLine($"build sheet {sheet.mName}");
				string binFileName = "./../Output/Bin_" + (isServer ? "S" : "C") + "/" + sheet.mName + ".bytes";
				string binTmpFileName = binFileName + ".tmp";
                var ms = new MemoryStream();
				var fs = new FileStream(binTmpFileName, FileMode.Create);
                ms.CopyTo(fs);
				var bw = new BinaryWriter(fs);
                
                StringBuilder fStr = new StringBuilder();
                fStr.Append("public static int WriteData");
                fStr.Append(sheet.mName);
                fStr.Append("_");
                fStr.Append((isServer ? "S" : "C"));
                fStr.Append("(System.IO.BinaryWriter bw){\r\ntry{\r\n");
				//写一行数据
				Action<string, string, int, int> funcStringWriteLine = (tTypeStr, tValue, r, c) =>
				{
                    tValue = tValue != null ? tValue : "";
					if (tTypeStr == "long" || tTypeStr == "ulong" || tTypeStr == "int" || tTypeStr == "uint" ||
							tTypeStr == "short" || tTypeStr == "ushort" || tTypeStr == "byte" || tTypeStr == "float" || tTypeStr == "double")
					{//数字型
						if (tValue == "" || tValue == null)
							tValue = "0";
                        fStr.Append("bw.Write((");
                        fStr.Append(tTypeStr);
                        fStr.Append(")");
                        fStr.Append(tValue);
                        fStr.Append(");\r\n");
					}
					else if (tTypeStr == "bool")
					{//布尔布
						var lowerValue = tValue.ToLower();
						if (lowerValue == "0")
							lowerValue = "false";
						else if (lowerValue == "1")
							lowerValue = "true";
						else if (lowerValue != "true" && lowerValue != "false")
							lowerValue = "false";
						//尔
                        fStr.Append("bw.Write((");
                        fStr.Append(tTypeStr);
                        fStr.Append(")");
                        fStr.Append(lowerValue);
                        fStr.Append(");\r\n");
					}
					else if (tTypeStr == "string")
					{//字符串型
                        fStr.Append("bw.Write((");
                        fStr.Append(tTypeStr);
                        fStr.Append(")\"");
                        fStr.Append(tValue);
                        fStr.Append("\");\r\n");
					}
					else if (tTypeStr == "string reference")
					{//字符串引用,转换成ushort型的id
						if (tValue != "")
						{
							if (XmlSheet_Strings.sRef2IDMap.ContainsKey(tValue) == false)
								throw new Exception("Can't find string ref '" + tValue + "'. Sheet=" + sheet.mName);
                            fStr.Append("bw.Write((uint)");
                            fStr.Append(XmlSheet_Strings.sRef2IDMap[tValue]);
                            fStr.Append(");\r\n");
						}
						else
                            fStr.Append("bw.Write((uint)0);\r\n");
					}
					else if (tTypeStr.Contains("enum"))
					{ //枚举
						var enumArray = tTypeStr.Split(":".ToCharArray());
						if (enumArray.Length < 2)
							throw new Exception("header enum type error at col " + c);
						string enumTypeStr = enumArray[1];
                        fStr.Append("bw.Write((ushort)");
                        fStr.Append(enumTypeStr);
                        fStr.Append(".");
                        fStr.Append(tValue);
                        fStr.Append(");\r\n");
					}
					else
					{//未识别类型
						throw new Exception("Unrecognized type of " + tTypeStr + " at row:" + r + " col:" + c);
					}
				};

				//读表格中所有的行
				for (int r = 0; r < sheet.mValues.Count; r++)
				{//数据第0行就是真实数据。表头3行已去掉
				 //列
					for (int c = 0; c < sheet.mComments.Count; c++)
					{
						if (isServer)
						{//服务器
							if (sheet.mRangeType[c] == XmlSheet.ERangeType.Client || sheet.mRangeType[c] == XmlSheet.ERangeType.None)
								continue;
						}
						else
						{//客户端
							if (sheet.mRangeType[c] == XmlSheet.ERangeType.Server || sheet.mRangeType[c] == XmlSheet.ERangeType.None)
								continue;
						}
						var curTypeStr = sheet.mTypes[c];
						if (curTypeStr.Contains("["))
						{//数组
							int startIdx_Bracket = curTypeStr.IndexOf('[');
							int endIdx_Bracket = curTypeStr.IndexOf(']');
							var arrayTypeStr = curTypeStr.Substring(0, startIdx_Bracket);
							int arrayCount = 0;
							if (false == Int32.TryParse(curTypeStr.Substring(startIdx_Bracket + 1, endIdx_Bracket - startIdx_Bracket - 1), out arrayCount))
								throw new Exception("Array Capacity is missing at row:" + r + " col:" + c);
							string[] arrayValue = sheet.mValues[r][c].Split("|".ToCharArray());
							if (arrayValue.Length != arrayCount)
								throw new Exception("Data array count is not valid at row:" + r + " col:" + c);
							//数量
							funcStringWriteLine("ushort", arrayCount.ToString(), r, c);
							for (int i = 0; i < arrayCount; i++)
								funcStringWriteLine(arrayTypeStr, arrayValue[i], r, c);//数据
						}
						else
						{//非数组
							funcStringWriteLine(curTypeStr, sheet.mValues[r][c], r, c);
						}
					}//for col
				}//for row
                fStr.Append("return 0;\r\n}catch(Exception e){Console.WriteLine(e.ToString());return 1; \r\n}\r\n}");
                if(mToolConfig.LogOn)
				    Console.WriteLine("--" + fStr.ToString());
				RunFunction<int>(defines, fStr.ToString(), 0, (object)bw);
				bw.Close();
				//加密
				FileDes.EncryptFile(binTmpFileName, binFileName, false);
                //删除临时文件
                File.Delete(binTmpFileName);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
        }
         
        //判断某列之后的列是不是没有实质内容了（后面都是none）
        static bool EmptyCollumsFollowed(XmlSheet sheet, int fromCol, bool isServer)
        {
            for (int i = fromCol + 1; i < sheet.mComments.Count; i++)
            {
                if (isServer)
                {//服务器
                    if (sheet.mRangeType[i] == XmlSheet.ERangeType.Server || sheet.mRangeType[i] == XmlSheet.ERangeType.Both)
                        return false;
                }
                else
                {//客户端
                    if (sheet.mRangeType[i] == XmlSheet.ERangeType.Client || sheet.mRangeType[i] == XmlSheet.ERangeType.Both)
                        return false;
                }
            }
            return true;
        }
 
        //生成Json文件
        static void WriteSheet2JsonFile(XmlSheet sheet, bool isServer, Assembly gAss, string[] defines)
        {
            Console.WriteLine($"build sheet {sheet.mName} to json");
			try
			{
				string jsonFileName = "./../Output/Json_" + (isServer ? "S" : "C") + "/" + sheet.mName + ".json";
				var fs = new FileStream(jsonFileName, FileMode.Create);
				var sw = new StreamWriter(fs);
                StringBuilder jStr = new StringBuilder();
                StringBuilder fStr = new StringBuilder();
                fStr.Append("public static int WriteJson");
                fStr.Append(sheet.mName);
                fStr.Append("_");
                fStr.Append(isServer ? "S" : "C");
                fStr.Append("(System.IO.StreamWriter sw){\r\n");
                fStr.Append("StringBuilder jStr = new StringBuilder();\ntry{\r\n");
                jStr.Append("[\n");
				//读表格中所有的行
				for (int r = 0; r < sheet.mValues.Count; r++)
				{//数据第0行就是真实数据。表头3行已去掉
                    fStr.Append("jStr.Append(\"{\\n\");\n");
                    jStr.Append("{\n");
				 //列
					for (int c = 0; c < sheet.mComments.Count; c++)
					{
						if (isServer)
						{//服务器
							if (sheet.mRangeType[c] == XmlSheet.ERangeType.Client || sheet.mRangeType[c] == XmlSheet.ERangeType.None)
								continue;
						}
						else
						{//客户端
							if (sheet.mRangeType[c] == XmlSheet.ERangeType.Server || sheet.mRangeType[c] == XmlSheet.ERangeType.None)
								continue;
						}
						var curTypeStr = sheet.mTypes[c];
						if (curTypeStr.Contains("["))
						{//数组
							int startIdx_Bracket = curTypeStr.IndexOf('[');
							int endIdx_Bracket = curTypeStr.IndexOf(']');
							var arrayTypeStr = curTypeStr.Substring(0, startIdx_Bracket);
							int arrayCount = 0;
							if (false == Int32.TryParse(curTypeStr.Substring(startIdx_Bracket + 1, endIdx_Bracket - startIdx_Bracket - 1), out arrayCount))
								throw new Exception("Array Capacity is missing at row:" + r + " col:" + c);
							string[] arrayValue = sheet.mValues[r][c].Split("|".ToCharArray());
							if (arrayValue.Length != arrayCount)
								throw new Exception("Data array count is not valid at row:" + r + " col:" + c);
                            fStr.Append("jStr.Append(\"\\t\\\"");
                            fStr.Append(sheet.mVarNames[c]);
                            fStr.Append("\\\" : [\");\n"); //写表头
                            jStr.Append("\t\"");
                            jStr.Append(sheet.mVarNames[c]);
                            jStr.Append("\" : [");
							for (int i = 0; i < arrayCount; i++)
                            {
                                if(i > 0) {
                                    fStr.Append("jStr.Append(\",\");\n");
                                    jStr.Append(",");
                                }
                                if(sheet.mTypes[c].ToLower().Contains("string")) { //字符串类型
                                    fStr.Append("jStr.Append(\"\\\"");
                                    fStr.Append(ReplaceBackSlash(arrayValue[i]));
                                    fStr.Append("\\\"\");\n");//数据
                                    jStr.Append("\"");
                                    jStr.Append(ReplaceBackSlash(arrayValue[i]));
                                    jStr.Append("\"");
                                }
                                else {
                                    fStr.Append("jStr.Append(");
                                    fStr.Append(arrayValue[i].ToString());
                                    fStr.Append(");\n");//数据
                                    jStr.Append(arrayValue[i].ToString());
                                }
                            }
                            fStr.Append("jStr.Append(\"]\");\n");
                            jStr.Append("]");
						}
						else
                        {//非数组
                            var tValue = sheet.mValues[r][c];
                            if (curTypeStr == "long" || curTypeStr == "ulong" || curTypeStr == "int" || curTypeStr == "uint" ||
                                                        curTypeStr == "short" || curTypeStr == "ushort" || curTypeStr == "byte" || curTypeStr == "float" || curTypeStr == "double")
                            {//数字型
                                if (tValue == "")
                                    tValue = "0";
                                fStr.Append("jStr.Append(\"\\t\\\"");
                                fStr.Append(sheet.mVarNames[c]);
                                fStr.Append("\\\" : \");\n");
                                fStr.Append("jStr.Append(");
                                fStr.Append(tValue);
                                fStr.Append(");\n");//数据
                                jStr.Append("\t\"");
                                jStr.Append(sheet.mVarNames[c]);
                                jStr.Append("\" : ");
                                jStr.Append(tValue);
                            }
                            else if (curTypeStr == "bool")
                            {//布尔布
                                var lowerValue = tValue.ToLower();
                                if (lowerValue == "0")
                                    lowerValue = "false";
                                else if (lowerValue == "1")
                                    lowerValue = "true";
                                else if (lowerValue != "true" && lowerValue != "false")
                                    lowerValue = "false";
                                fStr.Append("jStr.Append(\"\\t\\\"");
                                fStr.Append(sheet.mVarNames[c]);
                                fStr.Append("\\\" : \");\n");
                                fStr.Append("jStr.Append(");
                                fStr.Append(lowerValue);
                                fStr.Append(");\n");//数据
                                jStr.Append("\t\"");
                                jStr.Append(sheet.mVarNames[c]);
                                jStr.Append("\" : ");
                                jStr.Append(lowerValue);
                            }
                            else if (curTypeStr == "string")
                            {//字符串型
                                fStr.Append("jStr.Append(\"\\t\\\"");
                                fStr.Append(sheet.mVarNames[c]);
                                fStr.Append("\\\" : \");\n");
                                fStr.Append("jStr.Append(\"\\\"");
                                fStr.Append(ReplaceBackSlash(tValue));
                                fStr.Append("\\\"\");\n");//数据
                                jStr.Append("\t\"");
                                jStr.Append(sheet.mVarNames[c]);
                                jStr.Append("\" : ");
                                jStr.Append("\"");
                                jStr.Append(ReplaceBackSlash(tValue));
                                jStr.Append("\"");
                            }
                            else if (curTypeStr == "string reference")
                            {//字符串引用,转换成ushort型的id
                                if (tValue != "")
                                {
                                    if (XmlSheet_Strings.sRef2IDMap.ContainsKey(tValue) == false)
                                        throw new Exception("Can\\\"t find string ref \\\"" + tValue + "\\\". Sheet=" + sheet.mName);
                                    fStr.Append("jStr.Append(\"\\t\\\"");
                                    fStr.Append(sheet.mVarNames[c]);
                                    fStr.Append("\\\" : \");\n");
                                    fStr.Append("jStr.Append(");
                                    fStr.Append(XmlSheet_Strings.sRef2IDMap[tValue].ToString());
                                    fStr.Append(");\n");//数据
                                    jStr.Append("\t\"");
                                    jStr.Append(sheet.mVarNames[c]);
                                    jStr.Append("\" : ");
                                    jStr.Append(XmlSheet_Strings.sRef2IDMap[tValue].ToString());
                                }
                                else
                                {
                                    fStr.Append("jStr.Append(\"\\t\\\"");
                                    fStr.Append(sheet.mVarNames[c]);
                                    fStr.Append("\\\" : \");\n");
                                    fStr.Append("jStr.Append(");
                                    fStr.Append(0);
                                    fStr.Append(");\n");//数据
                                    jStr.Append("\t\"");
                                    jStr.Append(sheet.mVarNames[c]);
                                    jStr.Append("\" : ");
                                    jStr.Append(0);
                                }
                            }
                            else if (curTypeStr.Contains("enum"))
                            { //枚举
                                var enumArray = curTypeStr.Split(":".ToCharArray());
                                if (enumArray.Length < 2)
                                    throw new Exception("header enum type error at col " + c);
                                string enumTypeStr = enumArray[1];
                                fStr.Append("jStr.Append(\"\\t\\\"");
                                fStr.Append(sheet.mVarNames[c]);
                                fStr.Append("\\\" : \");\n");
                                fStr.Append("jStr.Append((ushort)");
                                fStr.Append(enumTypeStr);
                                fStr.Append(".");
                                fStr.Append(tValue);
                                fStr.Append(");\n");//数据
                                jStr.Append("\t\"");
                                jStr.Append(sheet.mVarNames[c]);
                                jStr.Append("\" : ");
                                if (tValue == "") {
                                    throw new Exception("Enum type error at row:" + r + " col:" + c);
                                } else {
                                    var type = gAss.GetType(enumTypeStr);
                                    var parseValue = System.Enum.Parse(type, tValue);
                                    jStr.Append((int)(parseValue));
                                }
                            }
                            else
                            {//未识别类型
                                throw new Exception("Unrecognized type of " + curTypeStr + " at row:" + r + " col:" + c);
                            }
                        }
                        //插入,
                        if (EmptyCollumsFollowed(sheet, c, isServer) == false){ //后面列还有内容
                            fStr.Append("jStr.Append(\",\\n\");\n");
                            jStr.Append(",\n");
                        }
                        else {//最后一个数据只插入一个回车
                            fStr.Append("jStr.Append(\"\\n\");\n");
                            jStr.Append("\n");
                        }
                    }//for col
                    fStr.Append("jStr.Append(\"}\");\n");
                    jStr.Append("}");
                    //插入,
                    if (r < sheet.mValues.Count - 1) {
                        fStr.Append("jStr.Append(\",\\n\");\n");
                        jStr.Append(",\n");
                    }
                        
                    else {//最后一个数据只插入一个回车
                        fStr.Append("jStr.Append(\"\\n\");\n");
                        jStr.Append("\n");
                    }
                        
                }//for row
                fStr.Append("jStr.Append(\"]\\n\");\n");
                jStr.Append("]");
                fStr.Append("sw.Write(jStr.ToString();\n");
                fStr.Append("return 0;\r\n}catch(Exception e){Console.WriteLine(e.ToString());return 1; \r\n}\r\n}");//结束
                if(mToolConfig.LogOn)
                    Console.WriteLine("--" + fStr.ToString());
                //RunFunction<int>(defines, fStr.ToString(), 0, (object)sw);
                sw.WriteLine(jStr.ToString());
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //替换字符串中的反斜杠
        static string ReplaceBackSlash(string input)
        {
            return input.Replace("\\", "\\\\");
        }

        //执行一个字符串的函数,函数声明必须是public static的
        static int RunFuncCount = 0;
        static T RunFunction<T>(string[] defines, string funcCode, T errorReturnValue, params object[] parameters)
        {
            RunFuncCount++;
            //var defines = LoadDefineCSFiles();
            int idx2 = funcCode.IndexOf("(", 0);
            int idx1 = funcCode.LastIndexOf(" ", idx2);
            string funcName = funcCode.Substring(idx1 + 1, idx2 - idx1 - 1);
            string className = "TempNameClass" + RunFuncCount;
            var code = "using System;\nusing System.IO;\nnamespace TempNameSpace{public class " + className + "{" + funcCode + "}}";
            try
            {
                var assembly = GetAssemblyFromSourceByRoslyn(code, "runFunc", defines);
                var method = assembly.CreateInstance("TempNameSpace." + className).GetType().GetMethod(funcName);
                T result = (T)method.Invoke(null, parameters);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return errorReturnValue;
            }
        }

        //编译代码成assembly
        static Assembly GetAssemblyFromSourceByRoslyn(string source, string destAssemblyName, string[] refAssemblies, string outputFileName = "")
        {
            List<MetadataReference> references = new List<MetadataReference>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in assemblies)
            {
                if (a.FullName.Contains("System."))
                    references.Add(MetadataReference.CreateFromFile(a.Location));
            }

            if (refAssemblies != null && refAssemblies.Length > 0)
            {
                foreach (var file in refAssemblies)
                {
                    references.Add(MetadataReference.CreateFromFile(file));
                }
            }

            var compilation = CSharpCompilation.Create(
                                                    destAssemblyName,
                                                    new[] { CSharpSyntaxTree.ParseText(source) },
                                                    references,
                                                    new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            using (var memSteam = new MemoryStream())
            {
                var emitResult = compilation.Emit(memSteam);

                if (!emitResult.Success)
                {
                    IEnumerable<Diagnostic> failures = emitResult.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    string exceptionStr = "";
                    foreach (Diagnostic diagnostic in failures)
                    {
                        exceptionStr += diagnostic.Id.ToString() + " : " + diagnostic.GetMessage() + " (" + diagnostic + ")\n";
                    }
                    Console.Error.WriteLine(exceptionStr);
                    //throw new Exception(exceptionStr);
                }

                memSteam.Seek(0, SeekOrigin.Begin);

                if (string.IsNullOrEmpty(outputFileName) == false)
                {//保存文件
                    if (File.Exists(outputFileName))
                        File.Delete(outputFileName);
                    FileStream fs = new FileStream(outputFileName, FileMode.CreateNew);
                    fs.Write(memSteam.GetBuffer());
                    fs.Close();
                }
                memSteam.Seek(0, SeekOrigin.Begin);
                return Assembly.Load(memSteam.ToArray());
            }
        }
        
        //加载枚举定义的cs文件
        static string[] LoadDefineCSFiles()
        {
            //清理目录
            if(Directory.Exists(mTempDefineDir))
            {
                Directory.Delete(mTempDefineDir, true);
            }
            Directory.CreateDirectory(mTempDefineDir);
            //遍历目录并编译
            DirectoryInfo folderInfo = new DirectoryInfo("./../Input/EnumDefines");
            if (folderInfo == null)
            {
                Console.WriteLine("Error: No folder named EnumDefines");
            }
            List<string> retValue = new List<string>();
            //遍历文件
            FileInfo[] files = folderInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension != ".cs")
                    continue;
                var fs = new FileStream(file.FullName, FileMode.Open);
                var sr = new StreamReader(fs);
                var src = sr.ReadToEnd();
                sr.Close();
                var dllName = mTempDefineDir + "/" + file.Name + ".dll";
                GetAssemblyFromSourceByRoslyn(src, file.Name, null, dllName);
                retValue.Add(dllName);
            }
            return retValue.ToArray();
        }

        //生成StaticDataMgr.cs文件
        private static void WriteStaticDataFile(bool isServer)
        {
            try
            {
                var csFileName = "./../Output/Code_" + (isServer ? "S" : "C") + "/" + "StaticDataMgr.cs";
                //加载Template
                var fs = new FileStream("./../Input/TemplateFiles/StaticDataMgrTemplate_" + (isServer ? "S" : "C") + ".txt", FileMode.Open);
                var sr = new StreamReader(fs);
                string finalContent = sr.ReadToEnd();
                sr.Close();
                //数据表定义
                string strDataDefine = "";
                foreach (var sheet in mSheetList)
                {
                    if (strDataDefine != "")
                        strDataDefine += "\t\t";
                    strDataDefine += "public Dictionary<uint, " + sheet.mName + "Data> m" + sheet.mName + "DataMap = new Dictionary<uint, " + sheet.mName + "Data>(); //" + sheet.mName + " Data\r\n";
                }
                finalContent = finalContent.Replace("{$DataDefine}", strDataDefine);

                //数据读取过程定义
                string strDataLoad = "";
                foreach (var sheet in mSheetList)
                {
                    if (strDataLoad != "")
                        strDataLoad += "\t\t\t";
                    //处理函数
                    var funcName = sheet.mName + "DataProcess";
                    if (finalContent.Contains(funcName))//有处理函数的
                        strDataLoad += "LoadDataBinWorker<" + sheet.mName + "Data>(\"" + sheet.mName + ".bytes\", m" + sheet.mName + "DataMap, " + funcName + "); //" + sheet.mName + " Data\r\n";
                    else
                        strDataLoad += "LoadDataBinWorker<" + sheet.mName + "Data>(\"" + sheet.mName + ".bytes\", m" + sheet.mName + "DataMap); //" + sheet.mName + " Data\r\n";

                }
                finalContent = finalContent.Replace("{$LoadData}", strDataLoad);
                //保存到文件
                var wfs = new FileStream(csFileName, FileMode.Create);
                var sWriter = new StreamWriter(wfs);
                sWriter.Write(finalContent);
                sWriter.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Write StaticDataMgr.cs Error");
                Console.WriteLine(e.ToString());
            }
        }

        //加载配置
        static  void LoadConfig()
        {
            try
            {
                FileStream fs = new FileStream("ToolConfig.json", FileMode.Open);
                var sr = new StreamReader(fs);
                var json = sr.ReadToEnd();
                sr.Close();
                mToolConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<ToolConfig>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Read Config error: " + e.ToString());
            }
        }
    }
}
