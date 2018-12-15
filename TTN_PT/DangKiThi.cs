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

        private void FormDangKiThi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tTN_DS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.tTN_DS.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'dS_VIEW.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS_VIEW.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'dS_VIEW.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS_VIEW.V_DS_PHANMANH);

        }
    }
}