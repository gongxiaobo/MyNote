using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// A的状态变化后，自己做点啥
     /// </summary>
     public abstract class AB_ADo : MonoBehaviour, I_StateChange
     {

          protected virtual void Start()
          {
               fnp_findOther();
          }
          /// <summary>
          /// 发起动作的item编号
          /// </summary>
          protected int m_triggerID = 0;
          public virtual void fni_itemChange(int _itemID)
          {
               m_triggerID = _itemID;
               fn_ToDo();
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
