using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 发送消息
     /// </summary>
     public abstract class AB_SendMsg
     {
          /// <summary>
          /// 组合消息，发送消息
          /// </summary>
          /// <param name="_type">消息类型</param>
          /// <param name="_fromid">从哪个item发出消息</param>
          /// <param name="_toID">发送给哪个item</param>
          /// <param name="_sender">发送消息的管理器</param>
          public abstract void fn_sendmsg(E_MessageType _type, E_valueType _valueType, int _fromid, int _toID, string _value, AB_HandleEvent _sender);

     } 
}
