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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=LAPTOP-BKC8B5BO\\ARONIUM;Initial Catalog=HotelDB;Integrated Security=True");
        }
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader dr;
        int id;
        String username;
        String password;
        String email;
        String confirm_password;

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_conpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login1_Click(object sender, EventArgs e)
        {
            if (txt_password.Text != txt_conpassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            con.Open();
            try
            {
                // SQL query to insert new user details
                string query = "INSERT INTO Login (username, password, email, confirm_password) VALUES (@username, @password, @email, @confirm_password)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", txt_username.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);
                cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cmd.Parameters.AddWithValue("@confirm_password", txt_conpassword.Text);

                // Execute query
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User registered successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to register user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                con.Close();

                // Navigate back to Form1
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }

        }
    }
}
