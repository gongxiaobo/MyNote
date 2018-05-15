using UnityEngine;
using System.Collections;
using System;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0206/ :手柄的输入获取,包括：触摸板的上下左右，扳机键按下松开，握持键的触发
     ///@ author gong
     ///@ version 1.1 /2017.0207/ :加入了射线的接口和获取触发物体的接口
     ///@ author gong
     ///@ version 1.2 /2017.0207/ :实现自动握持键接口
     ///@ author gong
     ///@ version 1.3 /2017.0210/ :修改了按下触摸板后选中物体后还有射线发出的问题line:99
     ///@ author gong
     ///@ version 1.4 /2017.0307/ :
     ///@ author gong
     ///</summary>
     public class HandButton : A_HandButton
     {

          protected SteamVR_TrackedObject m_trackedObj;

          protected TimeCount1 m_timecount;
          //为了防按下按键时多次被调用
          protected bool canPress = true;
          //发出射线的接口
          protected I_ShowOrHideRay mi_ray;
          //获取当前射线选中的物体
          protected I_GetTriggerObj mi_getObj;
          //选中的控制物体
          protected A_TriggerObj m_triggerObj;

          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               S_HandButton.Instance.m_handeButton = this;
               S_HandButton.Instance.GetRigid = this;
               m_trackedObj = GetComponent<SteamVR_TrackedObject>();
               if (m_trackedObj == null)
                    Destroy(this);

               m_timecount = new TimeCount1();
               m_timecount.SetCallSpace(0.05f, fnp_checkInput);

               mi_ray = GetComponent<NewLine>();
               mi_getObj = GetComponent<NewLine>();
               S_handShake.Instance.HandShake = fn_shake;
               m_thisHand.gameObject.SetActive(true);
          }

          // Update is called once per frame
          //	void Update () {
          //	
          //	}
          protected override void Update()
          {
               base.Update();

               if (!canPress)
               {
                    m_timecount.CallTime(Time.deltaTime);
               }
               fnp_checkDevice();

          }

          private void fnp_checkInput()
          {
               canPress = true;
          }

          protected Vector2 m_startLeft = new Vector2(1, 0);
          protected float t_angel = 0f;
          /// <summary>
          /// 输入的按键事件检测
          /// </summary>
          protected override void fnp_checkDevice()
          {
               if (!canPress)
                    return;

               var device = SteamVR_Controller.Input((int)m_trackedObj.index);

               if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
               {

                    if (m_triggerObj == null)
                    {
                         //				Debug.Log ("触到触摸板");
                         fnp_showRay();
                         //				canPress = false;
                    }

               }
               if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
               {

                    //				Debug.Log ("离开触摸板");
                    fnp_hideRay();
                    //				canPress = false;

               }

               //触摸板
               if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
               {

                    if (m_triggerObj == null)
                    {
                         m_triggerObj = mi_getObj.fni_getControl();
                         if (m_triggerObj != null)
                         {
                              m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDown, this);
                              fnp_hideRay();//隐藏射线
                         }
                         canPress = false;
                         return;
                    }

                    t_angel = fnp_vectorAngel(m_startLeft, device.GetAxis());
                    //			Debug.Log ("触摸板按下");
                    canPress = false;
                    //触摸板的上下左右按键检查
                    if (m_triggerObj != null)
                    {
                         if ((t_angel > -45f && t_angel <= 0f) || (t_angel >= 0f && t_angel < 45f))
                         {
                              //					Debug.Log ("右");
                              m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDownRight, this);

                         }
                         else if (t_angel < -45f && t_angel > -135f)
                         {
                              //					Debug.Log ("上");
                              m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDownUp, this);
                         }
                         else if (t_angel < -135f || t_angel > 135f)
                         {
                              //					Debug.Log ("左");
                              m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDownLeft, this);
                         }
                         else if (t_angel > 45f && t_angel < 135f)
                         {
                              //					Debug.Log ("下");
                              m_triggerObj.fn_trigger(E_buttonIndex.e_padPressDownDown, this);
                         }
                    }
                    return;
               }
               //添加触摸盘弹起的事件
               if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
               {

                    canPress = false;

                    if (m_triggerObj != null)
                    {
                         m_triggerObj.fn_trigger(E_buttonIndex.e_padPressUp, this);

                    }
                    return;
               }

               if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
               {
                    //			Debug.Log ("抓取键按下");
                    if (m_triggerObj != null)
                    {
                         m_triggerObj.fn_trigger(E_buttonIndex.e_gripDown, this);
                         m_triggerObj = null;

                    }
                    canPress = false;
                    return;
               }
               if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
               {
                    Debug.Log("触发键按下");
                    if (me_action != null)
                    {
                         me_action(E_buttonIndex.e_triggerDown);
                    }
                    canPress = false;
                    return;
               }
               if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
               {
                    Debug.Log("触发键松开");
                    canPress = false;
                    return;
               }
          }

          protected float m_angels;
          protected Vector3 m_cross;
          protected float fnp_vectorAngel(Vector2 _from, Vector2 _to)
          {

               m_cross = Vector3.Cross(_from, _to);

               m_angels = Vector2.Angle(_from, _to);

               return m_cross.z > 0 ? -m_angels : m_angels;
          }

          /// <summary>
          /// 射线消失
          /// </summary>
          protected override void fnp_hideRay()
          {

               if (mi_ray == null)
               {
                    mi_ray = GetComponent<NewLine>();
                    if (mi_ray != null)
                    {
                         mi_ray.fni_hidRay();
                    }
               }
               else
               {
                    mi_ray.fni_hidRay();
               }
          }
          /// <summary>
          /// 显示射线
          /// </summary>
          protected override void fnp_showRay()
          {

               if (mi_ray == null)
               {
                    mi_ray = GetComponent<NewLine>();
                    if (mi_ray != null)
                    {
                         mi_ray.fni_showRay();
                    }
               }
               else
               {
                    mi_ray.fni_showRay();
               }
          }
          public override void fni_autoRealse()
          {
               //		Debug.Log ("自动抓取键按下");
               if (m_triggerObj != null)
               {
                    m_triggerObj.fn_trigger(E_buttonIndex.e_gripDown, this);
                    m_triggerObj = null;

               }
          }
          /// <summary>
          /// 手柄上的链接点
          /// </summary>
          public Rigidbody m_thisHand;
          public override Rigidbody fni_getHandRigid()
          {
               m_thisHand.gameObject.SetActive(true);
               return m_thisHand;
          }
          public override Transform fni_getHand()
          {
               return this.gameObject.transform;
          }
          /// <summary>
          /// 手柄抖动
          /// </summary>
          public override void fn_shake()
          {
               //base.fn_shake();
               SteamVR_Controller.Input((int)m_trackedObj.index).TriggerHapticPulse();
          }

          //	//主要是用于关联检测扳机键和侧握键的事件
          //	protected Action<string> me_triggerAndGrip;
          //	public event Action<string> Me_triggerAndGrip{
          //		add{
          //			if (value!=null) {
          //				me_triggerAndGrip+=value;
          //			}
          //		}
          //		remove{
          //			me_triggerAndGrip -= value;
          //		}
          //	}

     }

}