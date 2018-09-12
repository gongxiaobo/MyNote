using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_CheckCondition : AB_CheckCondition
     {

          public override bool fn_check(string _Cname, AB_Condition m_condition)
          {
               return (m_condition != null) ? m_condition.fn_check(_Cname) : true;

          }
     } 
}
