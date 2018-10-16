using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 指针功能组件的抽象
     /// </summary>
     public abstract class AB_Pointer : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 输入给指针的值
          /// </summary>
          /// <param name="_value"></param>
          public abstract void fn_inputValue(float _value);
          /// <summary>
          /// 动画采样
          /// </summary>
          protected abstract void fnp_FixedUpdate();
     }

}