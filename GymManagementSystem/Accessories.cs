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
    public partial class Accessories : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pubz\Documents\GymDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();

        public Accessories()
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
                string qry = "Select * from Accessories";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Accessories");
                bindingSource1.DataSource = DS.Tables["Accessories"];
                AccessoryGridView.DataSource = bindingSource1;
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

        private void txtSearchAccessory_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string qry = "INSERT INTO Accessories VALUES ('" + txtAccessoryID.Text + "','" + txtAccessoryType.Text + "','" + txtAccessoryBrand.Text + "','" + txtAccessoryQty.Text + "','" + txtAccessoryPrice.Text + "','"+datePicker+"')";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                string dt = datePicker.Value.ToShortDateString();

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Accessory added Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
                AccessoryGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
