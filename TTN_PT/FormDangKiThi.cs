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
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormDangKiThi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tTN_DS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.GVDangKyTableAdapter.Fill(this.tTN_DS.GIAOVIEN_DANGKY);

            GVDangKyTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tTN_DS.MONHOC' table. You can move, or remove it, as needed.
            btnSua.Enabled = btnXoa.Enabled = false;
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = true;
            btnHuybo.Enabled = true;
            gIAOVIEN_DANGKYGridControl.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            bdsGVDangKy.AddNew();
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            gIAOVIEN_DANGKYGridControl.Enabled = true;

            bdsGVDangKy.CancelEdit();

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
                //txtTimkiem.Enabled = true;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //btnXacnhan.Enabled = btnSua.Enabled = btnLuu.Enabled =
            //     btnThem.Enabled = false;
            //btnXoa.Enabled = false;
            ////txtTimkiem.Enabled = false;

            //// xóa
            //DialogResult dr = MessageBox.Show("Bạn có chắc chắc muốn xóa", "Xóa đăng kí.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            //if (dr == DialogResult.Yes)
            //{
            //    bdsGVDangKy.RemoveCurrent();
            //    GVDangKyTableAdapter.Update(tTN_DS.GIAOVIEN_DANGKY);

            //    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            //}
            //else
            //{
            //    if (Program.mGroup == "TRUONG")
            //    {
            //        btnXacnhan.Enabled = btnSua.Enabled =
            //            btnXoa.Enabled = btnLuu.Enabled =
            //            btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            //    }
            //    else
            //    {
            //        btnXacnhan.Enabled = btnLuu.Enabled = false;
            //        btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
            //    }
            //}
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //btnXacnhan.Enabled = true;
            //btnHuybo.Enabled = true;

            //btnThem.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            //txtMaMH.Enabled = btnSua.Enabled = false;

            //// tắt ds sinh viên
            //MonHocGridControl.Enabled = false;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = false;
            btnHuybo.Enabled = false;

            gIAOVIEN_DANGKYGridControl.Enabled
                = btnLuu.Enabled = btnThem.Enabled = true;
            GVDangKyTableAdapter.Update(tTN_DS.GIAOVIEN_DANGKY);
            GVDangKyTableAdapter.Fill(tTN_DS.GIAOVIEN_DANGKY);
            MessageBox.Show("Cập nhật danh sách thành công");


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text.Trim() == "")
            {
                MessageBox.Show("Mã giáo viên không được để trống.");

            }
            else if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã của môn học không được để trống.");
            }
            else if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được để trống.");
            }
            else if (txtTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Trình độ không được để trống.");
            }
            else if (txtNgayThi.Text.Trim() == "")
            {
                MessageBox.Show("Ngày thi không được để trống.");
            }
            else if (txtLan.Text.Trim() == "")
            {
                MessageBox.Show("Lần thi không được để trống.");
            }
            else if (txtSoCau.Text.Trim() == "")
            {
                MessageBox.Show("Số câu không được để trống.");
            }
            else if (txtThoiGian.Text.Trim() == "")
            {
                MessageBox.Show("Thời gian không được để trống.");
            }
            else if (txtTrinhDo.Text.Trim() != "A" && txtTrinhDo.Text.Trim() != "B" && txtTrinhDo.Text.Trim() != "C")
            {
                MessageBox.Show("Trình độ là A hoặc B hoặc C.");
            }

            else
            {

                SqlDataReader myReader;
                String strlenh = "DECLARE	@return_value int EXEC " +
                    "@return_value = [dbo].[sp_KiemTraThongTindangKiThi]" +
                    " @MALOP = N'" + txtMaLop.Text + "'," +
                    "@MAMH = N'" + txtMaMH.Text + "'," +
                    "@LAN = " + txtLan.Text + "" +
                    "SELECT  'Return Value' = @return_value";
                myReader = Program.ExecSqlDataReader(strlenh);

                if (myReader == null) return;
                myReader.Read();
                int value = myReader.GetInt32(0);

                btnHuybo.Enabled = true;
                if (value == 1)
                {
                    MessageBox.Show("Thông tin đăng kí đã tồn tại.");
                    myReader.Close();
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
                        myReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi thông tin đăng kí thi !" + ex.Message);
                        return;
                    }
                }

            }
        }
    }
}