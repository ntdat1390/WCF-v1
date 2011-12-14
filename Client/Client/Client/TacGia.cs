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
    public partial class TacGia : Form
    {
        ServiceReference1.Service1Client client;
        public TacGia()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            lv_dsketqua.Items.Clear();
            textBox2.Text = "";
            client = new ServiceReference1.Service1Client();
            client.GetAuthorsCompleted += new EventHandler<ServiceReference1.GetAuthorsCompletedEventArgs>(GetAuthorsCallBack);
            client.GetAuthorsAsync();
        }
        void GetAuthorsCallBack(object sender, ServiceReference1.GetAuthorsCompletedEventArgs e)
        {
            try
            {
                string[] authors = e.Result;
                for (int i = 0; i < 3; i++)
                {
                    lv_dsketqua.Items.Add(authors[i].ToString());
                }
                textBox2.Text = authors[3].ToString();
                client.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi ! Không Thể Load Authors", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
