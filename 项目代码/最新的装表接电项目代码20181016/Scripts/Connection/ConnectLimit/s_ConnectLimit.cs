using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.ConnectLimit
{
     /// <summary>
     /// 操作权限问题
     /// </summary>
     public static class s_ConnectLimit
     {
          /// <summary>
          /// 处理接口和划片类型，是否是当前步骤可以操作的
          /// </summary>
          /// <param name="_handle"></param>
          /// <returns></returns>
          public static bool fn_canTrigger(AB_HandleEvent _handle)
          {
               //如果是培训模式
               if (S_SceneMessage.Instance.m_TableMode== TableMode.E_TableMode.e_learn||
                    S_SceneMessage.Instance.m_TableMode == TableMode.E_TableMode.e_null)
               {
                    return false;
               }
               //在训练，故障，新手引导,需要区分柜体，一次只能操作一个柜体的设备
               int t_stepID = 0;
               if (int.TryParse(S_SceneMessage.Instance.m_TableStep,out t_stepID))
               {
                    switch (t_stepID)
                    {
                         case 43://高供高计
                              if (_handle.m_MachineName!= E_MachineName.e_machine_42)
                              {
                                   return false;
                              }
                              break;
                         case 44://高供低计
                              if (_handle.m_MachineName != E_MachineName.e_machine_43)
                              {
                                   return false;
                              }
                              break;
                         case 45://低供低计
                              if (_handle.m_MachineName != E_MachineName.e_machine_44)
                              {
                                   return false;
                              }
                              break;
                         case 47://新手
                              if (_handle.m_MachineName != E_MachineName.e_machine_42)
                              {
                                   return false;
                              }
                              break;
                         case 61://故障模式
                         case 62:
                         case 63:
                         case 64:
                         case 65:
                         case 66:
                              if (_handle.m_MachineName != E_MachineName.e_machine_42)
                              {
                                   return false;
                              }

                              break;
                         default:
                              break;
                    }
               }
               

               return true;
          }
          public static bool fn_canUITrigger()
          {
               //如果是培训模式
               if (S_SceneMessage.Instance.m_TableMode == TableMode.E_TableMode.e_learn ||
                    S_SceneMessage.Instance.m_TableMode == TableMode.E_TableMode.e_null)
               {
                    return false;
               }
               return true;
          }
     
     }
}
