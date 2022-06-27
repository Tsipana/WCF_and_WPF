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
    
    public partial class Customers : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-57E53CS;Initial Catalog=DBCtuLogistics;Integrated Security=True");
        public Customers()
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
                string num = textBox1.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Customer values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + RanNum() + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been inserted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int RanNum()
        {
            Random num = new Random();
            int rannum = num.Next(1,13);
            return rannum;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (textBox2.Text == "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Customer", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Customer where ContactNumber='" + int.Parse(textBox2.Text) + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Customer set FullName='" + textBox1.Text + "', Email='" + textBox3.Text + "' where ContactNumber='" + int.Parse(textBox2.Text) + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been inserted");
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
                SqlCommand cmd = new SqlCommand("Delete from Customer where ContactNumber='" + int.Parse(textBox2.Text) + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been deleted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
         }
    }
}
