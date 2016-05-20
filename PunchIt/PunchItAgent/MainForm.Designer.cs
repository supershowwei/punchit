namespace PunchItAgent
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PunchItNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TickTock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PunchItNotifyIcon
            // 
            this.PunchItNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("PunchItNotifyIcon.Icon")));
            this.PunchItNotifyIcon.Text = "Punch It !";
            this.PunchItNotifyIcon.Visible = true;
            this.PunchItNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PunchItNotifyIcon_MouseDoubleClick);
            // 
            // TickTock
            // 
            this.TickTock.Enabled = true;
            this.TickTock.Interval = 60000;
            this.TickTock.Tick += new System.EventHandler(this.TickTock_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 154);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Punch It !";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon PunchItNotifyIcon;
        private System.Windows.Forms.Timer TickTock;
    }
}

