using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public abstract class AB_ShowConTrigger : MonoBehaviour
     {
          /// <summary>
          /// 再次链接的触发器是否显示或隐藏
          /// </summary>
          /// <param name="_show"></param>
          public abstract void fn_ShowOrHide(bool _show = true);
          /// <summary>
          /// 事件的绑定
          /// </summary>
          /// <param name="_state"></param>
          protected abstract void fn_ReceiveEvent(E_ThePartState _state);
     } 
}
