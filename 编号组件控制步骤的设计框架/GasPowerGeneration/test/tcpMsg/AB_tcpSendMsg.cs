using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace TcpMsg
{
     /// <summary>
     /// packaging the send msg
     /// </summary>
     public abstract class AB_tcpSendMsg
     {
          /// <summary>
          /// packaging original msg
          /// </summary>
          /// <param name="_originalMsg">json string</param>
          public abstract void fn_Packing(string _originalMsg);
          /// <summary>
          /// set callback func
          /// </summary>
          /// <param name="_sendMsg">callback func</param>
          public abstract void fn_setOut(Action<byte[]> _sendMsg);



     } 
}
