using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

using LitJson;

//namespace ConnectData.MyScript
//{
    /// <summary>
    /// 开启服务器
    /// </summary>
    class ServerTest
    {
        ////用来装载收到的消息
        //private static byte[] m_result = new byte[1024];
      /// <summary>
        ///   //监听套接字,用于服务器监听客服端的套接字
      /// </summary>
        private static Socket m_severSocket;
        //服务器ip地址
        private static IPAddress t_ip = IPAddress.Parse("10.15.19.84");
        //端口
        private static int m_myPort = 8885;


        /// <summary>
        /// 开启服务器
        /// </summary>
        public void fn_startServer() {
            try
            {
                //套接字的设置
                m_severSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //套接字的绑定ip,port
                m_severSocket.Bind(new IPEndPoint(t_ip, m_myPort));
                //套接字开始监听
                m_severSocket.Listen(50);
                Console.WriteLine("服务器开始监听");
                //开线程监听客服端的请求
                Task t_listenClient = new Task(fn_listenClient,TaskCreationOptions.LongRunning);
                t_listenClient.Start();

              

            }
            catch (Exception _e)
            {
                Console.WriteLine(_e.ToString());
                m_severSocket.Close();
                m_severSocket = null;
                throw;
            }
           
        
        }
        
        private bool m_stopServer = false;
        /// <summary>
        /// 关闭服务器
        /// </summary>
        public void fn_closeServer() {

            m_stopServer = true;

            //释放对数据库的引用
            S_ClientSocket.M_instance.fn_closeServer();
      
             new Task(() =>
            {

                if (m_severSocket != null)
                {
                    Thread.Sleep(2000);
                    m_severSocket.Shutdown(SocketShutdown.Both);
                    m_severSocket.Close();
                    m_severSocket.Dispose();
                    //m_severSocket = null;
                }
            }).Start();
    
        }

        /// <summary>
        /// 监听客服端的链接,服务器一直开启，
        /// </summary>
        private void fn_listenClient() {
            bool t_can = false;
            while (t_can == false)
            {
                 //有请求就创建一个线程去接收和传递数据
                try
                {
                    //
                    if (m_severSocket != null)
                    {
                        Socket t_client ;

                            t_client = m_severSocket.Accept();
                            if (t_client!=null)
                            {
                                Task t_received_task = new Task(() =>
                                {
                                    if (m_stopServer == false)
                                    {
                                        fn_receivedMsg(t_client);
                                    }
                                });
                                t_received_task.Start();
                            }
                        

                       
                    }
                    else {
                        Console.WriteLine("监听失败，需要重新开启监听");
                        t_can = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    t_can = true;
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        /// <summary>
        /// 接收消息处理,这里只是识别是否是正确的客服端使用
        /// 如果符合要求，建立连接
        /// </summary>
        /// <param name="传入收到的套接字"></param>
        private void fn_receivedMsg(Socket _clientSocket)
        {
            if(m_stopServer==true){
                Console.WriteLine("服务器已经停止");
                return;
            }
            Socket t_clientSoket = _clientSocket ;
            if (t_clientSoket==null)
            {
                return;
            }

            bool t_waitClientID=true;
            byte[] t_result = new byte[1024];
            while (t_waitClientID)
            {
                
                                    try {

                                                //把收到的byte数组转成字符串
                                            int t_receivedNumber = t_clientSoket.Receive(t_result);
                                            string t_message = Encoding.UTF8.GetString(t_result, 0, t_receivedNumber);
                                                //把字符串转成想要的对象
                                                A_baseMsg t_basemsg = JsonMapper.ToObject<A_baseMsg>(t_message);
                                                if (t_basemsg != null)
                                                {
                                                    if (t_basemsg.m_msgName == "N_msg_helloToServer")
                                                    {
                                                        N_msg_helloToServer t_user = JsonMapper.ToObject<N_msg_helloToServer>(t_message);
                                                        if (t_user.m_key == "hello,server,xreal,XREAL,0322")
                                                        {//链接服务器成功
                                                            t_waitClientID = false;//结束循环
                                                            //加入到客服端集合中
                                                            S_ClientSocket.M_instance.fn_addSokect(t_clientSoket);
                                                            //加入成功，反馈给客服端已经链接成功
                                                            N_msg_helloToServer_back t_back = new N_msg_helloToServer_back(true);
                                                            string t_jsonback = JsonMapper.ToJson(t_back);
                                                            t_clientSoket.Send(Encoding.UTF8.GetBytes(t_jsonback));

                                                        }
                                                        else
                                                        {
                                                            N_msg_helloToServer_back t_back = new N_msg_helloToServer_back(false);
                                                            string t_jsonback = JsonMapper.ToJson(t_back);
                                                            t_clientSoket.Send(Encoding.UTF8.GetBytes(t_jsonback));

                                                            t_waitClientID = false;//结束循环
                                                            t_clientSoket.Close();
                                                            t_clientSoket.Dispose();
                                                        }
                                                    }
                                                }
                                                else {
                                                    Console.WriteLine("传入对象不能转换成正确的消息类");
                                                    t_waitClientID = false;//结束循环
                                                }
                      
                                        }
                                        catch(Exception _e) {
                                            t_waitClientID = false;
                                                //Console.WriteLine(_e.Message);
                                                t_clientSoket.Close();
                                                t_clientSoket.Dispose();
                                                //throw;
                                        }
                                
            
            }

            //Console.WriteLine("--》");
            //Console.ReadKey();
        
        
        }

    }
//}
