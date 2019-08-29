using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using LD_ProtectApp.Utils;
using LD_ProtectApp.Functions;
using LD_ProtectApp.Models;
using System.IO;

namespace LD_ProtectApp
{
    public partial class frmProtect : Form
    {
        List<Applications> applicationInfos = new List<Applications>();
        public frmProtect()
        {
            InitializeComponent();
            //获取xml模板路径
            string path = Environment.CurrentDirectory + @"\ProcessInfo.xml";
            if (!File.Exists(path))
            {
                MessageBox.Show($"ProcessInfo.xml模板文件不存在,开始进程守护程序失败，请检查配置文件模板！", "络町软件");
                Environment.Exit(0);
            }
            //将模板转化成应用程序实例集合
            applicationInfos = XmlHelper.XmlToModel<Applications>(path);
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.Visible = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            InitUI();
        }

        #region 界面管理
        /// <summary>
        /// 判断是否最小化,然后显示托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                Icon.Visible = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Icon.Visible = false;
            this.Dispose();
            Environment.Exit(0);
        }
        #endregion

        /// <summary>
        /// 开启守护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartProtect_Click(object sender, EventArgs e)
        {
            int cycleTime = 0;
            if (applicationInfos.Count > 0)
            {
                cycleTime = int.Parse(applicationInfos[0].Cycle);
                foreach (var applicationInfo in applicationInfos)
                {
                    if (!File.Exists($@"{applicationInfo.Path}\{applicationInfo.Name}.exe"))
                    {
                        MessageBox.Show($"程序{applicationInfo.Name}.exe 不存在,开始守护进程失败，请检查配置文件模板！"
                            ,"络町软件");
                        return;
                    }
                }
            }
            QuartzManager.AddJob<AutoRestart>("AutoRestart", cycleTime == 0 ? 10000 : cycleTime);
            btnStartProtect.Enabled = false;
        }

        /// <summary>
        /// 初始化定时任务管理界面
        /// </summary>
        private void InitUI()
        {
            lvAppInfo.Clear();


            lvAppInfo.Columns.Add(new ColumnHeader() { Text = "程序名称",Width = 100,TextAlign = HorizontalAlignment.Center});
            lvAppInfo.Columns.Add(new ColumnHeader() { Text = "启动路径", Width = 300, TextAlign = HorizontalAlignment.Center });
            lvAppInfo.Columns.Add(new ColumnHeader() { Text = "启动参数", Width = 100, TextAlign = HorizontalAlignment.Center });
            lvAppInfo.Columns.Add(new ColumnHeader() { Text = "轮询时间", Width = 100, TextAlign = HorizontalAlignment.Center });
            //设置属性
            lvAppInfo.GridLines = true;  //显示网格线
            lvAppInfo.FullRowSelect = true;  //显示全行
            lvAppInfo.MultiSelect = false;  //设置只能单选
            lvAppInfo.View = View.Details;  //设置显示模式为详细
            lvAppInfo.HoverSelection = true;  //当鼠标停留数秒后自动选择
            try
            {
                this.lvAppInfo.BeginUpdate();
                foreach (var applicationInfo in applicationInfos)
                {
                    ListViewItem LVItem = new ListViewItem();
                    LVItem.Text = applicationInfo.Name;
                    LVItem.SubItems.Add(applicationInfo.Path);
                    LVItem.SubItems.Add(applicationInfo.StartArgs);
                    LVItem.SubItems.Add(applicationInfo.Cycle);

                    this.lvAppInfo.Items.Add(LVItem);
                }
                this.lvAppInfo.EndUpdate();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "络町软件");
            }
        }
    }
}
