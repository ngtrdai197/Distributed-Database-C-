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
    public partial class FormMonHoc : DevExpress.XtraEditors.XtraForm
    {
        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tTN_DS);

        }

        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tTN_DS.MONHOC' table. You can move, or remove it, as needed.
            this.MonHocTableAdapter.Fill(this.tTN_DS.MONHOC);
            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS";
            cbCoSo.ValueMember = "TENSERVER";

            btnHuybo.Enabled = false;
            btnLuu.Enabled = false;
            btnXacnhan.Enabled = false;

            if (Program.mGroup == "TRUONG")
            {
                cbCoSo.Enabled = true;
                btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
            }
            else
            {
                cbCoSo.Enabled = false;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            bdsMonHoc.Filter = "MAMH LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TENMH LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                MonHocTableAdapter.Fill(tTN_DS.MONHOC);
            }
        }

        private void txtTimkiem_KeyUp(object sender, KeyEventArgs e)
        {
            bdsMonHoc.Filter = "MAMH LIKE '%" + txtTimkiem.Text + "%'"
                + " OR TENMH LIKE '%" + this.txtTimkiem.Text + "%'";
            if (txtTimkiem.Text == "")
            {
                MonHocTableAdapter.Fill(tTN_DS.MONHOC);
            }
        }

        private void mAMHLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXacnhan.Enabled = btnSua.Enabled = btnLuu.Enabled =
                  btnThem.Enabled = false;
            btnXoa.Enabled = txtTimkiem.Enabled = false;

            // xóa
            DialogResult dr = MessageBox.Show("Bạn có chắc chắc muốn xóa", "Xóa sinh viên", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                bdsMonHoc.RemoveCurrent();
                MonHocTableAdapter.Update(tTN_DS.MONHOC);

                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            }
            else
            {
                if (Program.mGroup == "TRUONG")
                {
                    btnXacnhan.Enabled = btnSua.Enabled =
                        btnXoa.Enabled = btnLuu.Enabled =
                        btnThem.Enabled = false; // nhom truong ko duoc them moi 1 sv
                }
                else
                {
                    btnXacnhan.Enabled = btnLuu.Enabled = false;
                    btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
                }
            }
        }
    }
}