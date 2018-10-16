using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 触发类型
     /// A trigger B
     /// then B is to do something
     /// </summary>
     public abstract class AB_AToB : MonoBehaviour, I_StateChange
     {

          // Use this for initialization
          protected virtual void Start()
          {
               fnp_findControl();
               fnp_findOther();
          }
          /// <summary>
          /// 设置参数接口
          /// </summary>
          protected I_Control m_control = null;
          protected virtual void fnp_findControl()
          {
               if (m_control == null)
               {
                    m_control = GetComponent<I_Control>();
               }
          }
          /// <summary>
          /// 发起动作的item编号
          /// </summary>
          protected int m_triggerID = 0;
          public virtual void fni_itemChange(int _itemID)
          {
               fnp_findControl();
               fnp_findOther();
               if (m_control != null && mi_getOtherState!=null)
               {
                    m_triggerID = _itemID;
                    fn_ToDo(); 
               }
          }
          /// <summary>
          /// 做点什么
          /// </summary>
          public abstract void fn_ToDo();
          /// <summary>
          /// 获取关注item的状态
          /// </summary>
          protected I_getOtherState mi_getOtherState = null;
          protected virtual void fnp_findOther()
          {
               if (mi_getOtherState == null)
               {
                    mi_getOtherState = transform.parent.GetComponent<I_getOtherState>();
               }
          }
     } 
}
