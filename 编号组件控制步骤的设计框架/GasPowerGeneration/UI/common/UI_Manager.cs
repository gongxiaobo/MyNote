﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace GasPowerGeneration
{
     /// <summary>
     /// panel名称类
     /// </summary>
     public enum UIName
     {
          Panel_ChapterMenu = 1,
          Panel_ModelSelect = 2,
          Panel_CharacterSelect = 3,
          Panel_Loading = 4,
          Panel_Login = 5,
          Panel_WorldMenu = 6,
          Panel_StepMenu = 7,
     }

     /// <summary>
     /// UI管理类
     /// </summary>
     public class UI_Manager : GenericSingletonClass<UI_Manager>
     {
          //UIScene字典存储所有ui界面
          public Dictionary<string, UIScene> mUIScene = new Dictionary<string, UIScene>();

          Stack uiStack = new Stack();


          void Awake()
          {
               UI_Manager.Instance.InitializeUIs();
               UI_Manager.Instance.ShowUI();

          }


          public UIName first_panel;
          /// <summary>
          /// 初始化ui
          /// </summary>
          public void InitializeUIs()
          {
               mUIScene.Clear();

               Object[] uis = FindObjectsOfType(typeof(UIScene));// 获取所有ui面板存入字典
               if (uis != null)
               {
                    //将所有UI界面设置隐藏
                    foreach (Object obj in uis)
                    {
                         UIScene ui = obj as UIScene;
                         ui.SetVisible(false);
                         mUIScene.Add(ui.gameObject.name, ui);
                    }
               }
               //根据配置语言选择加载语言表格
               UIdata.first_lan = XMLOperation.xmlReadFirstLan();
               UIdata.second_lan = XMLOperation.xmlReadSecondLan();
               string lan = UIdata.first_lan == Language.Chinese ? UIdata.second_lan.ToString() : UIdata.first_lan.ToString();
               UIdata.ui_table_name = "language_" + lan;
               // print(UIdata.first_lan.ToString() + "#########" + UIdata.second_lan.ToString()+"#####"+UIdata.ui_table_name);
               //加载语言列表
               // S_LoadTable.Instance.fn_loadtable(UIdata.ui_table_name, "ui");

          }
          /// <summary>
          /// 控制UI显隐
          /// </summary>
          /// <param name="name"></param>
          /// <param name="visible"></param>
          public void SetVisible(string name, bool visible)
          {
               if (visible && !IsVisible(name))
               {
                    OpenScene(name);

               }
               else if (!visible && IsVisible(name))
               {
                    CloseScene(name);
               }
          }
          /// <summary>
          /// 反馈ui显隐状态
          /// </summary>
          /// <param name="name"></param>
          /// <returns></returns>
          public bool IsVisible(string name)
          {
               UIScene ui = GetUI(name);
               if (ui != null)
                    return ui.IsVisible();
               return false;
          }
          private UIScene GetUI(string name)
          {
               UIScene ui;
               return mUIScene.TryGetValue(name, out ui) ? ui : null;
          }

          public T GetUI<T>(string name) where T : UIScene
          {
               return GetUI(name) as T;
          }
          /// <summary>
          /// 判断ui字典中是否是否包含该ui
          /// </summary>
          /// <param name="name"></param>
          /// <returns></returns>
          private bool isLoaded(string name)
          {

               if (mUIScene.ContainsKey(name))
               {
                    return true;
               }
               return false;
          }
          /// <summary>
          /// 设置ui界面显示
          /// </summary>
          /// <param name="name"></param>
          private void OpenScene(string name)
          {

               if (isLoaded(name))
                    mUIScene[name].SetVisible(true);
               //mUIScene[name].updatelanguage();



          }
          private void CloseScene(string name)
          {
               if (isLoaded(name))
               {
                    mUIScene[name].SetVisible(false);
               }
          }

          /// <summary>	/// 显示UI（一级界面）	/// </summary>
          public void ShowUI()
          {
               SetVisible(first_panel.ToString(), true);


          }


          //在棧中記錄當前界面
          public void GetInStack(UIName UISceneName)
          {
               uiStack.Push(UISceneName);//記錄本次UI界面的名稱/界面切換時將本次場景名稱放入到棧中
          }
          //取出栈中数据
          public Stack GetStack()
          {
               foreach (var item in uiStack)
               {
                    print(item.ToString());
               }
               return uiStack;
          }

          public List<string> fn_get_mode_info()
          {
               List<string> modes = new List<string>();
               foreach (var item in S_LoadTable.Instance.M_loginui_dic)
               {
                    if (!modes.Contains(item.Value.sec_name))
                    {
                         modes.Add(item.Value.sec_name);
                    }
               }
               return modes;
          }

          public List<string> fn_get_chapter_info(string mode)
          {
               List<string> chapters = new List<string>();
               foreach (var item in S_LoadTable.Instance.M_loginui_dic)
               {
                    if (item.Value.sec_name == mode)
                    {
                         if (!chapters.Contains(item.Value.third_name))
                         {
                              chapters.Add(item.Value.third_name);
                         }
                    }
               }
               return chapters;
          }
          public List<string> fn_get_step_info(string mode, string chapter)
          {
               List<string> steps = new List<string>();
               foreach (var item in S_LoadTable.Instance.M_loginui_dic)
               {
                    if (item.Value.sec_name == mode && item.Value.third_name == chapter)
                    {
                         if (!steps.Contains(item.Value.for_name))
                         {
                              steps.Add(item.Value.for_name);
                         }
                    }

               }
               return steps;
          }

          public string fn_get_step_index(string step_name)
          {
               foreach (var item in S_LoadTable.Instance.M_loginui_dic)
               {
                    if (item.Value.for_name == step_name)
                    {
                         return item.Value.chapter_id;
                    }

               }
               return "";
          }
     }

}