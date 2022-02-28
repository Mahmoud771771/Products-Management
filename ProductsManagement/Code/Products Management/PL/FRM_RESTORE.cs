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

namespace Products_Management.PL
{
    public partial class FRM_RESTORE : Form
    {
        SqlConnection con = new SqlConnection(@"Server=.;Database=master;Integrated Security=true");
        SqlCommand cmd;
        public FRM_RESTORE()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtfileName.Text = openFileDialog1.FileName; // return to path select filename
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
           // try
           // {
               
                string strQurey = "ALTER Database ProductDB SET OFFLINE WITH ROLLBACK IMMEDIATE; RESTORE DATABASE ProductDB FROM DISK='" + txtfileName.Text + "'";
                cmd = new SqlCommand(strQurey, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم إستعادة النسخه الاحتياطية بنجاح ", "إستعادة نسخة إحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           // }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
