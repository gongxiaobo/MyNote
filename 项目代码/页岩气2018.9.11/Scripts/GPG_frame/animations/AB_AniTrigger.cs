using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 设置动画机的触发参数
     /// </summary>
     public abstract class AB_AniTrigger : MonoBehaviour
     {
          /// <summary>
          /// 设置触发类型的参数
          /// </summary>
          /// <param name="_trigger"></param>
          public abstract void fn_setTrigger(string _trigger);
     } 
}
