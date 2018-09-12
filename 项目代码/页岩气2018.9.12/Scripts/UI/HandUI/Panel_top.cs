using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Panel_top : N_handpanel
     {
         private Text last_btn_text;
         private Color original_color;
          protected override void Start()
          {
               base.Start();
               fn_test_or_train();
               Invoke("fn_update_lan", 1f);
              
          }
          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;
               switch (go.name)
               {
                    case "btn_transport":
                         HandUI_manager.Instance.fn_change_panel(e_hand_ui_panel.transport);
                         break;
                    case "btn_train":
                         HandUI_manager.Instance.fn_change_panel(e_hand_ui_panel.training);
                         break;
                    case "btn_exam":
                         HandUI_manager.Instance.fn_change_panel(e_hand_ui_panel.exam);
                         break;
                    case "btn_setting":
                         HandUI_manager.Instance.fn_change_panel(e_hand_ui_panel.setting);
                         break;
                    default:
                         break;
               }
               Text text = go.GetComponentInChildren<Text>();
               text.color = Color.white;
               if (last_btn_text != null)
               {
                   last_btn_text.color = new Color(0.1f, 0.9f, 0.91f, 1f);
               }
               last_btn_text = text;

          }
          /// <summary>
          /// 训练、考试模式下面板变动
          /// </summary>
          private void fn_test_or_train()
          {
               E_mode t_modeType = S_initDate.fns_getMode(S_SceneMessage.Instance.fn_getMode());
               if (t_modeType == E_mode.e_test)
               {
                    foreach (var item in triggers)
                    {
                        if (item.name == "btn_train")
                        {
                            item.GetComponent<BoxCollider>().enabled = false;
                            item.GetComponentInChildren<Text>().color = Color.gray;
                        }
                    }
               }
               else
               {
                    foreach (var item in triggers)
                    {
                         if (item.name == "btn_exam")
                         {
                             item.GetComponent<BoxCollider>().enabled = false;
                             item.GetComponentInChildren<Text>().color = Color.gray;
                         }
                    }
               }


          }

         

     }

}