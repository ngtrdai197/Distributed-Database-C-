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
using System.Collections;
using TTN_PT.Models;

namespace TTN_PT
{
    public partial class FormThi : DevExpress.XtraEditors.XtraForm
    {
        private int phut, giay;
        private int vitri_cauhoi = 1;
        private int demcaudung = 0;
        private string cautraloi = "\0"; // mặc định chưa trả lời là 0
        //private ArrayList ketqua = new ArrayList(); // danh sách chứa câu trả lời của sinh viên
        private ArrayList dapan_bode = new ArrayList(); // danh sách đáp án từ bộ đề
        private ArrayList cauhoi_thi = new ArrayList(); // danh sách câu hỏi từ bộ đề
        private string[] ketqua = new string[100];

        public FormThi()
        {
            InitializeComponent();

            grbThi.Visible = false;
            grbThoigianthi.Visible = false;
            txtHoten.Visible = txtMalop.Visible = txtTenlop.Visible = false;
            lbHoten.Visible = lbMalop.Visible = lbTenlop.Visible = false;
            btnThi.Enabled = false;

            // gán mặc định sinh viên chưa trả lời
            for (int i = 0; i < cauhoi_thi.Count; i++)
            {
                ketqua[i] = "\0";
            }
        }

        private void btnThi_Click(object sender, EventArgs e)
        {
            vitri_cauhoi = 1;
            grbThi.Visible = true;
            SqlDataReader myReader;
            string strLenh = "DECLARE	@return_value int " + "EXEC @return_value = " +
                "[dbo].[sp_Thi] @SOCAUHOII =" + 3 + ", @MAMH = N'MMTCB',"
                + "@KHOA = N'CNTT', @TRINHDO = N'A' SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strLenh);
            if (myReader == null) return;
            else
            {
                // đọc dữ liệu đến hết => false break
                while (myReader.Read() == true)
                {
                    // tạo đối tượng để lưu câu hỏi nhận được từ db
                    CauHoi ch = new CauHoi();
                    ch.CauHoiId = myReader.GetInt32(0);
                    ch.MaMH = myReader.GetString(1);
                    ch.TrinhDo = myReader.GetString(2);
                    ch.NoiDung = myReader.GetString(3);
                    ch.DA_A = myReader.GetString(4);
                    ch.DA_B = myReader.GetString(5);
                    ch.DA_C = myReader.GetString(6);
                    ch.DA_D = myReader.GetString(7);
                    ch.DAP_AN = myReader.GetString(8);
                    ch.MaGV = myReader.GetString(9);

                    // thêm vào mảng
                    cauhoi_thi.Add(ch);
                }
                myReader.Close(); // ngắt kết nối

                // đọc câu hỏi đầu tiên trong mảng câu hỏi nhận được từ db
                CauHoi cauhoi = (CauHoi)cauhoi_thi[vitri_cauhoi - 1];
                txtCauHoi.Text = "Câu " + vitri_cauhoi + " : " + cauhoi.NoiDung;
                lbDA_A.Text = cauhoi.DA_A;
                lbDA_B.Text = cauhoi.DA_B;
                lbDA_C.Text = cauhoi.DA_C;
                lbDA_D.Text = cauhoi.DA_D;

            }
        }


        private void txtMasv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnThi.Enabled = true;
                SqlDataReader myReader;
                string strlenh = "DECLARE	@return_value int " +
                    "EXEC @return_value = [dbo].[SP_LAYTHONGTINSINHVIEN]@MASV = N'" + txtMasv.Text + "'" +
                    "SELECT  'Return Value' = @return_value";
                myReader = Program.ExecSqlDataReader(strlenh);
                if (myReader == null) return;
                else
                {
                    myReader.Read();
                    txtHoten.Text = myReader.GetString(0) + " " + myReader.GetString(1);
                    txtMalop.Text = myReader.GetString(2);
                    txtTenlop.Text = myReader.GetString(3);
                    myReader.Close();
                }


                SqlDataReader myReaderThi;
                string strlenh2 = "DECLARE	@return_value int EXEC @return_value = [dbo].[SP_THONGTINTHI]" +
                    "@MALOP = N'" + txtMalop.Text + "' SELECT  'Return Value' = @return_value";

                myReaderThi = Program.ExecSqlDataReader(strlenh2);
                if (myReaderThi == null) return;
                else
                {
                    while (myReaderThi.Read() == true)
                    {
                        cbMonhoc.Items.Add(myReaderThi.GetString(0));
                        lbNgaythi.Text = myReaderThi.GetSqlDateTime(3).ToString();
                        lbPhut.Text = myReaderThi.GetInt16(5).ToString() + " Phút"; // lấy số phút phải thi
                    }
                    myReaderThi.Close();
                    grbThoigianthi.Visible = true;
                    cbMonhoc.SelectedIndex = 0;
                }

                txtHoten.Enabled = txtMalop.Enabled = txtTenlop.Enabled = txtMasv.Enabled = false;
                txtHoten.Visible = txtMalop.Visible = txtTenlop.Visible = true;
                lbHoten.Visible = lbMalop.Visible = lbTenlop.Visible = true;
            }

        }

        private void btnTieptheo_Click(object sender, EventArgs e)
        {
            // tạo object đáp án được chọn
            ketqua[vitri_cauhoi - 1] = cautraloi;
            vitri_cauhoi += 1;
            XuLyRadioButton(false);
            cautraloi = "\0";
            // nếu vị trí đang ở câu cuối cùng => chuyển về câu hỏi đầu tiên
            if (vitri_cauhoi > cauhoi_thi.Count)
            {
                vitri_cauhoi = 1;
                if (ketqua[vitri_cauhoi - 1] == "A")
                {
                    rdB_A.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "B")
                {
                    rdB_B.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "C")
                {
                    rdB_C.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "D")
                {
                    rdB_D.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "\0")
                {
                    XuLyRadioButton(false);
                }
                CauHoi cauhoi = (CauHoi)cauhoi_thi[vitri_cauhoi - 1];
                txtCauHoi.Text = "Câu " + vitri_cauhoi + " : " + cauhoi.NoiDung;
                lbDA_A.Text = cauhoi.DA_A;
                lbDA_B.Text = cauhoi.DA_B;
                lbDA_C.Text = cauhoi.DA_C;
                lbDA_D.Text = cauhoi.DA_D;
            }
            else
            {

                if (ketqua[vitri_cauhoi - 1] == "A")
                {
                    rdB_A.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "B")
                {
                    rdB_B.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "C")
                {
                    rdB_C.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "D")
                {
                    rdB_D.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "\0")
                {
                    XuLyRadioButton(false);
                }
                // di chuyển đến câu hỏi tiếp theo
                CauHoi cauhoi = (CauHoi)cauhoi_thi[vitri_cauhoi - 1];
                txtCauHoi.Text = "Câu " + vitri_cauhoi + " : " + cauhoi.NoiDung;
                lbDA_A.Text = cauhoi.DA_A;
                lbDA_B.Text = cauhoi.DA_B;
                lbDA_C.Text = cauhoi.DA_C;
                lbDA_D.Text = cauhoi.DA_D;
            }

        }

        private void btnLuilai_Click(object sender, EventArgs e)
        {
            // tạo object đáp án được chọn
            ketqua[vitri_cauhoi - 1] = cautraloi;
            vitri_cauhoi -= 1;
            XuLyRadioButton(false);
            cautraloi = "\0";

            // nếu vị trí đang ở câu cuối cùng => chuyển về câu hỏi đầu tiên
            if (vitri_cauhoi == 0)
            {
                vitri_cauhoi = cauhoi_thi.Count;
                if (ketqua[vitri_cauhoi - 1] == "A")
                {
                    rdB_A.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "B")
                {
                    rdB_B.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "C")
                {
                    rdB_C.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "D")
                {
                    rdB_D.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "\0")
                {
                    XuLyRadioButton(false);
                }
                CauHoi cauhoi = (CauHoi)cauhoi_thi[vitri_cauhoi - 1];
                txtCauHoi.Text = "Câu " + vitri_cauhoi + " : " + cauhoi.NoiDung;
                lbDA_A.Text = cauhoi.DA_A;
                lbDA_B.Text = cauhoi.DA_B;
                lbDA_C.Text = cauhoi.DA_C;
                lbDA_D.Text = cauhoi.DA_D;
            }
            else
            {
                if (ketqua[vitri_cauhoi - 1] == "A")
                {
                    rdB_A.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "B")
                {
                    rdB_B.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "C")
                {
                    rdB_C.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "D")
                {
                    rdB_D.Checked = true;
                }
                else if (ketqua[vitri_cauhoi - 1] == "\0")
                {
                    XuLyRadioButton(false);
                }
                // di chuyển đến câu hỏi tiếp theo
                CauHoi cauhoi = (CauHoi)cauhoi_thi[vitri_cauhoi - 1];
                txtCauHoi.Text = "Câu " + vitri_cauhoi + " : " + cauhoi.NoiDung;
                lbDA_A.Text = cauhoi.DA_A;
                lbDA_B.Text = cauhoi.DA_B;
                lbDA_C.Text = cauhoi.DA_C;
                lbDA_D.Text = cauhoi.DA_D;
            }
        }

        public void XuLyRadioButton(Boolean kt)
        {
            rdB_A.Checked = rdB_B.Checked = rdB_C.Checked = rdB_D.Checked = kt;
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.gIAOVIEN_DANGKYBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormThi_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void rdB_A_CheckedChanged(object sender, EventArgs e)
        {
            cautraloi = "A";
        }

        private void rdB_B_CheckedChanged(object sender, EventArgs e)
        {
            cautraloi = "B";

        }

        private void rdB_C_CheckedChanged(object sender, EventArgs e)
        {
            cautraloi = "C";

        }

        private void rdB_D_CheckedChanged(object sender, EventArgs e)
        {
            cautraloi = "D";

        }

        private void btnNopbaithi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cauhoi_thi.Count; i++)
            {
                CauHoi ch = (CauHoi)cauhoi_thi[i];
                if (ketqua[i] == ch.DAP_AN)
                {
                    demcaudung++;
                }
            }
            MessageBox.Show("Co: " + demcaudung); // lưu được số câu đúng
        }

        private void cbMonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string monhoc = cbMonhoc.Items[cbMonhoc.SelectedIndex].ToString();
            SqlDataReader myReader;
            string strLenh = "DECLARE @return_value int " +
                "EXEC @return_value = [dbo].[SP_LAYLANTHITHEOMH]" +
                "@MAMH = N'" + monhoc + "' " + "SELECT  'Return Value' = @return_value";
            myReader = Program.ExecSqlDataReader(strLenh);
            if (myReader == null) return;
            else
            {
                myReader.Read();
                lbLanthi.Text = myReader.GetInt16(0).ToString();
                myReader.Close();
            }
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            //this.gIAOVIEN_DANGKYBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }
    }
}