using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 移动到指定位置
     /// </summary>
     public abstract class AB_MoveTo : MonoBehaviour
     {
          /// <summary>
          /// 移动到制定位置
          /// </summary>
          /// <param name="_pos">世界坐标</param>
          public abstract void fn_MoveTo(Vector3 _pos);
     } 
}
