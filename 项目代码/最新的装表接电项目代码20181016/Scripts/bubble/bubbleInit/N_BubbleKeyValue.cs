using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 冒泡类型的单位显示和档位值转换成显示文字的功能组件
     /// </summary>
     public class N_BubbleKeyValue : AB_BubbleKeyValue
     {
          protected override void Start()
          {
               base.Start();
               fnp_load();
          }
          Dictionary<string, Dictionary<string, string>> m_bubbleDetail =
               new Dictionary<string, Dictionary<string, string>>();
          protected string m_type = "";
          //protected BubbleDetail m_bubbleDetail = null;
          protected override void fnp_load()
          {
               AB_Name t_name = GetComponent<AB_Name>();
               if (t_name == null)
               {
                    Destroy(this);
                    return;
               }
               string t_foldname = t_name.m_ID.ToString();

               Object t_date = Resources.Load("bubble_detail/" + "bd_" + t_foldname);
               if (t_date != null)
               {
                    BubbleDetail t_bubbleDetail = t_date as BubbleDetail;
                    if (t_bubbleDetail != null)
                    {
                         for (int i = 0; i < t_bubbleDetail.m_KeyValues.Count; i++)
                         {
                              string t_key = t_bubbleDetail.m_KeyValues[i].m_stateValue;
                              if (!m_bubbleDetail.ContainsKey(t_key))
                              {
                                   m_type = t_bubbleDetail.m_type;
                                   m_bubbleDetail.Add(t_key, new Dictionary<string, string>());
                                   List<KeyString> t_kws = t_bubbleDetail.m_KeyValues[i].m_ShowValue.m_words;
                                   for (int j = 0; j < t_kws.Count; j++)
                                   {
                                        m_bubbleDetail[t_key].Add(t_kws[j].m_key, t_kws[j].m_value);
                                   }
                                   //m_bubbleDetail.Add(t_key,
                                   //                   t_bubbleDetail.m_KeyValues[i].m_ShowValue);
                              }
                              else
                              {
                                   Debug.Log("<color=red>t_foldname:包含相同的键值对</color>");
                              }
                         }
                    }
               }
               else { Destroy(this); }


          }
          /// <summary>
          /// 返回的显示值
          /// </summary>
          public string m_showValue = "";
          public override string fn_getValue(string _stateValue)
          {
               fnp_getdata(_stateValue);
               return m_showValue;
          }
          /// <summary>
          /// 对输入值的加工处理，是值类型，加入单位，单位也分公制，英制
          /// 是名称类型，把输入的值转换成语言文字，根据语音来选择具体的显示名称
          /// </summary>
          /// <param name="_input"></param>
          protected virtual void fnp_getdata(string _input)
          {
               if (m_bubbleDetail != null)
               {

                    if (m_type == "unit")
                    {//单位类型
                         if (m_bubbleDetail.ContainsKey("0"))
                         {
                              if (m_bubbleDetail["0"].ContainsKey(S_setting.m_unit))
                              {
                                   m_showValue = _input + m_bubbleDetail["0"][S_setting.m_unit];
                              }
                              else if (!m_bubbleDetail["0"].ContainsKey(S_setting.m_unit))
                              {
                                   m_showValue = _input +
                                        ((m_bubbleDetail["0"].ContainsKey("default")) ? m_bubbleDetail["0"]["default"] : "");
                              }
                              else
                              {
                                   m_showValue = _input;
                              }
                         }
                    }

                    if (m_type == "name")
                    {//名称类型的转换
                         string t_language = S_SceneMessage.Instance.fn_getLanguage();
                         //t_language = (t_language == "Chinese") ? "ch" : t_language;
                         if (m_bubbleDetail.ContainsKey(_input))
                         {
                              if (m_bubbleDetail[_input].ContainsKey(t_language))
                              {
                                   m_showValue = m_bubbleDetail[_input][t_language];
                              }

                         }
                         else
                         {
                              m_showValue = _input;
                         }
                    }
               }

          }
     }

}