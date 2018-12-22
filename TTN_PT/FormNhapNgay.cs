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

        private void FormNhapNgay_Load(object sender, EventArgs e)
        {
            sp_9TableAdapter1.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS_VIEW.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS_VIEW.V_DS_PHANMANH);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";
            if (Program.mGroup == "TRUONG")
            {
                cbCoSo.Enabled = true;
            }
            else
            {
                cbCoSo.Enabled = false;
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dateTuNgay.Text == "")
            {
                MessageBox.Show("Ngày bắt đầu không được để trống !");
                return;
            }
            else if (dateDenNgay.Text == "")
            {
                MessageBox.Show("Ngày đến không được để trống !");
                return;
            }

            else
            {
                DateTime dt = Convert.ToDateTime(dateTuNgay.Text);
                DateTime dt1 = Convert.ToDateTime(dateDenNgay.Text);
                DANGKITHIcs dangki = new DANGKITHIcs(dt, dt1);
                ReportPrintTool ss = new ReportPrintTool(dangki);
                ss.ShowPreviewDialog();
            }
        }

        private void cbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCoSo.SelectedValue != null)
            {
                if (cbCoSo.ValueMember != "")
                {
                    if (Program.servername != cbCoSo.SelectedValue.ToString())
                    {
                        Program.servername = cbCoSo.SelectedValue.ToString();
                    }
                    if (cbCoSo.SelectedIndex != Program.mCoSo)
                    {
                        Program.mlogin = Program.remotelogin;
                        Program.password = Program.remotepassword;
                    }
                    else
                    {
                        Program.mlogin = Program.mloginDN;
                        Program.password = Program.passwordDN;
                    }
                    if (Program.KetNoi() == 0)
                    {
                        MessageBox.Show("Không thể kết nối", "Lỗi kết nối", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        sp_9TableAdapter1.Connection.ConnectionString = Program.connstr;
                    }

                }
            }
        }

    }
}