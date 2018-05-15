using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 熔断器的状态
     /// </summary>
     public abstract class AB_FuseState : MonoBehaviour
     {
          protected virtual void Start() { }
          /// <summary>
          /// 熔断器的状态，true为可以工作，false为不能工作
          /// </summary>
          /// <returns></returns>
          public abstract bool fn_CanWork();
          /// <summary>
          /// 设置熔断器的状态
          /// </summary>
          /// <param name="_canuse"></param>
          /// <returns></returns>
          public abstract void fn_setState(bool _canuse);
     } 
}
