using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.test.Optimization
{
     /// <summary>
     /// 为优化添加玩家位置
     /// </summary>
     class N_AddPlayerPos:MonoBehaviour
     {
          void Start()
          {
               S_OpMesh.Instance.Player = this.gameObject.transform;

          }
     }
}
