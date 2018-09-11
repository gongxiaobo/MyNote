using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 切换功能
     /// </summary>
     public abstract class AB_TriggerSwitch : MonoBehaviour
     {
          protected bool m_bool = true;
          /// <summary>
          /// trigger
          /// </summary>
          public abstract void fn_trigger();
          /// <summary>
          /// 设置状态值
          /// </summary>
          /// <param name="_bl"></param>
          public abstract void fn_set(bool _bl);

     } 
}
