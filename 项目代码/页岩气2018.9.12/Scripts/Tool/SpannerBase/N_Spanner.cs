using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_Spanner : AB_Spanner
     {
          public Animator m_animator = null;
          protected AB_HandleEvent m_handleEvent = null;
          // Use this for initialization
          protected virtual void Start()
          {
               if (m_animator == null)
               {
                    m_animator = GetComponent<Animator>();
               }
               if (m_animator == null)
               {
                    m_animator = GetComponentInChildren<Animator>();
               }
               m_handleEvent = GetComponent<AB_HandleEvent>();
               if (m_handleEvent==null)
               {
                    m_handleEvent = gameObject.transform.parent.GetComponent<AB_HandleEvent>();
               }
          }


          protected bool m_isStartHanding = false;
          public override void fn_startControl(Transform _hand)
          {
               m_isStartHanding = true;
          }

          public override void fn_endControl()
          {
               m_isStartHanding = false;
          }

          public override void fn_setTo(float _angel)
          {
          }

          public override void fn_setTo(string _com)
          {

          }
     }

}