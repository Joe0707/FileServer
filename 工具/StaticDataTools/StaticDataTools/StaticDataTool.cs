using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Newtonsoft.Json;
using StaticData;

namespace StaticDataTool
{

    public class StaticDataTool
{
	private static string mDataFileTemplate = "";

	private static string mClassFileTemplate = "";

	private static List<XmlSheet> mSheetList = new List<XmlSheet>();

	private static ToolConfig mToolConfig = new ToolConfig();

	private static Dictionary<string, string> mType2ReadFunc = new Dictionary<string, string>
	{
		{ "long", "ReadInt64()" },
		{ "ulong", "ReadUInt64()" },
		{ "int", "ReadInt32()" },
		{ "uint", "ReadUInt32()" },
		{ "short", "ReadInt16()" },
		{ "ushort", "ReadUInt16()" },
		{ "float", "ReadSingle()" },
		{ "double", "ReadDouble()" },
		{ "string", "ReadString()" },
		{ "byte", "ReadByte()" }
	};

	private static string mTempDefineDir = "./Defines";

	private static List<FunctionBox> mQueuedFunctions = new List<FunctionBox>();

	private static int RunFuncCount = 0;

	private static void Main(string[] args)
	{
		SetCurDir.Set();
		LoadConfig();
		if (args.Length != 0)
		{
			foreach (string arg in args)
			{
				try
				{
					if (!File.Exists(arg))
					{
						continue;
					}
					ReadFile(arg);
					Console.WriteLine("Read Xml data done");
					Stopwatch watch = Stopwatch.StartNew();
					foreach (XmlSheet sheet3 in mSheetList)
					{
						WriteSheet2BinFile(sheet3, isServer: false);
					}
					RunQueuedFunctions();
					bool stop = false;
					while (!stop)
					{
						Thread.Sleep(1000);
						stop = true;
						foreach (FunctionBox f2 in mQueuedFunctions)
						{
							if (!f2.mInvoked)
							{
								stop = false;
								break;
							}
						}
					}
					watch.Stop();
					Console.WriteLine("Use Time:" + (double)watch.ElapsedMilliseconds / 1000.0 + "秒");
					Console.WriteLine("Convert finished!");
					CopyWorker.CopyBin(mToolConfig.Copy_Bin_C_ToFolder, forserver: false);
					if (Directory.Exists(mTempDefineDir))
					{
						Directory.Delete(mTempDefineDir, recursive: true);
					}
					Console.WriteLine("Finished!");
					break;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			return;
		}
		InitOutputDirectory();
		ReadFolder(mToolConfig.InputEnumXmlFolder);
		WriteSheet2CSEnumFile(mSheetList, isServer: false);
		mSheetList.Clear();
		WriteSheet2CSClassFiles(mSheetList, isServer: false);
		mSheetList.Clear();
		//WriteFaceCode();
		ReadFolder(mToolConfig.InputXmlFolder);
		Console.WriteLine("Read Xml data done");
		FileStream fs = new FileStream("./../Input/TemplateFiles/DataFileTemplate.txt", FileMode.Open);
		StreamReader sr = new StreamReader(fs);
		mDataFileTemplate = sr.ReadToEnd();
		sr.Close();
		Stopwatch stopWatch = Stopwatch.StartNew();
		foreach (XmlSheet sheet2 in mSheetList)
		{
			WriteSheet2CSFile(sheet2, isServer: false);
		}
		foreach (XmlSheet sheet in mSheetList)
		{
			WriteSheet2BinFile(sheet, isServer: false);
		}
		WriteStaticDataFile(isServer: false);
		RunQueuedFunctions();
		bool stopped = false;
		while (!stopped)
		{
			Thread.Sleep(1000);
			stopped = true;
			foreach (FunctionBox f in mQueuedFunctions)
			{
				if (!f.mInvoked)
				{
					stopped = false;
					break;
				}
			}
		}
		stopWatch.Stop();
		Console.WriteLine("Use Time:" + (double)stopWatch.ElapsedMilliseconds / 1000.0 + "秒");
		Console.WriteLine("Convert finished!");
		CopyWorker.CopyBin(mToolConfig.Copy_Bin_C_ToFolder, forserver: false);
		CopyWorker.CopyStaticDataMgrCode(mToolConfig.Copy_StaticDataMgr_C_ToFolder, forserver: false);
		CopyWorker.CopyDataCode(mToolConfig.Copy_DataCode_C_ToFolder, forserver: false);
		if (Directory.Exists(mTempDefineDir))
		{
			Directory.Delete(mTempDefineDir, recursive: true);
		}
		Console.WriteLine("Finished!");
		Console.ReadLine();
	}

	private static void ReadFolder(string folderPath)
	{
		DirectoryInfo folderInfo = new DirectoryInfo(folderPath);
		DirectoryInfo[] subfolders = folderInfo.GetDirectories();
		FileInfo[] files = folderInfo.GetFiles();
		FileInfo[] array = files;
		foreach (FileInfo file in array)
		{
			if (file.Extension.ToLower() == ".xml")
			{
				ReadFile(file.FullName);
			}
		}
		DirectoryInfo[] array2 = subfolders;
		foreach (DirectoryInfo folder in array2)
		{
			ReadFolder(folder.FullName);
		}
	}

	private static void ReadFile(string filePathName)
	{
		if (filePathName.Contains("._"))
		{
			return;
		}
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

	private static void InitOutputDirectory()
	{
		if (Directory.Exists(FolderCfg.OutputDir))
		{
			Directory.Delete(FolderCfg.OutputDir, recursive: true);
		}
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

	private static void WriteSheet2CSClassFiles(List<XmlSheet> sheets, bool isServer)
	{
		FileStream fs = new FileStream("./../Input/TemplateFiles/ClassFileTemplate.txt", FileMode.Open);
		StreamReader sr = new StreamReader(fs);
		mClassFileTemplate = sr.ReadToEnd();
		for (int i = 0; i < sheets.Count; i++)
		{
			WriteSheet2CSClassFile(sheets[i], isServer);
		}
	}

	private static void WriteSheet2CSClassFile(XmlSheet sheet, bool isServer)
	{
		string csFileName = "./../Output/Code_" + (isServer ? "S" : "C") + "/Data/" + sheet.mName + ".cs";
		string finalContent = mClassFileTemplate;
		string className = sheet.mName;
		finalContent = finalContent.Replace("{$ClassName}", className);
		StringBuilder memberVars = new StringBuilder();
		for (int i = 0; i < sheet.mComments.Count; i++)
		{
			if (isServer)
			{
				if (sheet.mRangeType[i] == XmlSheet.ERangeType.Client || sheet.mRangeType[i] == XmlSheet.ERangeType.None)
				{
					continue;
				}
			}
			else if (sheet.mRangeType[i] == XmlSheet.ERangeType.Server || sheet.mRangeType[i] == XmlSheet.ERangeType.None)
			{
				continue;
			}
			string curTypeStr = sheet.mTypes[i];
			if (curTypeStr == "string reference")
			{
				curTypeStr = "uint";
			}
			switch (curTypeStr)
			{
			default:
				if (!(curTypeStr == "double"))
				{
					if (curTypeStr == "string")
					{
						memberVars.Append("public " + sheet.mTypes[i] + " " + sheet.mVarNames[i] + " = \"\";\t//" + sheet.mComments[i]);
						break;
					}
					if (curTypeStr == "bool")
					{
						memberVars.Append("public " + sheet.mTypes[i] + " " + sheet.mVarNames[i] + " = false;\t//" + sheet.mComments[i]);
						break;
					}
					if (curTypeStr.Contains("enum"))
					{
						string[] enumArray = sheet.mTypes[i].Split(":".ToCharArray());
						if (enumArray.Length < 2)
						{
							throw new Exception("header enum type error at col " + i);
						}
						string enumTypeStr = enumArray[1];
						memberVars.Append("public " + enumTypeStr + " " + sheet.mVarNames[i] + ";\t//" + sheet.mComments[i]);
						break;
					}
					if (curTypeStr.Contains("["))
					{
						int startIdx_Bracket = curTypeStr.IndexOf('[');
						int endIdx_Bracket = curTypeStr.IndexOf(']');
						string arrayTypeStr = curTypeStr.Substring(0, startIdx_Bracket);
						int arrayCount = 0;
						if (!int.TryParse(curTypeStr.Substring(startIdx_Bracket + 1, endIdx_Bracket - startIdx_Bracket - 1), out arrayCount))
						{
							throw new Exception("Array Capacity is missing at col " + i);
						}
						memberVars.Append("public " + arrayTypeStr + "[] " + sheet.mVarNames[i] + " = new " + arrayTypeStr + "[" + arrayCount + "];\t//" + sheet.mComments[i]);
						break;
					}
					throw new Exception(sheet.mName + ": Unrecognized type " + curTypeStr + " at col " + i);
				}
				goto case "long";
			case "long":
			case "ulong":
			case "int":
			case "uint":
			case "short":
			case "ushort":
			case "byte":
			case "float":
				memberVars.Append("public " + curTypeStr + " " + sheet.mVarNames[i] + " = 0;\t//" + sheet.mComments[i]);
				break;
			}
			memberVars.Append("\r\n\t\t");
		}
		finalContent = finalContent.Replace("{$MemberVars}", memberVars.ToString());
		FileStream fs = new FileStream(csFileName, FileMode.Create);
		StreamWriter sWriter = new StreamWriter(fs);
		sWriter.Write(finalContent);
		sWriter.Close();
	}

	private static void WriteSheet2CSEnumFile(List<XmlSheet> sheets, bool isServer)
	{
		string csFileName = "./../Output/Code_" + (isServer ? "S" : "C") + "/Data/Define.cs";
		if (sheets.Count <= 0)
		{
			return;
		}
		StringBuilder build = new StringBuilder();
		foreach (XmlSheet sheet in sheets)
		{
			string enumName = sheet.mName;
			build.AppendFormat("\tpublic enum {0}\r\n\t{{\r\n", enumName);
			if (sheet.mComments.Count < 3)
			{
				throw new Exception(sheet.mName + "不足三列");
			}
			if (sheet.mTypes[1] != "string")
			{
				throw new Exception(sheet.mName + ": Unrecognized type " + sheet.mTypes[1] + " at col " + 1);
			}
			if (sheet.mTypes[2] != "string")
			{
				throw new Exception(sheet.mName + ": Unrecognized type " + sheet.mTypes[2] + " at col " + 2);
			}
			for (int r = 0; r < sheet.mValues.Count; r++)
			{
				uint value = uint.Parse(sheet.mValues[r][0]);
				string name = sheet.mValues[r][1];
				string comment = sheet.mValues[r][2];
				build.AppendFormat("\t\t{0} = {1},//{2}\r\n", name, value, comment);
			}
			build.AppendFormat("\t}}\r\n");
		}
		FileStream fs = new FileStream(csFileName, FileMode.Create);
		StreamWriter sWriter = new StreamWriter(fs);
		sWriter.Write(build.ToString());
		sWriter.Close();
	}

	private static void WriteSheet2CSFile(XmlSheet sheet, bool isServer)
	{
		string csFileName = "./../Output/Code_" + (isServer ? "S" : "C") + "/Data/" + sheet.mName + "Data.cs";
		string finalContent = mDataFileTemplate;
		string className = sheet.mName + "Data";
		finalContent = finalContent.Replace("{$ClassName}", className);
		string memberVars = "";
		string readDataCode = "";
		for (int i = 0; i < sheet.mComments.Count; i++)
		{
			if (isServer)
			{
				if (sheet.mRangeType[i] == XmlSheet.ERangeType.Client || sheet.mRangeType[i] == XmlSheet.ERangeType.None)
				{
					continue;
				}
			}
			else if (sheet.mRangeType[i] == XmlSheet.ERangeType.Server || sheet.mRangeType[i] == XmlSheet.ERangeType.None)
			{
				continue;
			}
			string curTypeStr = sheet.mTypes[i];
			if (curTypeStr == "string reference")
			{
				curTypeStr = "uint";
			}
			switch (curTypeStr)
			{
			default:
				if (!(curTypeStr == "double"))
				{
					if (curTypeStr == "string")
					{
						memberVars = memberVars + "public " + sheet.mTypes[i] + " " + sheet.mVarNames[i] + " = \"\";\t//" + sheet.mComments[i];
						readDataCode = readDataCode + sheet.mVarNames[i] + " = br.ReadString();\t//" + sheet.mComments[i];
						break;
					}
					if (curTypeStr == "bool")
					{
						memberVars = memberVars + "public " + sheet.mTypes[i] + " " + sheet.mVarNames[i] + " = false;\t//" + sheet.mComments[i];
						readDataCode = readDataCode + sheet.mVarNames[i] + " = br.ReadBoolean();\t//" + sheet.mComments[i];
						break;
					}
					if (curTypeStr.Contains("enum"))
					{
						string[] enumArray = sheet.mTypes[i].Split(":".ToCharArray());
						if (enumArray.Length < 2)
						{
							throw new Exception("header enum type error at col " + i);
						}
						string enumTypeStr = enumArray[1];
						memberVars = memberVars + "public " + enumTypeStr + " " + sheet.mVarNames[i] + ";\t//" + sheet.mComments[i];
						readDataCode = readDataCode + sheet.mVarNames[i] + " = (" + enumTypeStr + ")br.ReadUInt16();\t//" + sheet.mComments[i];
						break;
					}
					if (curTypeStr.Contains("["))
					{
						int startIdx_Bracket = curTypeStr.IndexOf('[');
						int endIdx_Bracket = curTypeStr.IndexOf(']');
						string arrayTypeStr = curTypeStr.Substring(0, startIdx_Bracket);
						int arrayCount = 0;
						if (!int.TryParse(curTypeStr.Substring(startIdx_Bracket + 1, endIdx_Bracket - startIdx_Bracket - 1), out arrayCount))
						{
							throw new Exception("Array Capacity is missing at col " + i);
						}
						memberVars = memberVars + "public " + arrayTypeStr + "[] " + sheet.mVarNames[i] + " = new " + arrayTypeStr + "[" + arrayCount + "];\t//" + sheet.mComments[i];
						readDataCode = readDataCode + "ushort cnt" + arrayCount + "_" + i + " = br.ReadUInt16();\r\n\t\t\t";
						readDataCode = readDataCode + "for(ushort i = 0; i < cnt" + arrayCount + "_" + i + "; i++)\r\n\t\t\t\t" + sheet.mVarNames[i] + "[i] = br." + mType2ReadFunc[arrayTypeStr] + ";\t//" + sheet.mComments[i];
						break;
					}
					throw new Exception(sheet.mName + ": Unrecognized type " + curTypeStr + " at col " + i);
				}
				goto case "long";
			case "long":
			case "ulong":
			case "int":
			case "uint":
			case "short":
			case "ushort":
			case "byte":
			case "float":
				if (i == 0)
				{
					sheet.mVarNames[i] = "mID";
				}
				else
				{
					memberVars = memberVars + "public " + curTypeStr + " " + sheet.mVarNames[i] + " = 0;\t//" + sheet.mComments[i];
				}
				readDataCode = readDataCode + sheet.mVarNames[i] + " = br." + mType2ReadFunc[curTypeStr] + ";\t//" + sheet.mComments[i];
				break;
			}
			memberVars += "\r\n\t\t";
			readDataCode += "\r\n\t\t\t";
		}
		finalContent = finalContent.Replace("{$MemberVars}", memberVars);
		finalContent = finalContent.Replace("{$ReadDataCode}", readDataCode);
		FileStream fs = new FileStream(csFileName, FileMode.Create);
		StreamWriter sWriter = new StreamWriter(fs);
		sWriter.Write(finalContent);
		sWriter.Close();
	}

	private static void WriteSheet2BinFile(XmlSheet sheet, bool isServer)
	{
		try
		{
			string binFileName = "./../Output/Bin_" + (isServer ? "S" : "C") + "/" + sheet.mName + ".bytes";
			string binTmpFileName = binFileName + ".tmp";
			FileStream fs = new FileStream(binTmpFileName, FileMode.Create);
			BinaryWriter bw = new BinaryWriter(fs);
			StringBuilder sb = new StringBuilder(1024000);
			sb.AppendFormat("public static int WriteData{0}_{1}(System.IO.BinaryWriter bw){{\r\ntry{{\r\n", sheet.mName, isServer ? "S" : "C");
			Action<string, string, int, int> funcStringWriteLine = delegate(string tTypeStr, string tValue, int r, int c)
			{
				switch (tTypeStr)
				{
				default:
					if (!(tTypeStr == "double"))
					{
						switch (tTypeStr)
						{
						case "bool":
						{
							string text = tValue.ToLower();
							if (text == "0")
							{
								text = "false";
							}
							else if (text == "1")
							{
								text = "true";
							}
							else if (text != "true" && text != "false")
							{
								text = "false";
							}
							sb.AppendFormat("bw.Write(({0}){1});\r\n", tTypeStr, text);
							break;
						}
						case "string":
							sb.AppendFormat("bw.Write(({0})\"{1}\");\r\n", tTypeStr, tValue);
							break;
						case "string reference":
							if (tValue != "")
							{
								if (!XmlSheet_Strings.sRef2IDMap.ContainsKey(tValue))
								{
									throw new Exception("Can't find string ref '" + tValue + "'. Sheet=" + sheet.mName);
								}
								sb.AppendFormat("bw.Write((uint){0});\r\n", XmlSheet_Strings.sRef2IDMap[tValue]);
							}
							else
							{
								sb.Append("bw.Write((uint)0);\r\n");
							}
							break;
						default:
						{
							if (!tTypeStr.Contains("enum"))
							{
								throw new Exception(sheet.mName + ": Unrecognized type of " + tTypeStr + " at row:" + r + " col:" + c);
							}
							string[] array = tTypeStr.Split(":".ToCharArray());
							if (array.Length < 2)
							{
								throw new Exception("header enum type error at col " + c);
							}
							string arg = array[1];
							sb.AppendFormat("bw.Write((ushort){0}.{1});\r\n", arg, tValue);
							break;
						}
						}
						break;
					}
					goto case "long";
				case "long":
				case "ulong":
				case "int":
				case "uint":
				case "short":
				case "ushort":
				case "byte":
				case "float":
					if (tValue == "")
					{
						tValue = "0";
					}
					sb.AppendFormat("bw.Write(({0}){1});\r\n", tTypeStr, tValue);
					break;
				}
			};
			for (int r2 = 0; r2 < sheet.mValues.Count; r2++)
			{
				for (int c2 = 0; c2 < sheet.mComments.Count; c2++)
				{
					if (isServer)
					{
						if (sheet.mRangeType[c2] == XmlSheet.ERangeType.Client || sheet.mRangeType[c2] == XmlSheet.ERangeType.None)
						{
							continue;
						}
					}
					else if (sheet.mRangeType[c2] == XmlSheet.ERangeType.Server || sheet.mRangeType[c2] == XmlSheet.ERangeType.None)
					{
						continue;
					}
					string curTypeStr = sheet.mTypes[c2];
					if (curTypeStr.Contains("["))
					{
						int startIdx_Bracket = curTypeStr.IndexOf('[');
						int endIdx_Bracket = curTypeStr.IndexOf(']');
						string arrayTypeStr = curTypeStr.Substring(0, startIdx_Bracket);
						int arrayCount = 0;
						if (!int.TryParse(curTypeStr.Substring(startIdx_Bracket + 1, endIdx_Bracket - startIdx_Bracket - 1), out arrayCount))
						{
							throw new Exception("Array Capacity is missing at row:" + r2 + " col:" + c2);
						}
						string[] arrayValue = sheet.mValues[r2][c2].Split("|".ToCharArray());
						if (arrayValue.Length != arrayCount)
						{
							throw new Exception("Data array count is not valid at row:" + r2 + " col:" + c2);
						}
						funcStringWriteLine("ushort", arrayCount.ToString(), r2, c2);
						for (int i = 0; i < arrayCount; i++)
						{
							funcStringWriteLine(arrayTypeStr, arrayValue[i], r2, c2);
						}
					}
					else
					{
						funcStringWriteLine(curTypeStr, sheet.mValues[r2][c2], r2, c2);
					}
				}
			}
			sb.Append("return 0;\r\n}catch(Exception e){Console.WriteLine(e.ToString());return 1; \r\n}\r\n}");
			string funcString = sb.ToString();
			if (mToolConfig.LogOn)
			{
				Console.WriteLine("--" + funcString);
			}
			mQueuedFunctions.Add(new FunctionBox(funcString, bw, delegate
			{
				bw.Close();
				FileDes.EncryptFile(binTmpFileName, binFileName, deleteSource: false);
				File.Delete(binTmpFileName);
			}));
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static bool EmptyCollumsFollowed(XmlSheet sheet, int fromCol, bool isServer)
	{
		for (int i = fromCol + 1; i < sheet.mComments.Count; i++)
		{
			if (isServer)
			{
				if (sheet.mRangeType[i] == XmlSheet.ERangeType.Server || sheet.mRangeType[i] == XmlSheet.ERangeType.Both)
				{
					return false;
				}
			}
			else if (sheet.mRangeType[i] == XmlSheet.ERangeType.Client || sheet.mRangeType[i] == XmlSheet.ERangeType.Both)
			{
				return false;
			}
		}
		return true;
	}

	private static void WriteSheet2JsonFile(XmlSheet sheet, bool isServer)
	{
		try
		{
			string jsonFileName = "./../Output/Json_" + (isServer ? "S" : "C") + "/" + sheet.mName + ".json";
			FileStream fs = new FileStream(jsonFileName, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("public static int WriteJson{0}_{1}(System.IO.StreamWriter sw){{\r\ntry{{\r\n", sheet.mName, isServer ? "S" : "C");
			sb.Append("sw.WriteLine(\"[\");\n");
			for (int r = 0; r < sheet.mValues.Count; r++)
			{
				sb.Append("sw.WriteLine(\"{\");\n");
				for (int c = 0; c < sheet.mComments.Count; c++)
				{
					if (isServer)
					{
						if (sheet.mRangeType[c] == XmlSheet.ERangeType.Client || sheet.mRangeType[c] == XmlSheet.ERangeType.None)
						{
							continue;
						}
					}
					else if (sheet.mRangeType[c] == XmlSheet.ERangeType.Server || sheet.mRangeType[c] == XmlSheet.ERangeType.None)
					{
						continue;
					}
					string curTypeStr = sheet.mTypes[c];
					if (curTypeStr.Contains("["))
					{
						int startIdx_Bracket = curTypeStr.IndexOf('[');
						int endIdx_Bracket = curTypeStr.IndexOf(']');
						string arrayTypeStr = curTypeStr.Substring(0, startIdx_Bracket);
						int arrayCount = 0;
						if (!int.TryParse(curTypeStr.Substring(startIdx_Bracket + 1, endIdx_Bracket - startIdx_Bracket - 1), out arrayCount))
						{
							throw new Exception("Array Capacity is missing at row:" + r + " col:" + c);
						}
						string[] arrayValue = sheet.mValues[r][c].Split("|".ToCharArray());
						if (arrayValue.Length != arrayCount)
						{
							throw new Exception("Data array count is not valid at row:" + r + " col:" + c);
						}
						sb.AppendFormat("sw.Write(\"\\t\\\"{0}\\\" : [\");\n", sheet.mVarNames[c]);
						for (int i = 0; i < arrayCount; i++)
						{
							if (i > 0)
							{
								sb.Append("sw.Write(\",\");\n");
							}
							if (sheet.mTypes[c].ToLower().Contains("string"))
							{
								sb.AppendFormat("sw.Write(\"\\\"{0}\\\"\");\n", ReplaceBackSlash(arrayValue[i]));
							}
							else
							{
								sb.AppendFormat("sw.Write({0});\n", arrayValue[i].ToString());
							}
						}
						sb.Append("sw.Write(\"]\");\n");
					}
					else
					{
						string tValue = sheet.mValues[r][c];
						switch (curTypeStr)
						{
						default:
							if (!(curTypeStr == "double"))
							{
								switch (curTypeStr)
								{
								case "bool":
								{
									string lowerValue = tValue.ToLower();
									if (lowerValue == "0")
									{
										lowerValue = "false";
									}
									else if (lowerValue == "1")
									{
										lowerValue = "true";
									}
									else if (lowerValue != "true" && lowerValue != "false")
									{
										lowerValue = "false";
									}
									sb.AppendFormat("sw.Write(\"\\t\\\"{0}\\\" : \");\n", sheet.mVarNames[c]);
									sb.AppendFormat("sw.Write({0});\n", lowerValue);
									break;
								}
								case "string":
									sb.AppendFormat("sw.Write(\"\\t\\\"{0}\\\" : \");\n", sheet.mVarNames[c]);
									sb.AppendFormat("sw.Write(\"\\\"{0}\\\"\");\n", ReplaceBackSlash(tValue));
									break;
								case "string reference":
									if (tValue != "")
									{
										if (!XmlSheet_Strings.sRef2IDMap.ContainsKey(tValue))
										{
											throw new Exception("Can\\\"t find string ref \\\"" + tValue + "\\\". Sheet=" + sheet.mName);
										}
										sb.AppendFormat("sw.Write(\"\\t\\\"{0}\\\" : \");\n", sheet.mVarNames[c]);
										sb.AppendFormat("sw.Write({0});\n", XmlSheet_Strings.sRef2IDMap[tValue].ToString());
									}
									else
									{
										sb.AppendFormat("sw.Write(\"\\t\\\"{0}\\\" : \");\n", sheet.mVarNames[c]);
										sb.Append("sw.Write(0);\n");
									}
									break;
								default:
									if (curTypeStr.Contains("enum"))
									{
										string[] enumArray = curTypeStr.Split(":".ToCharArray());
										if (enumArray.Length < 2)
										{
											throw new Exception("header enum type error at col " + c);
										}
										string enumTypeStr = enumArray[1];
										sb.AppendFormat("sw.Write(\"\\t\\\"{0}\\\" : \");\n", sheet.mVarNames[c]);
										sb.AppendFormat("sw.Write((ushort){0}.{1});\n", enumTypeStr, tValue);
										break;
									}
									throw new Exception("Unrecognized type of " + curTypeStr + " at row:" + r + " col:" + c);
								}
								break;
							}
							goto case "long";
						case "long":
						case "ulong":
						case "int":
						case "uint":
						case "short":
						case "ushort":
						case "byte":
						case "float":
							if (tValue == "")
							{
								tValue = "0";
							}
							sb.AppendFormat("sw.Write(\"\\t\\\"{0}\\\" : \");\n", sheet.mVarNames[c]);
							sb.AppendFormat("sw.Write({0});\n", tValue);
							break;
						}
					}
					if (!EmptyCollumsFollowed(sheet, c, isServer))
					{
						sb.Append("sw.WriteLine(\",\");\n");
					}
					else
					{
						sb.Append("sw.WriteLine(\"\");\n");
					}
				}
				sb.Append("sw.Write(\"}\");\n");
				if (r < sheet.mValues.Count - 1)
				{
					sb.Append("sw.WriteLine(\",\");\n");
				}
				else
				{
					sb.Append("sw.WriteLine(\"\");\n");
				}
			}
			sb.Append("sw.WriteLine(\"]\");\n");
			sb.Append("return 0;\r\n}catch(Exception e){Console.WriteLine(e.ToString());return 1; \r\n}\r\n}");
			string funcString = sb.ToString();
			if (mToolConfig.LogOn)
			{
				Console.WriteLine("--" + funcString);
			}
			mQueuedFunctions.Add(new FunctionBox(funcString, sw, delegate
			{
				sw.Close();
			}));
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static string ReplaceBackSlash(string input)
	{
		return input.Replace("\\", "\\\\");
	}

	private static T RunFunction<T>(string funcCode, T errorReturnValue, params object[] parameters)
	{
		RunFuncCount++;
		string[] defines = LoadDefineCSFiles();
		int idx2 = funcCode.IndexOf("(", 0);
		int idx1 = funcCode.LastIndexOf(" ", idx2);
		string funcName = funcCode.Substring(idx1 + 1, idx2 - idx1 - 1);
		string className = "TempNameClass" + RunFuncCount;
		StringBuilder sb = new StringBuilder(1048576);
		sb.AppendFormat("using System;namespace TempNameSpace{{public class {0} {{ {1} }}}}", className, funcCode);
		string code = sb.ToString();
		try
		{
			Assembly assembly = GetAssemblyFromSourceByRoslyn(code, "runFunc", defines);
			MethodInfo method = assembly.CreateInstance("TempNameSpace." + className).GetType().GetMethod(funcName);
			return (T)method.Invoke(null, parameters);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
			return errorReturnValue;
		}
	}

	private static void RunQueuedFunctions()
	{
		string[] defines = LoadDefineCSFiles();
		RunFuncCount++;
		string className = "TempNameClass" + RunFuncCount;
		List<string> functionNames = new List<string>();
		StringBuilder sb = new StringBuilder(1048576);
		sb.AppendFormat("using System;namespace TempNameSpace{{public class {0} {{ \r\n", className);
		foreach (FunctionBox funcbox in mQueuedFunctions)
		{
			int idx3 = funcbox.mFunctionCode.IndexOf("(", 0);
			int idx2 = funcbox.mFunctionCode.LastIndexOf(" ", idx3);
			string funcName = funcbox.mFunctionCode.Substring(idx2 + 1, idx3 - idx2 - 1);
			functionNames.Add(funcName);
			sb.AppendLine(funcbox.mFunctionCode);
		}
		sb.Append("}}");
		Assembly assembly = GetAssemblyFromSourceByRoslyn(sb.ToString(), "runFunc", defines);
		object classObj = assembly.CreateInstance("TempNameSpace." + className);
		for (int i = 0; i < mQueuedFunctions.Count; i++)
		{
			int idx = i;
			Task.Run(delegate
			{
				try
				{
					MethodInfo method = classObj.GetType().GetMethod(functionNames[idx]);
					object obj = method.Invoke(null, new object[1] { mQueuedFunctions[idx].mFunctionParam });
					if (mQueuedFunctions[idx].mActionOnDone != null)
					{
						mQueuedFunctions[idx].mActionOnDone(obj: true);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					if (mQueuedFunctions[idx].mActionOnDone != null)
					{
						mQueuedFunctions[idx].mActionOnDone(obj: false);
					}
				}
				finally
				{
					mQueuedFunctions[idx].mInvoked = true;
				}
			});
		}
	}

	private static Assembly GetAssemblyFromSourceByRoslyn(string source, string destAssemblyName, string[] refAssemblies, string outputFileName = "")
	{
		List<MetadataReference> references = new List<MetadataReference>();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		Assembly[] array = assemblies;
		foreach (Assembly a in array)
		{
			if (a.FullName.Contains("System."))
			{
				references.Add(MetadataReference.CreateFromFile(a.Location));
			}
		}
		if (refAssemblies != null && refAssemblies.Length != 0)
		{
			foreach (string file in refAssemblies)
			{
				references.Add(MetadataReference.CreateFromFile(file));
			}
		}
		CSharpCompilation compilation = CSharpCompilation.Create(destAssemblyName, new SyntaxTree[1] { CSharpSyntaxTree.ParseText(source) }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
		using MemoryStream memSteam = new MemoryStream();
		EmitResult emitResult = compilation.Emit(memSteam);
		if (!emitResult.Success)
		{
			IEnumerable<Diagnostic> failures = emitResult.Diagnostics.Where<Diagnostic>((Diagnostic diagnostic) => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);
			string exceptionStr = "";
			foreach (Diagnostic diagnostic2 in failures)
			{
				exceptionStr = exceptionStr + diagnostic2.Id.ToString() + " : " + diagnostic2.GetMessage() + " (" + diagnostic2?.ToString() + ")\n";
			}
			Console.Error.WriteLine(exceptionStr);
		}
		memSteam.Seek(0L, SeekOrigin.Begin);
		if (!string.IsNullOrEmpty(outputFileName))
		{
			if (File.Exists(outputFileName))
			{
				File.Delete(outputFileName);
			}
			FileStream fs = new FileStream(outputFileName, FileMode.CreateNew);
			fs.Write(memSteam.GetBuffer(),0, memSteam.GetBuffer().Length);
			fs.Close();
		}
		memSteam.Seek(0L, SeekOrigin.Begin);
		return Assembly.Load(memSteam.ToArray());
	}

	private static string[] LoadDefineCSFiles()
	{
		if (Directory.Exists(mTempDefineDir))
		{
			Directory.Delete(mTempDefineDir, recursive: true);
		}
		Directory.CreateDirectory(mTempDefineDir);
		DirectoryInfo folderInfo = new DirectoryInfo("./../Input/EnumDefines");
		if (folderInfo == null)
		{
			Console.WriteLine("Error: No folder named EnumDefines");
		}
		List<string> retValue = new List<string>();
		FileInfo[] files = folderInfo.GetFiles();
		FileInfo[] array = files;
		foreach (FileInfo file in array)
		{
			if (!(file.Extension != ".cs"))
			{
				FileStream fs = new FileStream(file.FullName, FileMode.Open);
				StreamReader sr = new StreamReader(fs);
				string src = sr.ReadToEnd();
				sr.Close();
				string dllName = mTempDefineDir + "/" + file.Name + ".dll";
				GetAssemblyFromSourceByRoslyn(src, file.Name, null, dllName);
				retValue.Add(dllName);
			}
		}
		return retValue.ToArray();
	}

	private static void WriteStaticDataFile(bool isServer)
	{
		try
		{
			string csFileName = "./../Output/Code_" + (isServer ? "S" : "C") + "/DataToolMgr.cs";
			FileStream fs = new FileStream("./../Input/TemplateFiles/DataToolMgrTemplate_" + (isServer ? "S" : "C") + ".txt", FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			string finalContent = sr.ReadToEnd();
			sr.Close();
			string strDataDefine = "";
			foreach (XmlSheet sheet2 in mSheetList)
			{
				if (strDataDefine != "")
				{
					strDataDefine += "\t\t";
				}
				strDataDefine = strDataDefine + "public Dictionary<uint, " + sheet2.mName + "Data> m" + sheet2.mName + "DataMap = new Dictionary<uint, " + sheet2.mName + "Data>(); //" + sheet2.mName + " Data\r\n";
			}
			finalContent = finalContent.Replace("{$DataDefine}", strDataDefine);
			string strDataLoad = "";
			foreach (XmlSheet sheet in mSheetList)
			{
				if (strDataLoad != "")
				{
					strDataLoad += "\t\t\t";
				}
				string funcName = sheet.mName + "DataProcess";
				strDataLoad = ((!finalContent.Contains(funcName)) ? (strDataLoad + "LoadDataBinWorker<" + sheet.mName + "Data>(\"" + sheet.mName + ".bytes\", m" + sheet.mName + "DataMap); //" + sheet.mName + " Data\r\n") : (strDataLoad + "LoadDataBinWorker<" + sheet.mName + "Data>(\"" + sheet.mName + ".bytes\", m" + sheet.mName + "DataMap, " + funcName + "); //" + sheet.mName + " Data\r\n"));
			}
			finalContent = finalContent.Replace("{$LoadData}", strDataLoad);
			FileStream wfs = new FileStream(csFileName, FileMode.Create);
			StreamWriter sWriter = new StreamWriter(wfs);
			sWriter.Write(finalContent);
			sWriter.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine("Write StaticDataMgr.cs Error");
			Console.WriteLine(e.ToString());
		}
	}

	private static void LoadConfig()
	{
		try
		{
			FileStream fs = new FileStream("ToolConfig.json", FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			string json = sr.ReadToEnd();
			sr.Close();
			mToolConfig = JsonConvert.DeserializeObject<ToolConfig>(json);
		}
		catch (Exception e)
		{
			Console.WriteLine("Read Config error: " + e.ToString());
		}
	}

	private static void WriteFaceCode()
	{
		string definePath = FolderCfg.OutputDir_Code_C_Data + "/Define.cs";
		string path = Path.GetFullPath(definePath);
		if (!File.Exists(path))
		{
			return;
		}
		string src = File.ReadAllText(definePath);
		Assembly assembly = GetAssemblyFromSourceByRoslyn(src, "enumDefine", null);
		Type objType = assembly.GetType("EPartObjType");
		Type mainType = assembly.GetType("EPartType");
		Array objTypeValues = Enum.GetValues(objType);
		Array mainTypeValues = Enum.GetValues(mainType);
		List<string> fieldList = new List<string>();
		foreach (object? objTypeItem in objTypeValues)
		{
			fieldList.Add(objTypeItem.ToString());
		}
		foreach (object? mainItem in mainTypeValues)
		{
			string itemStr = mainItem.ToString();
			if (!fieldList.Contains(itemStr))
			{
				fieldList.Add(itemStr);
			}
		}
		fieldList.Sort();
		string fullpath = Path.GetFullPath("./../Input/TemplateFiles/TemplateConfig_Template.txt");
		if (File.Exists(fullpath))
		{
			string classStr = File.ReadAllText(fullpath);
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < fieldList.Count; i++)
			{
				builder.AppendFormat("public string {0} = \"\";\r\n", fieldList[i]);
			}
			classStr = classStr.Replace("{$MemberVars}", builder.ToString());
			string configDPath = "./../../Assets/Descent/Scripts/Data/Model/";
			DirectoryInfo directoryInfo = new DirectoryInfo(configDPath);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			string configPath = configDPath + "TemplateConfig.cs";
			FileStream wfs = new FileStream(configPath, FileMode.Create);
			StreamWriter sWriter = new StreamWriter(wfs);
			sWriter.Write(classStr);
			sWriter.Close();
		}
	}
}
}