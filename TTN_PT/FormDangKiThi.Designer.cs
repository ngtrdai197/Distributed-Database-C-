namespace TTN_PT
{
    partial class FormDangKiThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangKiThi));
            System.Windows.Forms.Label mAGVLabel;
            System.Windows.Forms.Label mALOPLabel;
            System.Windows.Forms.Label mAMHLabel;
            System.Windows.Forms.Label tRINHDOLabel;
            System.Windows.Forms.Label nGAYTHILabel;
            System.Windows.Forms.Label lANLabel;
            System.Windows.Forms.Label sOCAUTHILabel;
            System.Windows.Forms.Label tHOIGIANLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.TTN_DS = new TTN_PT.TTN_DS();
            this.bdsGVDangKy = new System.Windows.Forms.BindingSource();
            this.GVDangKyTableAdapter = new TTN_PT.TTN_DSTableAdapters.GIAOVIEN_DANGKYTableAdapter();
            this.tableAdapterManager = new TTN_PT.TTN_DSTableAdapters.TableAdapterManager();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dS_VIEW = new TTN_PT.DS_VIEW();
            this.v_DS_PHANMANHBindingSource = new System.Windows.Forms.BindingSource();
            this.v_DS_PHANMANHTableAdapter = new TTN_PT.DS_VIEWTableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager1 = new TTN_PT.DS_VIEWTableAdapters.TableAdapterManager();
            this.cbCoSo = new System.Windows.Forms.ComboBox();
            this.gIAOVIEN_DANGKYGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMaGv = new DevExpress.XtraEditors.TextEdit();
            this.txtMaLop = new DevExpress.XtraEditors.TextEdit();
            this.txtMaMH = new DevExpress.XtraEditors.TextEdit();
            this.txtTrinhDo = new DevExpress.XtraEditors.TextEdit();
            this.dtNgayThi = new DevExpress.XtraEditors.DateEdit();
            this.txtLanThi = new DevExpress.XtraEditors.TextEdit();
            this.txtSoCauThi = new DevExpress.XtraEditors.TextEdit();
            this.txtThoiGian = new DevExpress.XtraEditors.TextEdit();
            this.colMAGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRINHDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCAUTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTHOIGIAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXacnhan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            mAGVLabel = new System.Windows.Forms.Label();
            mALOPLabel = new System.Windows.Forms.Label();
            mAMHLabel = new System.Windows.Forms.Label();
            tRINHDOLabel = new System.Windows.Forms.Label();
            nGAYTHILabel = new System.Windows.Forms.Label();
            lANLabel = new System.Windows.Forms.Label();
            sOCAUTHILabel = new System.Windows.Forms.Label();
            tHOIGIANLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TTN_DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVDangKy)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS_VIEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIAOVIEN_DANGKYGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayThi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLanThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCauThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnLuu,
            this.btnHuy});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.btnLuu.Name = "btnLuu";
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy bỏ";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.btnHuy.Name = "btnHuy";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(824, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 518);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(824, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 471);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(824, 47);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 471);
            // 
            // TTN_DS
            // 
            this.TTN_DS.DataSetName = "TTN_DS";
            this.TTN_DS.EnforceConstraints = false;
            this.TTN_DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsGVDangKy
            // 
            this.bdsGVDangKy.DataMember = "GIAOVIEN_DANGKY";
            this.bdsGVDangKy.DataSource = this.TTN_DS;
            // 
            // GVDangKyTableAdapter
            // 
            this.GVDangKyTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = this.GVDangKyTableAdapter;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TTN_PT.TTN_DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbCoSo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 54);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cơ sở";
            // 
            // dS_VIEW
            // 
            this.dS_VIEW.DataSetName = "DS_VIEW";
            this.dS_VIEW.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DS_PHANMANHBindingSource
            // 
            this.v_DS_PHANMANHBindingSource.DataMember = "V_DS_PHANMANH";
            this.v_DS_PHANMANHBindingSource.DataSource = this.dS_VIEW;
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = TTN_PT.DS_VIEWTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cbCoSo
            // 
            this.cbCoSo.DataSource = this.v_DS_PHANMANHBindingSource;
            this.cbCoSo.DisplayMember = "TENCS";
            this.cbCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoSo.FormattingEnabled = true;
            this.cbCoSo.Location = new System.Drawing.Point(307, 20);
            this.cbCoSo.Name = "cbCoSo";
            this.cbCoSo.Size = new System.Drawing.Size(277, 21);
            this.cbCoSo.TabIndex = 0;
            this.cbCoSo.ValueMember = "TENSERVER";
            // 
            // gIAOVIEN_DANGKYGridControl
            // 
            this.gIAOVIEN_DANGKYGridControl.DataSource = this.bdsGVDangKy;
            this.gIAOVIEN_DANGKYGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.gIAOVIEN_DANGKYGridControl.Location = new System.Drawing.Point(0, 101);
            this.gIAOVIEN_DANGKYGridControl.MainView = this.gridView1;
            this.gIAOVIEN_DANGKYGridControl.MenuManager = this.barManager1;
            this.gIAOVIEN_DANGKYGridControl.Name = "gIAOVIEN_DANGKYGridControl";
            this.gIAOVIEN_DANGKYGridControl.Size = new System.Drawing.Size(824, 220);
            this.gIAOVIEN_DANGKYGridControl.TabIndex = 10;
            this.gIAOVIEN_DANGKYGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAGV,
            this.colMAMH,
            this.colMALOP,
            this.colTRINHDO,
            this.colNGAYTHI,
            this.colLAN,
            this.colSOCAUTHI,
            this.colTHOIGIAN});
            this.gridView1.GridControl = this.gIAOVIEN_DANGKYGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXacnhan);
            this.groupBox2.Controls.Add(tHOIGIANLabel);
            this.groupBox2.Controls.Add(this.txtThoiGian);
            this.groupBox2.Controls.Add(sOCAUTHILabel);
            this.groupBox2.Controls.Add(this.txtSoCauThi);
            this.groupBox2.Controls.Add(lANLabel);
            this.groupBox2.Controls.Add(this.txtLanThi);
            this.groupBox2.Controls.Add(nGAYTHILabel);
            this.groupBox2.Controls.Add(this.dtNgayThi);
            this.groupBox2.Controls.Add(tRINHDOLabel);
            this.groupBox2.Controls.Add(this.txtTrinhDo);
            this.groupBox2.Controls.Add(mAMHLabel);
            this.groupBox2.Controls.Add(this.txtMaMH);
            this.groupBox2.Controls.Add(mALOPLabel);
            this.groupBox2.Controls.Add(this.txtMaLop);
            this.groupBox2.Controls.Add(mAGVLabel);
            this.groupBox2.Controls.Add(this.txtMaGv);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(824, 218);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // mAGVLabel
            // 
            mAGVLabel.AutoSize = true;
            mAGVLabel.Location = new System.Drawing.Point(70, 31);
            mAGVLabel.Name = "mAGVLabel";
            mAGVLabel.Size = new System.Drawing.Size(39, 13);
            mAGVLabel.TabIndex = 0;
            mAGVLabel.Text = "MAGV:";
            // 
            // txtMaGv
            // 
            this.txtMaGv.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDangKy, "MAGV", true));
            this.txtMaGv.Location = new System.Drawing.Point(145, 28);
            this.txtMaGv.MenuManager = this.barManager1;
            this.txtMaGv.Name = "txtMaGv";
            this.txtMaGv.Size = new System.Drawing.Size(139, 20);
            this.txtMaGv.TabIndex = 1;
            // 
            // mALOPLabel
            // 
            mALOPLabel.AutoSize = true;
            mALOPLabel.Location = new System.Drawing.Point(69, 64);
            mALOPLabel.Name = "mALOPLabel";
            mALOPLabel.Size = new System.Drawing.Size(45, 13);
            mALOPLabel.TabIndex = 2;
            mALOPLabel.Text = "MALOP:";
            // 
            // txtMaLop
            // 
            this.txtMaLop.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDangKy, "MALOP", true));
            this.txtMaLop.Location = new System.Drawing.Point(145, 61);
            this.txtMaLop.MenuManager = this.barManager1;
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(139, 20);
            this.txtMaLop.TabIndex = 3;
            // 
            // mAMHLabel
            // 
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(66, 100);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(41, 13);
            mAMHLabel.TabIndex = 4;
            mAMHLabel.Text = "MAMH:";
            // 
            // txtMaMH
            // 
            this.txtMaMH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDangKy, "MAMH", true));
            this.txtMaMH.Location = new System.Drawing.Point(145, 93);
            this.txtMaMH.MenuManager = this.barManager1;
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(139, 20);
            this.txtMaMH.TabIndex = 5;
            // 
            // tRINHDOLabel
            // 
            tRINHDOLabel.AutoSize = true;
            tRINHDOLabel.Location = new System.Drawing.Point(66, 129);
            tRINHDOLabel.Name = "tRINHDOLabel";
            tRINHDOLabel.Size = new System.Drawing.Size(57, 13);
            tRINHDOLabel.TabIndex = 6;
            tRINHDOLabel.Text = "TRINHDO:";
            // 
            // txtTrinhDo
            // 
            this.txtTrinhDo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDangKy, "TRINHDO", true));
            this.txtTrinhDo.Location = new System.Drawing.Point(145, 126);
            this.txtTrinhDo.MenuManager = this.barManager1;
            this.txtTrinhDo.Name = "txtTrinhDo";
            this.txtTrinhDo.Size = new System.Drawing.Size(139, 20);
            this.txtTrinhDo.TabIndex = 7;
            // 
            // nGAYTHILabel
            // 
            nGAYTHILabel.AutoSize = true;
            nGAYTHILabel.Location = new System.Drawing.Point(66, 161);
            nGAYTHILabel.Name = "nGAYTHILabel";
            nGAYTHILabel.Size = new System.Drawing.Size(55, 13);
            nGAYTHILabel.TabIndex = 8;
            nGAYTHILabel.Text = "NGAYTHI:";
            // 
            // dtNgayThi
            // 
            this.dtNgayThi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDangKy, "NGAYTHI", true));
            this.dtNgayThi.EditValue = null;
            this.dtNgayThi.Location = new System.Drawing.Point(145, 158);
            this.dtNgayThi.MenuManager = this.barManager1;
            this.dtNgayThi.Name = "dtNgayThi";
            this.dtNgayThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayThi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayThi.Size = new System.Drawing.Size(139, 20);
            this.dtNgayThi.TabIndex = 9;
            // 
            // lANLabel
            // 
            lANLabel.AutoSize = true;
            lANLabel.Location = new System.Drawing.Point(395, 35);
            lANLabel.Name = "lANLabel";
            lANLabel.Size = new System.Drawing.Size(30, 13);
            lANLabel.TabIndex = 10;
            lANLabel.Text = "LAN:";
            // 
            // txtLanThi
            // 
            this.txtLanThi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDangKy, "LAN", true));
            this.txtLanThi.Location = new System.Drawing.Point(464, 32);
            this.txtLanThi.MenuManager = this.barManager1;
            this.txtLanThi.Name = "txtLanThi";
            this.txtLanThi.Size = new System.Drawing.Size(140, 20);
            this.txtLanThi.TabIndex = 11;
            // 
            // sOCAUTHILabel
            // 
            sOCAUTHILabel.AutoSize = true;
            sOCAUTHILabel.Location = new System.Drawing.Point(395, 68);
            sOCAUTHILabel.Name = "sOCAUTHILabel";
            sOCAUTHILabel.Size = new System.Drawing.Size(63, 13);
            sOCAUTHILabel.TabIndex = 12;
            sOCAUTHILabel.Text = "SOCAUTHI:";
            // 
            // txtSoCauThi
            // 
            this.txtSoCauThi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDangKy, "SOCAUTHI", true));
            this.txtSoCauThi.Location = new System.Drawing.Point(464, 65);
            this.txtSoCauThi.MenuManager = this.barManager1;
            this.txtSoCauThi.Name = "txtSoCauThi";
            this.txtSoCauThi.Size = new System.Drawing.Size(140, 20);
            this.txtSoCauThi.TabIndex = 13;
            // 
            // tHOIGIANLabel
            // 
            tHOIGIANLabel.AutoSize = true;
            tHOIGIANLabel.Location = new System.Drawing.Point(395, 109);
            tHOIGIANLabel.Name = "tHOIGIANLabel";
            tHOIGIANLabel.Size = new System.Drawing.Size(61, 13);
            tHOIGIANLabel.TabIndex = 14;
            tHOIGIANLabel.Text = "THOIGIAN:";
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDangKy, "THOIGIAN", true));
            this.txtThoiGian.Location = new System.Drawing.Point(464, 106);
            this.txtThoiGian.MenuManager = this.barManager1;
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Size = new System.Drawing.Size(140, 20);
            this.txtThoiGian.TabIndex = 15;
            // 
            // colMAGV
            // 
            this.colMAGV.Caption = "MÃ GV";
            this.colMAGV.FieldName = "MAGV";
            this.colMAGV.Name = "colMAGV";
            this.colMAGV.Visible = true;
            this.colMAGV.VisibleIndex = 0;
            // 
            // colMAMH
            // 
            this.colMAMH.Caption = "MÃ MH";
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 1;
            // 
            // colMALOP
            // 
            this.colMALOP.Caption = "MÃ LỚP";
            this.colMALOP.FieldName = "MALOP";
            this.colMALOP.Name = "colMALOP";
            this.colMALOP.Visible = true;
            this.colMALOP.VisibleIndex = 2;
            // 
            // colTRINHDO
            // 
            this.colTRINHDO.Caption = "TRÌNH ĐỘ";
            this.colTRINHDO.FieldName = "TRINHDO";
            this.colTRINHDO.Name = "colTRINHDO";
            this.colTRINHDO.Visible = true;
            this.colTRINHDO.VisibleIndex = 3;
            // 
            // colNGAYTHI
            // 
            this.colNGAYTHI.Caption = "NGÀY THI";
            this.colNGAYTHI.FieldName = "NGAYTHI";
            this.colNGAYTHI.Name = "colNGAYTHI";
            this.colNGAYTHI.Visible = true;
            this.colNGAYTHI.VisibleIndex = 4;
            // 
            // colLAN
            // 
            this.colLAN.Caption = "LẦN";
            this.colLAN.FieldName = "LAN";
            this.colLAN.Name = "colLAN";
            this.colLAN.Visible = true;
            this.colLAN.VisibleIndex = 5;
            // 
            // colSOCAUTHI
            // 
            this.colSOCAUTHI.Caption = "SỐ CÂU THI";
            this.colSOCAUTHI.FieldName = "SOCAUTHI";
            this.colSOCAUTHI.Name = "colSOCAUTHI";
            this.colSOCAUTHI.Visible = true;
            this.colSOCAUTHI.VisibleIndex = 6;
            // 
            // colTHOIGIAN
            // 
            this.colTHOIGIAN.Caption = "THỜI GIAN";
            this.colTHOIGIAN.FieldName = "THOIGIAN";
            this.colTHOIGIAN.Name = "colTHOIGIAN";
            this.colTHOIGIAN.Visible = true;
            this.colTHOIGIAN.VisibleIndex = 7;
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.Location = new System.Drawing.Point(464, 156);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(75, 23);
            this.btnXacnhan.TabIndex = 16;
            this.btnXacnhan.Text = "Xác nhận";
            this.btnXacnhan.UseVisualStyleBackColor = true;
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên cơ sở";
            // 
            // FormDangKiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 518);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gIAOVIEN_DANGKYGridControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormDangKiThi";
            this.Text = "FormDangKiThi";
            this.Load += new System.EventHandler(this.FormDangKiThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TTN_DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVDangKy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS_VIEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIAOVIEN_DANGKYGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayThi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLanThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCauThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private System.Windows.Forms.BindingSource bdsGVDangKy;
        private TTN_DS TTN_DS;
        private TTN_DSTableAdapters.GIAOVIEN_DANGKYTableAdapter GVDangKyTableAdapter;
        private TTN_DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DS_VIEW dS_VIEW;
        private System.Windows.Forms.BindingSource v_DS_PHANMANHBindingSource;
        private DS_VIEWTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private DS_VIEWTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtThoiGian;
        private DevExpress.XtraEditors.TextEdit txtSoCauThi;
        private DevExpress.XtraEditors.TextEdit txtLanThi;
        private DevExpress.XtraEditors.DateEdit dtNgayThi;
        private DevExpress.XtraEditors.TextEdit txtTrinhDo;
        private DevExpress.XtraEditors.TextEdit txtMaMH;
        private DevExpress.XtraEditors.TextEdit txtMaLop;
        private DevExpress.XtraEditors.TextEdit txtMaGv;
        private DevExpress.XtraGrid.GridControl gIAOVIEN_DANGKYGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAGV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colTRINHDO;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colLAN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCAUTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTHOIGIAN;
        private System.Windows.Forms.ComboBox cbCoSo;
        private System.Windows.Forms.Button btnXacnhan;
        private System.Windows.Forms.Label label1;
    }
}