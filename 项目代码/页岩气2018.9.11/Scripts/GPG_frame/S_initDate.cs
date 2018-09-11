using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 处理初始化的随机值
     /// </summary>
     public static class S_initDate
     {
          public static string fns_getInit(int _id)
          {
               switch (_id)
               {
                    case 100:

                         return Random.Range(1, 5).ToString();
                    case 101:

                         return Random.Range(22, 28).ToString();
                    case 102:

                         return Random.Range(25, 30).ToString();
                    case 103:

                         return (Random.Range(0, 100) > 50 ? "1" : "2");
                    case 104:

                         return (Random.Range(0, 100) > 50 ? "1" : "2");
                    case 105:

                         return (Random.Range(0, 100) > 50 ? "1" : "2");
                    case 106:

                         return (Random.Range(0, 100) > 50 ? "1" : "2");
                    case 107:

                         return (Random.Range(0, 100) > 50 ? "on" : "off");
                    case 108:

                         return (Random.Range(0, 100) > 50 ? "on" : "off");
                    //科目二
                    case 112:
                         return Random.Range(240, 250).ToString();
                    case 113:
                         return Random.Range(0, 2).ToString();
                    case 114:
                         return Random.Range(223, 336).ToString();
                    case 115:
                         return Random.Range(0.1f, 0.5f).ToString();
                    case 116:
                         return Random.Range(242, 246).ToString();
                    case 117:
                         return Random.Range(0, 3).ToString();
                    //科目7 
                    //进气压力表
                    case 1002:
                         return Random.Range(250, 350).ToString();
                    case 1003:
                         return Random.Range(250, 350).ToString();
                    case 1004:
                         return Random.Range(100, 350).ToString();
                    case 1102:
                         return Random.Range(200, 350).ToString();
                    case 1103:
                         return Random.Range(200, 350).ToString();
                    case 1104:
                         return Random.Range(100, 350).ToString();
                    case 1202:
                         return Random.Range(200, 350).ToString();
                    case 1203:
                         return Random.Range(200, 350).ToString();
                    case 1204:
                         return Random.Range(100, 350).ToString();
                    case 903:
                    //return (Random.Range(0, 100) > 50 ? "on" : "off");
                    case 904:
                    //return Random.Range(100, 350).ToString();
                    case 902:
                         return (Random.Range(0, 100) > 50 ? "on" : "off");

                    #region //燃气机
                    case 1038:
                         return Random.Range(1, 100).ToString();
                    case 1039:
                         return Random.Range(0, 100).ToString();
                    case 1040:
                         return Random.Range(1, 4).ToString();
                    case 1138:
                         return Random.Range(1, 100).ToString();
                    case 1139:
                         return Random.Range(0, 100).ToString();
                    case 1140:
                         return Random.Range(1, 4).ToString();
                    case 1238:
                         return Random.Range(1, 100).ToString();
                    case 1239:
                         return Random.Range(0, 100).ToString();
                    case 1240:
                         return Random.Range(1, 4).ToString();
                    #endregion
               }
               return "";
          }
          /// <summary>
          /// 返回item类型的状态段的名称
          /// </summary>
          /// <param name="_valueType"></param>
          /// <returns></returns>
          public static string fns_getStateValueName(E_valueType _valueType)
          {
               switch (_valueType)
               {
                    case E_valueType.e_inter_onoff:
                         return "onoff";

                    case E_valueType.e_inter_floatvalue:
                         return "floatvalue";

                    case E_valueType.e_inter_level:
                         return "level";
                    case E_valueType.e_inter_string:
                         return "string";
                    default:
                         return "";
               }

          }
          public static string fns_getStateValueName(E_StateValueType _valueType)
          {
               switch (_valueType)
               {
                    case E_StateValueType.e_electric:
                         return ("electric");

                    case E_StateValueType.e_lock:
                         return ("lock");

                    case E_StateValueType.e_check:
                         return ("check");

                    case E_StateValueType.e_onoff:
                         return ("onoff");

                    case E_StateValueType.e_floatvalue:
                         return ("floatvalue");

                    case E_StateValueType.e_level:
                         return ("level");
                    case E_StateValueType.e_string:
                         return "string";
                    default:
                         break;
               }
               return "";
          }

          public static E_mode fns_getMode(string _mode)
          {
               switch (_mode)
               {
                    case "free":
                         return E_mode.e_free;
                    case "train":
                         return E_mode.e_train;
                    case "test":
                         return E_mode.e_test;

               }
               return E_mode.e_null;
          }



     }

}