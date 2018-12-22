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
    public partial class FormLop : DevExpress.XtraEditors.XtraForm
    {
        public FormLop()
        {
            InitializeComponent();
        }

        private void TrangThaiButton(bool trangthai)
        {

            txtMasv.Enabled = txtTen.Enabled = txtHo.Enabled = txtDiachi.Enabled
                = txtMalop.Enabled = nGAYSINHDateEdit.Enabled = trangthai;
        }

        private void TrangThaiButtonLop(bool trangthai)
        {
            txtLopmalop.Enabled = txtKhoamakhoa.Enabled = txtLoptenlop.Enabled = btnThemlop.Enabled = btnXacnhanlop.Enabled = trangthai;
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tTN_DS.SINHVIEN' table. You can move, or remove it, as needed.

            // tải danh sách sinh viên cơ sở khác khi di chuyển site
            SinhVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SinhVienTableAdapter.Fill(this.tTN_DS.SINHVIEN);
            // TODO: This line of code loads data into the 'tTN_DS.LOP' table. You can move, or remove it, as needed.
            LopTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LopTableAdapter.Fill(this.tTN_DS.LOP);

            this.LopTableAdapter.Fill(this.tTN_DS.LOP);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

            // disable button
            btnXacnhan.Enabled = false;
            btnHuybo.Enabled = false;
            btnLuu.Enabled = false;
            btnXnSua.Visible = false; // ẩn xác nhận sửa

            TrangThaiButton(false);

            // LỚP
            btnHuybolop.Enabled = btnLuulop.Enabled = btnXacnhanlop.Enabled = false;
            txtLopmalop.Enabled = txtKhoamakhoa.Enabled = txtLoptenlop.Enabled = false;

            if (Program.mGroup == "TRUONG")
            {
                cbCoSo.Enabled = true;
                btnSua.Enabled = btnXoa.Enabled = btnThemlop.Enabled
                    = btnLuu.Enabled = btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                cbCoSo.Enabled = false;
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
                    // cơ sở vừa chọn khác cở sở ban đầu => thay đổi tk đăng nhập sang HTKN để có thể sang phân mảnh khác
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
                        LopTableAdapter.Connection.ConnectionString = Program.connstr;
                        LopTableAdapter.Fill(tTN_DS.LOP);

                        SinhVienTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.SinhVienTableAdapter.Fill(this.tTN_DS.SINHVIEN);
                    }

                }
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = true;
            btnHuybo.Enabled = true;
            TrangThaiButton(true);
            lOPGridControl.Enabled = false;
            TrangThaiButtonLop(false);
            sINHVIENGridControl.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            bdsSinhVien.AddNew();

            // gán mã lớp cho sv ko can nhap
            txtMalop.Text = txtLopmalop.Text;
            txtMalop.Enabled = false;

            btnThem.Enabled = false;
            txtTimkiem.Enabled = false;
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            SqlDataReader myReader;
            string strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MASV] " +
                "@MASV = N'" + txtMasv.Text + "' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strlenh);
            if (myReader == null) return;
            myReader.Read();
            int value = myReader.GetInt32(0);
            if (txtMasv.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống");
            }
            else if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ sinh viên không được để trống");
            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên sinh viên không được để trống");
            }
            else if (txtMalop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp sinh viên không được để trống");
            }
            else if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ sinh viên không được để trống");
            }
            else
            {
                btnHuybo.Enabled = true;
                if (value == 1)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại.");
                    myReader.Close();
                }
                else
                {
                    try
                    {
                        bdsSinhVien.EndEdit();
                        bdsSinhVien.ResetCurrentItem();

                        // huy thao tac
                        btnLuu.Enabled = true;

                        btnThem.Enabled = false;
                        myReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi sinh viên !" + ex.Message);
                        return;
                    }
                }

            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = btnSua.Enabled = btnLuu.Enabled =
                   btnThem.Enabled = false;
            btnXoa.Enabled = txtTimkiem.Enabled = false;

            // xóa
            DialogResult dr = MessageBox.Show("Bạn có chắc chắc muốn xóa", "Xóa sinh viên", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                bdsSinhVien.RemoveCurrent();
                SinhVienTableAdapter.Update(tTN_DS.SINHVIEN);

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
            TrangThaiButton(true);
            btnHuybo.Enabled = true;
            txtMasv.Enabled = false;
            txtTimkiem.Enabled = false;
            btnXnSua.Visible = true;
            btnXacnhan.Visible = false;
            txtMalop.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            sINHVIENGridControl.Enabled = btnSua.Enabled = false;

            // tắt ds sinh viên
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = btnHuybo.Enabled = btnLuu.Enabled = false;
            btnXnSua.Visible = false;
            btnXacnhan.Visible = true;
            lOPGridControl.Enabled = true;
            TrangThaiButtonLop(true);
            btnXacnhanlop.Enabled = false;
            TrangThaiButton(false);


            btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
            sINHVIENGridControl.Enabled = txtTimkiem.Enabled = true;

            SinhVienTableAdapter.Update(tTN_DS.SINHVIEN);
            SinhVienTableAdapter.Fill(tTN_DS.SINHVIEN);
            MessageBox.Show("Cập nhật danh sách thành công");
        }

        private void btnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Visible = true;
            lOPGridControl.Enabled = true;
            TrangThaiButtonLop(true);

            btnXnSua.Visible = false;

            bdsSinhVien.CancelEdit();

            if (Program.mGroup == "TRUONG")
            {
                btnXacnhan.Enabled = btnSua.Enabled =
                    btnXoa.Enabled = btnLuu.Enabled =
                    btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                btnHuybo.Enabled = btnLuu.Enabled = btnXacnhan.Enabled = false;
                TrangThaiButton(false);
                btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
                txtTimkiem.Enabled = true;
                sINHVIENGridControl.Enabled = true;
            }
        }

        private void txtTimkiem_KeyUp(object sender, KeyEventArgs e)
        {
            this.bdsSinhVien.Filter = "MASV LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TEN LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                SinhVienTableAdapter.Fill(tTN_DS.SINHVIEN);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXnSua_Click(object sender, EventArgs e)
        {

            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ sinh viên không được để trống");
            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên sinh viên không được để trống");
            }
            else if (txtMalop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp sinh viên không được để trống");
            }
            else if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ sinh viên không được để trống");
            }
            else
            {
                try
                {
                    bdsSinhVien.EndEdit();
                    bdsSinhVien.ResetCurrentItem();

                    // huy thao tac
                    btnLuu.Enabled = true;

                    btnThem.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi sinh viên !" + ex.Message);
                    return;
                }

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemlop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lOPGridControl.Enabled = false;
            btnThemlop.Enabled = btnLuulop.Enabled = false;
            txtLopmalop.Enabled = txtKhoamakhoa.Enabled = txtLoptenlop.Enabled = true;

            btnXacnhanlop.Enabled = btnHuybolop.Enabled = true;
            bdsLop.AddNew();
        }

        private void btnXacnhanlop_Click(object sender, EventArgs e)
        {
            SqlDataReader reader_lop;
            string strlenh = "DECLARE    @return_value int EXEC    " +
                "@return_value = [dbo].[CHECK_MALOP] @MALOP = N'" + txtLopmalop.Text + "'" +
                "SELECT  'Return Value' = @return_value";
            reader_lop = Program.ExecSqlDataReader(strlenh);
            if (reader_lop == null) return;
            reader_lop.Read();
            int value = reader_lop.GetInt32(0);
            reader_lop.Close();

            try
            {
                if (value == 1)
                {
                    MessageBox.Show("Mã lớp nhập vào đã tồn tại. Kiểm tra lại !!!", "Thông báo");
                    txtLopmalop.Focus(); return;
                }
                else
                {
                    bdsLop.EndEdit();
                    bdsLop.ResetCurrentItem();
                    btnHuybolop.Enabled = true;
                    btnLuulop.Enabled = true;
                }
                btnThemlop.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi sinh viên !" + ex.Message);
                return;
            }
        }

        private void btnLuulop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThemlop.Enabled = true;
            btnLuulop.Enabled = btnHuybolop.Enabled = btnXacnhanlop.Enabled = false;
            lOPGridControl.Enabled = true;

            LopTableAdapter.Update(tTN_DS.LOP);
            LopTableAdapter.Fill(tTN_DS.LOP);
            MessageBox.Show("Cập nhật danh sách thành công");
            txtLopmalop.Enabled = txtKhoamakhoa.Enabled = txtLoptenlop.Enabled = true;
        }

        private void btnHuybolop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThemlop.Enabled = true;
            bdsLop.CancelEdit();
            btnLuulop.Enabled = btnHuybolop.Enabled = btnXacnhanlop.Enabled = false;
            txtLopmalop.Enabled = txtKhoamakhoa.Enabled = txtLoptenlop.Enabled = true;
            lOPGridControl.Enabled = true;
        }

        private void tENLabel_Click(object sender, EventArgs e)
        {

        }
    }
}