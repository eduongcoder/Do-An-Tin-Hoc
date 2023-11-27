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
    public partial class frmThanhToan : Form
    {
        private readonly CXuLy xuLy = new CXuLy();
        string diachi = "data.txt";
        string diachi2 = "DoanhThu.txt";
        
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            xuLy.docFileDoanhThu(diachi2);

           foreach (KeyValuePair<string,CGioHang> mh in CGioHang.dsGioHang)
            {
                ListViewItem item = new ListViewItem(CGioHang.dsGioHang[mh.Key].ten.ToString());
                item.SubItems.Add(CGioHang.dsGioHang[mh.Key].soLuong.ToString());
                item.SubItems.Add(CGioHang.dsGioHang[mh.Key].gia.ToString());
               
                lst.Items.Add(item);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            xuLy.docFile(diachi);
            foreach (ListViewItem item in lst.Items)
            {
                string ten = item.SubItems[0].Text;
                int soLuong = int.Parse(item.SubItems[1].Text);
                int giaTien = int.Parse(item.SubItems[2].Text);
                CMatHang matHang = xuLy.TimMatHang(item.Text);
                matHang.m_SoLuong -= int.Parse(item.SubItems[1].Text);

                CMatHang temp =new CMatHang(ten, giaTien, soLuong, false);
                temp.m_NgayMuaHang = DateTime.Now;

                xuLy.ThemMHDT(temp);
                
                xuLy.Sua(matHang);               
            }
            
            xuLy.luuFileDoanhThu(diachi2);
            xuLy.luuFile(diachi);
            lst.Clear();
            CGioHang.dsGioHang.Clear();
            
            MessageBox.Show("Cảm ơn Quý Khách!");
            this.Close();
        }

        private void lst_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
