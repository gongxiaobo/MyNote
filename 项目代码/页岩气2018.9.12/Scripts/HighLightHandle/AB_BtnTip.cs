using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 挂载到需要手柄提示高亮哪个按键的物体上
     /// </summary>
     public abstract class AB_BtnTip : MonoBehaviour
     {

          public abstract void fn_light();
          public abstract void fn_endLight();
          public E_HandBtnName m_btnName = E_HandBtnName.e_null;
     }
     /// <summary>
     /// 高亮手柄上的哪个按钮
     /// </summary>
     public enum E_HandBtnName
     {
          e_null = 0,
          e_trigger = 1,
          e_pad = 2,

     } 
}
