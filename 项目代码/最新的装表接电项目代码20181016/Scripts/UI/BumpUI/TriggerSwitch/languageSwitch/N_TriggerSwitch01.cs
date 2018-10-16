using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 泵的操作UI的开始界面的触发类型的按钮
     /// </summary>
     public class N_TriggerSwitch01 : N_TriggerSwitch
     {
          protected Text m_ch, m_eng;
          protected override void fnp_do()
          {
               base.fnp_do();
               if (m_ch==null|| m_eng==null)
               {
                    m_ch = transform.FindInChild("ch").GetComponent<Text>();
                    m_eng = transform.FindInChild("eng").GetComponent<Text>(); 
               }
               if (m_ch != null && m_eng != null)
               {
                    fnp_setColor();
               }
               
          }
          protected void fnp_setColor()
          {
               Color t_black = new Color(0f, 0f, 0f);
               Color t_green = new Color(0f, 1f, 0f);
               m_ch.color = m_bool ? t_green : t_black;
               m_eng.color = !m_bool ? t_green : t_black;
               BumpUI_manager.Instance.m_bumpLanguage = m_bool ? "ch" : "eng";
               BumpUI_manager.Instance.fn_update_language();
          }

     } 
}
