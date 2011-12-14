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
namespace Server
{
    public partial class Form1 : Form
    {
        bool serviceStarted = false;
        ServiceHost myServiceHost = null;
        ServiceMetadataBehavior behavior;
        public Form1()
        {
            InitializeComponent();
        }
        public Type checkcontract(ComboBox cbbContract)
        {
            Type contract;
            switch (cbbContract.SelectedIndex)
            {
                case 1:
                    {
                        contract = typeof(IService2);
                        break;
                    }
                default:
                    {
                        contract = typeof(IService1);
                        break;
                    }
            }
            return contract;
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            if (!serviceStarted)
            {
                groupBox1.Enabled = false;
                Uri baseAddress;
                txbMessageCarrent.Text = "Tạo kiểu kết nối ";
                try
                {
                    //Kết nối kiểu BasicHttpBinding
                    if (checkBox1.Checked == true)
                    {
                        baseAddress = new Uri("http://" + txbBaseAddress.Text + "/" + txbEndPointAdd1.Text);
                        myServiceHost = new ServiceHost(typeof(Service1), baseAddress);
                        myServiceHost.AddServiceEndpoint(checkcontract(cbContract1), new BasicHttpBinding(), baseAddress);

                        if (ckbShowMEX.Checked == true)
                        {
                            behavior = new ServiceMetadataBehavior();
                            behavior.HttpGetEnabled = true;
                            myServiceHost.Description.Behaviors.Add(behavior);
                            behavior.HttpGetUrl = baseAddress;
                            myServiceHost.AddServiceEndpoint(typeof(IMetadataExchange), new BasicHttpBinding(), "http://localhost:8000/BasicHttpBinding/mex");
                        }
                        myServiceHost.Open();
                        txbMessageCarrent.Text += " BasicHttpBinding";
                    }
                    //Kết nối kiểu WSHttpBinding
                    if (checkBox2.Checked == true)
                    {
                        baseAddress = new Uri("http://" + txbBaseAddress.Text + "/" + txbEndPointAdd2.Text);
                        myServiceHost = new ServiceHost(typeof(Service1), baseAddress);
                        myServiceHost.AddServiceEndpoint(checkcontract(cbContract2), new WSHttpBinding(), baseAddress);

                        if (ckbShowMEX.Checked == true)
                        {
                            behavior = new ServiceMetadataBehavior();
                            behavior.HttpGetEnabled = true;
                            myServiceHost.Description.Behaviors.Add(behavior);
                            behavior.HttpGetUrl = baseAddress;
                            myServiceHost.AddServiceEndpoint(typeof(IMetadataExchange), new WSHttpBinding(),"http://localhost:8000/WSHttpBinding/mex");
                        }
                        myServiceHost.Open();
                        txbMessageCarrent.Text += " WSHttpBinding";
                    }

                    //Kết nối kiểu NetTcpBinding
                    if (checkBox3.Checked == true)
                    {
                        baseAddress = new Uri("net.tcp://" + "localhost:2020" + "/" + txbEndPointAdd3.Text);
                        myServiceHost = new ServiceHost(typeof(Service1), baseAddress);
                        myServiceHost.AddServiceEndpoint(checkcontract(cbContract2), new NetTcpBinding(), baseAddress);
                        if (ckbShowMEX.Checked == true)
                        {
                            behavior = new ServiceMetadataBehavior();
                            myServiceHost.Description.Behaviors.Add(behavior);
                            myServiceHost.AddServiceEndpoint(typeof(IMetadataExchange), new NetTcpBinding(), "MEX3");
                        }
                        myServiceHost.Open();
                        txbMessageCarrent.Text += " NetTcpBinding";
                    }
                    txbMessageCarrent.Text += " thành công!";
                    serviceStarted = true;
                    btStop.Enabled = true;
                    btStart.Enabled = false;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myServiceHost.Close();
                    groupBox1.Enabled = true;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btStop_Click(object sender, EventArgs e)
        {
            myServiceHost.Close();
            serviceStarted = false;
            btStop.Enabled = false;
            btStart.Enabled = true;
            groupBox1.Enabled = true;
            txbMessageCarrent.Text = "Server đã dừng!";
        }
    }
}
