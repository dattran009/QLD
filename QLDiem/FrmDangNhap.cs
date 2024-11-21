using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiem
{
    public partial class FrmDangNhap : Form
    {
        private CSDL csdl;
        public FrmDangNhap()
        {
            InitializeComponent();
            csdl = new CSDL(); // Khởi tạo đối tượng CSDL
            txtMatKhau.PasswordChar = '*';
        }
      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FrmHome frmHome = new FrmHome(); // Khởi tạo đối tượng FrmHome
            frmHome.Show(); // Hiển thị trang Home
            this.Hide(); // Ẩn trang đăng nhập hiện tại
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;

            if (csdl.ValidateUser(taiKhoan, matKhau))
            {
                MessageBox.Show("Đăng nhập thành công!");
                FrmQuanLy frmQuanLy = new FrmQuanLy(taiKhoan); // Truyền tài khoản vào FrmQuanLy
                frmQuanLy.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = cb1.Checked ? '\0' : '*';
        }
    }
}
