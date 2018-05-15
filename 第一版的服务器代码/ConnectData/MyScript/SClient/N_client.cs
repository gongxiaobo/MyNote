using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using LitJson;
//namespace ConnectData.MyScript
//{
    /// <summary>
    /// 客服端在服务器的实例
    /// 20170323：接收客服端的消息，处理消息，反馈消息，停用客服端
    /// </summary>
    class N_client : A_Client,I_sendBackClient
    {
        /// <summary>
        /// 客服端是否有生命
        /// </summary>
        protected bool m_clientIsAlive = false;
        /// <summary>
        /// 处理收到客服端的消息
        /// </summary>
        protected A_handleMsg m_handMsg;
        /// <summary>
        /// 初始化一个客服端对象
        /// </summary>
        /// <param name="_clientID"></param>
        /// <param name="_clientSocket"></param>
        public override void fn_init(string _clientID, Socket _clientSocket)
        {
            if (m_clientIsAlive)
            {//只能初始化一次
                return;
            }
            m_clientIsAlive = true;
            m_clientID = _clientID;
            m_clientSocket = _clientSocket;
            m_handMsg = new N_handleMsg01();
            m_handMsg.fn_init(this);
            Task t_toClient = new Task(fn_received, TaskCreationOptions.LongRunning);
            //t_toClient.CreationOptions = TaskCreationOptions.LongRunning;
            t_toClient.Start();
            Console.WriteLine("客服端：" + m_clientID + ",开始运行");

            //new Task(() => {
            //    Thread.Sleep(4000);
            //    fn_sendToClient("heart bag");
            //}).Start();
        }

        public override void fn_kill()
        {
            m_clientIsAlive = false;
            if (m_clientSocket!=null)
            {
                N_msg_serverClosed t_serverclosed = new N_msg_serverClosed(true);
                string t_json_closed = JsonMapper.ToJson(t_serverclosed);
                try
                {
                    m_clientSocket.Send(Encoding.UTF8.GetBytes(t_json_closed));
                }
                finally {
                    m_handMsg.fn_stop();
                    fnpp_clearSocket();
                }
              

               
            
            }
        }
        /// <summary>
        /// 客服端请求关闭通道
        /// </summary>
        public override void fn_killself()
        {
           
            m_clientIsAlive = false;
            m_handMsg.fn_stop();
            fnpp_clearSocket();

        }
        /// <summary>
        /// 关闭套接字
        /// </summary>
        private void fnpp_clearSocket() {
            if (m_clientSocket != null) {
                try
                {
                    m_clientSocket.Shutdown(SocketShutdown.Both);
                    m_clientSocket.Close();
                }
                finally {

                    m_clientSocket.Dispose();
                    m_clientSocket = null;
                }
              

            }
         
        }

        byte[] t_bytes =new byte[1024];
        /// <summary>
        /// 服务器正式接受客服端消息的地方
        /// 这里是一对一的接收消息出
        /// </summary>
        protected override void fn_received()
        {
            Console.WriteLine("服务器那端的虚拟客服端--》" + m_clientID);
            bool t_can = true;
            while (t_can)
            {
                try
                {
                    if (!m_clientSocket.Connected )
                    {
                        t_can = false;
                        m_clientIsAlive = false;
                        //fn_killself();
                        fnp_exit_acc();
                        return;
                    }
                    
                    int t_length = m_clientSocket.Receive(t_bytes);
                    if (t_length > 0)
                    {
                        string t_message = Encoding.UTF8.GetString(t_bytes, 0, t_length);
                        if (m_handMsg != null)
                            m_handMsg.fn_parse(t_message);
                    }
                    else {

                        t_can = false;
                        m_clientIsAlive = false;

                        fnp_exit_acc();

                        Console.WriteLine("收客服端数据时失败 为 0:");
                    
                    }
                }
                catch (Exception ex)
                {
                    t_can = false;
                    m_clientIsAlive = false;

                    fnp_exit_acc();
                  
                    Console.WriteLine("收客服端数据时失败:" );
                    //throw;
                }


               
                //Console.WriteLine("waiting:" + m_clientID);
                //Thread.Sleep(1000);
            }

            Console.WriteLine("客服端：" + m_clientID + ",接收线程关闭");
        }
        private static readonly object m_locksend = new object();
        /// <summary>
        /// 服务器发送会客服端消息的地方
        /// 这里可能同时多个线程处理，所有需要锁住
        /// </summary>
        /// <param name="_json"></param>
        public override void fn_sendToClient(string _json)
        {
            if (_json=="")
            {
                return;
            }
            lock (m_locksend)
            {
                string t_msg = _json;
                try
                {
                    if (m_clientSocket != null)
                    {
                        if (m_clientSocket.Connected)
                        {
                            m_clientSocket.Send(Encoding.UTF8.GetBytes(t_msg));
                        }
                    }
                }
                catch (Exception ex)
                {
                    m_clientIsAlive = false;

                    fnp_exit_acc();
                    //throw;
                }
               
            }
            
        }
        private static readonly object m_locksend01= new object();
        public void fn_sendback(string _jsonMsg){
            lock (m_locksend01)
            {
                fn_sendToClient(_jsonMsg);
            }
        
        }

        /// <summary>
        /// 用于意外退出情况使用,请求管理销毁此客户端
        /// </summary>
        protected void fnp_exit_acc() {

            new Task(() =>
            {
                //做些退出处理
                I_RemoveClient t_removeClient = S_ClientSocket.M_instance;
                if (t_removeClient != null)
                {
                    t_removeClient.fni_remove(m_clientID);
                }

            }).Start();
        }
    }
//}
