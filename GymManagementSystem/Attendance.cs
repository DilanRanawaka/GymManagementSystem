using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login two = new Login();
            this.Hide();
            two.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Home three = new Home();
            this.Hide();
            three.Show();
        }

        private void btnInstructor_Click(object sender, EventArgs e)
        {
            Instructor five = new Instructor();
            this.Hide();
            five.Show();
        }

        private void btnAccessories_Click(object sender, EventArgs e)
        {
            Accessories six = new Accessories();
            this.Hide();
            six.Show();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment eight = new Payment();
            this.Hide();
            eight.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Home three = new Home();
            this.Hide();
            three.Show();
        }
    }
}
