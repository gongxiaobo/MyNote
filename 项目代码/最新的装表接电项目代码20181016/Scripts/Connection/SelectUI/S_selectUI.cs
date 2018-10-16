using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.SelectUI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Connection.TableMode;
using Assets.Scripts.Connection.LearnModeConnect;
using Assets.Scripts.Bezier.BirthMesh;
namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电的消息转发类
     /// 918:快速设置UI的选择属性，通过接口：I_SetWireSelect
     /// </summary>
     public class S_selectUI : GenericSingletonClass<S_selectUI>, I_handlemsg, I_SetWireSelect
     {
          /// <summary>
          /// 所有的UI组件集合
          /// </summary>
          protected List<AB_UILevel01> m_SelectUI = new List<AB_UILevel01>();
          protected Dictionary<int, AB_UILevel01> m_UIs = new Dictionary<int, AB_UILevel01>();
          /// <summary>
          /// 添加选择UI
          /// </summary>
          /// <param name="_uilevel"></param>
          public void fn_addSelectUI(AB_UILevel01 _uilevel)
          {
               m_SelectUI.Add(_uilevel);
               if (!m_UIs.ContainsKey(_uilevel.m_UIID))
               {
                    m_UIs.Add(_uilevel.m_UIID, _uilevel);
               }
               else
               {
                    Debug.Log("<color=red> same ui id!</color>" + _uilevel.m_UIID + _uilevel.gameObject.name);
                    Debug.Log("<color=red> in collections same ui id!</color>" + _uilevel.m_UIID + m_UIs[_uilevel.m_UIID].gameObject.name);
               }
          }
          public AB_UILevel01 fn_getSelectUI(int _uiID)
          {
               if (m_UIs.ContainsKey(_uiID))
               {
                    return m_UIs[_uiID];
               }
               else
               {
                    return null;
               }
          }


          public void fni_receive(SMsg _reveive)
          {
               //Debug.Log("<color=blue>_reveive:</color>" + _reveive.m_ID);
               if (_reveive.m_additional=="")
               {
                    for (int i = 0; i < m_SelectUI.Count; i++)
                    {
                         m_SelectUI[i].fni_receive(_reveive);
                    }
               }
               if (_reveive.m_additional=="system")
               {//模式面板的消息
                     fnp_modeMsg(_reveive);

               }
               
          }
          /// <summary>
          /// 错误步骤的配置表内容
          /// </summary>
          subject_step m_stepInfo;
          private void fnp_TestErrorTips()
          {
               if (m_stepInfo==null)
               {
                    return;
               }
               //文字显示
               fnp_setDetailEvent(m_stepInfo.m_ch_txt);
               //高亮显示
               //拆开表中配的状态值
               string[] t_states = S_ParseWirePara.fn_SplitToThree(m_stepInfo.m_state);
               //查看现在接口的状态值
               for (int i = 0; i < t_states.Length; i++)
               {
                    if (t_states[i] != "")
                    {
                         string[] t_para = S_ParseWirePara.fn_getPara(t_states[i]);
                         string t_name = S_static.fns_OrderUp(t_para[0], t_para[1]);
                         //判断电线已经存在
                         if (S_BirthPipeMesh.Instance.fn_checkPipeExit(t_name))
                         {
                              continue;
                         }
                         else
                         {//高亮这根线的接口,
                              GameObject t_port1 = S_Ports.Instance.fn_getPort(t_para[0]);
                              GameObject t_port2 = S_Ports.Instance.fn_getPort(t_para[1]);
                              AB_LightOneObj t_light1 = t_port1.GetComponent<AB_LightOneObj>();
                              t_light1.fn_light();
                              AB_LightOneObj t_light2 = t_port2.GetComponent<AB_LightOneObj>();
                              t_light2.fn_light();

                              break;
                         }
                    }
               }
               m_stepInfo = null;
          }
          /// <summary>
          /// 收到系统消息时
          /// </summary>
          /// <param name="_reveive"></param>
          private void fnp_modeMsg(SMsg _reveive)
          {
               if (_reveive.m_ID == 12)
               {
                    //学习模式下：暂停/继续
                    //训练模式下：完成
                    //新手模式下：不显示
                    if (S_SceneMessage.Instance.m_TableMode== E_TableMode.e_learn)
                    {
                         I_LearnModePause ti_mode = S_SceneMagT1.Instance.Check as I_LearnModePause;
                         if (ti_mode != null)
                         {//暂停，继续模式
                              ti_mode.fni_getLearnMode().M_isPause = !ti_mode.fni_getLearnMode().M_isPause;
                         }
                    }
                    I_TablePutTestResult ti_putResult = S_SceneMagT1.Instance.Check as I_TablePutTestResult;
                    if (S_SceneMessage.Instance.m_TableMode == E_TableMode.e_test)
                    {
                         if (ti_putResult.fni_TablePutTestResult())
                         {//全部正确通过
                              fnp_setDetailEvent("操作通过！完成所有链接操作");
                              S_SoundComSingle.Instance.fnp_sound("Table_system_info 2");
                         }
                         else
                         {//还有错误，不通过
                              m_stepInfo = ti_putResult.fni_GetErrorStep();
                              if (m_stepInfo != null)
                              {//这里就可以找到链接错误的接口和语音提示信息
                                   fnp_setDetailEvent("操作不通过！一些链接操作还没有完成");
                                   S_SoundComSingle.Instance.fnp_sound("Table_system_info 1");
                                   //提示链接
                                   CancelInvoke("fnp_TestErrorTips");
                                   Invoke("fnp_TestErrorTips", S_SoundComSingle.Instance.fn_soundLength("Table_system_info 1"));
                                   

                              }
                         }
                    }
                    if (S_SceneMessage.Instance.m_TableMode == E_TableMode.e_troubleshooting)
                    {
                         if (ti_putResult.fni_TablePutTestResult())
                         {//全部正确通过，找到链接错误的线路
                              fnp_setDetailEvent("操作通过！完成故障排除");
                              S_SoundComSingle.Instance.fnp_sound("Table_system_info 4");
                         }
                         else
                         {//没有找到错误连线，不通过
                              subject_step t_stepInfo = ti_putResult.fni_GetErrorStep();
                              if (t_stepInfo != null)
                              {//这里就可以找到链接错误的接口和语音提示信息
                                   fnp_setDetailEvent("操作不通过！有错误的链接还没有修复");
                                   S_SoundComSingle.Instance.fnp_sound("Table_system_info 3");

                              }
                         }
                    }

               }
               if (_reveive.m_ID == 13)
               {//重新开始
                    //SceneManager.sceneLoaded
                    S_SceneMagT1.Instance.fn_end();
                    Invoke("fn_reload_scene", 0.5f);
               }
               if (_reveive.m_ID == 14)
               {//退出到选择界面
                    UIdata.currentStep = "";
                    S_SceneMagT1.Instance.fni_TrainBackSelect();

               }
          }
          void fn_reload_scene()
          {
               SceneManager.LoadScene("Table1");
          }
          public void fni_send(SMsg _sendmsg)
          {
               //throw new System.NotImplementedException();
          }
          /// <summary>
          /// 绳子选择UI的位置
          /// </summary>
          public Transform m_RopeSelect = null;
          #region select rope para
          public string m_ropesize;
          public string m_ropemode;
          public string m_ropecolor;
          //断开电线
          public bool m_isDisLine; 
          #endregion
          /// <summary>
          /// 获取当前选择电线的参数
          /// </summary>
          /// <returns>&2&hard&red</returns>
          public string fn_getWirePara()
          {
               string t_para = "&" + m_ropesize + "&" + m_ropemode + "&" + m_ropecolor;
               return t_para;
          }

          public Transform m_StepDetail = null;

          #region I_SetWireSelect
          /// <summary>
          /// 链接线的属性,包括线的半径，颜色，软硬
          /// </summary>
          /// <param name="_twoPortInfo"></param>
          public void fni_setWireSelect(string _twoPortInfo)
          {
               if (_twoPortInfo=="")
               {
                    return;
               }
               //拆分成颜色，线径，软硬
               string[] t_set= S_ParseWirePara.fn_getPara(_twoPortInfo);
               if (t_set.Length!=5)
               {
                    return;
               }
               //10,20,2,hard,red
               //找到线径
               string t_wireR = t_set[2];
               //查看线径的合法
               AB_UILevel01 t_radiulength = fn_getSelectUI(2);
               if (t_radiulength==null)
               {
                    return;
               }
               N_UILevel01_02 t_getRadiu = t_radiulength as N_UILevel01_02;
               bool t_wireReady = true;
               for (int i = 0; i < t_getRadiu.m_name.m_datas.Count; i++)
               {
                    if (t_getRadiu.m_name.m_datas[i].m_codeName==t_wireR)
                    {
                         break;
                    }
                    if (i==(t_getRadiu.m_name.m_datas.Count-1))
                    {
                         t_wireReady = false;
                         Debug.Log("<color=red>线径不合法！ </color>" + t_wireR);
                    }
               }
               if (t_wireReady==false)
               {
                    return;
               }
               //设置线径
               if (m_ropesize!=t_wireR)
               {
                    AB_UILevel01 t_radiu = fn_getSelectUI(6);
                    while (m_ropesize != t_wireR)
                    {
                         if (t_radiu == null)
                         {
                              break;
                         }
                         t_radiu.fn_buttonHit();
                    } 
               }

               //线的模式
               string t_wireMode = t_set[3];
               //查看线的模式是否合法
               N_UILevel01_01 t_mode1 = fn_getSelectUI(1) as N_UILevel01_01;
               for (int i = 0; i < t_mode1.m_name.m_datas.Count; i++)
               {
                    if (t_mode1.m_name.m_datas[i].m_codeName == t_wireMode)
                    {
                         break;
                    }
                    if (i==t_mode1.m_name.m_datas.Count-1)
                    {
                         t_wireReady = false;
                         Debug.Log("<color=red>线的模式不合法！ </color>" + t_wireMode);
                    }
               }
               if (t_wireReady == false)
               {
                    return;
               }

               AB_UILevel01 t_Mode = fn_getSelectUI(8);
               while (m_ropemode!=t_wireMode)
               {
                    if (t_Mode==null)
                    {
                         break;
                    }
                    t_Mode.fn_buttonHit();
               }

               //线的颜色
               string t_wirecolor = t_set[4];
               N_UILevel01_03 t_colorvalue = fn_getSelectUI(3) as N_UILevel01_03;
               for (int i = 0; i < t_colorvalue.m_name.m_datas.Count; i++)
               {
                    if (t_colorvalue.m_name.m_datas[i].m_codeName==t_wirecolor)
                    {
                         break;
                    }
                    if (i==(t_colorvalue.m_name.m_datas.Count-1))
                    {
                         t_wireReady = false;
                         Debug.Log("<color=red>线的颜色不合法！ </color>" + t_wirecolor);
                    }
               }
               if (t_wireReady == false)
               {
                    return;
               }
               AB_UILevel01 t_color = fn_getSelectUI(4);
               while (m_ropecolor != t_wirecolor)
               {
                    if (t_color == null)
                    {
                         break;
                    }
                    t_color.fn_buttonHit();
               }


          } 
          #endregion
          /// <summary>
          /// 设置详情文字显示
          /// </summary>
          /// <param name="_txt"></param>
          protected void fnp_setDetailEvent(string _txt)
          {
               GlobalEventSystem<Event_StepDetail>.Raise(new Event_StepDetail(_txt));
          }
     } 
}
