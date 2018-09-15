using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理间歇油泵的开启和停止，在给定间歇后，自动关闭
     /// </summary>
     public class ChangeOnOff02 : ChangeOnOff
     {
          /// <summary>
          /// 在这个范围左右+-0.5f
          /// </summary>
          public float m_delay = 1f;
          public override void fn_ToDo()
          {
               //base.fn_ToDo();
               if (m_triggerID == m_TriggerFrom)
               {//泵的开启按钮
                    StopCoroutine("fnp_dolater");
                    StartCoroutine("fnp_dolater");

               }
          }
          IEnumerator fnp_dolater()
          {
               yield return new WaitForSeconds(m_delay + Random.Range(-0.5f, 0.5f));
               float t_fl = 0f;
               if (float.TryParse(mi_getOtherState.fni_otherState(m_TriggerFrom), out t_fl))
               {
                    if (t_fl>0f)
                    {
                         m_control.fni_off();
                    }
                    else
                    {
                         m_control.fni_on();
                    }
               }
               
          }

     } 
}
