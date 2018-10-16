using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{

     /// <summary>
     /// CDP类型的值的存储类
     /// </summary>
     public abstract class AB_cdpValue : MonoBehaviour, I_CDPSet
     {
          protected virtual void Start() { }
          /// <summary>
          /// 设置从表中读取出来的值类型和值
          /// </summary>
          /// <param name="_type"></param>
          /// <param name="_values"></param>
          public abstract void fn_setValue(string _type, string _values);
          /// <summary>
          /// 从表中读取速度值
          /// </summary>
          /// <param name="_speed1"></param>
          /// <param name="_speed2"></param>
          public abstract void fn_setSpeed(string _speed1, string _speed2);

          public virtual void fni_UpArrow_start(Action<string> _callback)
          {
          }

          public virtual void fni_UpArrow_end()
          {
          }

          public virtual void fni_DownArrow_start(Action<string> _callback)
          {
          }

          public virtual void fni_DownArrow_end()
          {
          }

          public virtual void fni_DoubleUpArrow_start(Action<string> _callback)
          {
          }

          public virtual void fni_DoubleUpArrow_end()
          {
          }

          public virtual void fni_DoubleDownArrow_start(Action<string> _callback)
          {
          }

          public virtual void fni_DoubleDownArrow_end()
          {
          }

          public virtual void fni_Confirm()
          {
          }
          public virtual string fni_getValue() { return ""; }
     }

}