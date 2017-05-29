using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCreator
{
    public partial class Form1 : Form
    {
        DataModel[] arr = null;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                
            }

        private void button1_Click(object sender, EventArgs e)
        {
            arr = new DataModel[dataGridView1.RowCount];
            //string app, control, action, param;
            string cell = String.Empty;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    cell += dataGridView1.Rows[i].Cells[j].Value.ToString() + ";";

                }
                string[] res = cell.Split(';'); // splitter
                try
                {
                    arr[i].App = res[0];
                    arr[i].Control = res[1];
                    arr[i].Action = res[2];
                    arr[i].Param = res[3];
                    cell = string.Empty; //before new cycle }


                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cell = String.Empty;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                     dataGridView1.Rows[i].Cells[j].Value = String.Empty ;

                }
                

            }
        }
    }
}
