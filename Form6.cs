using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            
            con = new SqlConnection("Data Source=LAPTOP-BKC8B5BO\\ARONIUM;Initial Catalog=HotelDB;Integrated Security=True");
        }
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text.Trim();

                con.Open();

                string query = "SELECT * FROM Package WHERE name LIKE '%' + @name + '%'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No packages found with the given name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=LAPTOP-BKC8B5BO\\ARONIUM;Initial Catalog=HotelDB;Integrated Security=True");
        }
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader dr;
        String id;
        String name;
        int cost_per_person;
        String description;
        String complementary;

        private void button1_Click(object sender, EventArgs e)
        
          
            {
                try
                {
                    con.Open();

                    string query = "SELECT * FROM Package";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
    }
}
