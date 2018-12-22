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
            GiaoVien_DangKyGridControl.Enabled = false;
            bdsGVDangKy.AddNew();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (txtMaGv.Text.Trim() == "")
            {
                MessageBox.Show("Mã giảng viên không được để trống");
                txtMaGv.Focus(); return;
            }
            else if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được để trống");
                txtMaLop.Focus(); return;
            }
            else if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được để trống");
                txtMaMH.Focus(); return;
            }
            else if (txtSoCauThi.Text.Trim() == "")
            {
                MessageBox.Show("Số câu thi không được để trống");
                txtSoCauThi.Focus(); return;
            }
            else if (txtThoiGian.Text.Trim() == "")
            {
                MessageBox.Show("Thời thi không được để trống");
                txtThoiGian.Focus(); return;
            }
            else if (txtTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Trình độ thi không được để trống");
                txtTrinhDo.Focus(); return;
            }
            else if (txtLanThi.Text.Trim() == "")
            {
                MessageBox.Show("Lần thi không được để trống");
                txtLanThi.Focus(); return;
            }
            else if (dtNgayThi.Text.Trim() == "")
            {
                MessageBox.Show("Ngày thi không được để trống");
                dtNgayThi.Focus(); return;
            }
            else if (txtTrinhDo.Text.Trim() != "A" && txtTrinhDo.Text.Trim() != "B" && txtTrinhDo.Text.Trim() != "C")
            {
                MessageBox.Show("Trình độ là A hoặc B hoặc C.");
                txtTrinhDo.Focus(); return;
            }
            else
            {
                SqlDataReader myReader;
                string strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[sp_KiemTraMaMH_GiangVienDangKi_BoDe] " +
                    "@MAMH = N'" + txtMaMH.Text + "' SELECT  'Return Value' = @return_value";
                myReader = Program.ExecSqlDataReader(strlenh);
                if (myReader == null) return;
                myReader.Read();
                int value = myReader.GetInt32(0);
                myReader.Close();
                if (value == 0)
                {
                    MessageBox.Show("Môn học đăng ký không tồn tại trong bộ đề. Kiểm tra lại !!!", "Thông báo");
                    txtMaMH.Focus(); return;
                }
                else
                {
                    // KIEM TRA LOP TON TAI KHONG?
                    SqlDataReader reader_lop;
                    string query_lop = "DECLARE    @return_value int EXEC    " +
                        "@return_value = [dbo].[CHECK_MALOP] @MALOP = N'" + txtMaLop.Text + "'" +
                        "SELECT  'Return Value' = @return_value";
                    reader_lop = Program.ExecSqlDataReader(query_lop);
                    if (reader_lop == null) return;
                    reader_lop.Read();
                    int value_lop = reader_lop.GetInt32(0);
                    reader_lop.Close();
                    if (value_lop == 1) // ton tai lop trong db
                    {
                        // KIEM TRA GIANG VIEN TON TAI KHONG?
                        SqlDataReader reader_gv;
                        String query_gv = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MAGV] " +
                            "@MAGV = N'" + txtMaGv.Text + "' SELECT  'Return Value' = @return_value";
                        reader_gv = Program.ExecSqlDataReader(query_gv);
                        if (reader_gv == null) return;
                        reader_gv.Read();
                        int value_gv = reader_gv.GetInt32(0);
                        reader_gv.Close();
                        if (value_gv == 1)
                        {
                            SqlDataReader myReader_KTTTT;
                            string query = "DECLARE	@return_value int EXEC " +
                                "@return_value = [dbo].[sp_KiemTraThongTindangKiThi]" +
                                " @MALOP = N'" + txtMaLop.Text + "'," +
                                "@MAMH = N'" + txtMaMH.Text + "'," +
                                "@LAN = " + txtLanThi.Text + "" +
                                "SELECT  'Return Value' = @return_value";
                            myReader_KTTTT = Program.ExecSqlDataReader(query);

                            if (myReader_KTTTT == null) return;
                            myReader_KTTTT.Read();
                            int value_KTTTT = myReader_KTTTT.GetInt32(0);
                            myReader_KTTTT.Close();
                            btnHuy.Enabled = true;
                            if (value_KTTTT == 1)
                            {
                                MessageBox.Show("Thông tin đăng kí đã tồn tại.");
                                btnLuu.Enabled = false;
                                return;
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
                        else
                        {
                            MessageBox.Show("Mã giảng viên không tồn tại. Kiểm tra lại !!!");
                            txtMaGv.Focus(); return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Mã lớp không tồn tại. Kiểm tra lại !!!");
                        txtMaLop.Focus(); return;
                    }

                }
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GiaoVien_DangKyGridControl.Enabled = txtMaMH.Enabled = true;

            bdsGVDangKy.CancelEdit();

            if (Program.mGroup == "TRUONG")
            {
                btnXacnhan.Enabled = btnLuu.Enabled =
                    btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                btnHuy.Enabled = btnLuu.Enabled = btnXacnhan.Enabled = false;
                btnThem.Enabled = true;
                //txtTimkiem.Enabled = true;
            }
        }
    }
}