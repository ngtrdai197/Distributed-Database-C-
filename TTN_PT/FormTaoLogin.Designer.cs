namespace TTN_PT
{
    partial class FormTaoLogin
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThemGv = new DevExpress.XtraBars.BarButtonItem();
            this.btnThemSv = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupbox = new System.Windows.Forms.GroupBox();
            this.cbCoSo = new System.Windows.Forms.ComboBox();
            this.v_DS_PHANMANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_VIEW = new TTN_PT.DS_VIEW();
            this.v_DS_PHANMANHTableAdapter = new TTN_PT.DS_VIEWTableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager = new TTN_PT.DS_VIEWTableAdapters.TableAdapterManager();
            this.tTN_DS = new TTN_PT.TTN_DS();
            this.gIAOVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gIAOVIENTableAdapter = new TTN_PT.TTN_DSTableAdapters.GIAOVIENTableAdapter();
            this.tableAdapterManager1 = new TTN_PT.TTN_DSTableAdapters.TableAdapterManager();
            this.sINHVIENTableAdapter = new TTN_PT.TTN_DSTableAdapters.SINHVIENTableAdapter();
            this.GIAOVIENGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sINHVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SINHVIENGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbNhomQuyen = new System.Windows.Forms.ComboBox();
            this.v_DSNHOMBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsLOGIN = new TTN_PT.DsLOGIN();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.v_DSTKSVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbGV = new System.Windows.Forms.ComboBox();
            this.v_DSTKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.edtPass = new System.Windows.Forms.TextBox();
            this.edtUser = new System.Windows.Forms.TextBox();
            this.lbNhomQuyen = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.v_DSTKTableAdapter = new TTN_PT.DsLOGINTableAdapters.V_DSTKTableAdapter();
            this.tableAdapterManager2 = new TTN_PT.DsLOGINTableAdapters.TableAdapterManager();
            this.v_DSNHOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_DSNHOMTableAdapter = new TTN_PT.DsLOGINTableAdapters.V_DSNHOMTableAdapter();
            this.v_DSTKSVTableAdapter = new TTN_PT.DsLOGINTableAdapters.V_DSTKSVTableAdapter();
            this.cbSV = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_VIEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTN_DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIAOVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GIAOVIENGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SINHVIENGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSNHOMBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLOGIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSTKSVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSTKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSNHOMBindingSource)).BeginInit();
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
            this.btnThemGv,
            this.btnThemSv});
            this.barManager1.MaxItemId = 2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThemGv),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThemSv)});
            this.bar1.Text = "Tools";
            // 
            // btnThemGv
            // 
            this.btnThemGv.Caption = "Thêm GV";
            this.btnThemGv.Id = 0;
            this.btnThemGv.Name = "btnThemGv";
            this.btnThemGv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemGv_ItemClick);
            // 
            // btnThemSv
            // 
            this.btnThemSv.Caption = "Thêm SV";
            this.btnThemSv.Id = 1;
            this.btnThemSv.Name = "btnThemSv";
            this.btnThemSv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemSv_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(827, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 562);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(827, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 533);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(827, 29);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 533);
            // 
            // groupbox
            // 
            this.groupbox.Controls.Add(this.cbCoSo);
            this.groupbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupbox.Location = new System.Drawing.Point(0, 29);
            this.groupbox.Name = "groupbox";
            this.groupbox.Size = new System.Drawing.Size(827, 60);
            this.groupbox.TabIndex = 4;
            this.groupbox.TabStop = false;
            this.groupbox.Text = "groupBox1";
            // 
            // cbCoSo
            // 
            this.cbCoSo.DataSource = this.v_DS_PHANMANHBindingSource;
            this.cbCoSo.DisplayMember = "TENCS";
            this.cbCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoSo.FormattingEnabled = true;
            this.cbCoSo.Location = new System.Drawing.Point(162, 20);
            this.cbCoSo.Name = "cbCoSo";
            this.cbCoSo.Size = new System.Drawing.Size(300, 21);
            this.cbCoSo.TabIndex = 0;
            this.cbCoSo.ValueMember = "TENSERVER";
            this.cbCoSo.SelectedIndexChanged += new System.EventHandler(this.v_DS_PHANMANHComboBox_SelectedIndexChanged);
            // 
            // v_DS_PHANMANHBindingSource
            // 
            this.v_DS_PHANMANHBindingSource.DataMember = "V_DS_PHANMANH";
            this.v_DS_PHANMANHBindingSource.DataSource = this.dS_VIEW;
            // 
            // dS_VIEW
            // 
            this.dS_VIEW.DataSetName = "DS_VIEW";
            this.dS_VIEW.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = TTN_PT.DS_VIEWTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tTN_DS
            // 
            this.tTN_DS.DataSetName = "TTN_DS";
            this.tTN_DS.EnforceConstraints = false;
            this.tTN_DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gIAOVIENBindingSource
            // 
            this.gIAOVIENBindingSource.DataMember = "GIAOVIEN";
            this.gIAOVIENBindingSource.DataSource = this.tTN_DS;
            // 
            // gIAOVIENTableAdapter
            // 
            this.gIAOVIENTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.BANGDIEMTableAdapter = null;
            this.tableAdapterManager1.BODETableAdapter = null;
            this.tableAdapterManager1.COSOTableAdapter = null;
            this.tableAdapterManager1.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager1.GIAOVIENTableAdapter = this.gIAOVIENTableAdapter;
            this.tableAdapterManager1.KHOATableAdapter = null;
            this.tableAdapterManager1.LOPTableAdapter = null;
            this.tableAdapterManager1.MONHOCTableAdapter = null;
            this.tableAdapterManager1.SINHVIENTableAdapter = this.sINHVIENTableAdapter;
            this.tableAdapterManager1.UpdateOrder = TTN_PT.TTN_DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sINHVIENTableAdapter
            // 
            this.sINHVIENTableAdapter.ClearBeforeFill = true;
            // 
            // GIAOVIENGridControl
            // 
            this.GIAOVIENGridControl.DataSource = this.gIAOVIENBindingSource;
            this.GIAOVIENGridControl.Location = new System.Drawing.Point(71, 0);
            this.GIAOVIENGridControl.MainView = this.gridView1;
            this.GIAOVIENGridControl.MenuManager = this.barManager1;
            this.GIAOVIENGridControl.Name = "GIAOVIENGridControl";
            this.GIAOVIENGridControl.Size = new System.Drawing.Size(300, 220);
            this.GIAOVIENGridControl.TabIndex = 5;
            this.GIAOVIENGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GIAOVIENGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // sINHVIENBindingSource
            // 
            this.sINHVIENBindingSource.DataMember = "SINHVIEN";
            this.sINHVIENBindingSource.DataSource = this.tTN_DS;
            // 
            // SINHVIENGridControl
            // 
            this.SINHVIENGridControl.DataSource = this.sINHVIENBindingSource;
            this.SINHVIENGridControl.Location = new System.Drawing.Point(432, 0);
            this.SINHVIENGridControl.MainView = this.gridView2;
            this.SINHVIENGridControl.MenuManager = this.barManager1;
            this.SINHVIENGridControl.Name = "SINHVIENGridControl";
            this.SINHVIENGridControl.Size = new System.Drawing.Size(300, 220);
            this.SINHVIENGridControl.TabIndex = 6;
            this.SINHVIENGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.SINHVIENGridControl;
            this.gridView2.Name = "gridView2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GIAOVIENGridControl);
            this.groupBox1.Controls.Add(this.SINHVIENGridControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 225);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbNhomQuyen);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Controls.Add(this.cbSV);
            this.groupBox2.Controls.Add(this.cbGV);
            this.groupBox2.Controls.Add(this.edtPass);
            this.groupBox2.Controls.Add(this.edtUser);
            this.groupBox2.Controls.Add(this.lbNhomQuyen);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(827, 238);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cbNhomQuyen
            // 
            this.cbNhomQuyen.DataSource = this.v_DSNHOMBindingSource1;
            this.cbNhomQuyen.DisplayMember = "name";
            this.cbNhomQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhomQuyen.FormattingEnabled = true;
            this.cbNhomQuyen.Location = new System.Drawing.Point(209, 148);
            this.cbNhomQuyen.Name = "cbNhomQuyen";
            this.cbNhomQuyen.Size = new System.Drawing.Size(166, 21);
            this.cbNhomQuyen.TabIndex = 10;
            this.cbNhomQuyen.ValueMember = "name";
            // 
            // v_DSNHOMBindingSource1
            // 
            this.v_DSNHOMBindingSource1.DataMember = "V_DSNHOM";
            this.v_DSNHOMBindingSource1.DataSource = this.dsLOGIN;
            // 
            // dsLOGIN
            // 
            this.dsLOGIN.DataSetName = "DsLOGIN";
            this.dsLOGIN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(569, 147);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(457, 146);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // v_DSTKSVBindingSource
            // 
            this.v_DSTKSVBindingSource.DataMember = "V_DSTKSV";
            this.v_DSTKSVBindingSource.DataSource = this.dsLOGIN;
            // 
            // cbGV
            // 
            this.cbGV.DataSource = this.v_DSTKBindingSource;
            this.cbGV.DisplayMember = "MAGV";
            this.cbGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGV.FormattingEnabled = true;
            this.cbGV.Location = new System.Drawing.Point(209, 111);
            this.cbGV.Name = "cbGV";
            this.cbGV.Size = new System.Drawing.Size(162, 21);
            this.cbGV.TabIndex = 7;
            this.cbGV.ValueMember = "MAGV";
            // 
            // v_DSTKBindingSource
            // 
            this.v_DSTKBindingSource.DataMember = "V_DSTK";
            this.v_DSTKBindingSource.DataSource = this.dsLOGIN;
            // 
            // edtPass
            // 
            this.edtPass.Location = new System.Drawing.Point(209, 73);
            this.edtPass.Name = "edtPass";
            this.edtPass.Size = new System.Drawing.Size(162, 21);
            this.edtPass.TabIndex = 5;
            // 
            // edtUser
            // 
            this.edtUser.Location = new System.Drawing.Point(209, 37);
            this.edtUser.Name = "edtUser";
            this.edtUser.Size = new System.Drawing.Size(162, 21);
            this.edtUser.TabIndex = 4;
            // 
            // lbNhomQuyen
            // 
            this.lbNhomQuyen.AutoSize = true;
            this.lbNhomQuyen.Location = new System.Drawing.Point(81, 149);
            this.lbNhomQuyen.Name = "lbNhomQuyen";
            this.lbNhomQuyen.Size = new System.Drawing.Size(67, 13);
            this.lbNhomQuyen.TabIndex = 3;
            this.lbNhomQuyen.Text = "Nhóm quyền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // v_DSTKTableAdapter
            // 
            this.v_DSTKTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.Connection = null;
            this.tableAdapterManager2.UpdateOrder = TTN_PT.DsLOGINTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // v_DSNHOMBindingSource
            // 
            this.v_DSNHOMBindingSource.DataMember = "V_DSNHOM";
            this.v_DSNHOMBindingSource.DataSource = this.dsLOGIN;
            // 
            // v_DSNHOMTableAdapter
            // 
            this.v_DSNHOMTableAdapter.ClearBeforeFill = true;
            // 
            // v_DSTKSVTableAdapter
            // 
            this.v_DSTKSVTableAdapter.ClearBeforeFill = true;
            // 
            // cbSV
            // 
            this.cbSV.DataSource = this.v_DSTKSVBindingSource;
            this.cbSV.DisplayMember = "MASV";
            this.cbSV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSV.FormattingEnabled = true;
            this.cbSV.Location = new System.Drawing.Point(209, 111);
            this.cbSV.Name = "cbSV";
            this.cbSV.Size = new System.Drawing.Size(162, 21);
            this.cbSV.TabIndex = 8;
            this.cbSV.ValueMember = "MASV";
            // 
            // FormTaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupbox);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormTaoLogin";
            this.Text = "FormTaoLogin";
            this.Load += new System.EventHandler(this.FormTaoLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.groupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_VIEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTN_DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIAOVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GIAOVIENGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SINHVIENGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSNHOMBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLOGIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSTKSVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSTKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSNHOMBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource v_DS_PHANMANHBindingSource;
        private DS_VIEW dS_VIEW;
        private System.Windows.Forms.GroupBox groupbox;
        private DS_VIEWTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private DS_VIEWTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cbCoSo;
        private TTN_DS tTN_DS;
        private System.Windows.Forms.BindingSource gIAOVIENBindingSource;
        private TTN_DSTableAdapters.GIAOVIENTableAdapter gIAOVIENTableAdapter;
        private TTN_DSTableAdapters.TableAdapterManager tableAdapterManager1;
        private DevExpress.XtraGrid.GridControl GIAOVIENGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private TTN_DSTableAdapters.SINHVIENTableAdapter sINHVIENTableAdapter;
        private System.Windows.Forms.BindingSource sINHVIENBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox edtPass;
        private System.Windows.Forms.TextBox edtUser;
        private System.Windows.Forms.Label lbNhomQuyen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl SINHVIENGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DsLOGIN dsLOGIN;
        private System.Windows.Forms.BindingSource v_DSTKBindingSource;
        private DsLOGINTableAdapters.V_DSTKTableAdapter v_DSTKTableAdapter;
        private DsLOGINTableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.ComboBox cbGV;
        private System.Windows.Forms.BindingSource v_DSNHOMBindingSource;
        private DsLOGINTableAdapters.V_DSNHOMTableAdapter v_DSNHOMTableAdapter;
        private System.Windows.Forms.BindingSource v_DSTKSVBindingSource;
        private DsLOGINTableAdapters.V_DSTKSVTableAdapter v_DSTKSVTableAdapter;
        private DevExpress.XtraBars.BarButtonItem btnThemGv;
        private DevExpress.XtraBars.BarButtonItem btnThemSv;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbNhomQuyen;
        private System.Windows.Forms.BindingSource v_DSNHOMBindingSource1;
        private System.Windows.Forms.ComboBox cbSV;
    }
}