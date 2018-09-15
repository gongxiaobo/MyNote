using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ui上的组件，主要用于和control层的交互
/// </summary>
public abstract class AB_viewItem : MonoBehaviour, I_uiHandleMsg
{
     public E_UITypeName m_viewType = E_UITypeName.e_null;

     [Tooltip("不能重复的ID")]
     /// <summary>
     /// 这个view类型的ID
     /// </summary>
     public int m_viewID = -1;
     /// <summary>
     /// 这是对应的数据的item id
     /// 这项值可能是计算出来，也可能没有
     /// </summary>
     public int m_DataID = 0;
     public virtual void fni_send(UIMsg _sendout)
     {
          S_viewItems.Instance.fni_send(_sendout);
     }

     public virtual void fni_receive(UIMsg _get)
     {
     }
     protected virtual void Start()
     {
          S_viewItems.Instance.fn_putIn(this);
     }
}
