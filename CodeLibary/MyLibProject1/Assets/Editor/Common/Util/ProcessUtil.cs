using System.Diagnostics;
using System;
using System.Collections.Generic;
using UnityEngine;
public class ProcessUtil
{

    public static string RunCmd(List<string> cmds, bool isWaitForExit = true, System.Action callback = null)
    {
        try
        {
            //string strInput = Console.ReadLine();
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            // //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            // p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            //启用Exited事件
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler((sender, e) =>
            {
                UnityEngine.Debug.Log("命令执行完毕");
                Process pro = sender as Process;
                pro.Close();
                pro.Dispose();
                if (callback != null)
                {
                    callback();
                }
            });

            //启动程序
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.StandardInput.AutoFlush = true;
            //输入命令
            for (var i = 0; i < cmds.Count; i++)
            {
                p.StandardInput.WriteLine(cmds[i]);
            }
            p.StandardInput.WriteLine("exit");
            if (isWaitForExit)
            {
                p.WaitForExit();
            }
            return string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (e.Data != null)
        {
            UnityEngine.Debug.Log(e.Data);
        }
    }

    static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (e.Data != null)
        {
            UnityEngine.Debug.LogError(e.Data);
        }
    }

    static void Process_Exited(object sender, EventArgs e)
    {
        UnityEngine.Debug.Log("命令执行完毕");
        Process p = sender as Process;
        p.Close();
        p.Dispose();
    }
}