using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using LitJson;

namespace ConnectData.MyScript
{
    class ClientTest
    {

        private static byte[] m_result = new byte[1024];

        Socket m_ClientSocket;



        public void fn_startClient() {
            IPAddress t_ip = IPAddress.Parse("10.15.19.84");
            m_ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Console.WriteLine("链接中...");
                m_ClientSocket.Connect(new IPEndPoint(t_ip, 8885));
                //创建接收线程
                Task t_handle = new Task(() => {

                    if (m_ClientSocket.IsBound)
                    {
                        fnp_received(m_ClientSocket);
                    }
                    else {
                        Task t_connect = new Task(fnpp_connectAgain);
                        t_connect.Wait(1000);
                        t_connect.Start();
                    }
                 
                });
                t_handle.Start();

                Console.WriteLine("链接成功");
            }
            catch (Exception _e)
            {
                Task t_connect = new Task(fnpp_connectAgain);
                t_connect.Wait(1000);
                t_connect.Start();
                Console.WriteLine(_e.Message);
                return;
            }
            finally {
                
              
            }

            for (int i = 0; i < 10; i++)
            {

                        try
                        {
                            Thread.Sleep(1000);
                            //string t_sendmsg = "to server " + DateTime.Now;
                            string t_sendmsg ;
                            MyJsonData t_data = new MyJsonData(" xxx- ", i);
                            t_sendmsg = JsonMapper.ToJson(t_data);

                            m_ClientSocket.Send(Encoding.ASCII.GetBytes(t_sendmsg));
                            Console.WriteLine("发给服务器：" + t_data.m_name);
                        }
                        catch (Exception _e) {
                            Console.WriteLine(_e.Message);
                        }
            
            }
            
            
        
        }

        private short m_short = 0;
        //如果没有连上，重新连接
        private void fnpp_connectAgain() {
            m_short++;
            if (m_short>10)
            {
                Console.WriteLine("实在链接不成功，我看还是算了吧");
            }
            fn_startClient();
        }


        //接收到的字符数组
        private byte[] m_received = new byte[1024];
        //字符串
        private string m_receivedString = "";
        protected void fnp_received(Socket _sk ) {

            while (true)
            {
                int t_bytes = m_ClientSocket.Receive(m_received, m_received.Length, 0);
                m_receivedString = Encoding.UTF8.GetString(m_received, 0, t_bytes);

                Console.WriteLine("收到服务器：" + m_receivedString);

            }
           

        
        }

    }
}
