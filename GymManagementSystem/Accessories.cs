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
            string query = "SELECT * FROM Accessories where AccessoryID='" + txtAccessoryID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 1)
                {
                    MessageBox.Show("This accessory already exists");
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

            string qry = "INSERT INTO Accessories VALUES ('" + txtAccessoryID.Text + "','" + txtAccessoryType.Text + "','" + txtAccessoryBrand.Text + "','" + txtAccessoryQty.Text + "','" + txtAccessoryPrice.Text + "','"+txtDate.Text+"')";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
               
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
            string type = "";
            string brand = "";
            string quan = "";
            string price = "";
            string date = "";

            string qry = "UPDATE Accessories SET AccessoryType = @type, AccessoryBrand=@brand, Quantity=@quan, Price=@price, Date=@date  Where AccessoryID = @accID";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                DataTable Dt = new DataTable();
                AccessoryGridView.DataSource = bindingSource1;

                foreach (DataGridViewRow row in AccessoryGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(txtAccessoryID.Text))
                        {
                            DataRow dr = Dt.NewRow();

                            type = row.Cells[1].Value.ToString();
                            brand = row.Cells[2].Value.ToString();
                            quan = row.Cells[3].Value.ToString();
                            price = row.Cells[4].Value.ToString();
                            date = row.Cells[5].Value.ToString();
                            break;
                        }
                    }
                }

                if (txtAccessoryType.Text != null && txtAccessoryType.Text != String.Empty)
                {
                    type = txtAccessoryType.Text;
                }

                if (txtAccessoryBrand.Text != null && txtAccessoryBrand.Text != String.Empty)
                {
                    brand = txtAccessoryBrand.Text;
                }

                if (txtAccessoryQty.Text != null && txtAccessoryQty.Text != String.Empty)
                {
                    quan = txtAccessoryQty.Text;
                }

                if (txtAccessoryPrice.Text != null && txtAccessoryPrice.Text != String.Empty)
                {
                    price = txtAccessoryPrice.Text;
                }

                if (txtDate.Text != null && txtDate.Text != String.Empty)
                {
                    date = txtDate.Text;
                }

                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@quan", quan);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@accID", txtAccessoryID.Text);

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
                AccessoryGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchAccessory.Text;

            AccessoryGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                DataTable Dt = new DataTable();
                AccessoryGridView.DataSource = bindingSource1;

                foreach (DataGridViewRow row in AccessoryGridView.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (row.Cells[1].Value.ToString().Equals(searchValue))
                        {
                            // record exists   
                            Dt.Columns.Add("Accessory ID");
                            Dt.Columns.Add("Accessory Type");
                            Dt.Columns.Add("Brand");
                            Dt.Columns.Add("Quantity");
                            Dt.Columns.Add("Price");
                            Dt.Columns.Add("Date");
                            

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
                AccessoryGridView.DataSource = Dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchAccessory.Text = "";
            LoadAllCustomer();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
             txtAccessoryID.Text = "";
            txtAccessoryType.Text = "";
            txtAccessoryBrand.Text = "";
            txtAccessoryQty.Text = "";
          txtAccessoryPrice.Text = "";
            txtDate.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM Accessories WHERE AccessoryID='" + txtAccessoryID.Text + "'";
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
                AccessoryGridView.DataSource = null;
                LoadAllCustomer();
            }
        }
    }
}
