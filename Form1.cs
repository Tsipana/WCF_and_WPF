using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tshepo_8064_PRG521_SA
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

        private void button1_Click(object sender, EventArgs e)
        {
            LinkToAddresses();
            this.Hide();
        }

        public static void LinkToAddresses()
        {
            Adresses ad = new Adresses();
            ad.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LinkToCustomers();
            this.Hide();
        }

        public static void LinkToCustomers()
        {
            Customers cs = new Customers();
            cs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LinkToFreight();
            this.Hide();
        }

        public static void LinkToFreight()
        {
            Freights fr = new Freights();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LinkToDrivers();
            this.Hide();
        }

        public static void LinkToDrivers()
        {
            Drivers dr = new Drivers();
            dr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LinkToStatus();
            this.Hide();
        }

        public static void LinkToStatus()
        {
            Statuasses st = new Statuasses();
            st.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AppExit();
        }

        public static void AppExit()
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
