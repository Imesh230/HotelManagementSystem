using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btn_reservation_Click(object sender, EventArgs e)
        {
            Form5 ManageReservationForm = new Form5();
            ManageReservationForm.Show();
        }

        private void btn_viewpackage_Click(object sender, EventArgs e)
        {
            Form6 ViewpAckageForm = new Form6();
            ViewpAckageForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
