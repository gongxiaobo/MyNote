using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 是否放入熔断器
     /// </summary>
     public abstract class AB_haveFuse : MonoBehaviour
     {
          /// <summary>
          /// 是否有熔断器
          /// </summary>
          /// <returns>true 有</returns>
          public abstract bool fn_HaveFuse();
          /// <summary>
          /// 是否联入熔断器
          /// true为放入熔断器
          /// </summary>
          /// <param name="_co"></param>
          public abstract void fn_connectFuse(bool _co);


     } 
}
