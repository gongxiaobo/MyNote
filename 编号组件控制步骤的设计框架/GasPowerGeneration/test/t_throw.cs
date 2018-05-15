using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class t_throw : A_TriggerObj
     {

          Dictionary<int, int> m_value = new Dictionary<int, int>();

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               //throw new System.NotImplementedException();
               foreach (var item in m_value.Keys)
               {

               }
          }
     } 
}
