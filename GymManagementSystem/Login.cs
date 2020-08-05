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

namespace GymManagementSystem
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pubz\Documents\GymDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM Users where username='"+Txtusername.Text+"' AND password='"+Txtpassword.Text+"'";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DS = new DataTable();
                DA.Fill(DS);
                

                if (DS.Rows.Count==1)
                {
                    Home one = new Home();
                    this.Hide();
                    one.Show();
                }
                else
                {
                    MessageBox.Show("Sorry! You are not a registered user");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error generated : " + ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
