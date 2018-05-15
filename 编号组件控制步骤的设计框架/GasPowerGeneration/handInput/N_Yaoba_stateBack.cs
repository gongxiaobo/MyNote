using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把旋转后，手松开就回到0位置
     /// </summary>
     public class N_Yaoba_stateBack : N_Yaoba_state, I_YaobaBackSet
     {
          public bool m_BackToZero = false;
          protected override void fnp_handEndControl()
          {
               base.fnp_handEndControl();
               if (m_spanner != null && m_BackToZero)
               {
                    m_spanner.fn_setTo(0f);
               }
          }

          public void fni_setCanBack(bool _iscan)
          {
               m_BackToZero = _iscan;
          }
     } 
}
