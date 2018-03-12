namespace QuanLyTV
{
    partial class MuonTraSach
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
            this.dtMuonTraSach = new System.Windows.Forms.DataGridView();
            this.cmbMaNV = new System.Windows.Forms.ComboBox();
            this.nhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMaThe = new System.Windows.Forms.ComboBox();
            this.theThuVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thuViendemo1DataSet2 = new QuanLyTV.ThuViendemo1DataSet2();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.theThuVienTableAdapter = new QuanLyTV.ThuViendemo1DataSet2TableAdapters.TheThuVienTableAdapter();
            this.btnNV = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.btnNXB = new System.Windows.Forms.Button();
            this.btnTL = new System.Windows.Forms.Button();
            this.btnTGTS = new System.Windows.Forms.Button();
            this.btnNN = new System.Windows.Forms.Button();
            this.btnTG = new System.Windows.Forms.Button();
            this.btnCTPM = new System.Windows.Forms.Button();
            this.btnTTV = new System.Windows.Forms.Button();
            this.btnVT = new System.Windows.Forms.Button();
            this.btnTS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtMuonTraSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theThuVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thuViendemo1DataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtMuonTraSach
            // 
            this.dtMuonTraSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtMuonTraSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMuonTraSach.Location = new System.Drawing.Point(10, 269);
            this.dtMuonTraSach.Name = "dtMuonTraSach";
            this.dtMuonTraSach.RowTemplate.Height = 24;
            this.dtMuonTraSach.Size = new System.Drawing.Size(960, 372);
            this.dtMuonTraSach.TabIndex = 80;
            this.dtMuonTraSach.SelectionChanged += new System.EventHandler(this.dtMuonTraSach_SelectionChanged);
            // 
            // cmbMaNV
            // 
            this.cmbMaNV.FormattingEnabled = true;
            this.cmbMaNV.Location = new System.Drawing.Point(764, 102);
            this.cmbMaNV.Name = "cmbMaNV";
            this.cmbMaNV.Size = new System.Drawing.Size(164, 24);
            this.cmbMaNV.TabIndex = 79;
            // 
            // nhanVienBindingSource
            // 
            this.nhanVienBindingSource.DataMember = "NhanVien";
            // 
            // cmbMaThe
            // 
            this.cmbMaThe.FormattingEnabled = true;
            this.cmbMaThe.Location = new System.Drawing.Point(764, 60);
            this.cmbMaThe.Name = "cmbMaThe";
            this.cmbMaThe.Size = new System.Drawing.Size(164, 24);
            this.cmbMaThe.TabIndex = 78;
            // 
            // theThuVienBindingSource
            // 
            this.theThuVienBindingSource.DataMember = "TheThuVien";
            this.theThuVienBindingSource.DataSource = this.thuViendemo1DataSet2;
            // 
            // thuViendemo1DataSet2
            // 
            this.thuViendemo1DataSet2.DataSetName = "ThuViendemo1DataSet2";
            this.thuViendemo1DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(633, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "Mã Nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 76;
            this.label3.Text = "Mã thẻ";
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTra.Location = new System.Drawing.Point(380, 103);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayTra.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "Ngày trả";
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayMuon.Location = new System.Drawing.Point(380, 62);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayMuon.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 72;
            this.label5.Text = "Ngày Mượn";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(825, 227);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 71;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(676, 199);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(249, 22);
            this.txtTimKiem.TabIndex = 70;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(573, 154);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 69;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(453, 154);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 68;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(326, 154);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 67;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(207, 154);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 66;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(84, 154);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 65;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtMa
            // 
            this.txtMa.Enabled = false;
            this.txtMa.Location = new System.Drawing.Point(154, 62);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(85, 22);
            this.txtMa.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "Mã phiếu mượn";
            // 
            // theThuVienTableAdapter
            // 
            this.theThuVienTableAdapter.ClearBeforeFill = true;
            // 
            // btnNV
            // 
            this.btnNV.Location = new System.Drawing.Point(92, 12);
            this.btnNV.Margin = new System.Windows.Forms.Padding(4);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(82, 28);
            this.btnNV.TabIndex = 92;
            this.btnNV.Text = "Nhân Viên";
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(805, 13);
            this.btnS.Margin = new System.Windows.Forms.Padding(4);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(78, 27);
            this.btnS.TabIndex = 90;
            this.btnS.Text = "Sách";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnNXB
            // 
            this.btnNXB.Location = new System.Drawing.Point(182, 13);
            this.btnNXB.Margin = new System.Windows.Forms.Padding(4);
            this.btnNXB.Name = "btnNXB";
            this.btnNXB.Size = new System.Drawing.Size(78, 27);
            this.btnNXB.TabIndex = 89;
            this.btnNXB.Text = "NXB";
            this.btnNXB.UseVisualStyleBackColor = true;
            this.btnNXB.Click += new System.EventHandler(this.btnNXB_Click);
            // 
            // btnTL
            // 
            this.btnTL.Location = new System.Drawing.Point(535, 13);
            this.btnTL.Margin = new System.Windows.Forms.Padding(4);
            this.btnTL.Name = "btnTL";
            this.btnTL.Size = new System.Drawing.Size(78, 27);
            this.btnTL.TabIndex = 88;
            this.btnTL.Text = "Thể Loại";
            this.btnTL.UseVisualStyleBackColor = true;
            this.btnTL.Click += new System.EventHandler(this.btnTL_Click);
            // 
            // btnTGTS
            // 
            this.btnTGTS.Location = new System.Drawing.Point(720, 13);
            this.btnTGTS.Margin = new System.Windows.Forms.Padding(4);
            this.btnTGTS.Name = "btnTGTS";
            this.btnTGTS.Size = new System.Drawing.Size(78, 27);
            this.btnTGTS.TabIndex = 87;
            this.btnTGTS.Text = "TG_TS";
            this.btnTGTS.UseVisualStyleBackColor = true;
            this.btnTGTS.Click += new System.EventHandler(this.btnTGTS_Click);
            // 
            // btnNN
            // 
            this.btnNN.Location = new System.Drawing.Point(352, 13);
            this.btnNN.Margin = new System.Windows.Forms.Padding(4);
            this.btnNN.Name = "btnNN";
            this.btnNN.Size = new System.Drawing.Size(93, 27);
            this.btnNN.TabIndex = 86;
            this.btnNN.Text = "Ngôn Ngữ";
            this.btnNN.UseVisualStyleBackColor = true;
            this.btnNN.Click += new System.EventHandler(this.btnNN_Click);
            // 
            // btnTG
            // 
            this.btnTG.Location = new System.Drawing.Point(267, 13);
            this.btnTG.Margin = new System.Windows.Forms.Padding(4);
            this.btnTG.Name = "btnTG";
            this.btnTG.Size = new System.Drawing.Size(78, 27);
            this.btnTG.TabIndex = 85;
            this.btnTG.Text = "TacGia";
            this.btnTG.UseVisualStyleBackColor = true;
            this.btnTG.Click += new System.EventHandler(this.btnTG_Click);
            // 
            // btnCTPM
            // 
            this.btnCTPM.Location = new System.Drawing.Point(890, 12);
            this.btnCTPM.Margin = new System.Windows.Forms.Padding(4);
            this.btnCTPM.Name = "btnCTPM";
            this.btnCTPM.Size = new System.Drawing.Size(78, 28);
            this.btnCTPM.TabIndex = 84;
            this.btnCTPM.Text = "CTPM";
            this.btnCTPM.UseVisualStyleBackColor = true;
            this.btnCTPM.Click += new System.EventHandler(this.btnCTPM_Click);
            // 
            // btnTTV
            // 
            this.btnTTV.Location = new System.Drawing.Point(16, 12);
            this.btnTTV.Margin = new System.Windows.Forms.Padding(4);
            this.btnTTV.Name = "btnTTV";
            this.btnTTV.Size = new System.Drawing.Size(69, 28);
            this.btnTTV.TabIndex = 83;
            this.btnTTV.Text = "Thẻ TV";
            this.btnTTV.UseVisualStyleBackColor = true;
            this.btnTTV.Click += new System.EventHandler(this.btnTTV_Click);
            // 
            // btnVT
            // 
            this.btnVT.Location = new System.Drawing.Point(453, 12);
            this.btnVT.Margin = new System.Windows.Forms.Padding(4);
            this.btnVT.Name = "btnVT";
            this.btnVT.Size = new System.Drawing.Size(74, 28);
            this.btnVT.TabIndex = 82;
            this.btnVT.Text = "Vị Trí";
            this.btnVT.UseVisualStyleBackColor = true;
            this.btnVT.Click += new System.EventHandler(this.btnVT_Click);
            // 
            // btnTS
            // 
            this.btnTS.Location = new System.Drawing.Point(620, 12);
            this.btnTS.Margin = new System.Windows.Forms.Padding(4);
            this.btnTS.Name = "btnTS";
            this.btnTS.Size = new System.Drawing.Size(93, 28);
            this.btnTS.TabIndex = 81;
            this.btnTS.Text = "Tựa Sách";
            this.btnTS.UseVisualStyleBackColor = true;
            this.btnTS.Click += new System.EventHandler(this.btnTS_Click);
            // 
            // MuonTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.btnNV);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnNXB);
            this.Controls.Add(this.btnTL);
            this.Controls.Add(this.btnTGTS);
            this.Controls.Add(this.btnNN);
            this.Controls.Add(this.btnTG);
            this.Controls.Add(this.btnCTPM);
            this.Controls.Add(this.btnTTV);
            this.Controls.Add(this.btnVT);
            this.Controls.Add(this.btnTS);
            this.Controls.Add(this.dtMuonTraSach);
            this.Controls.Add(this.cmbMaNV);
            this.Controls.Add(this.cmbMaThe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpNgayTra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpNgayMuon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label1);
            this.Name = "MuonTraSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MuonTraSach";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MuonTraSach_FormClosing);
            this.Load += new System.EventHandler(this.MuonTraSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtMuonTraSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theThuVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thuViendemo1DataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtMuonTraSach;
        private System.Windows.Forms.ComboBox cmbMaNV;
        private System.Windows.Forms.ComboBox cmbMaThe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label1;
        private ThuViendemo1DataSet2 thuViendemo1DataSet2;
        private System.Windows.Forms.BindingSource theThuVienBindingSource;
        private ThuViendemo1DataSet2TableAdapters.TheThuVienTableAdapter theThuVienTableAdapter;
        //private ThuViendemo1DataSet3 thuViendemo1DataSet3;
        private System.Windows.Forms.BindingSource nhanVienBindingSource;
        //private ThuViendemo1DataSet3TableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnNXB;
        private System.Windows.Forms.Button btnTL;
        private System.Windows.Forms.Button btnTGTS;
        private System.Windows.Forms.Button btnNN;
        private System.Windows.Forms.Button btnTG;
        private System.Windows.Forms.Button btnCTPM;
        private System.Windows.Forms.Button btnTTV;
        private System.Windows.Forms.Button btnVT;
        private System.Windows.Forms.Button btnTS;
    }
}