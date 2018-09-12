using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace TcpMsg
{
     public abstract class AB_tcpMsgPool
     {
          /// <summary>
          /// 有效消息入池
          /// </summary>
          /// <param name="_msg"></param>
          public abstract void fn_msgInPool(byte[] _msg);

          /// <summary>
          /// 消息拆分，输出到指定类中
          /// </summary>
          /// <param name="_callback"></param>
          public abstract void fn_setCallBack(Action<string> _callback);
     } 
}
