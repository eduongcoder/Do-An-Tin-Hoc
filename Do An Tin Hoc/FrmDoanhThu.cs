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
    public partial class FrmDoanhThu : Form
    {
        private readonly CXuLy xuLy = new CXuLy();
        //string diachi = "data.txt";
        string diachi2 = "DoanhThu.txt";
        public FrmDoanhThu()
        {
            InitializeComponent();
        }

        private void FrmDoanhThu_Load(object sender, EventArgs e)
        {
            xuLy.docFileDoanhThu(diachi2);
            HienThi(xuLy.layDSDoanhThu());
        }
        private void HienThi(List<CMatHang> maHang)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = maHang;
            dgv.DataSource = bs;
            dgv.Columns[3].Visible = false;
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            xuLy.luuFileDoanhThu(diachi2);
            Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuLy.XoaDoanhThu();
            xuLy.luuFileDoanhThu(diachi2);
            HienThi(xuLy.layDSDoanhThu());
        }
    }
}
