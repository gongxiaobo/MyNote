using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// cdp的控制类型
     /// </summary>
     public class N_cdpControll : AB_OnlyValue
     {
          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_level(_level, _controlType);
               if (_controlType == E_ControlType.e_init)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("floatvalue", _level.ToString(), GetComponent<AB_HandleEvent>());
               }
               else if (_controlType == E_ControlType.e_normal)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("floatvalue", _level.ToString(), GetComponent<AB_HandleEvent>());
               }
          }
          public override void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_txt(_txt, _controlType);
               if (_controlType == E_ControlType.e_init)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("string", _txt, GetComponent<AB_HandleEvent>());
               }
               else if (_controlType == E_ControlType.e_normal)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("string", _txt, GetComponent<AB_HandleEvent>());
               }
          }

     }

}