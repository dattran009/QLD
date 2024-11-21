using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiem
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            this.FormClosing += FrmHome_FormClosing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmDangNhap = new FrmDangNhap();

            // Ẩn form Home
            this.Hide();

            // Hiển thị form Đăng Nhập
            frmDangNhap.ShowDialog();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDangKy frmDangKy = new FrmDangKy();  
            this.Hide();
            frmDangKy.ShowDialog();
     
        }
        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Kết thúc chương trình khi đóng form Home
        }
        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
