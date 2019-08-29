namespace LD_ProtectApp
{
    partial class frmProtect
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProtect));
            this.Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartProtect = new System.Windows.Forms.Button();
            this.lvAppInfo = new System.Windows.Forms.ListView();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // Icon
            // 
            this.Icon.ContextMenuStrip = this.CMS;
            this.Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("Icon.Icon")));
            this.Icon.Text = "守护程序";
            this.Icon.Visible = true;
            // 
            // CMS
            // 
            this.CMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(109, 28);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // btnStartProtect
            // 
            this.btnStartProtect.Location = new System.Drawing.Point(280, 408);
            this.btnStartProtect.Name = "btnStartProtect";
            this.btnStartProtect.Size = new System.Drawing.Size(108, 39);
            this.btnStartProtect.TabIndex = 1;
            this.btnStartProtect.Text = "开启守护";
            this.btnStartProtect.UseVisualStyleBackColor = true;
            this.btnStartProtect.Click += new System.EventHandler(this.BtnStartProtect_Click);
            // 
            // lvAppInfo
            // 
            this.lvAppInfo.HideSelection = false;
            this.lvAppInfo.Location = new System.Drawing.Point(12, 12);
            this.lvAppInfo.Name = "lvAppInfo";
            this.lvAppInfo.Size = new System.Drawing.Size(669, 369);
            this.lvAppInfo.TabIndex = 2;
            this.lvAppInfo.UseCompatibleStateImageBehavior = false;
            // 
            // frmProtect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 475);
            this.Controls.Add(this.lvAppInfo);
            this.Controls.Add(this.btnStartProtect);
            this.Name = "frmProtect";
            this.ShowInTaskbar = false;
            this.Text = "进程守护者";
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private new System.Windows.Forms.NotifyIcon Icon;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button btnStartProtect;
        private System.Windows.Forms.ListView lvAppInfo;
    }
}

