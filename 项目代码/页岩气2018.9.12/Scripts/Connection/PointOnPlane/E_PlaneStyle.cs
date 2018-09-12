using System;
using System.Collections.Generic;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 平面的类型
     /// </summary>
     public enum E_PlaneStyle
     {
          /// <summary>
          /// 一个点的投影，得到一个平面上的点
          /// </summary>
          e_1IN1OUT=0,
          /// <summary>
          /// 一个点投影，在投影到子平面上得到第二个点，得到平面上的两点
          /// </summary>
          e_1IN2OUT=1,
          /// <summary>
          /// 两点投影在平面上，得到平面上的两点,也有可能得到一个点，如果计算得到两点太近，就直接输出一个点
          /// </summary>
          e_2IN2OUT=3,
          /// <summary>
          /// 子平面
          /// </summary>
          e_child_1IN1OUT=4

     }
}
