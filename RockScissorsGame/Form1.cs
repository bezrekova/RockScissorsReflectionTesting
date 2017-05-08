using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockScissorsGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = comboBox1.Text;

            if (text1 == text2)
            {
                listBox1.Items.Add("Result is a tie!");
            }
            else if (text1 == "scissors" && text2 == "paper" ||
                text1 == "paper" && text2 == "rock" ||
                text1 == "rock" && text2 == "scissors")
            {
                listBox1.Items.Add("The textbox wins");
            }
            else
            {
                listBox1.Items.Add("The combobox wins");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
           // form1.Show();
            form1.ShowDialog(this);
            this.Close();
        }
    }
}
