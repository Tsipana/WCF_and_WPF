using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tshepo_8064_PRG521_SA
{
    public partial class Statuasses : Form
    {
        public Statuasses()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileP = "status.txt";
                if (!File.Exists(fileP))
                {
                    File.Create(fileP).Close();
                }
                using (StreamWriter sw = new StreamWriter(fileP))
                {
                    sw.WriteLine(textBox1.Text + " -" + dateTimePicker1.Text + " -" + dateTimePicker2.Text + " -" + textBox2.Text);
                    MessageBox.Show("Data has been written on status.txt");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        DataTable table = new DataTable();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string[] lines = File.ReadAllLines(@"status.txt");
                string[] values;

                for(int i=0; i<lines.Length; i++)
                {
                    values = lines[i].ToString().Split('-');
                    string[] row = new string[values.Length];
                    for(int j=0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    table.Rows.Add(row);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private void Statuasses_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Statusid", typeof(string));
            table.Columns.Add("DatePickedUp", typeof(string));
            table.Columns.Add("DateDeliverd", typeof(string));
            table.Columns.Add("Driverid", typeof(string));

            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("status.txt", String.Empty);
                MessageBox.Show("Data has been deleted from status.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetLine(string str)
        {
            int counter = 0;
            string line;

            using (StreamReader file = new StreamReader("status.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(str))
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newText = textBox1.Text + " -" + dateTimePicker1.Text + " -" + dateTimePicker2.Text + " -" + textBox2.Text;
            using (StreamWriter sw = new StreamWriter("status.txt"))
            {
                sw.WriteLine(newText);
                MessageBox.Show("Data has been updated on status.txt");
            }
        }
    }
}