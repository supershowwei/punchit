using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace PunchItAgent
{
    public partial class MainForm : Form
    {
        private static readonly string HubName = "PunchHub";
        private HubConnection hubConnection = new HubConnection(Properties.Settings.Default.SignalRService);
        private IHubProxy punchHubProxy;

        public MainForm()
        {
            InitializeComponent();

            SetupWebProxy();

            this.CreateHubProxy();
        }

        private static void SetupWebProxy()
        {
            WebProxy webProxy = new WebProxy(WebRequest.DefaultWebProxy.GetProxy(new Uri(Properties.Settings.Default.SignalRService)));
            webProxy.Credentials = new NetworkCredential("g1661", "", "evertrust.com.tw");

            WebRequest.DefaultWebProxy = webProxy;
        }

        private static bool IsNeedToPunch()
        {
            // 每天8點～9點等候打卡指令。
            return
                DateTime.Now > DateTime.Now.Date.AddHours(8)
                && DateTime.Now < DateTime.Now.Date.AddHours(9);
        }

        private void CreateHubProxy()
        {
            // 連線 SignalR Hub
            this.punchHubProxy = this.hubConnection.CreateHubProxy(HubName);

            // 顯示 Hub 傳入的文字訊息
            this.punchHubProxy.On("Punch", () =>
            {
                this.Punch();
            });
        }

        private void WaitToPunch()
        {
            int tryCount = 0;

            while (tryCount < 3)
            {
                try
                {
                    // 建立連線，連線建立完成後向Hub註冊識別名稱
                    this.hubConnection.Start().Wait();

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }

                tryCount++;
                Thread.Sleep(3000);
            }
        }

        private void Punch()
        {
            if (IsNeedToPunch())
            {
                Process.Start(Properties.Settings.Default.Browser, Properties.Settings.Default.PunchURL);

                this.punchHubProxy.Invoke("Punched")
                    .ContinueWith((task) =>
                    {
                        this.hubConnection.Stop();
                    });
            }
        }

        private void PunchItNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.ShowInTaskbar = this.WindowState != FormWindowState.Minimized;
        }

        private async void TickTock_Tick(object sender, EventArgs e)
        {
            if (IsNeedToPunch())
            {
                // 在等候指令時間範圍內，而且 Idle 中，主動連線。
                if (this.hubConnection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                {
                    await Task.Run(() =>
                    {
                        this.WaitToPunch();
                    });
                }
            }
            else if (this.hubConnection.State != Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
            {
                // 不在等候指令時間範圍內，而且等候指令中，主動結束連線。
                this.hubConnection.Stop();
            }
        }
    }
}
