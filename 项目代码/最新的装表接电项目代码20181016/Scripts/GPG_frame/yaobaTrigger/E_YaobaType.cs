using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把类型
     /// 需要碰触的类型和摇把类型一致才能使用摇把
     /// </summary>
     public enum E_YaobaType
     {
          e_null = 0,
          e_one = 1,
          /// <summary>
          /// 10kv操作类型1
          /// </summary>
          e_two = 2,
          /// <summary>
          /// 10kv操作类型2
          /// </summary>
          e_three = 3,
          /// <summary>
          /// 35kv的手车摇入手柄
          /// </summary>
          e_35kv_01 = 4,
          /// <summary>
          /// 35kv的接地开关
          /// </summary>
          e_35kv_02 = 5,
          /// <summary>
          /// T型的工具
          /// </summary>
          e_Ttool=6,
          /// <summary>
          /// 拉出器
          /// </summary>
          e_Puller=7,
          /// <summary>
          /// 柱子
          /// </summary>
          e_column=8,
          /// <summary>
          /// 柱塞盘根放入工具
          /// </summary>
          e_zhusai=9,

     } 
}
