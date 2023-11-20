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
    public partial class frmDangKy : Form
    {
        private readonly CXuLy xuly = new CXuLy();
        private string diachiDSTaiKhoan = "DanhSachTaiKhoan.txt";
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có đồng ý thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            CTaiKhoan taiKhoan = new CTaiKhoan();
            taiKhoan.Taikhoan = txtTaiKhoan.Text;
            taiKhoan.Matkhau = txtMatKhau.Text;
            taiKhoan.LoaiTK = false;
            xuly.ThemTaiKoan(taiKhoan);
            xuly.luuFileTaiKhaon(diachiDSTaiKhoan);
            MessageBox.Show("Đăng ký thành công!");
            this.Close();
        }
    }
}
