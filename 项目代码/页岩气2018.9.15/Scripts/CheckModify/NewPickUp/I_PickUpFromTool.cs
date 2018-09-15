using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 从工具上拿起零件
     /// </summary>
     public interface I_PickUpFromTool
     {
          /// <summary>
          /// 从工具上拿取零件后的反馈调用
          /// </summary>
          /// <param name="_callback"></param>
          void fni_PickUpPartFromTool(Action _callback);

     } 
}
