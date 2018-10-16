using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 被其他零件控制旋转的情况
     /// </summary>
     public abstract class AB_RotateByPart : MonoBehaviour
     {
          /// <summary>
          /// 旋转值传入
          /// </summary>
          /// <param name="_angle"></param>
          public abstract void fn_Rotate(float _angle);
          /// <summary>
          /// 当前旋转的角度值
          /// </summary>
          public abstract float M_Rotate { get; set; }
        
     } 
}
