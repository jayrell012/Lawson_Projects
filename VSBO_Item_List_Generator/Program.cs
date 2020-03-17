using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSBO_Item_List_Generator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}

        static Mutex m;
        [STAThread]


        static void Main()
        {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new login());

            bool open = false;
            m = new Mutex(true, Application.ProductName.ToString(), out open);

            if (open)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                m.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Another instance of this application is running", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
