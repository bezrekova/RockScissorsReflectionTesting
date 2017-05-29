using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsBasedColorMixer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       private static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            try
            {

                Console.WriteLine("\nStarting test scenario");
                Console.WriteLine("Launching Form");

                var formName = "WindowsBasedColorMixer.Form1";
                var path = "..\\..\\..\\WindowsBasedColorMixer\\bin\\debug\\WindowsBasedColorMixer.exe";
                var theForm1 = LaunchApp(path, formName);
                Thread.Sleep(3000);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
            }
        }//Main

        private static Form1 LaunchApp(string path, string formName)
        {
            Form1 result = null;
            var a = Assembly.LoadFrom(path);
            var t1 = a.GetType(formName);
            result = (Form1)a.CreateInstance(t1.FullName);

            var aps = new AppState(result);
            var ts = new ThreadStart(aps.RunApp);
            var thread = new Thread(ts);
            thread.ApartmentState = ApartmentState.STA;
            thread.IsBackground = true;
            thread.Start();
            return result;
        }

        private class AppState
        {
            private readonly Form1 _formToRun;

            public AppState(Form1 f)
            {
                _formToRun = f;
            }

            public void RunApp()
            {
                Application.Run(_formToRun);
            }
        } //class AppState
    }
}

