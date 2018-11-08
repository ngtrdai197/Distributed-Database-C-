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
    public partial class FormDangKiThi : DevExpress.XtraEditors.XtraForm
    {
        public FormDangKiThi()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gIAOVIEN_DANGKYBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormDangKiThi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tTN_DS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.tTN_DS.GIAOVIEN_DANGKY);

        }
    }
}