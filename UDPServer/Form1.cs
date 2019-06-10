using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
//Download by http://www.codesc.net
namespace UDPServer
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        } 
        //��˿�
        bool done = false;
        private const int listenPort = 11000;
        private  void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            //����IP����˿�Ϊ0��ʾ����
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            try
            {
                while (!done)
                {
                    byte[] bytes = listener.Receive(ref groupEP);
                    string strIP;
                    strIP ="��Ϣ����"+ groupEP.Address.ToString();
                    string strInfo=Encoding.GetEncoding("gb2312").GetString(bytes, 0, bytes.Length);
                    MessageBox.Show(strInfo, strIP);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
        private void frmServer_Load(object sender, EventArgs e)
        {
            this.Hide();
            StartListener(); 
        }
    }
}
