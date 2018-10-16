using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// ui的消息接收器
     /// </summary>
     public class N_UILevel01 : AB_UILevel01
     {
          public override void fni_receive(SMsg _reveive)
          {
               //base.fni_receive(_reveive);
               if (_reveive.m_ID==m_UIID)
               {//当消息是自己发出，不处理
                    return;
               }

          }
          public override void fn_buttonHit()
          {
               base.fn_buttonHit();
               //按钮按下发送消息处理
               fni_send(new SMsg { m_ID = m_UIID, m_additional = "" });
          }

     } 
}
