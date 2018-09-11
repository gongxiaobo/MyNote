using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{

     //     namespace VRPT.Teaching
     //{
     public abstract class TimeCount
     {
          public delegate void callFunction();

          /// <summary>
          /// 间隔时间
          /// </summary>
          protected float counttime;
          protected float tempTime = 0f;
          /// <summary>
          /// 间隔时间调用函数
          /// </summary>
          protected callFunction CallEvent;

          public event callFunction M_CallEvent
          {
               add { CallEvent += value; }
               remove { CallEvent -= value; }
          }

          /// <summary>
          /// 连续调用
          /// </summary>
          abstract public void CallTime(float calltime);

          /// <summary>
          /// 初始化
          /// </summary>
          /// <param name="_fl">Fl.</param>
          /// <param name="_cf">Cf.</param>
          abstract public void SetCallSpace(float _fl, callFunction _cf);

          /// <summary>
          /// 重置
          /// </summary>
          abstract public void Reset();


     }

     public class TimeCount1 : TimeCount
     {
          /// <summary>
          /// 初始化
          /// </summary>
          /// <param name="_fl">Fl.</param>
          /// <param name="_cf">Cf.</param>
          public override void SetCallSpace(float _fl, callFunction _cf)
          {
               Reset();
               counttime = _fl;
               CallEvent += _cf;
          }

          /// <summary>
          /// 连续调用
          /// </summary>
          /// <param name="calltime">Calltime.</param>
          public override void CallTime(float calltime)
          {
               tempTime += calltime;
               if (tempTime >= counttime)
               {
                    if (CallEvent != null)
                         CallEvent();
                    tempTime = 0f;
               }
          }

          /// <summary>
          /// 重置
          /// </summary>
          public override void Reset()
          {
               tempTime = 0f;
               counttime = 1f;
               CallEvent = null;
          }
     }
     //}



}