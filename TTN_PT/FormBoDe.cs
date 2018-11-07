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
           // bODETableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tTN_DS.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Fill(this.tTN_DS.BODE);
            //cbCoSo.DataSource = Program.bds_dspm;
            //cbCoSo.DisplayMember = "TENCS";
            //cbCoSo.ValueMember = "TENSERVER";
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
    }
}