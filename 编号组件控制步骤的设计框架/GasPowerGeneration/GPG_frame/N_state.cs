using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 获取一个物体上的状态值
     /// </summary>
     [DisallowMultipleComponent]
     [RequireComponent(typeof(N_Name))]
     public class N_state : AB_State, I_LightItem
     {
          /// <summary>
          /// 所有的状态值集合
          /// </summary>
          [SerializeField]
          public StateValue[] m_state = null;
          public override StateValue[] fn_getValue()
          {
               return m_state;
          }
          public override void fn_setValue(StateValue[] _initDate)
          {
               m_state = _initDate;
               //if (_initDate!=null)
               //{
               //     if (m_state==null)
               //     {
               //     }
               //     else
               //     {
               //          for (int i = 0; i < _initDate.Length; i++)
               //          {
               //               fn_setValue(_initDate[i]);
               //          }
               //     }
               //}
#if UNITY_EDITOR
               m_MainStateValue = fn_getMainValue();
#endif
          }
          public override StateValue fn_getValue(string _name)
          {
               for (int i = 0; i < m_state.Length; i++)
               {
                    if (m_state[i].Name.Equals(_name))
                    {
                         return m_state[i];
                    }
               }
               return null;
          }
          public override string fn_getMainValue()
          {
               string t_stateName = S_initDate.fns_getStateValueName(m_ItemValueType);
               return fnp_get(t_stateName);
          }

          private string fnp_get(string t_stateName)
          {
               for (int i = 0; i < m_state.Length; i++)
               {
                    if (m_state[i].Name.Equals(t_stateName))
                    {
                         return ((StateValueString)m_state[i]).m_date;
                    }
               }
               return "";
          }
          public override string fn_getMainValue(E_StateValueType _statevaluetype)
          {
               switch (_statevaluetype)
               {
                    case E_StateValueType.e_electric:
                         return fnp_get("electric");

                    case E_StateValueType.e_lock:
                         return fnp_get("lock");

                    case E_StateValueType.e_check:
                         return fnp_get("check");

                    case E_StateValueType.e_onoff:
                         return fnp_get("onoff");

                    case E_StateValueType.e_floatvalue:
                         return fnp_get("floatvalue");

                    case E_StateValueType.e_level:
                         return fnp_get("level");

                    case E_StateValueType.e_string:
                         return fnp_get("string");

                    default:
                         return "";
               }
          }
          public override string fn_getOtherValue(string _name)
          {

               return fnp_get(_name);
          }
          public override void fn_setValue(StateValue _changeValue)
          {
               if (_changeValue == null)
               {
                    return;
               }

               //Debug.Log("<color=blue>blue:</color>" + _changeValue.Name);

               for (int i = 0; i < m_state.Length; i++)
               {
                    if (m_state[i].Name == _changeValue.Name)
                    {
                         m_state[i] = _changeValue;
                         fnp_ValueChangeEvent();
                         break;
                    }
               }
#if UNITY_EDITOR
               m_MainStateValue = fn_getMainValue();
#endif
               //Debug.Log("<color=blue>blue:</color>" + _changeValue.Name);
          }
          public override void fn_setValue(string _name, string _changeValue)
          {
               if (_changeValue == null)
               {
                    return;
               }

               //Debug.Log("<color=blue>blue:</color>" + _changeValue.Name);

               for (int i = 0; i < m_state.Length; i++)
               {
                    if (m_state[i].Name == _name)
                    {
                         ((StateValueString)m_state[i]).m_date = _changeValue;
                         fnp_ValueChangeEvent();
                         break;
                    }
               }
#if UNITY_EDITOR
               m_MainStateValue = fn_getMainValue();
#endif
               //Debug.Log("<color=blue>blue:</color>" + _changeValue.Name);
          }
          public override void fn_debugContent()
          {
               AB_Name t_name = GetComponent<AB_Name>();
               for (int i = 0; i < m_state.Length; i++)
               {
                    string t_value = ((StateValueString)m_state[i]).m_date;
                    Debug.Log("<color=blue></color>" + t_name.m_ID + "->" + m_state[i].Name + "->" + t_value);

               }
          }


          #region lightItem,用于步骤的高亮提示
          protected AB_LightOneObj[] m_lightObj;
          /// <summary>
          /// 查找高亮物体的深度
          /// </summary>
          public byte m_findLightObjDepth = 0;
          public void fni_lightOn()
          {
               fnp_HandleStepLight();
          }

          private void fnp_HandleStepLight(bool _light = true)
          {
               if (m_lightObj == null)
               {
                    //m_lightObj = GetComponentsInChildren<AB_LightOneObj>();
                    m_lightObj =
                         transform.FindInChlidArray<AB_LightOneObj>(m_findLightObjDepth);
               }
               if (m_lightObj == null)
               {
                    return;
               }
               if (m_lightObj.Length == 0)
               {
                    return;
               }
               if (m_lightObj.Length >= 2)
               {
                    for (int i = 0; i < m_lightObj.Length; i++)
                    {
                         fnp_light(_light, i);
                    }
               }
               else
               {
                    fnp_light(_light, 0);
               }
          }

          private void fnp_light(bool _light, int i)
          {
               if (m_lightObj[i].m_lightObjType != E_LightObjType.e_normal)
               {
                    return;
               }
               if (_light)
               {
                    m_lightObj[i].fn_light();
               }
               else
               {
                    m_lightObj[i].fn_endLigth();
               }
          }

          public void fni_endLight()
          {
               fnp_HandleStepLight(false);
          }
          #endregion
          protected virtual void fnp_ValueChangeEvent()
          {
               //刷新冒泡的参数显示
               E_MachineName t_macName = GetComponent<AB_HandleEvent>().m_MachineName;
               S_SceneMagT1.Instance.fn_updateBubbleShow(t_macName);
          }

#if UNITY_EDITOR
          [SerializeField]
          protected string m_MainStateValue = "";
#endif
     }

}