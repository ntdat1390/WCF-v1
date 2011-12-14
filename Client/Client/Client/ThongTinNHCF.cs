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
    public partial class ThongTinNHCF : Form
    {
        ServiceReference1.Service1Client client;
        public ThongTinNHCF()
        {
            InitializeComponent();
        }

        private void bt_dangbai_Click(object sender, EventArgs e)
        {
            if (ds_Quan.SelectedIndex > 0 && ds_TP.SelectedIndex > 0 && tb_ten.Text != "" && tb_sonha.Text != "" && tb_phuong.Text != "" && tb_duong.Text != "" && tb_dienthoai.Text != "")
            {
                NHCF nhg = new NHCF();
                int IdQuan;
                int IdThanhPho;
                nhg.TenNhaHang = tb_ten.Text;
                nhg.LoaiHinh = tb_loaihinh.Text;
                nhg.SoNha=tb_sonha.Text;
                nhg.Duong = tb_duong.Text;
                nhg.Phuong = tb_phuong.Text;
                IdQuan = ds_Quan.SelectedIndex;
                IdThanhPho = ds_TP.SelectedIndex;
                nhg.DienThoai = tb_dienthoai.Text;
                nhg.Fax = tb_fax.Text;
                nhg.WebSite = tb_website.Text;
                nhg.Email = tb_email.Text;
                nhg.DatChoTruoc = tb_datchotruoc.Text;
                nhg.SoCho= int.Parse(tb_socho.Text);
                nhg.GioPhucVu = tb_giophucvu.Text;
                nhg.MucDich = tb_mucdich.Text;
                nhg.KhongGian = tb_khonggian.Text;
                nhg.BaiDoXe = tb_baidoxe.Text;
                nhg.ThanhToan = tb_thanhtoan.Text;
                nhg.NgonNgu = tb_ngonngu.Text;
                try
                {
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    client.DangNHCFCompleted += new EventHandler<ServiceReference1.DangNHCFCompletedEventArgs>(DangNHCFCallBack);
                    client.DangNHCFAsync(nhg,IdQuan,IdThanhPho,Form1.username);
                    client.TimnguoidangCompleted += new EventHandler<ServiceReference1.TimnguoidangCompletedEventArgs>(TimnguoidangCallBack);
                    client.TimnguoidangAsync(Form1.username);
                }
                catch
                {
                    MessageBox.Show("Lỗi Dịch Vụ !", "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập tên, địa chỉ và số điện thoại của nhà hàng");
            }
        }
        void DangNHCFCallBack(object sender, ServiceReference1.DangNHCFCompletedEventArgs e)
        {
            MessageBox.Show(e.Result, "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ThongTinNHCF_Load(object sender, EventArgs e)
        {
            client = new ServiceReference1.Service1Client();
            client.LoadTPCompleted += new EventHandler<ServiceReference1.LoadTPCompletedEventArgs>(LoadTPCallBack);
            client.LoadTPAsync();
            client.TimnguoidangCompleted += new EventHandler<ServiceReference1.TimnguoidangCompletedEventArgs>(TimnguoidangCallBack);
            client.TimnguoidangAsync(Form1.username);
        }
        public NHCF[] dsnhahang;
        void TimnguoidangCallBack(object sender, ServiceReference1.TimnguoidangCompletedEventArgs e)
        {
            try
            {
                lv_dsketqua.Items.Clear();
                dsnhahang = e.Result;
                for (int i = 0; i < dsnhahang.Count(); i++)
                {
                    lv_dsketqua.Items.Add(dsnhahang[i].TenNhaHang + " - ( Loại Hình: " + dsnhahang[i].LoaiHinh + " )").ToolTipText = dsnhahang[i].Id.ToString();
                }
                client.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi Dịch Vụ Không Thể Tìm Nhà Hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadTPCallBack(object sender, ServiceReference1.LoadTPCompletedEventArgs e)
        {
            try
            {
                string[] dsLoai = e.Result;
                ds_TP.Items.Add("-Tỉnh/Thành Phố-");
                for (int i = 0; i < dsLoai.Count(); i++)
                {
                    ds_TP.Items.Add(dsLoai[i].ToString());
                }
                client.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi ! Không Thể Load Danh Sách Tỉnh/Thành Phố", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadQuanCallBack(object sender, ServiceReference1.LoadQuanCompletedEventArgs e)
        {
            try
            {
                ds_Quan.Items.Add("-Quận/Huyện-");
                string[] dsLoai = e.Result;
                for (int i = 0; i < dsLoai.Count(); i++)
                {
                    ds_Quan.Items.Add(dsLoai[i].ToString());
                }
                ds_Quan.SelectedIndex = 0;
                client.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi ! Không Thể Load Danh Sách Quận/Huyện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ds_TP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int tp = ds_TP.SelectedIndex;
            client = new ServiceReference1.Service1Client();
            client.LoadQuanCompleted += new EventHandler<ServiceReference1.LoadQuanCompletedEventArgs>(LoadQuanCallBack);
            client.LoadQuanAsync(tp);
        }
        public NHCF nh;
        private void lv_dsketqua_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            client = new ServiceReference1.Service1Client();
            try
            {
                nh = client.GetNHCF(int.Parse(lv_dsketqua.Items[e.ItemIndex].ToolTipText), dsnhahang);
                toolTip1.Show(nh.TenNhaHang + " " + nh.SoNha + " " + nh.Duong + ", Phường " + nh.Phuong + ", Quận " + nh.Quan + ", Tp." + nh.ThanhPho + "\nSố điện thoại : " + nh.DienThoai, lv_dsketqua, 2000);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Truy cập thông tin bị lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
