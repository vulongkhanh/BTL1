namespace QuanLyTV
{
    partial class NhanVien
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
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNhanVien = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnMTS = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Location = new System.Drawing.Point(414, 108);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(200, 22);
            this.txtGioiTinh.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 57;
            this.label6.Text = "Giới tính";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(414, 63);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 22);
            this.dtpNgaySinh.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 55;
            this.label5.Text = "Ngày sinh";
            // 
            // dtNhanVien
            // 
            this.dtNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtNhanVien.Location = new System.Drawing.Point(7, 294);
            this.dtNhanVien.Name = "dtNhanVien";
            this.dtNhanVien.RowTemplate.Height = 24;
            this.dtNhanVien.Size = new System.Drawing.Size(963, 347);
            this.dtNhanVien.TabIndex = 54;
            this.dtNhanVien.SelectionChanged += new System.EventHandler(this.dtNhanVien_SelectionChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(887, 250);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 53;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(714, 211);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(249, 22);
            this.txtTimKiem.TabIndex = 52;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(888, 159);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 51;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(771, 159);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 50;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(360, 159);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 49;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(241, 159);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 48;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(118, 159);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 47;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(652, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(652, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "SĐT";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(118, 110);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(152, 22);
            this.txtHoTen.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "Họ tên";
            // 
            // txtMa
            // 
            this.txtMa.Enabled = false;
            this.txtMa.Location = new System.Drawing.Point(118, 62);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(85, 22);
            this.txtMa.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Mã NV";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(729, 63);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(200, 22);
            this.txtSDT.TabIndex = 59;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(729, 105);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(200, 22);
            this.txtDiaChi.TabIndex = 60;
            // 
            // btnMTS
            // 
            this.btnMTS.Location = new System.Drawing.Point(94, 13);
            this.btnMTS.Margin = new System.Windows.Forms.Padding(4);
            this.btnMTS.Name = "btnMTS";
            this.btnMTS.Size = new System.Drawing.Size(78, 28);
            this.btnMTS.TabIndex = 103;
            this.btnMTS.Text = "Mượn Trả Sách";
            this.btnMTS.UseVisualStyleBackColor = true;
            this.btnMTS.Click += new System.EventHandler(this.btnMTS_Click);
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(802, 14);
            this.btnS.Margin = new System.Windows.Forms.Padding(4);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(78, 27);
            this.btnS.TabIndex = 102;
            this.btnS.Text = "Sách";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnNXB
            // 
            this.btnNXB.Location = new System.Drawing.Point(179, 14);
            this.btnNXB.Margin = new System.Windows.Forms.Padding(4);
            this.btnNXB.Name = "btnNXB";
            this.btnNXB.Size = new System.Drawing.Size(78, 27);
            this.btnNXB.TabIndex = 101;
            this.btnNXB.Text = "NXB";
            this.btnNXB.UseVisualStyleBackColor = true;
            this.btnNXB.Click += new System.EventHandler(this.btnNXB_Click);
            // 
            // btnTL
            // 
            this.btnTL.Location = new System.Drawing.Point(532, 14);
            this.btnTL.Margin = new System.Windows.Forms.Padding(4);
            this.btnTL.Name = "btnTL";
            this.btnTL.Size = new System.Drawing.Size(78, 27);
            this.btnTL.TabIndex = 100;
            this.btnTL.Text = "Thể Loại";
            this.btnTL.UseVisualStyleBackColor = true;
            this.btnTL.Click += new System.EventHandler(this.btnTL_Click);
            // 
            // btnTGTS
            // 
            this.btnTGTS.Location = new System.Drawing.Point(717, 14);
            this.btnTGTS.Margin = new System.Windows.Forms.Padding(4);
            this.btnTGTS.Name = "btnTGTS";
            this.btnTGTS.Size = new System.Drawing.Size(78, 27);
            this.btnTGTS.TabIndex = 99;
            this.btnTGTS.Text = "TG_TS";
            this.btnTGTS.UseVisualStyleBackColor = true;
            this.btnTGTS.Click += new System.EventHandler(this.btnTGTS_Click);
            // 
            // btnNN
            // 
            this.btnNN.Location = new System.Drawing.Point(349, 14);
            this.btnNN.Margin = new System.Windows.Forms.Padding(4);
            this.btnNN.Name = "btnNN";
            this.btnNN.Size = new System.Drawing.Size(93, 27);
            this.btnNN.TabIndex = 98;
            this.btnNN.Text = "Ngôn Ngữ";
            this.btnNN.UseVisualStyleBackColor = true;
            this.btnNN.Click += new System.EventHandler(this.btnNN_Click);
            // 
            // btnTG
            // 
            this.btnTG.Location = new System.Drawing.Point(264, 14);
            this.btnTG.Margin = new System.Windows.Forms.Padding(4);
            this.btnTG.Name = "btnTG";
            this.btnTG.Size = new System.Drawing.Size(78, 27);
            this.btnTG.TabIndex = 97;
            this.btnTG.Text = "TacGia";
            this.btnTG.UseVisualStyleBackColor = true;
            this.btnTG.Click += new System.EventHandler(this.btnTG_Click);
            // 
            // btnCTPM
            // 
            this.btnCTPM.Location = new System.Drawing.Point(887, 13);
            this.btnCTPM.Margin = new System.Windows.Forms.Padding(4);
            this.btnCTPM.Name = "btnCTPM";
            this.btnCTPM.Size = new System.Drawing.Size(78, 28);
            this.btnCTPM.TabIndex = 96;
            this.btnCTPM.Text = "CTPM";
            this.btnCTPM.UseVisualStyleBackColor = true;
            this.btnCTPM.Click += new System.EventHandler(this.btnCTPM_Click);
            // 
            // btnTTV
            // 
            this.btnTTV.Location = new System.Drawing.Point(17, 13);
            this.btnTTV.Margin = new System.Windows.Forms.Padding(4);
            this.btnTTV.Name = "btnTTV";
            this.btnTTV.Size = new System.Drawing.Size(69, 28);
            this.btnTTV.TabIndex = 95;
            this.btnTTV.Text = "Thẻ TV";
            this.btnTTV.UseVisualStyleBackColor = true;
            this.btnTTV.Click += new System.EventHandler(this.btnTTV_Click);
            // 
            // btnVT
            // 
            this.btnVT.Location = new System.Drawing.Point(450, 13);
            this.btnVT.Margin = new System.Windows.Forms.Padding(4);
            this.btnVT.Name = "btnVT";
            this.btnVT.Size = new System.Drawing.Size(74, 28);
            this.btnVT.TabIndex = 94;
            this.btnVT.Text = "Vị Trí";
            this.btnVT.UseVisualStyleBackColor = true;
            this.btnVT.Click += new System.EventHandler(this.btnVT_Click);
            // 
            // btnTS
            // 
            this.btnTS.Location = new System.Drawing.Point(617, 13);
            this.btnTS.Margin = new System.Windows.Forms.Padding(4);
            this.btnTS.Name = "btnTS";
            this.btnTS.Size = new System.Drawing.Size(93, 28);
            this.btnTS.TabIndex = 93;
            this.btnTS.Text = "Tựa Sách";
            this.btnTS.UseVisualStyleBackColor = true;
            this.btnTS.Click += new System.EventHandler(this.btnTS_Click);
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.btnMTS);
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
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtGioiTinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtNhanVien);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label1);
            this.Name = "NhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhanVien";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NhanVien_FormClosing);
            this.Load += new System.EventHandler(this.NhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtNhanVien;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnMTS;
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