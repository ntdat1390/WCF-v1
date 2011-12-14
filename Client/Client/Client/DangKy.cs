using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class DangKy : Form
    {
        Form1 fr1;
        public DangKy(Form1 fr2)
        {
            InitializeComponent();
            fr1 = fr2;
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_dangky_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                client.UserdangkyCompleted += new EventHandler<ServiceReference1.UserdangkyCompletedEventArgs>(UserdangKyCallBack);
                client.UserdangkyAsync(tb_user.Text, tb_pass.Text, tb_email.Text, tb_hoten.Text, tb_diachi.Text, tb_sodt.Text,1);
            }
            catch
            {
                MessageBox.Show("Lỗi Dịch Vụ !", "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void UserdangKyCallBack(object sender, ServiceReference1.UserdangkyCompletedEventArgs e)
        {
            MessageBox.Show(e.Result, "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
