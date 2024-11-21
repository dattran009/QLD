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
    public partial class FrmQLLopHoc : Form
    {
        private CSDL csdl;
        public FrmQLLopHoc()
        {
            InitializeComponent();
            csdl = new CSDL();
        }
        private void LoadDanhSachLop()
        {
            DataTable dtLopHoc = CSDL.GetAllLopHoc();
            dataGridView1.DataSource = dtLopHoc;
        }
        private void LoadDanhSachLopTheoHocKyNamHoc(string hocKy, string namHoc)
        {
            try
            {
                DataTable dt = csdl.GetLopHocByHocKyNamHoc(hocKy, namHoc);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text;
            string tenLop = txtTenLop.Text;
            string hocKy = cbBoxHocKy.SelectedItem.ToString();
            string namHoc = txtNamHoc.Text;

            if (csdl.AddLopHoc(maLop, tenLop, hocKy, namHoc))
            {
                MessageBox.Show("Thêm lớp học thành công!");
                LoadDanhSachLopTheoHocKyNamHoc(hocKy, namHoc); // Cập nhật danh sách lớp học sau khi thêm
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm lớp học.");
            }
        }

        private void FrmQLLopHoc_Load(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text;
            string tenLop = txtTenLop.Text;
            string hocKy = cbBoxHocKy.SelectedItem.ToString();
            string namHoc = txtNamHoc.Text;

            if (csdl.UpdateLopHoc(maLop, tenLop, hocKy, namHoc))
            {
                MessageBox.Show("Cập nhật lớp học thành công!");
                LoadDanhSachLopTheoHocKyNamHoc(hocKy, namHoc); // Cập nhật danh sách lớp học sau khi sửa
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật lớp học.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận yêu cầu người dùng xác nhận hành động xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            // Kiểm tra kết quả từ hộp thoại xác nhận
            if (result == DialogResult.Yes)
            {
                // Thực hiện xóa dữ liệu
                string maLop = txtMaLop.Text;  // Hoặc lấy giá trị từ các control khác tùy thuộc vào thiết kế của bạn
                bool isDeleted = csdl.DeleteLopHoc(maLop);  // Giả sử bạn có phương thức xóa trong lớp DAL

                if (isDeleted)
                {
                    MessageBox.Show("Lớp đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Có thể reload lại danh sách lớp học sau khi xóa
                    LoadDanhSachLopTheoHocKyNamHoc(cbBoxHocKy.SelectedItem.ToString(), txtNamHoc.Text);
                }
                else
                {
                    MessageBox.Show("Xóa lớp không thành công. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu người dùng chọn "No", không thực hiện hành động xóa
                MessageBox.Show("Hành động xóa đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string selectedHocKy = cbBoxHocKy.SelectedItem?.ToString();
            string selectedNamHoc = txtNamHoc.Text;

            if (!string.IsNullOrEmpty(selectedHocKy) && !string.IsNullOrEmpty(selectedNamHoc))
            {
                LoadDanhSachLopTheoHocKyNamHoc(selectedHocKy, selectedNamHoc);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học kỳ và nhập năm học.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã được click
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Điền giá trị vào TextBox
                txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
                txtNamHoc.Text = row.Cells["NamHoc"].Value.ToString();
                cbBoxHocKy.SelectedItem = row.Cells["HocKy"].Value.ToString();
                // Thêm các trường khác vào TextBox hoặc ComboBox nếu cần
            }
        }
    }
}
