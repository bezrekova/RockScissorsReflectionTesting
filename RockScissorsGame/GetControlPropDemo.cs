//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using RockScissorsGame;

//namespace RockScissorsGame
//{
//    static class GetControlPropDemo
//    {
//        private static BindingFlags flags = BindingFlags.Public |
//                                            BindingFlags.NonPublic |
//                                            BindingFlags.Static |
//                                            BindingFlags.Instance;

//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main(string[] args)
//        {
//            try
//            {
//                Console.WriteLine("Launching Form");

//                string formName = "RockScissorsGame.Form1";
//                string path = "..\\..\\..\\RockScissorsGame\\bin\\debug\\RockScissorsGame.exe";
//                Form1 theForm1 = LaunchApp(path, formName);

//                Thread.Sleep(4000);
//                string txt = (string)GetControlPropertyValue(theForm1, "textBox1", "Text");
//                Console.WriteLine("TextBox1 holds " + txt);

//                Thread.Sleep(2000);
//                ListBox.ObjectCollection oc =
//                    (ListBox.ObjectCollection)GetControlPropertyValue(theForm1, "listBox1", "Items");
//                if (oc.Count > 0)
//                {
//                    string s = oc[0].ToString();
//                    Console.WriteLine("the first line in listBox1 is " + s);
//                    string tb = "The textbox wins";
//                    if (oc.Contains(tb))
//                    {
//                        Console.WriteLine("Found '{0}' in listbox1", tb);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Did not find '{0}' in listbox1", tb);
//                    }
//                }

//                Thread.Sleep(3000);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Fatal error:" + e.Message);
//            }
//        } //Main

//        delegate object GetControlPropertyValueHandler(Form1 f, string controlName,
//            string propertyName
//        );

//        static object GetControlPropertyValue(Form1 f, string controlName,
//            string propertyName)
//        {
//            if (f.InvokeRequired)
//            {
//                object[] o = { f, controlName, propertyName };
//                Delegate d = new GetControlPropertyValueHandler(GetControlPropertyValue);
//                object ires = f.Invoke(d, o);
//                return ires;
//            }
//            else
//            {
//                Type t = f.GetType();
//                FieldInfo fi = t.GetField(controlName, flags);

//                object ctrl = fi.GetValue(f);
//                Type t2 = ctrl.GetType();
//                PropertyInfo pi = t2.GetProperty(propertyName);
//                object result = pi.GetValue(ctrl, null);
//                return result;

//            }
//        }

//        private static Form1 LaunchApp(string path, string formName)
//        {
//            Form1 result = null;
//            var a = Assembly.LoadFrom(path);
//            var t1 = a.GetType(formName);
//            result = (Form1)a.CreateInstance(t1.FullName);

//            var aps = new AppState(result);
//            var ts = new ThreadStart(aps.RunApp);
//            var thread = new Thread(ts);
//            thread.ApartmentState = ApartmentState.STA;
//            thread.IsBackground = true;
//            thread.Start();
//            return result;
//        }

//        private class AppState
//        {
//            private readonly Form1 _formToRun;

//            public AppState(Form1 f)
//            {
//                this._formToRun = f;
//            }

//            public void RunApp()
//            {
//                Application.Run(_formToRun);
//            }
//        } //class AppState
//    } //class SetControlPropDemo
//} //ns



