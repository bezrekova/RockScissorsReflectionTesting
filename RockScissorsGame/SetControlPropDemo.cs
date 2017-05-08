using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockScissorsGame;

namespace RockScissorsGame
{
    static class SetControlPropDemo
    {
        private static BindingFlags flags = BindingFlags.Public |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Static |
                                            BindingFlags.Instance;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
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

        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Launching Form");

                var formName = "RockScissorsGame.Form1";
                var path = "..\\..\\..\\RockScissorsGame\\bin\\debug\\RockScissorsGame.exe";
                var theForm1 = LaunchApp(path, formName);

               
                SetControlPropertyValue(theForm1, "textBox1", "Text", "paper");
                Thread.Sleep(1500);
                SetControlPropertyValue(theForm1, "comboBox1", "Text", "rock");
                Thread.Sleep(1500);

                //press button
                var parms = new object[] { null, EventArgs.Empty };
                InvokeMethod(theForm1, "button1_Click", parms);
                Thread.Sleep(1500);

                //click menu item "New"
              //  InvokeMethod(theForm1, "newToolStripMenuItem_Click", parms);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Fatal error:" + e.Message);
            }
        } //Main

        //private static  TForm1 getForm<TForm1>()//get active form
        //    where TForm1 : Form1
        //{
        //    return (TForm1)Application.OpenForms.OfType<TForm1>().FirstOrDefault();
        //}
        //private static void CloseApp()//close form
        //{
        //    Form1 f = getForm<Form1>();
        //    f.Close();

        //    //Application.Exit();
        //}

        private delegate void SetControlPropertyValueHandler(Form1 f, string controlName,
            string propertyName, object newValue
        );

        private static void SetControlPropertyValue(Form1 f, string controlName,
            string propertyName, object newValue)
        {
            if (f.InvokeRequired)
            {
                Delegate d = new SetControlPropertyValueHandler(SetControlPropertyValue);
                var o = new object[] { f, controlName, propertyName, newValue };
                f.Invoke(d, o);
            }
            else
            {
                var t1 = f.GetType();
                var fi = t1.GetField(controlName, flags);
                var ctrl = fi.GetValue(f);
                var t2 = ctrl.GetType();
                var pi = t2.GetProperty(propertyName);
                if (pi != null) pi.SetValue(ctrl, newValue, null);
            }
        }

        private static AutoResetEvent are = new AutoResetEvent(false);

        private delegate void InvokeMethodHandler(Form f, string methodName, params object[] parms);

        private static void InvokeMethod(Form f, string methodName, params object[] parms)
        {
            if (f.InvokeRequired)
            {
                Delegate d = new InvokeMethodHandler(InvokeMethod);
                f.Invoke(d, new object[] { f, methodName, parms });
                are.WaitOne();//=>go to else block after form was invoked
            }
            else
            {
                var t = f.GetType();
                var mi = t.GetMethod(methodName, flags);
                mi.Invoke(f, parms);
                are.Set();//button1 is ready to procceding
            }
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
    } //class SetControlPropDemo
} //ns



