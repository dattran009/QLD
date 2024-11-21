using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLDiem
{
    public partial class FrmQuanLy : Form
    {
        private string taiKhoanDangNhap;
        public FrmQuanLy(string taiKhoan)
        {
            InitializeComponent();
            taiKhoanDangNhap = taiKhoan; // Lưu tên tài khoản đã đăng nhập
        }
        public FrmQuanLy()
        {
            InitializeComponent();
        }

        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            lblTaiKhoan.Text = "Tài khoản đang đăng nhập: " + taiKhoanDangNhap;
        }
        public void ShowFormInPanel(Form form)
        {
            panelContainer.Controls.Clear(); // Xóa các điều khiển trước đó trong panel
            form.TopLevel = false; // Thiết lập form con không phải là form đầu
            form.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền để ngăn di chuyển form
            form.Dock = DockStyle.Fill; // Đặt form con khớp với panel
            panelContainer.Controls.Add(form); // Thêm form vào panel
            form.Show(); // Hiển thị form
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQLSinhVien_Click(object sender, EventArgs e)
        {
            FrmQLSinhVien frmQLSinhVien = new FrmQLSinhVien();
            ShowFormInPanel(frmQLSinhVien);
        }

        private void lblTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmQLLopHoc frmQLLopHoc = new FrmQLLopHoc();
            ShowFormInPanel(frmQLLopHoc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmQLMonHoc frm =   new FrmQLMonHoc();
                ShowFormInPanel(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmQLDiemSV frmQLSDieminhVien = new FrmQLDiemSV();
            ShowFormInPanel(frmQLSDieminhVien);
        }

        

        

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn kết thúc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát ứng dụng nếu người dùng chọn "Yes"
            }
            // Nếu chọn "No", không làm gì cả và trở về ứng dụng
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmQLDiemMonHoc frmQLDiemMonHoc = new FrmQLDiemMonHoc();
            ShowFormInPanel(frmQLDiemMonHoc);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FrmQLSinhVien_LopHoc frm    =   new FrmQLSinhVien_LopHoc();
            ShowFormInPanel(frm);
        }
    }
}
