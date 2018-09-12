using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 柱形工具在播放动画完成后的事件发送
     /// </summary>
     public class N_ColumnCount_01 : N_ColumnCount
     {
          AB_NameFlag t_nf = null;
          AB_HandleEvent m_handleEvent = null;
          AB_Name t_thisTool = null;
          protected override void fnp_countOverDo()
          {
               base.fnp_countOverDo();
               if (t_nf == null)
               {
                    t_nf = this.gameObject.transform.parent.GetComponent<AB_NameFlag>();
               }
               if (m_handleEvent == null)
               {
                    m_handleEvent = this.gameObject.transform.parent.GetComponent<AB_HandleEvent>();
               }
               if (t_thisTool == null)
               {
                    t_thisTool = this.gameObject.transform.parent.GetComponent<AB_Name>();
               }
               if (t_nf == null || m_handleEvent == null)
               {

                    Debug.Log("<color=red>AB_NameFlag ,AB_HandleEvent not find ...</color>");

                    return;
               }
               AB_SendMsg t_send = new N_SendMsg();
               t_send.fn_sendmsg(E_MessageType.e_outside, E_valueType.e_inter_onoff,
                    t_thisTool.m_ID, t_nf.M_nameID, "on", m_handleEvent);
          }
          
     } 
}
