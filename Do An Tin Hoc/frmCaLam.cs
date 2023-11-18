using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Tin_Hoc
{
    public partial class frmCaLamNV : Form
    {
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private List<string> dateOfWeek = new List<string>() { "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};
        public frmCaLamNV()
        {
            InitializeComponent();
        }

        private void pnlLich_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadMatrix()
        {
            Matrix = new List<List<Button>>() ;
            Button oldBtn = new Button() { Width = 0, Height = 0 ,Location = new Point(-3,0)};
           
            for (int i = 0; i < 6; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < 7; j++)
                {
                    Button btn = new Button() { Width =73,Height=40};                   
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width+3, oldBtn.Location.Y);
                    btn.Click += Btn_Click;
                    pnlLich.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    

                    oldBtn = btn;
                }
                oldBtn = new Button() { Width=0,Height=0,Location=new Point(-3,oldBtn.Location.Y+40)};
            }
            SetDefaultDate();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty((sender as Button).Text))
            {
                return;
            }
            else
            {
                MessageBox.Show("Hehe");
            }
            
        }

        private void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for(int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.WhiteSmoke;
                }
            }
        }
        private bool CompareDateTime(DateTime dateTime1,DateTime dateTime2)
        {
            return dateTime1.Year== dateTime2.Year && dateTime1.Month== dateTime2.Month && dateTime1.Day== dateTime2.Day;
        }

        private void ThemSoVoMatrix(DateTime date)
        {
            ClearMatrix();

            DateTime temp = new DateTime(date.Year, date.Month, 1);
           
            int line = 0;
            for (int i=1;i< DateTime.DaysInMonth(temp.Year, temp.Month); i++)
            {
                int column = dateOfWeek.IndexOf(temp.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();

                if (CompareDateTime(dtp.Value, temp))
                {
                    btn.BackColor = Color.BlueViolet;
                }

                if (CompareDateTime(DateTime.Now, temp))
                {
                    btn.BackColor = Color.Yellow;
                }

                if (column>=6)
                {
                    line++;
                }

                temp= temp.AddDays(1);
            }
        }

        private void frmCaLam_Load(object sender, EventArgs e)
        {
            LoadMatrix();
        }

        private void SetDefaultDate()
        {
            dtp.Value= DateTime.Now;
        }
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            ThemSoVoMatrix((sender as DateTimePicker).Value);
        }
        private void btnThangSau_Click(object sender, EventArgs e)
        {
            dtp.Value=dtp.Value.AddMonths(1);
        }

        private void btnThangTruoc_Click(object sender, EventArgs e)
        {
            dtp.Value = dtp.Value.AddMonths(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtp.Value = DateTime.Now;
        }
    }
}
