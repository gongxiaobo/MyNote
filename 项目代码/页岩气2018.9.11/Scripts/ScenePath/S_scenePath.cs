using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 场景名称的获取
     /// </summary>
     public static class S_scenePath
     {
          /// <summary>
          /// 获取场景的名称
          /// </summary>
          /// <param name="_level"></param>
          /// <returns></returns>
          public static string fns_getSceneName(E_level _level)
          {
               switch (_level)
               {
                    case E_level.e_null:
                         return "";
                    case E_level.e_loading:
                         return "Loading";
                    case E_level.e_select:
                         return "Select_01";
                    //case E_level.e_classroom:
                    //     return "classroom_V02";
                    //case E_level.e_meetingroom:
                    //     return "meetingroom_V01";
                    //case E_level.e_emei:
                    //     return "emei_Show";
                    default:
                         return "";
               }
          }
     }
     public enum E_level : byte
     {
          e_null = 0,
          e_start = 1,
          /// <summary>
          /// 登陆场景
          /// </summary>
          e_loading = 2,
          /// <summary>
          /// 选择场景
          /// </summary>
          e_select = 3,

     } 
}