using System;

namespace MsgDefineTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //读配置文件
            MsgMaker.ReadConfig();
            //读文件
            MsgMaker.ReadCS();
            //转换
            MsgMaker.WriteTS();
            //拷贝到目标路径
            MsgMaker.CopyToDestDirectory();
            Console.WriteLine("转换完成");
        }
    }
}
