using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     public class N_bumpparam_01 : N_bumpparam
     {
          public override void fn_update_param(System.Action<int, string> _call, int bumpid)
          {
               base.fn_update_param(_call, bumpid);
               //float t_main;
               //float.TryParse(handler.fn_getMainValue(), out t_main);
               //fnp_rangValue(t_main, _callback);
               //if (bumpid == belongs_bump_id)
               //{

               //     //_callback += _call;
               //     //_call(handler.ID.m_ID, handler.fn_getMainValue());
               //     float t_main;
               //     float.TryParse(handler.fn_getMainValue(),out t_main);
               //     fnp_rangValue(t_main, _callback);

               //}
               //else
               //{
               //     //_callback = null;

               //}
          }
          I_ParaSet[] t_paraSet = null;
          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_level(_level, _controlType);
               //fnp_rangValue(_level, _callback);
          }

          private void fnp_rangValue(float _level,Action<int,string> _call)
          {
               //if (t_paraSet == null)
               //{
               //     t_paraSet = GetComponents<I_ParaSet>();
               //}
               //if (t_paraSet != null)
               //{
               //     for (int i = 0; i < t_paraSet.Length; i++)
               //     {
               //          t_paraSet[i].fni_newParaSet();
               //     }
               //}
          }
         
     } 
}
