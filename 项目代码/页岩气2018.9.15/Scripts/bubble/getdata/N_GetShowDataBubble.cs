using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 冒泡类型的文字显示和隐藏
     /// </summary>
     public class N_GetShowDataBubble : N_GetShowData
     {
          //ui text
          public Text m_theText = null;
          public override void fn_showDate()
          {
               base.fn_showDate();
               if (m_theText != null)
               {
                    m_theText.text = m_mainValue;
               }
               else
               {
                    fnp_autoFindText();
               }
          }

          private void fnp_autoFindText()
          {
               Transform t_txt = transform.FindInChild("Text");
               if (t_txt != null)
               {
                    Text t_text = t_txt.GetComponent<Text>();
                    if (t_text != null)
                    {
                         m_theText = t_text;
                         if (m_theText != null)
                         {
                              m_theText.text = m_mainValue;
                         }
                    }
               }
          }
          public override void fn_hideDtae()
          {
               base.fn_hideDtae();
               if (m_theText != null)
               {
                    m_theText.text = m_mainValue;
               }
               else
               {
                    fnp_autoFindText();
               }
          }


     }

}