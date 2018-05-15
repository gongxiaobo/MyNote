using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GasPowerGeneration
{
     /// <summary>
     /// CDP的界面控制接口
     /// </summary>
     public interface I_CDPSet
     {
          /// <summary>
          /// 向上单箭头开始控制
          /// </summary>
          void fni_UpArrow_start(Action<string> _callback);
          /// <summary>
          ///  向上单箭头结束控制
          /// </summary>
          void fni_UpArrow_end();
          /// <summary>
          ///  向下单箭头开始控制
          /// </summary>
          void fni_DownArrow_start(Action<string> _callback);
          /// <summary>
          /// 向下单箭头结束控制
          /// </summary>
          void fni_DownArrow_end();
          /// <summary>
          /// 向上双箭头开始控制
          /// </summary>
          void fni_DoubleUpArrow_start(Action<string> _callback);
          /// <summary>
          /// 向上双箭头结束控制
          /// </summary>
          void fni_DoubleUpArrow_end();
          /// <summary>
          /// 向下双箭头开始控制
          /// </summary>
          void fni_DoubleDownArrow_start(Action<string> _callback);
          /// <summary>
          /// 向下双箭头结束控制
          /// </summary>
          void fni_DoubleDownArrow_end();
          /// <summary>
          /// 确认键
          /// </summary>
          void fni_Confirm();
          /// <summary>
          /// 获取现在的状态值
          /// </summary>
          /// <returns></returns>
          string fni_getValue();

     }

}