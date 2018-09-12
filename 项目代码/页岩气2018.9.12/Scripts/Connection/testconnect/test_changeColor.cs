using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class test_changeColor : MonoBehaviour
     {
          public A_TriggerObj m_control = null;
          public A_TriggerObj m_control1 = null;
          // Use this for initialization
          void Start()
          {

          }

          // Update is called once per frame
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.C))
               {
                    if (m_control!=null)
                    {
                         m_control.fn_trigger(E_buttonIndex.e_padPressDown, null);
                    }
               }
               if (Input.GetKeyDown(KeyCode.X))
               {
                    if (m_control1 != null)
                    {
                         m_control1.fn_trigger(E_buttonIndex.e_padPressDown, null);
                    }
               }
          }
     } 
}
