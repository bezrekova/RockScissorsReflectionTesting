using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCreator
{
    class DataModel
    {
        private string _control;
        private readonly string _action;
        private string _control1;
        private string _action1;

        public string Control
        {
            get { return _control1; }
            set { _control1 = value; }
        }


        public string App { get; set; }

        public string Action
        {
            get { return _action1; }
            set { _action1 = value; }
        }

        public string Param { get; set; }

        public DataModel(string app, string ctrl, string action, string param)
        {
            App = app;
            Control = ctrl + "1";
            Action = TransAction(action);
            Param = param;
        }

        private string TransAction(string action)
        {
            string act = action;
            if (act == "Click" && Control.Contains("button"))
            {
                act = "button1_Click";
            }
            else if (act == "Set text" && Control.Contains("textBox")
                || Control.Contains("comboBox"))
            {
               
            }
            return action;
        }
    }
}
