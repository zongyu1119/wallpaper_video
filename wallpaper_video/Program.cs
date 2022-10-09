using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace wallpaper_video
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
         static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
         [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
         public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReNameForm());

        }
 
    }
}
