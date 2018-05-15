using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 高亮一个物体
     /// </summary>
     public abstract class AB_LightOneObj : MonoBehaviour
     {
          public E_LightObjType m_lightObjType = E_LightObjType.e_normal;
          protected virtual void Start() { }
          /// <summary>
          /// 高亮
          /// </summary>
          public abstract void fn_light();
          /// <summary>
          /// 结束高亮
          /// </summary>
          public abstract void fn_endLigth();
     }
     public enum E_LightObjType
     {
          e_null = 0,
          e_normal = 1,
          e_pickUp = 2,

     } 
}