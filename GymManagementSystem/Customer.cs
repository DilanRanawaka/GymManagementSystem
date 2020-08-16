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
    public partial class Customer : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pubz\Documents\GymDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();

        public Customer()
        {
            InitializeComponent();
            LoadAllCustomer();
        }

        private void LoadAllCustomer()
        {
            try
            {
                DS = new DataSet();
                bindingSource1.DataSource = null;

                con.Open();
                string qry = "Select * from Customer ";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Customer");
                bindingSource1.DataSource = DS.Tables["Customer"];                
                customerdetailsgrid.DataSource = bindingSource1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
            }
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
            Payment eight = new Payment();
            this.Hide();
            eight.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM Customer where CustomerID='" + txtCustomerID.Text + "' ";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DS = new DataTable();
                DA.Fill(DS);


                if (DS.Rows.Count == 1)
                {
                    MessageBox.Show("This customer already exists");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated : " + ex);
            }
            finally
            {
                con.Close();
            }

            string gender = "Female";

            if (radioCustomerMale.Checked)
                gender = "Male";

            
            string query = "INSERT INTO Customer VALUES ('"+txtCustomerID.Text+ "','" +txtCustomerName.Text + "','" + txtCustomerAddress.Text + "','" + txtCustomerNIC.Text + "','" + txtEmail.Text + "','" + txtno.Text + "','" + gender + "')";
            SqlCommand cmmd = new SqlCommand(query,con);
            try
            {
                con.Open();
                cmmd.ExecuteNonQuery();
                MessageBox.Show("User Registered Successfully");

            }
             catch(Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
                customerdetailsgrid.DataSource = null;
                LoadAllCustomer();
            }
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string custName = "";
            string address = "";
            string nic = "";
            string email = "";
            string no = "";

            string qry = "UPDATE Customer SET CustomerName = @cust, Address=@add, NIC=@nic, Email=@mail, Phone=@no  Where CustomerID = @custID";
            SqlCommand cmd = new SqlCommand(qry,con);
            try
            {
                con.Open();
                DataTable Dt = new DataTable();
                customerdetailsgrid.DataSource = bindingSource1;

                foreach (DataGridViewRow row in customerdetailsgrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(txtCustomerID.Text))
                        {
                            DataRow dr = Dt.NewRow();

                            custName = row.Cells[1].Value.ToString();
                            address = row.Cells[2].Value.ToString();
                            nic = row.Cells[3].Value.ToString();
                            email = row.Cells[4].Value.ToString();
                            no = row.Cells[5].Value.ToString();
                            break;
                        }
                    }
                }

                if (txtCustomerName.Text != null && txtCustomerName.Text != String.Empty)
                {
                    custName = txtCustomerName.Text;
                }

                if (txtCustomerAddress.Text != null && txtCustomerAddress.Text != String.Empty)
                {
                    address = txtCustomerAddress.Text;
                }

                if (txtCustomerNIC.Text != null && txtCustomerNIC.Text != String.Empty)
                {
                    nic = txtCustomerNIC.Text;
                }

                if (txtEmail.Text != null && txtEmail.Text != String.Empty)
                {
                    email = txtEmail.Text;
                }

                if (txtno.Text != null && txtno.Text != String.Empty)
                {
                    no = txtno.Text;
                }

                cmd.Parameters.AddWithValue("@cust", custName);
                cmd.Parameters.AddWithValue("@add", address);
                cmd.Parameters.AddWithValue("@nic", nic);
                cmd.Parameters.AddWithValue("@mail", email);
                cmd.Parameters.AddWithValue("@no", no);
                cmd.Parameters.AddWithValue("@custID", txtCustomerID.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated " + ex);
            }
            finally
            {
                con.Close();
                customerdetailsgrid.DataSource = null;
                LoadAllCustomer();
            }
        }

        private DataTable returnRecord(string searchValue)
        {
            customerdetailsgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                DataTable Dt = new DataTable();
                customerdetailsgrid.DataSource = bindingSource1;

                foreach (DataGridViewRow row in customerdetailsgrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(searchValue))
                        {
                            DataRow dr = Dt.NewRow();
                            
                            dr[0] = row.Cells[0].Value;
                            dr[1] = row.Cells[1].Value;
                            dr[2] = row.Cells[2].Value;
                            dr[3] = row.Cells[3].Value;
                            dr[4] = row.Cells[4].Value;
                            dr[5] = row.Cells[5].Value;
                            dr[6] = row.Cells[6].Value;

                            Dt.Rows.Add(dr);
                            break;
                        }
                    }
                }

                return Dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchCustomer.Text;

            customerdetailsgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                DataTable Dt = new DataTable();
                customerdetailsgrid.DataSource = bindingSource1;

                foreach (DataGridViewRow row in customerdetailsgrid.Rows)
                {
                    if(row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(searchValue))
                        {
                            // record exists   
                            Dt.Columns.Add("Customer ID");
                            Dt.Columns.Add("Customer Name");
                            Dt.Columns.Add("Address");
                            Dt.Columns.Add("NIC");
                            Dt.Columns.Add("Email");
                            Dt.Columns.Add("Phone");
                            Dt.Columns.Add("Gender");

                            DataRow dr = Dt.NewRow();
                            dr[0] = row.Cells[0].Value;
                            dr[1] = row.Cells[1].Value;
                            dr[2] = row.Cells[2].Value;
                            dr[3] = row.Cells[3].Value;
                            dr[4] = row.Cells[4].Value;
                            dr[5] = row.Cells[5].Value;
                            dr[6] = row.Cells[6].Value;

                            Dt.Rows.Add(dr);
                            break;
                        }
                    }
                }
                customerdetailsgrid.DataSource = Dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchCustomer.Text = "";
            LoadAllCustomer(); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text ="";
            txtCustomerNIC.Text = "";
            txtEmail.Text = "";
            txtno.Text = "";
            radioCustomerFemale.Checked = false;
            radioCustomerMale.Checked = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM Customer WHERE CustomerID='" + txtCustomerID.Text + "'";
            SqlCommand cmd = new SqlCommand(qry,con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated " + ex);
            }
            finally
            {
                con.Close();
                customerdetailsgrid.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
