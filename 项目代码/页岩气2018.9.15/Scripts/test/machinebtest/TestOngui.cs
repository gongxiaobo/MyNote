using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class TestOngui : MonoBehaviour
     {

          public float index;
          void OnGUI()
          {
               //if (GUILayout.Button("按下按钮1")) {

               //    AB_HandleEvent handle = GetComponent<AB_HandleEvent>();
               //    StateValue[] state = new StateValue[1] { new StateValueString("level", "level"+index.ToString()) };
               //   // GetComponent<N_state>().fn_setValue(state);
               //    //GetComponent<I_Control>().fni_txt();

               //    AB_Message message = new N_Message();
               //    message.fn_init(E_MessageType.e_inside, state, "", handle.ID.m_ID);
               //    handle.fn_HandleMsg(message);
               //}
               if (GUILayout.Button("开关"))
               {
                    GetComponentInChildren<N_handle>().fn_setTo(index);
               }
          }
     }

}