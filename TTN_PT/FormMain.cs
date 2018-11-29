using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;

namespace TTN_PT
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {


        public FormMain()
        {
            InitializeComponent();

            stHoten.Text = stHoten.Text + Program.mHoten + "  - ";
            stMa.Text = stMa.Text + Program.username + "  - ";
            toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + Program.mGroup;
        }

        //Kiểm tra form tồn tại chưa?
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

        private void btnSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(FormDangKiThi));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                FormDangKiThi frmDKThi = new FormDangKiThi();
                frmDKThi.MdiParent = this;
                frmDKThi.Show();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormLogin frmLogin = new FormLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormLogin frmLogin = new FormLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void btnGiangVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(FormGiangVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {

                FormGiangVien frmGV = new FormGiangVien();
                frmGV.MdiParent = this;
                frmGV.Show();
            }

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = CheckExists(typeof(FormBoDe));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormBoDe fBode = new FormBoDe();
                fBode.MdiParent = this;
                fBode.Show();
            }
        }

        private void btnMonhoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = CheckExists(typeof(FormMonHoc));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormMonHoc fMonHoc = new FormMonHoc();
                fMonHoc.MdiParent = this;
                fMonHoc.Show();
            }
        }

        private void btnKhoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = CheckExists(typeof(FormKhoa));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormKhoa fKhoa = new FormKhoa();
                fKhoa.MdiParent = this;
                fKhoa.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = CheckExists(typeof(FormLop));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormLop fLop = new FormLop();
                fLop.MdiParent = this;
                fLop.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormInDiemTheoMonHoc indiem = new FormInDiemTheoMonHoc();
            indiem.Show();
        }
    }
}