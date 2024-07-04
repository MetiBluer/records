using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace _169_Pascual_Tolentino_AppDB
{
    public partial class frmViewDoctors : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\\169_Pascual_Jeremiah_SC\\169_Pascual_Jeremiah_Tolentino_Francesz_AppDB\\dbHostpital.accdb");

        public frmViewDoctors()
        {
            InitializeComponent();
        }

        private void frmViewDoctors_Load(object sender, EventArgs e)
        {
           
            search("SELECT doctor.* FROM doctor WHERE(((doctor.Lastname) = '"+txtLname.Text+"'));");
        }

        void search(string _query)
        {
            
            OleDbCommand cmd = new OleDbCommand(_query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgrdData.DataSource = dt;
        }
        void displayRec()
        {
            string query = "SELECT * from doctor order by doctorID asc";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgrdData.DataSource = dt;
        }
    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            search(" SELECT doctor.* FROM doctor WHERE(((doctor.Lastname) = '" + txtLname.Text + "'));");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLname.Clear();
            dgrdData.DataSource = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO doctor(Firstname, Lastname, Birthday, Address, [Cellphone number], Email, Specialization) VALUES ('"+txtFname.Text+"', '"+txtLname.Text+"', '"+ txtBday.Text+"' , '"+txtAddress.Text+"' , '"+ txtCpnum.Text+"', '"+ txtEmail.Text+"', '"+ txtSpeci.Text+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Record Saved");
            displayRec();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText ="UPDATE doctor set Firstname = '" + txtFname.Text + "', Lastname = '" + txtLname.Text + "' ,Birthday = '"+txtBday.Text+"' ,Address = '"+txtAddress.Text+"' ,[Cellphone number]= '"+txtCpnum.Text+"', Email= '"+txtEmail.Text+"', Specialization= '"+txtSpeci.Text+"' WHERE doctorID = " + txtDocId.Text + " ";
            cmd.ExecuteNonQuery();
            conn.Close();
            displayRec();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM doctor WHERE doctorID =  " + txtDocId.Text +" ";
            cmd.ExecuteNonQuery();
            
            conn.Close();
            displayRec();
        }
    }
}
