using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
//namespace ConnectData.MyScript
//{

/// <summary>
/// 客服端的抽象
/// </summary>
   abstract  class A_Client
    {
       /// <summary>
       /// 客服端的名称编号
       /// </summary>
       protected string m_clientID;
       protected Socket m_clientSocket;
       /// <summary>
       /// 初始化，初始化完成就创建任务和客户端通讯
       /// </summary>
       /// <param name="_clientID"></param>
       /// <param name="_clientSocket"></param>
       public abstract void fn_init(string _clientID, Socket _clientSocket);
       /// <summary>
       /// 销毁
       /// </summary>
       public abstract void fn_kill();
       /// <summary>
       /// 客服端请求销毁关闭通道
       /// </summary>
       public abstract void fn_killself();
       /// <summary>
       /// 用于和客服端通讯
       /// </summary>
       protected abstract void fn_received();
       /// <summary>
       /// 反馈给客服端的数据
       /// </summary>
       /// <param name="_json"></param>
       public abstract void fn_sendToClient(string _json);

    }
//}
