using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 旋转值的发出
     /// </summary>
     public class N_CheckValueEvent_02 : AB_CheckValueEvent
     {
          AB_NameFlag t_nf = null;
          AB_HandleEvent m_handleEvent = null;
          AB_Name t_thisTool = null;
          public override void fn_ValueEvent(float _now, Vector2 _valuelimit)
          {
               if (t_nf==null)
               {
                    t_nf = this.gameObject.transform.parent.GetComponent<AB_NameFlag>();
               }
               if (m_handleEvent==null)
               {
                    m_handleEvent = this.gameObject.transform.parent.GetComponent<AB_HandleEvent>();
               }
               if (t_thisTool==null)
               {
                    t_thisTool = this.gameObject.transform.parent.GetComponent<AB_Name>();
               }
               if (t_nf==null || m_handleEvent==null)
               {

                    Debug.Log("<color=red>AB_NameFlag ,AB_HandleEvent not find ...</color>");
     
                    return;
               }
               if (_now<0f)
               {
                    return;
               }
               //throw new System.NotImplementedException();

               //Debug.Log("<color=blue>N_SendMsg:</color>" + _now);
               AB_SendMsg t_send = new N_SendMsg();
               t_send.fn_sendmsg(E_MessageType.e_outside, E_valueType.e_inter_floatvalue,
                    t_thisTool.m_ID, t_nf.M_nameID, (_now).ToString(), m_handleEvent);

     
          }
     } 
}
