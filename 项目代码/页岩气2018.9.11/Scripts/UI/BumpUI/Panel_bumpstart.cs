using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 泵的开始界面
     /// </summary>
     public class Panel_bumpstart : N_bumpUI, I_bumpTrigger
     {
          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;
               switch (go.name)
               {
                    case "lang":
                         AB_TriggerSwitch t_triggerswitch = go.GetComponent<AB_TriggerSwitch>();
                         if (t_triggerswitch!=null)
                         {
                              t_triggerswitch.fn_trigger();
                         }
                         break;
                    case "unit":
                         AB_TriggerSwitch t_unitswitch = go.GetComponent<AB_TriggerSwitch>();
                         if (t_unitswitch != null)
                         {
                              t_unitswitch.fn_trigger();
                         }
                         break;
                    case "enter":
                         fn_hide();
                         BumpUI_manager.Instance.fn_show_panel(e_bump_ui_panel.menu);
                         BumpUI_manager.Instance.fn_show_panel(e_bump_ui_panel.sigle_bump);
                         //BumpParam_manager.Instance.fn_update_bump_page();
                         break;
                    case "Button_quit":

                         break;
               }


          }

          public new void fni_btn_press(GameObject go, bool press)
          {
               fn_btn_press(go, press);
          }
     }
}
