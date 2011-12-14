using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Server
{
    [DataContract]
    public class KiemTraLoi
    {
        static SqlConnection conn;
        static SqlDataAdapter da;
        static DataTable dt;
        static SqlCommand cmd;
        internal static void Userdangky(string username, string password, string email, string hoten, string diachi, string sodienthoai, int phanquyen)
        {
            
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
                
            // Check connect SQL
            try
            {
                conn.Open();
            }
            catch
            {
                throw new ArgumentException("Không thể kết nối với database !");
            }

            //Check username
            try
            {
                cmd = new SqlCommand("Select Username from TaiKhoan where Username=@Username", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch
            {
                throw new ArgumentException("Không thể kiểm tra tài khoản !");
            }
            if (dt.Rows.Count > 0)
            {
                throw new ArgumentException("Tài khoản đã được sử dụng !");
            }
            
            // Đăng ký tài khoản mới
            try
            {
                cmd = new SqlCommand("Insert into TaiKhoan values (@username,@password,@email,@hoten,@diachi,@sodienthoai,@phanquyen)", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@hoten", hoten);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                cmd.Parameters.AddWithValue("@phanquyen", phanquyen);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw new ArgumentException("Không thể đăng kí !");
            }
        }

        internal static bool Userdangnhap(string username, string password)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            // Kiểm tra kết nối SQL có thành công không?
            try
            {
                conn.Open();
            }
            catch
            {
                throw new ArgumentException("Không thể kết nối tới dịch vụ !");
            }
            
            try
            {
                cmd = new SqlCommand("Select * from TaiKhoan where Username=@username and Password=@password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
            	throw new ArgumentException("Đăng nhập thất bại !");
            }
        }
        internal static void GopY(int IdNhaHang, string TaiKhoan, string NoiDung, string NgayGopY)
        {

            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;

            // Check connect SQL
            try
            {
                conn.Open();
            }
            catch
            {
                throw new ArgumentException("Không thể kết nối với database !");
            }
            // Gửi góp ý mới
            try
            {
                cmd = new SqlCommand("Insert into GopY values (@IdNhaHang,@TaiKhoan,@NoiDung,@NgayGopY)", conn);
                cmd.Parameters.AddWithValue("@IdNhaHang", IdNhaHang);
                cmd.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                cmd.Parameters.AddWithValue("@NoiDung", NoiDung);
                cmd.Parameters.AddWithValue("@NgayGopY", NgayGopY);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw new ArgumentException("Không thể gửi góp ý !");
            }
        }
        internal static void DatBan(int IdNhaHang, string TaiKhoan, int SoCho, string ThoiGian, string DichVu, string DienThoai)
        {

            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;

            // Check connect SQL
            try
            {
                conn.Open();
            }
            catch
            {
                throw new ArgumentException("Không thể kết nối với database !");
            }
            // Gửi góp ý mới
            try
            {
                cmd = new SqlCommand("Insert into DatBan values (@IdNhaHang,@TaiKhoan,@SoCho,@ThoiGian,@DichVu,@DienThoai)", conn);
                cmd.Parameters.AddWithValue("@IdNhaHang", IdNhaHang);
                cmd.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                cmd.Parameters.AddWithValue("@SoCho", SoCho);
                cmd.Parameters.AddWithValue("@ThoiGian", ThoiGian);
                cmd.Parameters.AddWithValue("@DichVu", DichVu);
                cmd.Parameters.AddWithValue("@DienThoai", DienThoai);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw new ArgumentException("Không thể đặt bàn !");
            }
        }
        internal static void DangNHCF(NHCF NhaHang,int IdQuan, int IdThanhPho, string username)
        {

            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;

            // Check connect SQL
            try
            {
                conn.Open();
            }
            catch
            {
                throw new ArgumentException("Không thể kết nối với database !");
            }
            // Gửi góp ý mới
            try
            {
                cmd = new SqlCommand("Insert into NhaHang values (@TenNhaHang,@LoaiHinh,@SoNha,@Duong,@Phuong,@IdQuan,@IdThanhPho,@DienThoai,@Fax,@WebSite,@Email,@DatChoTruoc,@SoCho,@GioPhucVu,@MucDich,@KhongGian,@BaiDoXe,@ThanhToan,@NgonNgu,@username)", conn);
                cmd.Parameters.AddWithValue("@TenNhaHang", NhaHang.TenNhaHang);
                cmd.Parameters.AddWithValue("@LoaiHinh", NhaHang.LoaiHinh);
                cmd.Parameters.AddWithValue("@SoNha", NhaHang.SoNha);
                cmd.Parameters.AddWithValue("@Duong", NhaHang.Duong);
                cmd.Parameters.AddWithValue("@Phuong", NhaHang.Phuong);
                cmd.Parameters.AddWithValue("@IdQuan", IdQuan);
                cmd.Parameters.AddWithValue("@IdThanhPho", IdThanhPho);
                cmd.Parameters.AddWithValue("@DienThoai", NhaHang.DienThoai);
                cmd.Parameters.AddWithValue("@Fax", NhaHang.Fax);
                cmd.Parameters.AddWithValue("@WebSite", NhaHang.WebSite);
                cmd.Parameters.AddWithValue("@Email", NhaHang.Email);
                cmd.Parameters.AddWithValue("@DatChoTruoc", NhaHang.DatChoTruoc);
                cmd.Parameters.AddWithValue("@SoCho", NhaHang.SoCho);
                cmd.Parameters.AddWithValue("@GioPhucVu", NhaHang.GioPhucVu);
                cmd.Parameters.AddWithValue("@MucDich", NhaHang.MucDich);
                cmd.Parameters.AddWithValue("@KhongGian", NhaHang.KhongGian);
                cmd.Parameters.AddWithValue("@BaiDoXe", NhaHang.BaiDoXe);
                cmd.Parameters.AddWithValue("@ThanhToan", NhaHang.ThanhToan);
                cmd.Parameters.AddWithValue("@NgonNgu", NhaHang.NgonNgu);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw new ArgumentException("Không thể đăng thông tin nhà hàng cà phê !");
            }
        }
        internal static void DangThucDon(ThucDon menu)
        {

            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;

            // Check connect SQL
            try
            {
                conn.Open();
            }
            catch
            {
                throw new ArgumentException("Không thể kết nối với database !");
            }
            // Gửi góp ý mới
            try
            {
                cmd = new SqlCommand("Insert into ThucDon values (@IdNhaHang,@MonAn,@NguyenLieu,@PhuongPhap,@Gia)", conn);
                cmd.Parameters.AddWithValue("@IdNhaHang", menu.IdNhaHang);
                cmd.Parameters.AddWithValue("@MonAn", menu.MonAn);
                cmd.Parameters.AddWithValue("@NguyenLieu", menu.NguyenLieu);
                cmd.Parameters.AddWithValue("@PhuongPhap", menu.PhuongPhap);
                cmd.Parameters.AddWithValue("@Gia", menu.Gia);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw new ArgumentException("Không thể đăng thông tin thực đơn !");
            }
        }
        internal static void DangKhuyenMai(KhuyenMai khmai)
        {

            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;

            // Check connect SQL
            try
            {
                conn.Open();
            }
            catch
            {
                throw new ArgumentException("Không thể kết nối với database !");
            }
            // Gửi góp ý mới
            try
            {
                cmd = new SqlCommand("Insert into KhuyenMai values (@IdNhaHang,@TenKhuyenMai,@ThoiGianStart,@ThoiGianEnd,@ThongTin)", conn);
                cmd.Parameters.AddWithValue("@IdNhaHang", khmai.IdNhaHang);
                cmd.Parameters.AddWithValue("@TenKhuyenMai", khmai.TenKhuyenMai);
                cmd.Parameters.AddWithValue("@ThoiGianStart", khmai.ThoiGianStart);
                cmd.Parameters.AddWithValue("@ThoiGianEnd", khmai.ThoiGianEnd);
                cmd.Parameters.AddWithValue("@ThongTin", khmai.ThongTin);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw new ArgumentException("Không thể đăng thông tin khuyến mãi!");
            }
        }
    }
}
