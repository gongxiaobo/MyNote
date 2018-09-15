using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 检查条件
     /// </summary>
     public abstract class AB_CheckCondition
     {
          /// <summary>
          /// 检查条件
          /// </summary>
          /// <param name="_Cname"></param>
          /// <param name="m_condition"></param>
          /// <returns>通过 true</returns>
          public abstract bool fn_check(string _Cname, AB_Condition m_condition);
     } 
}
