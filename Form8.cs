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
using System.IO;
using Org.BouncyCastle.Utilities.Collections;

namespace HotelManagementSystem
{
    public partial class Form8 : Form
    {
        private string photoFilePath = "";
        private string certificateFilePath = "";
        private string reportFilePath = "";
        private SqlConnection con;
        public Form8()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=LAPTOP-BKC8B5BO\\ARONIUM;Initial Catalog=HotelDB;Integrated Security=True");
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                comboBox1.Items.AddRange(new string[] { "Maintenance", "Kitchen", "Housekeeping", "Banquets" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        public SqlCommand cmd;
        public SqlDataReader dr;
        String id;
        String name;
        Image photo;
        String gender;
        String department;
        String address;
        int contact_no;
        String email;
        String salary;
        Image certificate;
        Image report;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDepartment = comboBox1.SelectedItem.ToString();
            switch (selectedDepartment)
            {
                case "Maintenance":
                    lbl_salary.Text = "Rs.45000";
                    break;
                case "Kitchen":
                    lbl_salary.Text = "Rs.50000";
                    break;
                case "Housekeeping":
                    lbl_salary.Text = "Rs.30000";
                    break;
                case "Banquets":
                    lbl_salary.Text = "Rs.60000";
                    break;
                default:
                    lbl_salary.Text = "";
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_search1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text.Trim();

                con.Open();

                string query = "SELECT id, name, gender, department, address, contact_no, email, salary, " +
                               "photo, certificate, report " +
                               "FROM Staff WHERE name LIKE '%' + @name + '%'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // Modify the DataTable to include columns for displaying file paths
                    dt.Columns.Add("Photo", typeof(string));
                    dt.Columns.Add("Certificate", typeof(string));
                    dt.Columns.Add("Report", typeof(string));

                    // Update the values of the newly added columns with correct file paths
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Photo"] = row["photo"].ToString(); // Assuming photo column stores the file path
                        row["Certificate"] = row["certificate"].ToString(); // Assuming certificate column stores the file path
                        row["Report"] = row["report"].ToString(); // Assuming report column stores the file path
                    }

                    // Remove the original photo, certificate, and report columns from the DataTable
                    dt.Columns.Remove("photo");
                    dt.Columns.Remove("certificate");
                    dt.Columns.Remove("report");

                    // Bind the modified DataTable to the DataGridView
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
        private string SaveByteArrayToFile(byte[] byteArray, string fileName)
        {
            string filePath = Path.Combine(Path.GetTempPath(), fileName);
            File.WriteAllBytes(filePath, byteArray);
            return filePath;
        }
        private void txt_id2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_photo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.Title = "Select a photo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    photoFilePath = openFileDialog.FileName;

                    // Get just the file name from the full path
                    string fileName = Path.GetFileName(photoFilePath);

                    // Display the file name in the label
                    label14.Text = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txt_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_salary_Click(object sender, EventArgs e)
        {

        }

        private void txt_name2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtx_email2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_certificate_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.Title = "Select a certificate file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    certificateFilePath = openFileDialog.FileName;

                    // Get just the file name from the full path
                    string fileName = Path.GetFileName(certificateFilePath);

                    // Display the file name in the label
                    label15.Text = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.Title = "Select a report file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    reportFilePath = openFileDialog.FileName;

                    // Get just the file name from the full path
                    string fileName = Path.GetFileName(reportFilePath);

                    // Display the file name in the label
                    label16.Text = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Staff (id, name, gender, department, address, contact_no, email, salary, photo, certificate, report) " +
                               "VALUES (@id, @name, @gender, @department, @address, @contact_no, @email, @salary, " +
                               "@photo, @certificate, @report)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txt_id2.Text);
                cmd.Parameters.AddWithValue("@name", txt_name2.Text);
                cmd.Parameters.AddWithValue("@gender", radioButton1.Checked ? "Male" : "Female");
                cmd.Parameters.AddWithValue("@department", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@address", txt_address.Text);
                cmd.Parameters.AddWithValue("@contact_no", int.Parse(txt_number.Text));
                cmd.Parameters.AddWithValue("@email", txtx_email2.Text);
                cmd.Parameters.AddWithValue("@salary", lbl_salary.Text);
                cmd.Parameters.AddWithValue("@photo", File.ReadAllBytes(photoFilePath));
                cmd.Parameters.AddWithValue("@certificate", File.ReadAllBytes(certificateFilePath));
                cmd.Parameters.AddWithValue("@report", File.ReadAllBytes(reportFilePath));

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Staff member added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add staff member.");
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

        private byte[] getReport()
        {
            if (btn_report.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                btn_report.Image.Save(stream, btn_report.Image.RawFormat);
                return stream.ToArray();
            }
            else
            {

                return new byte[0];
            }
        }

        private byte[] getCertificate()
        {
            if (btn_certificate.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                btn_certificate.Image.Save(stream, btn_certificate.Image.RawFormat);
                return stream.ToArray();
            }
            else
            {

                return new byte[0];
            }
        }

        private byte[] getPhoto()
        {
            if (btn_photo.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                btn_photo.Image.Save(stream, btn_photo.Image.RawFormat);
                return stream.ToArray();
            }
            else
            {

                return new byte[0];
            }
        }




        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "UPDATE Staff SET name = @name, gender = @gender, department = @department, " +
                               "address = @address, contact_no = @contact_no, email = @email, " +
                               "salary = @salary";

                // Check if photoFilePath, certificateFilePath, and reportFilePath are not empty before adding them to the query
                if (!string.IsNullOrEmpty(photoFilePath))
                {
                    query += ", photo = @photo";
                }
                if (!string.IsNullOrEmpty(certificateFilePath))
                {
                    query += ", certificate = @certificate";
                }
                if (!string.IsNullOrEmpty(reportFilePath))
                {
                    query += ", report = @report";
                }

                query += " WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txt_id2.Text);
                cmd.Parameters.AddWithValue("@name", txt_name2.Text);
                cmd.Parameters.AddWithValue("@gender", radioButton1.Checked ? "Male" : "Female");

                if (comboBox1.SelectedItem != null)
                {
                    cmd.Parameters.AddWithValue("@department", comboBox1.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Please select a department.");
                    return;
                }

                cmd.Parameters.AddWithValue("@address", txt_address.Text);
                cmd.Parameters.AddWithValue("@contact_no", int.Parse(txt_number.Text));
                cmd.Parameters.AddWithValue("@email", txtx_email2.Text);
                cmd.Parameters.AddWithValue("@salary", lbl_salary.Text);

                // Check if photoFilePath, certificateFilePath, and reportFilePath are not empty before adding them as parameters
                if (!string.IsNullOrEmpty(photoFilePath))
                {
                    cmd.Parameters.AddWithValue("@photo", File.ReadAllBytes(photoFilePath));
                }
                if (!string.IsNullOrEmpty(certificateFilePath))
                {
                    cmd.Parameters.AddWithValue("@certificate", File.ReadAllBytes(certificateFilePath));
                }
                if (!string.IsNullOrEmpty(reportFilePath))
                {
                    cmd.Parameters.AddWithValue("@report", File.ReadAllBytes(reportFilePath));
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Staff member updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update staff member.");
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

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                string idText = txt_id2.Text.Trim();

                // Check if the ID text is not empty
                if (!string.IsNullOrEmpty(idText))
                {
                    con.Open();
                    string query = "DELETE FROM Staff WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Use SqlDbType.VarChar for a varchar column
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = idText;

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Staff member deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No staff member found with the given ID.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid ID.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Staff WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txt_id2.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_id2.Text = dr["id"].ToString();
                    txt_name2.Text = dr["name"].ToString();
                    comboBox1.Text = dr["department"].ToString();
                    txt_address.Text = dr["address"].ToString();
                    txt_number.Text = dr["contact_no"].ToString();
                    txtx_email2.Text = dr["email"].ToString();
                    lbl_salary.Text = dr["salary"].ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
