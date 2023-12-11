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
            HienThi(xuly.layDSTaiKhoan());
        }
        private void HienThi(List<CTaiKhoan> dsTaiKhoan)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dsTaiKhoan;
            dgv.DataSource = bs;
         
        }
        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có đồng ý xóa tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (xuly.TimTK(txtTaiKhoan.Text) == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần xóa");
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                }
                else
                {
                    
                    // MessageBox.Show(CTaiKhoan.getTenTK());
                    if (txtTaiKhoan.Text == CTaiKhoan.getTenTK())
                    {
                        MessageBox.Show("Bạn không thể xóa tài khoản đang được sử dụng!");
                    }
                    else
                    {
                        xuly.XoaTaiKoan(txtTaiKhoan.Text);
                        xuly.luuFileTaiKhoan(diachiDSTaiKhoan);
                        HienThi(xuly.layDSTaiKhoan());
                        MessageBox.Show("Xóa thành công!");
                    }                   
                }               
            }            
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.RowCount > 0 && dgv.Rows[e.RowIndex].Cells[0].Value != null)
            {

                txtTaiKhoan.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMatKhau.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();          
            }
        }
    }
}
