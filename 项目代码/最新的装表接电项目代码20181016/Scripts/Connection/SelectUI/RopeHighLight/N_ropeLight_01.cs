using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
using UnityEngine.UI;
namespace Assets.Scripts.Connection.SelectUI.RopeHighLight
{
     /// <summary>
     /// 处理拆线模式时，在选择拆线时，提示问题显示：拆线中
     /// </summary>
     class N_ropeLight_01 : N_ropeLight
     {
          protected Text m_txt = null;

          protected override void Start()
          {
               base.Start();
               if (m_txt==null)
               {
                    m_txt = GetComponentInChildren<Text>();
               }
          }
          public override void fn_highlight()
          {
               //base.fn_highlight();
               if (m_txt!=null)
               {
                    m_txt.text = "拆线中";
               }
          }
          public override void fn_default()
          {
               //base.fn_default();
               if (m_txt != null)
               {
                    m_txt.text = "拆线";
               }
          }
     }
}
