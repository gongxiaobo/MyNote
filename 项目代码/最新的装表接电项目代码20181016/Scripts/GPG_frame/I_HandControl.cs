using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 需要手柄的交互接口
     /// </summary>
     public interface I_HandControl : I_Control
     {
          /// <summary>
          /// 开始手柄的触发
          /// </summary>
          /// <param name="_hand"></param>
          void fni_startControl(Transform _hand);
          /// <summary>
          /// 结束手柄的触发
          /// </summary>
          void fni_endControl();

     } 
}
