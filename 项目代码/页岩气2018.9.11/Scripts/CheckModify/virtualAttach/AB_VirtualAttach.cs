using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public abstract class AB_VirtualAttach : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 链接的零件
          /// </summary>
          public int m_AttachPartID = 0;
          /// <summary>
          /// 找到零件
          /// </summary>
          protected abstract void fn_findPart();
          /// <summary>
          /// 初始化虚拟零件，找到对应的依附零件，关联
          /// </summary>
          public abstract void fn_init();

     } 
}
