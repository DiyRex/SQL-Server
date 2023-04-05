using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void execute(int status)

        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"'/C cd mariadb/mariadb10.6.5/bin/ && mysqld.exe";
            process.StartInfo = startInfo;

            if (status == 1)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "ONLINE";
                process.Start();
            }
            else
            {
                try
                {
                    foreach (var p in Process.GetProcessesByName("mysqld"))
                    {
                        p.Kill();
                    }
                    process.Kill();
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "OFFLINE";

                }
                catch (Exception)
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "OFFLINE";
                    //MessageBox.Show($"Process Exited");
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            execute(1);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            execute(0);
        }
    }
}
