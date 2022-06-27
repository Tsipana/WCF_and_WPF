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
    public partial class Adresses : Form
    {
        public Adresses()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-57E53CS;Initial Catalog=DBCtuLogistics;Integrated Security=True");
        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Adresses_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Address values('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your data has been inserted");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" && textBox2.Text == "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Address", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Address where ComplexNumber='" + int.Parse(textBox1.Text) + "' and ComplexName='" + textBox2.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Address set Street='" + textBox3.Text + "', Suburb='" + textBox4.Text + "', City='" + textBox5.Text + "', Province='" + textBox6.Text + "', Country='" + textBox7.Text + "', PostalCode='" + textBox8.Text + "' where ComplexNumber='" + int.Parse(textBox1.Text) + "' and ComplexName='" + textBox2.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has been updated");
                con.Close();
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
                SqlCommand cmd = new SqlCommand("delete from Address where ComplexNumber='" + int.Parse(textBox1.Text) + "' and ComplexName='" + textBox2.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been updated");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
