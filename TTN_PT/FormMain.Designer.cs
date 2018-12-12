namespace TTN_PT
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnDangKiThi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnBode = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnMonhoc = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnKhoa = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnLop = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnIndiem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnDSDKThi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barTaoLG = new DevExpress.XtraBars.BarButtonItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stHoten = new System.Windows.Forms.ToolStripStatusLabel();
            this.stMa = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // xtraTabbedMdiManager1
            //
            this.xtraTabbedMdiManager1.MdiParent = this;
            //
            // ribbonPage1
            //
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8,
            this.ribbonPageGroup3,
            this.ribbonPageGroup9,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            //
            // ribbonPageGroup2
            //
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDangKiThi);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Đăng ký thi";
            //
            // btnDangKiThi
            //
            this.btnDangKiThi.Caption = "Đăng kí thi";
            this.btnDangKiThi.Id = 2;
            this.btnDangKiThi.ImageOptions.Image = global::TTN_PT.Properties.Resources.Student_3_icon;
            this.btnDangKiThi.Name = "btnDangKiThi";
            this.btnDangKiThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSinhVien_ItemClick);
            //
            // ribbonPageGroup4
            //
            this.ribbonPageGroup4.ItemLinks.Add(this.btnBode);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Bộ Đề";
            //
            // btnBode
            //
            this.btnBode.Caption = "Bộ Đề";
            this.btnBode.Id = 4;
            this.btnBode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBode.ImageOptions.Image")));
            this.btnBode.Name = "btnBode";
            this.btnBode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            //
            // ribbonPageGroup5
            //
            this.ribbonPageGroup5.ItemLinks.Add(this.btnMonhoc);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Môn học";
            //
            // btnMonhoc
            //
            this.btnMonhoc.Caption = "Môn Học";
            this.btnMonhoc.Id = 6;
            this.btnMonhoc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMonhoc.ImageOptions.Image")));
            this.btnMonhoc.Name = "btnMonhoc";
            this.btnMonhoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonhoc_ItemClick);
            //
            // ribbonPageGroup6
            //
            this.ribbonPageGroup6.ItemLinks.Add(this.btnKhoa);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Khoa";
            //
            // btnKhoa
            //
            this.btnKhoa.Caption = "Khoa";
            this.btnKhoa.Id = 7;
            this.btnKhoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoa.ImageOptions.Image")));
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhoa_ItemClick);
            //
            // ribbonPageGroup7
            //
            this.ribbonPageGroup7.ItemLinks.Add(this.btnLop);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Lớp";
            //
            // btnLop
            //
            this.btnLop.Caption = "Lớp";
            this.btnLop.Id = 8;
            this.btnLop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLop.ImageOptions.Image")));
            this.btnLop.Name = "btnLop";
            this.btnLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            //
            // ribbonPageGroup8
            //
            this.ribbonPageGroup8.ItemLinks.Add(this.btnIndiem);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "In điểm";
            //
            // btnIndiem
            //
            this.btnIndiem.Caption = "In điểm";
            this.btnIndiem.Id = 9;
            this.btnIndiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIndiem.ImageOptions.Image")));
            this.btnIndiem.Name = "btnIndiem";
            this.btnIndiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            //
            // ribbonPageGroup3
            //
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Đăng xuất";
            //
            // barButtonItem1
            //
            this.barButtonItem1.Caption = "Đăng Xuất";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            //
            // ribbonPageGroup9
            //
            this.ribbonPageGroup9.ItemLinks.Add(this.btnDSDKThi);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "DS đăng ký thi";
            //
            // btnDSDKThi
            //
            this.btnDSDKThi.Caption = "Danh sách ĐK Thi";
            this.btnDSDKThi.Id = 10;
            this.btnDSDKThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDSDKThi.ImageOptions.Image")));
            this.btnDSDKThi.Name = "btnDSDKThi";
            this.btnDSDKThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSDKThi_ItemClick);
            //
            // ribbonPageGroup1
            //
            this.ribbonPageGroup1.ItemLinks.Add(this.barTaoLG);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            //
            // barTaoLG
            //
            this.barTaoLG.Caption = "Tạo LOGIN";
            this.barTaoLG.Id = 12;
            this.barTaoLG.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barTaoLG.Name = "barTaoLG";
            this.barTaoLG.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick_1);
            //
            // ribbon
            //
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnDangKiThi,
            this.barButtonItem1,
            this.btnBode,
            this.btnMonhoc,
            this.btnKhoa,
            this.btnLop,
            this.btnIndiem,
            this.btnDSDKThi,
            this.barTaoLG});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 13;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(882, 143);
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stHoten,
            this.stMa,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(882, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "Họ:";
            //
            // stHoten
            //
            this.stHoten.Name = "stHoten";
            this.stHoten.Size = new System.Drawing.Size(29, 17);
            this.stHoten.Text = "Tên:";
            //
            // stMa
            //
            this.stMa.Name = "stMa";
            this.stMa.Size = new System.Drawing.Size(27, 17);
            this.stMa.Text = "Mã:";
            //
            // toolStripStatusLabel3
            //
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel3.Text = "Nhóm:";
            //
            // FormMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 474);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Ribbon = this.ribbon;
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stHoten;
        private System.Windows.Forms.ToolStripStatusLabel stMa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnDangKiThi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem btnBode;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnMonhoc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnKhoa;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnLop;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btnIndiem;
        private DevExpress.XtraBars.BarButtonItem btnDSDKThi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem barTaoLG;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}