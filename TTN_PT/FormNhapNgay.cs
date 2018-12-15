using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace TTN_PT
{
    public partial class FormNhapNgay : DevExpress.XtraEditors.XtraForm
    {
        public FormNhapNgay()
        {
            InitializeComponent();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTuNgay.Text == "")
            {
                MessageBox.Show("Ngày bắt đầu không được để trống !");
                return;
            }
            else if (txtDenNgay.Text == "")
            {
                MessageBox.Show("Ngày đến không được để trống !");
                return;
            }
           
            else
            {
                DateTime dt = Convert.ToDateTime(txtTuNgay.Text);
                DateTime dt1 = Convert.ToDateTime(txtDenNgay.Text);
                DANGKITHIcs dangki = new DANGKITHIcs(dt,dt1);
                ReportPrintTool ss = new ReportPrintTool(dangki);
                ss.ShowPreviewDialog();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}