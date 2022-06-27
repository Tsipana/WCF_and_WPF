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
    public partial class Freights : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-57E53CS;Initial Catalog=DBCtuLogistics;Integrated Security=True");
        public Freights()
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
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Freight values('" + int.Parse(textBox1.Text) + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + comboBox1.SelectedItem.ToString() + "', '" + DateTime.Parse(dateTimePicker1.Text) + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been insert");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Freights_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Waiting");
            comboBox1.Items.Add("Shiping");
            comboBox1.Items.Add("Arrived");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                SqlCommand cmd = new SqlCommand("Select * from Freight", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Select * from Freight where Customerid='" + int.Parse(textBox1.Text) + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Freight set Height='"+ textBox2.Text + "', Length='"+ textBox3.Text + "', Weight='" + textBox4.Text + "', DestinationAddressid='"+ textBox5.Text + "', OriginAdressid='"+ textBox6.Text + "', Statusid='"+comboBox1.SelectedItem.ToString()+"', date='"+ DateTime.Parse(dateTimePicker1.Text) + "' where Customerid='"+ int.Parse(textBox1.Text) + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been updated");
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
                SqlCommand cmd = new SqlCommand("delete from Freight where Customerid='" + int.Parse(textBox1.Text) + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been deleted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}