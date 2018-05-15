using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections.Concurrent;
using LitJson;

using System.Threading;

//namespace ConnectData.MyScript
//{
/// <summary>
/// 一个用于保存客服端的套接字的单例
/// 20170323：加入了保存套接字，保存客服端对象，初始化客服端开始和服务器通信
/// 20170330:使用共享单例基类的方式实现单例
/// </summary>
class S_ClientSocket : Singleton<S_ClientSocket>, I_RemoveClient
    {
        //private static S_ClientSocket m_instance;
        //private static readonly object m_locker = new object();
        private static readonly object m_locker01 = new object();
        //public static S_ClientSocket M_instance { get {

        //    if (m_instance==null)
        //    {
        //        lock (m_locker)
        //        {
        //            if (m_instance==null)
        //            {
        //                m_instance = new S_ClientSocket();
        //            }
        //        }
        //    }
        //    return m_instance;
        //} }
        /// <summary>
        /// 所有链接客服端的名称和套接字集合
        /// </summary>
        private ConcurrentDictionary<string, Socket> m_clientSocket = new ConcurrentDictionary<string, Socket>();
        /// <summary>
        /// 所有客服端对象集合
        /// </summary>
        private ConcurrentDictionary<string, A_Client> m_clientObj = new ConcurrentDictionary<string, A_Client>();

        /// <summary>
        /// 为客服端编号
        /// </summary>
        static int m_clientIndex = 0;
        /// <summary>
        /// 加入套接字,初始化客服端对象
        /// 有可能多线程访问，加锁处理
        /// </summary>
        /// <param name="_clientSocket"></param>
        public void fn_addSokect(Socket _clientSocket) {
            lock (m_locker01)
            {
                Socket t_temp = _clientSocket;
                if (t_temp != null)
                {
                    m_clientIndex++;
                    //m_listSocket.Add(_clientSocket);         
                    //给客服端编号
                    string t_clientname=m_clientIndex.ToString();
                    //加入集合
                    m_clientSocket.TryAdd(t_clientname, t_temp);
                    Console.WriteLine("加入客服端：" + m_clientIndex);

                 
                    //新建客服端对象
                    A_Client t_client = new N_client();
                    t_client.fn_init(t_clientname, t_temp);
                    m_clientObj.TryAdd(t_clientname, t_client);

                    //需要给刚连接的客服端发送编号
                    N_msg_clientName t_toclient = new N_msg_clientName(t_clientname);
                    string t_json = JsonMapper.ToJson(t_toclient);
                    t_temp.Send(Encoding.UTF8.GetBytes(t_json));
                    t_toclient = null;

                    Console.WriteLine("有新的客服端加入后，客服端的数量=" + m_clientSocket.Count);
                    //开启一个线程去查看每一个客服端的心跳
                    if (m_clientSocket.Count == 1 &&  m_heartBagRunning==false)
                    {
                        new Task(() => { fnpp_heartBag(); }).Start();
                    }
                   


                }
            }
           
         
        
        }
    
        public ICollection<Socket> fn_getSockets() {

            return m_clientSocket.Values;
        }


        public void fn_clear() {
            m_clientSocket.Clear();
        }

        /// <summary>
        /// 服务器器关闭调用,销毁所有资源
        /// </summary>
        public void fn_closeServer() {
            //第一步销毁客户端对象，通知每一个客服端，服务器关闭
            foreach (var item in m_clientObj.Values)
            {
                item.fn_kill();
            }
            //清理对象集合
            m_clientObj.Clear();
            //然后删除集合
            m_clientSocket.Clear();
        
        }
        /// <summary>
        /// 根据编号，获取客服端的套接字
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public Socket fn_getClient(string _name) {
            if (m_clientSocket.ContainsKey(_name))
            {
                if (m_clientSocket[_name]!=null)
                {
                    return m_clientSocket[_name];
                }
            }
            return null;
        }

        private static readonly object m_locker_remove=new object();
        /// <summary>
        /// 删除指定的客服端对象
        /// </summary>
        /// <param name="_clientID"></param>
        public  void fni_remove(string _clientID){
            lock (m_locker_remove)
	        {
                string t_client=_clientID;
                if(m_clientObj.ContainsKey(t_client)){
                    m_clientObj[t_client].fn_killself();
                }else{
                    return;
                }
                  A_Client t_client01=null;
                m_clientObj.TryRemove(t_client , out t_client01);
                t_client01=null;

                Socket t_temp=null;
                m_clientSocket.TryRemove(t_client,out t_temp);
                if(t_temp!=null){
                    t_temp=null;
                }
                Console.WriteLine("有客户端移除，客服端的名称=" + t_client);
                Console.WriteLine("有客户端移除，客服端的数量=" + m_clientSocket.Count);


	        }

        }
        //是否已经开启心跳包：true 为已经开启
        private bool m_heartBagRunning = false;
        /// <summary>
        /// 简单心跳包的发送
        /// </summary>
        private void fnpp_heartBag() {
            m_heartBagRunning = true;
            int t_client = m_clientSocket.Count;
            int t_time = 1500;
            while (t_client>0)
            {
                if (m_clientSocket != null)
                {//根据连接数来发送心跳包的频率
                    t_client = m_clientSocket.Count;
                    int t_t = 20 * t_client;
                    if (t_t > t_time)
                    {
                        t_time = t_t;
                    }
                    if (t_time > 5000)
                    {
                        t_time = 5000;
                    }
                }
                else {
                    break;
                }

                Thread.Sleep(t_time);
                //Console.WriteLine("heart bag");
                string heartbag = "is alive?";
                //

                //if (m_clientSocket != null)
                //{
                //    t_client = m_clientSocket.Count;
                //}
                foreach (var item in m_clientSocket.Values)
                {
                    if (item != null)
                    {
                        if (item.Connected)
                        {
                            item.Send(Encoding.UTF8.GetBytes(heartbag));
                        }
                   
                    }

                }
               
        
            }
            m_heartBagRunning = false;
          
        }
    }
//}
