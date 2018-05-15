using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 门开关90度的控制。
     /// </summary>
     public class Door_90 : N_handle
     {
          public float m_closedoffset = 0.25f;
          public float m_openoffset = 0.35f;
          public override void fn_endControl()
          {
               base.fn_endControl();
               if (m_lastTime <= m_closedoffset)
               {
                    fnp_setAni(m_min);
               }
               if (m_max - m_lastTime <= m_openoffset)
               {
                    fnp_setAni(m_max);
               }
          }
     } 
}
