using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Connection.TableMode;
namespace GasPowerGeneration
{
     /// <summary>
     /// 模式选择的UI控制
     /// 组装跨场景消息
     /// 18925融合装表接电的模式要求
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
               if (btn_train!=null&&btn_exam!=null&&btn_free!=null)
               {
                    fnp_changeLanguage(btn_train.gameObject);
                    fnp_changeLanguage(btn_exam.gameObject);
                    fnp_changeLanguage(btn_free.gameObject); 
               }
          }
          public Text m_train, m_test;
          protected override void fnp_changeLanguage(GameObject _obj)
          {
               //base.fnp_changeLanguage(_obj);
               if (_obj == null)
               {
                    return;
               }
               Text t_txt = _obj.GetComponentInChildren<Text>();
               UILanguageTable t_tableinfo =
                    S_LoadTable.Instance.fn_getUILanguage("language_English", _obj.name);
               if (t_txt == null || t_tableinfo == null)
               {
                    return;
               }
               //t_txt.text =
               //     UIdata.language_type == Language.Chinese ? t_tableinfo.Firstlan : t_tableinfo.Secondlan;
               //在装表接电模式下，模式名称的匹配
               fnp_setName();
          }

          private void fnp_setName()
          {
               if (S_SceneMessage.Instance.m_isTableModel)
               {

                    //Debug.Log("<color=red>模式的名称：</color>");

                    if (m_train.text != "培训模式")
                    {
                         m_train.text = "培训模式";
                    }
                    if (m_test.text != "训练模式")
                    {
                         m_test.text = "训练模式";
                    }
               }
          }
          public override void UpdateLanguage()
          {
               base.UpdateLanguage();
               //在装表接电模式下，模式名称的匹配
               fnp_setName();
          }
         
          void OnEnable() {
              if (btn_exam != null)
              {
                  //如为复合关卡 隐藏考试模式
                  if (UIdata.compound_step)
                      btn_exam.gameObject.SetActive(false);
                  else
                      btn_exam.gameObject.SetActive(true);
              }
              fnp_modeText();
              //Debug.Log("<color=blue>模式面板激活</color>");
              fnp_AutoLoad();
     
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
          /// 在装表接电模式下，故障和引导模式自动跳转场景，无需选择训练还是考试模式
          /// </summary>
          private void fnp_AutoLoad()
          {
               if (S_SceneMessage.Instance.m_isTableModel==false)
               {
                    return;
               }
               if (UIdata.currentStep=="")
               {
                    return;
               }
               //表的编号
               string chapter_id = UI_Manager.Instance.fn_get_step_index(UIdata.currentStep);
               if (chapter_id=="46")
               {
                    btn_exam_click(this.gameObject);
               }
               else if (chapter_id == "47")
               {
                    btn_train_click(this.gameObject);
               }

          }
          public int m_testTroubleID = 61;
          /// <summary>
          /// 装表接电的模式
          /// </summary>
          E_TableMode m_tablemode = E_TableMode.e_null;
          public Vector2 m_TroubleRange = new Vector2(61, 67);
          /// <summary>
          /// 在装表接电模式下，对步骤的模式和故障模式的找出找表进行处理
          /// </summary>
          /// <param name="_stepID"></param>
          /// <param name="_initName"></param>
          /// <param name="_stepName"></param>
          private void fnp_Table(string _stepID, out string _initName, out string _stepName)
          {
               string t_stepID = _stepID;
               //对模式进行再次处理
               switch (_stepID)
               {
                    case "43"://高供高计
                    case "44"://高供低计
                    case "45"://低供低计
                         if (UIdata.trainMode == Select_mode.train)
                         {
                              m_tablemode = E_TableMode.e_learn;
                         }
                         else if (UIdata.trainMode == Select_mode.test)
                         {
                              m_tablemode = E_TableMode.e_test;
                         }
                         _stepName = "debug_s" + t_stepID + "_step_" + language_csv_read();
                         break;
                    case "46"://故障模式
                         UIdata.trainMode = Select_mode.test;
                         m_tablemode = E_TableMode.e_troubleshooting;
                         //随机故障步骤[60-70)
                         t_stepID = UnityEngine.Random.Range((int)m_TroubleRange.x, (int)m_TroubleRange.y).ToString();
                         //t_stepID = m_testTroubleID.ToString();
                         _stepName = "debug_s" + "43" + "_step_" + language_csv_read();
                         break;
                    case "47"://新手引导
                         UIdata.trainMode = Select_mode.train;
                         m_tablemode = E_TableMode.e_newbird;
                         _stepName = "debug_s" + t_stepID + "_step_" + language_csv_read();
                         break;
                    default:
                         _stepName = "debug_s" + t_stepID + "_step_" + language_csv_read();
                         break;
               }

               _initName = "debug_s" + t_stepID + "_train";
               //_stepName = "debug_s" + t_stepID + "_step_" + language_csv_read();
               
               //Debug.Log("<color=blue>step table : </color>"+_stepName);
               S_SceneMessage.Instance.m_TableMode = m_tablemode;
               //为装表接电场景使用，步骤表的ID
               S_SceneMessage.Instance.m_TableStep = t_stepID;
          }
          /// <summary>
          /// 切换场景时执行
          /// </summary>
          private void Change_scene()
          {
               //表的编号
               string chapter_id = UI_Manager.Instance.fn_get_step_index(UIdata.currentStep);
               if (UIdata.compound_step)
               {//是否是复合关卡
                    fn_handle_compound_step(chapter_id);
                    initFormName = "debug_s" + UIdata.compound_steps_id[0] + "_train";
                    stepFormName = "debug_s" + UIdata.compound_steps_id[0] + "_step_" + language_csv_read();
               }
               else if (chapter_id != "")
               {//普通关卡
                    initFormName = "debug_s" + chapter_id + "_train";
                    stepFormName = "debug_s" + chapter_id + "_step_" + language_csv_read();
               }
               else
               {
                    print("关卡编号返回值有误");
               }
               
               //在这里为装表接电单独处理，主要处理附加的模式，和故障随机步骤的选择
               if (S_SceneMessage.Instance.m_isTableModel)
               {
                    fnp_Table(chapter_id, out initFormName, out stepFormName);
               }
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