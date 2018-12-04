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
using System.Data.SqlClient;

namespace TTN_PT
{
    public partial class FormMonHoc : DevExpress.XtraEditors.XtraForm
    {
        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            MonHocTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tTN_DS.MONHOC' table. You can move, or remove it, as needed.
            this.MonHocTableAdapter.Fill(this.tTN_DS.MONHOC);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

            btnHuybo.Enabled = false;
            btnLuu.Enabled = false;
            btnXacnhan.Enabled = false;

            if (Program.mGroup == "TRUONG")
            {
                cbCoSo.Enabled = true;
                btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                cbCoSo.Enabled = false;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            bdsMonHoc.Filter = "MAMH LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TENMH LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                MonHocTableAdapter.Fill(tTN_DS.MONHOC);
            }
        }

        private void txtTimkiem_KeyUp(object sender, KeyEventArgs e)
        {
            bdsMonHoc.Filter = "MAMH LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TENMH LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                MonHocTableAdapter.Fill(tTN_DS.MONHOC);
            }
        }

        private void mAMHLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = btnSua.Enabled = btnLuu.Enabled =
                  btnThem.Enabled = false;
            btnXoa.Enabled = txtTimkiem.Enabled = false;

            // xóa
            DialogResult dr = MessageBox.Show("Bạn có chắc chắc muốn xóa", "Xóa môn học", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                bdsMonHoc.RemoveCurrent();
                MonHocTableAdapter.Update(tTN_DS.MONHOC);

                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            }
            else
            {
                if (Program.mGroup == "TRUONG")
                {
                    btnXacnhan.Enabled = btnSua.Enabled =
                        btnXoa.Enabled = btnLuu.Enabled =
                        btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
                }
                else
                {
                    btnXacnhan.Enabled = btnLuu.Enabled = false;
                    btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = true;
            btnHuybo.Enabled = true;

            btnThem.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            txtMaMH.Enabled = btnSua.Enabled = false;

            // tắt ds sinh viên
            MonHocGridControl.Enabled = false;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = false;
            btnHuybo.Enabled = false;

            MonHocGridControl.Enabled = btnSua.Enabled
                = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = true;
            txtTimkiem.Enabled = txtMaMH.Enabled = true;

            MonHocTableAdapter.Update(tTN_DS.MONHOC);
            MonHocTableAdapter.Fill(tTN_DS.MONHOC);
            MessageBox.Show("Cập nhật danh sách thành công");
        }

        private void btnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MonHocGridControl.Enabled = txtMaMH.Enabled = true;

            bdsMonHoc.CancelEdit();

            if (Program.mGroup == "TRUONG")
            {
                btnXacnhan.Enabled = btnSua.Enabled =
                    btnXoa.Enabled = btnLuu.Enabled =
                    btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                btnHuybo.Enabled = btnLuu.Enabled = btnXacnhan.Enabled = false;
                btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
                txtTimkiem.Enabled = true;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = true;
            btnHuybo.Enabled = true;

            MonHocGridControl.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            bdsMonHoc.AddNew();
            btnThem.Enabled = false;
            txtTimkiem.Enabled = false;
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            SqlDataReader myReader;
            String strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MAMH] " +
                "@MAMH = N'" + txtMaMH.Text + "' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strlenh);
            if (myReader == null) return;
            myReader.Read();
            int value = myReader.GetInt32(0);
            if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã của môn học không được để trống");
            }
            else if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên của môn học không được để trống");
            }
            else
            {
                btnHuybo.Enabled = true;
                if (value == 1)
                {
                    MessageBox.Show("Mã môn học đã tồn tại.");
                    myReader.Close();
                }
                else
                {
                    try
                    {
                        bdsMonHoc.EndEdit();
                        bdsMonHoc.ResetCurrentItem();

                        // huy thao tac
                        btnLuu.Enabled = true;

                        btnThem.Enabled = false;
                        myReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi môn học !" + ex.Message);
                        return;
                    }
                }

            }
        }
    }
}