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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
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

        private void txt_id1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_name1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_person_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_description_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_comple_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Package (id, name, cost_per_person, description, complementary) VALUES (@id, @name, @cost_per_person, @description, @complementary)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txt_id1.Text);
                cmd.Parameters.AddWithValue("@name", txt_name1.Text);
                cmd.Parameters.AddWithValue("@cost_per_person", int.Parse(txt_person.Text));
                cmd.Parameters.AddWithValue("@description", txt_description.Text);
                cmd.Parameters.AddWithValue("@complementary", txt_comple.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Package added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add package.");
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

        private void btn_edit1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "UPDATE Package SET name = @name, cost_per_person = @cost_per_person, description = @description, complementary = @complementary WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txt_id1.Text);
                cmd.Parameters.AddWithValue("@name", txt_name1.Text);
                cmd.Parameters.AddWithValue("@cost_per_person", int.Parse(txt_person.Text));
                cmd.Parameters.AddWithValue("@description", txt_description.Text);
                cmd.Parameters.AddWithValue("@complementary", txt_comple.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Package updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update package.");
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM Package WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", int.Parse(txt_id1.Text));

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Package deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to delete package.");
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_id1.Clear();
            txt_name1.Clear();
            txt_person.Clear();
            txt_description.Clear();
            txt_comple.Clear();
        }

        private void btn_search2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Package WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txt_id2.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_id1.Text = dr["id"].ToString();
                    txt_name1.Text = dr["name"].ToString();
                    txt_person.Text = dr["cost_per_person"].ToString();
                    txt_description.Text = dr["description"].ToString();
                    txt_comple.Text = dr["complementary"].ToString();
                }
                else
                {
                    MessageBox.Show("Package not found.");
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

        private void txt_id2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
}
