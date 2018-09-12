using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0206/ :手柄的按键自定义名称
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public enum E_buttonIndex
     {
          e_null = 0,
          /// <summary>
          /// 接触触摸板
          /// </summary>
          e_padTouched = 1,
          /// <summary>
          /// 离开触摸板
          /// </summary>
          e_padTouchOver = 2,

          /// <summary>
          /// 触摸板按下
          /// </summary>
          e_padPressDown = 3,


          /// <summary>
          /// 按下触摸板上方键
          /// </summary>
          e_padPressDownUp = 4,
          /// <summary>
          /// 按下触摸板左方键
          /// </summary>
          e_padPressDownLeft = 5,
          /// <summary>
          /// 按下触摸板右方键
          /// </summary>
          e_padPressDownRight = 6,
          /// <summary>
          /// 按下触摸板下方键
          /// </summary>
          e_padPressDownDown = 7,

          /// <summary>
          /// 按下扳机键
          /// </summary>
          e_triggerDown = 8,
          /// <summary>
          /// 松开扳机键
          /// </summary>
          e_triggerUp = 9,

          /// <summary>
          /// 抓取键按下
          /// </summary>
          e_gripDown = 10,
          /// <summary>
          /// 抓取键松开
          /// </summary>
          e_gripUp = 11,
          /// <summary>
          /// 菜单键按下
          /// </summary>
          e_menuDown = 12,

          //
          /// <summary>
          /// 手柄进入
          /// </summary>
          e_handIn = 13,
          /// <summary>
          /// 手柄离开
          /// </summary>
          e_handOut = 14,
          /// <summary>
          /// 触摸板弹起
          /// </summary>
          e_padPressUp = 15,
     }


     public enum E_TriggerObjState
     {
          e_null = 0,
          /// <summary>
          /// 射线击中
          /// </summary>
          e_rayhit = 1,
          /// <summary>
          /// 已经被选中
          /// </summary>
          e_selected = 2,
          /// <summary>
          /// 没有被选中
          /// </summary>
          e_unselected = 3,

     } 
}