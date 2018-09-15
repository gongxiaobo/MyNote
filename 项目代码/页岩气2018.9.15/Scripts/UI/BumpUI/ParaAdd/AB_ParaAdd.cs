using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 累计添加数值类
     /// </summary>
     public abstract class AB_ParaAdd : MonoBehaviour
     {
          /// <summary>
          /// 累计添加数值
          /// </summary>
          public float m_off = 1f;
          /// <summary>
          /// 开始累加数值
          /// </summary>
          public abstract float m_startvalue{get;set;}
          /// <summary>
          /// 参数累加的时间间隔
          /// </summary>
          public float m_timecall = 1f;
          /// <summary>
          /// 开始
          /// </summary>
          public abstract void fn_start();
          /// <summary>
          /// 结束
          /// </summary>
          public abstract void fn_end();
          /// <summary>
          /// 结束后参数归零
          /// </summary>
          public abstract void fn_endToZero();

     } 
}
