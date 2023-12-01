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
        string diachi = "data.txt";
        string diachi2 = "DoanhThu.txt";
        public FrmDoanhThu()
        {
            InitializeComponent();
        }

        private void FrmDoanhThu_Load(object sender, EventArgs e)
        {
            xuLy.docFile(diachi);
            xuLy.docFileDoanhThu(diachi2);
            HienThi(BubbleSortSoLuong(xuLy.layDSDoanhThu()));
            loadComboBox(xuLy.layDSMatHang());

        }
        private void loadComboBox(List<CMatHang> ds)
        {
            for (int i = 0;i<ds.Count;i++)
                cboMatHang.Items.Add(ds[i].m_TenMatHang);
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

  
        private int getTieuChi( DateTime tieuChi,string kieuTieuChi)
        {
            switch (kieuTieuChi)
            {
                case "Ngay":
                    return tieuChi.Day;
                case "Thang":
                    return tieuChi.Month;
                case "Nam":
                    return tieuChi.Year;
                default: 
                    return 0;
            }
        }

        private List<CMatHang> locBanChay(List<CMatHang> dsmh,DateTime thoigian,string kieuTieuChi,object ten) 
        {
            List<CMatHang> tempList= new List<CMatHang>();
            List<CMatHang> ds = xuLy.layDSMatHang();
            for (int i = 0;i< ds.Count;i++)
            {                
                CMatHang mh = new CMatHang();
                if (kieuTieuChi != "" && ten==null)
                {//Lọc theo ngày tháng 
                    for (int j = 0; j < dsmh.Count; j++)
                    {
                        if (dsmh[j].m_TenMatHang == ds[i].m_TenMatHang && getTieuChi(thoigian, kieuTieuChi) == getTieuChi(dsmh[j].m_NgayMuaHang, kieuTieuChi))
                        {
                            mh = new CMatHang();
                            mh.m_TenMatHang = dsmh[j].m_TenMatHang;                           
                            mh.m_GiaTien = dsmh[j].m_GiaTien;
                            mh.m_SoLuong = dsmh[j].m_SoLuong;
                            mh.m_NgayMuaHang = dsmh[j].m_NgayMuaHang.Date;
                            tempList.Add(mh);
                        }
                    }
                    continue;

                }
                else if(ten!=null&& kieuTieuChi!=null)
                {
                    if (xuLy.TimMatHang(ten.ToString()) != null)
                    {                   
                        for (int j = 0; j < dsmh.Count; j++)
                        {                          
                            if (dsmh[j].m_TenMatHang == ten.ToString()&& getTieuChi(thoigian,kieuTieuChi)== getTieuChi(dsmh[j].m_NgayMuaHang, kieuTieuChi))
                            {
                               
                                mh = new CMatHang();
                                mh.m_TenMatHang = ten.ToString();
                                mh.m_SoLuong = dsmh[j].m_SoLuong;
                                mh.m_GiaTien = dsmh[j].m_GiaTien;
                                mh.m_NgayMuaHang = dsmh[j].m_NgayMuaHang.Date;
                                tempList.Add(mh);
                            }
                        }
                        return tempList;
                    }
                    else
                    {
                        break;
                    }
                }
                else if(kieuTieuChi!=null)
                {
                    for (int j = 0; j < dsmh.Count; j++)
                    {
                        if (dsmh[j].m_TenMatHang == ds[i].m_TenMatHang && getTieuChi(thoigian, kieuTieuChi) == getTieuChi(dsmh[j].m_NgayMuaHang, kieuTieuChi))
                        {

                            mh.m_TenMatHang = dsmh[j].m_TenMatHang;                          
                            mh.m_SoLuong += dsmh[j].m_SoLuong;
                            mh.m_GiaTien += dsmh[j].m_GiaTien;
                            mh.m_NgayMuaHang = dsmh[j].m_NgayMuaHang.Date;
                        }
                    }
                }              
              if(mh.m_TenMatHang!="")
                tempList.Add(mh);
            }
            return tempList;
        }

        private List<CMatHang> BubbleSortSoLuong( List<CMatHang>  listSoLuong)
        {
           for(int i=0;i< listSoLuong.Count;i++)
            {
                for (int j=0;j< listSoLuong.Count - i-1;j++)
                {
                    if (listSoLuong[j].m_SoLuong < listSoLuong[j + 1].m_SoLuong)
                    {
                        CMatHang temp = listSoLuong[j];
                        listSoLuong[j] = listSoLuong[j+1];
                        listSoLuong[j+1] = temp;
                    }
                }
            }
         
            return listSoLuong;
        }
      
        private void btnNgay_Click(object sender, EventArgs e)
        {
            try
            {
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Ngay", cboMatHang.SelectedItem)!= null)
                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Ngay", cboMatHang.SelectedItem)));
            }
            catch (Exception) { }
             
        }
        private void btnBanChay_Click(object sender, EventArgs e)
        {
            try
            {             
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "", cboMatHang.SelectedItem) != null )
                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "", cboMatHang.SelectedItem)));
            }
            catch (Exception) { }
        }

        private void btnNam_Click(object sender, EventArgs e)
        {
            try
            {
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Nam", cboMatHang.SelectedItem) != null)

                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Nam", cboMatHang.SelectedItem)));

            }
            catch (Exception) { }


        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            try
            {
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Thang", cboMatHang.SelectedItem) != null)

                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Thang", cboMatHang.SelectedItem)));

            }
            catch (Exception) { }

        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Ngay", cboMatHang.SelectedItem) != null)
                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Ngay", cboMatHang.SelectedItem)));

            }
            catch (Exception) { }

        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                HienThi(BubbleSortSoLuong(xuLy.layDSDoanhThu()));

            }
            catch (Exception) { }

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            cboMatHang.Text = null;
        }
    }
}
