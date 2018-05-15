using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testUseHand : MonoBehaviour
     {
          public CaculateAngel m_spanner;
          // Use this for initialization
          void Start()
          {

          }

          // Update is called once per frame
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.C))
               {
                    m_trigger = !m_trigger;

               }
               if (m_cancontrol && m_trigger)
               {
                    m_spanner.fn_startControl(this.gameObject.transform);
               }
               else
               {

                    m_spanner.fn_endControl();
               }
          }
          bool m_cancontrol = false;
          bool m_trigger = false;
          public void OnTriggerEnter(Collider other)
          {
               if (other.name == "LookTarget")
               {
                    if (m_spanner != null)
                    {
                         m_trigger = false;
                         m_cancontrol = true;

                    }
               }
          }

          public void OnTriggerExit(Collider other)
          {
               if (other.name == "LookTarget")
               {
                    if (m_spanner != null)
                    {
                         m_cancontrol = false;
                         m_trigger = false;
                    }
               }
          }

     }

}