using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestCreator
{

    class XMLCreator
    {
        public static int counter = 0;


        public void CreateXml(DataModel[] arr)
        {
            if (arr != null)
            {
                XMLCreator.counter++;
                string part = "Testcase" + counter;
                string filename = part + ".xml";
                try
                {
                    using (XmlWriter writer = XmlWriter.Create(filename))
                    {
                        //string app, string ctrl, string action, string param
                        writer.WriteStartDocument();
                        writer.WriteStartElement(part);

                        foreach (DataModel dt in arr)
                        {
                            writer.WriteStartElement("TestRow");

                            writer.WriteElementString("App", dt.App);
                            writer.WriteElementString("Control", dt.Control);
                            writer.WriteElementString("Action", dt.Action);
                            if (dt.Param != String.Empty)
                            {
                                writer.WriteElementString("Param", dt.Param);
                            }

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("Empty testcase");
            }

        }


    }

}

