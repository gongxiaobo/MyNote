using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 是否是拆线
     /// </summary>
     public class N_UILevel01_04 : N_UILevel01
     {
          /// <summary>
          /// true为正在执行拆卸操作
          /// </summary>
          public bool m_isDisLine = false;
          public override void fni_receive(SMsg _reveive)
          {
               base.fni_receive(_reveive);
               if (_reveive.m_ID==10)
               {
                    m_isDisLine = !m_isDisLine;
                    S_selectUI.Instance.m_isDisLine = m_isDisLine;
                              
               }
          }

     } 
}
