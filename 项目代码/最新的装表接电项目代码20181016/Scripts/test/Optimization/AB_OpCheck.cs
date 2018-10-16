using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.test.Optimization
{
     /// <summary>
     /// 优化距离的管理检查抽象
     /// </summary>
     public abstract class AB_OpCheck : MonoBehaviour
     {
          protected virtual void Start() { }
          /// <summary>
          /// 玩家的位置
          /// </summary>
          public abstract Transform M_player { get; set; }
          /// <summary>
          /// 立即设置玩家将要去的位置
          /// </summary>
          /// <param name="_playerWorldPos"></param>
          public abstract void fn_SetImmediately(Vector3 _playerWorldPos);
          /// <summary>
          /// 设置是否使用优化处理
          /// true 为关闭
          /// </summary>
          public abstract bool M_CloseOptimizam { set; }
          /// <summary>
          /// 开始检查
          /// </summary>
          public abstract void fn_startCheck();
          /// <summary>
          /// 结束检查
          /// </summary>
          public abstract void fn_endCheck();

     }
}
