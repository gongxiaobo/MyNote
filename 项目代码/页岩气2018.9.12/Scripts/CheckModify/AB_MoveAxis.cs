using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 沿着一个轴去移动一个物体
     /// </summary>
     public abstract class AB_MoveAxis : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 根据参数来移动
          /// </summary>
          /// <param name="_moveValue"></param>
          public abstract void fn_move(float _moveValue);
          /// <summary>
          /// 正向反向
          /// </summary>
          public bool m_dir;
          public abstract void fn_reset();
          /// <summary>
          /// 是否到达最末端
          /// </summary>
          public bool m_isReachEnd = false;
          /// <summary>
          /// 移动的方向
          /// </summary>
          public abstract Vector3 M_MoveDir { get; set; }


     }

}