using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace StaticDataTool { 

public class FileDes
{
	private static byte[] sKey = new byte[8] { 33, 74, 149, 120, 160, 171, 205, 239 };

	private static byte[] sIV = new byte[8] { 18, 58, 32, 168, 156, 131, 86, 218 };

	private static CryptoStream cStream = null;

	public static void EncryptFile(string inFileName, string outFileName, bool deleteSource)
	{
		FileStream fin = new FileStream(inFileName, FileMode.Open, FileAccess.Read);
		if (File.Exists(outFileName))
		{
			File.Delete(outFileName);
		}
		FileStream fout = new FileStream(outFileName, FileMode.Create, FileAccess.Write);
		fout.SetLength(0L);
		byte[] bin = new byte[256];
		long rdlen = 0L;
		long totlen = fin.Length;
		DES des = new DESCryptoServiceProvider();
		CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(sKey, sIV), CryptoStreamMode.Write);
		int len;
		for (; rdlen < totlen; rdlen += len)
		{
			len = fin.Read(bin, 0, 256);
			encStream.Write(bin, 0, len);
		}
		encStream.Close();
		fout.Close();
		fin.Close();
		if (deleteSource)
		{
			File.Delete(inFileName);
		}
	}

	public static Stream DecryptFileToStream(string inFile)
	{
		try
		{
			FileStream fStream = File.OpenRead(inFile);
			if (cStream != null)
			{
				cStream.Close();
				cStream = null;
			}
			cStream = new CryptoStream(fStream, new DESCryptoServiceProvider().CreateDecryptor(sKey, sIV), CryptoStreamMode.Read);
			List<byte> byteList = new List<byte>();
			try
			{
				while (true)
				{
					int value = cStream.ReadByte();
					if (value == -1)
					{
						break;
					}
					byteList.Add((byte)value);
				}
			}
			catch (Exception e3)
			{
				Console.WriteLine(e3.ToString());
			}
			byte[] data = byteList.ToArray();
			MemoryStream outStream = new MemoryStream();
			outStream.Write(data, 0, data.Length);
			outStream.Seek(0L, SeekOrigin.Begin);
			return outStream;
		}
		catch (CryptographicException)
		{
			return null;
		}
		catch (UnauthorizedAccessException)
		{
			return null;
		}
	}

	public static Stream DecryptDataToStream(byte[] inData)
	{
		try
		{
			if (cStream != null)
			{
				cStream.Close();
				cStream = null;
			}
			MemoryStream inStream = new MemoryStream(inData);
			cStream = new CryptoStream(inStream, new DESCryptoServiceProvider().CreateDecryptor(sKey, sIV), CryptoStreamMode.Read);
			List<byte> byteList = new List<byte>();
			try
			{
				while (true)
				{
					int value = cStream.ReadByte();
					if (value == -1)
					{
						break;
					}
					byteList.Add((byte)value);
				}
			}
			catch (Exception e3)
			{
				Console.WriteLine(e3.ToString());
			}
			byte[] data = byteList.ToArray();
			MemoryStream outStream = new MemoryStream();
			outStream.Write(data, 0, data.Length);
			outStream.Seek(0L, SeekOrigin.Begin);
			return outStream;
		}
		catch (CryptographicException e2)
		{
			Console.WriteLine("A Cryptographic error occurred: " + e2.ToString());
			return null;
		}
		catch (UnauthorizedAccessException e)
		{
			Console.WriteLine("A file error occurred: " + e.ToString());
			return null;
		}
	}

	public static void CloseStream()
	{
		if (cStream != null)
		{
			cStream.Close();
			cStream = null;
		}
	}
}
}