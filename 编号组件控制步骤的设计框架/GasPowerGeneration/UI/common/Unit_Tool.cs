using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public static class Unit_Tool
     {

          /// <summary>
          /// 根据公英制获取参数信息
          /// </summary>
          /// <param name="type"></param>
          /// <param name="unit_value"></param>
          /// <returns></returns>
          public static string fn_get_unit_value(unit_type type, string unit_value)
          {

               float value;
               if (float.TryParse(unit_value, out value))
               {

               }
               else
                    Debug.Log("传入参数有误");
               //T value=null;
               switch (UIdata.unit_type)
               {
                    case unit_system_type.british:
                         switch (type)
                         {
                              case unit_type.temperature:

                                   break;
                              case unit_type.humid:

                                   break;


                         }
                         break;
                    case unit_system_type.mertric:
                         return value.ToString();

                    default:
                         break;
               }
               return "单位类型有误";
          }


          public static string fn_get_unit_type(unit_type type)
          {
               switch (UIdata.unit_type)
               {
                    case unit_system_type.british:
                         switch (type)
                         {
                              case unit_type.current:
                                   return "A";
                              case unit_type.humid:
                                   return "%";
                              case unit_type.temperature:
                                   return "°C";
                              case unit_type.voltage:
                                   return "V";
                              case unit_type.hour:
                                   return "h";
                              case unit_type.rate:
                                   return "Hz";
                              case unit_type.rpm:
                                   return "rpm";
                              case unit_type.kw:
                                   return "kw";
                              case unit_type.kWh:
                                   return "kWh";
                              case unit_type.kpa:
                                   return "kpa";
                              default:
                                   return "null";
                         }
                    case unit_system_type.mertric:
                         switch (type)
                         {
                              case unit_type.current:
                                   return "A";
                              case unit_type.humid:
                                   return "%";
                              case unit_type.temperature:
                                   return "°C";
                              case unit_type.voltage:
                                   return "V";
                              case unit_type.hour:
                                   return "h";
                              case unit_type.rate:
                                   return "Hz";
                              case unit_type.rpm:
                                   return "rpm";
                              case unit_type.kw:
                                   return "kw";
                              case unit_type.kWh:
                                   return "kWh";
                              case unit_type.kpa:
                                   return "kpa";
                              default:
                                   return "null";
                         }

                    default:
                         return "类型有误";
               }


          }
     }

}