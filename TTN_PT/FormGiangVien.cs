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
    public partial class FormGiangVien : DevExpress.XtraEditors.XtraForm
    {
        public FormGiangVien()
        {
            InitializeComponent();
        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gIAOVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormGiangVien_Load(object sender, EventArgs e)
        {
            gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tTN_DS.SINHVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Fill(this.tTN_DS.GIAOVIEN);
            cbCoso.DataSource = Program.bds_dspm;
            cbCoso.DisplayMember = "TENCS";
            cbCoso.ValueMember = "TENSERVER";

            // disable button
            btnXacnhan.Enabled = false;
            btnHuybo.Enabled = false;
            btnLuu.Enabled = false;

            if (Program.mGroup == "TRUONG")
            {
                cbCoso.Enabled = true;
                btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv

            }
            else
            {
                cbCoso.Enabled = false;
            }

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = true;
            btnHuybo.Enabled = true;

            gIAOVIENGridControl.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            gIAOVIENBindingSource.AddNew();
            btnThem.Enabled = false;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tắt btn xác nhận
            btnXacnhan.Enabled = false;
            btnHuybo.Enabled = false;

            gIAOVIENGridControl.Enabled = btnSua.Enabled
                = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = true;
            gIAOVIENTableAdapter.Update(tTN_DS.GIAOVIEN);
            gIAOVIENTableAdapter.Fill(tTN_DS.GIAOVIEN);
            MessageBox.Show("Cập nhật danh sách thành công");
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
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
                MessageBox.Show("Mã giảng viên không được để trống");
            }
            else if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ giảng viên không được để trống");
            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên giảng viên không được để trống");
            }
            else if (txtMakhoa.Text.Trim() == "")
            {
                MessageBox.Show("Mã khoa giảng viên không được để trống");
            }
            else if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ giảng viên viên không được để trống");
            }
            else
            {
                btnHuybo.Enabled = true;
                if (value == 1)
                {
                    MessageBox.Show("Mã giảng viên trùng. Kiểm tra lại!");
                    myReader.Close();

                }
                else
                {
                    try
                    {
                        gIAOVIENBindingSource.EndEdit();
                        gIAOVIENBindingSource.ResetCurrentItem();

                        // huy thao tac
                        btnLuu.Enabled = true;

                        btnThem.Enabled = false;
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

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = true;
            btnHuybo.Enabled = true;

            btnThem.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            btnSua.Enabled = false;

            // tắt ds sinh viên
            gIAOVIENGridControl.Enabled = false;
        }

        private void btnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gIAOVIENGridControl.Enabled = true;

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
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            this.gIAOVIENBindingSource.Filter = "MAGV LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TEN LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                gIAOVIENTableAdapter.Fill(tTN_DS.GIAOVIEN);
            }
        }

        private void txtTimkiem_KeyUp(object sender, KeyEventArgs e)
        {
            this.gIAOVIENBindingSource.Filter = "MAGV LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TEN LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                gIAOVIENTableAdapter.Fill(tTN_DS.GIAOVIEN);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            
        }

        private void cbCoso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}