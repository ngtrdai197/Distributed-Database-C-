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
    public partial class FormInDiemTheoMonHoc : DevExpress.XtraEditors.XtraForm
    {
        public FormInDiemTheoMonHoc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTenmon.Text == "")
            {
                MessageBox.Show("Tên môn học không được để trống !");
                return;
            }else if(txtTenlop.Text == "")
            {
                MessageBox.Show("Tên lớp không được để trống !");
                return;
            }else if(txtLanthi.Text == "")
            {
                MessageBox.Show("Lần thi không được để trống !");
                return;
            }
            else
            {
                int lanthi = Int32.Parse(txtLanthi.Text);
                INDIEMTHEOMON ii = new INDIEMTHEOMON(txtTenlop.Text, txtTenmon.Text, lanthi);
                ReportPrintTool ss = new ReportPrintTool(ii);
                ss.ShowPreviewDialog();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}