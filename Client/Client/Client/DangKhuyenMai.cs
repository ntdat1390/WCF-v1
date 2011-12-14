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
    public partial class DangKhuyenMai : Form
    {
        ServiceReference1.Service1Client client;
        public DangKhuyenMai()
        {
            InitializeComponent();
        }

        private void DangKhuyenMai_Load(object sender, EventArgs e)
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
                toolTip1.Show(nh.TenNhaHang + " " + nh.SoNha + " " + nh.Duong + ", Phường " + nh.Phuong + ", Quận " + nh.Quan + ", Tp." + nh.ThanhPho + "\nSố điện thoại : " + nh.DienThoai, lv_dsketqua, 2000);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Truy cập thông tin bị lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_dangbai_Click(object sender, EventArgs e)
        {
            if (tb_tenkhuyenmai.Text!=""&&tb_thoigianend.Text!=""&&tb_thoigianstart.Text!=""&&tb_thongtin.Text!="")
            {
                KhuyenMai khm = new KhuyenMai();
                khm.IdNhaHang = nh.Id;
                khm.TenKhuyenMai = tb_tenkhuyenmai.Text;
                khm.ThoiGianStart = tb_thoigianstart.Text;
                khm.ThoiGianEnd = tb_thoigianend.Text;
                khm.ThongTin = tb_thongtin.Text;
                try
                {
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    client.DangKhuyenMaiCompleted += new EventHandler<ServiceReference1.DangKhuyenMaiCompletedEventArgs>(DangKhuyenMaiCallBack);
                    client.DangKhuyenMaiAsync(khm);
                }
                catch
                {
                    MessageBox.Show("Lỗi Dịch Vụ !", "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập tên, thời gian bắt đầu, thời gian kết thúc, thông tin của đợt khuyến mãi");
            }
        }
        void DangKhuyenMaiCallBack(object sender, ServiceReference1.DangKhuyenMaiCompletedEventArgs e)
        {
            MessageBox.Show(e.Result, "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            tb_tenkhuyenmai.Text = "";
            tb_thoigianend.Text = "";
            tb_thoigianstart.Text = "";
            tb_thongtin.Text = "";
        }
    }
}
