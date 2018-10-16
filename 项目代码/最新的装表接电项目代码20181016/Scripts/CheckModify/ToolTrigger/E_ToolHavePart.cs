using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 在泵的检修中，工具能拿起物体，
     /// 枚举表示工具有没有挂载物体
     /// </summary>
     public enum E_ToolHavePart
     {
          /// <summary>
          ///工具上 没有零件
          /// </summary>
          e_noPart=0,
          /// <summary>
          ///工具上 有零件
          /// </summary>
          e_havePart=1,

     } 
}
