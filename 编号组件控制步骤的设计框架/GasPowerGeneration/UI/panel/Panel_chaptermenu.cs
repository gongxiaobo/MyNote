using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace GasPowerGeneration
{
     public class Panel_chaptermenu : UIScene
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
               Update_chapter_language();
               btn_up = GetWidget("Button_Up");
               btn_down = GetWidget("Button_Down");
               btn_back = GetWidget("Button_Back");
               UISceneWidget.Get(btn_up.gameObject).onClick += page_up;
               UISceneWidget.Get(btn_down.gameObject).onClick += page_down;
               UISceneWidget.Get(btn_back.gameObject).onClick += btn_back_click;

          }

          private void btn_back_click(GameObject go)
          {
               UIName lastpage = (UIName)Enum.Parse(typeof(UIName), UI_Manager.Instance.GetStack().Pop().ToString());
               this.SetVisible(false);
               UI_Manager.Instance.SetVisible(lastpage.ToString(), true);
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
               UIdata.currentChapter = UIdata.current_pro.ToString() + "_s" + chpterindex.ToString();
               print(UIdata.currentChapter);
               ChangePanel(UIName.Panel_ModelSelect);
          }


          private void Update_chapter_language()
          {
               foreach (var item in chapterbtns)
               {
                    Text text = item.GetComponentInChildren<Text>();
                    string chapterkey = UIdata.current_pro.ToString() + item.name.Replace("Button_", "");
                    UILanguageTable lang = S_LoadTable.Instance.fn_getUILanguage(UIdata.ui_table_name, chapterkey);
                    if (text != null && lang != null)
                         text.text = lang.CurrentLan();
               }
          }

     }

}