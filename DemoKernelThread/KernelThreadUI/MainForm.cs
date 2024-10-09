using KernelThreadCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KernelThreadUI
{
    public partial class MainForm : Form
    {
        Kernel core;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            this.core = new KernelThreadCore.Kernel();
            this.core.LogMessage += this.WriteLog;
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            this.core.Dispose();
        }

        void WriteLog(string message)
        {
            if (this.richTextBoxLog.InvokeRequired)
            {
                this.richTextBoxLog.BeginInvoke(new LogMessageDelegate(WriteLog), message);
                return;
            }

            this.richTextBoxLog.Text = $"{message}\n{this.richTextBoxLog.Text}";

            // Log handle
            string[] lines = this.richTextBoxLog.Lines;
            if (lines.Length < 30)
                return;

            string[] newLines = new string[25];
            Array.Copy(lines, newLines, 25);
            this.richTextBoxLog.Lines = newLines;
        }
    }
}
