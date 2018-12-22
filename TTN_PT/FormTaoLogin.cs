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
    public partial class FormTaoLogin : DevExpress.XtraEditors.XtraForm
    {
        int chucnang;
        public FormTaoLogin()
        {
            InitializeComponent();
        }

        private void FormTaoLogin_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'dsLOGIN.V_DSTKSV' table. You can move, or remove it, as needed.
            this.v_DSTKSVTableAdapter.Fill(this.dsLOGIN.V_DSTKSV);
            // TODO: This line of code loads data into the 'dsLOGIN.V_DSNHOM' table. You can move, or remove it, as needed.
            this.v_DSNHOMTableAdapter.Fill(this.dsLOGIN.V_DSNHOM);
            // TODO: This line of code loads data into the 'dsLOGIN.V_DSTK' table. You can move, or remove it, as needed.
            this.v_DSTKTableAdapter.Fill(this.dsLOGIN.V_DSTK);
            // TODO: This line of code loads data into the 'tTN_DS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.tTN_DS.SINHVIEN);
            // TODO: This line of code loads data into the 'tTN_DS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Fill(this.tTN_DS.GIAOVIEN);
            // TODO: This line of code loads data into the 'dS_VIEW.V_DS_PHANMANH' table. You can move, or remove it, as needed.

            this.v_DS_PHANMANHTableAdapter.Fill(this.dS_VIEW.V_DS_PHANMANH);

            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";


            cbCoSo.SelectedIndex = 1;
            cbCoSo.SelectedIndex = 0;
            groupBox2.Visible = false; // an form dang ki login
            groupBox1.Visible = false;

            if (Program.mGroup == "TRUONG")
            {
                cbNhomQuyen.Enabled = false;
                btnThemSv.Enabled = false;
                cbCoSo.Enabled = true;


            }
            else
            {
                cbNhomQuyen.Enabled = true;
                btnThemSv.Enabled = true;
                cbCoSo.Enabled = false;
            }
        }

        private void btnThemGv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GIAOVIENGridControl.Visible = true;
            groupBox2.Visible = true;
            groupBox1.Visible = true;

            cbGV.Visible = true;
            cbSV.Visible = false;
            SINHVIENGridControl.Visible = false;
            GIAOVIENGridControl.Visible = true;
            cbNhomQuyen.Visible = true;
            chucnang = 1;


            GIAOVIENGridControl.Dock = DockStyle.Fill;
        }

        private void btnThemSv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GIAOVIENGridControl.Visible = false;
            groupBox2.Visible = true;
            groupBox1.Visible = true;

            cbGV.Visible = false; // an combobox ma GV
            cbSV.Visible = true; // hien thi combobox ma SV
            SINHVIENGridControl.Visible = true;
            GIAOVIENGridControl.Visible = false;
            cbNhomQuyen.Visible = false;
            lbNhomQuyen.Visible = true;
            chucnang = 2;


            SINHVIENGridControl.Dock = DockStyle.Fill;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chucnang == 1)
            {
                if (edtUser.Text.Equals("") || edtPass.Text.Equals(""))
                {
                    MessageBox.Show("tài khoản hoặc mật khẩu không hợp lệ!");
                }
                else
                {
                    SqlDataReader myReader;
                    string sqlcmd1 = "DECLARE	@return_value int EXEC	@return_value = [dbo].[SP_CHECKLOGIN] @LGNAME = N'" + edtUser.Text.ToString().Trim() + "' SELECT	'Return Value' = @return_value";
                    myReader = Program.ExecSqlDataReader(sqlcmd1);
                    myReader.Read();
                    int value = myReader.GetInt32(0);
                    myReader.Close();
                    if (value == 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    }
                    else
                    {
                        string sqlcmd = "exec SP_TAOLOGIN_1 '" + edtUser.Text.ToString().Trim() + "','" + edtPass.Text.ToString().Trim() + "','" + cbGV.Text.ToString() + "','" + cbNhomQuyen.Text.ToString() + "'";
                        myReader = Program.ExecSqlDataReader(sqlcmd);
                        myReader.Close();
                        MessageBox.Show("Thành công!");
                    }

                }

            }
            else if (chucnang == 2)
            {

                if (edtUser.Text.Equals("") || edtPass.Text.Equals(""))
                {
                    MessageBox.Show("tài khoản hoặc mật khẩu không hợp lệ!");
                }
                else
                {
                    SqlDataReader myReader;
                    string sqlcmd1 = "DECLARE	@return_value int EXEC	@return_value = [dbo].[SP_CHECKLOGIN] @LGNAME = N'" + edtUser.Text.ToString().Trim() + "' SELECT	'Return Value' = @return_value";
                    myReader = Program.ExecSqlDataReader(sqlcmd1);
                    myReader.Read();
                    int value = myReader.GetInt32(0);
                    myReader.Close();
                    if (value == 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    }
                    else
                    {
                        string sqlcmd = "exec SP_TAOLOGIN_1 '" + edtUser.Text.ToString().Trim() + "','" + edtPass.Text.ToString().Trim() + "','" + cbSV.Text.ToString() + "','SINHVIEN'";
                        myReader = Program.ExecSqlDataReader(sqlcmd);
                        myReader.Read();
                        myReader.Close();
                        MessageBox.Show("Thành công!");
                    }

                }
            }
        }

        private void v_DS_PHANMANHComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}