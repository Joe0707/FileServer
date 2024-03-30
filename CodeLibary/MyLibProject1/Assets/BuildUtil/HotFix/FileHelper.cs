using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO.Compression;
namespace System.IO
{
    static public class FileHelper
    {
        private static byte mKey = 0x0f; //密钥
        //拷贝文件夹
        public static void CopyDirectory(string sourceFolder, string targetFolder)
        {
            try
            {
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string pFilePath = targetFolder + "\\" + Path.GetFileName(file);
                    if (File.Exists(pFilePath))
                        continue;
                    File.Copy(file, pFilePath, true);
                }

                string[] dirs = Directory.GetDirectories(sourceFolder);
                foreach (string dir in dirs)
                {
                    CopyDirectory(dir, targetFolder + "\\" + Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 检测路径是否存在
        /// </summary>
        /// <param name="path"></param>
        static private void CheckDirectory(string path)
        {
            var direct = Path.GetDirectoryName(path);
            if (!Directory.Exists(direct))
            {
                Directory.CreateDirectory(direct);
            }


        }
        /// <summary>
        ///  写入所有字节码
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        static public void WriteAllBytes(string path, byte[] bytes)
        {
            CheckDirectory(path);
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// 写入所有字符串
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        static public void WriteAllText(string path, string contents)
        {
            CheckDirectory(path);
            File.WriteAllText(path, contents);
        }

        /// <summary>
        /// 写入所有行
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        static public void WriteAllLines(string path, string[] contents)
        {
            CheckDirectory(path);
            File.WriteAllLines(path, contents);
        }

        /// <summary>
        /// 获取文件的md5
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetHashFromFile(string fileName)
        {
            string hash = "null";
            if (File.Exists(fileName))
            {
                var bytes = File.ReadAllBytes(fileName);
                // //这里为了防止碰撞 考虑Sha256 512 但是速度会更慢
                // var sha1 = SHA1.Create();
                // byte[] retVal = sha1.ComputeHash(bytes.ToArray());
                //获取加密服务  
                System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
                //计算hash值  
                byte[] retVal = md5CSP.ComputeHash(bytes.ToArray());

                //hash
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                hash = sb.ToString();
            }

            return hash;
        }

        //----------------------------------------------------------------------
        /*						加密逻辑
            根据文件的ab包名进行计算偏移值,对文件字节进行偏移,0-偏移值之间的内容填入随机数
        */
        //----------------------------------------------------------------------

        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="file">文件名</param>
        /// <param name="key">密钥</param>
        public static void EncryptFile(string file, string key, string outfile = null)
        {
            var filebytes = File.ReadAllBytes(file);
            var offset = (int)GetEncryptionOffset(key);
            var newfilebytes = new byte[filebytes.Length + offset];
            filebytes.CopyTo(newfilebytes, offset);
            for (int i = 0; i < offset; i++)
            {
                newfilebytes[i] = (byte)UnityEngine.Random.Range(byte.MinValue, byte.MaxValue);
            }
            outfile = (outfile == null) ? file : outfile;
            FileStream fs = File.OpenWrite(outfile);
            fs.Write(newfilebytes, 0, filebytes.Length + offset);
            fs.Close();
        }

        //获取加密偏移值 通过对传入参数转字符集求合再和密钥进行求与运算,如果值为0则和密钥进行求和运算
        public static ulong GetEncryptionOffset(string key)
        {
            var chars = key.ToCharArray();
            ulong result = 0;
            for (var i = 0; i < chars.Length; i++)
            {
                result += chars[i];
            }
            result = result & mKey;
            if (result == 0)
            {
                result += mKey;
            }
            return result;
        }
        //文件解密
        public static void DecryptFile(string file, string key, string outfile = null)
        {
            var filebytes = File.ReadAllBytes(file);
            var offset = (int)GetEncryptionOffset(key);
            var newfilebytes = new byte[filebytes.Length - offset];
            System.Array.Copy(filebytes, offset, newfilebytes, 0, filebytes.Length - offset);
            outfile = (outfile == null) ? file : outfile;
            FileStream fs = File.OpenWrite(outfile);
            fs.Write(newfilebytes, 0, newfilebytes.Length);
            fs.Close();
        }
        //文件解密
        public static byte[] DecryptFile(string file, string key)
        {
            var filebytes = File.ReadAllBytes(file);
            var offset = (int)GetEncryptionOffset(key);
            var newfilebytes = new byte[filebytes.Length - offset];
            System.Array.Copy(filebytes, offset, newfilebytes, 0, filebytes.Length - offset);
            return newfilebytes;
        }
        //-------------------------------------压缩-----------------------
        // 压缩文件夹
        public static void CompressFolder(string sourcefolderName, string compressedFilePath, bool includeBaseDirectory = true)
        {
            if (Directory.Exists(sourcefolderName) == false) throw new FileNotFoundException("未找到文件夹", sourcefolderName);
            if (File.Exists(compressedFilePath) == true) File.Delete(compressedFilePath);
            ZipFile.CreateFromDirectory(sourcefolderName, compressedFilePath, CompressionLevel.Fastest, includeBaseDirectory);
        }
    }
}