using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockScissorsGame
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
        //Getting properties of the window
        //static Form1 LaunchApp(string path, string formName)
        //{
        //    Form1 result = null;
        //    Assembly a = Assembly.LoadFrom(path);
        //    Type t1 = a.GetType(formName);
        //    result = (Form1)a.CreateInstance(t1.FullName);

        //    AppState aps = new AppState(result);
        //    ThreadStart ts = new ThreadStart(aps.RunApp);
        //    Thread thread = new Thread(ts);
        //    thread.ApartmentState = ApartmentState.STA;
        //    thread.IsBackground = true;
        //    thread.Start();
        //    return result;

        //}
        //static void Main(string[] args)
        //{

        //    try
        //    {
        //        Console.WriteLine("Launching Form");

        //        string formName = "RockScissorsGame.Form1";
        //        string path = "..\\..\\..\\RockScissorsGame\\bin\\debug\\RockScissorsGame.exe";
        //        Form1 theForm1 = LaunchApp(path, formName);

        //        // ReSharper disable once LocalizableElement
        //        Console.WriteLine("Changing name of Form");
        //        SetFormPropertyValue(theForm1, "Text", "Hahaaha");
        //        Thread.Sleep(1500);

        //        Console.WriteLine("\nSetting form location to x = 10, y=20");
        //        System.Drawing.Point pt = new Point(10, 20);
        //        SetFormPropertyValue(theForm1, "Location", pt);
        //        Thread.Sleep(1500);

        //        Size size = new Size(600, 500);
        //        Console.WriteLine("\n And now setting form size to {0} x {1}", size.Width, size.Height);
        //        SetFormPropertyValue(theForm1, "Size", size);
        //        Thread.Sleep(1500);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Fatal error:" + e.Message);

        //    }
        //}//Main

        //delegate void SetFormPropertyValueHandler(Form1 f, string propertyName, object newValue);
        //static void SetFormPropertyValue(Form1 f, string propName, object newValue)
        //{

        //    if (f.InvokeRequired)
        //    {

        //        Delegate d = new SetFormPropertyValueHandler(SetFormPropertyValue);
        //        object[] o = new object[] { f, propName, newValue };
        //        f.Invoke(d, o);
        //        return;

        //    }
        //    else
        //    {
        //        Type t = f.GetType();
        //        PropertyInfo pi = t.GetProperty(propName);
        //        if (pi != null) pi.SetValue(f, newValue, null);
        //    }

        //}
        //private class AppState
        //{
        //    private readonly Form1 formToRun;

        //    public AppState(Form1 f)
        //    {
        //        this.formToRun = f;

        //    }

        //    public void RunApp()
        //    {
        //        Application.Run(formToRun);
        //    }
        //}//class AppState
    }//class Program
}
