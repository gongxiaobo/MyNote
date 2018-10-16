using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 柱塞翻入工具的触发器
     /// </summary>
     public class N_YaobaTrigger_tool01_01_01 : N_YaobaTrigger_tool01_01
     {
          protected override void fnp_Do(GameObject _collider)
          {
               base.fnp_Do(_collider);
               if (m_obj!=null)
               {
                    I_SetPullBack t_setPullBack = m_obj.GetComponent<I_SetPullBack>();
                    if (t_setPullBack!=null)
                    {
                         t_setPullBack.fni_setPullBack(true);
                    }
               }

          }

     } 
}
