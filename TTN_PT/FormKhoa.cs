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
    public partial class FormKhoa : DevExpress.XtraEditors.XtraForm
    {
        public FormKhoa()
        {
            InitializeComponent();
        }
        private void TrangThaiButton(bool trangthai)
        {
            txtMaGv.Enabled = txtTenGv.Enabled = txtHoGv.Enabled = txtDiachiGv.Enabled
                = txtMakhoa.Enabled = txtMakhoaGv.Enabled = trangthai;
        }
        private void TrangThaiButtonKhoa(bool trangthai)
        {
            txtMakhoa.Enabled = txtTenkhoa.Enabled = txtMacs.Enabled
                = btnThemKhoa.Enabled = btnXacnhankhoa.Enabled = trangthai;
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhoa.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormKhoa_Load(object sender, EventArgs e)
        {
            GiaoVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GiaoVienTableAdapter.Fill(this.tTN_DS.GIAOVIEN);
            KhoaTableAdapter.Connection.ConnectionString = Program.connstr;
            this.KhoaTableAdapter.Fill(this.tTN_DS.KHOA);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

            TrangThaiButton(false);
            // disable button
            btnXacnhanGv.Enabled = btnHuyboGv.Enabled = btnLuuGv.Enabled = false;

            btnXnsua.Visible = false; // ẩn xác nhận sửa
            // Khoa
            btnHuykhoa.Enabled = btnLuukhoa.Enabled = btnXacnhankhoa.Enabled = false;
            txtTenkhoa.Enabled = txtMakhoa.Enabled = txtMacs.Enabled = false;

            // nhóm !TRUONG không được di chuyển sang site khác
            if (Program.mGroup == "TRUONG")
            {
                cbCoSo.Enabled = true;
                btnThemKhoa.Enabled = btnThemGv.Enabled = btnSuaGv.Enabled = btnLuuGv.Enabled = btnHuyboGv.Enabled
                    = btnXoaGv.Enabled = btnXacnhanGv.Enabled = false;
            }
            else
            {
                cbCoSo.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                        KhoaTableAdapter.Connection.ConnectionString = Program.connstr;
                        KhoaTableAdapter.Fill(tTN_DS.KHOA);
                    }

                }
            }
        }

        private void btnThemGv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhanGv.Enabled = true;
            btnHuyboGv.Enabled = true;
            TrangThaiButton(true);
            TrangThaiButtonKhoa(false);
            GiaoVienGridControl.Enabled = btnSuaGv.Enabled = btnXoaGv.Enabled = btnLuuGv.Enabled = false;
            bdsGiaoVien.AddNew();
            btnThemGv.Enabled = false;
            // gan ten khoa cho gv
            txtMakhoaGv.Text = txtMakhoa.Text;
            txtMakhoaGv.Enabled = false;
        }

        private void btnXoaGv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // bắt sự kiện bật tắt nút
            btnXacnhanGv.Enabled = btnSuaGv.Enabled = btnLuuGv.Enabled =
                   btnThemGv.Enabled = false;
            btnXoaGv.Enabled = false;
            SqlDataReader myReader;
            String strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MAGV_DKI] " +
                "@MAGV = N'" + txtMaGv.Text + "' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strlenh);
            if (myReader == null) return;
            myReader.Read();
            int value = myReader.GetInt32(0);
            myReader.Close();
            if (value == 1)
            {
                MessageBox.Show("Giảng viên đã tạo câu hỏi. Không thể xóa!", "Thông báo");
                btnThemGv.Enabled = btnSuaGv.Enabled = btnXoaGv.Enabled = true;
                return;
            }
            else
            {
                // xóa
                DialogResult dr = MessageBox.Show("Bạn có chắc chắc muốn xóa", "Xóa giảng viên viên", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    bdsGiaoVien.RemoveCurrent();
                    GiaoVienTableAdapter.Update(tTN_DS.GIAOVIEN);
                    SqlDataReader reader_Login;
                    string query_login = "DECLARE	@return_value int EXEC " +
                        "@return_value = [dbo].[SP_XOALOGIN] @MAGV = N'" + txtMaGv.Text + "' " +
                        "SELECT  'Return Value' = @return_value";
                    reader_Login = Program.ExecSqlDataReader(query_login);
                    reader_Login.Close();
                    MessageBox.Show("Xóa giảng viên thành công", "Thông báo");
                    btnThemGv.Enabled = btnXoaGv.Enabled = btnSuaGv.Enabled = true;
                }
                else
                {
                    GiaoVienGridControl.Enabled = true;

                    if (Program.mGroup == "TRUONG")
                    {
                        btnXacnhanGv.Enabled = btnSuaGv.Enabled =
                            btnXoaGv.Enabled = btnLuuGv.Enabled =
                            btnThemGv.Enabled = false; // nhom truong ko duoc them moi 1 sv
                    }
                    else
                    {
                        btnXacnhanGv.Enabled = btnLuuGv.Enabled = false;
                        btnSuaGv.Enabled = btnXoaGv.Enabled = btnThemGv.Enabled = true;
                    }
                }
            }

        }

        private void btnSuaGv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhanGv.Enabled = true;
            btnHuyboGv.Enabled = true;
            TrangThaiButton(true);
            btnXnsua.Visible = true;
            btnXacnhanGv.Visible = false;
            btnThemGv.Enabled = btnXoaGv.Enabled = btnLuuGv.Enabled = txtMaGv.Enabled = txtMakhoa.Enabled = false;
            btnSuaGv.Enabled = false;

            // tắt ds sinh viên
            GiaoVienGridControl.Enabled = false;
        }

        private void btnLuuGv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tắt btn xác nhận
            btnXacnhanGv.Enabled = false;
            btnXnsua.Visible = false;
            btnXacnhanGv.Visible = true;
            btnHuyboGv.Enabled = false;
            TrangThaiButton(false);
            TrangThaiButtonKhoa(true);
            btnLuuGv.Enabled = false;
            GiaoVienGridControl.Enabled = btnSuaGv.Enabled
                = btnXoaGv.Enabled = btnThemGv.Enabled = true;
            GiaoVienTableAdapter.Update(tTN_DS.GIAOVIEN);
            GiaoVienTableAdapter.Fill(tTN_DS.GIAOVIEN);
            MessageBox.Show("Cập nhật danh sách thành công", "Thông báo");
        }

        private void btnHuyboGv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GiaoVienGridControl.Enabled = true;
            bdsGiaoVien.CancelEdit();
            btnXnsua.Visible = false;
            TrangThaiButtonKhoa(true);
            GiaoVienTableAdapter.Fill(tTN_DS.GIAOVIEN);
            if (Program.mGroup == "TRUONG")
            {
                btnXacnhanGv.Enabled = btnSuaGv.Enabled =
                    btnXoaGv.Enabled = btnLuuGv.Enabled =
                    btnThemGv.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                btnHuyboGv.Enabled = btnLuuGv.Enabled = btnXacnhanGv.Enabled = false;
                btnSuaGv.Enabled = btnXoaGv.Enabled = btnThemGv.Enabled = true;
                TrangThaiButton(false);
            }
        }

        private void btnXacnhanGv_Click(object sender, EventArgs e)
        {

            SqlDataReader myReader;
            String strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MAGV] " +
                "@MAGV = N'" + txtMaGv.Text + "' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strlenh);
            if (myReader == null) return;
            myReader.Read();
            int value = myReader.GetInt32(0);

            if (txtMaGv.Text.Trim() == "")
            {
                MessageBox.Show("Mã giảng viên không được để trống", "Thông báo");
            }
            else if (txtHoGv.Text.Trim() == "")
            {
                MessageBox.Show("Họ giảng viên không được để trống", "Thông báo");
            }
            else if (txtTenGv.Text.Trim() == "")
            {
                MessageBox.Show("Tên giảng viên không được để trống", "Thông báo");
            }
            else if (txtMakhoaGv.Text.Trim() == "")
            {
                MessageBox.Show("Mã khoa giảng viên không được để trống", "Thông báo");
            }
            else if (txtDiachiGv.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ giảng viên viên không được để trống", "Thông báo");
            }
            else
            {
                btnHuyboGv.Enabled = true;
                if (value == 1)
                {
                    MessageBox.Show("Mã giảng viên trùng. Kiểm tra lại!", "Thông báo");
                    myReader.Close();
                }
                else
                {
                    try
                    {
                        bdsGiaoVien.EndEdit();
                        bdsGiaoVien.ResetCurrentItem();

                        // huy thao tac
                        btnLuuGv.Enabled = true;
                        btnThemGv.Enabled = false;
                        TrangThaiButton(false);
                        myReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi giảng viên !" + ex.Message);
                        return;
                    }
                }
            }
        }

        private void btnThemKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoaGridControl.Enabled = false;
            btnThemKhoa.Enabled = btnLuukhoa.Enabled = false;
            txtMakhoa.Enabled = txtMacs.Enabled = txtTenkhoa.Enabled = true;

            btnXacnhankhoa.Enabled = btnHuykhoa.Enabled = true;
            bdsKhoa.AddNew();
        }

        private void btnHuykhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThemKhoa.Enabled = true;
            bdsKhoa.CancelEdit();
            btnLuukhoa.Enabled = btnHuykhoa.Enabled = btnXacnhankhoa.Enabled = false;
            KhoaGridControl.Enabled = true;
            KhoaTableAdapter.Fill(tTN_DS.KHOA);

        }

        private void btnLuukhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThemKhoa.Enabled = true;
            btnLuukhoa.Enabled = btnHuykhoa.Enabled = btnXacnhankhoa.Enabled = false;
            KhoaGridControl.Enabled = true;

            KhoaTableAdapter.Update(tTN_DS.KHOA);
            KhoaTableAdapter.Fill(tTN_DS.KHOA);
            MessageBox.Show("Cập nhật danh sách thành công", "Thông báo");
        }

        private void btnXacnhankhoa_Click(object sender, EventArgs e)
        {
            btnHuykhoa.Enabled = true;
            SqlDataReader myReader;
            string query = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MAKHOA] " +
                "@MAKHOA = N'" + txtMakhoa.Text + "' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(query);
            if (myReader == null) return;

            myReader.Read();
            int value = myReader.GetInt32(0);
            myReader.Close();
            if (value == 1)
            {
                MessageBox.Show("Mã khoa đã tồn tại. Kiểm tra lại !!!", "Thông báo");
                return;
            }
            else
            {
                if (cbCoSo.SelectedIndex == 0)
                {
                    if (txtMacs.Text == "CS1" || txtMacs.Text == "cs1")
                    {
                        try
                        {
                            btnLuukhoa.Enabled = true;
                            bdsKhoa.EndEdit();
                            bdsKhoa.ResetCurrentItem();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi ghi khoa !" + ex.Message);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã cơ sở không hợp lệ. Kiểm tra lại !!!", "Thông báo");
                        return;
                    }
                }
                else if(cbCoSo.SelectedIndex == 1)
                {
                    if (txtMacs.Text == "CS2" || txtMacs.Text == "cs2")
                    {
                        try
                        {
                            btnLuukhoa.Enabled = true;
                            bdsKhoa.EndEdit();
                            bdsKhoa.ResetCurrentItem();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi ghi khoa !" + ex.Message);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã cơ sở không hợp lệ. Kiểm tra lại !!!", "Thông báo");
                        return;
                    }
                }
                
            }
            // huy thao tac
            btnThemKhoa.Enabled = false;

        }

        private void btnXnsua_Click(object sender, EventArgs e)
        {
            if (txtHoGv.Text.Trim() == "")
            {
                MessageBox.Show("Họ giảng viên không được để trống");
            }
            else if (txtTenGv.Text.Trim() == "")
            {
                MessageBox.Show("Tên giảng viên không được để trống");
            }
            else if (txtDiachiGv.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ giảng viên không được để trống");
            }

            else
            {
                try
                {
                    bdsGiaoVien.EndEdit();
                    bdsGiaoVien.ResetCurrentItem();

                    // huy thao tac
                    btnLuuGv.Enabled = true;

                    btnThemGv.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi giảng viên !" + ex.Message);
                    return;
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMacs_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}