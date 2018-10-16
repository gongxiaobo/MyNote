using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testChageState : MonoBehaviour
     {
          AB_HandleEvent m_handle;
          // Use this for initialization
          void Start()
          {
               m_handle = GetComponent<AB_HandleEvent>();
          }

          // Update is called once per frame
          void Update()
          {

               if (Input.GetKeyDown(KeyCode.C))
               {
                    StateValueString t_value = (StateValueString)m_handle.fn_get("xx");
                    if (t_value.m_date == "good")
                    {
                         //m_handle.fn_HandleMsg()
                         AB_Message t_msg = new N_Message();
                         t_msg.fn_init(E_MessageType.e_changeState,
                              new StateValue[1] { 
               new StateValueString("xx","changexx")
               }, "change");
                         m_handle.fn_HandleMsg(t_msg);
                    }
               }
          }
     }

}