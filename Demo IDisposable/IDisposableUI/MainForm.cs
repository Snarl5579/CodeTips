using IDisposableCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDisposableUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void DemoClick(object sender, EventArgs e)
        {
            this.LogMessage($">>");
            this.LogMessage($"Start to Demo, memory usage: {GC.GetTotalMemory(true)}");

            Kernel kernel = new Kernel();
            this.LogMessage($"Construct kernel, memory usage: {GC.GetTotalMemory(true)}");

            kernel.Dispose();
            this.LogMessage($"Dispose kernel, memory usage: {GC.GetTotalMemory(true)}");
        }

        void LogMessage(string message)
        {
            string[] lines = this.richTextBoxLog.Lines;

            this.richTextBoxLog.Text = $"{DateTime.Now:yyyyMMdd HH:mm:ss:ffff} - {message}\n" + this.richTextBoxLog.Text;

            if (lines.Length < 50)
                return;

            string[] newLines = new string[20];
            Array.Copy(lines, newLines, newLines.Length);
            this.richTextBoxLog.Lines = newLines;
        }
    }
}
