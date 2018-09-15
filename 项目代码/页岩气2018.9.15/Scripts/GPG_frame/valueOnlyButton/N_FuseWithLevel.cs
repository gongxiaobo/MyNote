using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 熔断器初始化连接
     /// </summary>
     public class N_FuseWithLevel : AB_OnlyValue
     {
          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_level(_level, _controlType);

               //Debug.Log("<color=red>N_FuseWithLevel:</color>" + _level);

               if (_controlType == E_ControlType.e_init)
               {
                    if (_level == 2)
                    {//初始化连接
                         I_fuseInit t_fuseinit = GetComponent<I_fuseInit>();
                         if (t_fuseinit != null)
                         {
                              t_fuseinit.fni_initFuseConnect();
                         }
                    }
               }
          }

     } 
}
