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
            ckbTTG.Checked = true;
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

  
        private int getTieuChi( DateTime dateTime1, DateTime dateTime2,string kieuTieuChi)
        {
            switch (kieuTieuChi)
            {
                case "Ngay":
                    if (xuLy.CompareDateTime(dateTime1, dateTime2))
                        return dateTime2.Day;
                    else return 0;
                case "Thang":
                  
                    if (dateTime1.Month== dateTime2.Month&& dateTime1.Year == dateTime2.Year)
                    {                      
                        return dateTime2.Month;
                    }                       
                    else return 0;
                case "Nam":
                    if (dateTime1.Year == dateTime2.Year)
                        return dateTime2.Year;
                    else return 0;
                default: 
                    return 0;
            }
        }

        private List<CMatHang> locBanChay(List<CMatHang> dsmh,DateTime thoigian,string kieuTieuChi,object ten,bool trangThai) 
        {
            List<CMatHang> tempList= new List<CMatHang>();
            List<CMatHang> ds = xuLy.layDSMatHang();
            for (int i = 0;i< ds.Count;i++)
            {                
                CMatHang mh = new CMatHang();
                if (kieuTieuChi != "" && ten==null && !trangThai)
                {   //Lọc theo ngày tháng và không có tên món hàng cụ thể
                    //Chi tiết các món hàng
                    for (int j = 0; j < dsmh.Count; j++)
                    {
                        int temp = getTieuChi(thoigian, dsmh[j].m_NgayMuaHang, kieuTieuChi);
                        if (dsmh[j].m_TenMatHang == ds[i].m_TenMatHang &&temp!=0 && getTieuChi(thoigian, dsmh[j].m_NgayMuaHang, kieuTieuChi) != 0)
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
                else if(ten!=null&& kieuTieuChi!="" && !trangThai)
                {   //Lọc theo ngày tháng và có tên món hàng cụ thể
                    //Chi tiết các món hàng
                    if (xuLy.TimMatHang(ten.ToString()) != null)
                    {                   
                        for (int j = 0; j < dsmh.Count; j++)
                        {   
                            if (dsmh[j].m_TenMatHang == ten.ToString()&& getTieuChi(thoigian, dsmh[j].m_NgayMuaHang, kieuTieuChi) != 0)
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
                else if(kieuTieuChi!="" && trangThai)
                {   //Có ngày tháng và ko có tên món hàng cụ thể
                    //Tổng các hàng
                 
                    cboMatHang.SelectedIndex = -1;
                    mh = new CMatHang();                   
                    for (int j = 0; j < dsmh.Count; j++)
                    {
                        if (dsmh[j].m_TenMatHang == ds[i].m_TenMatHang&&getTieuChi(thoigian, dsmh[j].m_NgayMuaHang, kieuTieuChi) != 0)
                        {
                            mh.m_TenMatHang = ds[i].m_TenMatHang;                          
                            mh.m_SoLuong += dsmh[j].m_SoLuong;
                            mh.m_GiaTien += dsmh[j].m_GiaTien;
                            mh.m_NgayMuaHang = dsmh[j].m_NgayMuaHang.Date;
                        }
                    }
                    if (mh.m_TenMatHang != "")
                        tempList.Add(mh);
                    else
                    {

                    }
                }
                else if (kieuTieuChi== "" && trangThai)
                {   //Lọc bất kể hàng hóa hay ngày tháng 
                    //Tổng các hàng               
                    cboMatHang.SelectedIndex = -1;
                    mh = new CMatHang();
                    for (int j = 0; j < dsmh.Count; j++)
                     {
                        if (dsmh[j].m_TenMatHang == ds[i].m_TenMatHang )
                        {
                            mh.m_TenMatHang = ds[i].m_TenMatHang;
                            mh.m_SoLuong += dsmh[j].m_SoLuong;
                            mh.m_GiaTien += dsmh[j].m_GiaTien;                     
                            mh.m_NgayMuaHang = dsmh[j].m_NgayMuaHang.Date;
                        }
                    } 
                    tempList.Add(mh);
                }else if (kieuTieuChi == ""  && !trangThai)
                {
                    //Lọc cụ thể hàng hóa hay ngày tháng
                    //Chi tiết các hàng hóa                                
                    for (int j = 0; j < dsmh.Count; j++)
                    {
                        if ( dsmh[j].m_TenMatHang== ten.ToString())
                        {
                            mh = new CMatHang();
                            mh.m_TenMatHang = ds[i].m_TenMatHang;
                            mh.m_SoLuong = dsmh[j].m_SoLuong;
                            mh.m_GiaTien = dsmh[j].m_GiaTien;
                            mh.m_NgayMuaHang = dsmh[j].m_NgayMuaHang.Date;
                            tempList.Add(mh);
                        }
                    }
                    return tempList;
                }
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
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Ngay", cboMatHang.SelectedItem, ckbBC.Checked) != null)
                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Ngay", cboMatHang.SelectedItem,ckbBC.Checked)));
            }
            catch (Exception) { }
             
        }
    

        private void btnNam_Click(object sender, EventArgs e)
        {
            try
            {
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Nam", cboMatHang.SelectedItem, ckbBC.Checked) != null)

                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Nam", cboMatHang.SelectedItem, ckbBC.Checked)));

            }
            catch (Exception) { }


        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            try
            {
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Thang", cboMatHang.SelectedItem, ckbBC.Checked) != null)

                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Thang", cboMatHang.SelectedItem, ckbBC.Checked)));

            }
            catch (Exception) { }

        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Ngay", cboMatHang.SelectedItem, ckbBC.Checked) != null)
                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "Ngay", cboMatHang.SelectedItem, ckbBC.Checked)));

            }
            catch (Exception) { }

        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckbBC.Checked)
                {
                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "", cboMatHang.SelectedItem, ckbBC.Checked)));
                }                   
                else if(cboMatHang.SelectedItem!=null){
                    HienThi(BubbleSortSoLuong(locBanChay(xuLy.layDSDoanhThu(), dtp.Value, "", cboMatHang.SelectedItem, ckbBC.Checked)));
                }
                else
                {
                    HienThi(BubbleSortSoLuong(xuLy.layDSDoanhThu()));
                }
                   

            }
            catch (Exception) { }

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            cboMatHang.Text = null;
        }

        private void ckbTTG_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTTG.Checked)
            {
                dtp.Enabled = true;
            }else 
            {
                dtp.Value = DateTime.Today;
                dtp.Enabled = false;
            }
        }

        private void cboMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
