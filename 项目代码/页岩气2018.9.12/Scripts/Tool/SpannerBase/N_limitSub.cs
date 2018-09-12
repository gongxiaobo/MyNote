using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_limitSub : CaculateAngelLimitSub
     {
          protected override void fnp_nearValue(float _value)
          {
               base.fnp_nearValue(_value);

               Debug.Log("<color=red>fnp_nearValue red:</color>" + _value);

          }

     }

}