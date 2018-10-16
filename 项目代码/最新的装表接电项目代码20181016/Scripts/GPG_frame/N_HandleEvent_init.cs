using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.Port;
namespace GasPowerGeneration
{
     /// <summary>
     /// 处理初始化的item处理类
     /// 初始化把值的设置和操作分开
     /// 处理其他机器发来的设置消息
     /// 处理状态值发生变化后的接口触发调用
     /// 2018.5.17 加入在初始化完成后的事件回调
     /// </summary>
     [RequireComponent(typeof(N_state))]
     public class N_HandleEvent_init : N_HandleEvent
     {
          protected override void Start()
          {
               base.Start();
               fnp_addComponent();
          }
          /// <summary>
          /// 添加条件和反射触发
          /// </summary>
          protected virtual void fnp_addComponent()
          {
               gameObject.AddComponent<N_LoadCondition>();
               gameObject.AddComponent<N_LoadResultAction>();
               gameObject.AddComponent<N_BubbleKeyValue>();
          }
          /// <summary>
          /// 控制item的接口
          /// </summary>
          protected I_Control m_thisControl = null;
          public override StateValue fn_get(string _name)
          {
               if (m_state != null)
               {
                    return m_state.fn_getValue(_name);
               }
               return null;
          }
          public override void fn_init(AB_MachineMag _mag)
          {
               base.fn_init(_mag);
               if (m_thisControl == null)
               {
                    m_thisControl = GetComponent<I_Control>();

               }
              
          }
          public override void fn_HandleMsg(AB_Message _msg)
          {
               base.fn_HandleMsg(_msg);
               if (_msg.Name == "init")
               {//初始化
                    StateValueInt t_id = (StateValueInt)_msg.fn_getContent("m_id");
                    if (t_id.m_date == m_ID.m_ID)
                    {
                         string t_state;
                         StateValueString t_initState =
                              (StateValueString)_msg.fn_getContent("m_state");
                         t_state = t_initState.m_date;
                         //设置状态值
                         if (t_initState.m_date == "rand")
                         {
                              t_state = S_initDate.fns_getInit(m_ID.m_ID);
                              m_state.fn_setValue(m_valueType, t_state);
                         }
                         else
                         {
                              if (S_SceneMessage.Instance.m_isTableModel)
                              {//装表接电模式下,接口要初始化连接线，就不赋值状态值，等待链接线后，自动附加状态值
                                   if (GetComponent<AB_PortPath>()!=null)
                                   {
                                   }
                                   else
                                   {
                                        m_state.fn_setValue(m_valueType, t_state);
                                   }
                              }
                              else
                              {
                                   m_state.fn_setValue(m_valueType, t_state);
                              }
                         }
                         //设置外观
                         fnp_initSet(t_state);
                         //初始化完成后的事件回调
                         if (m_initFinishEvent != null)
                         {
                              m_initFinishEvent();
                              m_initFinishEvent = null;
                         }
                    }
                    return;
               }
               if (_msg.Name == "check" && _msg.ToId == m_ID.m_ID)
               {//检查类型

                    m_state.fn_setValue(_msg.fn_getContent("check"));
#if UNITY_EDITOR
                    m_state.fn_debugContent(); 
#endif
                    return;
               }
               //处理其他机器发来的设置消息
               if (_msg.Name == "set")
               {
                    if (_msg.ToId == m_ID.m_ID)
                    {

                         string t_valueType = S_initDate.fns_getStateValueName(m_state.m_ItemValueType);

                         StateValueString t_value = _msg.fn_getContent(t_valueType) as StateValueString;
                         //设置外观
                         if (t_value != null)
                         {//主状态值
                              fnp_initSet(t_value.m_date, E_ControlType.e_normal);
                              //Debug.Log(m_ID.m_ID + "<color=red>被设置值:</color>" + t_value.m_date);
                              //fnp_setStateOver(t_valueType);
                         }
                         else
                         {//其他类型的状态
                              fnp_setState(_msg);
                         }



                    }
#if UNITY_EDITOR
                    m_state.fn_debugContent();
#endif

                    return;
               }

          }
          protected virtual void fnp_setState(AB_Message _msg)
          {
               StateValue[] t_value = _msg.fn_getMessageValue();
               for (int i = 0; i < t_value.Length; i++)
               {
                    StateValueString t_ss = t_value[i] as StateValueString;
                    if (t_ss == null)
                    {
                         continue;
                    }
                    switch (t_value[i].Name)
                    {
                         case "check":

                              //if (t_ss.m_date!=m_state.fn_getOtherValue(t_value[i].Name))
                              //{
                              //     m_state.fn_setValue(t_value[i]);
                              //     fnp_setStateOver(t_value[i].Name, t_ss.m_date); 
                              //}
                              m_state.fn_setValue(t_value[i]);
                              fnp_setStateOver(t_value[i].Name, t_ss.m_date);

                              break;
                         case "lock":
                              //if (t_ss.m_date != m_state.fn_getOtherValue(t_value[i].Name))
                              //{
                              //     m_state.fn_setValue(t_value[i]);
                              //     fnp_setStateOver(t_value[i].Name, t_ss.m_date); 
                              //}
                              m_state.fn_setValue(t_value[i]);
                              fnp_setStateOver(t_value[i].Name, t_ss.m_date);
                              break;
                         case "electric":
                              //if (t_ss.m_date != m_state.fn_getOtherValue(t_value[i].Name))
                              //{

                              //}
                              m_state.fn_setValue(t_value[i]);
                              fnp_setStateOver(t_value[i].Name, t_ss.m_date);
                              //Debug.Log(m_ID.m_ID + "<color=red>electric被设置值:</color>" + t_ss.m_date);
                              break;
                         default:
                              break;
                    }
               }

          }
          /// <summary>
          /// 被其他机器改变状态那一个状态值后的触发
          /// </summary>
          /// <param name="_name">那一种状态被修改了</param>
          protected virtual void fnp_setStateOver(string _name, string _value)
          {
               if (m_thisControl == null)
               {
                    Debug.Log("<color=red>not find I_Control !" + m_ID.m_ID + "</color>");
                    return;
               }
               m_thisControl.fni_stateChange(_name, _value);
          }
          /// <summary>
          /// 初始化的值解析，调用相应的接口方法
          /// 例如，按钮播放动画到开的位置。
          /// </summary>
          /// <param name="_init"></param>
          protected virtual void fnp_initSet(string _init, E_ControlType _controlType = E_ControlType.e_init)
          {
               if (m_thisControl == null)
               {
                    Debug.Log("<color=red>not find I_Control !" + m_ID.m_ID + "</color>");
                    return;
               }
               if (m_state != null)
               {
                    switch (m_state.m_ItemValueType)
                    {
                         case E_valueType.e_inter_onoff:

                              if (_init == "on")
                              {
                                   m_thisControl.fni_on(_controlType);
                              }
                              else
                              {
                                   m_thisControl.fni_off(_controlType);
                              }
                              break;
                         case E_valueType.e_inter_floatvalue:
                              float t_initvalue = 0f;
                              m_thisControl.fni_level(
                                   (float.TryParse(_init, out t_initvalue)) ? t_initvalue : 0f,
                                   _controlType);
                              break;
                         case E_valueType.e_inter_level:
                              int t_intvalue = 0;
                              m_thisControl.fni_level(
                                   (int.TryParse(_init, out t_intvalue)) ? t_intvalue : 0,
                                   _controlType);
                              break;
                         case E_valueType.e_inter_string:

                              m_thisControl.fni_txt(_init, _controlType);
                              break;
                         default:
                              break;
                    }

               }

               
          }


     } 
}
