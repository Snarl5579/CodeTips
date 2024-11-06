using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicUserControlUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            int index = this.tableLayoutPanel.ColumnCount;

            //  Control Item
            RadioButton item = new RadioButton()
            {
                Appearance = Appearance.Button,
                AutoSize = false,
                Size = new Size(150, 200),
                Text = $"{index:00}",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightGreen
            };
            item.PreviewKeyDown += RadioButton1PreviewKeyDown;

            //  TableLayoutPant
            this.tableLayoutPanel.ColumnCount++;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.tableLayoutPanel.Controls.Add(item, index, 0);
        }

        private void RadioButton1PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            this.tableLayoutPanel.Controls.Remove(sender as RadioButton);
        }
    }
}
