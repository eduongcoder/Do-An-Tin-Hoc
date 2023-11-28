using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Do_An_Tin_Hoc
{
    public partial class frmNhanSuAdmin : Form
    {
        private readonly CXuLy xuLy = new CXuLy();

        string diachi = "DanhSachNV.txt";
        public frmNhanSuAdmin()
        {
            InitializeComponent();
        }

        private void NhanSu_Load(object sender, EventArgs e)
        {
            xuLy.docFileNS(diachi);

            HienNhanSu(xuLy.layDSNhanSu());

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag=true;
                string temp;
                do
                {
                    temp= GenerateCode(8);
                    if (!xuLy.TimMaTrung(temp)){
                        flag = false;
                    }
                }while(flag);
                

                CNhanSu nhansu = new CNhanSu(temp, txtHoTen.Text, dtp.Value.Date);
                xuLy.ThemNS(nhansu);
               
                HienNhanSu(xuLy.layDSNhanSu());
                xuLy.luuFileNS(diachi);
            }
            catch {
                MessageBox.Show("Lỗi nhập thông tin");
            }

        }

        private string GenerateCode(int length)
        {
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Use StringBuilder for efficient string concatenation
            StringBuilder codeBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                // Append a random character from the 'characters' string
                codeBuilder.Append(characters[random.Next(characters.Length)]);
            }

            return codeBuilder.ToString();
        }



        private void HienNhanSu(List<CNhanSu> ns)
        {
            BindingSource sd=new BindingSource();
            sd.DataSource = ns;
            dgv.DataSource = sd;
        }
    

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
               
                xuLy.XoaNS(xuLy.TimNS(txtMNV.Text));
                HienNhanSu(xuLy.layDSNhanSu());
                xuLy.luuFileNS(diachi);
            }
            catch 
            { MessageBox.Show("Không có nhân viên này!");

            }
        }


        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0&& dgv.Rows[e.RowIndex].Cells[0].Value != null)
            {
                txtMNV.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtHoTen.Text= dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtp.Value = (DateTime) dgv.Rows[e.RowIndex].Cells[2].Value;
                
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {

            
            CNhanSu nhansu = new CNhanSu(txtMNV.Text, txtHoTen.Text, dtp.Value);
            xuLy.SuaNS(nhansu);
            HienNhanSu(xuLy.layDSNhanSu());
            xuLy.luuFileNS(diachi);

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^\p{L}+(?: \p{L}+)*$";
            if (!Regex.IsMatch(txtHoTen.Text, pattern))
            {
                MessageBox.Show("Họ tên nhập lỗi", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Text = "";
                e.Cancel = true;
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, backspace, and space
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
