﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Tin_Hoc
{
    public partial class frmTrangChuAdmin : Form
    {
        private readonly CXuLy xuly =new CXuLy();
        public frmTrangChuAdmin()
        {
            InitializeComponent();
        }
        private void btnNhanSu_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmNhanSuAdmin nhanSu = new frmNhanSuAdmin();
            nhanSu.ShowDialog();
            this.Show();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKho kho = new frmKho();
            kho.ShowDialog();
            this.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBanHang nhban = new frmBanHang();
            nhban.ShowDialog();
            this.Show();
        }

        private void frmTrangChuAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnDoanhSo_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDoanhThu frmDoanhThu = new FrmDoanhThu();
            frmDoanhThu.ShowDialog();
            this.Show();
        }

        private void btnCaLam_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCaLamAdmin frmCaLamAdmin = new frmCaLamAdmin();
            frmCaLamAdmin.ShowDialog();
            this.Show();
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmXoaTaiKhoan frmXoaTaiKhoan = new frmXoaTaiKhoan();
            frmXoaTaiKhoan.ShowDialog();                     
            this.Show();
        }
    }
}
