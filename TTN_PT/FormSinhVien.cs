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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Data.SqlClient;

namespace TTN_PT
{
    public partial class FormSinhVien : DevExpress.XtraEditors.XtraForm
    {

        public FormSinhVien()
        {
            InitializeComponent();
        }


        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tTN_DS.SINHVIEN' table. You can move, or remove it, as needed.
            sINHVIENTableAdapter.Fill(tTN_DS.SINHVIEN);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

            // disable button
            btnXacnhan.Enabled = false;
            btnHuybo.Enabled = false;
            btnLuu.Enabled = false;


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

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = true;
            btnHuybo.Enabled = true;

            sINHVIENGridControl.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            sINHVIENBindingSource.AddNew();
            btnThem.Enabled = false;
            txtTimkiem.Enabled = false;
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            SqlDataReader myReader;
            String strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MASV] " +
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
                        sINHVIENBindingSource.EndEdit();
                        sINHVIENBindingSource.ResetCurrentItem();

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
                        sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                        sINHVIENTableAdapter.Fill(tTN_DS.SINHVIEN);

                    }

                }
            }

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // bắt sự kiện bật tắt nút
            btnXacnhan.Enabled = btnSua.Enabled = btnLuu.Enabled =
                   btnThem.Enabled = false;
            btnXoa.Enabled = false;

            // xóa

            DialogResult dr = MessageBox.Show("Bạn có chắc chắc muốn xóa", "Xóa sinh viên", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                sINHVIENBindingSource.RemoveCurrent();
                sINHVIENTableAdapter.Update(tTN_DS.SINHVIEN);
            }
            else
            {
                sINHVIENGridControl.Enabled = true;

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
            btnSua.Enabled = false;
            txtMasv.Enabled = false;
            // tắt ds sinh viên
            sINHVIENGridControl.Enabled = false;

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tắt btn xác nhận
            btnXacnhan.Enabled = false;
            btnHuybo.Enabled = false;

            sINHVIENGridControl.Enabled = btnSua.Enabled
                = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = true;
            txtTimkiem.Enabled = txtMasv.Enabled = true;

            sINHVIENTableAdapter.Update(tTN_DS.SINHVIEN);
            sINHVIENTableAdapter.Fill(tTN_DS.SINHVIEN);
            MessageBox.Show("Cập nhật danh sách thành công");
        }

        private void btnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sINHVIENGridControl.Enabled = txtMasv.Enabled = true;

            sINHVIENBindingSource.CancelEdit();

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


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            this.sINHVIENBindingSource.Filter = "MASV LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TEN LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                sINHVIENTableAdapter.Fill(tTN_DS.SINHVIEN);
            }
        }

        private void txtTimkiem_KeyUp(object sender, KeyEventArgs e)
        {
            this.sINHVIENBindingSource.Filter = "MASV LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TEN LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                sINHVIENTableAdapter.Fill(tTN_DS.SINHVIEN);
            }
        }


    }
}