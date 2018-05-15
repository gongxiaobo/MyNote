using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
namespace GasPowerGeneration
{
     public class panel_worldmenu : UIScene
     {
          private UISceneWidget[] btns;
          private UnityAction action;

          UISceneWidget btn_firstlan;
          UISceneWidget btn_secondlan;
          UISceneWidget btn_back;
          UISceneWidget btn_quit;
          public int btn_count = 7;
          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               btns = new UISceneWidget[btn_count];
               for (int i = 1; i <= btn_count; i++)
               {
                    btns[i - 1] = GetWidget("Button_" + i.ToString());
                    UISceneWidget.Get(btns[i - 1].gameObject).onClick += btn_mode_click;
               }
               btn_firstlan = GetWidget("Button_FirstLan");
               btn_secondlan = GetWidget("Button_SecondLan");
               btn_back = GetWidget("Button_Back");
               btn_quit = GetWidget("Button_quit");
               UISceneWidget.Get(btn_firstlan.gameObject).onClick += btn_lang_click;
               UISceneWidget.Get(btn_secondlan.gameObject).onClick += btn_lang_click;
               UISceneWidget.Get(btn_back.gameObject).onClick += btn_back_click;
               UISceneWidget.Get(btn_quit.gameObject).onClick += btn_quit_click;
               UpdateLanguage();
          }

          private void btn_mode_click(GameObject go)
          {
               int index = int.Parse(go.name.Replace("Button_", ""));
               UIdata.project = (Project_new)Enum.Parse(typeof(Project_new), UI_Manager.Instance.fn_get_mode_info()[index - 1]);
               ChangePanel(UIName.Panel_ChapterMenu);
          }

          private void btn_quit_click(GameObject go)
          {
               Application.Quit();
          }

          private void btn_lang_click(GameObject go)
          {

               if (go.name == "Button_FirstLan")
               {
                    UIdata.language_type = UIdata.first_lan;
               }
               else if (go.name == "Button_SecondLan")
               {
                    UIdata.language_type = UIdata.second_lan;
               }

               UpdateLanguage();
          }
          private void btn_back_click(GameObject go)
          {
               UIName lastpage = (UIName)Enum.Parse(typeof(UIName), UI_Manager.Instance.GetStack().Pop().ToString());
               this.SetVisible(false);
               UI_Manager.Instance.SetVisible(lastpage.ToString(), true);
          }

          public override void UpdateLanguage()
          {
               base.UpdateLanguage();
               List<string> temp = UI_Manager.Instance.fn_get_mode_info();
               for (int i = 0; i < temp.Count; i++)
               {
                    if (btns != null && i < btns.Length)
                    {
                         UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, temp[i]);
                         btns[i].GetComponentInChildren<Text>().text = lang.CurrentLan();
                    }
               }
          }
     }

}