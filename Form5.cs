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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;





namespace HotelManagementSystem
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=LAPTOP-BKC8B5BO\\ARONIUM;Initial Catalog=HotelDB;Integrated Security=True");
        }
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader dr;
        String id;
        String full_name;
        String email;
        int mobile;
        DateTime reservation_date;
        int no_of_pax;
        String total_cost;
       
        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_fullname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_email1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_mobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_nopackage_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_totcost_Click(object sender, EventArgs e)
        {

        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            int no_of_pax = int.Parse(txt_nopackage.Text);
            int rate;
            if (no_of_pax <= 15)
            {
                rate = 3000 ;
            }
            else if (no_of_pax <= 25)
            {
                rate = 2500;
            }
            else if (no_of_pax <= 50)
            {
                rate = 1500;
            }
            else
            {
                rate = 1000;
            }
            int totalCost = no_of_pax * rate;
            lbl_totcost.Text = " Rs. " + totalCost.ToString() ;

            con.Open();
            try
            {
                string query = "INSERT INTO Reservation (id, full_name, email, mobile, reservation_date, no_of_pax, total_cost) VALUES (@id, @full_name, @email, @mobile, @reservation_date, @no_of_pax, @total_cost)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                cmd.Parameters.AddWithValue("@full_name", txt_fullname.Text);
                cmd.Parameters.AddWithValue("@email", txt_email1.Text);
                cmd.Parameters.AddWithValue("@mobile", int.Parse(txt_mobile.Text));
                cmd.Parameters.AddWithValue("@reservation_date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@no_of_pax", no_of_pax);
                cmd.Parameters.AddWithValue("@total_cost", totalCost);

            
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Reservation created successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to create reservation.");
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

        private void btn_edit_Click(object sender, EventArgs e)
        {


        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_fullname.Text = "";
            txt_email1.Text = "";
            txt_mobile.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txt_nopackage.Text = "";
            lbl_totcost.Text = "Total Cost:";
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
          
            richTextBox1.Text += "******           HotelXYZ              ****** \n ";
            richTextBox1.Text += "            Reservation Slip                  \n ";
            richTextBox1.Text += "******************************************  \n \n";

            richTextBox1.Text += "ID : " +txt_id.Text+ "\n\n";
            richTextBox1.Text += "Full Name : " + txt_fullname.Text + "\n\n";
            richTextBox1.Text += "Email Address : " + txt_email1.Text + "\n\n";
            richTextBox1.Text += "Mobile Number : " + txt_mobile.Text + "\n\n";
            richTextBox1.Text += "Reservation Date : " + dateTimePicker1.Text + "\n\n";
            richTextBox1.Text += "No of Pax : " + txt_nopackage.Text + "\n\n";
            richTextBox1.Text += "Total Cost : " + lbl_totcost.Text + "\n\n";



        }

        private void btn_downloadslip_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate a temporary file path
                string tempFilePath = Path.GetTempFileName();
                string pdfFilePath = Path.ChangeExtension(tempFilePath, ".pdf");

                // Create a PdfWriter
                using (PdfWriter writer = new PdfWriter(pdfFilePath))
                {
                    // Create a PdfDocument
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        // Create a Document
                        Document document = new Document(pdf);

                        // Add the content of the RichTextBox to the PDF document
                        Paragraph paragraph = new Paragraph(richTextBox1.Text);
                        document.Add(paragraph);
                    }
                }
                System.Diagnostics.Process.Start(pdfFilePath);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Error: PDF file not found. " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Error: Unauthorized access to file system. " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
           
        
    }
}
