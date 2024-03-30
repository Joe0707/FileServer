using System.IO;

namespace StaticData { 

public abstract class BaseDataObject
{
	public uint mID = 0u;

	public abstract void ReadFromStream(BinaryReader br);
}
}