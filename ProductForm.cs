using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SupermarketManagementSystem
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\laven\Documents\superMarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void fill_Combobox()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select categName from CategTbl", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("categName", typeof(string));
            dt.Load(rdr);
            guna2ComboBox1.ValueMember = "categName";
            guna2ComboBox1.DataSource = dt;
            Con.Close();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            fill_Combobox();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            this.Hide();
            categoryForm.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into ProductTbl values(" + guna2TextBox1.Text + ",'" + guna2TextBox2.Text + "','" + guna2TextBox3.Text + "', '"+ guna2TextBox4.Text + "', '"+ guna2ComboBox1.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Succesfully!");
                Con.Close();
                populate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2ComboBox1.SelectedValue = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox1.Text == "")
                {
                    MessageBox.Show("Select a Product to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from ProductTbl where productId=" + guna2TextBox1.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Succesfully!");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update ProductTbl set productId='" + guna2TextBox1.Text + "', productName='" + guna2TextBox2.Text + "', productAmount='" + guna2TextBox3.Text + "', productPrice='" + guna2TextBox4.Text + "' where productId=" + guna2TextBox1.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Edited Succesfully!");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            this.Hide();
            customer.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SellingForm sellingForm = new SellingForm();
            this.Hide();
            sellingForm.Show();
        }
    }
}
