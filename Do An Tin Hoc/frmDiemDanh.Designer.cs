namespace Do_An_Tin_Hoc
{
    partial class frmDiemDanh
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
            this.cboTen = new System.Windows.Forms.ComboBox();
            this.cboCaLam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDiemDanh = new System.Windows.Forms.Button();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 58);
            this.label1.TabIndex = 3;
            this.label1.Text = "Điểm Danh";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboTen
            // 
            this.cboTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTen.FormattingEnabled = true;
            this.cboTen.Location = new System.Drawing.Point(379, 108);
            this.cboTen.Name = "cboTen";
            this.cboTen.Size = new System.Drawing.Size(158, 28);
            this.cboTen.TabIndex = 4;
            this.cboTen.SelectedIndexChanged += new System.EventHandler(this.cboTen_SelectedIndexChanged);
            // 
            // cboCaLam
            // 
            this.cboCaLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCaLam.FormattingEnabled = true;
            this.cboCaLam.Location = new System.Drawing.Point(681, 108);
            this.cboCaLam.Name = "cboCaLam";
            this.cboCaLam.Size = new System.Drawing.Size(88, 28);
            this.cboCaLam.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên Nhân Viên";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(589, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ca Làm";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiemDanh.Location = new System.Drawing.Point(231, 244);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.Size = new System.Drawing.Size(336, 163);
            this.btnDiemDanh.TabIndex = 6;
            this.btnDiemDanh.Text = "Điểm Danh";
            this.btnDiemDanh.UseVisualStyleBackColor = true;
            this.btnDiemDanh.Click += new System.EventHandler(this.btnDiemDanh_Click);
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(80, 111);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(135, 22);
            this.dtp.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ngày";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.btnDiemDanh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCaLam);
            this.Controls.Add(this.cboTen);
            this.Controls.Add(this.label1);
            this.Name = "frmDiemDanh";
            this.Text = "frmDiemDanh";
            this.Load += new System.EventHandler(this.frmDiemDanh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTen;
        private System.Windows.Forms.ComboBox cboCaLam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDiemDanh;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label4;
    }
}