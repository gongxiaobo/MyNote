#define test
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Connection.TableMode;
using Assets.Scripts.Connection.LearnModeConnect;
namespace GasPowerGeneration
{
     /// <summary>
     /// 训练科目
     /// 考试科目
     /// 检查提示器
     /// 加入高亮提示物体的功能
     /// 加入特殊物体的检测范围只是在一个步骤中有效
     /// 回滚步骤后取消当前步骤的高亮
     /// 回滚步骤取消以前声音的播放
     /// 高亮类型不计入统计分数里面
     /// </summary>
     public class N_SubjectCheck : AB_SubjectCheck, I_LearnModePause, I_TablePutTestResult
     {
          //步骤检查完成后的反馈
          Action m_callback;
          //选择的模式
          E_mode me_mode;
          //Dictionary<string, subject_step> m_tableDate = new Dictionary<string, subject_step>();
          //考试的检测物件
          List<subject_step> m_steps = new List<subject_step>();
          //检查步骤的分组
          Dictionary<int, List<subject_step>> m_stepgroup =
               new Dictionary<int, List<subject_step>>();
          int m_maxStep = 0;
          //当前的语言
          [SerializeField]
          string m_language = "";
          public override void fn_init(Action _callback, E_mode _mode)
          {
               m_language = S_SceneMessage.Instance.fn_getLanguage();
               me_mode = _mode;
               m_callback = _callback;
               //所有的状态值拉取
               mi_CheckValue = S_SceneMagT1.Instance;
               //高亮指定的item
               mi_LightItemID = S_SceneMagT1.Instance;
               //拉取步骤数据
               AB_Message t_sceneMsg = S_SceneMessage.Instance.fn_getMsg("sceneMsg");
               if (t_sceneMsg != null)
               {
                    string t_stepTableName =
                         ((StateValueString)t_sceneMsg.fn_getContent("subject_step")).m_date;
                    if (t_stepTableName == "")
                    {//没有找到步骤表格
                         return;
                    }
                    Dictionary<string, subject_step> t_tableDate =
                         S_LoadTable.Instance.fn_getSubStep(t_stepTableName);
                    if (t_tableDate.Count > 0)
                    {
                         //步骤表数据单独保存
                         S_TableStepInfo.Instance.M_tableDate = t_tableDate;
                         //把相同的步骤装入步骤集合
                         int t_step = 0;
                         foreach (subject_step item in t_tableDate.Values)
                         {
                              if (me_mode == E_mode.e_test)
                              {//考试场景的步骤装载
                                   m_steps.Add(item);

                              }
                              else if (me_mode == E_mode.e_train)
                              {
                                   if (item.m_step != t_step)
                                   {
                                        t_step = item.m_step;
                                        if (!m_stepgroup.ContainsKey(t_step))
                                        {
                                             m_stepgroup.Add(t_step, new List<subject_step>());
                                             m_stepgroup[t_step].Add(item);
                                        }
                                        else
                                        {
                                             m_stepgroup[t_step].Add(item);
                                        }
                                   }
                                   else
                                   {
                                        if (m_stepgroup.ContainsKey(t_step))
                                        {
                                             m_stepgroup[t_step].Add(item);
                                        }

                                   }
                              }
                              else
                              {
                                   fn_kill();

                              }

                         }
                         m_maxStep = t_step;


                    }

               }
               if (m_stepgroup.Count > 0 || m_steps.Count > 0)
               {
                    if (me_mode == E_mode.e_train || me_mode == E_mode.e_test)
                    {
                         fnp_startend();
                         fnp_startCheck();
                    }
               }
          }
          /// <summary>
          /// 正在检查的步骤编号
          /// </summary>
          int m_WorkingStep = 0;
          I_CheckStateValue mi_CheckValue = null;
          /// <summary>
          /// 高亮提示功能接口
          /// </summary>
          I_LightItemID mi_LightItemID = null;
          /// <summary>
          /// 装表接电下，学习模式的自动连接线功能
          /// </summary>
          AB_LearnModeConnect m_learnMode = null;
          public AB_LearnModeConnect fni_getLearnMode()
          {
               return m_learnMode;
          }
          protected override void fnp_startCheck()
          {
               if (me_mode == E_mode.e_train)
               {
                    //开始播放开始的语音提示，在两秒钟后开始训练模式
                    S_SoundComSingle.Instance.fnp_sound(m_startSoundName);
                    InvokeRepeating("fnp_check", 5f, 1f);
                    fnp_updateTime(M_TainTimeCount, 0);
                    //Debug.Log("<color=blue>开始训练模式</color>");
                    if (S_SceneMessage.Instance.m_TableMode == E_TableMode.e_learn)
                    {//在装表接电的学习模式下，开启自动连接线
                         //m_learnMode=
                         GameObject t_lernmode = new GameObject("LearnModeConnect");
                         m_learnMode = t_lernmode.AddComponent<N_LearnModeConnect_01>();
                    }
               }
               else if (me_mode == E_mode.e_test)
               {
                    //Debug.Log("<color=blue>开始考试模式</color>");
                    //开始播放开始的语音提示，在两秒钟后开始考试模式
                    S_SoundComSingle.Instance.fnp_sound(m_startSoundName);
                    InvokeRepeating("fnp_TestCheck", 5f, 1f);
                    fnp_updateTime(M_TestTimeCount, 0);
               }

          }
          /// <summary>
          /// 刷新倒计时
          /// </summary>
          /// <param name="_maxTime"></param>
          /// <param name="_nowTime"></param>
          protected void fnp_updateTime(int _maxTime, int _nowTime)
          {
               HandUI_manager.Instance.fn_update_time(_maxTime * 60 - _nowTime);
          }
          /// <summary>
          /// 测试时间，分钟计算
          /// </summary>
          public int M_TainTimeCount = 30;
          int t_trainTime = 0;
          /// <summary>
          /// 检查每一步的是否通过
          /// </summary>
          private void fnp_check()
          {
               t_trainTime += 1;
               fnp_updateTime(M_TainTimeCount, t_trainTime);
               bool t_check = false;
               for (int i = 1; i <= m_maxStep; i++)
               {
                    //Debug.Log("<color=blue>检查步骤:</color>" + i);
                    //检查每一步的观察item状态值
                    for (int j = 0; j < m_stepgroup[i].Count; j++)
                    {
                         //if (t_check==false)
                         //{
                         if (mi_CheckValue.fni_checkItemType(m_stepgroup[i][j].m_id)
                                        == E_ItemType.e_check)
                         {//检查类型

#if test

                              string t_sceneValue = mi_CheckValue.fni_checkDate(m_stepgroup[i][j].m_id);
                              string t_tablevalue = m_stepgroup[i][j].m_state;
                              E_valueType t_type = mi_CheckValue.fni_checkItemValueType(m_stepgroup[i][j].m_id);
                              if (mi_CheckValue.fni_checkDate(m_stepgroup[i][j].m_id, E_StateValueType.e_check) == "right" &&
                                   S_checkValue.fns_isInArea(t_sceneValue, t_tablevalue, t_type))
                              {
                                   //continue;
                                   fnp_lightStepObj(i, j, false);
                              }
                              else if (mi_CheckValue.fni_checkDate(m_stepgroup[i][j].m_id, E_StateValueType.e_check) == "error" &&
                              S_checkValue.fns_isInArea(t_sceneValue, t_tablevalue, t_type) == false)
                              {
                                   //continue;
                                   fnp_lightStepObj(i, j, false);
                              }
                              else
                              {//未通过状态

                                   fnp_TrainSound(i, j);
                                   t_check = true;
                                   fnp_lightStepObj(i, j);
                                   //break;
                              }

#else

                         if (mi_CheckValue.fni_checkDate(m_stepgroup[i][j].m_id, E_StateValueType.e_check) != "idle")
                         {
                              continue;
                         }
                         else
                         {
                              fnp_TrainSound(i, j);
                              t_check = true;
                              break;
                         } 
#endif
                         }
                         else
                         {//操作类型
                              if (m_stepgroup[i][j].m_condition == "")
                              {
                                   if (fnp_CheckTheValues(m_stepgroup[i][j].m_state,
                                         mi_CheckValue.fni_checkDate(m_stepgroup[i][j].m_id)))
                                   {//场景中状态和配置表状态一直，通过
                                        //continue;
                                        fnp_lightStepObj(i, j, false);
                                   }
                                   else
                                   {//未通过状态

                                        fnp_TrainSound(i, j);
                                        t_check = true;
                                        fnp_lightStepObj(i, j);
                                        //break;
                                   }
                              }
                              else if (m_stepgroup[i][j].m_condition == "light")
                              {
                                   //Debug.Log("<color=blue>blue:</color>");
                                   //如果是简单步骤高亮item,那么就不进入步骤的通过检查，只是达成条件就不高亮，
                                   //并且是正在检查这一步时才检查
                                   if (m_WorkingStep == i || ((m_WorkingStep == (i - 1)) && j == 0))
                                   {//正在检查这一步的时候,状态是符合表中的要求，跳过
                                        if (fnp_CheckTheValues(m_stepgroup[i][j].m_state,
                                         mi_CheckValue.fni_checkDate(m_stepgroup[i][j].m_id)))
                                        {//场景中状态和配置表状态一直，通过
                                             //continue;
                                             mi_LightItemID.fni_endLight(m_stepgroup[i][j].m_id);
                                             fnp_lightStepObj(i, j, false);
                                        }
                                        else
                                        {//未通过状态fni_endLight

                                             mi_LightItemID.fni_lightOn(m_stepgroup[i][j].m_id);
                                             //Debug.Log("<color=blue>blue2:</color>");
                                             fnp_lightStepObj(i, j);
                                             //if (true)
                                             //{
                                             fnp_TrainSound(i, j);
                                             t_check = true;
                                             //}
                                        }
                                        //continue;
                                   }

                              }



                         }
                         //}

                    }
                    if (!S_SceneMessage.Instance.m_isTableModel)
                    {
                         if ((M_TainTimeCount * 60) <= t_trainTime)
                         {//训练时间到
                              t_check = false;
                         }
                    }


                    if (t_check)
                    {

                         break;
                    }
               }
               if (t_check == false)
               {
                    fnp_endCheck();
               }
          }
          /// <summary>
          /// 为了解决装表接电的值对比判断
          /// </summary>
          /// <param name="_table"></param>
          /// <param name="_now"></param>
          /// <returns></returns>
          private bool fnp_CheckTheValues(string _table, string _now)
          {
               if (S_SceneMessage.Instance.m_isTableModel)
               {//装表接电模式下
                    return S_ParseWirePara.fn_checkValueSame(_table, _now);
               }
               else
               {
                    return (_table == _now);
               }
               //return true;
          }

          private void fnp_lightStepObj(int i, int j, bool t_check = true)
          {
               if (t_check)
               {//高亮需要操作的物体
                    //需要确定状态是否是匹配

                    if (mi_LightItemID != null)
                    {
                         if (m_stepgroup[i][j].m_condition != "light")
                         {
                              mi_LightItemID.fni_lightOn(m_stepgroup[i][j].m_id);
                         }
                    }
               }
               else
               {
                    if (mi_LightItemID != null)
                    {
                         if (m_stepgroup[i][j].m_condition != "light")
                         {
                              mi_LightItemID.fni_endLight(m_stepgroup[i][j].m_id);
                         }
                    }
               }
          }
          /// <summary>
          /// 当前步骤需要播放的语音名称
          /// </summary>
          protected string m_soundNameNow = "";
          private void fnp_TrainSound(int i, int j)
          {
               if (m_WorkingStep > i)
               {//不只是回滚步骤才停止以前的步骤高亮物体
                    //检查每一步的观察item状态值
                    //if (m_WorkingStep>0)
                    {

                         for (int j1 = 0; j1 < m_stepgroup[m_WorkingStep].Count; j1++)
                         {//取消这个一步的高亮
                              fnp_lightStepObj(m_WorkingStep, j1, false);
                         }
                    }
                    S_SoundComSingle.Instance.fnp_sound("warming01", true);
               }
               if (m_WorkingStep != i)
               {


                    if (me_mode == E_mode.e_train)
                    {//播放步骤语音
                         //这里还需要选择语言的情况处理，以后处理
                         if (m_language == "Chinese")
                         {
                              string t_soundNamelast = m_stepgroup[m_WorkingStep == 0 ? 1 : m_WorkingStep][0].m_ch_voice;
                              S_SoundComSingle.Instance.fnp_sound(t_soundNamelast, false);
                              string t_soundName = m_stepgroup[i][0].m_ch_voice;
                              S_SoundComSingle.Instance.fnp_sound(t_soundName);
                              fnp_noSound(t_soundName);
                              fnp_setTrainDetailEvent(m_stepgroup[i][0].m_ch_txt);
                              if (S_SceneMessage.Instance.m_TableMode == E_TableMode.e_learn)
                              {//在装表接电的学习模式下，开启一次自动连接线
                                   if (m_learnMode != null)
                                   {
                                        int t_id = m_stepgroup[i][0].m_id;
                                        m_learnMode.fn_callOneConnect(t_id.ToString(),
                                             mi_CheckValue.fni_checkDate(t_id),
                                             m_stepgroup[i][0].m_state, m_soundNameNow);
                                   }
                              }
                         }
                         else
                         {
                              string t_soundNamelast = m_stepgroup[m_WorkingStep == 0 ? 1 : m_WorkingStep][0].m_en_voice;
                              S_SoundComSingle.Instance.fnp_sound(t_soundNamelast, false);
                              string t_soundName = m_stepgroup[i][0].m_en_voice;
                              S_SoundComSingle.Instance.fnp_sound(t_soundName);
                              fnp_noSound(t_soundName);
                              fnp_setTrainDetailEvent(m_stepgroup[i][0].m_en_txt);
                         }

                    }
                    m_WorkingStep = i;

               }
          }
          /// <summary>
          /// 在装表接电的培训模式下，步骤提示文字事件
          /// </summary>
          /// <param name="_txt"></param>
          protected void fnp_setTrainDetailEvent(string _txt)
          {
               GlobalEventSystem<Event_StepDetail>.Raise(new Event_StepDetail(_txt));
          }
          private void fnp_noSound(string t_soundName)
          {
               if (t_soundName == "")
               {
                    Debug.Log("<color=red>can not find step </color>" + m_WorkingStep + " sound name");
               }
               else
               {
                    m_soundNameNow = t_soundName;
               }
          }
          [SerializeField]
          string m_startSoundName;
          [SerializeField]
          string m_endSoundName;
          /// <summary>
          /// 开始结束的语音
          /// 新增装表接电的开始语音
          /// </summary>
          protected virtual void fnp_startend()
          {
               if (S_LoadTable.Instance.M_normalsound.ContainsKey(m_language))
               {
                    if (me_mode == E_mode.e_train)
                    {
                         if (S_SceneMessage.Instance.m_isTableModel == false)
                         {
                              m_startSoundName = S_LoadTable.Instance.M_normalsound[m_language].m_startTrain;
                              m_endSoundName = S_LoadTable.Instance.M_normalsound[m_language].m_endTrain;
                              return;
                         }
                    }
                    else if (me_mode == E_mode.e_test)
                    {
                         if (S_SceneMessage.Instance.m_isTableModel == false)
                         {
                              m_startSoundName = S_LoadTable.Instance.M_normalsound[m_language].m_startTest;
                              m_endSoundName = S_LoadTable.Instance.M_normalsound[m_language].m_endTest;
                              return;
                         }
                    }
               }
               else
               {
                    Debug.Log("<color=red>not find sound name!</color>");
               }
               switch (S_SceneMessage.Instance.m_TableMode)
               {
                    case E_TableMode.e_null:
                         break;
                    case E_TableMode.e_learn:
                         m_startSoundName = S_LoadTable.Instance.M_specialsounds["Table_system_info 6"].m_sound_c;
                         break;
                    case E_TableMode.e_test:
                         m_startSoundName = S_LoadTable.Instance.M_specialsounds["Table_system_info 7"].m_sound_c;
                         break;
                    case E_TableMode.e_troubleshooting:
                         m_startSoundName = S_LoadTable.Instance.M_specialsounds["Table_system_info 8"].m_sound_c;
                         break;
                    case E_TableMode.e_newbird:
                         m_startSoundName = S_LoadTable.Instance.M_specialsounds["Table_system_info 9"].m_sound_c;
                         break;
                    default:
                         break;
               }
               m_endSoundName = S_LoadTable.Instance.M_specialsounds["Table_system_info 10"].m_sound_c;

          }
          /// <summary>
          /// 考试步骤对错的记录
          /// </summary>
          protected Dictionary<int, bool> m_testRusult = new Dictionary<int, bool>();
          /// <summary>
          /// 步骤编号-item编号
          /// </summary>
          protected Dictionary<int, int> m_testRusultItem = null;
          /// <summary>
          /// 考试时间，分钟计算
          /// </summary>
          public int M_TestTimeCount = 1;
          int t_testTime = 0;
          private void fnp_TestCheck()
          {
               t_testTime += 1;
               fnp_updateTime(M_TestTimeCount, t_testTime);
               if (m_testRusultItem == null)
               {
                    m_testRusultItem = new Dictionary<int, int>();
                    for (int i = 0; i < m_steps.Count; i++)
                    {
                         if (m_steps[i].m_condition == "")
                         {//高亮类型不计入统计分数里面
                              m_testRusultItem.Add(i, m_steps[i].m_id);
                         }
                    }
               }
               bool t_check = true;
               for (int i = 0; i < m_steps.Count; i++)
               {



                    if (!m_testRusult.ContainsKey(i))
                    {
                         if (m_steps[i].m_condition == "")
                         {//高亮类型不计入统计分数里面
                              m_testRusult.Add(i, false);
                         }
                         //m_testRusult.Add(i, false);
                    }
                    if (mi_CheckValue.fni_checkItemType(m_steps[i].m_id)
                              == E_ItemType.e_check)
                    {//检查类型
                         string t_sceneValue = mi_CheckValue.fni_checkDate(m_steps[i].m_id);
                         string t_tablevalue = m_steps[i].m_state;
                         E_valueType t_type = mi_CheckValue.fni_checkItemValueType(m_steps[i].m_id);

                         if (S_checkValue.fns_isInArea(t_sceneValue, t_tablevalue, t_type) &&
                              mi_CheckValue.fni_checkDate(
                                   m_steps[i].m_id, E_StateValueType.e_check) == "right")
                         {
                              m_testRusult[i] = true;
                              continue;
                         }
                         else if ((S_checkValue.fns_isInArea(t_sceneValue, t_tablevalue, t_type) == false) &&
                              mi_CheckValue.fni_checkDate(
                                   m_steps[i].m_id, E_StateValueType.e_check) == "error")
                         {
                              m_testRusult[i] = true;
                              continue;
                         }
                         else
                         {
                              m_testRusult[i] = false;
                              //t_check = true;
                              //break;
                         }
                    }
                    else
                    {//交互类型
                         if (m_steps[i].m_condition == "")
                         {
                              if (fnp_CheckTheValues(m_steps[i].m_state, mi_CheckValue.fni_checkDate(m_steps[i].m_id)))
                              {//场景中状态和配置表状态一直，通过
                                   m_testRusult[i] = true;
                                   continue;
                              }
                              else
                              {//未通过状态
                                   //t_check = true;
                                   //break;
                                   m_testRusult[i] = false;
                                   Debug.Log("<color=blue>未通过的步骤:</color>" + m_steps[i].m_index);
                              }
                         }
                         else if (m_steps[i].m_condition == "light")
                         {//高亮类型不计入统计分数里面
                              //m_testRusult[i] = true;
                              continue;
                         }

                    }

               }
               if (!S_SceneMessage.Instance.m_isTableModel)
               {//装表接电不记时
                    if ((M_TestTimeCount * 60) <= t_testTime)
                    {//考试时间到
                         t_check = false;
                    }
               }

               if (t_check)
               {//重复
                    return;
               }
               else
               {
                    if (S_SceneMessage.Instance.m_isTableModel)
                    {
                         if (S_SceneMessage.Instance.m_TableMode == E_TableMode.e_test ||
                                       S_SceneMessage.Instance.m_TableMode == E_TableMode.e_troubleshooting)
                         {//装表接电考试模式
                              //if (fnp_TableTestCheck())
                              //{
                              //     //fnp_endCheck();
                              //}
                              //else
                              //{

                              //}
                         }
                    }
                    else
                    {

                         fnp_endCheck();
                    }
               }

          }
          /// <summary>
          /// 装表接电中，考试模式可以反复提交，直到所有都做正确
          /// false==有错误
          /// </summary>
          /// <returns></returns>
          protected bool fnp_TableTestCheck()
          {
               //for (int i = 0; i < m_testRusult.Count; i++)
               //{
               //     if (m_testRusult[i] == false)
               //     {
               //          return false;
               //     }

               //}
               //IDictionary<int,bool>t_rusult=m_testRusult.
               foreach (var item in m_testRusult.Keys)
               {
                    if (m_testRusult[item] == false)
                    {
                         return false;
                    }
                   
               }
               return true;
          }
          /// <summary>
          /// 考试训练模式结束调用
          /// </summary>
          public override void fnp_endCheck()
          {
               S_SoundComSingle.Instance.fnp_sound(m_endSoundName);
               //Debug.Log("<color=blue>结束检查:</color>");
               fnp_setTrainDetailEvent("");
               fnp_cansel();

               if (m_callback != null)
               {
                    m_callback();
               }
               //结束训练或者考试结束
               if (me_mode == E_mode.e_test)
               {
                    if (S_SceneMessage.Instance.m_isTableModel == false)
                    {
                         fnp_debugTestResult();
                    }
                    else
                    {//装表接电模式下

                    }
               }
          }

          private void fnp_cansel()
          {
               if (me_mode == E_mode.e_train)
               {
                    CancelInvoke("fnp_check");
               }
               else if (me_mode == E_mode.e_test)
               {
                    CancelInvoke("fnp_TestCheck");
               }
          }
          public override void fn_kill()
          {
               fnp_cansel();
               Destroy(this);
               Destroy(this.gameObject);
          }

          protected void fnp_debugTestResult()
          { //临时添加代码查看考试结构
               //GameObject.Find("ScoreUI").GetComponent<Score>().ShowScore(m_testRusult, m_testRusultItem);
               if (m_testRusult == null || m_testRusultItem == null)
               {
                    //throw new System.NullReferenceException();

                    Debug.Log("<color=red>m_testRusult == null || m_testRusultItem == null</color>");

                    return;
               }
               //if (m_testRusult.Count != m_testRusultItem.Count)
               //{
               //     //throw new System.NullReferenceException();
               //}
               HandUI_manager.Instance.fn_show_score(m_testRusult, m_testRusultItem);
               //foreach (KeyValuePair<int, bool> item in m_testRusult)
               //{
               //    Debug.Log("<color=red>test : </color>" + m_testRusultItem[item.Key] + "->" + item.Value);

               //}
          }


          #region I_TablePutTestResult
          /// <summary>
          /// 装表接电中，考试模式和故障排除模式下提交测试结果的接口,true为测试通过
          /// </summary>
          /// <returns></returns>
          public bool fni_TablePutTestResult()
          {
               if (fnp_TableTestCheck())
               {//完全正确

                    return true;
               }
               else
               {

                    return false;
               }
          }

          /// <summary>
          /// 装表接电中，考试模式和故障排除模式下,获取错误的步骤详情
          /// </summary>
          /// <returns></returns>
          public subject_step fni_GetErrorStep()
          {
               //for (int i = 0; i < m_testRusult.Count; i++)
               //{
               //     if (m_testRusult[i] == false)
               //     {
               //          return m_steps[i];
               //     }

               //}
               foreach (var item in m_testRusult.Keys)
               {
                    if (m_testRusult[item] == false)
                     {
                          return m_steps[item];
                         
                     }
               }
               return null;
          }
          #endregion
     }

}