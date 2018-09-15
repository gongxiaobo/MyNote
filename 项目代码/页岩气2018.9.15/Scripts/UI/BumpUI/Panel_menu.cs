using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 菜单界面
     /// </summary>
     public class Panel_menu : N_bumpUI
     {
          /// <summary>
          /// 阶段时间
          /// </summary>
          private Text phase_work_time;
          /// <summary>
          /// 总时间
          /// </summary>
          private Text total_work_time;
          protected override void Start()
          {
               phase_work_time = TransformHelper.FindChild(transform, "phase_work_time_value").GetComponent<Text>();
               total_work_time = TransformHelper.FindChild(transform, "total_work_time_value").GetComponent<Text>();
               fn_update_handler = fn_update;
               base.Start();

          }

          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;



               switch (go.name)
               {
                    case "btn_mainmenu":
                         BumpUI_manager.Instance.fn_change_panel(e_bump_ui_panel.start);
                         break;
                    case "btn_bumpscontrol":
                         //BumpUI_manager.Instance.fn_change_panel(e_bump_ui_panel.bumps);
                         break;
                    case "btn_singlebumpcontrol":
                         //BumpUI_manager.Instance.fn_change_panel(e_bump_ui_panel.sigle_bump);
                         break;
                    case "btn_processcontrol":

                         break;
                    case "btn_play":

                         break;
                    case "btn_next":

                         break;
                    case "btn_pause":

                         break;
                    case "btn_edit":

                         break;


               }
               //BumpParam_manager.Instance.fn_update_bump_page();
          }
          int phase_hour, phase_min, phase_sec, total_hour, total_min, total_sec;
          /// <summary>
          /// 事件更新
          /// </summary>
          private void fn_update()
          {
               phase_sec++;
               total_sec++;
               phase_work_time.text = phase_hour.ToString("00") + ":" + phase_min.ToString("00") + ":" + phase_sec.ToString("00");
               total_work_time.text = total_hour.ToString("00") + ":" + total_min.ToString("00") + ":" + total_sec.ToString("00");
          }

          public void fn_start_cal_time()
          {
               StartCoroutine(update_data(1));
          }
     }
}