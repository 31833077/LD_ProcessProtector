using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LD_ProtectApp.Utils;
using Quartz;
using System.Configuration;
using LD_ProtectApp.Models;

namespace LD_ProtectApp.Functions
{
    /// <summary>
    /// 重启进程
    /// </summary>
    public class AutoRestart : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Task cycleTask = new Task(CheckAndRestartProcess);
            cycleTask.Start();
            return cycleTask;
        }

        /// <summary>
        /// 检查并重启模板中的所有应用程序
        /// </summary>
        private void CheckAndRestartProcess()
        {
            //获取xml模板路径
            string path = Environment.CurrentDirectory + @"\ProcessInfo.xml";
            //将模板转化成应用程序实例集合
            var applicationInfos = XmlHelper.XmlToModel<Applications>(path);

            //遍历集合，检查并重启程序
            foreach (var applicationInfo in applicationInfos)
            {
                if (Process.GetProcessesByName(applicationInfo.Name).ToList().Count == 0)
                {
                    Process fireProcess = new Process();
                    try
                    {
                        fireProcess.StartInfo.Arguments = applicationInfo.StartArgs;
                        fireProcess.StartInfo.UseShellExecute = true;
                        fireProcess.StartInfo.CreateNoWindow = false;
                        fireProcess.StartInfo.WorkingDirectory = applicationInfo.Path;
                        fireProcess.StartInfo.FileName = $"{applicationInfo.Name}.exe";
                        fireProcess.Start();
                    }
                    catch (Exception error)
                    {
                        Log.WriteLog(error.Message + "__" + DateTime.Now);
                    }
                    finally
                    {
                        fireProcess.Dispose();
                    }
                }
            }
        }
    }
}
