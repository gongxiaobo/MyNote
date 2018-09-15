using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_TriggerSwitch : AB_TriggerSwitch
     {

         
          public override void fn_trigger()
          {
               m_bool = !m_bool;
               fnp_do();
          }

          public override void fn_set(bool _bl)
          {
               m_bool=_bl;
               fnp_do();
          }
          /// <summary>
          /// 触发后需要做什么
          /// </summary>
          protected virtual void fnp_do() { }
     } 
}
