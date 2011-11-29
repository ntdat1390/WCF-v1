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
using WcfServiceLibrary1;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool serviceStarted = false;
        ServiceHost myServiceHost = null;
        public Form1()
        {
            InitializeComponent();
        }
        public  Type checkcontract(ComboBox cbbContract)
        {
            Type contract;
            switch(cbbContract.SelectedIndex)
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
        protected void AddMexEndpoint(ServiceHost myHost)
        {

            ServiceMetadataBehavior smb = myHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            // If not, add one
            if (smb == null)

                smb = new ServiceMetadataBehavior();

            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            myHost.Description.Behaviors.Add(smb);
            // Add MEX endpoint
            myHost.AddServiceEndpoint(

            ServiceMetadataBehavior.MexContractName,
            MetadataExchangeBindings.CreateMexHttpBinding(),
            "mex"

            );


        }
        public void check(ComboBox cbBindding, ComboBox cbContract, string hostAddress, string endpointaddress)
        {
            switch (cbBindding.SelectedIndex)
                    {
                        case 0:
                            {
                                BasicHttpBinding binding = new BasicHttpBinding();
                                endpointaddress = "http://" + hostAddress + "/" + endpointaddress;
                                Uri endpAddress = new Uri(endpointaddress);
                                myServiceHost.AddServiceEndpoint(checkcontract(cbContract), binding, endpAddress);
                                break;
                            }
                        case 1:
                            {
                                NetMsmqBinding binding = new NetMsmqBinding();
                                endpointaddress = "net.msmq://" + hostAddress + "/" + endpointaddress;
                                Uri endpAddress = new Uri(endpointaddress);
                                myServiceHost.AddServiceEndpoint(checkcontract(cbContract), binding, endpAddress);
                                break;
                            }
                        case 2:
                            {
                                NetNamedPipeBinding binding = new NetNamedPipeBinding();
                                endpointaddress = "net.pipe://" + hostAddress + "/" + endpointaddress;
                                Uri endpAddress = new Uri(endpointaddress);
                                myServiceHost.AddServiceEndpoint(checkcontract(cbContract), binding, endpAddress);
                                break;
                            }
                        case 3:
                            {
                                NetTcpBinding binding = new NetTcpBinding();
                                endpointaddress = "net.tcp://" + hostAddress + "/" + endpointaddress;
                                Uri endpAddress = new Uri(endpointaddress);
                                myServiceHost.AddServiceEndpoint(checkcontract(cbContract), binding, endpAddress);
                                break;
                            }
                        case 4:
                            {
                                WSHttpBinding binding = new WSHttpBinding();
                                endpointaddress = "http://" + hostAddress + "/" + endpointaddress;
                                Uri endpAddress = new Uri(endpointaddress);
                                myServiceHost.AddServiceEndpoint(checkcontract(cbContract), binding, endpAddress);
                                break;
                            }
                    }
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serviceStarted)
                {
                    Uri baseAddress = new Uri(txbBaseAddress.Text.ToString());
                    myServiceHost = new ServiceHost(typeof(Service1), baseAddress);
                    if (checkBox1.Checked == true) check(cbBindding1, cbContract1, txbBaseAddress.Text.ToString(), txbEndPointAdd1.Text.ToString());
                    if (checkBox2.Checked == true) check(cbBindding2, cbContract2, txbBaseAddress.Text.ToString(), txbEndPointAdd2.Text.ToString());
                    if (checkBox3.Checked == true) check(cbBindding3, cbContract3, txbBaseAddress.Text.ToString(), txbEndPointAdd3.Text.ToString());
                    if (ckbShowMEX.Checked == true) AddMexEndpoint(myServiceHost);
                    myServiceHost.Open();
                    serviceStarted = true;
                    txbMessageCarrent.Text = "Service Connected";
                }
            }
            catch
            {
                txbMessageCarrent.Text = "Lỗi! không thể start service";
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            if (serviceStarted)
            {
                myServiceHost.Close();
                serviceStarted = false;
                txbMessageCarrent.Text = "Service Disconnected";
            }
        }

        private void lbBaseAddress_Click(object sender, EventArgs e)
        {

        }

        private void ckbShowMEX_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txbBaseAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbMessageCarrent_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
