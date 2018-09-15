using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 事件处理器
     /// </summary>
     public class N_HandleEvent : AB_HandleEvent
     {

          protected AB_MachineMag m_machineMag = null;
          public override void fn_HandleMsg(AB_Message _msg)
          {

          }

          public override void fn_SendMsg(AB_Message _send)
          {
               if (m_machineMag != null)
               {
                    m_machineMag.fn_ReceiveEvent(_send);
               }
          }

          public override void fn_init(AB_MachineMag _mag)
          {
               m_machineMag = _mag;
               m_ID = GetComponent<AB_Name>();
               if (m_ID == null)
               {

                    Debug.Log("<color=red>Without name!</color>");
                    return;
               }
               m_state = GetComponent<AB_State>();
               if (m_state == null)
               {
                    Debug.Log("<color=red>Without state!</color>");
                    throw new NotImplementedException();
                    //return;
               }
               //加入到全局集合中
               S_SceneMagT1.Instance.fn_ItemLogin(m_ID.m_ID, m_state);

               if (m_state != null)
               {
                    StateValue[] t_state = new StateValue[4]{
                    new StateValueString("electric", "uncon"),
                    new StateValueString("lock", "unlock"),
                    new StateValueString("check", "idle"),
                    fnp_getStateValue(m_state.m_ItemValueType)};

                    m_state.fn_setValue(t_state);
               }
          }
          protected string m_valueType = "";
          protected virtual StateValueString fnp_getStateValue(E_valueType _valueType)
          {
               switch (_valueType)
               {
                    case E_valueType.e_inter_onoff:
                         m_valueType = "onoff";
                         return new StateValueString("onoff", "off");
                    case E_valueType.e_inter_floatvalue:
                         m_valueType = "floatvalue";
                         return new StateValueString("floatvalue", "0");
                    case E_valueType.e_inter_level:
                         m_valueType = "level";
                         return new StateValueString("level", "0");
                    case E_valueType.e_inter_string:
                         m_valueType = "string";
                         return new StateValueString("string", "");
                    default:
                         break;
               }
               return null;

          }
          public override string fn_getValue(string _name)
          {
               if (m_state == null)
               {
                    Debug.Log("<color=red>not find state!!!</color>");
                    return "";
               }
               return m_state.fn_getOtherValue(_name);
          }
          public override string fn_getMainValue()
          {
               if (m_state==null)
               {
                    m_state = GetComponent<AB_State>(); 
               }
               if (m_state==null)
               {
                    Debug.Log("<color=red>not find state!!!</color>");
                    return "";
               }
               return m_state.fn_getMainValue();
          }
     }
     /// <summary>
     /// 状态值名称的类型
     /// </summary>
     public enum E_StateValueType
     {
          [EnumLabel("是否通电")]
          e_electric = 1,
          [EnumLabel("锁定")]
          e_lock = 2,
          [EnumLabel("检查值")]
          e_check = 3,
          [EnumLabel("开关值")]
          e_onoff = 4,
          [EnumLabel("数值")]
          e_floatvalue = 5,
          [EnumLabel("等级")]
          e_level = 6,
          [EnumLabel("字符串")]
          e_string = 7,
     } 
}