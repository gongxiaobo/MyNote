using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 零件初始化隐藏自己的碰撞体
     /// </summary>
     public abstract class AB_PartTriggerInit : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 初始化去隐藏自己的碰撞体
          /// </summary>
          protected abstract void fnp_init();
          protected abstract void fnp_kill();


     } 
}
