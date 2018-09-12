using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 一个按钮改变状态后需要触发的消息链
     /// </summary>
     public class N_ResultAction : AB_ResultAction
     {
          [SerializeField]
          protected List<ResultDate> m_ResultDate = new List<ResultDate>();
          public override List<AB_Message> fn_getReultMsg(string _name)
          {
               if (m_ResultDate.Count == 0)
               {
                    return null;
               }
               List<AB_Message> t_msg = new List<AB_Message>();
               for (int i = 0; i < m_ResultDate.Count; i++)
               {
                    if (m_ResultDate[i].m_ResultName == _name)
                    {
                         for (int j = 0; j < m_ResultDate[i].m_result.Count; j++)
                         {
                              ItemStateResult t_r = m_ResultDate[i].m_result[j];
                              if (t_r.m_Toid == 0)
                              {//在目标id==0,表示放弃发送
                                   continue;
                              }
                              AB_Message t_g = new N_Message();
                              t_g.fn_init(
                                   t_r.m_msgType,
                                   new StateValue[1] { 
                                   new StateValueString(
                                        S_initDate.fns_getStateValueName(t_r.m_type),
                                        t_r.m_state) },
                                   "set",
                                   m_ID,
                                   t_r.m_Toid);
                              t_msg.Add(t_g);
                         }
                    }
               }
               return t_msg;
          }
          public override void fn_SendResultMsg(string _name, AB_HandleEvent _mac)
          {
               if (_mac == null)
               {
                    return;
               }
               if (m_ResultDate.Count == 0)
               {
                    return;
               }
               for (int i = 0; i < m_ResultDate.Count; i++)
               {
                    if (m_ResultDate[i].m_ResultName == _name)
                    {
                         for (int j = 0; j < m_ResultDate[i].m_result.Count; j++)
                         {
                              ItemStateResult t_r = m_ResultDate[i].m_result[j];
                              if (t_r.m_Toid == 0)
                              {//在目标id==0,表示放弃发送
                                   continue;
                              }
                              AB_Message t_g = new N_Message();
                              t_g.fn_init(
                                   t_r.m_msgType,
                                   new StateValue[1] { 
                                   new StateValueString(
                                        S_initDate.fns_getStateValueName(t_r.m_type),
                                        t_r.m_state) },
                                   "set",
                                   m_ID,
                                   t_r.m_Toid);
                              _mac.fn_SendMsg(t_g);

                              //Debug.Log("<color=red>result id :</color>" + t_r.m_Toid);

                         }
                    }
               }

          }
     }

}