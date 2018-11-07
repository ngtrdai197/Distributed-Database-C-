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

namespace TTN_PT
{
    public partial class FormKhoa : DevExpress.XtraEditors.XtraForm
    {
        public FormKhoa()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kHOABindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormKhoa_Load(object sender, EventArgs e)
        {
            kHOATableAdapter.Connection.ConnectionString = Program.connstr;

            // TODO: This line of code loads data into the 'tTN_DS.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Fill(this.tTN_DS.KHOA);
            comboBox1.DataSource = Program.bds_dspm;
            comboBox1.DisplayMember = "TENCS";
            comboBox1.ValueMember = "TENSERVER";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                if (comboBox1.ValueMember != "")
                {
                    if (Program.servername != comboBox1.SelectedValue.ToString())
                    {
                        Program.servername = comboBox1.SelectedValue.ToString();
                    }
                    if (comboBox1.SelectedIndex != Program.mCoSo)
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
                        kHOATableAdapter.Connection.ConnectionString = Program.connstr;
                        kHOATableAdapter.Fill(tTN_DS.KHOA);

                    }

                }
            }
        }
    }
}