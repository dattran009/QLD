using System;
using System.Data;
using System.Data.SqlClient;

namespace QLDiem
{
    public class CSDL
    {
        private string connectionString = "Data Source=DESKTOP-N64K7CG;Initial Catalog=QLDiem;Integrated Security=True";

        // Phương thức để lấy kết nối đến cơ sở dữ liệu
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Phương thức kiểm tra tài khoản và mật khẩu
        public bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @TaiKhoan AND MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", username);
                    command.Parameters.AddWithValue("@MatKhau", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Trả về true nếu đăng nhập thành công
                }
            }
        }

        // Phương thức thêm người dùng mới (có thể mở rộng trong tương lai)
        public bool AddUser(string username, string password)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau) VALUES (@TaiKhoan, @MatKhau)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", username);
                    command.Parameters.AddWithValue("@MatKhau", password);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu thêm thành công
                }
            }
        }

        // Phương thức để lấy danh sách người dùng (có thể mở rộng trong tương lai)
        public DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM NguoiDung";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable; // Trả về DataTable chứa danh sách người dùng
        }
        public bool AddStudent(string maSV, string hoTen, string email, string soDienThoai, string khoaHoc, string chuyenNganh, string diaChi, DateTime ngaySinh, string gioiTinh, string soCCCD)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO SinhVien (MaSV, HoTen, Email, SoDienThoai, KhoaHoc, ChuyenNganh, DiaChi, NgaySinh, GioiTinh, SoCCCD) VALUES (@MaSV, @HoTen, @Email, @SoDienThoai, @KhoaHoc, @ChuyenNganh, @DiaChi, @NgaySinh, @GioiTinh, @SoCCCD)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSV", maSV);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    command.Parameters.AddWithValue("@KhoaHoc", khoaHoc);
                    command.Parameters.AddWithValue("@ChuyenNganh", chuyenNganh);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@SoCCCD", soCCCD);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu thêm thành công
                }
            }
        }




        // Sửa thông tin sinh viên
        public bool UpdateStudent(string maSV, string hoTen, string email, string soDienThoai, string khoaHoc, string chuyenNganh, string diaChi, DateTime ngaySinh, string gioiTinh, string soCCCD)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE SinhVien SET HoTen = @HoTen, Email = @Email, SoDienThoai = @SoDienThoai, KhoaHoc = @KhoaHoc, " +
                               "ChuyenNganh = @ChuyenNganh, DiaChi = @DiaChi, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, SoCCCD = @SoCCCD " +
                               "WHERE MaSV = @MaSV";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSV", maSV);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    command.Parameters.AddWithValue("@KhoaHoc", khoaHoc);
                    command.Parameters.AddWithValue("@ChuyenNganh", chuyenNganh);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@SoCCCD", soCCCD);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu sửa thành công
                }
            }
        }

        // Xóa sinh viên
        public bool DeleteStudent(string maSV)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSV", maSV);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu xóa thành công
                }
            }
        }

        // Thêm vào lớp CSDL_SinhVien
        public DataTable SearchStudents(string keyword)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM SinhVien WHERE MaSV LIKE @Keyword OR HoTen LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable; // Trả về DataTable chứa danh sách sinh viên tìm được
        }

        // Phương thức kiểm tra xem mã sinh viên đã tồn tại hay chưa
        public bool CheckStudentExists(string maSV)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSV", maSV);
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Trả về true nếu mã sinh viên đã tồn tại
                }
            }
        }

        // Lấy danh sách sinh viên
        public DataTable GetAllStudents()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM SinhVien";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable; // Trả về DataTable chứa danh sách sinh viên
        }
        public DataTable GetLopHocByHocKyNamHoc(string hocKy, string namHoc)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = GetConnection())  // Sử dụng GetConnection
            {
                string query = "SELECT * FROM LopHoc WHERE HocKy = @HocKy AND NamHoc = @NamHoc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HocKy", hocKy);
                cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        // Phương thức lấy tất cả lớp học
        public static DataTable GetAllLopHoc()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new CSDL().GetConnection()) // Dùng GetConnection của thể hiện CSDL
            {
                string query = "SELECT MaLop, TenLop, HocKy, NamHoc FROM LopHoc";  // Cập nhật câu lệnh SQL phù hợp
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        // Phương thức thêm lớp học
        public bool AddLopHoc(string maLop, string tenLop, string hocKy, string namHoc)
        {
            using (SqlConnection conn = GetConnection())  // Sử dụng GetConnection
            {
                string query = "INSERT INTO LopHoc (MaLop, TenLop, HocKy, NamHoc) VALUES (@MaLop, @TenLop, @HocKy, @NamHoc)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                cmd.Parameters.AddWithValue("@TenLop", tenLop);
                cmd.Parameters.AddWithValue("@HocKy", hocKy);
                cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu thêm thành công
            }
        }

        // Phương thức sửa lớp học
        public bool UpdateLopHoc(string maLop, string tenLop, string hocKy, string namHoc)
        {
            using (SqlConnection conn = GetConnection())  // Sử dụng GetConnection
            {
                string query = "UPDATE LopHoc SET TenLop = @TenLop, HocKy = @HocKy, NamHoc = @NamHoc WHERE MaLop = @MaLop";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                cmd.Parameters.AddWithValue("@TenLop", tenLop);
                cmd.Parameters.AddWithValue("@HocKy", hocKy);
                cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu sửa thành công
            }
        }

        // Phương thức xóa lớp học
        public bool DeleteLopHoc(string maLop)
        {
            using (SqlConnection conn = GetConnection())  // Sử dụng GetConnection
            {
                string query = "DELETE FROM LopHoc WHERE MaLop = @MaLop";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLop", maLop);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu xóa thành công
            }
        }
    }
}

