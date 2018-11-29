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
        private int phut, giay, socauthi;
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
            grbInfo.Enabled = false;
            timer1.Start();
            string monhoc = cbMonhoc.Items[cbMonhoc.SelectedIndex].ToString();
            vitri_cauhoi = 1;
            grbThi.Visible = true;
            SqlDataReader myReader;
            string strLenh = "DECLARE	@return_value int " + "EXEC @return_value = " +
                "[dbo].[sp_Thi] @SOCAUHOII =" + 10 + ", @MAMH = N'" + monhoc + "',"
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
                        socauthi = myReaderThi.GetInt16(4);
                        // phut = myReaderThi.GetInt16(5); // lấy số phút phải thi
                        phut = 2;
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
            timer1.Stop();
            grbCoverThi.Hide();
            MessageBox.Show("Kết thúc phần thi ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            TinhDiemSV();
        }

        private void TinhDiemSV()
        {
            for (int i = 0; i < cauhoi_thi.Count; i++)
            {
                CauHoi ch = (CauHoi)cauhoi_thi[i];
                if (ketqua[i] == ch.DAP_AN)
                {
                    demcaudung++;
                }
            }
            float diem = ((float)demcaudung / (float)10) * 10;
            Math.Round(diem, 1);
            if (diem >= 0 && diem < 0.25) { diem = 0; }
            else if (diem >= 0.25 && diem < 0.75) { diem = 0.5f; }
            else if (diem >= 0.75 && diem < 1.25) { diem = 1; }
            else if (diem >= 1.25 && diem < 2.25) { diem = 2; }
            else if (diem >= 2.25 && diem < 2.75) { diem = 2.5f; }
            else if (diem >= 2.75 && diem < 3.25) { diem = 3; }
            else if (diem >= 3.25 && diem < 3.75) { diem = 3.5f; }
            else if (diem >= 3.75 && diem < 4.25) { diem = 4; }
            else if (diem >= 4.25 && diem < 4.75) { diem = 4.5f; }
            else if (diem >= 4.75 && diem < 5.25) { diem = 5; }
            else if (diem >= 5.25 && diem < 5.75) { diem = 5.5f; }
            else if (diem >= 5.75 && diem < 6.25) { diem = 6; }
            else if (diem >= 6.25 && diem < 6.75) { diem = 6.5f; }
            else if (diem >= 6.75 && diem < 7.25) { diem = 7; }
            else if (diem >= 7.25 && diem < 7.75) { diem = 7.5f; }
            else if (diem >= 7.75 && diem < 8.25) { diem = 8; }
            else if (diem >= 8.25 && diem < 8.75) { diem = 8.5f; }
            else if (diem >= 8.75 && diem < 9.25) { diem = 9; }
            else if (diem >= 9.25 && diem < 9.75) { diem = 9.5f; }
            else diem = 10;
            MessageBox.Show("Số câu đúng là: " + demcaudung + "\nSố điểm là: " + diem, "Thông báo kết quả");
            string monhoc = cbMonhoc.Items[cbMonhoc.SelectedIndex].ToString();
            SqlDataReader myReader;
            string lenh = "EXEC  sp_GhiDiem '" + txtMasv.Text + "','" + monhoc + "','" +
                lbLanthi.Text + "','" + lbNgaythi.Text + "','" + diem + "'";
            myReader = Program.ExecSqlDataReader(lenh);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (phut >= 0)
            {
                if (giay <= 0)
                {
                    if (phut == 0)
                    {
                        timer1.Stop();
                        grbCoverThi.Hide();
                        MessageBox.Show("Kết thúc phần thi ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TinhDiemSV();
                    }
                    else
                    {
                        giay = 59;
                        phut--;
                        this.lbGiay.Text = giay.ToString() + " Giây";
                        this.lbPhut.Text = phut.ToString() + " Phút";
                    }

                }
                else if (giay < 10)
                {
                    giay--;
                    this.lbGiay.Text = "0" + giay.ToString() + " Giây";
                }
                else
                {
                    giay--;
                    this.lbGiay.Text = giay.ToString() + " Giây";
                    this.lbPhut.Text = phut.ToString() + " Phút";
                }
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