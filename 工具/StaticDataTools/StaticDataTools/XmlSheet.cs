using System;
using System.Collections.Generic;
using System.Xml;

namespace StaticDataTool { 

public class XmlSheet
{
	public enum ERangeType
	{
		None,
		Server,
		Client,
		Both
	}

	protected const int HeaderRowCnt = 3;

	public string mName;

	public List<string> mComments = new List<string>();

	public List<string> mTypes = new List<string>();

	public List<string> mVarNames = new List<string>();

	public List<ERangeType> mRangeType = new List<ERangeType>();

	public List<List<string>> mValues = new List<List<string>>();

	public XmlSheet(string sheetName)
	{
		mName = sheetName;
	}

	public virtual void Load(XmlNode sheetRootNode, XmlNamespaceManager nsmgr)
	{
		bool readfinished = false;
		XmlNodeList rows = sheetRootNode.SelectNodes("default:Table/default:Row", nsmgr);
		for (int r = 0; r < rows.Count; r++)
		{
			XmlNodeList cells = rows[r].SelectNodes("default:Cell", nsmgr);
			if (cells.Count == 0)
			{
				break;
			}
			int colIdx = 0;
			for (int c = 0; c < cells.Count; c++)
			{
				XmlNode celldata = cells[c].SelectSingleNode("default:Data", nsmgr);
				switch (r)
				{
				case 0:
					ReadHeaderRow1(celldata.InnerText, c);
					continue;
				case 1:
					ReadHeaderRow2(celldata.InnerText, c);
					continue;
				case 2:
					ReadHeaderRow3(celldata.InnerText, c);
					continue;
				default:
				{
					string text = "";
					if (celldata != null)
					{
						XmlAttribute ssIdx2 = celldata.ParentNode.Attributes["ss:Index"];
						if (ssIdx2 != null && ssIdx2.Value != "")
						{
							colIdx = int.Parse(ssIdx2.Value) - 1;
						}
						text = celldata.InnerText;
					}
					else
					{
						XmlAttribute ssIdx = cells[c].Attributes["ss:Index"];
						if (ssIdx != null && ssIdx.Value != "")
						{
							colIdx = int.Parse(ssIdx.Value) - 1;
						}
					}
					if (c != 0 || !(text == ""))
					{
						ReadCellData(text, r - 3, colIdx, mComments.Count);
						colIdx++;
						continue;
					}
					break;
				}
				}
				readfinished = true;
				break;
			}
			if (readfinished)
			{
				break;
			}
		}
	}

	protected virtual void ReadHeaderRow1(string cellValue, int colIdx)
	{
		while (mComments.Count <= colIdx)
		{
			mComments.Add("");
		}
		mComments[colIdx] = cellValue;
	}

	protected virtual void ReadHeaderRow2(string cellValue, int colIdx)
	{
		string[] valueArray = cellValue.Split("|".ToCharArray());
		if (valueArray.Length != 2)
		{
			throw new Exception("row 2 col " + colIdx + " format error : " + cellValue);
		}
		if (valueArray[0] == "" || valueArray[1] == "")
		{
			throw new Exception("row 2 col " + colIdx + " format error : " + cellValue);
		}
		string typeStr = valueArray[0];
		string varNameStr = valueArray[1];
		while (mTypes.Count <= colIdx)
		{
			mTypes.Add("");
		}
		mTypes[colIdx] = typeStr;
		while (mVarNames.Count <= colIdx)
		{
			mVarNames.Add("");
		}
		mVarNames[colIdx] = varNameStr;
	}

	protected virtual void ReadHeaderRow3(string cellValue, int colIdx)
	{
		ERangeType rangeType = ERangeType.Both;
		string lStr = cellValue.ToLower();
		rangeType = (lStr.Contains("server") ? ERangeType.Server : (lStr.Contains("client") ? ERangeType.Client : ((!lStr.Contains("none")) ? ERangeType.Both : ERangeType.None)));
		while (mRangeType.Count <= colIdx)
		{
			mRangeType.Add(ERangeType.Both);
		}
		mRangeType[colIdx] = rangeType;
	}

	protected virtual void ReadCellData(string cellValue, int rowIdx, int colIdx, int maxColCnt)
	{
		while (mValues.Count <= rowIdx)
		{
			mValues.Add(new List<string>());
		}
		while (mValues[rowIdx].Count <= maxColCnt)
		{
			mValues[rowIdx].Add("");
		}
		mValues[rowIdx][colIdx] = cellValue;
	}
}
}