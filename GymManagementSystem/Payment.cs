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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Home three = new Home();
            this.Hide();
            three.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login two = new Login();
            this.Hide();
            two.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer four = new Customer();
            this.Hide();
            four.Show();
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
            Attendance seven = new Attendance();
            this.Hide();
            seven.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
           
        }
    }
}
