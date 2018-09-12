using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace GasPowerGeneration
{
     public class Panel_model : UIScene
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


               initFormName = UIdata.currentChapter.ToLower() + "_train";
               stepFormName = UIdata.currentChapter.ToLower() + "_step_" + language_csv_read();
               print(initFormName);
               print(stepFormName);
               //发送UI选择的关卡信息
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
               SceneManager.LoadScene("test_step1");//场景切换
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