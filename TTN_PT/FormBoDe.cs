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

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bODEBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormBoDe_Load(object sender, EventArgs e)
        {
            bODETableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tTN_DS.MONHOC' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Fill(this.tTN_DS.BODE);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

            btnHuybo.Enabled = false;
            btnLuu.Enabled = false;
            btnXacNhan.Enabled = false;

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

        private void tRINHDOLabel_Click(object sender, EventArgs e)
        {

        }

        private void tRINHDOTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cAUHOISpinEdit_EditValueChanged(object sender, EventArgs e)
        {

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

                        bODETableAdapter.Connection.ConnectionString = Program.connstr;
                        bODETableAdapter.Fill(tTN_DS.BODE);

                    }

                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacNhan.Enabled = true;
            btnHuybo.Enabled = true;

            bODEGridControl.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            //bdsMonHoc.AddNew();
            bODEBindingSource.AddNew();
            btnThem.Enabled = false;
            //txtTimkiem.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacNhan.Enabled = btnSua.Enabled = btnLuu.Enabled =
                  btnThem.Enabled = false;
            btnXoa.Enabled = false;
            //txtTimkiem.Enabled = false;

            // xóa
            DialogResult dr = MessageBox.Show("Bạn có chắc chắc muốn xóa", "Xóa bộ đề", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                bODEBindingSource.RemoveCurrent();

                bODETableAdapter.Update(tTN_DS.BODE);

                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            }
            else
            {
                if (Program.mGroup == "TRUONG")
                {
                    btnXacNhan.Enabled = btnSua.Enabled =
                        btnXoa.Enabled = btnLuu.Enabled =
                        btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
                }
                else
                {
                    btnXacNhan.Enabled = btnLuu.Enabled = false;
                    btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacNhan.Enabled = true;
            btnHuybo.Enabled = true;

            btnThem.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            txtMaCH.Enabled = btnSua.Enabled = false;
            txtMaGV.Enabled = false;
            txtMaMH.Enabled = false;
            // tắt ds sinh viên
            bODEGridControl.Enabled = false;          
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacNhan.Enabled = false;
            btnHuybo.Enabled = false;

            bODEGridControl.Enabled = btnSua.Enabled
                = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = true;
            //txtTimkiem.Enabled =
                txtMaCH.Enabled = true;

            bODETableAdapter.Update(tTN_DS.BODE);
            bODETableAdapter.Fill(tTN_DS.BODE);
            MessageBox.Show("Cập nhật danh sách thành công");
        }

        private void btnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bODEGridControl.Enabled = txtMaCH.Enabled = true;
            
            bODEBindingSource.CancelEdit();

            if (Program.mGroup == "TRUONG")
            {
                btnXacNhan.Enabled = btnSua.Enabled =
                    btnXoa.Enabled = btnLuu.Enabled =
                    btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                btnHuybo.Enabled = btnLuu.Enabled = btnXacNhan.Enabled = false;
                btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
                //txtTimkiem.Enabled = true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {        
            
            SqlDataReader myReader;
            String strlenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[sp_KiemTraMaCauHoi] " +
                "@MACH = N'" + txtMaCH.Text + "' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strlenh);
            if (myReader == null) return;
            myReader.Read();
            int value = myReader.GetInt32(0);
            myReader.Close();

            SqlDataReader myReader1;
            String strlenh1 = "DECLARE	@return_value int EXEC @return_value = [dbo].[sp_KiemTraMaMonHoc] " +
                "@MAMH = N'" + txtMaMH.Text + "' SELECT  'Return Value' = @return_value";
            myReader1 = Program.ExecSqlDataReader(strlenh1);
            if (myReader1 == null) return;
            myReader1.Read();
            int valueMH = myReader1.GetInt32(0);
            myReader1.Close();

            SqlDataReader myReader2;
            String strlenh2 = "DECLARE	@return_value int EXEC @return_value = [dbo].[sp_KiemTraMaGiaoVienTonTai] " +
                "@MAGV = N'" + txtMaGV.Text + "' SELECT  'Return Value' = @return_value";
            myReader2 = Program.ExecSqlDataReader(strlenh2);
            if (myReader2 == null) return;
            myReader2.Read();
            int valueGV = myReader2.GetInt32(0);
            myReader2.Close();

            if (txtMaCH.Text.Trim() == "")
            {
                MessageBox.Show("Mã của câu hỏi không được để trống");
            }

            else if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã của môn học không được để trống");
            }

            else if (txtTD.Text.Trim() == "")
            {
                MessageBox.Show("Trình độ không được để trống");
            }

            else if (txtND.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung câu hỏi không được để trống");
            }
            else if (txtMaGV.Text.Trim() == "")
            {
                MessageBox.Show("Mã của giáo viên không được để trống");
            }
            else if (txtA.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung đáp án A không được để trống");
            }
            else if (txtB.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung đáp án B không được để trống");
            }
            else if (txtC.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung đáp án C không được để trống");
            }
            else if (txtD.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung đáp án D không được để trống");
            }
            else if (txtDA.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án câu hỏi không được để trống");
            }
            else
            {
                btnHuybo.Enabled = true;
                if (value == 1)
                {
                    MessageBox.Show("Mã câu hỏi đã tồn tại.");
                    
                }
                else if (valueMH == 0)
                {
                    MessageBox.Show("Mã môn học chưa đúng.");

                }
                else if (valueGV == 0)
                {
                    MessageBox.Show("Mã giáo viên chưa đúng.");

                }
                else if(txtTD.Text.Trim()!="A" && txtTD.Text.Trim() != "B" && txtTD.Text.Trim() != "C")
                {
                    MessageBox.Show("Trình độ chỉ có thể là A hoặc B hoặc C.");

                }
                else if (txtDA.Text.Trim() != "A" && txtDA.Text.Trim() != "B" && txtDA.Text.Trim() != "C" && txtDA.Text.Trim() != "D")
                {
                    MessageBox.Show("Đáp án chỉ có thể là A hoặc B hoặc C hoặc D.");

                }
                else
                {
                    try
                    {

                        bODEBindingSource.EndEdit();
                        bODEBindingSource.ResetCurrentItem();

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
        }
    }
}
