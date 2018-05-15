using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Panel_exam : N_handpanel
     {
          //public int max_min;
          //public int max_sec;
          int min;
          int sec;
          private Text time_text;
          I_backToSelect t_back;
          protected override void Awake()
          {
               base.Awake();
               t_back = S_SceneMagT1.Instance;
               time_text = TransformHelper.FindChild(transform, "time").GetComponent<Text>();
               //fn_start_time_count();
          }



          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;
               print("press");
               switch (go.name)
               {
                    case "btn_submit":

                         //结束考试
                         t_back.fni_StopTest();
                         HandUI_manager.Instance.fn_change_panel(e_hand_ui_panel.score);
                         break;
                    case "btn_quit":
                         //考试返回选择场景
                         t_back.fni_TestBackSelect();
                         break;
               }
          }

          //public void fn_start_time_count()
          //{
          //    update_handler = fn_count_second;
          //    StartCoroutine(update_data(1f));
          //}

          //public void fn_stop_time_count()
          //{
          //    print("时间到");
          //    StopCoroutine(update_data(0));
          //}

          //private void fn_count_second()
          //{

          //    sec++;
          //    if (sec > 59)
          //    {
          //        min += 1;
          //        sec = 0;
          //    }

          //    time_text.text = min.ToString("00") + ":" + sec.ToString("00");
          //    if (min == max_min && sec == max_sec)
          //    {
          //        fn_stop_time_count();
          //    }

          //}


          public override void fn_update_time(int seconds)
          {
               base.fn_update_time(seconds);
               sec = seconds % 60;
               min = (int)(seconds / 60);
               time_text.text = min.ToString("00") + ":" + sec.ToString("00");
               if (seconds == 0)
                    HandUI_manager.Instance.fn_change_panel(e_hand_ui_panel.score);
          }


     }

}