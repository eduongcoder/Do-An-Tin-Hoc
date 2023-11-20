using System;
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
    public partial class frmTrangChuNhanVien : Form
    {
        public frmTrangChuNhanVien()
        {
            InitializeComponent();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
           frmKho frmKho = new frmKho();
            this.Hide();
            frmKho.ShowDialog();
            this.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frmBanHang = new frmBanHang();
            this.Hide();
            frmBanHang.ShowDialog();
            this.Show();
        }

        private void btnCaLam_Click(object sender, EventArgs e)
        {
            frmCaLamNV frmCaLam = new frmCaLamNV();
            this.Hide();
            frmCaLam.ShowDialog();
            this.Show();
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            frmDiemDanh frmDiemDanh = new frmDiemDanh();
            this.Hide();
            frmDiemDanh.ShowDialog();
            this.Show();
        }
    }
}
