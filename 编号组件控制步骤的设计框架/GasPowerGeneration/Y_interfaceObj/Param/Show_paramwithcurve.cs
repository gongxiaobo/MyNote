using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_paramwithcurve : Show_paramwithchange
     {
          public AnimationCurve curve;
          float index_f = 0;

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
          IEnumerator ValueGrowth(float from_value, float maxvalue, float change_range, float change_rate = 1)
          {
               while (from_value < maxvalue)
               {
                    yield return new WaitForSeconds(change_rate);
                    from_value += curve.Evaluate(index_f);
                    index_f += 1;
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
          IEnumerator ValueReduce(float from_value, float minvalue, float change_range, float change_rate = 1)
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
     }

}