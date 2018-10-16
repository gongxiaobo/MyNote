using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 射线碰触到操作UI的高亮
     /// </summary>
     public abstract class AB_ropeLight : MonoBehaviour
     {
          protected virtual void Start() { }
          /// <summary>
          /// 高亮
          /// </summary>
          public abstract void fn_highlight();
          /// <summary>
          /// 默认状态
          /// </summary>
          public abstract void fn_default();

     } 
}
