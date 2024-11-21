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
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }

        private CSDL csdl;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            FrmHome frmHome = new FrmHome(); // Khởi tạo đối tượng FrmHome
            frmHome.Show(); // Hiển thị trang Home
            this.Hide(); // Ẩn trang đăng nhập hiện tại
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text; // Lấy tài khoản từ TextBox
            string matKhau = txtMatKhau.Text; // Lấy mật khẩu từ TextBox
            string xacNhanMatKhau = txtXacNhanMatKhau.Text; // Lấy mật khẩu xác nhận từ TextBox

            // Kiểm tra xem tài khoản và mật khẩu đã được nhập
            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(xacNhanMatKhau))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem mật khẩu và xác nhận mật khẩu có khớp nhau không
            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp! Vui lòng nhập lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           

            // Gọi phương thức AddUser để thêm tài khoản mới
            if (csdl.AddUser(taiKhoan, matKhau))
            {
                MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form Đăng Ký
                FrmDangNhap frmDangNhap = new FrmDangNhap(); // Tạo mới form Đăng Nhập
                frmDangNhap.Show(); // Mở lại form Đăng Nhập
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            csdl = new CSDL(); // Khởi tạo đối tượng CSDL
        }
    }
}
