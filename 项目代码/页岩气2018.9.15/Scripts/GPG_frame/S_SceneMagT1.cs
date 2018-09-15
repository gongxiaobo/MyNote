using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.test.Optimization;
namespace GasPowerGeneration
{
     /// <summary>
     /// 调试培训的场景初始化工作,延迟2秒中初始化
     /// 实现高亮item的接口
     /// </summary>
     public class S_SceneMagT1 : GenericSingletonClass<S_SceneMagT1>, I_CheckStateValue,
          I_LightItemID, I_bubbleGetDetail, I_backToSelect, I_partPos
     {
          //每个科目的位置
          public AB_GetPos M_getPos { get; set; }
          //玩家移动
          public AB_MoveTo M_PlayerMove { get; set; }

          protected Dictionary<int, AB_State> m_Items = new Dictionary<int, AB_State>();
          public void fn_ItemLogin(int _ID, AB_State _state)
          {
               if (!m_Items.ContainsKey(_ID))
               {
                    m_Items.Add(_ID, _state);
               }
          }
          /// <summary>
          /// 所有效果，如灯光，声音的集合
          /// </summary>
          protected Dictionary<int, List<AB_effect>> m_ItemsEffect = new Dictionary<int, List<AB_effect>>();
          /// <summary>
          /// 加入效果到集合中
          /// </summary>
          /// <param name="_id"></param>
          /// <param name="_effect"></param>
          public void fn_putEffect(int _id, AB_effect _effect)
          {
               if (m_ItemsEffect.ContainsKey(_id))
               {
                    m_ItemsEffect[_id].Add(_effect);
               }
               else
               {
                    //List<AB_effect> t_listEffect = new List<AB_effect>();
                    //t_listEffect.Add(_effect);
                    m_ItemsEffect.Add(_id, new List<AB_effect>() { _effect });

               }
          }
          /// <summary>
          /// 根据ID获取效果序列
          /// </summary>
          /// <param name="_id"></param>
          /// <returns></returns>
          public List<AB_effect> fn_getEffect(int _id)
          {
               return m_ItemsEffect.ContainsKey(_id) ? m_ItemsEffect[_id] : null;
          }
          GameObject m_machineParent = null;
          // Use this for initialization
          void Start()
          {
               if (S_SceneMessage.Instance.me_thisSceneName != E_sceneName.e_step)
               {
                    return;
               }
              
               Debug.Log("<color=blue>blue:</color>" + S_SceneMessage.Instance.me_thisSceneName);
     
               //开始屏幕变黑
               SteamVR_Fade.Start(new Color(0f, 0f, 0f, 1f), 0f);
               m_isPause = false;
               m_readyback = false;
               Invoke("fnp_init1", 2f);
               S_SoundComSingle.Instance.fnp_sound("backsound01");
               Invoke("fnp_show", 2.5f);

               //Debug.Log("<color=red>当前训练章节名称=</color>" + UIdata.currentChapter);
     
          }
          protected void fnp_show()
          {
               SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0f), 0.24f);
               
               Debug.Log("<color=blue>blue:</color>");
     
          }
          //所有机器的缓存
          protected Dictionary<E_MachineName, AB_MachineMag> m_Machines =
               new Dictionary<E_MachineName, AB_MachineMag>();
          /// <summary>
          /// 把机器的引用传入到字典
          /// </summary>
          /// <param name="_mac"></param>
          public void fn_MachineLogin(AB_MachineMag _mac)
          {
               if (_mac == null)
               {
                    return;
               }
               if (_mac.m_MachineName == E_MachineName.e_null)
               {
                    return;
               }
               if (!m_Machines.ContainsKey(_mac.m_MachineName))
               {
                    m_Machines.Add(_mac.m_MachineName, _mac);
               }
          }
          /// <summary>
          /// 生成机器物体，注册机器和item
          /// </summary>
          /// <param name="_macName"></param>
          /// <param name="_HandleEvent"></param>
          public void fn_MachineLogin(E_MachineName _macName, AB_HandleEvent _HandleEvent)
          {
               if (m_machineParent == null)
               {
                    m_machineParent = new GameObject("machines");
               }
               if (_HandleEvent == null)
               {
                    return;
               }
               if (_macName == E_MachineName.e_null)
               {
                    return;
               }
               if (!m_Machines.ContainsKey(_macName))
               {
                    m_Machines.Add(_macName, null);
                    GameObject t_mac = new GameObject(_macName.ToString());
                    AB_MachineMag t_mag = t_mac.AddComponent<N_MachineMag>();
                    t_mag.fn_addControlItem(_HandleEvent);
                    t_mag.m_MachineName = _macName;
                    m_Machines[_macName] = t_mag;
                    t_mac.transform.parent = m_machineParent.transform;

               }
               else
               {
                    m_Machines[_macName].fn_addControlItem(_HandleEvent);
               }
          }
          /// <summary>
          /// 初始化工作
          /// </summary>
          protected void fnp_init1()
          {

               foreach (var mac in m_Machines.Values)
               {
                    mac.fn_init();
               }
               //玩家出生点位置
               if (M_getPos != null && M_PlayerMove != null)
               {
                    AB_Message t_sceneMsg = S_SceneMessage.Instance.fn_getMsg("sceneMsg");
                    if (t_sceneMsg != null)
                    {
                         string t_initTableName =
                              ((StateValueString)t_sceneMsg.fn_getContent("subject_init")).m_date;
                         fn_PlayerMoveTo(t_initTableName);
                    }
               }
               //冒泡注册到机器
               fnp_bubbleToMachine();
               //冒泡面板隐藏
               S_SceneMagT1.Instance.fn_BubblesShow(false);
               //整体介绍面板隐藏
               S_SceneMagT1.Instance.fn_IntroduceShow(false);
               Invoke("fnp_init2", 0.5f);
          }
          /// <summary>
          /// 玩家跳转到指定位置
          /// </summary>
          /// <param name="_posName"></param>
          public void fn_PlayerMoveTo(string _posName)
          {
               if (M_PlayerMove != null && M_getPos!=null)
               {
                    M_PlayerMove.fn_MoveTo(M_getPos.fn_getPos(_posName)); 
               }
          }
          protected string m_initTablename = "";
          /// <summary>
          /// 设置状态到指定状态
          /// </summary>
          protected void fnp_init2()
          {
               AB_Message t_sceneMsg = S_SceneMessage.Instance.fn_getMsg("sceneMsg");
               if (t_sceneMsg != null)
               {
                    string t_initTableName =
                         ((StateValueString)t_sceneMsg.fn_getContent("subject_init")).m_date;
                    m_initTablename = t_initTableName;
                    Dictionary<string, subject_init> t_init =
                         S_LoadTable.Instance.fn_getSubInit(t_initTableName);
                    if (t_init != null)
                    {
                         if (t_init.Count > 0)
                         {
                              fnp_doInit2(t_init);
                         }
                    }
                    else
                    {
                         Debug.Log("<color=red>not find subject_init!</color>");
                    }
               }


          }

          protected void fnp_doInit2(Dictionary<string, subject_init> _init)
          {
               //选择步骤的初始化表格
               fnp_initItems(_init);
               //在页岩气场景，加载设置泵的操作界面初始化
               fnp_initBengUI();
               //模式选择：自由，训练，考试
               string t_mode = S_SceneMessage.Instance.fn_getMode();
               if (t_mode != "")
               {
                    E_mode t_modeType = S_initDate.fns_getMode(t_mode);
                    if (t_modeType == E_mode.e_null)
                    {
                         return;
                    }
                    GameObject t_subCheck = new GameObject("Check_obj");
                    m_check = t_subCheck.gameObject.AddComponent<N_SubjectCheck>();
                    m_check.fn_init(fnp_checkOver, t_modeType);

               }
              
               //泵场景的虚拟按钮的初始化
               S_VirtualAttach.Instance.fn_InitAllVirtual();
               m_finishInit = true;
               //通知现在已经初始化完成
               GlobalEventSystem<InitFinished>.Raise(new InitFinished());
          }


          #region item的初始化
          private void fnp_initBengUI()
          {
               if (m_initTablename == "debug_s50_train" || m_initTablename == "debug_s51_train")
               {//如果是泵的界面操作步骤，那么就不用再初始化了,这里主要处理快速开始的情况
                    return;
               }
               if (UIdata.currentChapter!="")
               {
                    if (UIdata.currentChapter == "bumpUI_debug")
                    {
                         return;
                    }
               }
               if (SceneManager.GetActiveScene().name == "test_step1")
               {//在页岩气场景，加载设置泵的操作界面初始化，debug_s50_train
                    Dictionary<string, subject_init> t_initbengUI =
                        S_LoadTable.Instance.fn_getSubInit("debug_s50_train");
                    if (t_initbengUI != null)
                    {
                         if (t_initbengUI.Count > 0)
                         {
                              fnp_initItems(t_initbengUI);
                         }
                    }
                    else
                    {
                         Debug.Log("<color=red>not find debug_s50_train!</color>");
                    }
               }
          }

          private void fnp_initItems(Dictionary<string, subject_init> _init)
          {
               foreach (var item in _init.Values)
               {
                    AB_Message t_msg = new N_Message();
                    t_msg.fn_init(E_MessageType.e_outside,
                         new StateValue[2]{
                          new StateValueInt("m_id",item.m_id),
               new StateValueString("m_state",item.m_state) },
                         "init", 0, 0);

                    fn_ReceiveEvent(t_msg);

               }
          }  
          #endregion

        
          public bool m_finishInit = false;
          AB_SubjectCheck m_check;
          /// <summary>
          /// 步骤检查结束
          /// </summary>
          protected void fnp_checkOver()
          {
               Invoke("fnp_callOver2s", 2f);
          }
          //在2s后调用场景结束事件
          private void fnp_callOver2s()
          {
               if (S_sceneOver.Instance.Over != null)
               {
                    S_sceneOver.Instance.Over();
               }
          }
          bool m_isEnd = false;
          /// <summary>
          /// 场景结束调用
          /// </summary>
          public void fn_end()
          {
               if (m_isEnd)
               {
                    return;
               }
               m_isEnd = true;
               if (m_check != null)
               {

                    m_check.fn_kill();
               }
               S_update.Instance.fn_kill();
               S_SoundComSingle.Instance.fn_killSoundChain();
               S_OpMesh.Instance.fn_end();
               GlobalEventSystemMaitenance.CleanUpEventSystem();
          }
          public void fn_ReceiveEvent(AB_Message _msg)
          {
               if (_msg != null)
               {
                    if (_msg.Type == E_MessageType.e_outside)
                    {//向所有的机器转发消息,处理发送消息的机器
                         _msg.Type = E_MessageType.e_inside;
                         fn_SendEvent(_msg);
                    }
               }
          }
          protected void fn_SendEvent(AB_Message _msg)
          {
               foreach (var item in m_Machines.Values)
               {
                    if (item.m_MachineName != _msg.m_MachineName)
                    {
                         item.fn_ReceiveEvent(_msg);
                    }
               }
          }

          #region I_CheckValue
          public string fni_checkDate(int _id)
          {
               if (m_Items.ContainsKey(_id))
               {
                    return m_Items[_id].fn_getMainValue();
               }
               return "";
          }



          public string fni_checkDate(int _id, E_StateValueType _StateValueType)
          {
               if (m_Items.ContainsKey(_id))
               {
                    return m_Items[_id].fn_getMainValue(_StateValueType);
               }
               return "";
          }
          #endregion

          #region I_CheckStateValue
          public E_ItemType fni_checkItemType(int _id)
          {
               if (m_Items.ContainsKey(_id))
               {
                    return m_Items[_id].m_ItemType;
               }
               return E_ItemType.e_interactive;
          }
          public E_valueType fni_checkItemValueType(int _id)
          {
               if (m_Items.ContainsKey(_id))
               {
                    return m_Items[_id].m_ItemValueType;
               }
               return E_valueType.e_inter_floatvalue;
          }
          #endregion


          #region I_LightItemID
          public void fni_lightOn(int _id)
          {

               fnp_trainLight(_id, true);
          }

          private void fnp_trainLight(int _id, bool t_light)
          {
               if (m_Items.ContainsKey(_id))
               {
                    I_LightItem t_lightItem = m_Items[_id] as I_LightItem;
                    if (t_lightItem != null)
                    {
                         if (t_light)
                         {
                              t_lightItem.fni_lightOn();
                         }
                         else
                         {
                              t_lightItem.fni_endLight();
                         }
                    }
               }
          }

          public void fni_endLight(int _id)
          {
               fnp_trainLight(_id, false);
          }
          #endregion
          #region gotopos
          /// <summary>
          /// 跳转到指定位置
          /// </summary>
          /// <param name="_worldpos"></param>
          public void fn_GoTo(Vector3 _worldpos)
          {
               //跳转位置前，显示位置附近的细节模型
               S_OpMesh.Instance.fn_SetImmediately(_worldpos);

               if (M_PlayerMove != null)
               {
                    M_PlayerMove.fn_MoveTo(_worldpos);
               }
          }
          #endregion
          #region bubbles
          //每个机器的冒泡管理集合
          Dictionary<E_MachineName, AB_HideShow> m_bubbleMags = new Dictionary<E_MachineName, AB_HideShow>();
          public void fn_putInBubblesMag(E_MachineName _macname, AB_HideShow _bubble)
          {
               if (!m_bubbleMags.ContainsKey(_macname))
               {
                    m_bubbleMags.Add(_macname, _bubble);
               }
          }
          /// <summary>
          /// 开打关闭每个机器的详细文字泡
          /// </summary>
          /// <param name="_show">true 为显示</param>
          public void fn_BubblesShow(bool _show)
          {
               foreach (var bubble in m_bubbleMags.Values)
               {
                    if (_show)
                         bubble.fn_show();
                    else
                         bubble.fn_hide();
               }
          }
          //所有的冒泡集合
          List<N_HideShowOne> m_bubbles = new List<N_HideShowOne>();
          public void fn_putInBubble(N_HideShowOne _bubble)
          {
               if (_bubble != null)
               {
                    m_bubbles.Add(_bubble);
               }
          }
          bool m_btm = false;
          //把冒泡类型注册到相应的机器管理类中
          protected void fnp_bubbleToMachine()
          {
               if (m_btm)
               {
                    return;
               }
               m_btm = true;
               for (int i = 0; i < m_bubbles.Count; i++)
               {
                    E_MachineName t_mn = m_bubbles[i].m_machineName;
                    if (m_bubbleMags.ContainsKey(t_mn))
                    {//有机器注册
                         I_bubleMagFind t_bubbleLogo = m_bubbleMags[t_mn] as I_bubleMagFind;
                         if (t_bubbleLogo != null)
                         {
                              t_bubbleLogo.fni_login(m_bubbles[i]);
                         }
                    }
               }
          }
          /// <summary>
          /// 刷新冒泡显示的参数
          /// </summary>
          /// <param name="_macName"></param>
          public void fn_updateBubbleShow(E_MachineName _macName)
          {
               if (m_bubbleMags.ContainsKey(_macName))
               {//
                    I_updatePara t_bubbleupdate = m_bubbleMags[_macName] as I_updatePara;
                    if (t_bubbleupdate != null)
                    {
                         t_bubbleupdate.fni_updatePara();
                    }
               }
          }
          public AB_BubbleKeyValue fni_bubbleGetDetail(int _itemID)
          {
               if (m_Items.ContainsKey(_itemID))
               {
                    return m_Items[_itemID].gameObject.GetComponent<AB_BubbleKeyValue>();
               }
               return null;
          }
          #endregion
          #region 机器的整体介绍功能
          Dictionary<E_MachineName, AB_HideShow> m_introduceMachine = new Dictionary<E_MachineName, AB_HideShow>();
          public void fn_putIntroduceMac(E_MachineName _macName, AB_HideShow _ui)
          {
               if (!m_introduceMachine.ContainsKey(_macName))
               {
                    m_introduceMachine.Add(_macName, _ui);
               }
          }
          /// <summary>
          /// 整体介绍的UI显示
          /// </summary>
          /// <param name="_show"></param>
          public void fn_IntroduceShow(bool _show)
          {
               foreach (var macintro in m_introduceMachine.Values)
               {
                    if (_show)
                         macintro.fn_show();
                    else
                         macintro.fn_hide();
               }
          }
          #endregion




          #region I_backToSelect

          private bool m_isPause = false;
          /// <summary>
          /// 是否场景暂停
          /// </summary>
          public bool IsPause
          {
               get { return m_isPause; }
               //set { m_isPause = value; }
          }
          public void fni_TrainBackSelect()
          {
               fnp_doback();
          }

          private void fnp_doback()
          {
               m_isPause = true;
               fnp_readyback();
          }

          public void fni_TestBackSelect()
          {

               fnp_doback();
          }
          bool m_readyback = false;
          private void fnp_readyback()
          {
               if (m_readyback)
               {
                    return;
               }
               m_readyback = true;
               fn_end();
               Invoke("fnp_backSelect", 2f);
          }
          protected void fnp_backSelect()
          {
               S_SceneMessage.Instance.me_thisSceneName = E_sceneName.e_select;
               SceneManager.LoadScene("Main1");
          }


          public void fni_StopTest()
          {
               if (m_isPause)
               {
                    return;
               }
               m_isPause = true;
               if (m_check != null)
               {
                    m_check.fnp_endCheck();
               }
               //fn_end();
          }
          #endregion

          #region I_partPos
          public Transform fni_ItemPos(int _id)
          {
               if (m_Items.ContainsKey(_id))
               {
                    return m_Items[_id].gameObject.transform;
               }
               else
               {
                    return null;
               }
          } 
          #endregion
     }

}