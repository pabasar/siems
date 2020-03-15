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
using System.IO;

namespace SIEMS_2
{
    public partial class frm1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PSurasinghe\Documents\SIEMS_DB.mdf;Integrated Security=True;Connect Timeout=30");

        public frm1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sIEMS_DBDataSet.Instruments' table. You can move, or remove it, as needed.
            this.instrumentsTableAdapter.Fill(this.sIEMS_DBDataSet.Instruments);
            
        }

        private void table1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

        }

        private void table1BindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void table1BindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            
        }

        private void table1DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnExt_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "SIEMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnUpdt_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Instruments] (Instrument Name,WHO Number,SR Number,Issued Date,Issued From,Available at,Unit Price,Quantity) values ('" + txtName.Text + "','" + txtWHO.Text + "','" + txtSR.Text + "','" + date.Value.ToShortDateString() + "','" + cmbFrom.Text + "','" + cmbAt.Text + "','" + txtPrice.Text + "','" + ((UpDownBase)numQty).Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            txtName.Text = "";
            txtWHO.Text = "";
            txtSR.Text = "";
            cmbFrom.Text = "";
            cmbAt.Text = "";
            ((UpDownBase)numQty).Text = "";
            displayData();
        }

        public void displayData()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Instruments]";
            cmd.ExecuteNonQuery();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            DataGrid.DataSource = data;
            connection.Close();
        }

        private void btnRmv_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Instruments] where Name = '" + txtName.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            txtName.Text = "";
            txtWHO.Text = "";
            txtSR.Text = "";
            cmbFrom.Text = "";
            cmbAt.Text = "";
            ((UpDownBase)numQty).Text = "";
            displayData();
        }

        private void equipment_NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void equipment_NameLabel_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private static bool MAXIMIZED = false;
        private void btnMax_Click(object sender, EventArgs e)
        {
            if (MAXIMIZED)
            {
                WindowState = FormWindowState.Normal;
                MAXIMIZED = false;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                MAXIMIZED = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void btnRpt_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        

        
    }
}
