using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GasPowerGeneration
{
     public class N_cdpValue : AB_cdpValue
     {
          protected override void Start()
          {
               base.Start();
               AB_Name t_name = GetComponent<N_Name>();
               if (t_name != null)
               {
                    S_CDPControl.Instance.fn_logCDPSet(t_name.m_ID, this);
               }
          }
          /// <summary>
          /// 变化参数类型
          /// </summary>
          public string m_type;
          /// <summary>
          /// 选择项
          /// </summary>
          public string[] m_values;
          public override void fn_setValue(string _type, string _values)
          {
               m_type = _type;
               m_values = _values.Split(new[] { "|" },
                    StringSplitOptions.RemoveEmptyEntries);
               fnp_initPara();
          }
          /// <summary>
          /// 速度
          /// </summary>
          public float[] m_speed = new float[3];
          public override void fn_setSpeed(string _speed1, string _speed2)
          {
               float.TryParse(_speed1, out m_speed[0]);
               string[] t_speed2;
               t_speed2 = _speed2.Split(new[] { "|" },
                    StringSplitOptions.RemoveEmptyEntries);
               float.TryParse(t_speed2[0], out m_speed[1]);
               float.TryParse(t_speed2[1], out m_speed[2]);
          }
          /// <summary>
          /// 数值范围
          /// </summary>
          public Vector2 m_range;
          /// <summary>
          /// 如果是数字范围转换成最大最小值
          /// </summary>
          protected virtual void fnp_initPara()
          {
               if (m_type == "para")
               {
                    m_range = new Vector2(float.Parse(m_values[0]), float.Parse(m_values[1]));
               }
          }
          /// <summary>
          /// 获取item的实际状态值
          /// </summary>
          /// <returns></returns>
          public override string fni_getValue()
          {
               //return base.fni_getValue();
               return fnp_getStateMainValue();
          }

          protected string fnp_getStateMainValue()
          {
               AB_State t_state = GetComponent<AB_State>();
               if (t_state != null)
               {
                    return t_state.fn_getMainValue();
               }
               return "";
          }


     }

}