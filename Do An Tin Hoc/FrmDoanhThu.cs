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
            cboSapXep.Items.Add("Số Lượng");
            cboSapXep.Items.Add("Ngày tháng");

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
            //xuLy.XoaDoanhThu();
            //xuLy.luuFileDoanhThu(diachi2);
            //HienThi(xuLy.layDSDoanhThu());
        }
        private List<CMatHang> BubbleSortSoLuong( List<CMatHang>  listSoLuong)
        {
           for(int i=0;i< listSoLuong.Count;i++)
            {
                for (int j=0;j< listSoLuong.Count - i-1;j++)
                {
                    if (listSoLuong[j].m_SoLuong > listSoLuong[j + 1].m_SoLuong)
                    {
                        CMatHang temp = listSoLuong[j];
                        listSoLuong[j] = listSoLuong[j+1];
                        listSoLuong[j+1] = temp;
                    }
                }
            }
            List<CMatHang> temp1 = listSoLuong;
            return temp1;
        }
        private List<CMatHang> BubbleSortNgay(List<CMatHang> listSoLuong)
        {
            for (int i = 0; i < listSoLuong.Count; i++)
            {
                for (int j = 0; j < listSoLuong.Count - i - 1; j++)
                {
                    if (listSoLuong[j].m_NgayMuaHang > listSoLuong[j + 1].m_NgayMuaHang)
                    {
                        CMatHang temp = listSoLuong[j];
                        listSoLuong[j] = listSoLuong[j + 1];
                        listSoLuong[j + 1] = temp;
                    }
                }
            }
            List<CMatHang> temp1 = listSoLuong;
            return temp1;
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {

            xuLy.datDSDoanhThu(BubbleSortSoLuong(xuLy.layDSDoanhThu()));
            HienThi(xuLy.layDSDoanhThu());
            xuLy.luuFileDoanhThu(diachi2);
          
        }

        private void btnSapXepTheoNgay_Click(object sender, EventArgs e)
        {
            xuLy.datDSDoanhThu(BubbleSortNgay(xuLy.layDSDoanhThu()));
            HienThi(xuLy.layDSDoanhThu());
            xuLy.luuFileDoanhThu(diachi2);
        }

        private void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSapXep.SelectedIndex != -1)
            {
                if(cboSapXep.Text== "Số Lượng")
                {
                    xuLy.datDSDoanhThu(BubbleSortSoLuong(xuLy.layDSDoanhThu()));
                    HienThi(xuLy.layDSDoanhThu());
                    xuLy.luuFileDoanhThu(diachi2);
                }else if(cboSapXep.Text== "Ngày tháng")
                {
                    xuLy.datDSDoanhThu(BubbleSortNgay(xuLy.layDSDoanhThu()));
                    HienThi(xuLy.layDSDoanhThu());
                    xuLy.luuFileDoanhThu(diachi2);
                }
            }
        }
    }
}
