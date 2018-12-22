namespace TTN_PT
{
    partial class FormInDiemTheoMonHoc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenlop = new System.Windows.Forms.TextBox();
            this.txtTenmon = new System.Windows.Forms.TextBox();
            this.txtLanthi = new System.Windows.Forms.TextBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dS_VIEW = new TTN_PT.DS_VIEW();
            this.v_DS_PHANMANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_DS_PHANMANHTableAdapter = new TTN_PT.DS_VIEWTableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager = new TTN_PT.DS_VIEWTableAdapters.TableAdapterManager();
            this.cbCoSo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tTN_DS = new TTN_PT.TTN_DS();
            this.sp_8BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_8TableAdapter = new TTN_PT.TTN_DSTableAdapters.sp_8TableAdapter();
            this.tableAdapterManager1 = new TTN_PT.TTN_DSTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dS_VIEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTN_DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_8BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "TÊN LỚP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "TÊN MÔN HỌC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "LẦN THI";
            // 
            // txtTenlop
            // 
            this.txtTenlop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenlop.Location = new System.Drawing.Point(186, 82);
            this.txtTenlop.Name = "txtTenlop";
            this.txtTenlop.Size = new System.Drawing.Size(275, 22);
            this.txtTenlop.TabIndex = 3;
            // 
            // txtTenmon
            // 
            this.txtTenmon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenmon.Location = new System.Drawing.Point(186, 126);
            this.txtTenmon.Name = "txtTenmon";
            this.txtTenmon.Size = new System.Drawing.Size(275, 22);
            this.txtTenmon.TabIndex = 4;
            // 
            // txtLanthi
            // 
            this.txtLanthi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLanthi.Location = new System.Drawing.Point(186, 163);
            this.txtLanthi.Name = "txtLanthi";
            this.txtLanthi.Size = new System.Drawing.Size(275, 22);
            this.txtLanthi.TabIndex = 5;
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(200, 220);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(83, 24);
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(386, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 7;
            this.button2.Text = "EXIT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = TTN_PT.DS_VIEWTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cbCoSo
            // 
            this.cbCoSo.DataSource = this.v_DS_PHANMANHBindingSource;
            this.cbCoSo.DisplayMember = "TENCS";
            this.cbCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoSo.FormattingEnabled = true;
            this.cbCoSo.Location = new System.Drawing.Point(186, 33);
            this.cbCoSo.Name = "cbCoSo";
            this.cbCoSo.Size = new System.Drawing.Size(275, 21);
            this.cbCoSo.TabIndex = 9;
            this.cbCoSo.ValueMember = "TENSERVER";
            this.cbCoSo.SelectedIndexChanged += new System.EventHandler(this.v_DS_PHANMANHComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "CƠ SỞ";
            // 
            // tTN_DS
            // 
            this.tTN_DS.DataSetName = "TTN_DS";
            this.tTN_DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_8BindingSource
            // 
            this.sp_8BindingSource.DataMember = "sp_8";
            this.sp_8BindingSource.DataSource = this.tTN_DS;
            // 
            // sp_8TableAdapter
            // 
            this.sp_8TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.BANGDIEMTableAdapter = null;
            this.tableAdapterManager1.BODETableAdapter = null;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.COSOTableAdapter = null;
            this.tableAdapterManager1.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager1.GIAOVIENTableAdapter = null;
            this.tableAdapterManager1.KHOATableAdapter = null;
            this.tableAdapterManager1.LOPTableAdapter = null;
            this.tableAdapterManager1.MONHOCTableAdapter = null;
            this.tableAdapterManager1.SINHVIENTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = TTN_PT.TTN_DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // FormInDiemTheoMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 270);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCoSo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.txtLanthi);
            this.Controls.Add(this.txtTenmon);
            this.Controls.Add(this.txtTenlop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormInDiemTheoMonHoc";
            this.Text = "FormInDiemTheoMonHoc";
            this.Load += new System.EventHandler(this.FormInDiemTheoMonHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_VIEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTN_DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_8BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnIn;
        public System.Windows.Forms.TextBox txtTenlop;
        public System.Windows.Forms.TextBox txtTenmon;
        public System.Windows.Forms.TextBox txtLanthi;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private DS_VIEW dS_VIEW;
        private System.Windows.Forms.BindingSource v_DS_PHANMANHBindingSource;
        private DS_VIEWTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private DS_VIEWTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cbCoSo;
        private System.Windows.Forms.Label label4;
        private TTN_DS tTN_DS;
        private System.Windows.Forms.BindingSource sp_8BindingSource;
        private TTN_DSTableAdapters.sp_8TableAdapter sp_8TableAdapter;
        private TTN_DSTableAdapters.TableAdapterManager tableAdapterManager1;
    }
}