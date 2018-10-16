using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     public abstract class AB_SubjectCheck : MonoBehaviour
     {
          /// <summary>
          /// 根据不同的模式初始化检查器，
          /// </summary>
          /// <param name="_callback">检查完成后的反馈</param>
          /// <param name="_mode">模式</param>
          public abstract void fn_init(Action _callback, E_mode _mode);
          /// <summary>
          /// 开始检查
          /// </summary>
          protected abstract void fnp_startCheck();
          /// <summary>
          /// 结束检查
          /// </summary>
          public abstract void fnp_endCheck();
          /// <summary>
          /// 销毁
          /// </summary>
          public abstract void fn_kill();



     } 
}
