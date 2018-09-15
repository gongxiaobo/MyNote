using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 线的大小设置
     /// </summary>
     public abstract class AB_WireScale : MonoBehaviour
     {
          /// <summary>
          /// 设置电线的粗细
          /// </summary>
          /// <param name="_size"></param>
          public abstract void fn_setWireSize(string _size);
          
     }

}