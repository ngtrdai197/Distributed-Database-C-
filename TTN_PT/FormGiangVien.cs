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
        int chucnang;
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
            // TODO: This line of code loads data into the 'dsLOGIN.V_DSTKSV' table. You can move, or remove it, as needed.
            this.v_DSTKSVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_DSTKSVTableAdapter.Fill(this.dsLOGIN.V_DSTKSV);
            // TODO: This line of code loads data into the 'dsLOGIN.V_DSTKSV' table. You can move, or remove it, as needed.
            this.v_DSTKSVTableAdapter.Fill(this.dsLOGIN.V_DSTKSV);
            // TODO: This line of code loads data into the 'tTN_DS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.tTN_DS.SINHVIEN);
            // TODO: This line of code loads data into the 'dsLOGIN.V_DSNHOM' table. You can move, or remove it, as needed.
            this.v_DSNHOMTableAdapter.Fill(this.dsLOGIN.V_DSNHOM);
            // TODO: This line of code loads data into the 'dsLOGIN.V_DSTK' table. You can move, or remove it, as needed.
            this.v_DSTKTableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_DSTKTableAdapter.Fill(this.dsLOGIN.V_DSTK);
            // TODO: This line of code loads data into the 'dsLOGIN.V_DSNHOM' table. You can move, or remove it, as needed.
            this.v_DSNHOMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_DSNHOMTableAdapter.Fill(this.dsLOGIN.V_DSNHOM);
            gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tTN_DS.SINHVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Fill(this.tTN_DS.GIAOVIEN);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

           
            btnHuybo.Enabled = false;
            btnLuu.Enabled = false;

            if (Program.mGroup == "TRUONG")
            {
                cbNh.Enabled = false;
                barLGSV.Enabled = false;
                cbCoSo.Enabled = true;
                

            }
            else
            {
                cbNh.Enabled = true;
                barLGSV.Enabled = true;
                cbCoSo.Enabled = false;
            }

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            gbDangKi.Visible = true;
            lbNhom.Visible = true;
            cbNh.Visible = true;
            sINHVIENGridControl.Visible = false;
            gIAOVIENGridControl.Visible = true;
            cbMAGV.Visible = true;
            cbMASV.Visible = false;
            chucnang = 1;

           
            gIAOVIENGridControl.Dock = DockStyle.Fill;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gbDangKi.Visible = true;
            lbNhom.Visible = false;
            cbNh.Visible = false;
            sINHVIENGridControl.Visible = true;
            gIAOVIENGridControl.Visible = false;
            cbMAGV.Visible = false;
            cbMASV.Visible = true;
            sINHVIENGridControl.Dock = DockStyle.Fill;
            chucnang = 2;
            
        }

        private void cbCoso_SelectedIndexChanged(object sender, EventArgs e)
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
                        gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                        gIAOVIENTableAdapter.Fill(tTN_DS.GIAOVIEN);

                        sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                        sINHVIENTableAdapter.Fill(tTN_DS.SINHVIEN);

                        this.v_DSNHOMTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.v_DSNHOMTableAdapter.Fill(this.dsLOGIN.V_DSNHOM);

                        this.v_DSTKTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.v_DSTKTableAdapter.Fill(this.dsLOGIN.V_DSTK);

                        this.v_DSTKSVTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.v_DSTKSVTableAdapter.Fill(this.dsLOGIN.V_DSTKSV);






                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chucnang == 1)
            {
                if (edtUser.Text.Equals("") || edtPass.Text.Equals(""))
                {
                    MessageBox.Show("tài khoản hoặc mật khẩu không hợp lệ!");
                }
                else
                {
                    string sqlcmd1 = "DECLARE	@return_value int EXEC	@return_value = [dbo].[SP_CHECKLOGIN] @LGNAME = N'" + edtUser.Text.ToString().Trim() + "' SELECT	'Return Value' = @return_value";
                    Program.myReader = Program.ExecSqlDataReader(sqlcmd1);
                    Program.myReader.Read();
                    int value = Program.myReader.GetInt32(0);
                    Program.myReader.Close();
                    if (value == 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    }
                    else
                    {
                        string sqlcmd = "exec SP_TAOLOGIN_1 '" + edtUser.Text.ToString().Trim() + "','" + edtPass.Text.ToString().Trim() + "','" + cbMAGV.Text.ToString() + "','" + cbNh.Text.ToString() + "'";
                        Program.myReader = Program.ExecSqlDataReader(sqlcmd);
                        Program.myReader.Read();
                        Program.myReader.Close();
                        MessageBox.Show("Thành công!");
                    }

                }
               
            }else if (chucnang == 2)
            {

                if (edtUser.Text.Equals("") || edtPass.Text.Equals(""))
                {
                    MessageBox.Show("tài khoản hoặc mật khẩu không hợp lệ!");
                }
                else
                {
                    string sqlcmd1 = "DECLARE	@return_value int EXEC	@return_value = [dbo].[SP_CHECKLOGIN] @LGNAME = N'" + edtUser.Text.ToString().Trim() + "' SELECT	'Return Value' = @return_value";
                    Program.myReader = Program.ExecSqlDataReader(sqlcmd1);
                    Program.myReader.Read();
                    int value = Program.myReader.GetInt32(0);
                    Program.myReader.Close();
                    if (value == 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    }
                    else
                    {
                        string sqlcmd = "exec SP_TAOLOGIN_1 '" + edtUser.Text.ToString().Trim() + "','" + edtPass.Text.ToString().Trim() + "','" + cbMASV.Text.ToString() + "','SINHVIEN'";
                        Program.myReader = Program.ExecSqlDataReader(sqlcmd);
                        Program.myReader.Read();
                        Program.myReader.Close();
                        MessageBox.Show("Thành công!");
                    }

                }
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edtUser.ResetText();
            edtPass.ResetText();
            gbDangKi.Visible = false;
        }
    }
}
