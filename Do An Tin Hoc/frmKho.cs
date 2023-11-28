using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Tin_Hoc
{
    public partial class frmKho : Form
    {
        private readonly CXuLy xuLy = new CXuLy();
        string diachi = "data.txt";
        CTaiKhoan taiKhoan = new CTaiKhoan();
        public frmKho()
        {
            InitializeComponent();
        }
       
        private void KhoVaNhapKho_Load(object sender, EventArgs e)
        {

            ConfigButton(CTaiKhoan.getTK());
            dgv.ReadOnly = true;
            
            if (xuLy.docFile(diachi))
            {
                HienThi(xuLy.layDSMatHang());

            }
            else
            {
                MessageBox.Show("File lỗi!");
            }
            btnSua.Visible = false;
        }
        private void ConfigButton(bool loaitk)
        {
            if (!loaitk)
            {                               
                btnThemHang.Visible = false;
                btnSua.Visible = false;
                btnXoaHang.Visible = false;
                btnNhapKho.Location= btnThemHang.Location;
                btnNhapKho.Location = new Point(btnNhapKho.Location.X+40,btnNhapKho.Location.Y+70);

            }
            else
            {

                btnThemHang.Visible = true;
                btnSua.Visible = true;
                btnXoaHang.Visible = true;
               
            }
        }
        private void LoadForm()
        {
            dgv.ReadOnly = true;

            if (xuLy.docFile(diachi))
            {
                HienThi(xuLy.layDSMatHang());

            }
            else
            {
                MessageBox.Show("File lỗi!");
            }
        }
       
        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (xuLy.TimMatHang(txtMH.Text)==null)
            {
                CMatHang matHang = new CMatHang();
                matHang.m_TenMatHang = txtMH.Text;
                matHang.m_SoLuong = Convert.ToInt32(txtSL.Text);
                matHang.m_GiaTien = Convert.ToInt32(txtGiaTien.Text);
                xuLy.ThemMH(matHang);
              
                HienThi(xuLy.layDSMatHang());
                xuLy.luuFile(diachi);
            }
            else
            {
                MessageBox.Show("Đã có mặt hàng này!");
            }
            
        }
        private void LoadData()
        {
            CMatHang cMatHang = new CMatHang("Áo",100000,12,false);
            xuLy.ThemMH(cMatHang);
            CMatHang cMatHang1 = new CMatHang("Quần", 200000, 12, false);
            xuLy.ThemMH(cMatHang1);
            CMatHang cMatHang2 = new CMatHang("Nón", 50000, 12, false);
            xuLy.ThemMH(cMatHang2);
        }
        Dictionary<string,CMatHang> dsMaHang= new Dictionary<string, CMatHang>();
       


        private void HienThi(List<CMatHang> dsmh)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dsmh;
            dgv.DataSource = bs;
           
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
        }
 

        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            if (xuLy.TimMatHang(txtMH.Text) != null)
            {
                xuLy.Xoa(xuLy.TimMatHang(txtMH.Text));
                HienThi(xuLy.layDSMatHang());
                xuLy.luuFile(diachi);
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNhapKho nhapHang = new FrmNhapKho();
            nhapHang.ShowDialog();
            LoadForm();
            this.Show();
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0 && dgv.Rows[e.RowIndex].Cells[0].Value !=null)
            {
                txtMH.Text= dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtGiaTien.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSL.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();               
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                CMatHang matHang = new CMatHang(txtMH.Text, int.Parse(txtGiaTien.Text), int.Parse(txtSL.Text), false);
                xuLy.Sua(matHang);
                HienThi(xuLy.layDSMatHang());
                xuLy.luuFile(diachi);
            }
            catch { MessageBox.Show("Chưa có mặt hàng này!"); }
           
        }

        private void txtMH_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^\p{L}+(?: \p{L}+)*$";
            if (!Regex.IsMatch(txtMH.Text, pattern))
            {
               
                txtMH.Text = "";
                e.Cancel = true;
            }
        }

        private void txtMH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int temp = int.Parse(txtSL.Text);
                if (temp <=0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn hoặc bằng 0!");
                    txtSL.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn đã nhập sai!");
            }
        }

        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int temp = int.Parse(txtGiaTien.Text);
                if (temp <= 0)
                {
                    MessageBox.Show("Giá tiền phải không được bé hơn 0!");
                    txtSL.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn đã nhập sai!");
            }
        }

        private void txtMH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
