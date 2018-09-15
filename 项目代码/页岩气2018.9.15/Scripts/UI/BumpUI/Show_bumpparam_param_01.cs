using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 处理运行时间的问题
     /// </summary>
     public class Show_bumpparam_param_01 : Show_bumpparam_param
     {
          //public unit_type unittype;
          //private Text param;
          //private Text unit;
          protected Text m_hour, m_minute, m_second;
          // Use this for initialization
          void Start()
          {
               //Transform para_tran = transform.Find("param");
               //if (para_tran != null)
               //     param = para_tran.GetComponent<Text>();
               //Transform unit_tran = transform.Find("unit");
               //if (unit_tran != null)
               //     unit = unit_tran.GetComponent<Text>();
               m_hour = transform.FindInChild("param_h").GetComponent<Text>();
               m_minute = transform.FindInChild("param_m").GetComponent<Text>();
               m_second = transform.FindInChild("param_s").GetComponent<Text>();

          }

          protected override void fn_show_number(string value)
          {
               //base.fn_show_number(value);
               float _level;
               if (float.TryParse(value, out _level) == false)
               {
                    Debug.Log("<color=red>float.TryParse false </color>" + value);
                    return;
               }
               string t_h,t_m,t_s;
               s_secondToH.fns_HMStoString(_level,out t_h,out t_m,out t_s);
               m_hour.text = float.Parse(t_h) >= 99f ? "99" : t_h;
               m_minute.text = t_m;
               m_second.text = t_s;

               //if (param != null)
               //     param.text = Unit_Tool.fn_get_bumpuiunit_value(unittype, value);
               //if (unit != null)
               //     unit.text = Unit_Tool.fn_get_bumpuiunit_type(unittype);
          }

          
     } 
}
