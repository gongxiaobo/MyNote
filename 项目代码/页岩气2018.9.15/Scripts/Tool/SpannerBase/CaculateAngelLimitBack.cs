using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 扳手被旋转后规定的时间后回到起点，并在旋转超过一定值后发出通知 。
     /// 
     /// </summary>
     public class CaculateAngelLimitBack : CaculateAngelLimit_Logic
     {
          protected override void Start()
          {
               base.Start();
               if (m_TimeBack >= 0f)
               {
                    m_TimeBack = m_TimeBack > 5f ? 5f : m_TimeBack;
               }
               else
               {
                    m_TimeBack = 2f;
               }
          }
          public override void fn_startControl(Transform _hand)
          {
               if (m_callOnce == false)
               {
                    base.fn_startControl(_hand);
               }
          }
          /// <summary>
          /// 超过的旋转角度值
          /// </summary>
          public float m_MoreThan = -45f;
          /// <summary>
          /// 回到开始位置的时间
          /// </summary>
          public float m_TimeBack = 2f;
          protected override void fnp_handleRotate()
          {
               base.fnp_handleRotate();
               if (m_callOnce == false)
               {
                    if (m_MoreThan < 0f)
                    {
                         if (AllRotate <= m_MoreThan)
                         {
                              fnMoreThan();

                              Debug.Log("<color=red>m_MoreThan:</color>" + m_MoreThan);

                         }
                    }
                    else
                    {
                         if (AllRotate >= m_MoreThan)
                         {
                              fnMoreThan();
                              Debug.Log("<color=red>m_MoreThan1:</color>" + m_MoreThan);
                         }
                    }
               }
          }
          public override void fn_endControl()
          {
               base.fn_endControl();
               if (m_callOnce == false)
               {
                    fn_setTo(0f);
               }

          }
          /// <summary>
          /// 回到开始点位置
          /// </summary>
          protected virtual void fnp_back()
          {
               fn_setTo(0f);
               m_callOnce = false;
               //声音播放
               fnp_onoffSound("btn_down");
          }
          bool m_callOnce = false;
          protected virtual void fnMoreThan()
          {
               m_callOnce = true;
               //Debug.Log("<color=red>超过：</color>" + m_MoreThan + "|" + AllRotate);
               fn_endControl();
               Invoke("fnp_back", m_TimeBack);
               fnp_onoffSound("btn_down");
          }

     }

}