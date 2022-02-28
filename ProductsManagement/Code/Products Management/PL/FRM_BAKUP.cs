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
    public partial class FRM_BAKUP : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=ProductDB;Integrated Security=true");
        SqlCommand cmd; 
        public FRM_BAKUP()
        { 
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {

                txtfileName.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = txtfileName.Text + "\\ProductDB" + DateTime.Now.ToShortDateString().Replace('/', '-');
                string strQurey = "BACKUP DATABASE ProductDB TO DISK='" + fileName + ".bak'";
                cmd = new SqlCommand(strQurey, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم إنشاء النسخه الاحتياطية بنجاح ", "إنشاء نسخة إحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
