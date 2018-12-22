using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TTN_PT
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();

            txtLogin.Text = "HAI";
            txtPass.Text = "123";
            rdbGV.Checked = true;

        }

        private void cbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCoSo.SelectedValue != null)
            {
                Program.servername = cbCoSo.SelectedValue.ToString();
            }
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_VIEW.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS_VIEW.V_DS_PHANMANH);
            cbCoSo.SelectedIndex = 1;
            cbCoSo.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản đăng nhập không được rỗng. Kiểm tra lại !", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                txtLogin.Focus();
                return;
            }
            else if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu đăng nhập không được rỗng. Kiểm tra lại !", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                txtPass.Focus();
                return;
            }
            else
            {
                Program.mlogin = txtLogin.Text;
                Program.password = txtPass.Text;


                if (Program.KetNoi() == 0) return;
                else
                {
                    Program.bds_dspm = this.v_DS_PHANMANHBindingSource;
                    Program.mloginDN = Program.mlogin;
                    Program.passwordDN = Program.password;
                    Program.mCoSo = cbCoSo.SelectedIndex;
                    SqlDataReader myReader;

                    if (rdbGV.Checked == true)
                    {
                        string strlenh = "EXEC SP_DANGNHAP '" + Program.mlogin + "'";
                        myReader = Program.ExecSqlDataReader(strlenh);
                        if (myReader == null) return;
                        myReader.Read();
                        Program.username = myReader.GetString(0);
                        Program.mHoten = myReader.GetString(1);
                        Program.mGroup = myReader.GetString(2);
                        myReader.Close();

                        FormMain frMain = new FormMain();
                        frMain.Show();
                    }

                    else if (rdbSV.Checked == true)
                    {
                        string strlenh = "EXEC SP_DANGNHAP_SV '" + Program.mlogin + "'";
                        myReader = Program.ExecSqlDataReader(strlenh);
                        if (myReader == null) return;
                        myReader.Read();
                        Program.username = myReader.GetString(0);
                        Program.mHoten = myReader.GetString(1);
                        Program.mGroup = myReader.GetString(2);
                        myReader.Close();

                        FormMain frMain = new FormMain();
                        frMain.Show();

                    }

                    this.Hide();
                }
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
