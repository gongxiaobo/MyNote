using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 需检测物体发送消息类
     /// </summary>

     public class CheckUI : MonoBehaviour, I_checkable
     {

          public List<int> handlers = new List<int>();
          private Transform uipos;
          void Start()
          {
               uipos = TransformHelper.FindChild(transform, "checkuipos");

               if (handlers.Count == 0 && GetComponent<N_Name>() != null)
               {

                    if (GetComponent<N_Name>().m_ID != 0)
                         handlers.Add(GetComponent<N_Name>().m_ID);
               }
          }

          public void fn_send_messagetomanager()
          {
               CheckUImanager.Instance.fn_recive_handlers(handlers);
          }
          public void fn_send_handpos(Transform handpos)
          {
               CheckUImanager.Instance.fn_checkhandpos(uipos);
          }

          public void fn_hand_out()
          {
               CheckUImanager.Instance.fn_hideUI();
          }
     }

}