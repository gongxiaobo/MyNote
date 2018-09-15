using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testInput : MonoBehaviour
     {
          AB_HandModel m_handmode = null;
          // Use this for initialization
          void Start()
          {
               if (m_handmode == null)
               {
                    m_handmode = GetComponent<AB_HandModel>();
               }
          }
          bool m_down = false;
          // Update is called once per frame
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.T))
               {
                    if (m_handmode == null) return;
                    m_down = !m_down;
                    if (m_down)
                    {
                         m_handmode.fn_setHighLight("trigger");
                         //m_handmode.fn_setHighLight("body");
                    }
                    else
                    {
                         m_handmode.fn_setDefault();

                    }

               }
          }
     } 
}
