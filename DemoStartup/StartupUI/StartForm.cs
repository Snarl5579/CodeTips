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
    public partial class StartForm : Form
    {
        public UserInterfaceDelegate InitializeMessage;

        public StartForm()
        {
            InitializeComponent();
        }

        public void ViewUpdate(UserInterfaceMessageType type, string[] data)
        {
            if (type == UserInterfaceMessageType.InitializeFinshed)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new UserInterfaceDelegate(ViewUpdate), type, data);
                    return;
                }

                this.Close();
                this.InitializeMessage?.Invoke(
                    UserInterfaceMessageType.InitializeFinshed, new string[] { "" });
            }


            if (type != UserInterfaceMessageType.InitializeMessage) return;
            if (data == null) return;
            if (data.Length == 0) return;

            if (this.labelInformation.InvokeRequired)
            {
                this.labelInformation.BeginInvoke(new UserInterfaceDelegate(ViewUpdate), type, data);
                return;
            }

            this.labelInformation.Text = data[0];
        }
    }
}
