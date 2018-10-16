using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 公制，英制的切换
     /// </summary>
     public class N_TriggerSwitch02 : N_TriggerSwitch
     {
          protected Text m_metric, m_inch;
          protected override void fnp_do()
          {
               base.fnp_do();
               if (m_metric == null || m_inch == null)
               {
                    m_metric = transform.FindInChild("metric").GetComponent<Text>();
                    m_inch = transform.FindInChild("british").GetComponent<Text>();
               }
               if (m_metric != null && m_inch != null)
               {
                    fnp_setColor();
               }

          }
          protected void fnp_setColor()
          {
               Color t_black = new Color(0f, 0f, 0f);
               Color t_green = new Color(0f, 1f, 0f);
               m_metric.color = m_bool ? t_green : t_black;
               m_inch.color = !m_bool ? t_green : t_black;
               //公共变量变化
               UIdata.bumpui_unit_type = m_bool ? unit_system_type.mertric : unit_system_type.british;
               //更新单位
               BumpParam_manager.Instance.fn_update_bump_page();
          }
     } 
}
