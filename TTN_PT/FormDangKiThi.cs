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

namespace TTN_PT
{
    public partial class FormDangKiThi : DevExpress.XtraEditors.XtraForm
    {
        public FormDangKiThi()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDangKy.EndEdit();
            this.tableAdapterManager.UpdateAll(this.TTN_DS);

        }

        private void FormDangKiThi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_VIEW.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS_VIEW.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'tTN_DS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.GVDangKyTableAdapter.Fill(this.TTN_DS.GIAOVIEN_DANGKY);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

            btnXacnhan.Enabled = btnHuy.Enabled = btnLuu.Enabled = false;

            // nhóm !TRUONG không được di chuyển sang site khác
            if (Program.mGroup == "TRUONG")
            {
                cbCoSo.Enabled = true;
                btnThem.Enabled = btnHuy.Enabled = btnLuu.Enabled = false;
            }
            else
            {
                cbCoSo.Enabled = false;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            gIAOVIEN_DANGKYGridControl.Enabled = false;
            bdsGVDangKy.AddNew();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (txtMaGv.Text.Trim() == "")
            {
                MessageBox.Show("Mã giảng viên không được để trống");
            }
            else if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được để trống");
            }
            else if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được để trống");
            }
            else if (txtSoCauThi.Text.Trim() == "")
            {
                MessageBox.Show("Số câu thi không được để trống");

            }
            else if (txtThoiGian.Text.Trim() == "")
            {
                MessageBox.Show("Thời thi không được để trống");
            }
            else if (txtTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Trình độ thi không được để trống");
            }
            else if (txtLanThi.Text.Trim() == "")
            {
                MessageBox.Show("Lần thi không được để trống");
            }
            else if (dtNgayThi.Text.Trim() == "")
            {
                MessageBox.Show("Ngày thi không được để trống");
            }
            else
            {
                try
                {
                    bdsGVDangKy.EndEdit();
                    bdsGVDangKy.ResetCurrentItem();

                    // huy thao tac
                    btnLuu.Enabled = true;

                    btnThem.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi đăng kí thi !" + ex.Message);
                    return;
                }

            }
        }
    }
}