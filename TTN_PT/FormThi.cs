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
        string role;
        private int vitri_cauhoi = 1;
        private string cautraloi = "\0"; // mặc định chưa trả lời là 0
        //private ArrayList ketqua = new ArrayList(); // danh sách chứa câu trả lời của sinh viên
        //private ArrayList dapan_bode = new ArrayList(); // danh sách đáp án từ bộ đề
        private ArrayList cauhoi_thi = new ArrayList(); // danh sách câu hỏi từ bộ đề
        private string[] ketqua = new string[100];

        public FormThi()
        {
            InitializeComponent();
            // nhóm quyền có thể thi và được thi thử
            role = Program.mGroup;
            if (role != "SINHVIEN")
            {
                btnNopbaithi.Enabled = false; // nhóm giảng viên chỉ được thi thử và ko đc ghi điểm
            }

            grbThoigianthi.Visible = false;
            grbCoverThi.Visible = false;

            txtHoten.Visible = txtMalop.Visible = txtTenlop.Visible = false;
            lbHoten.Visible = lbMalop.Visible = lbTenlop.Visible = false;
            btnThi.Enabled = false;

            // gán mặc định sinh viên chưa trả lời
            //for (int i = 0; i < cauhoi_thi.Count; i++)
            //{
            //    ketqua[i] = "\0";
            //}
        }

        private void btnThi_Click(object sender, EventArgs e)
        {

            SqlDataReader reader_MaLopThi;
            string query = "DECLARE	@return_value int " + "EXEC @return_value = " +
                "[dbo].[KiemTramaLopSV_GiangVienDangKi] @MASV =N'" + txtMasv.Text + "' " +
                "SELECT  'Return Value' = @return_value";
            reader_MaLopThi = Program.ExecSqlDataReader(query);
            if (reader_MaLopThi == null) return;
            else
            {
                reader_MaLopThi.Read();
                int value = reader_MaLopThi.GetInt32(0);
                reader_MaLopThi.Close();
                if (value == 0) // lớp chưa được đăng kí thi => không cho thi
                {
                    MessageBox.Show("Sinh viên không thuộc đợt thi này", "Thông báo");
                }
                else // lớp được đăng kí thi
                {

                    // sinh viên đã thi và có điểm trong table bảng điểm
                    SqlDataReader reader_SVThi;
                    string monhoc = cbMonhoc.Items[cbMonhoc.SelectedIndex].ToString();
                    string query_SVThi = "DECLARE	@return_value int EXEC " +
                        "@return_value = [dbo].[KiemTraSinhVienThiChua] " +
                        "@MASV = N'" + txtMasv.Text + "'," +
                        "@MAMH = N'" + monhoc + "'," +
                        "@LAN = '" + lbLanthi.Text + "' SELECT  'Return Value' = @return_value";
                    reader_SVThi = Program.ExecSqlDataReader(query_SVThi);
                    if (reader_SVThi == null) return;
                    else
                    {

                        reader_SVThi.Read();
                        int value_SVThi = reader_SVThi.GetInt32(0);
                        reader_SVThi.Close();
                        if (value_SVThi == 1)
                        {
                            MessageBox.Show("Sinh viên đã thi rồi.", "Thông báo");
                        }
                        else
                        {
                            SqlDataReader reader_LayTrinhDo;
                            string query_LayTrinhDo = "DECLARE	@return_value int " +
                                "EXEC @return_value = [dbo].[sp_TraVeTrinhDo]" +
                                "@MALOP = N'" + txtMalop.Text + "',@MAMH = N'" + monhoc + "',@lan = '" + lbLanthi.Text + "'" +
                                "SELECT  'Return Value' = @return_value";
                            reader_LayTrinhDo = Program.ExecSqlDataReader(query_LayTrinhDo);
                            if (reader_SVThi == null) return;

                            reader_LayTrinhDo.Read();
                            string trinhDo = reader_LayTrinhDo.GetString(0);
                            reader_LayTrinhDo.Close();
                            // sinh viên chưa được thi
                            grbInfo.Enabled = false;
                            timer1.Start();
                            vitri_cauhoi = 1;
                            grbCoverThi.Visible = true;

                            SqlDataReader myReader;
                            // sp lấy thông tin thi
                            string strLenh = "DECLARE	@return_value int " + "EXEC @return_value = " +
                                "[dbo].[sp_Thi] @SOCAUHOII =" + socauthi + ", @MAMH = N'" + monhoc + "',"
                                + "@TRINHDO = N'" + trinhDo + "' SELECT  'Return Value' = @return_value";
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
                    }

                }
            }

        }


        private void txtMasv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SqlDataReader myReader;
                string strlenh = "DECLARE	@return_value int " +
                    "EXEC @return_value = [dbo].[SP_LAYTHONGTINSINHVIEN]@MASV = N'" + txtMasv.Text + "'" +
                    "SELECT  'Return Value' = @return_value";
                myReader = Program.ExecSqlDataReader(strlenh);
                if (myReader == null) return;
                else
                {
                    myReader.Read();
                    bool exists = myReader.HasRows; // trả về true nếu có 1 hoặc nhiều dòng dữ liệuc
                    if (exists)
                    {
                        btnThi.Enabled = true;
                        txtHoten.Text = myReader.GetString(0) + " " + myReader.GetString(1);
                        txtMalop.Text = myReader.GetString(2);
                        txtTenlop.Text = myReader.GetString(3);
                        myReader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mã sinh viên không tồn tại. Kiểm tra lại !!!", "Thông báo");
                        myReader.Close();
                        return;
                    }
                    
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
                        phut = myReaderThi.GetInt16(5); // lấy số phút phải thi
                    }
                    myReaderThi.Close();
                    grbThoigianthi.Visible = true;
                    if (cbMonhoc.Items.Count > 0)
                    {
                        cbMonhoc.SelectedIndex = 0;
                    }
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
            // nhóm quyền sinh viên mới có thể tự động tính điểm + ghi điểm vào db
            if (role == "SINHVIEN")
            {
                timer1.Stop();
                grbCoverThi.Hide();
                MessageBox.Show("Kết thúc phần thi ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TinhDiemSV();
            }

        }

        private void TinhDiemSV()
        {
            int demcaudung = 0;
            for (int i = 0; i < cauhoi_thi.Count; i++)
            {
                CauHoi ch = (CauHoi)cauhoi_thi[i];
                if (ketqua[i] == ch.DAP_AN)
                {
                    demcaudung++;
                }
            }
            float diem = ((float)demcaudung / (float)socauthi) * 10;
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
            string strLenh = "DECLARE	@return_value int EXEC @return_value = [dbo].[SP_LAYLANTHITHEOMH]" +
                "@MAMH = N'" + monhoc + "',@MALOP = N'" + txtMalop.Text + "' SELECT  'Return Value' = @return_value";
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
                        if (role == "SINHVIEN")
                        {
                            TinhDiemSV(); // quyền sv mới được ghi điểm
                        }
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

    }
}