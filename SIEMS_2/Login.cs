using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace SIEMS_2
{
    public partial class Login : Form
    {
        SqlCeConnection con = new SqlCeConnection(Properties.Settings.Default.RegisterDBConnectionString);
        SqlCeDataAdapter da;
        SqlCeCommand cmd;

        public Login()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnMin_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("SELECT * FROM User WHERE UserName='" + txtUser.Text + "' and Password='" + txtPass.Text + "'", con);
                da = new SqlCeDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i == 1)
                {
                    frm1 ob1 = new frm1();
                    ob1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You are not registered");
                    Register ob2 = new Register();
                    ob2.Show();
                    this.Hide();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register ob3 = new Register();
            this.Hide();
            ob3.Show();
        }
    }
}
