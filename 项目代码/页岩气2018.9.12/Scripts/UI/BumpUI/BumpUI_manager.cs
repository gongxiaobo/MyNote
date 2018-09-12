using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     public class BumpUI_manager : GenericSingletonClass<BumpUI_manager>
     { //当前操作泵的id
          //[HideInInspector]
          public int current_bump_id = 1;
          //节点下的所有panel界面管理类
          public N_bumpUI[] switch_panels;
          /// <summary>
          /// 初始界面类型
          /// </summary>
          public e_bump_ui_panel start_panel;
          /// <summary>
          /// 手部菜单各个界面列表
          /// </summary>
          private List<N_bumpUI> panels;
          // Use this for initialization
          void Start()
          {
               switch_panels = GetComponentsInChildren<N_bumpUI>();
               panels = new List<N_bumpUI>(switch_panels);
               //fn_change_panel(start_panel);
               //Init();
               GlobalEventSystem<InitFinished>.eventHappened += fnp_initShow;
          }

          private void Init()
          {
               foreach (var item in panels)
               {//隐藏一些界面在程序开始
                    if (item.panel_type == e_bump_ui_panel.param_input ||
                         item.panel_type == e_bump_ui_panel.support ||
                         item.panel_type == e_bump_ui_panel.bumppara_set)
                         item.fn_hide();
               }
          }
          #region hide or show a panel
          protected void fnp_initShow(InitFinished _isfinished)
          {
               fn_change_panel(start_panel);
          }
          /// <summary>
          /// 切换界面，显示传入界面，隐藏其他界面
          /// </summary>
          /// <param name="paneltype"></param>
          public void fn_change_panel(e_bump_ui_panel paneltype)
          {
               foreach (var item in panels)
               {
                    if (item.panel_type != paneltype)
                         item.fn_hide();
                    else
                         item.fn_show();
               }
          }
          /// <summary>
          /// 显示一个指定的界面
          /// </summary>
          /// <param name="paneltype"></param>
          public void fn_show_panel(e_bump_ui_panel paneltype)
          {
               foreach (var item in panels)
               {
                    if (item.panel_type == paneltype)
                    {
                         item.fn_show();
                    }
               }
          } 
          #endregion
          /// <summary>
          /// 输入面板的打开，注册回调
          /// </summary>
          /// <param name="call"></param>
          /// <param name="ui_index"></param>
          public void fn_show_set_panel(Action<int, string> call, int ui_index)
          {
               foreach (var item in panels)
               {
                    if (item.panel_type == e_bump_ui_panel.param_input)
                    {
                         item.fn_show();
                         Panel_paraminput panel = item.GetComponent<Panel_paraminput>();
                         panel.fn_set_info(ui_index, call);

                    }
               }
          }
          /// <summary>
          /// 修改面板的上的系数，但是不把值放入到item的state中
          /// </summary>
          /// <param name="call"></param>
          /// <param name="ui_index"></param>
          /// <param name="type"></param>
          public void fn_show_set_panel(Action<int, string, string> call, int ui_index, input_type type)
          {
               foreach (var item in panels)
               {
                    if (item.panel_type == e_bump_ui_panel.param_input)
                    {
                         item.fn_show();
                         Panel_paraminput panel = item.GetComponent<Panel_paraminput>();
                         switch (type)
                         {
                              case input_type.coefficient://乘系数
                                   panel.fn_set_coefficient(ui_index, call);
                                   break;
                              case input_type.offset://加偏移量
                                   panel.fn_set_offset(ui_index, call);
                                   break;
                         }

                    }

               }
          }


          /// <summary>
          /// 更新训练、考试的时间信息
          /// </summary>
          /// <param name="seconds"></param>
          public void fn_update_time(int seconds)
          {
               //foreach (var item in panels)
               //{
               //     item.fn_update_time(seconds);
               //}
          }
          /// <summary>
          /// 泵的界面语言 ch,eng
          /// </summary>
          public string m_bumpLanguage = "ch";
          public void fn_update_language()
          {
               foreach (var item in panels)
               {
                    item.fn_updatelan();
               }
          }

     }
}
