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
            if (choNhanVien.Checked != false || choAdmin.Checked != false)
            {
                if (CXuLy.GetDangNhap())
                {

                    lblTieuDe.Text = "Đăng Ký";
                    CTaiKhoan taiKhoan = new CTaiKhoan();
                    taiKhoan.Taikhoan = txtTaiKhoan.Text;
                    taiKhoan.Matkhau = txtMatKhau.Text;
                    taiKhoan.LoaiTK = choAdmin.Checked;

                    xuly.ThemTaiKoan(taiKhoan);
                    xuly.luuFileTaiKhaon(diachiDSTaiKhoan);
                    MessageBox.Show("Đăng ký thành công!");
                    this.Close();
                }
                else
                {
                    lblTieuDe.Text = "Đổi Mật Khẩu";

                    CTaiKhoan taiKhoan = new CTaiKhoan();
                    taiKhoan.Taikhoan = txtTaiKhoan.Text;
                    taiKhoan.Matkhau = txtMatKhau.Text;
                    taiKhoan.LoaiTK = choNhanVien.Checked;

                    if (xuly.TimTK(taiKhoan.Taikhoan) != null)
                    {
                        xuly.SuaTK(taiKhoan);
                        xuly.luuFileTaiKhaon(diachiDSTaiKhoan);
                        MessageBox.Show("Đổi mật khẩu thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không có tài khoản " + taiKhoan.Taikhoan);
                    }

                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn loại tài khoản!");
            }
        }        

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            xuly.docFileTaiKhoan(diachiDSTaiKhoan);
        }

        private void choNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if(choNhanVien.Checked==true)
            {
                choAdmin.Checked = false;
            }
            else
            {
                choAdmin.Checked = true;
            }
        }

        private void choAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (choAdmin.Checked == true)
            {
                choNhanVien.Checked = false;
            }
            else
            {
                choNhanVien.Checked = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
