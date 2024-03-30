using System;

namespace StaticDataTool
{

	public class FunctionBox
	{
		public string mFunctionCode = "";

		public object mFunctionParam = null;

		public Action<bool> mActionOnDone = null;

		public bool mInvoked = false;

		public FunctionBox(string code, object objParam, Action<bool> actionOnDone)
		{
			mFunctionCode = code;
			mFunctionParam = objParam;
			mActionOnDone = actionOnDone;
			mInvoked = false;
		}
	}
}