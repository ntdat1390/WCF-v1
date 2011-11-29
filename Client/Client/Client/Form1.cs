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
        IService1 Client = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds_KetNoi.SelectedIndex == 0)
                {
                    EndpointAddress address = new EndpointAddress(new Uri("http://localhost:8000/BasicHttpBinding"));
                    BasicHttpBinding binding = new BasicHttpBinding();
                    ChannelFactory<IService1> factory = new ChannelFactory<IService1>(binding, address);
                    Client = factory.CreateChannel();
                    string authors = Client.GetAuthors();
                    if (authors != null)
                    {
                        textBox1.Text = authors;
                    }
                }
                else if (ds_KetNoi.SelectedIndex == 1)
                {
                    EndpointAddress address = new EndpointAddress(new Uri("http://localhost:8000/WSHttpBinding"));
                    WSHttpBinding binding = new WSHttpBinding();
                    ChannelFactory<IService1> factory = new ChannelFactory<IService1>(binding, address);
                    Client = factory.CreateChannel();
                    string authors = Client.GetAuthors();
                    if (authors != null)
                    {
                        textBox1.Text = authors;
                    }
                }
                else if (ds_KetNoi.SelectedIndex == 2)
                {
                    EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:2020/NetTcpBinding"));
                    NetTcpBinding binding = new NetTcpBinding();
                    ChannelFactory<IService1> factory = new ChannelFactory<IService1>(binding, address);
                    Client = factory.CreateChannel();
                    string authors = Client.GetAuthors();
                    if (authors != null)
                    {
                        textBox1.Text = authors;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không kết nối được !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
            }
        }

        private void bt_Asynchronous_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client Basic = new ServiceReference1.Service1Client();
            Basic.GetAuthorsCompleted += new EventHandler<ServiceReference1.GetAuthorsCompletedEventArgs>(GetAuthors1);
            Basic.GetAuthorsAsync();
        }
        void GetAuthors1(Object sender, ServiceReference1.GetAuthorsCompletedEventArgs e)
        {
            try
            {
                textBox1.Text = e.Result;
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
