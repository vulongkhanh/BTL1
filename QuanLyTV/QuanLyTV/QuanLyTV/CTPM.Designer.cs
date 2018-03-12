namespace QuanLyTV
{
    partial class CTPM
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
            this.dtgCTPM = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbma = new System.Windows.Forms.ComboBox();
            this.cmbcb = new System.Windows.Forms.ComboBox();
            this.abc = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnNV = new System.Windows.Forms.Button();
            this.btnMTS = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.btnNXB = new System.Windows.Forms.Button();
            this.btnTL = new System.Windows.Forms.Button();
            this.btnTGTS = new System.Windows.Forms.Button();
            this.btnNN = new System.Windows.Forms.Button();
            this.btnTG = new System.Windows.Forms.Button();
            this.btnTTV = new System.Windows.Forms.Button();
            this.btnVT = new System.Windows.Forms.Button();
            this.btnTS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCTPM)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCTPM
            // 
            this.dtgCTPM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgCTPM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCTPM.Location = new System.Drawing.Point(16, 310);
            this.dtgCTPM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgCTPM.Name = "dtgCTPM";
            this.dtgCTPM.Size = new System.Drawing.Size(950, 328);
            this.dtgCTPM.TabIndex = 0;
            this.dtgCTPM.SelectionChanged += new System.EventHandler(this.dtgCTPM_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "mã CTM";
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(123, 108);
            this.txtma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(104, 22);
            this.txtma.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "mã PMT";
            // 
            // cmbma
            // 
            this.cmbma.FormattingEnabled = true;
            this.cmbma.Location = new System.Drawing.Point(319, 107);
            this.cmbma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbma.Name = "cmbma";
            this.cmbma.Size = new System.Drawing.Size(160, 24);
            this.cmbma.TabIndex = 4;
            // 
            // cmbcb
            // 
            this.cmbcb.FormattingEnabled = true;
            this.cmbcb.Location = new System.Drawing.Point(566, 107);
            this.cmbcb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbcb.Name = "cmbcb";
            this.cmbcb.Size = new System.Drawing.Size(160, 24);
            this.cmbcb.TabIndex = 6;
            // 
            // abc
            // 
            this.abc.AutoSize = true;
            this.abc.Location = new System.Drawing.Point(495, 112);
            this.abc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.abc.Name = "abc";
            this.abc.Size = new System.Drawing.Size(42, 17);
            this.abc.TabIndex = 5;
            this.abc.Text = "số cb";
            // 
            // btnTim
            // 
            this.btnTim.Enabled = false;
            this.btnTim.Location = new System.Drawing.Point(856, 219);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 28);
            this.btnTim.TabIndex = 38;
            this.btnTim.Text = "Tìm Kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(564, 196);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 37;
            this.btnReset.Text = "Trở lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(437, 196);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(119, 28);
            this.btnLuu.TabIndex = 36;
            this.btnLuu.Text = "Lưu Thay Đổi";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(272, 196);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 28);
            this.btnXoa.TabIndex = 35;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(141, 196);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 28);
            this.btnSua.TabIndex = 34;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 196);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 28);
            this.btnThem.TabIndex = 33;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(824, 171);
            this.txtTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(132, 22);
            this.txtTim.TabIndex = 39;
            // 
            // btnNV
            // 
            this.btnNV.Location = new System.Drawing.Point(97, 27);
            this.btnNV.Margin = new System.Windows.Forms.Padding(4);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(69, 28);
            this.btnNV.TabIndex = 138;
            this.btnNV.Text = "NV";
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnMTS
            // 
            this.btnMTS.Location = new System.Drawing.Point(168, 27);
            this.btnMTS.Margin = new System.Windows.Forms.Padding(4);
            this.btnMTS.Name = "btnMTS";
            this.btnMTS.Size = new System.Drawing.Size(78, 28);
            this.btnMTS.TabIndex = 137;
            this.btnMTS.Text = "Mượn Trả Sách";
            this.btnMTS.UseVisualStyleBackColor = true;
            this.btnMTS.Click += new System.EventHandler(this.btnMTS_Click);
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(876, 28);
            this.btnS.Margin = new System.Windows.Forms.Padding(4);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(78, 27);
            this.btnS.TabIndex = 136;
            this.btnS.Text = "Sách";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnNXB
            // 
            this.btnNXB.Location = new System.Drawing.Point(253, 28);
            this.btnNXB.Margin = new System.Windows.Forms.Padding(4);
            this.btnNXB.Name = "btnNXB";
            this.btnNXB.Size = new System.Drawing.Size(78, 27);
            this.btnNXB.TabIndex = 135;
            this.btnNXB.Text = "NXB";
            this.btnNXB.UseVisualStyleBackColor = true;
            this.btnNXB.Click += new System.EventHandler(this.btnNXB_Click);
            // 
            // btnTL
            // 
            this.btnTL.Location = new System.Drawing.Point(606, 28);
            this.btnTL.Margin = new System.Windows.Forms.Padding(4);
            this.btnTL.Name = "btnTL";
            this.btnTL.Size = new System.Drawing.Size(78, 27);
            this.btnTL.TabIndex = 134;
            this.btnTL.Text = "Thể Loại";
            this.btnTL.UseVisualStyleBackColor = true;
            this.btnTL.Click += new System.EventHandler(this.btnTL_Click);
            // 
            // btnTGTS
            // 
            this.btnTGTS.Location = new System.Drawing.Point(791, 28);
            this.btnTGTS.Margin = new System.Windows.Forms.Padding(4);
            this.btnTGTS.Name = "btnTGTS";
            this.btnTGTS.Size = new System.Drawing.Size(78, 27);
            this.btnTGTS.TabIndex = 133;
            this.btnTGTS.Text = "TG_TS";
            this.btnTGTS.UseVisualStyleBackColor = true;
            this.btnTGTS.Click += new System.EventHandler(this.btnTGTS_Click);
            // 
            // btnNN
            // 
            this.btnNN.Location = new System.Drawing.Point(423, 28);
            this.btnNN.Margin = new System.Windows.Forms.Padding(4);
            this.btnNN.Name = "btnNN";
            this.btnNN.Size = new System.Drawing.Size(93, 27);
            this.btnNN.TabIndex = 132;
            this.btnNN.Text = "Ngôn Ngữ";
            this.btnNN.UseVisualStyleBackColor = true;
            this.btnNN.Click += new System.EventHandler(this.btnNN_Click);
            // 
            // btnTG
            // 
            this.btnTG.Location = new System.Drawing.Point(338, 28);
            this.btnTG.Margin = new System.Windows.Forms.Padding(4);
            this.btnTG.Name = "btnTG";
            this.btnTG.Size = new System.Drawing.Size(78, 27);
            this.btnTG.TabIndex = 131;
            this.btnTG.Text = "TacGia";
            this.btnTG.UseVisualStyleBackColor = true;
            this.btnTG.Click += new System.EventHandler(this.btnTG_Click);
            // 
            // btnTTV
            // 
            this.btnTTV.Location = new System.Drawing.Point(12, 27);
            this.btnTTV.Margin = new System.Windows.Forms.Padding(4);
            this.btnTTV.Name = "btnTTV";
            this.btnTTV.Size = new System.Drawing.Size(78, 28);
            this.btnTTV.TabIndex = 130;
            this.btnTTV.Text = "TTV";
            this.btnTTV.UseVisualStyleBackColor = true;
            this.btnTTV.Click += new System.EventHandler(this.btnTTV_Click);
            // 
            // btnVT
            // 
            this.btnVT.Location = new System.Drawing.Point(524, 27);
            this.btnVT.Margin = new System.Windows.Forms.Padding(4);
            this.btnVT.Name = "btnVT";
            this.btnVT.Size = new System.Drawing.Size(74, 28);
            this.btnVT.TabIndex = 129;
            this.btnVT.Text = "Vị Trí";
            this.btnVT.UseVisualStyleBackColor = true;
            this.btnVT.Click += new System.EventHandler(this.btnVT_Click);
            // 
            // btnTS
            // 
            this.btnTS.Location = new System.Drawing.Point(691, 27);
            this.btnTS.Margin = new System.Windows.Forms.Padding(4);
            this.btnTS.Name = "btnTS";
            this.btnTS.Size = new System.Drawing.Size(93, 28);
            this.btnTS.TabIndex = 128;
            this.btnTS.Text = "Tựa Sách";
            this.btnTS.UseVisualStyleBackColor = true;
            this.btnTS.Click += new System.EventHandler(this.btnTS_Click);
            // 
            // CTPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.btnNV);
            this.Controls.Add(this.btnMTS);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnNXB);
            this.Controls.Add(this.btnTL);
            this.Controls.Add(this.btnTGTS);
            this.Controls.Add(this.btnNN);
            this.Controls.Add(this.btnTG);
            this.Controls.Add(this.btnTTV);
            this.Controls.Add(this.btnVT);
            this.Controls.Add(this.btnTS);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cmbcb);
            this.Controls.Add(this.abc);
            this.Controls.Add(this.cmbma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgCTPM);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CTPM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CTPM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CTPM_FormClosing);
            this.Load += new System.EventHandler(this.CTPM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCTPM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCTPM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbma;
        private System.Windows.Forms.ComboBox cmbcb;
        private System.Windows.Forms.Label abc;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Button btnMTS;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnNXB;
        private System.Windows.Forms.Button btnTL;
        private System.Windows.Forms.Button btnTGTS;
        private System.Windows.Forms.Button btnNN;
        private System.Windows.Forms.Button btnTG;
        private System.Windows.Forms.Button btnTTV;
        private System.Windows.Forms.Button btnVT;
        private System.Windows.Forms.Button btnTS;
    }
}