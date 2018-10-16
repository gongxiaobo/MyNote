using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
namespace GasPowerGeneration
{
     public class Panel_train : N_handpanel
     {
          //气泡提示是否激活
          bool bubble_show = true;
          //介绍模式是否激活
          bool introduce_show = true;
          //public int max_min;
          //public int max_sec;
          int min;
          int sec;
          private Text time_text;

          protected override void Awake()
          {
               base.Awake();
               time_text = TransformHelper.FindChild(transform, "time").GetComponent<Text>();

               // fn_start_time_count();
          }

          protected override void Start()
          {
               base.Start();
               S_sceneOver.Instance.Over = fn_next_step;
          }
          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;
               switch (go.name)
               {
                    case "btn_bubble":
                         S_SceneMagT1.Instance.fn_BubblesShow(bubble_show);
                         bubble_show = !bubble_show;
                         break;
                    case "btn_introduce":
                         S_SceneMagT1.Instance.fn_IntroduceShow(introduce_show);
                         introduce_show = !introduce_show;
                         break;
                    case "btn_quit":
                         fn_quit();
                         break;
                    case "btn_nextstep":
                         fn_next_step();
                         break;
               }
          }

          private void fn_next_step()
          {
               //string current_stepid=
               if (!UIdata.compound_step) return;
               UIdata.compound_steps_id.Remove(UIdata.compound_steps_id[0]);
               //复合关卡还有其他关卡
               if (UIdata.compound_steps_id.Count > 0)
               {
                    string initFormName = "debug_s" + UIdata.compound_steps_id[0] + "_train";
                    string stepFormName = "debug_s" + UIdata.compound_steps_id[0] + "_step_" + language_csv_read();

                    AB_Message t_msg = new N_Message();
                    t_msg.fn_init(E_MessageType.e_sceneMsg, new StateValue[5]
                         {
                         new StateValueString("sceneType",UIdata.trainMode.ToString()),
                         new StateValueString("subject_init",initFormName),
                         new StateValueString("subject_step",stepFormName),
                         new StateValueString("lg",UIdata.language_type.ToString()),
                         new StateValueString("item_name","item_names_"+language_csv_read())
                         },
                    "sceneMsg", 0, 0);
                    S_SceneMessage.Instance.fn_addMsg(t_msg);

                    S_SceneMessage.Instance.me_thisSceneName = E_sceneName.e_step;
                    S_SoundComSingle.Instance.fnp_soundSpecial("next_step");
                    Invoke("fn_change_scene", 3f);
               }
               else
               {
                    S_SoundComSingle.Instance.fnp_soundSpecial("all_step_end");
                    Invoke("fn_end_train", 6f);

               }
          }

          void fn_end_train()
          {
               S_SceneMagT1.Instance.fn_end();
               S_SceneMagT1.Instance.fni_TrainBackSelect();
          }

          void fn_change_scene()
          {
               S_SceneMagT1.Instance.fn_end();
               Invoke("fn_reload_scene", 0.5f);

          }
          void fn_reload_scene()
          {
               SceneManager.LoadScene("test_step1");
          }
          //public void fn_start_time_count() {
          //    update_handler = fn_count_second;
          //    StartCoroutine(update_data(1f));
          //}

          //public void fn_stop_time_count() {
          //    print("时间到");
          //    StopCoroutine(update_data(0));
          //    fn_quit();
          //}

          //private void fn_count_second() {

          //    sec++;
          //    if (sec > 59){
          //        min +=1;
          //        sec = 0;
          //    }

          //    time_text.text = min.ToString("00") + ":" + sec.ToString("00");
          //    if (min == max_min && sec == max_sec)
          //    {
          //        fn_stop_time_count();
          //    }

          //}


          private void fn_quit()
          {
               I_backToSelect t_back = S_SceneMagT1.Instance;
               //训练返回选择场景
               t_back.fni_TrainBackSelect();



          }

          public override void fn_update_time(int seconds)
          {
               base.fn_update_time(seconds);
               sec = seconds % 60;
               min = (int)(seconds / 60);
               time_text.text = min.ToString("00") + ":" + sec.ToString("00");
          }
          private string language_csv_read()
          {
               //if (UIdata.first_lan != Language.Chinese)
               //    return "_" + UIdata.first_lan.ToString();
               //else
               //    return "_" + UIdata.second_lan.ToString();

               string lan1 = UIdata.first_lan.ToString().Substring(0, 1).ToLower();
               string lan2 = UIdata.second_lan.ToString().Substring(0, 1).ToLower();
               return lan1 + lan2;
          }

     }

}