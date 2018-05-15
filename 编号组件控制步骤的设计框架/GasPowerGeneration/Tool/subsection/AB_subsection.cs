using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     ///  gong -- 2017/11/03
     ///  ***把指定范围中的值拆分指定段，过滤值使用
     ///  gong -- 2017/8/
     ///  ***
     ///  gong -- 2017/8/
     ///  ***
     ///  gong -- 2017/8/
     ///  ***
     /// </summary>
     public abstract class AB_subsection
     {
          /// <summary>
          /// 起始值
          /// </summary>
          protected float m_startValue = 0f;
          /// <summary>
          /// 结束值
          /// </summary>
          protected float m_endValue = 1f;
          /// <summary>
          /// 拆分几段
          /// </summary>
          public float m_subNum = 4;
          /// <summary>
          /// 过滤后的值
          /// </summary>
          public float m_filterValue = 0f;
          /// <summary>
          /// 初始化
          /// </summary>
          /// <param name="_start"></param>
          /// <param name="_end"></param>
          /// <param name="_subnum"></param>
          public abstract void fn_init(float _start, float _end, float _subnum);
          public abstract void fn_init(float _start, float _end, float _subnum, Action<float> _call);
          /// <summary>
          /// 过滤输入值到分段刻度值
          /// </summary>
          /// <param name="_value"></param>
          /// <returns></returns>
          public abstract float fn_filter(float _value);
          /// <summary>
          /// 输入当前值
          /// </summary>
          /// <param name="_input"></param>
          public abstract void fn_inputValue(float _input);
     }

}