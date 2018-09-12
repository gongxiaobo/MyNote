using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 第一层UI的管理类
     /// </summary>
     public abstract class AB_UILevel01 : MonoBehaviour,I_handlemsg
     {
          public E_UILevel me_level = E_UILevel.e_null;
          /// <summary>
          /// UI的编号
          /// </summary>
          public int m_UIID = -1;
          // Use this for initialization
          protected virtual void Start()
          {//找到UI管理点
               S_selectUI.Instance.fn_addSelectUI(this);
          }

          public virtual void fni_receive(SMsg _reveive)
          {
              
          }

          public virtual void fni_send(SMsg _sendmsg)
          {
               S_selectUI.Instance.fni_receive(_sendmsg);
          }
          /// <summary>
          /// 按钮按下
          /// </summary>
          public virtual void fn_buttonHit() { }
     }

}