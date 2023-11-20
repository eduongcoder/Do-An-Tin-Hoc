using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Tin_Hoc
{
    public enum CaLam {Ca1,Ca2,Ca3,Ca4,koCa}
    [Serializable]
    internal class CCaLam
    {
        private DateTime m_NgayLam;
        private string m_NhanVien;
        private CaLam m_CaLam;
        private bool m_DiemDanh;
        private string m_TkDiemDanh;
        public DateTime NgayLam { get => m_NgayLam; set => m_NgayLam = value; }
        public string NhanVien { get => m_NhanVien; set => m_NhanVien = value; }
        public CaLam CaLam { get => m_CaLam; set => m_CaLam = value; }
        public bool DiemDanh { get => m_DiemDanh; set=> m_DiemDanh = value; }
        public string TKDiemDanh { get => m_TkDiemDanh; set => m_TkDiemDanh = value; }

        public CCaLam()
        {
            NgayLam= DateTime.Now;
            NhanVien = "";
            CaLam = CaLam.Ca1;
            DiemDanh = false;
            TKDiemDanh = "";
        }
        public CCaLam(DateTime date,string nhanVien,CaLam caLam,bool diemDanh,string tkDiemDanh)
        {
            NgayLam = date;
            NhanVien = nhanVien;
            CaLam = caLam;
            DiemDanh= diemDanh;
            TKDiemDanh= tkDiemDanh;
        }
    }
}
