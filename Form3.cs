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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btn_managestaff_Click(object sender, EventArgs e)
        {

            Form8 ManageStaffForm = new Form8();
            ManageStaffForm.Show();
        }

        private void btn_managepackage_Click(object sender, EventArgs e)
        {
            Form7 ManagePackageForm = new Form7();
            ManagePackageForm.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
