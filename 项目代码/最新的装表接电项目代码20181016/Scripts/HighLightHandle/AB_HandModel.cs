using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 手柄上一个按钮的高亮显示
     /// </summary>
     public abstract class AB_HandModel : MonoBehaviour
     {
          protected virtual void Start()
          {
               S_HandButton.Instance.RightHandLightBtn = this;
          }
          /// <summary>
          /// 设置高亮的按钮
          /// </summary>
          /// <param name="_btnName"></param>
          public abstract void fn_setHighLight(string _btnName);
          /// <summary>
          /// 设置默认材质
          /// </summary>
          public abstract void fn_setDefault();
          protected virtual void fn_findMesh() { }
          public Material m_light;
          protected Material m_default;
     } 
}
