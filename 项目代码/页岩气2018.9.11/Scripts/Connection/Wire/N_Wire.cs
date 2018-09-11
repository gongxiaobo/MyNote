using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_Wire : AB_Wire
     {
          public override void fn_init(string _para)
          {
               m_WirePara = _para;
               m_isConnect = true;
          }

          public override void fn_show()
          {
               
          }

          public override void fn_hide()
          {
          }

          public override void fn_init(string _para, AB_HandleEvent[] _ports)
          {
               m_WirePara = _para;
               m_ports = _ports;
               m_isConnect = true;
          }
          /// <summary>
          /// 设置电线连接端口的链接状态信息为空
          /// </summary>
          protected virtual void fnp_changePortState()
          {
               if (m_isConnect)
               {
                    AB_SetState t_setState = new N_SetState();
                    if (m_ports != null)
                    {
                         for (int i = 0; i < m_ports.Length; i++)
                         {
                              t_setState.fn_setState("string", "", m_ports[i]);
                         }
                    }
                    t_setState = null;
               }
          }
          /// <summary>
          /// 卸线的时候使用，
          /// 检查一个接口是否已经链接两根线，删除一根线的状态值
          /// </summary>
          protected virtual void fnp_changePortState1()
          {
               if (m_isConnect==false)
               {
                    return;
               }
               AB_SetState t_setState = new N_SetState();
               if (m_ports != null)
               {
                    for (int i = 0; i < m_ports.Length; i++)
                    {//接口的状态值更新
                         string[] t_split=S_ParseWirePara.fn_SplitToTwo(m_ports[i].fn_getMainValue());
                         if (t_split[0] != "" && t_split[1] != "")
                         {//两根线情况
                              if (t_split[0]==m_WirePara)
                              {
                                   t_setState.fn_setState("string", t_split[1], m_ports[i]);
                              }
                              else if (t_split[1] == m_WirePara)
                              {
                                   t_setState.fn_setState("string", t_split[0], m_ports[i]);
                              }
                         }
                         else if (t_split[0] != "" && t_split[1] == "")
                         {//一根线的情况
                              if (t_split[0] == m_WirePara)
                              {
                                   t_setState.fn_setState("string", "", m_ports[i]);
                              }
                         }
                         else
                         {//没有线的情况
                              t_setState.fn_setState("string", "", m_ports[i]);
                         }
                         //t_setState.fn_setState("string", "", m_ports[i]);
                    }
               }
               t_setState = null;
          }
          public override void fn_clear()
          {
               //fnp_changePortState();
               fnp_changePortState1();
               if (m_WirePara!="")
               {
                    m_WirePara = "";
               }
               if (m_ports!=null)
               {
                    for (int i = 0; i < m_ports.Length; i++)
                    {
                         m_ports[i] = null;
                    }
                    m_ports = null;
               }
               m_isConnect = false;
          }
     } 
}
