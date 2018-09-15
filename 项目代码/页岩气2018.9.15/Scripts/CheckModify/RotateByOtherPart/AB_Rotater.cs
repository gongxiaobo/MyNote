using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     ///找到指定的零件，然后旋转这个一个零件
     /// </summary>
     public abstract class AB_Rotater : MonoBehaviour
     {
          /// <summary>
          /// 传出旋转值
          /// </summary>
          /// <param name="_angle"></param>
          public abstract void fn_Rotate(float _angle);
          /// <summary>
          /// 要旋转的目标零件
          /// </summary>
          public abstract int M_PartID { get; set; }
     } 
}
