using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;


class testShutdownSocket
{
    private static Socket m_severSocket;
    //服务器ip地址
    private static IPAddress t_ip = IPAddress.Parse("10.15.19.84");
    //端口
    private static int m_myPort = 8885;

    /// <summary>
    /// 开启服务器
    /// </summary>
    public void fn_startServer()
    {
        try
        {
            if (m_severSocket!=null)
            {
                if (m_severSocket.Connected)
                {
                    return;
                }
                m_severSocket.Shutdown(SocketShutdown.Both);
                m_severSocket.Close();
                m_severSocket = null;
            }
            //套接字的设置
            m_severSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //套接字的绑定ip,port
            m_severSocket.Bind(new IPEndPoint(t_ip, m_myPort));
            //套接字开始监听
            m_severSocket.Listen(20);
            Console.WriteLine("测试服务器开始监听");
            //开线程监听客服端的请求

            Task m_listenClient = new Task(fn_listenClient, TaskCreationOptions.LongRunning);
            m_listenClient.Start();

        }
        catch (Exception _e)
        {
            Console.WriteLine(_e.ToString());
            if (m_severSocket!=null)
            {
                m_severSocket.Close();
            }

            throw;
        }


    }
    
    Task m_receivedTask;
    Task m_sendTask;
    /// <summary>
    /// 开始监听客服端链接
    /// </summary>
    private void fn_listenClient()
    {
        bool t_can = false;
        while (!t_can)
        {
            try
            {
                Socket t_client = m_severSocket.Accept();
                if (t_client!=null)
                {
                    //开启线程去接受这个客服端的消息数据
                    m_receivedTask=new Task(() => {
                        Console.WriteLine("链接成功");
                        fnpp_received(t_client);
                    });
                    m_receivedTask.Start();
                    //同时创建一个发送消息数据线程
                    m_sendTask = new Task(() =>
                    {
                        //Console.WriteLine("链接成功");
                        fn_send(t_client);
                    });
                    m_sendTask.Start();

                }
            }
            catch (Exception ex)
            {
                t_can = true;
                Console.WriteLine("创建和客服端连接的线程时出错");
            }
        }
    }

    /// <summary>
    /// 接收线程调用，接收客服端的消息数据
    /// </summary>
    /// <param name="_client"></param>
    private void fnpp_received(Socket _client) {
        if (_client!=null)
        {
            Socket t_client = _client;
            byte[] t_received = new byte[1024];
            int t_receivedCount;
            bool t_shutdown = false;
            while (!t_shutdown)
            {
                try
                {
                    t_receivedCount = t_client.Receive(t_received);
                    Console.WriteLine("收到的数据大小=" + t_receivedCount);

                    if (t_receivedCount > 0)
                    {
                        string t_getString = Encoding.UTF8.GetString(t_received);
                        Console.WriteLine("收到的数据是：" + t_getString);
                    }
                    else {//客服端关闭了 
                        Console.WriteLine("收到数据==0,关闭");
                        t_shutdown = true;
                        t_client.Shutdown(SocketShutdown.Both);
                        t_client.Close();
                        t_client.Dispose();
                        t_client = null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    t_shutdown = true;
                    t_client.Shutdown(SocketShutdown.Both);
                    t_client.Close();
                    t_client.Dispose();
                    t_client = null;

                  
                }

            }

          

        }

        //观察关闭后的状态
        new Task(() =>
        {
            Thread.Sleep(1000);
            fnpp_isClosed(_client);
        }).Start();
        Console.WriteLine("关闭接收线程");

    
    }
    /// <summary>
    /// 向客服端发送数据
    /// </summary>
    /// <param name="_client"></param>
    private void fn_send(Socket _client)
    {
        bool t_dowhile = true;
        while (t_dowhile)
        {
            Thread.Sleep(100);
            try
            {
                string t_str = "I am server...";

                    _client.Send(Encoding.UTF8.GetBytes(t_str));
             
            }
            catch (Exception ex)
            {//发送数据遇到问题
                t_dowhile = false;
                //Console.WriteLine("发送遇到问题1");
                if (_client!=null)
                {
                    if (_client.Connected)
                    {
                        //Console.WriteLine("发送遇到问题2");
                        _client.Shutdown(SocketShutdown.Both);
                        _client.Close();
                        _client.Dispose();
                        _client = null;
                    }
                }        
            }
        }

        //new Task(() =>
        //{
        //    Thread.Sleep(1000);
        //    fnpp_isClosed(_client);
        //}).Start();

    }

    private void fnpp_isClosed(Socket _client)
    {
        if (m_receivedTask != null)
        {

            Console.WriteLine("m_receivedTask state=" + m_receivedTask.Status);
            if (_client != null)
            {
                Console.WriteLine("_client state=" + _client.Connected);

            }
        }
        if (m_sendTask != null)
        {
            Console.WriteLine("m_sendTask state=" + m_sendTask.Status);
        }
        if (_client == null)
        {
            Console.WriteLine("_client = null");

        }


    }

}

