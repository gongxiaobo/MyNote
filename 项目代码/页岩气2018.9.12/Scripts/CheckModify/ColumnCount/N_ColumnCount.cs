using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_ColumnCount : AB_ColumnCount
     {
          /// <summary>
          /// 倒计时时间
          /// </summary>
          public float m_countTime = 3f;
          protected bool m_CountOver = false;
          private bool m_start = false;
          public override void fn_StartCount()
          {
               if (m_start)
               {
                    return;
               }
               m_start = true;
               Invoke("fnp_count", m_countTime);
          }
          protected void fnp_count()
          {
               m_CountOver = true;
               fnp_countOverDo();
          }
          protected virtual void fnp_countOverDo() { }
          public override bool fn_IsEndCount()
          {
              return m_CountOver;
          }

          public override void fn_reset()
          {
               m_start = false;
               m_CountOver=false;
          }
     } 
}
