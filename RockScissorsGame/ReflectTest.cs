using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace RockScissorsGame
{
    public class ReflectTest
    {
        private static BindingFlags flags = BindingFlags.Public |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Static |
                                            BindingFlags.Instance;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nStarting test scenario");
                Console.WriteLine("Launching Form");

                var formName = "RockScissorsGame.Form1";
                var path = "..\\..\\..\\RockScissorsGame\\bin\\debug\\RockScissorsGame.exe";
                var theForm1 = LaunchApp(path, formName);

                //1. Moving form
                Console.WriteLine("\nMoving form");
                var pt = new Point(330, 120);
                SetFormPropertyValue(theForm1, "Location", pt);

                //2. Setting controls' values
                Console.WriteLine("\nSetting textBox1 to 'rock'");
                SetControlPropertyValue(theForm1, "textBox1", "Text", "rock");
                Console.WriteLine("Setting comboBox1 to 'scissors'");
                SetControlPropertyValue(theForm1, "comboBox1", "Text", "scissors");

                /*3.Methods operations
                 * 1)button1_Click
                 * 2)File->Exit*/
                Console.WriteLine("\nClicking button1");
                var parms = new object[] { null, EventArgs.Empty };
                InvokeMethod(theForm1, "button1_Click", parms);

                var pass = true;

                Console.WriteLine("\nChecking listBox1 for 'textBox wins'");

                Thread.Sleep(2000);
                var oc =
                    (ListBox.ObjectCollection)GetControlPropertyValue(theForm1, "listBox1",
                    "Items");
                var s = oc[0].ToString();
                if (s.IndexOf("textbox wins") == -1)
                    pass = false;
                if (pass)
                    Console.WriteLine("\n--Scenario result = Pass--");
                else
                    Console.WriteLine("\n--Scenario result = *FAIL*");
                Console.WriteLine("\nClicking File->Exit in 3 seconds");
                Thread.Sleep(3000);
                Console.WriteLine("\nEnd test scenario");
            }
            catch (Exception e)
            {
                Console.WriteLine("Fatal error:" + e.Message);
            }
        } //Main

        private delegate object GetControlPropertyValueHandler(Form1 f, string controlName,
            string propertyName
        );

        private static object GetControlPropertyValue(Form1 f, string controlName,
            string propertyName)
        {
            if (f.InvokeRequired)
            {
                object[] o = { f, controlName, propertyName };
                Delegate d = new GetControlPropertyValueHandler(GetControlPropertyValue);
                var ires = f.Invoke(d, o);
                return ires;
            }
            else
            {
                var t = f.GetType();
                var fi = t.GetField(controlName, flags);

                var ctrl = fi.GetValue(f);
                var t2 = ctrl.GetType();
                var pi = t2.GetProperty(propertyName);
                var result = pi.GetValue(ctrl, null);
                return result;

            }

        }
        private static AutoResetEvent are = new AutoResetEvent(false);

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

        private delegate void SetFormPropertyValueHandler(Form1 f, string propertyName, object newValue);

        private static void SetFormPropertyValue(Form1 f, string propName, object newValue)
        {

            if (f.InvokeRequired)
            {

                Delegate d = new SetFormPropertyValueHandler(SetFormPropertyValue);
                var o = new object[] { f, propName, newValue };
                f.Invoke(d, o);
                return;

            }
            else
            {
                var t = f.GetType();
                var pi = t.GetProperty(propName);
                if (pi != null) pi.SetValue(f, newValue, null);
            }

        }

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
