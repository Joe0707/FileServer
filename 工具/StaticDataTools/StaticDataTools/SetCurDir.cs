using System.IO;

namespace StaticDataTool { 

public class SetCurDir
{
	public static void Set()
	{
		dynamic type = new SetCurDir().GetType();
		string currentDirectory = Path.GetDirectoryName(type.Assembly.Location);
		Directory.SetCurrentDirectory(currentDirectory);
	}
}
}