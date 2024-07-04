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
    public partial class frmViewPatients : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\\169_Pascual_Jeremiah_SC\\169_Pascual_Jeremiah_Tolentino_Francesz_AppDB\\dbHostpital.accdb");
        public frmViewPatients()
        {
            InitializeComponent();
        }

        private void frmViewPatients_Load(object sender, EventArgs e)
        {
            displayRec();
            search("SELECT patient.*FROM patient WHERE(((patient.Lastname) ='" + txtLname.Text + "'));");
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
            string query = "SELECT * from patient order by patientID  asc";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgrdData.DataSource = dt;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            search("SELECT patient.* FROM patient WHERE(((patient.Lastname) = '" +txtLname.Text + "'));");
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
            cmd.CommandText = "INSERT INTO patient(Firstname, Lastname, Sex, Birthday,Age, Address, [Cellphone number]) VALUES ('" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtSex.Text + "' , '" + txtBday.Text + "' , '" + txtAge.Text + "', '" + txtAddress.Text + "', '" + txtCnum.Text + "')";
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
            cmd.CommandText = "UPDATE patient set Firstname = '" + txtFname.Text + "', Lastname = '" + txtLname.Text + "', Sex = '"+ txtSex.Text+ "', Birthday = '"+txtBday.Text+"', Age ='"+txtAge.Text+"', Address = '"+txtAddress.Text+"', [Cellphone number] = '"+txtCnum.Text+"'  WHERE patientID = " +txtPatientId.Text + " ";
            cmd.ExecuteNonQuery();
            conn.Close();
            displayRec();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM patient WHERE patientID =  " + txtPatientId.Text + " ";
            cmd.ExecuteNonQuery();

            conn.Close();
            displayRec();
        }
    }
}
