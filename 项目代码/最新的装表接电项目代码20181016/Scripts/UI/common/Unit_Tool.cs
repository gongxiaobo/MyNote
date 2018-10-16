using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 单位转换工具类
     /// </summary>
     public static class Unit_Tool
     {

          /// <summary>
          /// 根据公英制获取参数信息,还没有对单位进行转换
          /// </summary>
          /// <param name="type">单位类型</param>
          /// <param name="unit_value">当前需要转换的值</param>
          /// <returns>转换后的值</returns>
          public static string fn_get_unit_value(unit_type type, string unit_value)
          {
               if (UIdata.unit_type== unit_system_type.mertric)
               {//公制直接转换
                    return unit_value;
               }
               float value;
               if (float.TryParse(unit_value, out value)==false)
               {
                    Debug.Log("传入参数有误");
                    return unit_value;
               }

               switch (type)
               {
                    case unit_type.current:
                         return value.ToString();
                    case unit_type.humid:
                         return value.ToString();
                    case unit_type.temperature:
                         return value.ToString();
                    case unit_type.voltage:
                         return value.ToString();
                    case unit_type.hour:
                         return value.ToString();
                    case unit_type.rate:
                         return value.ToString();
                    case unit_type.rpm:
                         return value.ToString();
                    case unit_type.kw:
                         return value.ToString();
                    case unit_type.kWh:
                         return value.ToString();
                    case unit_type.kpa:
                         return value.ToString();
                    case unit_type.spm:
                         return value.ToString();
                    case unit_type.MPa:
                         return value.ToString();
                    case unit_type.m3min:
                         return value.ToString();
                    case unit_type.m3:
                         return value.ToString();
                    case unit_type.mm:
                         return value.ToString();
                    case unit_type.Nm:
                         return value.ToString();
                    case unit_type.second:
                         return value.ToString();
                    case unit_type.strokes:
                         return value.ToString();
                    default:
                         break;
               }
               Debug.Log("<color=red>未转换英制成功：</color>" + unit_value+" - " + type);
               return unit_value;
          }

          /// <summary>
          /// 公制英制单位符号的枚举值替换成字符
          /// </summary>
          /// <param name="type">unit_type</param>
          /// <returns>单位</returns>
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
                             case unit_type.spm:
                                 return "SPM";
                             case unit_type.MPa:
                                 return "MPa";
                             case unit_type.m3min:
                                 return "m3/min";
                             case unit_type.m3:
                                 return "m3";
                             case unit_type.mm:
                                 return "mm";
                             case unit_type.Nm:
                                 return "Nm";
                             case unit_type.second:
                                 return "s";
                             case unit_type.strokes:
                                 return "stroke";
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
                             case unit_type.spm:
                                 return "SPM";
                             case unit_type.MPa:
                                 return "MPa";
                             case unit_type.m3min:
                                 return "m3/min";
                             case unit_type.m3:
                                 return "m3";
                             case unit_type.mm:
                                 return "mm";
                             case unit_type.Nm:
                                 return "Nm";
                             case unit_type.second:
                                 return "s";
                             case unit_type.strokes:
                                 return "stroke";
                              default:
                                   return "null";
                         }

                    default:
                         return "类型有误";
               }

          }


          /// <summary>
          /// 根据公英制获取参数信息
          /// </summary>
          /// <param name="type"></param>
          /// <param name="unit_value"></param>
          /// <returns></returns>
          public static string fn_get_bumpuiunit_value(unit_type type, string unit_value)
          {
               if (UIdata.bumpui_unit_type== unit_system_type.mertric)
               {
                    return unit_value;
               }
              float value;
              if (float.TryParse(unit_value, out value)==false)
              {

                   Debug.Log("<color=red>传入参数有误</color>");
                   return unit_value;
              }
              switch (type)
              {
                   case unit_type.current:
                        return (value * 2).ToString();
                   case unit_type.humid:
                        return value.ToString();
                   case unit_type.temperature:
                        return value.ToString();
                   case unit_type.voltage:
                        return value.ToString();
                   case unit_type.hour:
                        return value.ToString();
                   case unit_type.rate:
                        return value.ToString();
                   case unit_type.rpm:
                        return value.ToString();
                   case unit_type.kw:
                        return value.ToString();
                   case unit_type.kWh:
                        return value.ToString();
                   case unit_type.kpa:
                        return value.ToString();
                   case unit_type.spm:
                        return value.ToString();
                   case unit_type.MPa:
                        return value.ToString();
                   case unit_type.m3min:
                        return value.ToString();
                   case unit_type.m3:
                        return value.ToString();
                   case unit_type.mm:
                        return value.ToString();
                   case unit_type.Nm:
                        return value.ToString();
                   case unit_type.second:
                        return value.ToString();
                   case unit_type.strokes:
                        return value.ToString();
                   case unit_type.Null:
                        return value.ToString();
                   default:
                        break;

              }
              return unit_value;
          }


          public static string fn_get_bumpuiunit_type(unit_type type)
          {
              switch (UIdata.bumpui_unit_type)
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
                          case unit_type.spm:
                              return "SPM";
                          case unit_type.MPa:
                              return "MPa";
                          case unit_type.m3min:
                              return "m3/min";
                          case unit_type.m3:
                              return "m3";
                          case unit_type.mm:
                              return "mm";
                          case unit_type.Nm:

                              return "Nm";
                          case unit_type.second:
                              return "s";
                          case unit_type.strokes:
                              return "stroke";
                          case unit_type.Null:
                              return "";
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
                          case unit_type.spm:
                              return "SPM";
                          case unit_type.MPa:
                              return "MPa";
                          case unit_type.m3min:
                              return "m3/min";
                          case unit_type.m3:
                              return "m3";
                          case unit_type.mm:
                              return "mm";
                          case unit_type.Nm:
                              return "Nm";
                          case unit_type.second:
                              return "s";
                          case unit_type.strokes:
                              return "stroke";
                          case unit_type.Null:
                              return "";
                          default:
                              return "null";
                      }

                  default:
                      return "类型有误";
              }


          }
     }

}