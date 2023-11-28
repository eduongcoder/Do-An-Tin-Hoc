namespace Do_An_Tin_Hoc
{
    partial class frmTrangChuAdmin
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
            this.btnNhanSu = new System.Windows.Forms.Button();
            this.btnKho = new System.Windows.Forms.Button();
            this.btnDoanhSo = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.btnCaLam = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trang chủ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnNhanSu
            // 
            this.btnNhanSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanSu.Location = new System.Drawing.Point(70, 186);
            this.btnNhanSu.Name = "btnNhanSu";
            this.btnNhanSu.Size = new System.Drawing.Size(151, 79);
            this.btnNhanSu.TabIndex = 1;
            this.btnNhanSu.Text = "Nhân Sự";
            this.btnNhanSu.UseVisualStyleBackColor = true;
            this.btnNhanSu.Click += new System.EventHandler(this.btnNhanSu_Click);
            // 
            // btnKho
            // 
            this.btnKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKho.Location = new System.Drawing.Point(566, 186);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(151, 79);
            this.btnKho.TabIndex = 1;
            this.btnKho.Text = "Kho Và Nhập Kho";
            this.btnKho.UseVisualStyleBackColor = true;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnDoanhSo
            // 
            this.btnDoanhSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhSo.Location = new System.Drawing.Point(70, 291);
            this.btnDoanhSo.Name = "btnDoanhSo";
            this.btnDoanhSo.Size = new System.Drawing.Size(151, 79);
            this.btnDoanhSo.TabIndex = 1;
            this.btnDoanhSo.Text = "Doanh Số Bán Hàng";
            this.btnDoanhSo.UseVisualStyleBackColor = true;
            this.btnDoanhSo.Click += new System.EventHandler(this.btnDoanhSo_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanHang.Location = new System.Drawing.Point(566, 291);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(151, 79);
            this.btnBanHang.TabIndex = 1;
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.UseVisualStyleBackColor = true;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnCaLam
            // 
            this.btnCaLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaLam.Location = new System.Drawing.Point(326, 186);
            this.btnCaLam.Name = "btnCaLam";
            this.btnCaLam.Size = new System.Drawing.Size(151, 79);
            this.btnCaLam.TabIndex = 1;
            this.btnCaLam.Text = "Ca Làm";
            this.btnCaLam.UseVisualStyleBackColor = true;
            this.btnCaLam.Click += new System.EventHandler(this.btnCaLam_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTK.Location = new System.Drawing.Point(326, 291);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(151, 79);
            this.btnXoaTK.TabIndex = 1;
            this.btnXoaTK.Text = "Xóa Tài Khoản";
            this.btnXoaTK.UseVisualStyleBackColor = true;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // frmTrangChuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXoaTK);
            this.Controls.Add(this.btnCaLam);
            this.Controls.Add(this.btnKho);
            this.Controls.Add(this.btnBanHang);
            this.Controls.Add(this.btnDoanhSo);
            this.Controls.Add(this.btnNhanSu);
            this.Controls.Add(this.label1);
            this.Name = "frmTrangChuAdmin";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.frmTrangChuAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNhanSu;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Button btnDoanhSo;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnCaLam;
        private System.Windows.Forms.Button btnXoaTK;
    }
}