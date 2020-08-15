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
    public partial class Payment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pubz\Documents\GymDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Payment()
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
            string qry = "Select * from Payment ";

            DA = new SqlDataAdapter(qry, con);

            DA.Fill(DS, "Payment");
            bindingSource1.DataSource = DS.Tables["[Payment"];
            PaymentGridView.DataSource = bindingSource1;
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

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchPayment.Text = "";
            LoadAllCustomer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchPayment.Text;

            PaymentGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                DataTable Dt = new DataTable();
                PaymentGridView.DataSource = bindingSource1;

                foreach (DataGridViewRow row in PaymentGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(searchValue))
                        {
                            // record exists   
                            Dt.Columns.Add("Payment ID");
                            Dt.Columns.Add("Customer ID");
                            Dt.Columns.Add("Customer Name");
                            Dt.Columns.Add("Date");
                            Dt.Columns.Add("Amount");
                            Dt.Columns.Add("Payment Method");

                            DataRow dr = Dt.NewRow();
                            dr[0] = row.Cells[0].Value;
                            dr[1] = row.Cells[1].Value;
                            dr[2] = row.Cells[2].Value;
                            dr[3] = row.Cells[3].Value;
                            dr[4] = row.Cells[4].Value;
                            dr[5] = row.Cells[5].Value;

                            Dt.Rows.Add(dr);
                            break;
                        }
                    }
                }

                PaymentGridView.DataSource = Dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void txtPaymentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            string paymethod = "Card";

            if (radioButton2.Checked)
            {
                paymethod = "Cash";
            }
            string dt = PaymentDate.Value.ToShortDateString();

            string qry = "INSERT INTO Payment VALUES ('" + txtPaymentID.Text + "','" + txtCustomerID.Text + "','" + txtCustomerName.Text + "','" + TxtAmount.Text + "','" + paymethod + "','" + PaymentDate + "')";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
                PaymentGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string qry = "UPDATE Payment SET CustomerID = @cust, CustomerName=@CustName, Date=@date, Amount=@amt Where PaymentID = @payID";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();

                cmd.Parameters.AddWithValue("@cust", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@CustName", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@Date", PaymentDate.Text);
                cmd.Parameters.AddWithValue("@amt", TxtAmount.Text);

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
                PaymentGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPaymentID.Text = "";
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            PaymentDate.Text = "";
            TxtAmount.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
}
