using RecipeCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void WriteClick(object sender, EventArgs e)
        {
            ConfigExample example = new ConfigExample();

            example.intExample = 86;
            example.doubleExample = 5.78;
            example.stringExample = "HelloWorld";
            example.listExample.Add(3);
            example.listExample.Add(1);
            example.listExample.Add(2);
            example.listExample.Add(5);

            example.Write("ExampleRecipe.json");

            FileInfo file = new FileInfo("ExampleRecipe.json");
            this.LogClear();
            this.LogWrite($"Write Config");
            this.LogWrite($"========================================");
            this.LogWrite($"File Path: {file.FullName}");
            this.LogWrite($"Config Data:");
            this.LogWrite($"  int:{example.intExample}");
            this.LogWrite($"  double:{example.doubleExample}");
            this.LogWrite($"  string:{example.stringExample}");
            this.LogWrite($"  List:");
            this.LogWrite($"    0:{example.listExample[0]}");
            this.LogWrite($"    1:{example.listExample[1]}");
            this.LogWrite($"    2:{example.listExample[2]}");
            this.LogWrite($"    3:{example.listExample[3]}");
        }

        private void ReadClick(object sender, EventArgs e)
        {
            ConfigExample example = new ConfigExample();

            example.Read("ExampleRecipe.json");

            FileInfo file = new FileInfo("ExampleRecipe.json");
            this.LogClear();
            this.LogWrite($"Read Config");
            this.LogWrite($"========================================");
            this.LogWrite($"File Path: {file.FullName}");
            this.LogWrite($"Config Data:");
            this.LogWrite($"  int:{example.intExample}");
            this.LogWrite($"  double:{example.doubleExample}");
            this.LogWrite($"  string:{example.stringExample}");
            this.LogWrite($"  List:");
            for(int count = 0; count < example.listExample.Count; count++)
            {
                this.LogWrite($"    {count}:{example.listExample[count]}");
            }
        }

        void LogClear()
        {
            this.richTextBoxLog.Text = "";        }

        void LogWrite(string message)
        {
            this.richTextBoxLog.Text += $"{message}\n";
        }
    }
}
