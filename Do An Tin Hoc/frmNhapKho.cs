using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Do_An_Tin_Hoc
{
    public partial class FrmNhapKho : Form
    {
        private readonly CXuLy xuLy = new CXuLy();
        string diachi = "data.txt";

        public FrmNhapKho()
        {
            InitializeComponent();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            


            if (xuLy.docFile(diachi))
            {
                HienThi(xuLy.layDSMatHang());
            }
           
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[5].ReadOnly = false;
            }
        }

        private void bthDatHang_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Đã đặt hàng trên shoppe!");
            for(int i = 0; i < dgv.RowCount; i++)
            {
                if(dgv.Rows[i].Cells[5].Value !=null&& dgv.Rows[i].Cells[0].Value!=null)
                {
                    if((bool)dgv.Rows[i].Cells[5].Value == true)
                    {
                        CMatHang mathang = xuLy.TimMatHang(dgv.Rows[i].Cells[2].Value.ToString());
                        mathang.m_SoLuong += int.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                        xuLy.Sua(mathang);
                        dgv.Rows[i].Cells[5].Value = false;
                        dgv.Rows[i].Cells[1].Value = null;
                        dgv.Rows[i].Cells[0].Value = null;
                    }
                }
            }
            txtTongTien.Text = "";
            xuLy.luuFile(diachi);
            this.Close();
        }
        
        

        private string TinhTien(string giatien, string soluong)
        {
            int tong = 0;
            tong = int.Parse(giatien) *int.Parse(soluong);
            return tong.ToString();           
        }

      


      
        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        { 
           
          
            if (dgv.RowCount>0 &&  dgv.Rows[e.RowIndex].Cells[2].Value!=null )
            {
                index = e.RowIndex;
              
                txtTenMH.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtGiaTien.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();               
                txtSoLuong.Text = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

     
     
        


        private void HienThi(List<CMatHang> ds)
        {
            BindingSource source = new BindingSource();
            source.DataSource = ds;
            dgv.DataSource = source;
            dgv.Columns[6].Visible = false;
        }
        private void btnTongTien_Click(object sender, EventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                int tong = 0;
                
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    
                        tong += Convert.ToInt32(dgv.Rows[i].Cells[1].Value);
                }
                txtTongTien.Text = tong.ToString();
            }            
        }
        private void bthMuaThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (xuLy.TimMatHang(txtTenMH.Text) != null)
                {
                    if (dgv.Rows[index].Cells[2].Value.ToString() == txtTenMH.Text)
                    {
                        int temp = Convert.ToInt32(txtSoLuong.Text) - Convert.ToInt32(xuLy.GetDSMH()[txtTenMH.Text].m_SoLuong);
                        if(temp>0)
                        {
                            dgv.Rows[index].Cells[0].Value = temp;
                            dgv.Rows[index].Cells[1].Value = TinhTien(dgv.Rows[index].Cells[3].Value.ToString(), dgv.Rows[index].Cells[0].Value.ToString());

                        }                      
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show("Không có mặt hàng này trong Kho!");
            }
          
        }
        int tong = 0;
        int index = 0;
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            try
            {
                if ((bool)dgv.Rows[e.RowIndex].Cells[5].Value != true && dgv.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    dgv.Rows[e.RowIndex].Cells[5].Value = true;
                    dgv.Rows[e.RowIndex].Cells[1].Value = TinhTien(dgv.Rows[e.RowIndex].Cells[3].Value.ToString(), dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    tong += int.Parse(dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txtTongTien.Text = tong.ToString();
                }
                else if((bool)dgv.Rows[e.RowIndex].Cells[5].Value == true && dgv.Rows[e.RowIndex].Cells[0].Value != null)
                {                   
                    tong -= int.Parse(dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txtTongTien.Text = tong.ToString();
                    dgv.Rows[e.RowIndex].Cells[1].Value = null;
                    dgv.Rows[e.RowIndex].Cells[0].Value = null;
                    dgv.Rows[e.RowIndex].Cells[5].Value = false;
                }
            }catch(Exception) { }
           
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int temp = int.Parse(txtSoLuong.Text);
            }
            catch (Exception) { txtSoLuong.Text = string.Empty; }
        }

        private void txtTenMH_TextChanged(object sender, EventArgs e)
        {
            txtGiaTien.Text = xuLy.TimMatHang(txtTenMH.Text).m_GiaTien.ToString();
        }
    }  
}
