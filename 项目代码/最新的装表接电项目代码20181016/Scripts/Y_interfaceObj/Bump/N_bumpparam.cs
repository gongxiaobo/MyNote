using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{

     /// <summary>
     /// 泵参数显示类
     /// </summary>
     public class N_bumpparam : AB_bumpparam
     {

          [HideInInspector]
          public int belongs_bump_id;


          public Vector2 Range;
          protected Action<int, string> _callback;

          public bump_param_type param_type;
          protected N_HandleEvent_init handler;
          AB_BumpSCMgr m_bumpSCMgr = null;
          protected override void Start()
          {
               base.Start();
               belongs_bump_id = int.Parse(transform.parent.name.Replace("bump", ""));
               handler = GetComponent<N_HandleEvent_init>();
               m_bumpSCMgr = transform.parent.GetComponent<AB_BumpSCMgr>();

          }

          /// <summary>
          /// 更新参数信息
          /// </summary>
          /// <param name="_call">委托 int参数为item_id string 为值</param>
          /// <param name="bumpid"></param>
          public override void fn_update_param(Action<int, string> _call, int bumpid)
          {
               if (handler == null)
               {
                    handler = GetComponent<N_HandleEvent_init>();
               }
               if (bumpid == belongs_bump_id)
               {

                    _callback += _call;
                    _call(handler.ID.m_ID, handler.fn_getMainValue());
                   

               }
               else
               {
                    _callback = null;
               }
          }

          /// <summary>
          /// 获取参数的范围
          /// </summary>
          /// <param name="unit_range"></param>
          public override Vector2 fn_get_unit_range(Action<Vector2> unit_range)
          {
               if (unit_range != null)
                    unit_range(Range);
               return Range;
          }
          #region I_control



          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_level(_level, _controlType);


               //限制设置范围
               if (_level > Range.y)
                    _level = Range.y;
               if (_level < Range.x)
                    _level = Range.x;
               original_value = _level;
               //计算校正系数和偏移量
               _level = _level * coefficient + offset;
               //再次计算经过校正系数和偏移量的值，设置范围
               if (_level > Range.y)
                    _level = Range.y;
               if (_level < Range.x)
                    _level = Range.x;
               if (_controlType == E_ControlType.e_init)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("floatvalue", _level.ToString(), handler);
               }
               else if (_controlType == E_ControlType.e_normal)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("floatvalue", _level.ToString(), handler);
               }
               if (_callback != null) _callback(handler.ID.m_ID, _level.ToString());//执行回调 更新参数
               fnp_sendChangeToOthers();
          }
          /// <summary>
          /// 告诉这个泵的其他参数，这个参数值被改变了
          /// </summary>
          private void fnp_sendChangeToOthers()
          {
               if (m_bumpSCMgr != null)
               {
                    m_bumpSCMgr.fn_sendChange(handler.ID.m_ID);
               }
          }
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {

               base.fni_on(_controlType);

               if (_controlType == E_ControlType.e_init)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("onoff", "on", handler);
               }
               else if (_controlType == E_ControlType.e_normal)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("onoff", "on", handler);
               }
               if (_callback != null) _callback(handler.ID.m_ID, "on");//执行回调 更新参数
               fnp_sendChangeToOthers();
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);

               if (_controlType == E_ControlType.e_init)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("onoff", "off", handler);
               }
               else if (_controlType == E_ControlType.e_normal)
               {
                    AB_SetState t_state = new N_SetState();
                    t_state.fn_setState("onoff", "off", handler);
               }
               if (_callback != null) _callback(handler.ID.m_ID, "off");//执行回调 更新参数
               fnp_sendChangeToOthers();
          }
          #endregion

          /// <summary>
          /// 设置参数值
          /// </summary>
          /// <param name="set_call"></param>
          /// <param name="bumpid"></param>
          /// <param name="value"></param>
          public override void fn_set_param(Action<int, string> set_call, int bumpid, bool value)
          {
               base.fn_set_param(set_call, bumpid, value);
               if (bumpid == belongs_bump_id)
               {
                    _callback += set_call;
                    if (value) fni_on();
                    else fni_off();
               }
          }
          /// <summary>
          /// 设置参数值
          /// </summary>
          /// <param name="set_call"></param>
          /// <param name="bumpid"></param>
          /// <param name="value"></param>
          public override void fn_set_param(Action<int, string> set_call, int bumpid, float value)
          {
               base.fn_set_param(set_call, bumpid, value);
               if (bumpid == belongs_bump_id)
               {
                    _callback += set_call;
                    fni_level(value);
               }
          }
     }
     /// <summary>
     /// 泵的参数类型
     /// </summary>
     public enum bump_param_type
     {
          Bool = 1,
          Param = 2,

     }
}