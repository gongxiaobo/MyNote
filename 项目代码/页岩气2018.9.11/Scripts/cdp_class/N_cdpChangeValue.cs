using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GasPowerGeneration
{
     /// <summary>
     /// cdp的参数修改的控制类，
     /// 实现快速增加和减少的功能
     /// </summary>
     public class N_cdpChangeValue : N_cdpValue
     {

          bool m_init = false;
          public override string fni_getValue()
          {
               if (m_init == false)
               {
                    fnp_getInitDate();
                    fnp_state(E_ControlType.e_init);
                    m_init = true;
               }
               return base.fni_getValue();
          }
          /// <summary>
          /// 现在的临时数值
          /// </summary>
          public float m_currentFloatValue = 0f;
          protected int m_stringIndex = 0;
          /// <summary>
          /// 现在的临时选项
          /// </summary>
          public string m_currentString = "";
          /// <summary>
          /// 获取初始值
          /// </summary>
          protected virtual void fnp_getInitDate()
          {
               if (m_init == true)
               {
                    return;
               }
               m_init = true;
               if (m_itemControl == null)
               {
                    m_itemControl = GetComponent<I_Control>();
               }
               string t_value = fnp_getStateMainValue();
               if (m_type == "para")
               {//如果是数值类型
                    float.TryParse(t_value, out m_currentFloatValue);
               }
               else if (m_type == "set")
               {//选项类型
                    m_currentString = t_value;
                    for (int i = 0; i < m_values.Length; i++)
                    {
                         if (m_values[i] == m_currentString)
                         {
                              m_stringIndex = i;
                              break;
                         }
                    }
                    if (m_currentString == "")
                    {
                         m_currentString = m_values[0];
                         m_stringIndex = 0;
                    }
               }

          }
          protected virtual void fnp_sendChangeValue()
          {
               if (m_callback != null)
               {
                    if (m_type == "para")
                    {//如果是数值类型
                         m_callback(m_currentFloatValue.ToString());
                    }
                    else if (m_type == "set")
                    {//选项类型
                         m_callback(m_currentString);
                    }
               }
          }
          /// <summary>
          /// 向上增加
          /// </summary>
          protected virtual void fnp_up()
          {

               Debug.Log("<color=blue>add</color>");

               if (m_type == "para")
               {//如果是数值类型

                    Debug.Log("<color=red>m_currentFloatValue:</color>" + m_currentFloatValue);

                    float t_value = m_currentFloatValue + m_speed[m_speedlevel];
                    if (t_value >= m_range.y)
                    {
                         t_value = m_range.y;
                    }
                    m_currentFloatValue = t_value;
               }
               else if (m_type == "set")
               {//选项类型
                    int t_index = m_stringIndex + (int)m_speed[m_speedlevel];
                    t_index = (t_index >= m_values.Length) ? (m_values.Length - 1) : t_index;
                    m_currentString = m_values[t_index];
               }
               fnp_sendChangeValue();
          }
          /// <summary>
          /// 向下增加
          /// </summary>
          protected virtual void fnp_down()
          {
               Debug.Log("<color=blue>substrative</color>");
               if (m_type == "para")
               {//如果是数值类型
                    float t_value = m_currentFloatValue - m_speed[m_speedlevel];
                    if (t_value <= m_range.x)
                    {
                         t_value = m_range.x;
                    }
                    m_currentFloatValue = t_value;
               }
               else if (m_type == "set")
               {//选项类型
                    int t_index = m_stringIndex - (int)m_speed[m_speedlevel];
                    t_index = (t_index <= 0) ? 0 : t_index;
                    m_currentString = m_values[t_index];
               }
               fnp_sendChangeValue();
          }
          #region speedadd
          /// <summary>
          /// 速度档位
          /// </summary>
          int m_speedlevel = 0;
          protected virtual void fnp_changeSpeed1()
          {
               m_speedlevel = 0;
          }
          protected virtual void fnp_changeSpeed2()
          {
               m_speedlevel = 1;
          }
          protected virtual void fnp_changeSpeed3()
          {
               m_speedlevel = 2;
          }
          /// <summary>
          /// 取消加速
          /// </summary>
          protected void fnp_CancelChange()
          {
               CancelInvoke("fnp_changeSpeed2");
               CancelInvoke("fnp_changeSpeed3");
               fnp_changeSpeed1();
          }
          /// <summary>
          /// 开始加速
          /// </summary>
          protected void fnp_startChange()
          {
               Invoke("fnp_changeSpeed2", 2f);
               Invoke("fnp_changeSpeed3", 5f);
          }
          #endregion

          TimeComponent m_call = null;
          Action<string> m_callback = null;
          #region UpArrow
          public override void fni_UpArrow_start(Action<string> _callback)
          {
               base.fni_UpArrow_start(_callback);
               fnp_start(_callback, fnp_up);
               //if (m_changeStart)
               //{
               //     return;
               //}
               //m_changeStart = true;
               //m_callback = _callback;
               ////找到初始值
               //fnp_getInitDate();
               ////添加间隔调用
               //m_call = gameObject.AddComponent<TimeComponent>();
               //m_call.initial(1f, fnp_up);
               ////开始计算增加速度
               //fnp_startChange();
               //fnp_up();

          }
          bool m_changeStart = false;
          private void fnp_start(Action<string> _callback, TimeCount.callFunction _updown)
          {
               if (m_changeStart)
               {
                    return;
               }
               m_changeStart = true;
               m_callback = _callback;
               //找到初始值
               fnp_getInitDate();
               //添加间隔调用
               m_call = gameObject.AddComponent<TimeComponent>();
               m_call.initial(1f, _updown);
               //开始计算增加速度
               fnp_startChange();
               _updown();
          }
          public override void fni_UpArrow_end()
          {

               base.fni_UpArrow_end();
               fnp_end();
          }

          private void fnp_end()
          {
               if (m_changeStart == false)
               {
                    return;
               }
               m_changeStart = false;
               fnp_CancelChange();
               m_call.fni_pause();
               m_call.Kill();
               m_call = null;
               fnp_sendChangeValue();
          }
          #endregion

          #region DownArrow
          public override void fni_DownArrow_start(Action<string> _callback)
          {
               base.fni_DownArrow_start(_callback);

               fnp_start(_callback, fnp_down);
          }
          public override void fni_DownArrow_end()
          {
               base.fni_DownArrow_end();
               fnp_end();
          }

          #endregion
          public override void fni_DoubleUpArrow_start(Action<string> _callback)
          {
               base.fni_DoubleUpArrow_start(_callback);
               fnp_start(_callback, fnp_up);
          }
          public override void fni_DoubleUpArrow_end()
          {
               base.fni_DoubleUpArrow_end();
               fnp_end();
          }
          public override void fni_DoubleDownArrow_start(Action<string> _callback)
          {
               base.fni_DoubleDownArrow_start(_callback);
               fnp_start(_callback, fnp_down);
          }
          public override void fni_DoubleDownArrow_end()
          {
               base.fni_DoubleDownArrow_end();
               fnp_end();
          }
          public override void fni_Confirm()
          {
               base.fni_Confirm();
               fnp_state(E_ControlType.e_normal);
          }

          private void fnp_state(E_ControlType _controlType)
          {
               if (m_itemControl == null)
               {
                    Debug.Log("<color=red>can not find I_Control</color>");
                    return;
               }
               if (m_type == "para")
               {
                    m_itemControl.fni_level(m_currentFloatValue, _controlType);
                    fnp_result(m_currentFloatValue.ToString());
               }
               else if (m_type == "set")
               {
                    m_itemControl.fni_txt(m_currentString, _controlType);
                    fnp_result(m_currentString);
               }


          }
          protected I_Control m_itemControl;
          /// <summary>
          /// 触发条件链
          /// </summary>
          protected virtual void fnp_result(string _currentValue)
          {
               //找到状态值
               AB_SendResult t_sr = new N_SendResult();
               t_sr.fn_SendResult(_currentValue, GetComponent<AB_ResultAction>(), GetComponent<AB_HandleEvent>());
          }

     }

}