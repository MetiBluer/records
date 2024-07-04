using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _169_Pascual_Tolentino_AppDB
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboSearch.Items.Add("Patient");
            cboSearch.Items.Add("Doctor");

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if(cboSearch.Text == "Patient")
            {
                frmViewPatients pat = new frmViewPatients();
                pat.ShowDialog();
            }
            else if(cboSearch.Text == "Doctor")
            {

                frmViewDoctors doc = new frmViewDoctors();
                doc.ShowDialog();
            }
                        
                       
            
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
        }
    }
}
