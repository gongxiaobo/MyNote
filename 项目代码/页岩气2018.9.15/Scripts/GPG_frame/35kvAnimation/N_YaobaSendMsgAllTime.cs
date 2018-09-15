using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把类型连续发送值给目标物体
     /// </summary>
     public class N_YaobaSendMsgAllTime : N_YaobaSendMsg
     {
          TimeCount1 m_timecall = null;
          public override void fn_StartCheck()
          {
               base.fn_StartCheck();
               m_timecall = m_timecall ?? new TimeCount1();
               m_timecall.SetCallSpace(0.1f, fnp_send);
          }
          protected override void fnp_update()
          {
               //base.fnp_update();
               if (m_timecall != null)
               {
                    m_timecall.CallTime(Time.deltaTime);
               }
          }
          protected void fnp_send()
          {

               //Debug.Log("<color=blue>send</color>");

               if (m_spanner != null)
               {
                    fnp_RotateRoAniTime();
               }
          }
          //float m_animation = 0f;
          private void fnp_RotateRoAniTime()
          {
               //m_animation += 0.05f;
               float t_Anitime = m_spanner.fni_getRotateValue() / m_spanner.fni_getLimit().y;
               //float t_Anitime = 0.8f;
               this.fnp_sendOn(t_Anitime.ToString());
          }
          public override void fn_endCheck()
          {
               //base.fn_endCheck();
               if (m_isChecking)
               {
                    S_update.Instance.fn_remove(fnp_update);
                    m_timecall.Reset();
                    //在结束操作后发送一个值
                    fnp_RotateRoAniTime();
                    m_spanner = null;
                    m_isChecking = false;
               }
          }
          protected void fnp_sendOn(string _value)
          {
               AB_NameFlag t_name = GetComponent<AB_NameFlag>();
               if (t_name != null)
               {
                    if (t_name.M_nameID <= 0)
                    {
                         return;
                    }
                    else
                    {
                         AB_Message t_g = new N_Message();
                         t_g.fn_init(
                              E_MessageType.e_outside,
                              new StateValue[1] { 
                                   new StateValueString(
                                        "floatvalue",
                                        _value) },
                              "set",
                              0,
                              t_name.M_nameID);
                         S_SceneMagT1.Instance.fn_ReceiveEvent(t_g);
                    }
               }
          }

     }

}