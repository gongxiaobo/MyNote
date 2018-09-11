using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 两点在平面上排序后生成路径点的模式
     /// </summary>
     public enum E_CaculateMode
     {
          /// <summary>
          /// 普通模式，不添加多余的点
          /// </summary>
          e_default=0,
          /// <summary>
          /// 在开始点和结束点都添加一点
          /// </summary>
          e_style1=1,
          /// <summary>
          /// 在开始点和结束点都添加两点
          /// </summary>
          e_style2=2,
     }
}
