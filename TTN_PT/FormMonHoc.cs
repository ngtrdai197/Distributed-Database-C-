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
            btnXnSua.Visible = false; // ẩn xác nhận sửa

            if (Program.mGroup == "TRUONG")
            {
                grbThongtinMH.Enabled = false;
                cbCoSo.Enabled = true;
                btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                cbCoSo.Enabled = false;
                txtMaMH.Enabled = txtTenMH.Enabled = false;
            }
        }

        private void cbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCoSo.SelectedValue != null)
            {
                Program.servername = cbCoSo.SelectedValue.ToString();
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
                SqlDataReader myReader;
                string query = "DECLARE	@return_value int EXEC " +
                    "@return_value = [dbo].[sp_KiemTraMaMonHoc_MonHoc_GiaoVienDangKi]" +
                    "@MAMH = N'" + txtMaMH.Text + "'SELECT  'Return Value' = @return_value";
                myReader = Program.ExecSqlDataReader(query);
                myReader.Read();
                if (myReader == null) return;
                int value = myReader.GetInt32(0);
                myReader.Close();

                if (value == 1)
                {
                    MessageBox.Show("Không thể xóa môn học này. Do môn học này được chọn để Thi.", "Thông báo");
                }
                else
                {
                    bdsMonHoc.RemoveCurrent();
                    MonHocTableAdapter.Update(tTN_DS.MONHOC);
                }
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
            txtMaMH.Enabled = txtTenMH.Enabled = true;
            btnXnSua.Visible = true;
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
            btnXnSua.Visible = false;
            MonHocGridControl.Enabled = btnSua.Enabled
                = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = true;
            txtTimkiem.Enabled = txtMaMH.Enabled = false;

            MonHocTableAdapter.Update(tTN_DS.MONHOC);
            MonHocTableAdapter.Fill(tTN_DS.MONHOC);
            MessageBox.Show("Cập nhật danh sách thành công", "Thông báo");
        }

        private void btnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MonHocGridControl.Enabled = txtMaMH.Enabled = true;
            txtMaMH.Enabled = txtTenMH.Enabled = false;
            btnXnSua.Visible = false;
            bdsMonHoc.CancelEdit();
            MonHocTableAdapter.Fill(tTN_DS.MONHOC);
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
            txtMaMH.Enabled = txtTenMH.Enabled = true;

            MonHocGridControl.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            bdsMonHoc.AddNew();
            btnThem.Enabled = false;
            txtTimkiem.Enabled = false;
            txtMaMH.Focus();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            SqlDataReader myReader;
            string strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MAMH] " +
                "@MAMH = N'" + txtMaMH.Text + "' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strlenh);
            if (myReader == null) return;
            myReader.Read();
            int value = myReader.GetInt32(0);
            myReader.Close();
            if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã của môn học không được để trống", "Thông báo");
            }
            else if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên của môn học không được để trống", "Thông báo");
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
                        txtMaMH.Enabled = txtTenMH.Enabled = false;

                        bdsMonHoc.EndEdit();
                        bdsMonHoc.ResetCurrentItem();

                        // huy thao tac
                        btnLuu.Enabled = true;

                        btnThem.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi môn học !" + ex.Message, "Thông báo");
                        return;
                    }
                }

            }
        }

        private void btnXnSua_Click(object sender, EventArgs e)
        {
            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không được để trống", "Thông báo");
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi môn học !" + ex.Message, "Thông báo");
                    return;
                }

            }
        }
    }
}