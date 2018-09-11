using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理了最小值为负数的bug
     /// </summary>
     public class Look_pointer : N_Pointer
     {
          public float animspeed;
          protected override void Start()
          {
               base.Start();
               //m_offset = animspeed*0.2f;
               m_offset *= 4f;
               //m_valueNow = m_min;
          }
          public override void fn_inputValue(float _value)
          {
               //base.fn_inputValue(_value);
               m_valueNew = fnp_input(_value);
              
               m_valueNew = m_valueNew - m_min;
               m_valueNew = m_valueNew * m_factor;

               //Debug.Log("<color=blue>传入表的参数blue:</color>" + m_valueNew + ":" + m_factor);

               if (m_isSetting == false)
               {
                    m_isSetting = true;
                    S_update.Instance.M_fixedupdate = fnp_FixedUpdate;
                    fnp_newValueStartSet();
               }
          }

     }

}