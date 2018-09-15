using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Show_paramwithchange : AB_Param
     {

          [EnumLabel("单位类型")]
          public unit_type unittype;
          [Tooltip("显示参数text")]
          private Text param_text;
          [Tooltip("显示单位text")]
          private Text unit_text;

          internal int int_value;
          internal float float_value;

          public Vector2 min_max;
          public Vector2 growth_reduce_range;

          public List<float> send_result_value = new List<float>();

          public bool random_change = false;
          protected override void Start()
          {
               base.Start();
          }
          protected override void OnEnable()
          {
               base.OnEnable();
               param_text = TransformHelper.FindChild(transform, "param").GetComponent<Text>();
               unit_text = TransformHelper.FindChild(transform, "unit").GetComponent<Text>();
          }

          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_level > min_max.y)
                    _level = (int)min_max.y;
               else if (_level < min_max.x)
                    _level = (int)min_max.x;
               if (_controlType == E_ControlType.e_init)
               {
                    fn_show_param(_level);
                    fn_show_unit();
                    // GetComponentInChildren<N_Pointer>().fn_inputValue(_level);
               }
               else
               {
                    fn_show_param(_level);
                    fn_show_unit();
                    StateValueString state = (StateValueString)handler.fn_get("floatvalue");
                    state.m_date = _level.ToString();
                    handler.fn_set(state);

               }
          }

          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_level > min_max.y)
                    _level = min_max.y;
               else if (_level < min_max.x)
                    _level = min_max.x;
               if (_controlType == E_ControlType.e_init)
               {
                    fn_show_param(_level);
                    fn_show_unit();
                    // GetComponentInChildren<N_Pointer>().fn_inputValue(_level);
               }
               else
               {
                    fn_show_param(_level);
                    fn_show_unit();
                    StateValueString state = (StateValueString)handler.fn_get("floatvalue");
                    state.m_date = _level.ToString();
                    handler.fn_set(state);
               }
          }



          /// <summary>
          /// 显示参数单位
          /// </summary>
          /// <param name="value"></param>
          public override void fn_show_param(int value)
          {
               int_value = value;
               if (random_change)
               {
                    int temp = Random.Range(1, 5);
                    value += temp;
               }
               if (param_text != null && unittype != null)
                    param_text.text = Unit_Tool.fn_get_unit_value(unittype, value.ToString());
          }
          /// <summary>
          /// 显示参数单位
          /// </summary>
          /// <param name="value"></param>
          public override void fn_show_param(float value)
          {
               float_value = value;
               if (random_change)
               {
                    int a = Random.Range(1, 100);
                    float temp = (float)(a * 0.01);
                    value += temp;
               }
               if (param_text != null && unittype != null)
                    param_text.text = Unit_Tool.fn_get_unit_value(unittype, value.ToString("0.00"));
          }
          /// <summary>
          /// 显示参数单位
          /// </summary>
          /// <param name="value"></param>
          public override void fn_show_unit()
          {
               if (param_text != null && unittype != null)
                    unit_text.text = Unit_Tool.fn_get_unit_type(unittype);
          }

          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_statename == "electric")
               {
                    if (_value == "con")
                    {
                         StartCoroutine(ValueGrowth(float_value, min_max.y, growth_reduce_range.y));
                    }
                    else
                    {
                         //StartCoroutine(ValueGrowth(float_value, max_value, -range_value));
                         StartCoroutine(ValueReduce(float_value, min_max.x, growth_reduce_range.x));
                    }
               }

          }
          /// <summary>
          /// 数值变化 升高
          /// </summary>
          /// <param name="from_value">初始值</param>
          /// <param name="maxvalue">最大值</param>
          /// <param name="change_range">变化范围</param>
          /// <param name="change_rate">变化频率</param>
          /// <returns></returns>
          protected IEnumerator ValueGrowth(float from_value, float maxvalue, float change_range, float change_rate = 1)
          {
              print("起始值：" + from_value + "__" + "最大值：" + maxvalue + "__" + "增加幅度：" + change_range + "增加频率" + change_rate);
               while (from_value < maxvalue)
               {
                    yield return new WaitForSeconds(change_rate);
                    from_value += change_range;
                    print("change");
                    fn_value_handle_bigger(send_result_value, from_value);
                    if (from_value >= maxvalue)
                    {
                         from_value = maxvalue;
                         fni_level(from_value);

                         StopCoroutine("ValueGrowth");
                         yield return null;
                    }
                    fni_level(from_value);

               }
          }
          /// <summary>
          /// 数值变化 降低
          /// </summary>
          /// <param name="from_value">初始值</param>
          /// <param name="maxvalue">最大值</param>
          /// <param name="change_range">变化范围</param>
          /// <param name="change_rate">变化频率</param>
          /// <returns></returns>
          protected IEnumerator ValueReduce(float from_value, float minvalue, float change_range, float change_rate = 1)
          {
               while (from_value > minvalue)
               {
                    yield return new WaitForSeconds(change_rate);
                    from_value -= change_range;
                    print("change");
                    fn_value_handle_less(send_result_value, from_value);
                    if (from_value < minvalue)
                    {
                         from_value = minvalue;
                         fni_level(from_value);
                         StopCoroutine("ValueReduce");
                         yield return null;
                    }
                    fni_level(from_value);

               }
          }

      


          public override RectTransform fn_getrect()
          {
               RectTransform rect = GetComponent<RectTransform>();
               if (rect != null)
                    return rect;
               else return null;
          }

          /// <summary>
          /// 数值到达一定值时发送条件链消息
          /// </summary>
          /// <param name="value_list"></param>
          /// <param name="compare_value"></param>
          protected virtual void fn_value_handle_bigger(List<float> value_list, float compare_value)
          {
               if (value_list.Count == 0) return;
               if (value_list.Count == 1)
               {
                    if (compare_value >= value_list[0])
                    {
                         fnp_Result(value_list[0].ToString() + "up");
                         fnp_effect(E_effectType.e_on, E_effectName.e_light);

                    }
               }
               if (value_list.Count > 1)
               {
                    foreach (var item in value_list)
                    {
                         if (compare_value >= item)
                         {
                              fnp_Result(item.ToString() + "up");
                         }
                    }
               }
          }
          protected virtual void fn_value_handle_less(List<float> value_list, float compare_value)
          {
               if (value_list.Count == 0) return;
               if (value_list.Count == 1)
               {
                    if (compare_value <= value_list[0])
                    {
                         fnp_Result(value_list[0].ToString() + "low");
                         fnp_effect(E_effectType.e_off, E_effectName.e_light);

                    }
               }
               if (value_list.Count > 1)
               {
                    foreach (var item in value_list)
                    {
                         if (compare_value <= item)
                         {
                              fnp_Result(item.ToString() + "low");
                         }
                    }
               }
          }
     }

}