using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Panel_transport : N_handpanel
     {

          //private Trigger_handui btn_up;
          //private Trigger_handui btn_down;

          //protected override void Awake()
          //{
          //    base.Awake();
          //    btn_up = TransformHelper.FindChild(transform, "Button_Up").GetComponent<Trigger_handui>();
          //    btn_down = TransformHelper.FindChild(transform, "Button_Down").GetComponent<Trigger_handui>();
          //}

          UI_page page;

          protected override void Awake()
          {
               base.Awake();
               page = GetComponent<UI_page>();
          }
          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;
               if (go.name.EndsWith("pos"))
               {
                    S_SceneMagT1.Instance.fn_PlayerMoveTo(go.name);
                    if (handui != null)
                         handui.SetActive(false);
               }
               else if (go.name == "Button_Up")
               {
                    fn_page_up();
                    fn_update_lan();
               }
               else if (go.name == "Button_Down")
               {
                    fn_page_down();
                    fn_update_lan();
               }
          }

          private void fn_page_up()
          {
               page.Previous();
          }

          private void fn_page_down()
          {
               page.Next();
          }
     }

}