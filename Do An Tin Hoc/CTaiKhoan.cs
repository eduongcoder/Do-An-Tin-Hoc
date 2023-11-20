using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Tin_Hoc
{
    [Serializable]
    internal class CTaiKhoan
    {
        private string taiKhoan;
        private string matKhau;
        private bool loaiTK;

        private static bool tk;
        private static string tenTK;

        public static string getTenTK()
        {
            return tenTK;
        }
        public static void setTenTK(string tentk)
        {
            tenTK = tentk;
        }
        public static bool getTK()
        {
            return tk;
        }
        public static void setTK(bool loaitk)
        {
            tk = loaitk;
        }

        public string Taikhoan{
            get => taiKhoan;
            set => taiKhoan=value;
        }
        public string Matkhau
        {
            get => matKhau;
            set => matKhau=value;
        }
        public bool LoaiTK
        {
            get => loaiTK;
            set => loaiTK=value;
        }
        public CTaiKhoan(string taikhoan,string matkhau,bool loaitk)
        {
            this.taiKhoan=taikhoan;
            this.matKhau=matkhau;
            this.loaiTK=loaitk;
        }
        public CTaiKhoan()
        {
            this.taiKhoan = "";
            this.matKhau = "";
            this.loaiTK = tk; 
        }

        public string ShowTK()
        {
            return this.taiKhoan;
        }
    }
}
