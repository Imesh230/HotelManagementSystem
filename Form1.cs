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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=LAPTOP-BKC8B5BO\\ARONIUM;Initial Catalog=HotelDB;Integrated Security=True");


        }
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader dr;
        int id;
        String username;
        String password;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT * FROM Login WHERE username = @username AND password = @password", con);
            cmd.Parameters.AddWithValue("@username", Username.Text);
            cmd.Parameters.AddWithValue("@password", Password.Text);

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["username"].ToString() == "admin")
                    {
                        Form3 MainmenuForm = new Form3();
                        MainmenuForm.Show();
                    }
                    else
                    {
                        Form4 otherForm = new Form4();
                        otherForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                con.Close();
            }
        }


        private void btn_newaccount_Click(object sender, EventArgs e)
        {
            Form2 RegisterPageForm = new Form2();
            RegisterPageForm.Show();
        }
    }
}
