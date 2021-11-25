using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagementSystem
{
    public partial class SellingForm : Form
    {
        public SellingForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\laven\Documents\superMarketdb.mdf;Integrated Security=True;Connect Timeout=30");


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
