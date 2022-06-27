using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tshepo_8064_PRG521_SA
{
    public partial class Drivers : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-57E53CS;Initial Catalog=DBCtuLogistics;Integrated Security=True");
        public Drivers()
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
                string status = "";
                if (radioButton1.Checked == true)
                {
                    status = radioButton1.Text;
                }
                else
                {
                    status = radioButton2.Text;
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Driver values('"+textBox1.Text+"', '"+ comboBox1.SelectedItem.ToString() +"', '"+ status +"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been inserted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("A1");
            comboBox1.Items.Add("A");
            comboBox1.Items.Add("B");
            comboBox1.Items.Add("EB");
            comboBox1.Items.Add("C1");
            comboBox1.Items.Add("C");
            comboBox1.Items.Add("EC1");
            comboBox1.Items.Add("EC");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    SqlCommand cmd = new SqlCommand("Select * from Driver", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Select * from Driver where FullName='" + textBox1.Text + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                if (radioButton1.Checked == true)
                {
                    status = radioButton1.Text;
                }
                else
                {
                    status = radioButton2.Text;
                }

                con.Open();
                SqlCommand cmd = new SqlCommand("update Driver set LicenseType='"+ comboBox1.SelectedItem.ToString() + "', Owner='"+status+ "' where FullName='"+ textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been update");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Driver where FullName='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been deleted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
