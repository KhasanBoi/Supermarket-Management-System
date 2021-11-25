using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SupermarketManagementSystem
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\laven\Documents\superMarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into CategTbl values("+ guna2TextBox1.Text+ ",'"+guna2TextBox2.Text+"','"+guna2TextBox3.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Added Succesfully!");
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
            string query = "select * from CategTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if(guna2TextBox1.Text == "")
                {
                    MessageBox.Show("Select a Category to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from CategTbl where categId=" + guna2TextBox1.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Succesfully!");
                    Con.Close();
                    populate();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update CategTbl set categId='" + guna2TextBox1.Text + "', categName='" + guna2TextBox2.Text + "', categDesc='" + guna2TextBox3.Text + "' where categId=" + guna2TextBox1.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Edited Succesfully!");
                    Con.Close();
                    populate();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            this.Hide();
            productForm.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SellingForm sellingForm = new SellingForm();
            this.Hide();
            sellingForm.Show();
        }
    }
}
