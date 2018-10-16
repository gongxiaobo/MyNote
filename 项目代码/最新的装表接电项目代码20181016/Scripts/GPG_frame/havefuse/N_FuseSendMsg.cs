using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 熔断器的消息发送
     /// 主要是熔断器放入和拿出的是否消息的发送
     /// </summary>
     public class N_FuseSendMsg : AB_CheckSendMsg
     {

          public override void fn_StartCheck()
          {
               throw new System.NotImplementedException();
          }

          public override void fn_endCheck()
          {
               throw new System.NotImplementedException();
          }

          protected override bool fnp_Check()
          {
               throw new System.NotImplementedException();
          }

          protected override void fnp_SendMsg()
          {
               throw new System.NotImplementedException();
          }
     } 
}
