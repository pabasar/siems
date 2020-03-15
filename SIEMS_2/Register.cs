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
using System.Data.SqlServerCe;
using System.IO;

namespace SIEMS_2
{
    public partial class Register : Form
    {
        SqlCeConnection con = new SqlCeConnection(Properties.Settings.Default.RegisterDBConnectionString);
        SqlCeCommand cmd;

        public Register()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkToSign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login ob2 = new Login();
            this.Hide();
            ob2.Show();
        }

        private void btnCloseReg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinReg_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                cmd=new SqlCeCommand("SELECT * FROM User WHERE UserName='"+txtName.Text+"'", con);
                SqlCeDataAdapter da=new SqlCeDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i=ds.Tables[0].Rows.Count;
                if(i>0)
                {
                    MessageBox.Show("You have already registered");
                }
                else
                {
                    cmd=new SqlCeCommand(" INSERT INTO User (UserName,Password,Title,Hospital,Email,Phone) VALUES('"+txtName.Text+"','"+txtPass.Text+"','"+cmbTitle.Text+"','"+txtHospital.Text+"','"+txtMail.Text+"','"+txtPhone.Text+"')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("You have registered successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
