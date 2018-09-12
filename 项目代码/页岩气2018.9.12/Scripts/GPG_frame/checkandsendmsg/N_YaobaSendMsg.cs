using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把的检查类型，当摇把摇入到最大值后，发送消息给当前机器
     /// </summary>
     public class N_YaobaSendMsg : AB_CheckSendMsg
     {
          protected AB_Spanner m_spanner;
          protected bool m_isChecking = false;
          public override void fn_StartCheck()
          {
               if (m_isChecking == false)
               {
                    m_isChecking = true;
                    fnp_find();
                    S_update.Instance.M_update = fnp_update;

               }
          }
          protected void fnp_find()
          {
               m_spanner = GetComponent<AB_Spanner>();
               if (m_spanner == null)
               {
                    m_spanner = GetComponentInChildren<AB_Spanner>();
               }
               if (m_spanner == null)
               {
                    fn_endCheck();
               }
          }
          public override void fn_endCheck()
          {
               if (m_isChecking)
               {
                    S_update.Instance.fn_remove(fnp_update);
                    m_spanner = null;
                    m_isChecking = false;
               }
          }
          protected override bool fnp_Check()
          {
               if (m_spanner != null)
               {
                    return m_spanner.fni_valueToBig();
               }
               else
               {

                    return true;
               }
          }

          protected override void fnp_SendMsg()
          {
               //msg
               fnp_sendOn("on");
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
                                        "onoff",
                                        _value) },
                              "set",
                              0,
                              t_name.M_nameID);
                         S_SceneMagT1.Instance.fn_ReceiveEvent(t_g);
                    }
               }
          }
          protected virtual void fnp_update()
          {
               if (fnp_Check())
               {//pass
                    fnp_SendMsg();
                    fn_endCheck();
               }

               //Debug.Log("<color=blue>bluex:</color>");

          }
     }

}