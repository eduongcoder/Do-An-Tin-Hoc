using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Do_An_Tin_Hoc
{
    public partial class frmCaLamAdmin : Form
    {
        private readonly CXuLy xuly = new CXuLy();
        private string diaChiCaLam = "CaLam.txt";
        string diachi = "DanhSachNV.txt";
        public frmCaLamAdmin()
        {
            InitializeComponent();
        }

        private void frmCaLamAdmin_Load(object sender, EventArgs e)
        {
            if (xuly.docFileCaLam(diaChiCaLam))
            {
                
                HienThi(xuly.layDsCaLam());
            }
            else
            {
                MessageBox.Show("Lỗi đọc file");
            }
            xuly.docFileNS(diachi);
            LoadComBoBox();
        }
        private void HienThi(List<CCaLam> dsCaLam)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dsCaLam;
            dgv.DataSource = bs;

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CCaLam caLam = new CCaLam();
            caLam.NgayLam = dtpNgayLam.Value;
            caLam.NhanVien = cboNhanVien.Text;
            if(ConvertToCaLam(cboCaLam.Text)== CaLam.koCa)
            {
                MessageBox.Show("Lỗi Nhập Ca Làm");
            }
            else
            {
                caLam.CaLam = ConvertToCaLam(cboCaLam.Text);
                if (xuly.TimTrung(caLam)==null)
                {
                    xuly.ThemCaLam(caLam);
                    HienThi(xuly.layDsCaLam());
                }
                else { MessageBox.Show("Đã có nhân viên của ca này rồi"); }
                
            }
           
            xuly.luuFileCaLam(diaChiCaLam);
        }
        private void LoadComBoBox()
        {
            foreach (CNhanSu nhanSu in xuly.layDSNhanSu())
            {
                cboNhanVien.Items.Add(nhanSu.TenNhanVien);
            }
            cboCaLam.Items.Add(CaLam.Ca1);
            cboCaLam.Items.Add(CaLam.Ca2);
            cboCaLam.Items.Add(CaLam.Ca3);
            cboCaLam.Items.Add(CaLam.Ca4);
        }

        private CaLam ConvertToCaLam(string ca)
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

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0 && dgv.Rows[e.RowIndex].Cells[0].Value != null)
            {
                dtpNgayLam.Value = (DateTime)dgv.Rows[e.RowIndex].Cells[0].Value;
                cboNhanVien.Text= dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboCaLam.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            xuly.luuFileCaLam(diaChiCaLam);
            Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CCaLam caLam = new CCaLam();
            caLam.NgayLam = dtpNgayLam.Value;
            caLam.NhanVien = cboNhanVien.Text;
            caLam.CaLam = ConvertToCaLam(cboCaLam.Text);

            if (xuly.TimTrung(caLam) != null)
            {
                xuly.XoaCaLam(xuly.TimTrung(caLam));
                HienThi(xuly.layDsCaLam());
                xuly.luuFileCaLam(diaChiCaLam);
            }
           
        }
    }
}
