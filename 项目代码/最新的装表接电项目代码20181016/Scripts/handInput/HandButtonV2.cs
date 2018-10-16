using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 对手柄加入了事件控制手柄扳机键的按下和松开
     /// </summary>
     public class HandButtonV2 : HandButtonV1
     {
          protected override void Start()
          {
               base.Start();
               //全局事件，在需要被动调用扳机键弹起时，会被任何位置调用
               GlobalEventSystem<GE_HandTriggerUp>.eventHappened += fn_GE_TriggerUp;
               GlobalEventSystem<GE_HandTriggerDown>.eventHappened += fn_GE_HandTriggerDown;
          }
          protected override void fnp_triggerDown()
          {
               if (m_isTriggerDown)
               {
                    return;
               }
               
               m_isTriggerDown = true;
               base.fnp_triggerDown();
          }
          protected override void fnp_triggerUp()
          {
               if (m_isTriggerDown==false)
               {
                    return;
               }
               base.fnp_triggerUp();
              
          }

     } 
}
