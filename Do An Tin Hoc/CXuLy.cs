using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Tin_Hoc
{
    internal class CXuLy
    {
        private static readonly BinaryFormatter bf = new BinaryFormatter();
        private Dictionary<string,CMatHang> dsMatHang = new Dictionary<string,CMatHang>();
        private Dictionary<string,CNhanSu> dsNhanSu = new Dictionary<string,CNhanSu>();
        private Dictionary<string,CTaiKhoan> dsTaiKhoan = new Dictionary<string, CTaiKhoan>();
        private static List<CMatHang> dsDoanhThu = new List<CMatHang>();
        private List<CCaLam> dsCaLam = new List<CCaLam>();

        private static DateTime ngayLam;

        private static bool dangNhap;
        //Xử Lý Tài Khoản;

        public static void LoadFormDangKy(bool dauvao)
        {
            if (dauvao)
            {
                dangNhap= true;
            }
            else
            {
                dangNhap = false;
            }
        }
        public static bool GetDangNhap()
        {
            return dangNhap;
        }
        public CTaiKhoan TimTK(string tenTK)
        {
            if (dsTaiKhoan.ContainsKey(tenTK))
            {
                return dsTaiKhoan[tenTK];
            }
            else
            { return null; }
        }
        public void SuaTK(CTaiKhoan taiKhoan)
        {
            CTaiKhoan temp = TimTK(taiKhoan.Taikhoan);
           temp.Matkhau = taiKhoan.Matkhau;
            temp.LoaiTK= taiKhoan.LoaiTK;
        }
        public List<CTaiKhoan> layDSTaiKhoan()
        {
            return dsTaiKhoan.Values.ToList();
        }
        public void ThemTaiKoan(CTaiKhoan taiKhoan)
        {
            dsTaiKhoan.Add(taiKhoan.Taikhoan,taiKhoan);
        }
        public void XoaTaiKoan(string tenTK)
        {
            dsTaiKhoan.Remove(tenTK);
        }
        public bool docFileTaiKhoan(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Open);
                dsTaiKhoan = (Dictionary<string, CTaiKhoan>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool luuFileTaiKhoan(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Create);
                bf.Serialize(fs, dsTaiKhoan);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Xử Lý Ca làm

        public static void SetNgayLam(DateTime dateTime)
        {
            ngayLam=dateTime;
        }
        public static DateTime GetNgayLam()
        {
           return ngayLam;
        }
        public List<CCaLam> layDsCaLam()
        {
            return dsCaLam.ToList();
        }

        public void ThemCaLam(CCaLam caLam)
        {
            dsCaLam.Add(caLam);
        }
        public void XoaCaLam(CCaLam caLam)
        {
           dsCaLam.Remove(caLam);
            
        }
        public bool CapNhatDiemDanh(CCaLam caLam)
        {
            if (TimTrung(caLam) != null)
            {
                TimTrung(caLam).DiemDanh = true;
                TimTrung(caLam).TKDiemDanh = caLam.TKDiemDanh;
                return true;
            }else 
            { return false; }
           
        }
        public CCaLam TimTrung(CCaLam caLam)
        {
           for(int i=0;i<dsCaLam.Count;i++)
           {
                if (dsCaLam[i].NhanVien==caLam.NhanVien && dsCaLam[i].CaLam == caLam.CaLam && CompareDateTime(dsCaLam[i].NgayLam,caLam.NgayLam))
                {
                    return dsCaLam[i];
                }
           }
           return null;
        }
        public bool CompareDateTime(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Year == dateTime2.Year && dateTime1.Month == dateTime2.Month && dateTime1.Day == dateTime2.Day;
        }
        public CaLam ConvertToCaLam(string ca)
        {
            switch (ca)
            {
                case "Ca1":
                    return CaLam.Ca1;
                case "Ca2":
                    return CaLam.Ca2;
                case "Ca3":
                    return CaLam.Ca3;
                case "Ca4":
                    return CaLam.Ca4;
                default:
                    return CaLam.koCa;
            }
        }

        public bool docFileCaLam(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Open);
                dsCaLam = (List<CCaLam>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool luuFileCaLam(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Create);
                bf.Serialize(fs, dsCaLam);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Xử Lý Doanh Thu 
        public List<CMatHang> layDSDoanhThu()
        {
            return CXuLy.dsDoanhThu.ToList();
        }
        public void XoaDoanhThu()
        {
            dsDoanhThu.Clear();
        }
        public bool docFileDoanhThu(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Open);
                CXuLy.dsDoanhThu = (List<CMatHang>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ThemMHDT(CMatHang mH)
        {         
          dsDoanhThu.Add( mH);
        }
       public bool TimMHDT(string tenMH)
        {
            foreach (CMatHang item in dsDoanhThu)
            {
                if (item.m_TenMatHang == tenMH)
                {
                    return true;
                }
            }
            return false;
        }
        public bool luuFileDoanhThu(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Create);
                bf.Serialize(fs, CXuLy.dsDoanhThu);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Xử Lý Mặt Hàng
        public List<CMatHang> layDSMatHang()
        {
            return dsMatHang.Values.ToList();
        }
        public Dictionary<string,CMatHang> GetDSMH()
        {
            return dsMatHang;
        }
        public CMatHang TimMatHang(string ma)
        {
            if (dsMatHang.ContainsKey(ma))
            {
                return dsMatHang[ma];
            }else { return null; }
        }
        public void ThemMH(CMatHang mH)
        {
            if(!dsMatHang.ContainsKey(mH.m_TenMatHang))
            {
                dsMatHang.Add(mH.m_TenMatHang, mH);
            }            
        }
        public void Xoa(CMatHang mH)
        {
            if (dsMatHang.ContainsKey(mH.m_TenMatHang.ToString()))
            {
                dsMatHang.Remove(mH.m_TenMatHang);
            }
        }
        public void Sua(CMatHang mH)
        {
            if (dsMatHang.ContainsKey(mH.m_TenMatHang.ToString()))
            {
                dsMatHang[mH.m_TenMatHang] = mH;
            }
        }
        public bool docFile(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Open);
                dsMatHang = (Dictionary<string, CMatHang>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool luuFile(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Create);
                bf.Serialize(fs, dsMatHang);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ////Xử Lý Nhân Sự
        public List<CNhanSu> layDSNhanSu()
        {
            return dsNhanSu.Values.ToList();
        }
        public CNhanSu TimNS(string ma)
        {
            if (dsNhanSu.ContainsKey(ma))
            {
                return dsNhanSu[ma];
            }
            else 
            { return null; }
        }
        public void ThemNS(CNhanSu mH)
        {
            if (!dsNhanSu.ContainsKey(mH.MaNhanVien))
            {
                dsNhanSu.Add(mH.MaNhanVien, mH);
            }
        }
        public void XoaNS(CNhanSu mH)
        {
            if (dsNhanSu.ContainsKey(mH.MaNhanVien))
            {
                dsNhanSu.Remove(mH.MaNhanVien);
            }
        }
        public void SuaNS(CNhanSu mH)
        {
            if (dsNhanSu.ContainsKey(mH.MaNhanVien))
            {
                dsNhanSu[mH.MaNhanVien] = mH;
            }
        }
        
        public bool docFileNS(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Open);
                dsNhanSu = (Dictionary<string,CNhanSu>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool luuFileNS(string tenfile)
        {
            try
            {
                FileStream fs = new FileStream(tenfile, FileMode.Create);
                bf.Serialize(fs, dsNhanSu);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
