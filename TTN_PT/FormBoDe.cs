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
    public partial class FormBoDe : DevExpress.XtraEditors.XtraForm
    {
        public FormBoDe()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TrangThaiButton(bool trangthai)
        {
            txtNoiDung.Enabled = txtTrinhDo.Enabled = txtMaMH.Enabled = txtMaGV.Enabled = txtMaCH.Enabled = txtDapAn.Enabled
                = txtDan_d.Enabled = txtDan_c.Enabled = txtDan_b.Enabled = txtDan_a.Enabled = trangthai;
        }

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsBoDe.EndEdit();
            this.tableAdapterManager.UpdateAll(this.TTN_DS);

        }

        private void FormBoDe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_VIEW.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS_VIEW.V_DS_PHANMANH);
            // bODETableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tTN_DS.BODE' table. You can move, or remove it, as needed.
            this.BoDeTableAdapter.Fill(this.TTN_DS.BODE);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

            btnHuybo.Enabled = btnXacnhan.Enabled = btnLuu.Enabled = false;
            TrangThaiButton(false);  // không cho chỉnh sửa -> disable input
            btnXnSua.Visible = false; // ẩn xác nhận sửa

            if (Program.mGroup == "TRUONG")
            {
                cbCoSo.Enabled = true;
                btnLuu.Enabled = btnThem.Enabled = btnSua.Enabled = false; // nhom truong ko duoc them moi 1 bộ đề
            }
            else
            {
                cbCoSo.Enabled = false;
            }


        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrangThaiButton(true); // cho phép user nhập thông tin
            btnXacnhan.Enabled = btnHuybo.Enabled = true;

            BoDeGridControl.Enabled = btnLuu.Enabled = btnSua.Enabled = false;
            bdsBoDe.AddNew();
            btnThem.Enabled = false;
            txtMaCH.Focus();
            //txtTimkiem.Enabled = false;
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            TrangThaiButton(false); // không cho chỉnh sửa nữa -> disable input
            SqlDataReader myReader;
            string strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[CHECK_MACAUHOI] " +
                "@MACH = '" + txtMaCH.Text + "' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strlenh);
            if (myReader == null) return;
            myReader.Read();
            int value = myReader.GetInt32(0);
            if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã của câu hỏi không được để trống");
            }
            else if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã của môn học không được để trống");
            }
            else if (txtTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Trình độ không được để trống");
            }
            else if (txtMaGV.Text.Trim() == "")
            {
                MessageBox.Show("Mã của giảng viên không được để trống");
            }
            else if (txtDapAn.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án của câu hỏi không được để trống");
            }
            else if (txtDan_a.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án A không được để trống");
            }
            else if (txtDan_b.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án B không được để trống");
            }
            else if (txtDan_c.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án C không được để trống");
            }
            else if (txtDan_d.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án D không được để trống");
            }
            else if (txtNoiDung.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung câu hỏi không được để trống");
            }
            else
            {
                btnHuybo.Enabled = true;
                if (value == 1)
                {
                    MessageBox.Show("Mã câu hỏi đã tồn tại. Kiểm tra lại");
                    myReader.Close();
                }
                else
                {
                    try
                    {
                        bdsBoDe.EndEdit();
                        bdsBoDe.ResetCurrentItem();

                        // huy thao tac
                        btnLuu.Enabled = true;

                        btnThem.Enabled = false;
                        myReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi câu hỏi !" + ex.Message);
                        return;
                    }
                }

            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BoDeGridControl.Enabled = btnLuu.Enabled = btnThem.Enabled = true;

            BoDeTableAdapter.Update(TTN_DS.BODE);
            BoDeTableAdapter.Fill(TTN_DS.BODE);

            btnXacnhan.Enabled = btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnHuybo.Enabled = false;
            btnXnSua.Visible = false;

            MessageBox.Show("Cập nhật danh sách thành công");
        }

        private void btnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrangThaiButton(false);
            BoDeGridControl.Enabled = true;
            btnXnSua.Visible = false;

            bdsBoDe.CancelEdit();
            BoDeTableAdapter.Fill(TTN_DS.BODE);
            if (Program.mGroup == "TRUONG")
            {
                btnXacnhan.Enabled = btnLuu.Enabled =
                    btnThem.Enabled = false; // nhom truong ko duoc them moi bộ đề
            }
            else
            {
                btnHuybo.Enabled = btnLuu.Enabled = btnXacnhan.Enabled = false;
                btnSua.Enabled = btnThem.Enabled = true;
                //txtTimkiem.Enabled = true;
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSua.Enabled = false;
            if (txtMaGV.Text == Program.username)
            {
                TrangThaiButton(true);
                btnXacnhan.Enabled = true;
                btnHuybo.Enabled = true;
                btnXnSua.Visible = true;
                txtMaGV.Enabled = txtMaCH.Enabled = txtMaMH.Enabled = false;
                btnThem.Enabled = btnLuu.Enabled = false;
                btnSua.Enabled = false;

                // tắt ds bộ đề
                BoDeGridControl.Enabled = false;
            }
            else
            {
                MessageBox.Show("Không thể chỉnh sửa câu hỏi không phải do mình tạo !!");
                btnSua.Enabled = true;
                return;
            }

        }

        private void btnXnSua_Click(object sender, EventArgs e)
        {

            if (txtNoiDung.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung câu hỏi không được để trống");
            }
            else if (txtDan_a.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án trả lời không được để trống");
            }
            else if (txtDan_b.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án trả lời không được để trống");
            }
            else if (txtDan_c.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án trả lời không được để trống");
            }
            else if (txtDan_d.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án trả lời không được để trống");
            }
            else if (txtDapAn.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án không được để trống");
            }
            else if (txtTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Trình độ của câu hỏi không được để trống");
            }
            else
            {
                try
                {
                    bdsBoDe.EndEdit();
                    bdsBoDe.ResetCurrentItem();

                    // huy thao tac
                    btnLuu.Enabled = true;
                    btnThem.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi câu hỏi !" + ex.Message);
                    return;
                }

            }
        }

        private void cbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}