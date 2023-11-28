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
    public partial class frmDKvaDoiMK : Form
    {
        private readonly CXuLy xuly = new CXuLy();
        private string diachiDSTaiKhoan = "DanhSachTaiKhoan.txt";
        public frmDKvaDoiMK()
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
            if (rdbAdmin.Checked != false || rdbNhanVien.Checked != false)
            {
                if (CXuLy.GetDangNhap())
                {
                   //Đăng Ký
                   
                    CTaiKhoan taiKhoan = new CTaiKhoan();
                    taiKhoan.Taikhoan = txtTaiKhoan.Text;
                    taiKhoan.Matkhau = txtMatKhau.Text;
                    if(rdbNhanVien.Checked)
                        taiKhoan.LoaiTK = false;
                    else
                        taiKhoan.LoaiTK = true;

                    if (xuly.TimTK(taiKhoan.Taikhoan) == null)
                    {
                        xuly.ThemTaiKoan(taiKhoan);
                        xuly.luuFileTaiKhoan(diachiDSTaiKhoan);
                        MessageBox.Show("Đăng ký thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản bị trùng\nVui lòng đặt tên tài khoản khác!");
                        txtTaiKhoan.Text = "";
                        txtMatKhau.Text = "";
                    }
                   
                }
                else
                {
                    //Đổi Mật Khẩu

                    lblTieuDe.Text = "Đổi Mật Khẩu";

                    CTaiKhoan taiKhoan = new CTaiKhoan();
                    taiKhoan.Taikhoan = txtTaiKhoan.Text;
                    taiKhoan.Matkhau = txtMatKhau.Text;
                    if (rdbNhanVien.Checked)
                    {                      
                        taiKhoan.LoaiTK = false;
                    }
                    else
                    {                 
                        taiKhoan.LoaiTK = true;
                    }
                        

                   
                    if (xuly.TimTK(taiKhoan.Taikhoan) != null)
                    {
                        xuly.SuaTK(taiKhoan);
                        xuly.luuFileTaiKhoan(diachiDSTaiKhoan);
                        MessageBox.Show("Đổi mật khẩu thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không có tài khoản " + taiKhoan.Taikhoan);
                        txtTaiKhoan.Text = "";
                        txtMatKhau.Text = "";
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
            if (CXuLy.GetDangNhap())
            {
                this.Text = "Đăng Ký";
                lblTieuDe.Text = "Đăng Ký";
                btnXacNhan.Text = "Đăng ký";
            }
            else
            {
                this.Text = "Đổi Mật Khẩu";
                lblTieuDe.Text = "Đổi Mật Khẩu";
                btnXacNhan.Text = "Đổi mật khẩu";
               
            }
        }

       

   

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
