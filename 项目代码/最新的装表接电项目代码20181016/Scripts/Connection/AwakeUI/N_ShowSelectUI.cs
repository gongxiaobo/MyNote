using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 选择电线UI的UI位置显示
     /// </summary>
     public class N_ShowSelectUI : AB_ShowSelectUI
     {
          protected Transform m_UI = null;
          protected Transform m_UIPoint = null;

          protected Transform m_StepDetail = null;
          /// <summary>
          /// 是否改变弹出UI组件的状态值
          /// </summary>
          public bool m_ChangeStateValue = false;
          /// <summary>
          /// 设置item 5505的状态值
          /// 主要是新手引导模式使用
          /// </summary>
          protected void fnp_setStateValue()
          {
               int t_id;
               if (int.TryParse("5505", out t_id))
               {
                    GameObject t_item = S_SceneMagT1.Instance.fn_getItemObj(t_id);
                    if (t_item != null)
                    {
                         AB_SetState t_set = new N_SetState();
                         t_set.fn_setState("onoff", "on", t_item.GetComponent<AB_HandleEvent>());
                    }
               }
          }
          public override void fn_showUI()
          {
               if (m_ChangeStateValue)
               {
                    fnp_setStateValue();
               }
               fnp_findUIPos();
               if (m_UI != null && m_UIPoint!=null)
               {
                    //处理多个地方要显示线选择面板
                    AB_CloseLastUI t_lastUI = m_UI.gameObject.GetComponent<AB_CloseLastUI>();
                    if (t_lastUI!=null)
                    {
                         A_TriggerObj t_now=this.gameObject.GetComponent<A_TriggerObj>();
                         //if (t_now != t_lastUI.M_LastUI)
                         {//如果在其他地方要显示UI,关闭以前的UI
                              if (t_lastUI.M_LastUI != null && m_UI.position != new Vector3(0f, -1000f, 0f))
                              {
                                   t_lastUI.M_LastUI.fn_trigger(E_buttonIndex.e_padTouched, null);
                                   t_lastUI.M_LastUI.fn_trigger(E_buttonIndex.e_padTouchOver, null);
                                   t_lastUI.M_LastUI.fn_trigger(E_buttonIndex.e_padPressDown, null);

                                   //t_lastUI.M_LastUI = null; 
                              }
                              t_lastUI.M_LastUI = t_now;
                         }
                    }
                    m_UI.position = m_UIPoint.position;
                    m_UI.rotation = m_UIPoint.rotation;
                    
               }
               if (m_StepDetail!=null)
               {
                    //if (S_SceneMessage.Instance.fn_getMode()=="test")
                    //{//在考试模式下，不显示步骤详情
                    //     return;
                    //}
                    if (S_selectUI.Instance.m_StepDetail!=null)
                    {
                         S_selectUI.Instance.m_StepDetail.position = m_StepDetail.position;
                         S_selectUI.Instance.m_StepDetail.rotation = m_StepDetail.rotation;
                    }
               }
          }

          private void fnp_findUIPos()
          {
               if (m_UI == null)
               {
                    m_UI = S_selectUI.Instance.m_RopeSelect;
               }
               if (m_UIPoint == null)
               {
                    m_UIPoint = transform.FindInChild("UIPoint");
               }
               if (m_StepDetail == null)
               {
                    m_StepDetail = transform.FindInChild("StepDetail");
               }
          }

          public override void fn_hideUI()
          {
               fnp_findUIPos();
               if (m_UI != null && m_UIPoint != null)
               {
                    //AB_CloseLastUI t_lastUI = m_UI.gameObject.GetComponent<AB_CloseLastUI>();
                    //if (t_lastUI.M_LastUI != null)
                    //{//隐藏时取消对选择线UI的持有
                    //     t_lastUI.M_LastUI = null;
                    //}
                    m_UI.position = new Vector3(0f,-1000f,0f);
               }
               if (S_selectUI.Instance.m_StepDetail != null)
               {
                    S_selectUI.Instance.m_StepDetail.position = new Vector3(0f, -1000f, 0f);
               }
          }
          bool m_show = false;
          public override void fn_trigger()
          {
               if (m_show==false)
               {
                    fn_showUI();
               }
               else
               {
                    fn_hideUI();
               }
               m_show = !m_show;
          }
     } 
}
