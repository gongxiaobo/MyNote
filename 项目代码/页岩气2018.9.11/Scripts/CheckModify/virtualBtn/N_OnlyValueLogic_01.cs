using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 被动改变值类型的虚拟从属零件
     /// </summary>
     public class N_OnlyValueLogic_01 : N_OnlyValueLogic
     {
          AB_SetState t_setState = null;
          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_findCR();
               base.fni_level(_level, _controlType);
               if (t_setState == null)
               {
                    t_setState = new N_SetState();
               }
               t_setState.fn_setState("level", _level.ToString(), m_handleEvent);


          }

     } 
}
