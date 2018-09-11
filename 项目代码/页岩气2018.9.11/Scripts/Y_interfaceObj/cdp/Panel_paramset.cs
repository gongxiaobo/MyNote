using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cdp;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Panel_paramset : N_CDPPanel
     {



          protected Text group_name;
          protected Text param_name;
          protected Text param_value;
          protected Text param_unit;
          /// <summary>
          /// 当前组索引
          /// </summary>
          public int group_index = 1;
          /// <summary>
          /// 当前参数索引
          /// </summary>
          public int param_index = 1;
          /// <summary>
          /// 最大组数
          /// </summary>
          private int max_group;
          /// <summary>
          /// 当前组最大参数数
          /// </summary>
          private int max_param;
          /// <summary>
          /// 是否在编辑模式
          /// </summary>
          private bool editstate = false;

          /// <summary>
          /// 参数锁定
          /// </summary>
          private bool param_lock = false;

          private I_CDPSet current_cdpinfo;
          // Use this for initialization
          protected override void Awake()
          {
               base.Awake();
               group_name = TransformHelper.FindChild(transform, "group_name").GetComponent<Text>();
               param_name = TransformHelper.FindChild(transform, "param_name").GetComponent<Text>();
               param_value = TransformHelper.FindChild(transform, "param_value").GetComponent<Text>();
               param_unit = TransformHelper.FindChild(transform, "param_unit").GetComponent<Text>();
               blink = TransformHelper.FindChild(transform, "blink");

          }
          /// <summary>
          /// 显示该界面时触发
          /// </summary>
          public override void fn_show_panel()
          {
               base.fn_show_panel();
               fn_setmax_info();
               fn_show_group_info();
          }
          /// <summary>
          /// 设置组数和参数数最大值
          /// </summary>
          private void fn_setmax_info()
          {
               max_group = CDPctrl_manager.Instance.fn_getmaxgroup_count();
               max_param = CDPctrl_manager.Instance.fn_getmaxparam_count(group_index);
          }

          /// <summary>
          /// 按下上时执行
          /// </summary>
          /// <param name="press"></param>
          public override void btn_up(bool press)
          {
               base.btn_up(press);
               if (!editstate)//非编辑模式时执行
               {
                    if (press)//按下时执行
                    {
                         handler = () =>
                         {
                              print(param_index);
                              if (param_index > 1)
                              {
                                   param_index--;
                                   fn_show_group_info();
                              }
                         };
                         StartCoroutine(update_data(0.1f));
                    }
                    else//抬起时执行
                    {
                         handler();
                         handler = null;
                         StopCoroutine(update_data(0.1f));
                    }
               }
               else
               {
                    if (param_lock && group_index != 16 && param_index != 3) return;

                    if (press)
                    {
                         current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(group_index, param_index);
                         current_cdpinfo.fni_UpArrow_start(fn_paramvalue_change);
                    }
                    else
                    {
                         current_cdpinfo.fni_UpArrow_end();
                    }

               }

          }


          public override void btn_down(bool press)
          {
               base.btn_up(press);
               if (!editstate)
               {
                    if (press)
                    {
                         handler = () =>
                         {
                              print(param_index);
                              if (param_index < max_param)
                              {
                                   param_index++;
                                   fn_show_group_info();
                              }
                         };
                         StartCoroutine(update_data(0.1f));
                    }
                    else
                    {
                         handler();
                         handler = null;
                         StopCoroutine(update_data(0.1f));
                    }
               }
               else
               {
                    if (param_lock && group_index != 16 && param_index != 3) return;
                    if (press)
                    {
                         current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(group_index, param_index);
                         current_cdpinfo.fni_DownArrow_start(fn_paramvalue_change);
                    }
                    else
                    {
                         current_cdpinfo.fni_DownArrow_end();
                    }
               }


          }
          public override void btn_upup(bool press)
          {
               base.btn_up(press);
               if (!editstate)
               {
                    if (press)
                    {
                         handler = () =>
                         {
                              if (group_index > 1)
                              {
                                   group_index--;
                                   param_index = 1;
                                   fn_show_group_info();

                              }
                         };
                         StartCoroutine(update_data(0.1f));
                    }
                    else
                    {
                         handler();
                         handler = null;
                         StopCoroutine(update_data(0.1f));
                    }
               }
               else
               {
                    if (param_lock && group_index != 16 && param_index != 3) return;
                    if (press)
                    {
                         current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(group_index, param_index);
                         current_cdpinfo.fni_DoubleUpArrow_start(fn_paramvalue_change);
                    }
                    else
                    {
                         current_cdpinfo.fni_DoubleUpArrow_end();
                    }
               }
          }
          public override void btn_downdown(bool press)
          {
               base.btn_up(press);
               if (!editstate)
               {
                    if (press)
                    {
                         handler = () =>
                         {
                              if (group_index < max_group)
                              {
                                   group_index++;
                                   param_index = 1;
                                   fn_show_group_info();
                              }
                         };
                         StartCoroutine(update_data(0.1f));
                    }
                    else
                    {
                         handler();
                         handler = null;
                         StopCoroutine(update_data(0.1f));
                    }
               }
               else
               {
                    if (param_lock && group_index != 16 && param_index != 3) return;
                    if (press)
                    {
                         current_cdpinfo = S_CDPControl.Instance.fn_getCDPSet(group_index, param_index);
                         current_cdpinfo.fni_DoubleDownArrow_start(fn_paramvalue_change);
                    }
                    else
                    {
                         current_cdpinfo.fni_DoubleDownArrow_end();
                    }
               }
          }

          public override void btn_enter(bool press)
          {
               base.btn_enter(press);
               //if (!press)
               //{
               //    if (editstate)
               //    {
               //        current_cdpinfo.fni_Confirm();
               //        handler = null;
               //        fn_stop_blink();
               //    }
               //    else {
               //        fn_effect_blink();
               //    }


               //    editstate = !editstate;

               //}
               if (press) return;

               if (param_lock)
               {
                    if (group_index == 16 && param_index == 3)
                    {
                         if (editstate)
                         {
                              current_cdpinfo.fni_Confirm();
                              handler = null;
                              fn_stop_blink();
                              fni_level(2);
                         }
                         else
                         {
                              fni_level(3);
                              fn_effect_blink();
                         }
                    }
                    else return;
               }
               else
               {
                    //编辑状态非锁定 编辑状态锁定 锁定状态密码 锁定状态非密码
                    if (editstate)
                    {
                         current_cdpinfo.fni_Confirm();
                         handler = null;
                         fni_level(3);//设置参数设置面板状态为参数修改
                         fn_stop_blink();
                    }
                    else
                    {
                         fn_effect_blink();
                         fni_level(2);//设置参数设置面板状态为参数设置
                    }
               }

               editstate = !editstate;




          }

          public override void btn_act(bool press)
          {
               base.btn_act(press);
               if (press) return;
               if (editstate)
               {
                    fn_cancelcurrentstate();
                    fn_show_group_info();
                    editstate = false;
               }
               else
               {
                    CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
               }
          }
          public override void btn_par(bool press)
          {
               base.btn_par(press);
               if (!press) return;
               if (editstate)
               {
                    fn_cancelcurrentstate();
                    fn_show_group_info();
                    editstate = false;
               }
               else
               {
                    CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
               }
          }
          public override void btn_drive(bool press)
          {
               base.btn_drive(press);
               if (!press) return;
               if (editstate)
               {
                    fn_cancelcurrentstate();
                    fn_show_group_info();
                    editstate = false;
               }
               else
               {
                    CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
               }
          }
          public override void btn_func(bool press)
          {
               base.btn_func(press);
               if (!press) return;
               if (editstate)
               {
                    fn_cancelcurrentstate();
                    fn_show_group_info();
                    editstate = false;
               }
               else
               {
                    CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.signal);
               }
          }
          /// <summary>
          /// 界面参数变化显示
          /// </summary>
          /// <param name="value"></param>
          private void fn_paramvalue_change(string value)
          {
               print(param_lock);
               if (!param_lock)//当参数锁定未开启时直接显示修改值
               {

                    param_value.text = value;
               }
               else if (param_lock && group_index == 16 && param_index == 3)//锁定状态下切换到密码界面时参数会随上下键变动
               {
                    param_value.text = value;
               }
          }
          /// <summary>
          /// 显示当前参数信息
          /// </summary>
          private void fn_show_group_info()
          {
               fni_level(1);
               //给当前选择逻辑item发送当前选择的参数的itemid
               AB_SendMsg msg = new N_SendMsg();
               msg.fn_sendmsg(E_MessageType.e_inside, E_valueType.e_inter_floatvalue, m_handler.ID.m_ID, 2419,
                   S_CDPControl.Instance.fn_getCDPItemID(group_index, param_index).ToString(), m_handler);
               group_name.text = S_CDPControl.Instance.fn_getGroupName(group_index);
               param_name.text = S_CDPControl.Instance.fn_getMemberName(group_index, param_index);
               param_value.text = S_CDPControl.Instance.fn_getMemberValue(group_index, param_index);
               param_unit.text = S_CDPControl.Instance.fn_getMemberUnit(group_index, param_index);
          }

          /// <summary>
          /// 高亮显示
          /// </summary>
          public override void fn_effect_blink()
          {
               base.fn_effect_blink();
               handler += () =>
               {
                    if ((int)Time.time % 2 == 0)
                    {
                         blink.gameObject.SetActive(true);
                    }
                    else
                    {
                         blink.gameObject.SetActive(false);
                    }
               };
               StartCoroutine(update_data(1f));
          }
          /// <summary>
          /// 停止高亮
          /// </summary>
          public override void fn_stop_blink()
          {
               base.fn_stop_blink();
               blink.gameObject.SetActive(false);
          }

          /// <summary>
          /// 取消选中 高亮等状态
          /// </summary>
          protected override void fn_cancelcurrentstate()
          {
               base.fn_cancelcurrentstate();
               fn_stop_blink();
               handler = null;
          }

          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_level(_level, _controlType);
               StateValueString state = (StateValueString)m_handler.fn_get("level");
               state.m_date = _level.ToString();
               m_handler.fn_set(state);
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_statename == "electric")
               {
                    if (_value == "con")
                         param_lock = true;
                    else
                         param_lock = false;
               }
          }
     }

}