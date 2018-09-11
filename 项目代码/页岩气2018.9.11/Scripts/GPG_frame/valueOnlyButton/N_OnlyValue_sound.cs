using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_OnlyValue_sound : N_OnlyValueLogic
     {
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);
               //S_SoundComSingle.Instance.fn
               S_SoundComSingle.Instance.fnp_sound("btn_up");
          }

     } 
}
