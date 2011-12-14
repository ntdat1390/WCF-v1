using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        string GetAuthors1();
        // TODO: Add your service operations here
    }
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string[] GetAuthors();
        // TODO: Add your service operations here
        // --------------------------------------

        // Đăng ký thành viên
        [OperationContract]
        [FaultContract(typeof(KiemTraLoi))]
        string Userdangky(string username, string password, string email, string hoten, string diachi, string sodienthoai,int phanquyen);

        // Mã hoá Passwords

        string Mahoa(string password);

        // Kiểm tra tài khoản khi đăng nhập
        [OperationContract]
        bool Userdangnhap(string username, string password);
        // Hàm trả về danh sách tất cả NH-CF
        [OperationContract]
        NHCF[] LoadNHCF();
        // Hàm trả về thành phố, quận
        [OperationContract]
        string[] LoadTP();
        [OperationContract]
        string[] LoadQuan(int tp);
        // Danh sách nhà hàng tìm được
        [OperationContract]
        NHCF[] Timdiadiem(string TenThanhPho, string Quan, string Duong, bool chinhxac);
        [OperationContract]
        NHCF[] Timdiadiemtp(string TenThanhPho);
        [OperationContract]
        NHCF[] Timdiadiemtpquan(string TenThanhPho, string Quan);
        [OperationContract]
        NHCF[] Timdiadiemduong(string Duong, bool chinhxac);
        [OperationContract]
        NHCF[] Timnguoidang(string username);
        [OperationContract]
        NHCF[] Timkhonggian(string Loai);
        [OperationContract]
        NHCF[] Timmonan(string MonAn);
        [OperationContract]
        NHCF[] Timnhucau(string MucDich);
        [OperationContract]
        NHCF[] Timgia(int GiaTu, int GiaDen);
        [OperationContract]
        NHCF[] Timkhuyenmai(string Loai);
        // Hiển thị thông tin nhà hàng
        [OperationContract]
        [FaultContract(typeof(CustomFaultMsg))]
        NHCF GetNHCF(int Id, NHCF[] nhahang);
        [OperationContract]
        bool HasNHCF(int Id, NHCF[] nhahang);
        // Hiển thị thông tin thực đơn của nhà hàng
        [OperationContract]
        ThucDon[] GetMenu(int IdNhaHang);
        // Hiển thị thông tin khuyến mãi của nhà hàng
        [OperationContract]
        KhuyenMai GetKhuyenMai(int IdNhaHang);
        // Hiển thị thông tin góp ý của nhà hàng
        [OperationContract]
        GopY[] GetGopY(int IdNhaHang);
        // Gửi góp ý của thành viên tới nhà hàng
        [OperationContract]
        [FaultContract(typeof(KiemTraLoi))]
        string GopY(int IdNhaHang, string TaiKhoan, string NoiDung, string NgayGopY);
        // Gửi đơn đặt bàn của thành viên tới nhà hàng
        [OperationContract]
        [FaultContract(typeof(KiemTraLoi))]
        string DatBan(int IdNhaHang, string TaiKhoan, int SoCho, string ThoiGian, string DichVu, string DienThoai);
        // Đăng thông tin nhà hàng cafe
        [OperationContract]
        [FaultContract(typeof(KiemTraLoi))]
        string DangNHCF(NHCF NhaHang, int IdQuan, int IdThanhPho, string username);
        // Đăng thông tin thực đơn nhà hàng cafe
        [OperationContract]
        [FaultContract(typeof(KiemTraLoi))]
        string DangThucDon(ThucDon menu);
        // Đăng thông tin khuyến mãi nhà hàng cafe
        [OperationContract]
        [FaultContract(typeof(KiemTraLoi))]
        string DangKhuyenMai(KhuyenMai khmai);
    }
    
    // Use a data contract as illustrated in the sample below to add composite types to service operations
    [DataContract]
    public class NHCF
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string TenNhaHang;
        [DataMember]
        public string LoaiHinh;
        [DataMember]
        public string SoNha;
        [DataMember]
        public string Duong;
        [DataMember]
        public string Phuong;
        [DataMember]
        public string Quan;
        [DataMember]
        public string ThanhPho;
        [DataMember]
        public string DienThoai;
        [DataMember]
        public string Fax;
        [DataMember]
        public string WebSite;
        [DataMember]
        public string Email;
        [DataMember]
        public string DatChoTruoc;
        [DataMember]
        public int SoCho;
        [DataMember]
        public string GioPhucVu;
        [DataMember]
        public string MucDich;
        [DataMember]
        public string KhongGian;
        [DataMember]
        public string BaiDoXe;
        [DataMember]
        public string ThanhToan;
        [DataMember]
        public string NgonNgu;
    }
    [DataContract]
    public class ThucDon
    {
        [DataMember]
        public int IdNhaHang;
        [DataMember]
        public string MonAn;
        [DataMember]
        public string NguyenLieu;
        [DataMember]
        public string PhuongPhap;
        [DataMember]
        public int Gia;
    }
    [DataContract]
    public class KhuyenMai
    {
        [DataMember]
        public int IdNhaHang;
        [DataMember]
        public string TenKhuyenMai;
        [DataMember]
        public string ThoiGianStart;
        [DataMember]
        public string ThoiGianEnd;
        [DataMember]
        public string ThongTin;
    }
    [DataContract]
    public class GopY
    {
        [DataMember]
        public int IdNhaHang;
        [DataMember]
        public string TenTaiKhoan;
        [DataMember]
        public string NoiDung;
        [DataMember]
        public string NgayGopY;
    }
}
