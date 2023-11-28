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
    public partial class frmXoaTaiKhoan : Form
    {
        private readonly CXuLy xuly=new CXuLy();
        private string diachiDSTaiKhoan= "DanhSachTaiKhoan.txt";
        public frmXoaTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmXoaTaiKhoan_Load(object sender, EventArgs e)
        {
            xuly.docFileTaiKhoan(diachiDSTaiKhoan);
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            
            for(int i=0;i< xuly.layDSTaiKhoan().Count; i++)
            {
                cboTaiKhoan.Items.Add(xuly.layDSTaiKhoan()[i].Taikhoan);
            }                    
        }

        private void cboTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTaiKhoan.SelectedIndex != -1)
            {
                txtMatKhau.Text = xuly.TimTK(cboTaiKhoan.Text).Matkhau;
                MessageBox.Show(xuly.TimTK(cboTaiKhoan.Text).Matkhau);
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có đồng ý xóa tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (xuly.TimTK(cboTaiKhoan.Text) == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần xóa");
                    cboTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                }
                else
                {
                    xuly.XoaTaiKoan(cboTaiKhoan.Text);
                    xuly.luuFileTaiKhoan(diachiDSTaiKhoan);
                    // MessageBox.Show(CTaiKhoan.getTenTK());
                    if (cboTaiKhoan.Text == CTaiKhoan.getTenTK())
                    {
                        this.Close();
                    }
                    MessageBox.Show("Xóa thành công!");
                }
               
            }
            
        }
    }
}
