using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using Server;
namespace Client
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_DangKy_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy(this);
            dk.Show();
        }

        private void bt_DangNhap_Click(object sender, EventArgs e)
        {
            if (tb_User.Text.Count() != 0 && tb_Pass.Text.Count() != 0)
            {
                client.UserdangnhapCompleted += new EventHandler<ServiceReference1.UserdangnhapCompletedEventArgs>(UserdangnhapCallBack);
                client.UserdangnhapAsync(tb_User.Text, tb_Pass.Text);
            }
            else
                MessageBox.Show("Vui lòng điền thông tin đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static string username;
        void UserdangnhapCallBack(object sender, ServiceReference1.UserdangnhapCompletedEventArgs e)
        {
            try
            {
                if (e.Result == false)
                    MessageBox.Show("Đăng nhập thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    username = tb_User.Text;
                    DichVu dv = new DichVu();
                    dv.Show();
                    this.Hide();
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dịch vụ Lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
