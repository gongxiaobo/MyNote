using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     public class N_subsection : AB_subsection
     {
          bool m_isok = true;
          Action<float> m_callback = null;
          public override void fn_init(float _start, float _end, float _subnum)
          {
               if (_start >= _end)
               {
                    m_isok = false;
               }
               m_startValue = _start;
               m_endValue = _end;
               m_subNum = _subnum;
               if (m_isok)
               {
                    fnp_split();
               }
          }
          public override void fn_init(float _start, float _end, float _subnum, System.Action<float> _call)
          {
               fn_init(_start, _end, _subnum);
               m_callback = _call;
          }
          public override float fn_filter(float _value)
          {
               for (int i = 0; i < m_specDot.Length; i++)
               {
                    if (_value - m_specDot[i] < (m_subValue * 0.5f))
                    {
                         return m_specDot[i];
                    }
               }
               return 0f;
          }
          public override void fn_inputValue(float _input)
          {

               //Debug.Log("<color=red>_input:</color>" + _input);

               //if (_input-m_filterValue<(m_subValue * 0.5f))
               //{
               //     return;
               //}
               //float t_thenew = 0f;
               for (int i = 0; i < m_specDot.Length; i++)
               {
                    //if (_input - m_specDot[i] < (m_subValue * 0.5f))
                    //{
                    //     //return m_specDot[i];
                    //     t_thenew = m_specDot[i];
                    //     if (m_filterValue!=t_thenew)
                    //     {
                    //          m_filterValue = t_thenew;
                    //          if (m_callback!=null)
                    //          {
                    //               m_callback(m_filterValue);
                    //          }
                    //     }
                    //     break;
                    //}

                    if (i == 0)
                    {
                         if ((i + 1) == m_specDot.Length)
                         {
                              if (m_callback != null)
                              {
                                   m_callback(m_specDot[i]);
                              }
                              break;
                         }
                         else
                         {
                              float t_half = (m_specDot[i] + m_specDot[i + 1]) * 0.5f;
                              if (t_half >= _input)
                              {
                                   if (m_callback != null)
                                   {
                                        m_callback(m_specDot[i]);
                                   }
                                   break;
                              }
                              else if (_input > t_half && _input <= m_specDot[i + 1])
                              {
                                   if (m_callback != null)
                                   {
                                        m_callback(m_specDot[i + 1]);
                                   }
                                   break;
                              }
                         }
                    }
                    else if (i <= (m_specDot.Length - 2))
                    {
                         float t_half = (m_specDot[i] + m_specDot[i + 1]) * 0.5f;
                         if (t_half >= _input)
                         {
                              if (m_callback != null)
                              {
                                   m_callback(m_specDot[i]);
                              }
                              break;
                         }
                         else if (_input > t_half && _input <= m_specDot[i + 1])
                         {
                              if (m_callback != null)
                              {
                                   m_callback(m_specDot[i + 1]);
                              }
                              break;
                         }
                    }

               }


          }
          /// <summary>
          /// 拆分后的数据点
          /// </summary>
          public float[] m_specDot;
          //数据点之间的距离
          public float m_subValue = 0.1f;
          /// <summary>
          /// 拆分
          /// </summary>
          protected void fnp_split()
          {
               float t_length = m_endValue - m_startValue;
               m_subValue = t_length / m_subNum;
               m_specDot = new float[(int)m_subNum + 1];
               for (int i = 0; i < m_specDot.Length; i++)
               {
                    m_specDot[i] = m_startValue + i * m_subValue;
               }
          }


     }

}