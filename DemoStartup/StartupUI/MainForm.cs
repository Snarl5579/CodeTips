using StartupCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void Startup(UserInterfaceMessageType type, string[] data)
        {
            if (type == UserInterfaceMessageType.InitializeFinshed)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new UserInterfaceDelegate(Startup), type, data);
                    return;
                }

                this.Show();
            }
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
