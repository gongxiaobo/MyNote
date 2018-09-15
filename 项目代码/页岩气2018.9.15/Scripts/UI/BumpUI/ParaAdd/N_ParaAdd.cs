using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_ParaAdd : AB_ParaAdd
     {

          
          public override void fn_start()
          {
               CancelInvoke("fnp_add");
               InvokeRepeating("fnp_add", 1f, m_timecall);
          }

          public override void fn_end()
          {
               CancelInvoke("fnp_add"); 
          }

          public override void fn_endToZero()
          {
               fn_end();
               m_start = 0f;

          }
          protected virtual void fnp_add()
          {
               m_startvalue += m_off;
          }
          [SerializeField]
          float m_start = 0f;
          public override float m_startvalue
          {
               get
               {
                    return m_start;
               }
               set
               {
                    m_start=value;
               }
          }
     } 
}
