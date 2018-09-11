using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public abstract class AB_SpAni : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 设置动画时间
          /// </summary>
          /// <param name="_time"></param>
          public abstract void fn_setAniTime(float _time);

     }
     
}