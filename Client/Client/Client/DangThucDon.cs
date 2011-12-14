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
    public partial class DangThucDon : Form
    {
        ServiceReference1.Service1Client client;
        public DangThucDon()
        {
            InitializeComponent();
        }

        private void DangThucDon_Load(object sender, EventArgs e)
        {
            lv_dsketqua.Items.Clear();
            client = new ServiceReference1.Service1Client();
            client.TimnguoidangCompleted += new EventHandler<ServiceReference1.TimnguoidangCompletedEventArgs>(TimnguoidangCallBack);
            client.TimnguoidangAsync(Form1.username);
        }
        public NHCF[] dsnhahang;
        void TimnguoidangCallBack(object sender, ServiceReference1.TimnguoidangCompletedEventArgs e)
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
                MessageBox.Show("Lỗi Dịch Vụ Không Thể Tìm Nhà Hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public NHCF nh;
        private void lv_dsketqua_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            client = new ServiceReference1.Service1Client();
            try
            {
                nh = client.GetNHCF(int.Parse(lv_dsketqua.Items[e.ItemIndex].ToolTipText), dsnhahang);
                lv_menu.Items.Clear();
                ThucDon[] menu = client.GetMenu(nh.Id);
                foreach (ThucDon td in menu)
                {
                    lv_menu.Items.Add("Tên Món Ăn: " + td.MonAn + " - Giá: " + td.Gia);
                }
                toolTip1.Show(nh.TenNhaHang + " " + nh.SoNha + " " + nh.Duong + ", Phường " + nh.Phuong + ", Quận " + nh.Quan + ", Tp." + nh.ThanhPho + "\nSố điện thoại : " + nh.DienThoai, lv_dsketqua, 2000);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Truy cập thông tin bị lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_dangbai_Click(object sender, EventArgs e)
        {
            if (tb_monan.Text!=""&&tb_gia.Text!="")
            {
                ThucDon thd = new ThucDon();
                thd.IdNhaHang = nh.Id;
                thd.MonAn = tb_monan.Text;
                thd.NguyenLieu = tb_nguyenlieu.Text;
                thd.PhuongPhap = tb_phuongphap.Text;
                thd.Gia = int.Parse(tb_gia.Text);
                try
                {
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    client.DangThucDonCompleted += new EventHandler<ServiceReference1.DangThucDonCompletedEventArgs>(DangThucDonCallBack);
                    client.DangThucDonAsync(thd);
                }
                catch
                {
                    MessageBox.Show("Lỗi Dịch Vụ !", "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập tên và giá của món ăn");
            }
        }
        void DangThucDonCallBack(object sender, ServiceReference1.DangThucDonCompletedEventArgs e)
        {
            MessageBox.Show(e.Result, "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            tb_gia.Text = "";
            tb_monan.Text = "";
            tb_nguyenlieu.Text = "";
            tb_phuongphap.Text = "";
        }

    }
}
