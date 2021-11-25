using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\laven\Documents\superMarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex > -1)
            {
                if(guna2ComboBox1.Text == "Admin")
                {
                    if (guna2TextBox3.Text == "admin" && guna2TextBox2.Text == "admin25112021")
                    {
                        ProductForm productForm = new ProductForm();
                        this.Hide();
                        productForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password or Admin Name");
                    }
                }
                else if(guna2ComboBox1.Text == "Customer")
                {
                    // YOU LOGGED IN AS A CUSTOMER
                    try
                    {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select count(8) from CustomTbl where customName='" + guna2TextBox3.Text + "' and customPassword='" + guna2TextBox2.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            SellingForm sellingForm = new SellingForm();
                            sellingForm.Show();
                            this.Hide();
                        }
                        Con.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Select a Role");
                }
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.PasswordChar = '*';
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            guna2TextBox2.PasswordChar = '\0';
        }
    }
}
