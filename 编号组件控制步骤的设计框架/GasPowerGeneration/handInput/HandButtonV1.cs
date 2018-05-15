using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace GasPowerGeneration
{
     //using GCode;
     ///<summary>
     ///@ version 1.0 /2017.0215/ :根据客户需求，更改手柄新的操作方式,主要是用扳机键来出发事件
     /// 重写了HandButton.cs中的fnp_checkDevice，fni_autoRealse
     ///@ author gong
     ///@ version 1.1 /2017.0305/ :加入了锁定旋钮的操作逻辑m_isHoldKnob
     ///@ author gong
     ///@ version 1.2 /2017.0318/ :加入了原盘建按下的支持
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class HandButtonV1 : HandButton
     {
          //握持键按下
          private bool m_backToSelect = false;

          //获取当前手柄前端正方体中的最近的物体
          protected I_GetTriggerObj mi_getcanHoldObj;
          //选中的可以拿起的物体
          protected A_TriggerObj m_canHoldObj;
          //圆盘按下后触发的物体
          protected A_TriggerObj m_PadPressDownObj = null;
          protected override void Start()
          {
               base.Start();
               mi_getcanHoldObj = mi_getcanHoldObj ?? GetComponent<HandFindNearObj>();
          }

          protected override void Update()
          {
               base.Update();
          }
          protected override void fnp_checkDevice()
          {

               if (!canPress)
                    return;

               var device = SteamVR_Controller.Input((int)m_trackedObj.index);

               if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
               {
                    //			if (mi_getObj!=null) {
                    //				if (m_triggerObj==null) {//这里主要是用于播放模型的动画，为了不打断以前的逻辑，在使用完后要把m_triggerObj=null,
                    //					//主要是处理选中旋钮的情况，按下圆盘键就没有用了
                    //					m_triggerObj = mi_getObj.fni_getControl ();
                    //					if (m_triggerObj != null) {
                    //						m_triggerObj.fn_trigger (E_buttonIndex.e_padTouched, this);
                    ////						m_triggerObj = null;
                    //					}
                    //				}
                    //			}
                    //点击触摸板
                    if (m_isHoldKnob)
                    {//如果已经锁定旋钮，就不再发出射线了
                         return;
                    }

                    if (m_isTriggerDown)
                    {
                         fnp_hideRay();
                         return;

                    }
                    else
                    {
                         fnp_showRay();
                    }

               }
               if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
               {
                    if (m_isHoldKnob)
                    {//如果已经锁定旋钮，就不再发出射线了
                         return;
                    }
                    //			Debug.Log ("离开触摸板");
                    fnp_hideRay();
                    //				canPress = false;

               }

               //触摸板
               if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
               {


                    if (mi_getObj != null)
                    {
                         if (m_triggerObj == null)
                         {//这里主要是用于播放模型的动画，为了不打断以前的逻辑，在使用完后要把m_triggerObj=null,
                              //主要是处理选中旋钮的情况，按下圆盘键就没有用了
                              m_triggerObj = mi_getObj.fni_getControl();
                              if (m_triggerObj != null)
                              {
                                   m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDown, this);
                                   m_PadPressDownObj = m_triggerObj;
                                   m_triggerObj = null;
                              }
                         }
                    }


                    //device.GetPressDown(SteamVR_Controller.ButtonMask.Axis3)

                    t_angel = fnp_vectorAngel(m_startLeft, device.GetAxis());
                    //			Debug.Log ("触摸板按下");
                    canPress = false;
                    //触摸板的上下左右按键检查
                    if (m_triggerObj != null)
                    {
                         if ((t_angel > -45f && t_angel <= 0f) || (t_angel >= 0f && t_angel < 45f))
                         {
                              Debug.Log("右");
                              m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDownRight, this);

                         }
                         else if (t_angel < -45f && t_angel > -135f)
                         {
                              Debug.Log("上");
                              m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDownUp, this);
                         }
                         else if (t_angel < -135f || t_angel > 135f)
                         {
                              Debug.Log("左");
                              if (m_isHoldKnob)
                              {
                                   m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDownLeft, this);
                              }
                         }
                         else if (t_angel > 45f && t_angel < 135f)
                         {
                              Debug.Log("下");
                              if (m_isHoldKnob)
                              {
                                   m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDownDown, this);
                              }
                         }
                    }
                    else
                    {

                         Debug.Log("<color=yellow>触发的物体没有找到 触发器</color>" + "-->");
                    }

                    return;
               }
               //添加触摸盘弹起的事件
               if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
               {

                    //Debug.Log("<color=red>添加触摸盘弹起的事件</color>");

                    canPress = false;

                    if (m_PadPressDownObj != null)
                    {
                         m_PadPressDownObj.fn_trigger(E_buttonIndex.e_padPressUp, this);
                         m_PadPressDownObj = null;
                    }
                    return;
               }

               if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
               {
                    //			m_backToSelect = !m_backToSelect;
                    if (me_triggerAndGrip != null)
                    {
                         me_triggerAndGrip("grip");
                    }
                    canPress = false;
                    return;
               }
               if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
               {
                    if (me_triggerAndGrip != null)
                    {
                         me_triggerAndGrip("trigger");
                    }

                    if (me_action != null)
                    {//扳机键按下事件,任务重动态链接像等待用户输入任务就是使用此事件
                         me_action(E_buttonIndex.e_triggerDown);
                    }

                    if (m_canHoldObj == null)
                    {
                         if (mi_getcanHoldObj != null)
                         {
                              m_canHoldObj = mi_getcanHoldObj.fni_getControl();

                              if (m_canHoldObj != null)
                              {
                                   m_canHoldObj.fn_trigger(E_buttonIndex.e_triggerDown, this);
                              }
                         }
                    }

                    if (mi_getObj != null)
                    {
                         if (m_triggerObj == null)
                         {//这里主要是用于播放模型的动画，为了不打断以前的逻辑，在使用完后要把m_triggerObj=null,
                              //主要是处理选中旋钮的情况，按下圆盘键就没有用了
                              m_triggerObj = mi_getObj.fni_getControl();
                              if (m_triggerObj != null)
                              {
                                   m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDown, this);
                                   m_triggerObj = null;
                              }
                         }
                    }
                    //			if (m_backToSelect) {
                    //				SceneManager.LoadSceneAsync ("Select_new");
                    //				return;
                    //			}
                    //			if (m_isTriggerDown == false) {
                    //				m_isTriggerDown = true;
                    //			} else {
                    //				return;
                    //			}

                    //			Debug.Log ("按下扳机键");
                    //获取现在射线击中的物体接口
                    //			if (m_triggerObj == null) {//在没有选择中旋钮的情况下
                    //				m_triggerObj = mi_getObj.fni_getControl ();
                    //
                    //				fnp_buttonType ();
                    //			} else {//选中旋钮的情况
                    //				fnp_hadTriggerObj();
                    //			}
                    fnp_controlHand("close");
                    canPress = false;
                    return;
               }
               if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
               {
                    if (m_isTriggerDown)
                    {
                         //				Debug.Log ("扳机键松开");
                         m_isTriggerDown = false;
                    }
                    if (m_canHoldObj != null)
                    {
                         m_canHoldObj.fn_trigger(E_buttonIndex.e_triggerUp, this);
                         m_canHoldObj = null;
                    }
                    fnp_controlHand("open");
                    canPress = false;
                    return;
               }
               if (device.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
               {
                    //			if (m_triggerObj!=null) {
                    //				m_triggerObj.fn_trigger (E_buttonIndex.e_menuDown, this);
                    //			}
                    //发出全局事件，右手的菜单键按下
                    GlobalEventSystem<N_event_menuBtnDow>.Raise(new N_event_menuBtnDow("right"));

                    canPress = false;
                    return;
               }
          }

          //是否选中旋钮
          private bool m_isHoldKnob = false;
          private bool m_isTriggerDown = false;
          /// <summary>
          /// 在没有选择物体按键的情况下，检查是那种类型的按键
          /// 手柄的按下事件发送到现在指向的可以触发的物体
          /// </summary>
          private void fnp_buttonType()
          {
               if (m_triggerObj == null)
               {
                    return;
               }
               switch (m_triggerObj.m_buttonType)
               {
                    case E_buttonType.e_ui_button:
                         Debug.Log("<color=blue>按下UI界面按钮</color>" + "-->");
                         m_triggerObj.fn_trigger(E_buttonIndex.e_triggerDown, this);
                         fnp_hideRay();
                         m_triggerObj = null;
                         break;
                    case E_buttonType.e_onoff_switch:
                         Debug.Log("<color=blue>按下普通开关按钮</color>" + "-->");
                         m_triggerObj.fn_trigger(E_buttonIndex.e_triggerDown, this);
                         fnp_hideRay();
                         m_triggerObj = null;
                         //			m_triggerObj.fn_trigger (E_buttonIndex.e_triggerDown, this);
                         break;
                    case E_buttonType.e_knob_button:
                         Debug.Log("<color=blue>按下旋钮钮</color>" + "-->");
                         m_isHoldKnob = true;
                         fnp_hideRay();
                         m_triggerObj.fn_trigger(E_buttonIndex.e_triggerDown, this);
                         break;
                    case E_buttonType.e_grip_obj:
                         m_triggerObj.fn_trigger(E_buttonIndex.e_triggerDown, this);
                         fnp_hideRay();
                         break;

                    default:
                         break;
               }
          }
          /// <summary>
          /// 已经锁定物体，像旋钮，抓取物体,解除锁定
          /// </summary>
          private void fnp_hadTriggerObj()
          {
               if (m_triggerObj != null)
               {

                    switch (m_triggerObj.m_buttonType)
                    {
                         case E_buttonType.e_ui_button:

                              break;
                         case E_buttonType.e_onoff_switch:

                              break;
                         case E_buttonType.e_knob_button:
                              Debug.Log("<color=blue>取消锁定，旋钮钮</color>" + "-->");
                              m_isHoldKnob = false;
                              m_triggerObj.fn_trigger(E_buttonIndex.e_triggerDown, this);
                              fnp_hideRay();
                              m_triggerObj = null;
                              //			m_triggerObj.fn_trigger (E_buttonIndex.e_triggerDown, this);
                              break;
                         case E_buttonType.e_grip_obj:
                              m_triggerObj.fn_trigger(E_buttonIndex.e_triggerDown, this);
                              fnp_hideRay();
                              m_triggerObj = null;
                              //				m_triggerObj.fn_trigger (E_buttonIndex.e_triggerDown, this);
                              break;

                         default:
                              break;
                    }

               }
          }

          public override void fni_autoRealse()
          {
               //		base.fni_autoRealse ();
               if (m_triggerObj != null)
               {
                    Debug.Log("<color=yellow>手柄射线释放</color>");
                    //			m_triggerObj.fn_trigger (E_buttonIndex.e_triggerDown,this);
                    fnp_hideRay();
                    m_triggerObj = null;

               }

          }
          protected void fnp_controlHand(string _mg)
          {
               //if (gameObject.name == "Controller (right)")
               //{
               //     GlobalEventSystem<Event_handL>.Raise(new Event_handL(E_hand.e_right, _mg));
               //}

          }
          //用于隐藏手柄模型
          AB_HideModel m_hideModel = null;
          public override void fni_callBack(bool _bl)
          {
               base.fni_callBack(_bl);
               if (m_hideModel == null)
               {
                    m_hideModel = GetComponent<AB_HideModel>();
               }
               if (m_hideModel == null)
               {
                    return;
               }
               m_hideModel.fn_hide(_bl);
          }

     }

}