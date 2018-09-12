using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// UI处理消息接口
     /// </summary>
     public interface I_handlemsg
     {
          void fni_receive(SMsg _reveive);
          void fni_send(SMsg _sendmsg);

     } 
}
