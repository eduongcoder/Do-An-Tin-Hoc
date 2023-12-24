using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Do_An_Tin_Hoc
{
    
    public partial class frmDangNhap : Form
    {
        List<CTaiKhoan> danhsachTK = new List<CTaiKhoan>();
        private readonly CXuLy xuLy = new CXuLy();
        private string diachiDSTaiKhoan = "DanhSachTaiKhoan.txt";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // ReadFile("DanhSachTaiKhoan.txt");
            if (xuLy.docFileTaiKhoan(diachiDSTaiKhoan))
            {
                //LoadTKMK();
            }
            else
            {
                MessageBox.Show("File rỗng");
            }
            
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
      
        public bool KTDangNhap(string tk,string mk)
        {
            for(int i = 0; i < xuLy.layDSTaiKhoan().Count; i++)
            {
                if (tk == xuLy.layDSTaiKhoan()[i].Taikhoan && mk == xuLy.layDSTaiKhoan()[i].Matkhau)
                {
                    if (xuLy.layDSTaiKhoan()[i].LoaiTK)
                    {
                        this.Hide();
                        frmTrangChuAdmin admin = new frmTrangChuAdmin();
                        CTaiKhoan.setTK(xuLy.layDSTaiKhoan()[i].LoaiTK);
                        CTaiKhoan.setTenTK(xuLy.layDSTaiKhoan()[i].Taikhoan);
                       
                        admin.ShowDialog();
                        frmDangNhap frmDangNhap = new frmDangNhap();
                        frmDangNhap.ShowDialog();
                        this.Close();
                        
                                               
                        return true;
                    }else
                    {
                        this.Hide();
                        frmTrangChuNhanVien nhanvien = new frmTrangChuNhanVien();
                        CTaiKhoan.setTK(xuLy.layDSTaiKhoan()[i].LoaiTK);
                        CTaiKhoan.setTenTK(xuLy.layDSTaiKhoan()[i].Taikhoan);
                       
                        nhanvien.ShowDialog();
                        frmDangNhap frmDangNhap = new frmDangNhap();                        
                        frmDangNhap.ShowDialog();
                        this.Close();
                        return true;
                    }                   
                }
            }
            return false;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(KTDangNhap(txtTaiKhoan.Text, txtMatKhau.Text))
            {
                
            }
            else
            {
                MessageBox.Show("Bạn đã đăng nhập sai\nVui lòng đăng nhập lại", "Thông Báo",MessageBoxButtons.OK);
            }
                         
        }
      
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có đồng ý thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            CXuLy.LoadFormDangKy(true);
            this.Hide();
            frmDKvaDoiMK frmDangKy = new frmDKvaDoiMK();
            frmDangKy.ShowDialog();
            
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.ShowDialog();
            this.Close();
            

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            CXuLy.LoadFormDangKy(false);
            this.Hide();
            frmDKvaDoiMK frmDangKy = new frmDKvaDoiMK();
            frmDangKy.ShowDialog();

            frmDangNhap frmDangNhap = new frmDangNhap();           
            frmDangNhap.ShowDialog();
            this.Close();

        }
    }
}
