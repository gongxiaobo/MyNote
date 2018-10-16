using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// mvc模式下的接收消息和发送消息的接口
/// </summary>
public interface I_uiHandleMsg  {
     /// <summary>
     /// 发出的消息
     /// </summary>
     /// <param name="_sendout"></param>
     void fni_send(UIMsg _sendout);
     /// <summary>
     /// 收到的消息
     /// </summary>
     /// <param name="_get"></param>
     void fni_receive(UIMsg _get);
	
}
