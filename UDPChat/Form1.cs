using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
//download by http://www.codesc.net
namespace UDPChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Send();
        }

        public void Send()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
            //起到广播的作用在一个段内如192.168.1.255 都是1
            IPAddress broadcast = IPAddress.Parse(this.textBox2.Text.ToString());                                                                   
            //
            byte[] sendbuf = Encoding.GetEncoding("gb2312").GetBytes(this.textBox1.Text.ToString());
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);
            s.SendTo(sendbuf, ep);
            Console.WriteLine("Message sent to the broadcast address");
            Console.Read();
        }
    }
}