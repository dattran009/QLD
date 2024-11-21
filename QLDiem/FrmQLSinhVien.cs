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
    public partial class FrmQLSinhVien : Form
    {
        private CSDL csdl;
        public FrmQLSinhVien()
        {
            InitializeComponent();
            csdl = new CSDL();
        }
        private void LoadData()
        {
            DataTable dt = csdl.GetAllStudents(); // Lấy danh sách sinh viên từ cơ sở dữ liệu
            dataGridView1.DataSource = dt; // Gán danh sách sinh viên vào DataGridView
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động điều chỉnh kích thước
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu tất cả các trường đã được điền
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtKhoaHoc.Text) ||
                string.IsNullOrWhiteSpace(txtChuyenNganh.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return; // Không tiếp tục nếu có trường thiếu
            }

            // Kiểm tra nếu mã sinh viên đã tồn tại
            if (csdl.CheckStudentExists(txtMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại. Vui lòng nhập mã khác.");
                return; // Không tiếp tục nếu mã sinh viên trùng
            }

            // Gọi phương thức thêm sinh viên
            bool success = csdl.AddStudent(
                txtMaSV.Text,
                txtHoTen.Text,
                txtEmail.Text,
                txtSDT.Text,
                txtKhoaHoc.Text,
                txtChuyenNganh.Text,
                txtDiaChi.Text,
                dateTimePicker1.Value,
                comboBox1.SelectedItem.ToString(),
                txtCCCD.Text
            );

            if (success)
            {
                MessageBox.Show("Thêm sinh viên thành công.");
                LoadData(); // Tải lại dữ liệu vào DataGridView
            }
            else
            {
                MessageBox.Show("Thêm sinh viên không thành công.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool result = csdl.UpdateStudent(
               txtMaSV.Text,
               txtHoTen.Text,
               txtEmail.Text,
               txtSDT.Text,
               txtKhoaHoc.Text,
               txtChuyenNganh.Text,
               txtDiaChi.Text,
               dateTimePicker1.Value,
               comboBox1.SelectedItem.ToString(),
               txtCCCD.Text);

            if (result)
            {
                MessageBox.Show("Cập nhật sinh viên thành công!");
                LoadData(); // Tải lại dữ liệu để cập nhật danh sách
            }
            else
            {
                MessageBox.Show("Cập nhật sinh viên không thành công!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Nếu người dùng chọn "Có", thực hiện xóa
                bool result = csdl.DeleteStudent(txtMaSV.Text);
                if (result)
                {
                    MessageBox.Show("Xóa sinh viên thành công!");
                    LoadData(); // Tải lại dữ liệu để cập nhật danh sách
                }
                else
                {
                    MessageBox.Show("Xóa sinh viên không thành công!");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text; // Lấy mã sinh viên từ TextBox
            DataTable dt = csdl.SearchStudents(maSV); // Gọi phương thức tìm kiếm
            dataGridView1.DataSource = dt; // Gán kết quả tìm kiếm vào DataGridView
        }

        private void FrmQLSinhVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy thông tin từ các cột trong dòng đã chọn
                txtMaSV.Text = selectedRow.Cells["MaSV"].Value.ToString();
                txtHoTen.Text = selectedRow.Cells["HoTen"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();
                txtKhoaHoc.Text = selectedRow.Cells["KhoaHoc"].Value.ToString();
                txtChuyenNganh.Text = selectedRow.Cells["ChuyenNganh"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                comboBox1.SelectedItem = selectedRow.Cells["GioiTinh"].Value.ToString();
                txtCCCD.Text = selectedRow.Cells["SoCCCD"].Value.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
