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

        private void FormInDiemTheoMonHoc_Load(object sender, EventArgs e)
        {
            sp_8TableAdapter.Connection.ConnectionString = Program.connstr;
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

        private void v_DS_PHANMANHComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
                        sp_8TableAdapter.Connection.ConnectionString = Program.connstr;
                    }

                }
            }
        }
        
    }
}