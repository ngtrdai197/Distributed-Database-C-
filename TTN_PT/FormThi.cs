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
    public partial class FormThi : DevExpress.XtraEditors.XtraForm
    {
        public FormThi()
        {
            InitializeComponent();

            txtCauHoi.Text = "It is a long established fact that a " +
                "reader will be distracted by the readable content of a " +
                "page when looking at its layout. " +
                "The point of using Lorem Ipsum is that it has a more-or-less " +
                "normal distribution of letters";
            grbThi.Visible = false;
        }

        private void btnThi_Click(object sender, EventArgs e)
        {
            grbThi.Visible = true;

        }
    }
}