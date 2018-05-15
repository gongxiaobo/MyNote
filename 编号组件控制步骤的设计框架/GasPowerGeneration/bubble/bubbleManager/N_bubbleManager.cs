using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 一个机器的冒泡管理
     /// 刷新方式使用触发方式
     /// </summary>
     public class N_bubbleManager : N_HideShowNormal, I_bubleMagFind, I_updatePara
     {
          /// <summary>
          /// 机器的名称
          /// </summary>
          [EnumLabel("机器")]
          public E_MachineName m_MachineName = E_MachineName.e_null;
          public bool m_realtimeUpdate = true;
          void Start()
          {
               //m_bubbles = GetComponentsInChildren<AB_HideShow>();
               if (m_MachineName != E_MachineName.e_null)
               {
                    S_SceneMagT1.Instance.fn_putInBubblesMag(m_MachineName, this);
               }
               //fn_hide();
          }
          protected List<AB_HideShow> m_bubbles = new List<AB_HideShow>();

          public override void fn_show()
          {
               base.fn_show();
               fnp_showOrHide(true);

          }
          bool m_hideState = true;
          private void fnp_showOrHide(bool _hide = false)
          {
               if (m_bubbles != null)
               {
                    if (m_hideState == _hide)
                    {
                         return;
                    }
                    m_hideState = _hide;
                    fnp_bobbleShow();
                    //if (m_realtimeUpdate && m_hideState)
                    //{
                    //     InvokeRepeating("fnp_bobbleShow", 1f,1f); 
                    //}
               }
          }

          private void fnp_bobbleShow()
          {
               for (int i = 0; i < m_bubbles.Count; i++)
               {
                    if (m_hideState)
                    {
                         m_bubbles[i].fn_show();
                    }
                    else
                    {
                         m_bubbles[i].fn_hide();
                    }

               }
          }
          public override void fn_hide()
          {
               base.fn_hide();
               fnp_showOrHide();
               //if (m_realtimeUpdate)
               //{
               //     CancelInvoke("fnp_bobbleShow"); 
               //}
          }


          public void fni_login(AB_HideShow _bubble)
          {
               if (_bubble != null)
               {
                    m_bubbles.Add(_bubble);
               }
          }

          public void fni_updatePara()
          {
               if (m_realtimeUpdate && m_hideState)
               {
                    fnp_bobbleShow();
               }
          }
     }
     public interface I_bubleMagFind
     {
          void fni_login(AB_HideShow _bubble);
     }
     /// <summary>
     /// 显示数据的刷新
     /// </summary>
     public interface I_updatePara
     {
          /// <summary>
          /// 冒泡显示数据的刷新
          /// </summary>
          void fni_updatePara();
     }

}