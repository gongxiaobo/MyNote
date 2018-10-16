using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理装表接电的门的初始化的状态值设置
     /// </summary>
     public class operate_door_01 : operate_door
     {
          public override void fn_setTo(float _angel)
          {
               base.fn_setTo(_angel);
               if (m_handleEvent == null)
               {
                    m_handleEvent = GetComponent<AB_HandleEvent>();
               }
               if (m_handleEvent == null)
               {
                    Debug.Log("<color=red>not find m_handleEvent!!</color>");
                    return;
               }

               if (m_lastTime <= m_closedoffset)
               {

                    if (m_flip == false)
                    {
                         fnp_setState("off");
                    }
                    else
                    {
                         fnp_setState();
                    }
                    Debug.Log("<color=blue>关闭阀门</color>");

               }
               if (m_max - m_lastTime <= m_openoffset)
               {
                    if (m_flip == false)
                    {
                         fnp_setState();
                    }
                    else
                    {
                         fnp_setState("off");
                    }
               }
          }
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);
               fn_setTo(0f);
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               
               fn_setTo(1f);
          }
     }
}
