using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Server;
namespace Client
{
    public partial class TimGia : Form
    {
        ServiceReference1.Service1Client client;
        public TimGia()
        {
            InitializeComponent();
        }
        private void bt_Tim_Click(object sender, EventArgs e)
        {
            if (tb_giatu.Text != ""&&tb_giaden.Text!="")
            {
                lv_dsketqua.Items.Clear();
                client = new ServiceReference1.Service1Client();
                client.TimgiaCompleted += new EventHandler<ServiceReference1.TimgiaCompletedEventArgs>(TimgiaCallBack);
                client.TimgiaAsync(int.Parse(tb_giatu.Text),int.Parse(tb_giaden.Text));
            }
            else
            {
                lv_dsketqua.Items.Clear();
                client = new ServiceReference1.Service1Client();
                client.LoadNHCFCompleted += new EventHandler<ServiceReference1.LoadNHCFCompletedEventArgs>(LoadNHCFCallBack);
                client.LoadNHCFAsync();
            }
        }
        public NHCF[] dsnhahang;
        void LoadNHCFCallBack(object sender, ServiceReference1.LoadNHCFCompletedEventArgs e)
        {
            try
            {
                dsnhahang = e.Result;
                for (int i = 0; i < dsnhahang.Count(); i++)
                {
                    lv_dsketqua.Items.Add(dsnhahang[i].TenNhaHang + " - ( Loại Hình: " + dsnhahang[i].LoaiHinh + " )").ToolTipText = dsnhahang[i].Id.ToString();
                }
                client.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi Dịch Vụ Không Thể Load Nhà Hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void TimgiaCallBack(object sender, ServiceReference1.TimgiaCompletedEventArgs e)
        {
            try
            {
                dsnhahang = e.Result;
                for (int i = 0; i < dsnhahang.Count(); i++)
                {
                    lv_dsketqua.Items.Add(dsnhahang[i].TenNhaHang + " - ( Loại Hình: " + dsnhahang[i].LoaiHinh + " )").ToolTipText = dsnhahang[i].Id.ToString();
                }
                client.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi Dịch Vụ Không Thể Load Nhà Hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public NHCF nh;
        private void lv_dsketqua_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            client = new ServiceReference1.Service1Client();
            try
            {
                nh = client.GetNHCF(int.Parse(lv_dsketqua.Items[e.ItemIndex].ToolTipText), dsnhahang);
                ThucDon[] menu = client.GetMenu(nh.Id);
                GopY[] comment = client.GetGopY(nh.Id);
                ds_sochodc.Items.Clear();
                ds_sochodc.Items.Add("-Chọn số chỗ-");
                for (int i = 1; i <= nh.SoCho; i *= 2)
                {
                    ds_sochodc.Items.Add(i);
                }
                lv_menu.Items.Clear();
                lv_gopy.Items.Clear();
                foreach (ThucDon td in menu)
                {
                    lv_menu.Items.Add("Tên Món Ăn: " + td.MonAn + " - Nguyên Liệu: " + td.NguyenLieu + " - Phương Pháp: " + td.PhuongPhap + " - Giá: " + td.Gia);
                }
                foreach (GopY cm in comment)
                {
                    lv_gopy.Items.Add(cm.TenTaiKhoan + ": - " + cm.NgayGopY + " - " + cm.NoiDung);
                }
                KhuyenMai km = client.GetKhuyenMai(nh.Id);
                tb_tenkhuyenmai.Text = km.TenKhuyenMai;
                tb_thoigianstart.Text = km.ThoiGianStart;
                tb_thoigianend.Text = km.ThoiGianEnd;
                tb_thongtin.Text = km.ThongTin;
                tb_ten.Text = nh.TenNhaHang;
                tb_loaihinh.Text = nh.LoaiHinh;
                tb_diachi.Text = nh.SoNha + " " + nh.Duong + ", Phường " + nh.Phuong + ", Quận " + nh.Quan + ", Tp. " + nh.ThanhPho;
                tb_dienthoai.Text = nh.DienThoai;
                tb_fax.Text = nh.Fax;
                tb_website.Text = nh.WebSite;
                tb_email.Text = nh.Email;
                tb_datchotruoc.Text = nh.DatChoTruoc;
                tb_socho.Text = nh.SoCho.ToString();
                tb_giophucvu.Text = nh.GioPhucVu;
                tb_mucdich.Text = nh.MucDich;
                tb_khonggian.Text = nh.KhongGian;
                tb_baidoxe.Text = nh.BaiDoXe;
                tb_thanhtoan.Text = nh.ThanhToan;
                tb_ngonngu.Text = nh.NgonNgu;
                toolTip1.Show(nh.TenNhaHang + " " + nh.SoNha + " " + nh.Duong + ", Phường " + nh.Phuong + ", Quận " + nh.Quan + ", Tp." + nh.ThanhPho + "\nSố điện thoại : " + nh.DienThoai, lv_dsketqua, 2000);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Truy cập thông tin bị lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bt_gopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_gopy.Text != "")
                {
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    client.GopYCompleted += new EventHandler<ServiceReference1.GopYCompletedEventArgs>(GopYCallBack);
                    client.GopYAsync(nh.Id, Form1.username, tb_gopy.Text, String.Format("{0:dd/MM/yyyy}", DateTime.Now));
                    tb_gopy.Text = "";
                    GopY[] comment = client.GetGopY(nh.Id);
                    lv_gopy.Items.Clear();
                    foreach (GopY cm in comment)
                    {
                        lv_gopy.Items.Add(cm.TenTaiKhoan + ": - " + cm.NgayGopY + " - " + cm.NoiDung);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Dịch Vụ !", "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GopYCallBack(object sender, ServiceReference1.GopYCompletedEventArgs e)
        {
            MessageBox.Show(e.Result, "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            tb_gopy.Text = "";
        }

        private void bt_datcho_Click(object sender, EventArgs e)
        {
            if (ds_sochodc.SelectedIndex > 0 && tb_thoigiandc.Text != "" && tb_dienthoaidc.Text != "")
            {
                try
                {
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    client.DatBanCompleted += new EventHandler<ServiceReference1.DatBanCompletedEventArgs>(DatBanCallBack);
                    client.DatBanAsync(nh.Id, Form1.username, ds_sochodc.SelectedIndex, tb_thoigiandc.Text, tb_dichvudc.Text, tb_dienthoaidc.Text);
                }
                catch
                {
                    MessageBox.Show("Lỗi Dịch Vụ !", "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn số chỗ, thời gian và số điện thoại liên lạc khi muốn đặt bàn");
            }
        }
        void DatBanCallBack(object sender, ServiceReference1.DatBanCompletedEventArgs e)
        {
            MessageBox.Show(e.Result, "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_canceldc_Click(object sender, EventArgs e)
        {
            ds_sochodc.SelectedIndex = 0;
            tb_thoigiandc.Text = "";
            tb_dienthoaidc.Text = "";
            tb_dichvudc.Text = "";
        }
    }
}
