using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1, IService2
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
        public string[] GetAuthors()
        {
            string[] authors=new string[4];
            authors[0] = "Nguyễn Thế Đạt - 091390";
            authors[1] = "Nguyễn Quang Khải - 081668";
            authors[2] = "Ngô Trường Luân - 080196";
            authors[3] = "Xây dựng ứng dụng WS cung cấp thông tin nhà hàng, quán cà phê";
            return authors;
        }
        public string GetAuthors1()
        {
            return string.Format("Đề tài: Xây dựng ứng dụng WS cung cấp thông tin nhà hàng, quán cà phê");
        }
        public string Userdangky(string username, string password, string email, string hoten, string diachi, string sodienthoai, int phanquyen)
        {
            try
            {
                string pass = Mahoa(password);
                KiemTraLoi.Userdangky(username, pass, email, hoten, diachi, sodienthoai, phanquyen);
                return "Thành công";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
        public string Mahoa(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] HashBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            HashBytes = md5.ComputeHash(encoder.GetBytes(password));
            return encoder.GetString(HashBytes);
        }
        public bool Userdangnhap(string username, string password)
        {
            try
            {
                password = Mahoa(password);
                return KiemTraLoi.Userdangnhap(username, password);
            }
            catch (ArgumentException ex)
            {
                throw new FaultException(ex.Message);
            }
            catch
            {
                throw new FaultException("Lỗi Dịch Vụ !");
            }
        }
        public NHCF[] LoadNHCF()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id", conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public string[] LoadTP()
        {
            int k = 0;
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("Select TenThanhPho from ThanhPho", conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            string[] DSTP = new string[dt.Rows.Count];
            foreach (DataRow rows in dt.Rows)
            {
                DSTP[k] = rows[0].ToString();
                k++;
            }
            return DSTP;
        }
        public string[] LoadQuan(int tp)
        {
            int k = 0;
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("Select TenQuan from Quan Where IdThanhPho=@tp", conn);
            cmd.Parameters.AddWithValue("@tp", tp);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            string[] DSQuan = new string[dt.Rows.Count];
            foreach (DataRow rows in dt.Rows)
            {
                DSQuan[k] = rows[0].ToString();
                k++;
            }
            return DSQuan;
        }
        public NHCF[] Timdiadiem(string TenThanhPho, string Quan, string Duong, bool chinhxac)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            if (chinhxac == false)
                cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (Quan.TenQuan like N'%'+@Quan+'%' ) AND (ThanhPho.TenThanhPho like N'%'+@TenThanhPho+'%' ) AND (NhaHang.Duong like N'%'+@Duong+'%' )", conn);
            else
                cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (Quan.TenQuan= N'" + @Quan + "') AND (ThanhPho.TenThanhPho= N'" + @TenThanhPho + "') AND (ThanhPho.Duong= N'" + @Duong + "')", conn);
            cmd.Parameters.AddWithValue("@TenThanhPho", TenThanhPho);
            cmd.Parameters.AddWithValue("@Quan", Quan);
            cmd.Parameters.AddWithValue("@Duong", Duong);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang=new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i]= temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timdiadiemtp(string TenThanhPho)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (ThanhPho.TenThanhPho= N'" + @TenThanhPho + "')", conn);
            cmd.Parameters.AddWithValue("@TenThanhPho", TenThanhPho);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timdiadiemtpquan(string TenThanhPho, string Quan)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (Quan.TenQuan= N'" + @Quan + "') AND (ThanhPho.TenThanhPho= N'" + @TenThanhPho + "')", conn);
            cmd.Parameters.AddWithValue("@TenThanhPho", TenThanhPho);
            cmd.Parameters.AddWithValue("@Quan", Quan);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timdiadiemduong(string Duong, bool chinhxac)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            if (chinhxac == false)
                cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (NhaHang.Duong like N'%'+@Duong+'%' )", conn);
            else
                cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (ThanhPho.Duong= N'" + @Duong + "')", conn);
            cmd.Parameters.AddWithValue("@Duong", Duong);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timnguoidang(string username)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (NhaHang.username= N'" + @username + "')", conn);
            cmd.Parameters.AddWithValue("@username", username);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timkhonggian(string Loai)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (NhaHang.KhongGian like N'%'+@Loai+'%' )", conn);
            cmd.Parameters.AddWithValue("@Loai", Loai);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timmonan(string MonAn)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho,ThucDon WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND NhaHang.Id=ThucDon.IdNhaHang AND (ThucDon.MonAn like N'%'+@MonAn+'%' )", conn);
            cmd.Parameters.AddWithValue("@MonAn", MonAn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timnhucau(string MucDich)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND (NhaHang.MucDich like N'%'+@MucDich+'%' )", conn);
            cmd.Parameters.AddWithValue("@MucDich", MucDich);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timgia(int GiaTu, int GiaDen)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT DISTINCT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho,ThucDon WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND NhaHang.Id=ThucDon.IdNhaHang AND (ThucDon.Gia>@GiaTu OR ThucDon.Gia=@GiaTu) AND (ThucDon.Gia<@GiaDen OR ThucDon.Gia=@GiaDen)", conn);
            cmd.Parameters.AddWithValue("@GiaTu", GiaTu);
            cmd.Parameters.AddWithValue("@GiaDen", GiaDen);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public NHCF[] Timkhuyenmai(string Loai)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT DISTINCT NhaHang.Id, NhaHang.TenNhaHang, NhaHang.LoaiHinh, NhaHang.SoNha, NhaHang.Duong, NhaHang.Phuong, Quan.TenQuan, ThanhPho.TenThanhPho, NhaHang.DienThoai, NhaHang.Fax, NhaHang.WebSite, NhaHang.Email, NhaHang.DatChoTruoc, NhaHang.SoCho, NhaHang.GioPhucVu, NhaHang.MucDich, NhaHang.KhongGian, NhaHang.BaiDoXe, NhaHang.ThanhToan, NhaHang.NgonNgu FROM NhaHang,Quan,ThanhPho,KhuyenMai WHERE NhaHang.IdThanhPho=ThanhPho.Id AND NhaHang.IdQuan=Quan.Id AND NhaHang.Id=KhuyenMai.IdNhaHang AND (KhuyenMai.ThongTin like N'%'+@Loai+'%' )", conn);
            cmd.Parameters.AddWithValue("@Loai", Loai);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            NHCF[] nhahang = new NHCF[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                NHCF temp = new NHCF();
                temp.Id = int.Parse(row[0].ToString());
                temp.TenNhaHang = row[1].ToString();
                temp.LoaiHinh = row[2].ToString();
                temp.SoNha = row[3].ToString();
                temp.Duong = row[4].ToString();
                temp.Phuong = row[5].ToString();
                temp.Quan = row[6].ToString();
                temp.ThanhPho = row[7].ToString();
                temp.DienThoai = row[8].ToString();
                temp.Fax = row[9].ToString();
                temp.WebSite = row[10].ToString();
                temp.Email = row[11].ToString();
                temp.DatChoTruoc = row[12].ToString();
                temp.SoCho = int.Parse(row[13].ToString());
                temp.GioPhucVu = row[14].ToString();
                temp.MucDich = row[15].ToString();
                temp.KhongGian = row[16].ToString();
                temp.BaiDoXe = row[17].ToString();
                temp.ThanhToan = row[18].ToString();
                temp.NgonNgu = row[19].ToString();
                nhahang[i] = temp;
                i++;
            }
            return nhahang;
        }
        public bool HasNHCF(int Id, NHCF[] nhahang)
        {
            return nhahang.Any(x => x.Id == Id);
        }
        public NHCF GetNHCF(int Id, NHCF[] nhahang)
        {
            if (!HasNHCF(Id,nhahang))
            {
                var error = new CustomFaultMsg { Message = "Không có nhà hàng nào với ID là : " + Id };
                throw new FaultException<CustomFaultMsg>(error, error.Message);
            }
            return nhahang.FirstOrDefault(x => x.Id == Id);
        }
        public ThucDon[] GetMenu(int IdNhaHang)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM ThucDon Where IdNhaHang=@IdNhaHang", conn);
            cmd.Parameters.AddWithValue("@IdNhaHang", IdNhaHang);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            ThucDon[] menu = new ThucDon[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                ThucDon temp = new ThucDon();
                temp.IdNhaHang = int.Parse(row[0].ToString());
                temp.MonAn = row[1].ToString();
                temp.NguyenLieu = row[2].ToString();
                temp.PhuongPhap = row[3].ToString();
                temp.Gia = int.Parse(row[4].ToString());
                menu[i] = temp;
                i++;
            }
            return menu;
        }
        public KhuyenMai GetKhuyenMai(int IdNhaHang)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT TOP 1 * FROM KhuyenMai Where IdNhaHang=@IdNhaHang", conn);
            cmd.Parameters.AddWithValue("@IdNhaHang", IdNhaHang);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            KhuyenMai km = new KhuyenMai();
            foreach (DataRow row in dt.Rows)
            {
                km.IdNhaHang = int.Parse(row[0].ToString());
                km.TenKhuyenMai = row[1].ToString();
                km.ThoiGianStart = row[2].ToString();
                km.ThoiGianEnd = row[3].ToString();
                km.ThongTin = row[4].ToString();
            }
            return km;
        }
        public GopY[] GetGopY(int IdNhaHang)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NH-CF"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM GopY Where IdNhaHang=@IdNhaHang", conn);
            cmd.Parameters.AddWithValue("@IdNhaHang", IdNhaHang);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            GopY[] comment = new GopY[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                GopY temp = new GopY();
                temp.IdNhaHang = int.Parse(row[0].ToString());
                temp.TenTaiKhoan = row[1].ToString();
                temp.NoiDung = row[2].ToString();
                temp.NgayGopY = row[3].ToString();
                comment[i] = temp;
                i++;
            }
            return comment;
        }
        public string GopY(int IdNhaHang, string TaiKhoan, string NoiDung, string NgayGopY)
        {
            try
            {
                KiemTraLoi.GopY(IdNhaHang,TaiKhoan,NoiDung,NgayGopY);
                return "Gửi Góp Ý Thành công";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
        public string DatBan(int IdNhaHang, string TaiKhoan, int SoCho, string ThoiGian, string DichVu, string DienThoai)
        {
            try
            {
                KiemTraLoi.DatBan(IdNhaHang,TaiKhoan,SoCho,ThoiGian,DichVu,DienThoai);
                return "Đặt Bàn Thành công";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
        public string DangNHCF(NHCF NhaHang, int IdQuan, int IdThanhPho, string username)
        {
            try
            {
                KiemTraLoi.DangNHCF(NhaHang,IdQuan,IdThanhPho,username);
                return "Đăng Bài Thành công";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
        public string DangThucDon(ThucDon menu)
        {
            try
            {
                KiemTraLoi.DangThucDon(menu);
                return "Đăng Bài Thành công";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
        public string DangKhuyenMai(KhuyenMai khmai)
        {
            try
            {
                KiemTraLoi.DangKhuyenMai(khmai);
                return "Đăng Bài Thành công";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
    }
}
