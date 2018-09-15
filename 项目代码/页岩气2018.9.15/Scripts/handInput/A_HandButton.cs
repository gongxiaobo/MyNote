using UnityEngine;
using System.Collections;
using System;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0215/ :对手柄按键的设置抽象
     ///@ author gong
     ///@ version 1.1 /2017.0307/ :新增关联检测扳机键和侧握键的事件:Me_triggerAndGrip；
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public abstract class A_HandButton : MonoBehaviour, I_HandButton
     {
          protected Action<E_buttonIndex> me_action;
          // Use this for initialization
          protected virtual void Start()
          {
               return;
          }

          // Update is called once per frame
          protected virtual void Update()
          {
               return;
          }
          /// <summary>
          /// 输入的按键事件检测
          /// </summary>
          protected abstract void fnp_checkDevice();
          /// <summary>
          /// 隐藏射线
          /// </summary>
          protected abstract void fnp_hideRay();
          /// <summary>
          /// 显示射线
          /// </summary>
          protected abstract void fnp_showRay();
          /// <summary>
          /// 自动取消选择的物体
          /// </summary>
          public abstract void fni_autoRealse();
          /// <summary>
          /// 获取手柄的RigidBody
          /// </summary>
          /// <returns>The get hand rigid.</returns>
          public abstract Rigidbody fni_getHandRigid();
          /// <summary>
          /// 获取手的位置组件
          /// </summary>
          /// <returns>The get hand.</returns>
          public abstract Transform fni_getHand();
          /// <summary>
          /// 加入事件
          /// </summary>
          /// <param name="_fnction">Fnction.</param>
          public virtual void fn_addEvent(Action<E_buttonIndex> _fnction)
          {
               if (_fnction != null)
               {
                    me_action += _fnction;
               }
          }
          /// <summary>
          /// 取消事件
          /// </summary>
          /// <param name="_fnction">Fnction.</param>
          public virtual void fn_subEvent(Action<E_buttonIndex> _fnction)
          {
               if (_fnction != null)
               {
                    me_action -= _fnction;
               }
          }

          //主要是用于关联检测扳机键和侧握键的事件
          protected Action<string> me_triggerAndGrip;
          public event Action<string> Me_triggerAndGrip
          {
               add
               {
                    if (value != null)
                    {
                         me_triggerAndGrip += value;
                    }
               }
               remove
               {
                    me_triggerAndGrip -= value;
               }
          }
          /// <summary>
          /// 抖动手柄
          /// </summary>
          public virtual void fn_shake() { }
          /// <summary>
          /// 反馈接口
          /// </summary>
          /// <param name="_bl"></param>
          public virtual void fni_callBack(bool _bl) { }
     }

}