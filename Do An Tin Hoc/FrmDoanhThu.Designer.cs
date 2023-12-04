namespace Do_An_Tin_Hoc
{
    partial class FrmDoanhThu
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.btnNgay = new System.Windows.Forms.Button();
            this.btnThang = new System.Windows.Forms.Button();
            this.btnNam = new System.Windows.Forms.Button();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.cboMatHang = new System.Windows.Forms.ComboBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.ckbBC = new System.Windows.Forms.CheckBox();
            this.ckbTTG = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doanh Thu";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv.Location = new System.Drawing.Point(27, 187);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(757, 286);
            this.dgv.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "m_TenMatHang";
            this.Column1.HeaderText = "Tên Mặt Hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "m_GiaTien";
            this.Column2.HeaderText = "Giá Tiền";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "m_SoLuong";
            this.Column3.HeaderText = "Số Lượng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "m_NgayMuaHang";
            this.Column4.HeaderText = "Thời Gian";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(705, 479);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(79, 41);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(216, 99);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(200, 22);
            this.dtp.TabIndex = 4;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // btnNgay
            // 
            this.btnNgay.Location = new System.Drawing.Point(516, 133);
            this.btnNgay.Name = "btnNgay";
            this.btnNgay.Size = new System.Drawing.Size(85, 45);
            this.btnNgay.TabIndex = 5;
            this.btnNgay.Text = "Ngày";
            this.btnNgay.UseVisualStyleBackColor = true;
            this.btnNgay.Click += new System.EventHandler(this.btnNgay_Click);
            // 
            // btnThang
            // 
            this.btnThang.Location = new System.Drawing.Point(605, 133);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(85, 45);
            this.btnThang.TabIndex = 5;
            this.btnThang.Text = "Tháng";
            this.btnThang.UseVisualStyleBackColor = true;
            this.btnThang.Click += new System.EventHandler(this.btnThang_Click);
            // 
            // btnNam
            // 
            this.btnNam.Location = new System.Drawing.Point(696, 133);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(85, 45);
            this.btnNam.TabIndex = 5;
            this.btnNam.Text = "Năm";
            this.btnNam.UseVisualStyleBackColor = true;
            this.btnNam.Click += new System.EventHandler(this.btnNam_Click);
            // 
            // btnTatCa
            // 
            this.btnTatCa.Location = new System.Drawing.Point(605, 82);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(85, 45);
            this.btnTatCa.TabIndex = 5;
            this.btnTatCa.Text = "Tất Cả";
            this.btnTatCa.UseVisualStyleBackColor = true;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // cboMatHang
            // 
            this.cboMatHang.FormattingEnabled = true;
            this.cboMatHang.Location = new System.Drawing.Point(216, 127);
            this.cboMatHang.Name = "cboMatHang";
            this.cboMatHang.Size = new System.Drawing.Size(200, 24);
            this.cboMatHang.TabIndex = 6;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(422, 127);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(64, 24);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // ckbBC
            // 
            this.ckbBC.AutoSize = true;
            this.ckbBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbBC.Location = new System.Drawing.Point(27, 129);
            this.ckbBC.Name = "ckbBC";
            this.ckbBC.Size = new System.Drawing.Size(104, 24);
            this.ckbBC.TabIndex = 7;
            this.ckbBC.Text = "Bán Chạy";
            this.ckbBC.UseVisualStyleBackColor = true;
            // 
            // ckbTTG
            // 
            this.ckbTTG.AutoSize = true;
            this.ckbTTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTTG.Location = new System.Drawing.Point(27, 99);
            this.ckbTTG.Name = "ckbTTG";
            this.ckbTTG.Size = new System.Drawing.Size(145, 24);
            this.ckbTTG.TabIndex = 7;
            this.ckbTTG.Text = "Toàn Thời Gian";
            this.ckbTTG.UseVisualStyleBackColor = true;
            this.ckbTTG.CheckedChanged += new System.EventHandler(this.ckbTTG_CheckedChanged);
            // 
            // FrmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 541);
            this.Controls.Add(this.ckbTTG);
            this.Controls.Add(this.ckbBC);
            this.Controls.Add(this.cboMatHang);
            this.Controls.Add(this.btnNam);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.btnThang);
            this.Controls.Add(this.btnNgay);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Name = "FrmDoanhThu";
            this.Text = "Doanh Thu";
            this.Load += new System.EventHandler(this.FrmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Button btnNgay;
        private System.Windows.Forms.Button btnThang;
        private System.Windows.Forms.Button btnNam;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.ComboBox cboMatHang;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.CheckBox ckbBC;
        private System.Windows.Forms.CheckBox ckbTTG;
    }
}