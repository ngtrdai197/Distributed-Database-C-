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
    public partial class TAOLOGIN : DevExpress.XtraEditors.XtraForm
    {
        public TAOLOGIN()
        {
            InitializeComponent();
        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gIAOVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void TAOLOGIN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tTN_DS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Fill(this.tTN_DS.GIAOVIEN);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

                    }

                }
            }
        }
    }
}