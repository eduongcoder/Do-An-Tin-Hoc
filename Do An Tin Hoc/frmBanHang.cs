using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Tin_Hoc
{
    public partial class frmBanHang : Form
    {
        private readonly CXuLy xuLy = new CXuLy();
        string diachi = "data.txt";
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            if (xuLy.docFile(diachi))
                AddItems();

        }

        private void AddItems()
        {
            foreach(KeyValuePair<string,CMatHang> key in xuLy.GetDSMH())
            {
                cboTenMatHang.Items.Add(key.Key);
            }
        }
      
       
        private void cboTenMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTenMatHang.SelectedIndex != -1)
            { 
                txtGiaTien.Text = xuLy.GetDSMH()[cboTenMatHang.SelectedItem.ToString()].m_GiaTien.ToString();
            }
        }
      
   
     
        private void HienThi(Dictionary<string,CMatHang> danhSach)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = danhSach.Values;
            dgv.DataSource = bs;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
        }
        private bool Tim(string tenMH,Dictionary<string,CMatHang> danhSach)
        {
            if (danhSach.ContainsKey(tenMH))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private Dictionary<string, CMatHang> dsChonMua = new Dictionary<string, CMatHang>();
        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (!Tim(cboTenMatHang.SelectedItem.ToString(), xuLy.GetDSMH()) && Tim(cboTenMatHang.SelectedItem.ToString(), dsChonMua))
            {
               
                try
                {
                    int tongtien = 0;
                    tongtien = Convert.ToInt32(txtGiaTien.Text) * Convert.ToInt32(txtSoLuong.Text);
                    CMatHang matHang = new CMatHang(cboTenMatHang.SelectedItem.ToString(), tongtien, Convert.ToInt32(txtSoLuong.Text), false);
                    dsChonMua.Add(matHang.m_TenMatHang, matHang);

                    CGioHang giohang = new CGioHang(cboTenMatHang.Text, tongtien, int.Parse(txtSoLuong.Text));
                    CGioHang.themHang(giohang); //cập nhật dữ liệu cho form Thanh Toán

                    CapNhatKho();

                    HienThi(dsChonMua);
                }
                catch(Exception)
                {
                    MessageBox.Show("Bạn chưa nhập số lượng");
                }            
            }
            else
            {
                MessageBox.Show("Đã có mặt hàng này!");
            }
        }
        private void CapNhatKho()
        {
            foreach(KeyValuePair<string,CMatHang> item in dsChonMua)
            {
                xuLy.GetDSMH()[item.Key].m_SoLuong -=item.Value.m_SoLuong;
            }
        }
      
        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            if (xuLy.TimMatHang(cboTenMatHang.Text) != null&& dgv.RowCount>1)
            {
                dsChonMua.Remove(cboTenMatHang.Text);
                
                CGioHang.XoaHang(CGioHang.dsGioHang[cboTenMatHang.Text]);
                HienThi(dsChonMua);
            }
            else if(dgv.RowCount ==1)
            {
                dsChonMua.Remove(cboTenMatHang.Text);

                CGioHang.XoaHang(CGioHang.dsGioHang[cboTenMatHang.Text]);
               // dgv.Rows[0].SetValues(null, null,null );
                dgv.Rows.Clear();

            }          
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          
            if (dgv.RowCount > 0 && dgv.Rows[e.RowIndex].Cells[0].Value != null)
            {       
           
                cboTenMatHang.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtGiaTien.Text = xuLy.TimMatHang(cboTenMatHang.Text).m_GiaTien.ToString();
                txtSoLuong.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            else
            {
                dgv.Rows.Clear();
            }
        }

        private void btnLenDon_Click(object sender, EventArgs e)
        {
            frmThanhToan thanhToan = new frmThanhToan();
            thanhToan.Show(); 
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((xuLy.GetDSMH()[cboTenMatHang.Text].m_SoLuong - int.Parse(txtSoLuong.Text)) < 0 && (int.Parse(txtSoLuong.Text)) > 0)
                {
                    MessageBox.Show("Không đủ số lượng\n Chỉ còn" + xuLy.GetDSMH()[cboTenMatHang.Text].m_SoLuong);
                    txtSoLuong.Text =string.Empty;
                }
            }catch { }
            
        }
    }
}
