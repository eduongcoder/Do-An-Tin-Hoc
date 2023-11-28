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
            ConfigButton(CTaiKhoan.getTK());

            if (xuly.docFileCaLam(diaChiCaLam) && CTaiKhoan.getTK()==true)
            {   
                dtpNgayLam.Enabled= true;
                cboCaLam.Enabled= true;
                cboNhanVien.Enabled= true;
                HienThi(xuly.layDsCaLam());
            }
            else if(xuly.docFileCaLam(diaChiCaLam) && CTaiKhoan.getTK() == false)
            {
                dtpNgayLam.Enabled = false;
                cboCaLam.Enabled = false;
                cboNhanVien.Enabled = false;
                HienThi(LocNhanVien(CXuLy.GetNgayLam()));
            }
            else
            {
                MessageBox.Show("Lỗi đọc file");
            }
            xuly.docFileNS(diachi);
            LoadComBoBox();
        }

        private List<CCaLam> LocNhanVien(DateTime dateTime) 
        {
            List<CCaLam> temp =new List<CCaLam>();
            
            foreach(CCaLam item in xuly.layDsCaLam())
            {
                if(xuly.CompareDateTime(item.NgayLam, dateTime)) 
                { 
                    temp.Add(item);
                }
            }
            return temp;
        }

        private void HienThi(List<CCaLam> dsCaLam)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dsCaLam;
            dgv.DataSource = bs;
            dgv.Columns[3].ReadOnly = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            CCaLam caLam = new CCaLam();
            caLam.NgayLam = dtpNgayLam.Value;
            caLam.NhanVien = cboNhanVien.Text;
            if(xuly.ConvertToCaLam(cboCaLam.Text)== CaLam.koCa)
            {
                MessageBox.Show("Lỗi Nhập Ca Làm");
            }
            else
            {
                caLam.CaLam = xuly.ConvertToCaLam(cboCaLam.Text);
                if (xuly.TimTrung(caLam)==null)
                {
                    xuly.ThemCaLam(caLam);
                    HienThi(xuly.layDsCaLam());
                }
                else { MessageBox.Show("Đã có nhân viên của ca này rồi"); }
                
            }
           
            xuly.luuFileCaLam(diaChiCaLam);
        }
        private void ConfigButton(bool loaitk)
        {
            if (!loaitk)
            {
              btnThem.Visible = false;
              btnXoa.Visible = false;
            }
            else
            {
                btnThem.Visible = true;
                btnXoa.Visible = true;
            }
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
            caLam.CaLam = xuly.ConvertToCaLam(cboCaLam.Text);

            if (xuly.TimTrung(caLam) != null)
            {
                xuly.XoaCaLam(xuly.TimTrung(caLam));
                HienThi(xuly.layDsCaLam());
                xuly.luuFileCaLam(diaChiCaLam);
            }
           
        }
    }
}
