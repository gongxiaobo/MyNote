using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GasPowerGeneration
{

     public class N_HideShowOne : N_HideShowNormal
     {
          public GameObject m_hideObj = null;
          [EnumLabel("机器")]
          public E_MachineName m_machineName = E_MachineName.e_null;
          void Start()
          {
               S_SceneMagT1.Instance.fn_putInBubble(this);
          }
          public override void fn_hide()
          {
               base.fn_hide();
               fnp_isHide();
               fnp_changestate();

          }
          public override void fn_show()
          {
               base.fn_show();
               fnp_changestate(true);
               fnp_isShow();

          }

          protected virtual void fnp_changestate(bool _hide = false)
          {
               if (m_hideObj != null)
               {
                    m_hideObj.SetActive(_hide);
                    if (_hide)
                    {
                         //m_hideObj.transform.do
                    }
               }
               else { Debug.Log("<color=red>m_hideObj==null</color>"); }
          }
          /// <summary>
          /// 显示要做的事情
          /// </summary>
          protected virtual void fnp_isShow() { }
          /// <summary>
          /// 隐藏前要做的事情
          /// </summary>
          protected virtual void fnp_isHide() { }
     }

}