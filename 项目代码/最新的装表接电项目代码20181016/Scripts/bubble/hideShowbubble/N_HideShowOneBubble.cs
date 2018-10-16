using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 冒泡类型的数据显示
     /// </summary>
     public class N_HideShowOneBubble : N_HideShowOne
     {
          //挂载的数据提取工具类
          AB_GetShowData[] m_getshowdatas = null;
          protected override void fnp_isShow()
          {
               base.fnp_isShow();
               fnp_showOrHideDate(true);
          }

          private void fnp_showOrHideDate(bool _ishide = false)
          {
               m_getshowdatas = m_getshowdatas ?? GetComponents<AB_GetShowData>();
               if (m_getshowdatas != null)
               {
                    for (int i = 0; i < m_getshowdatas.Length; i++)
                    {
                         if (_ishide)
                         {
                              m_getshowdatas[i].fn_showDate();
                         }
                         else
                         {
                              m_getshowdatas[i].fn_hideDtae();
                         }
                    }
               }
          }
          protected override void fnp_isHide()
          {
               base.fnp_isHide();
               fnp_showOrHideDate();
          }

     }

}