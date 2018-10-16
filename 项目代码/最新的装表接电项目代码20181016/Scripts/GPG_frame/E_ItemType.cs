using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// item 的类型
     /// </summary>
     public enum E_ItemType
     {
          ///// <summary>
          ///// 交互类型
          ///// </summary>
          e_interactive = 1,
          /// <summary>
          /// 检查类型
          /// </summary>
          e_check = 2,

     }
     /// <summary>
     /// 状态值的类型
     /// </summary>
     public enum E_valueType
     {
          /// <summary>
          /// 交互开关类型
          /// </summary>
          e_inter_onoff = 10,
          /// <summary>
          /// 交互值类型
          /// </summary>
          e_inter_floatvalue = 11,
          /// <summary>
          /// 交互档位类型
          /// </summary>
          e_inter_level = 12,
          /// <summary>
          /// 字符串类型
          /// </summary>
          e_inter_string = 13,
     } 
}