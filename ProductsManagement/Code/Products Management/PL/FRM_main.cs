using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Management.PL
{
    public partial class FRM_main : Form
    {

        private static FRM_main frm;
        static void frm_FormCLosed(object sender, FormClosedEventArgs e)
        {

            frm = null;
        }

        public static FRM_main getMainForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new FRM_main();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormCLosed);

                }
                return frm;
            }

        }
        public FRM_main()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.المنتجاتToolStripMenuItem.Enabled = false;
            this.العملاءToolStripMenuItem.Enabled = false;
            this.المستخدمونToolStripMenuItem.Enabled = false;
            this.إنشاءنسخةإحتياطيةToolStripMenuItem.Enabled = false;
            this.إستعادةنسخةمحفوظةToolStripMenuItem.Enabled = false;

        }

        private void FRM_main_Load(object sender, EventArgs e)
        {

        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMLogin FRM = new FRMLogin();
            FRM.ShowDialog();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void اضافةمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.ShowDialog();
        }

        private void إدارهالمونتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS frm = new FRM_PRODUCTS();
            frm.ShowDialog();
        }

        private void إدارهالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frm = new FRM_CATEGORIES();

            frm.ShowDialog();

        }

        private void إدارهالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frm = new FRM_CATEGORIES();
            frm.ShowDialog();
        }

        private void إضافةبيعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS frm = new FRM_ORDERS();
            frm.ShowDialog();
        }

        private void إدارهالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDER_LIST frm = new FRM_ORDER_LIST();
            frm.ShowDialog();

        }

        private void إضافهمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();   
        }

        private void إضافةعميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void إدارهالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USER_LIST frm = new FRM_USER_LIST();
            frm.ShowDialog();
        }

        private void إنشاءنسخةإحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_BAKUP frm = new FRM_BAKUP();
            frm.ShowDialog();
        }

        private void إستعادةنسخةمحفوظةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_RESTORE frm = new FRM_RESTORE();
            frm.ShowDialog();
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
