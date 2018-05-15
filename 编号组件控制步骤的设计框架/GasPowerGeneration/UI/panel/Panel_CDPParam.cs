using cdp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     /// <summary>
     /// cdp参数整体面板管理类
     /// </summary>
     public class Panel_CDPParam : MonoBehaviour
     {
          public const string up_btnname = "up";
          public const string down_btnname = "down";
          public const string upup_btnname = "upup";
          public const string downdown_btnname = "downdown";
          public const string act_btnname = "act";
          public const string par_btnname = "par";
          public const string func_btnname = "func";
          public const string drive_btnname = "drive";
          public const string lock_btnname = "lock";
          public const string reset_btnname = "reset";
          public const string ref_btnname = "ref";
          public const string start_btnname = "start";
          public const string stop_btnname = "stop";
          public const string backward_btnname = "backward";
          public const string forwad_btnname = "forwad";
          public const string enter_btnname = "enter";

          private N_CDPPanel[] panel_list;
          [HideInInspector]
          public N_CDPPanel current_panel;
          // Use this for initialization
          void Awake()
          {
               panel_list = GetComponentsInChildren<N_CDPPanel>();
          }


          /// <summary>
          /// 变换panel
          /// </summary>
          /// <param name="type"></param>
          public void fn_change_panel(cdp_panel_type type)
          {

               foreach (var item in panel_list)
               {
                    if (item.panel_type == type)
                    {
                         current_panel = item;
                         item.fn_show_panel();
                    }
                    else
                         item.fn_hide_panel();
               }

          }

          public void fn_show_panel(cdp_panel_type type)
          {
               foreach (var item in panel_list)
               {
                    if (item.panel_type == type)
                         item.fn_show_panel();
               }
          }
          /// <summary>
          /// 按钮触发
          /// </summary>
          /// <param name="go"></param>
          /// <param name="press"></param>
          public void fn_btn_click(GameObject go, bool press)
          {

               switch (go.name)
               {
                    case up_btnname:
                         current_panel.btn_up(press);
                         break;
                    case upup_btnname:
                         current_panel.btn_upup(press);
                         break;
                    case downdown_btnname:
                         current_panel.btn_downdown(press);
                         break;
                    case act_btnname:
                         current_panel.btn_act(press);
                         break;
                    case enter_btnname:
                         current_panel.btn_enter(press);
                         break;
                    case par_btnname:
                         current_panel.btn_par(press);
                         break;
                    case down_btnname:

                         current_panel.btn_down(press);
                         break;
                    case func_btnname:
                         current_panel.btn_func(press);
                         break;
                    case drive_btnname:
                         current_panel.btn_drive(press);
                         break;
                    case lock_btnname:
                         current_panel.btn_loc_rem(press);
                         break;
                    case reset_btnname:
                         current_panel.btn_reset(press);
                         break;
                    case ref_btnname:
                         current_panel.btn_ref(press);
                         break;
                    case start_btnname:
                         current_panel.btn_start(press);
                         break;
                    case stop_btnname:
                         current_panel.btn_stop(press);
                         break;
                    case backward_btnname:
                         current_panel.btn_backward(press);
                         break;
                    case forwad_btnname:
                         current_panel.btn_forward(press);
                         break;
               }

          }

          public void fn_changepanelmsg(ChangeHandler changehandler, cdp_panel_type panel)
          {
               // current_panel.fn_changepanelmsg(changehandler);
               foreach (var item in panel_list)
               {
                    if (item.panel_type == panel)
                         item.fn_changepanelmsg(changehandler);
               }
          }
     }

}