﻿using System;
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
    public partial class Attendance : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pubz\Documents\GymDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Attendance()
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
                string qry = "Select * from Attendance";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Accessories");
                bindingSource1.DataSource = DS.Tables["Accessories"];
                AttendanceGridView.DataSource = bindingSource1;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            string qry = "INSERT INTO Attendance VALUES ('" + txtAttendanceID.Text + "','" +txtCusID.Text + "','" + txtCusName.Text + "','" + txtDateDay.Text + "','" + TxtTimeIN.Text + "','" +txtTimeOut.Text + "')";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record added Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
                AttendanceGridView.DataSource = null;
                LoadAllCustomer();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string custID = "";
            string custName = "";
            string Date = "";
            string Atime = "";
            string Dtime = "";
            

            string qry = "UPDATE Attendance SET CustomerID = @custID, CustomerName=@name, Date=@date, ArrivalTime=@Atime, DepTime=@Dtime  Where AttendanceID= @attID";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                DataTable Dt = new DataTable();
                AttendanceGridView.DataSource = bindingSource1;

                foreach (DataGridViewRow row in AttendanceGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(txtAttendanceID.Text))
                        {
                            DataRow dr = Dt.NewRow();

                            custID = row.Cells[1].Value.ToString();
                            custName = row.Cells[2].Value.ToString();
                            Date = row.Cells[3].Value.ToString();
                            Atime = row.Cells[4].Value.ToString();
                            Dtime = row.Cells[5].Value.ToString();
                            break;
                        }
                    }
                }

                if (txtCusID.Text != null && txtCusID.Text != String.Empty)
                {
                    custID = txtCusID.Text;
                }

                if (txtCusName.Text != null && txtCusName.Text != String.Empty)
                {
                    custName = txtCusName.Text;
                }

                if (txtDateDay.Text != null && txtDateDay.Text != String.Empty)
                {
                    Date = txtDateDay.Text;
                }

                if (TxtTimeIN.Text != null && TxtTimeIN.Text != String.Empty)
                {
                    Atime = TxtTimeIN.Text;
                }

                if (txtTimeOut.Text != null && txtTimeOut.Text != String.Empty)
                {
                    Dtime = txtTimeOut.Text;
                }

                cmd.Parameters.AddWithValue("@custID", custID);
                cmd.Parameters.AddWithValue("@name", custName);
                cmd.Parameters.AddWithValue("@date", Date);
                cmd.Parameters.AddWithValue("@Atime", Atime);
                cmd.Parameters.AddWithValue("@Dtime", Dtime);
                cmd.Parameters.AddWithValue("@attID",txtAttendanceID.Text);

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
                AttendanceGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM Attendance WHERE AttendanceID='" + txtAttendanceID.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
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
                AttendanceGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAttendanceID.Text = "";
            txtCusID.Text = "";
            txtCusName.Text = "";
            txtDateDay.Text = "";
            TxtTimeIN.Text = "";
            txtTimeOut.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchAttendance.Text;

            AttendanceGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                DataTable Dt = new DataTable();
                AttendanceGridView.DataSource = bindingSource1;

                foreach (DataGridViewRow row in AttendanceGridView.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (row.Cells[1].Value.ToString().Equals(searchValue))
                        {
                            // record exists   
                            Dt.Columns.Add("Attendance ID");
                            Dt.Columns.Add("Customer ID");
                            Dt.Columns.Add("Customer Name");
                            Dt.Columns.Add("Date");
                            Dt.Columns.Add("Arrival Time");
                            Dt.Columns.Add("Departure Time");
                           

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
                AttendanceGridView.DataSource = Dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchAttendance.Text = "";
            LoadAllCustomer();
        }
    }
}
