using System;
using System.Collections.Generic;
using System.Xml;

namespace StaticDataTool { 

public class XmlSheet_Strings : XmlSheet
{
	private int mLanguageCnt = 0;

	public static Dictionary<string, uint> sRef2IDMap = new Dictionary<string, uint>();

	public XmlSheet_Strings(string sheetName)
		: base(sheetName)
	{
	}

	public override void Load(XmlNode sheetRootNode, XmlNamespaceManager nsmgr)
	{
		base.Load(sheetRootNode, nsmgr);
	}

	protected override void ReadHeaderRow1(string cellValue, int colIdx)
	{
		while (mComments.Count < 3)
		{
			mComments.Add("");
		}
		if (colIdx == 0 || colIdx == 1)
		{
			mComments[colIdx] = cellValue;
			return;
		}
		if (colIdx == 2)
		{
			mComments[2] = "StringTable";
		}
		mLanguageCnt++;
	}

	protected override void ReadHeaderRow2(string cellValue, int colIdx)
	{
		if (colIdx > 2)
		{
			return;
		}
		while (mTypes.Count < 3)
		{
			mTypes.Add("");
		}
		while (mVarNames.Count < 3)
		{
			mVarNames.Add("");
		}
		if (colIdx < 2)
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
			mTypes[colIdx] = typeStr;
			mVarNames[colIdx] = varNameStr;
		}
		else
		{
			mTypes[2] = "string[" + mLanguageCnt + "]";
			mVarNames[2] = "mStrings";
		}
	}

	protected override void ReadHeaderRow3(string cellValue, int colIdx)
	{
		if (colIdx <= 2)
		{
			while (mRangeType.Count < 3)
			{
				mRangeType.Add(ERangeType.Client);
			}
			mRangeType[0] = ERangeType.Both;
		}
	}

	protected override void ReadCellData(string cellValue, int rowIdx, int colIdx, int maxColCnt)
	{
		while (mValues.Count <= rowIdx)
		{
			mValues.Add(new List<string>());
		}
		while (mValues[rowIdx].Count < 3)
		{
			mValues[rowIdx].Add("");
		}
		if (colIdx < 2)
		{
			mValues[rowIdx][colIdx] = cellValue;
			if (colIdx == 1)
			{
				sRef2IDMap.Add(cellValue, uint.Parse(mValues[rowIdx][0]));
			}
		}
		else if (mValues[rowIdx][2] == "")
		{
			mValues[rowIdx][2] += cellValue;
		}
		else
		{
			List<string> list = mValues[rowIdx];
			list[2] = list[2] + "|" + cellValue;
		}
	}
}
}