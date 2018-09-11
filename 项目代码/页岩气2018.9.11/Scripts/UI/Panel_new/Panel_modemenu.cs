using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 模式选择的UI控制
     /// </summary>
     public class Panel_modemenu : UIScene
     {

          private UISceneWidget btn_train, btn_exam, btn_free, btn_back;
          //初始化科目表格名称
          private string initFormName;
          /// <summary>
          /// 步骤表格名称
          /// </summary>
          private string stepFormName;
          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               btn_train = GetWidget("Button_TrainModel");
               btn_exam = GetWidget("Button_ExamModel");
               btn_free = GetWidget("Button_FreeModel");
               btn_back = GetWidget("Button_Back");
               UISceneWidget.Get(btn_train.gameObject).onClick += btn_train_click;
               UISceneWidget.Get(btn_exam.gameObject).onClick += btn_exam_click;
               UISceneWidget.Get(btn_free.gameObject).onClick += btn_free_click;
               UISceneWidget.Get(btn_back.gameObject).onClick += btn_back_click;
               fnp_modeText();
             
          }
          protected void fnp_modeText()
          {
               fnp_changeLanguage(btn_train.gameObject);
               fnp_changeLanguage(btn_exam.gameObject);
               fnp_changeLanguage(btn_free.gameObject);
          }
          ///// <summary>
          ///// 训练，考试，模式的多语言显示
          ///// </summary>
          ///// <param name="_obj"></param>
          //protected void fnp_changeLanguage(GameObject _obj)
          //{
          //     if (_obj==null)
          //     {
          //          return;
          //     }
          //     Text t_txt = _obj.GetComponentInChildren<Text>();
          //     UILanguageTable t_tableinfo = 
          //          S_LoadTable.Instance.fn_getUILanguage("language_English", _obj.name);
          //     if (t_txt==null || t_tableinfo==null)
          //     {
          //          return;
          //     }
          //     t_txt.text=
          //          UIdata.language_type== Language.Chinese?t_tableinfo.Firstlan:t_tableinfo.Secondlan;
               
          //}
          void OnEnable() {
              if (btn_exam != null)
              {
                  //如为复合关卡 隐藏考试模式
                  if (UIdata.compound_step)
                      btn_exam.gameObject.SetActive(false);
                  else
                      btn_exam.gameObject.SetActive(true);
              }
          }


          string message_to_send;

          private void btn_free_click(GameObject go)
          {
               UIdata.trainMode = Select_mode.free;

               Change_scene();
          }

          private void btn_exam_click(GameObject go)
          {
               UIdata.trainMode = Select_mode.test;
               Change_scene();
          }

          private void btn_train_click(GameObject go)
          {
               UIdata.trainMode = Select_mode.train;
               Change_scene();
          }
          /// <summary>
          /// 切换场景时执行
          /// </summary>
          private void Change_scene()
          {
               string chapter_id = UI_Manager.Instance.fn_get_step_index(UIdata.currentStep);
               if (UIdata.compound_step)
               {
                    fn_handle_compound_step(chapter_id);
                    initFormName = "debug_s" + UIdata.compound_steps_id[0] + "_train";
                    stepFormName = "debug_s" + UIdata.compound_steps_id[0] + "_step_" + language_csv_read();
               }
               else if (chapter_id != "")
               {
                    initFormName = "debug_s" + chapter_id + "_train";
                    stepFormName = "debug_s" + chapter_id + "_step_" + language_csv_read();
               }
               else
               {
                    print("关卡编号返回值有误");
               }
               print(initFormName);
               print(stepFormName);
               //关卡初始化消息
               AB_Message t_msg = new N_Message();
               t_msg.fn_init(E_MessageType.e_sceneMsg,
                    new StateValue[5]{
               new StateValueString("sceneType",UIdata.trainMode.ToString()),
               new StateValueString("subject_init",initFormName),
               new StateValueString("subject_step",stepFormName),
               new StateValueString("lg",UIdata.language_type.ToString()),
               new StateValueString("item_name","item_names_"+language_csv_read())},
                    "sceneMsg", 0, 0);
               S_SceneMessage.Instance.fn_addMsg(t_msg);

               S_SceneMessage.Instance.me_thisSceneName = E_sceneName.e_step;

               S_update.Instance.fn_kill();
               GlobalEventSystemMaitenance.CleanUpEventSystem();
               if (UIdata.currentChapter == "beng_check"||
                    UIdata.currentChapter == "beng_setup"){
                    //检泵场景
                    SceneManager.LoadScene("BengCheck");
               }
               else if (UIdata.currentChapter == "connect")
               {
                    //装表接电场景
                    SceneManager.LoadScene("Table1");
               }
               else
               {
                    //燃气发电场景
                   SceneManager.LoadScene("test_step1");
               }
          }

          /// <summary>
          /// 后退按钮
          /// </summary>
          /// <param name="go"></param>
          private void btn_back_click(GameObject go)
          {
               UIName lastpage = (UIName)Enum.Parse(typeof(UIName), UI_Manager.Instance.GetStack().Pop().ToString());
               this.SetVisible(false);
               UI_Manager.Instance.SetVisible(lastpage.ToString(), true);
          }
          /// <summary>
          /// 获取当前语言
          /// </summary>
          /// <returns></returns>
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

          void fn_handle_compound_step(string compound_info)
          {
               //拆分复合关卡信息 获取关卡数量和id
               string[] temp = compound_info.Split('_');
               string[] compound_chapters = temp[1].Split('|');
               if (UIdata.compound_steps_id != null)
                    UIdata.compound_steps_id.Clear();
               UIdata.compound_steps_id = new List<string>(compound_chapters);
          }
     }

}