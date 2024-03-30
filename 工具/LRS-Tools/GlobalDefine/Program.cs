using System;

namespace GlobalDefine
{
    class Program
    {
        static void Main(string[] args)
        {
            //设定当前目录
            System.IO.Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            //读配置文件
            GlobalDefineMaker.ReadConfig();
            for(int i = 0; i < GlobalDefineMaker.mConfig.InputJSFile.Count; i++) {
                //读文件
                GlobalDefineMaker.ReadJS(i);
                //转换
                GlobalDefineMaker.WriteCS(i);
                //拷贝到目标路径
                GlobalDefineMaker.CopyToDestDirectory(i);
            }
            Console.WriteLine("转换完成");
        }
    }
}
