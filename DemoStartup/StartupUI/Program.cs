using StartupCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupUI
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();

            StartForm startForm = new StartForm();
            startForm.InitializeMessage += mainForm.Startup;

            Kernel core = new Kernel();
            core.InitializeMessage += startForm.ViewUpdate;


            startForm.Show();
            core.Initialize();

            Application.Run();

            core.Dispose();
        }
    }
}
