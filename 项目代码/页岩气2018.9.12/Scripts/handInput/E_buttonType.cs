using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0215/ :按键类型分类，4类
     ///@ author gong
     ///@ version 1.1 /2017.0311/ :加入e_light_obj和e_panel_obj类型
     ///@ author gong
     ///@ version 1.2 /2017.0311/ :加入了 e_onoff_updown，e_onoff_lr，e_pointer这三种新的类型
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public enum E_buttonType
     {
          e_null = 0,
          /// <summary>
          /// UI按钮
          /// </summary>
          e_ui_button = 1,
          /// <summary>
          /// 普通的开关按钮，自有开和关两种状态
          /// </summary>
          e_onoff_switch = 2,
          /// <summary>
          /// 旋钮
          /// </summary>
          e_knob_button = 3,
          /// <summary>
          /// 物体
          /// </summary>
          e_grip_obj = 4,


          /// <summary>
          /// 指示灯
          /// </summary>
          e_light_obj = 5,
          /// <summary>
          /// 显示面板物体
          /// </summary>
          e_panel_obj = 6,



          /// <summary>
          /// 上下开的开关
          /// </summary>
          e_onoff_updown = 7,
          /// <summary>
          /// 左右开的开关
          /// </summary>
          e_onoff_lr = 8,
          /// <summary>
          /// 指针类型的仪表盘
          /// </summary>
          e_pointer = 9,
     }

}