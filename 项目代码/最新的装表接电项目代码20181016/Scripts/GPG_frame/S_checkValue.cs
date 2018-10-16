using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     ///  检查值类型是否在一个范围里
     /// </summary>
     public static class S_checkValue
     {

          public static bool fns_isArea(string _tableDate)
          {
               //如果里面有特殊字符就返回ture
               if (_tableDate.Contains("|"))
               {
                    return true;
               }
               //只包含一个值的情况
               return false;
          }
          /// <summary>
          /// 检查值类型是否在一个范围里
          /// </summary>
          /// <param name="_scenevalue">场景中item 的值</param>
          /// <param name="_tablevalue">表中的配置值</param>
          /// <param name="_valuetype">item 的值类型</param>
          /// <returns>true 表示场景值和表中配置值通过</returns>
          public static bool fns_isInArea(string _scenevalue, string _tablevalue, E_valueType _valuetype)
          {
               if (fns_isArea(_tablevalue))
               {//有区间值
                    string[] s_plit = _tablevalue.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    if (_valuetype == E_valueType.e_inter_floatvalue)
                    {
                         float t_scenevalue = 0f;
                         float.TryParse(_scenevalue, out t_scenevalue);
                         float t_min = 0f;
                         float.TryParse(s_plit[0], out t_min);
                         float t_max = 1f;
                         float.TryParse(s_plit[1], out t_max);
                         if (t_scenevalue >= t_min && t_scenevalue <= t_max)
                         {
                              return true;
                         }
                         else
                         {
                              return false;
                         }

                    }
                    else if (_valuetype == E_valueType.e_inter_level)
                    {
                         int t_scenevalue = 0;
                         int.TryParse(_scenevalue, out t_scenevalue);
                         int t_min = 0;
                         int.TryParse(s_plit[0], out t_min);
                         int t_max = 10;
                         int.TryParse(s_plit[1], out t_max);
                         if (t_scenevalue >= t_min && t_scenevalue <= t_max)
                         {
                              return true;
                         }
                         else
                         {
                              return false;
                         }
                    }
               }
               else
               {//无区间值
                    if (_scenevalue.Equals(_tablevalue))
                    {
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }



               return false;
          }
     }

}