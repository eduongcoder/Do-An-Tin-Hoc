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
    public partial class frmDiemDanh : Form
    {
        private readonly CXuLy xuly = new CXuLy();
        private string diaChiCaLam = "CaLam.txt";
        string diachi = "DanhSachNV.txt";
        public frmDiemDanh()
        {
            InitializeComponent();
        }

        private void frmDiemDanh_Load(object sender, EventArgs e)
        {
            if (xuly.docFileNS(diachi)&& xuly.docFileCaLam(diaChiCaLam))
            {
                LoadComBoBox();
                dtp.Value = DateTime.Today;
            }
            else
            {
                MessageBox.Show("Lỗi đọc file Nhân Sự");
            }
           
           
        }
        private void LoadComBoBox()
        {
            foreach (CNhanSu nhanSu in xuly.layDSNhanSu())
            {
                cboTen.Items.Add(nhanSu.TenNhanVien);
            }
            cboCaLam.Items.Add(CaLam.Ca1);
            cboCaLam.Items.Add(CaLam.Ca2);
            cboCaLam.Items.Add(CaLam.Ca3);
            cboCaLam.Items.Add(CaLam.Ca4);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cboTen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            CCaLam caLam = new CCaLam();
            caLam.NgayLam = dtp.Value;
            caLam.NhanVien = cboTen.Text;
            caLam.CaLam = xuly.ConvertToCaLam(cboCaLam.Text);
            caLam.TKDiemDanh = CTaiKhoan.getTenTK();
            MessageBox.Show(caLam.TKDiemDanh);
            if (!xuly.CapNhatDiemDanh(caLam))
            {
                MessageBox.Show("Không có nhân viên " + cboTen.Text + " làm vào " + cboCaLam.Text);
            }
            else
            {
                xuly.luuFileCaLam(diaChiCaLam);
                MessageBox.Show("Điểm danh thành công");
            }
        }
    }
}
