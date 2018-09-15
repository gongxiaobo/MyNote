﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{

     public class panel_chaptermenu : UIScene
     {
          private UISceneWidget[] chapterbtns;
          private UISceneWidget btn_up;
          private UISceneWidget btn_down;
          private UISceneWidget btn_back;

          private UI_page page;

          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               page = GetComponent<UI_page>();
               chapterbtns = new UISceneWidget[page.itemcount_per_page];
               for (int i = 0; i < page.itemcount_per_page; i++)
               {
                    chapterbtns[i] = GetWidget("Button_" + (i + 1).ToString());
                    UISceneWidget.Get(chapterbtns[i].gameObject).onClick += btn_chapter_click;
               }
               btn_up = GetWidget("Button_Up");
               btn_down = GetWidget("Button_Down");
               btn_back = GetWidget("Button_Back");
               UISceneWidget.Get(btn_up.gameObject).onClick += page_up;
               UISceneWidget.Get(btn_down.gameObject).onClick += page_down;
               UISceneWidget.Get(btn_back.gameObject).onClick += btn_back_click;


               UpdateLanguage();

          }

          private void btn_back_click(GameObject go)
          {
               this.SetVisible(false);
               // UIName lastpage = (UIName)Enum.Parse(typeof(UIName), UI_Manager.Instance.GetStack().Pop().ToString());
               UIName lastpage = (UIName)UI_Manager.Instance.GetStack().Pop();
               UI_Manager.Instance.SetVisible(lastpage.ToString(), true);

               //ChangePanel(lastpage);

          }

          private void page_down(GameObject go)
          {
               page.Next();
          }

          private void page_up(GameObject go)
          {
               page.Previous();
          }
          /// <summary>
          /// 章节按钮按下方法
          /// </summary>
          /// <param name="go"></param>
          private void btn_chapter_click(GameObject go)
          {

               int chpterindex = int.Parse(go.name.Replace("Button_", "")) + (page.m_PageIndex - 1) * page.itemcount_per_page;
               UIdata.currentChapter = UI_Manager.Instance.fn_get_chapter_info(UIdata.project.ToString())[chpterindex - 1];
               print(UIdata.currentChapter);
               ChangePanel(UIName.Panel_StepMenu);
          }
          public override void UpdateLanguage()
          {
               base.UpdateLanguage();
               List<string> temp = UI_Manager.Instance.fn_get_chapter_info(UIdata.project.ToString());

               if (chapterbtns != null)
               {
                    for (int i = 0; i < chapterbtns.Length; i++)
                    {
                         if (i < temp.Count)
                         {
                              UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, temp[i]);
                              if (lang != null)
                                   chapterbtns[i].GetComponentInChildren<Text>().text = lang.CurrentLan();
                         }
                    }
               }
          }

     }

}