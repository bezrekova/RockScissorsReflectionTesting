using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsBasedColorMixer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tb = textBox1.Text;
            string cb = comboBox1.Text;

            if (tb == "<enter color>" || cb == "pick")
            {
                MessageBox.Show("You need 2 colors", "Error");
            }
            else
            {
                if (tb == cb)
                {
                    listBox1.Items.Add("Result is " + tb);
                }
                else if (tb == "red" && cb == "blue" ||
                         tb == "blue" && cb == "red")
                {
                    listBox1.Items.Add("Result is purple");
                }
                else if (tb == "blue" && cb == "yellow" || tb == "yellow" && cb == "blue")
                {
                    listBox1.Items.Add("Result is green");
                }
                else
                {
                    listBox1.Items.Add("Result is black");
                }
            }
        }
    }
}

