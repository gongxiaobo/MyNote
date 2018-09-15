using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
namespace GasPowerGeneration
{
     public class Panel_worldmenu : UIScene
     {
          private UISceneWidget btn_showworld, btn_debug, btn_move, btn_maintain, btn_fault, btn_firstlan, btn_secondlan;
          private UnityAction action;

          public int DebugChapterCount;
          public int MoveChapterCount;
          public int MaintainChapterCount;
          public int FaultChapterCount;

          private UISceneWidget btn_back;
          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               btn_showworld = GetWidget("Button_ShowWorld"); //指点江山按钮
               btn_debug = GetWidget("Button_Debug");            //调试模式按钮
               btn_move = GetWidget("Button_Move");              //搬安模式
               btn_maintain = GetWidget("Button_Maintain");    //维护模式
               btn_fault = GetWidget("Button_Fault");          //故障维修模式
               btn_firstlan = GetWidget("Button_FirstLan");
               btn_secondlan = GetWidget("Button_SecondLan");
               btn_back = GetWidget("Button_Back");
               UISceneWidget.Get(btn_showworld.gameObject).onClick += btn_showworld_click;
               UISceneWidget.Get(btn_debug.gameObject).onClick += btn_tranpro_click;
               UISceneWidget.Get(btn_move.gameObject).onClick += btn_tranpro_click;
               UISceneWidget.Get(btn_maintain.gameObject).onClick += btn_tranpro_click;
               UISceneWidget.Get(btn_fault.gameObject).onClick += btn_tranpro_click;
               UISceneWidget.Get(btn_firstlan.gameObject).onClick += btn_lang_click;
               UISceneWidget.Get(btn_secondlan.gameObject).onClick += btn_lang_click;
               UISceneWidget.Get(btn_back.gameObject).onClick += btn_back_click;

          }

          private void btn_showworld_click(GameObject go)
          {

          }
          private void btn_tranpro_click(GameObject go)
          {
               UIdata.current_pro = (Project)Enum.Parse(typeof(Project), go.name.Replace("Button_", ""));
               UIdata.currentProChapterCount = CurrentProChapterCount();
               ChangePanel(UIName.Panel_ChapterMenu);
          }
          private void btn_lang_click(GameObject go)
          {

               if (go.name == "Button_FirstLan")
               {
                    UIdata.language_type = UIdata.first_lan;
                    print("111");
               }
               else if (go.name == "Button_SecondLan")
               {
                    UIdata.language_type = UIdata.second_lan;
                    print("222");
               }

               UpdateLanguage();
          }
          private int CurrentProChapterCount()
          {
               switch (UIdata.current_pro)
               {
                    case Project.Debug:
                         return DebugChapterCount;
                    case Project.Fault:
                         return FaultChapterCount;
                    case Project.Maintain:
                         return MaintainChapterCount;
                    case Project.Move:
                         return MoveChapterCount;
                    default:
                         return 0;

               }
          }
          private void btn_back_click(GameObject go)
          {
               UIName lastpage = (UIName)Enum.Parse(typeof(UIName), UI_Manager.Instance.GetStack().Pop().ToString());
               this.SetVisible(false);
               UI_Manager.Instance.SetVisible(lastpage.ToString(), true);
          }
     }

}