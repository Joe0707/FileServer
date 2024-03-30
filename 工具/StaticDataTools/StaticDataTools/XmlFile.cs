using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace StaticDataTool { 

public class XmlFile
{
	public void LoadXml(string filepathname, List<XmlSheet> allSheetList)
	{
		XmlDocument doc = new XmlDocument();
		doc.Load(filepathname);
		XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
		nsmgr.AddNamespace("default", "urn:schemas-microsoft-com:office:spreadsheet");
		XmlNodeList sheets = doc.SelectNodes("//default:Workbook/default:Worksheet", nsmgr);
		if (sheets.Count == 0)
		{
			throw new Exception("No sheet in the xml file:" + Path.GetFileName(filepathname));
		}
		for (int i = 0; i < sheets.Count; i++)
		{
			XmlAttribute att = sheets[i].Attributes["ss:Name"];
			if (att != null)
			{
				string sheetName = att.InnerText;
				if (sheets.Count == 1)
				{
					sheetName = Path.GetFileNameWithoutExtension(filepathname);
				}
				XmlSheet sheet = null;
				sheet = ((!(sheetName == "Strings")) ? new XmlSheet(sheetName) : new XmlSheet_Strings(sheetName));
				sheet.Load(sheets[i], nsmgr);
				allSheetList.Add(sheet);
			}
		}
	}
}
}