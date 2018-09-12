using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_PickUp : N_lightTarget, I_pickUp
     {

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (mi_hand == null)
               {
                    mi_hand = _hand;
               }
               fnp_PickCheck(_button, _hand);
          }

          protected virtual void fnp_PickCheck(E_buttonIndex _button, I_HandButton _hand)
          {

               //Debug.Log("<color=red>_button:</color>" + _button);

               if (m_rotateControl)
               {
                    return;
               }
               if (_button == E_buttonIndex.e_triggerDown)
               {
                    if (m_isPick == false)
                    {
                         m_isPick = true;
                         fnp_pickUp(_hand);
                    }
                    else
                    {
                         m_isPick = false;
                         fnp_putDown();
                    }
               }
          }
          /// <summary>
          /// true 为拿在手里
          /// </summary>
          protected bool m_isPick = false;
          protected I_HandButton mi_hand = null;
          protected virtual void fnp_pickUp(I_HandButton _hand)
          {

               //Debug.Log("<color=blue>抓取物体</color>");

               FixedJoint t_fj = gameObject.transform.GetComponent<FixedJoint>();
               if (t_fj == null)
               {
                    t_fj = gameObject.AddComponent<FixedJoint>();
               }
               t_fj.connectedBody = _hand.fni_getHandRigid();
               //t_lights = GetComponentsInChildren<AB_LightOneObj>();
               for (int i = 0; i < t_lights.Length; i++)
               {
                    if (t_lights[i].m_lightObjType == E_LightObjType.e_pickUp)
                    {
                         t_lights[i].fn_endLigth();
                    }
               }
          }
          protected virtual void fnp_putDown()
          {
               //Debug.Log("<color=blue>放下物体</color>");
               //m_isPick = false;


               FixedJoint t_fj = gameObject.GetComponent<FixedJoint>();
               if (t_fj != null)
               {
                    t_fj.connectedBody = null;
                    Destroy(t_fj);
               }
               if (m_RemoveRigibody)
               {
                    Rigidbody t_rg = GetComponent<Rigidbody>();
                    if (t_rg != null)
                    {
                         Destroy(t_rg);
                    }
               }

          }
          /// <summary>
          /// 是否在结束时移除rigibody
          /// </summary>
          public bool m_RemoveRigibody = false;
          /// <summary>
          /// 在操作这个工具时，不使用拾取功能
          /// </summary>
          protected bool m_rotateControl = false;
          /// <summary>
          /// 工具碰触到触发器后被调用，工具到指定位置，等待操作。
          /// </summary>
          public virtual void fni_putDown()
          {
               fnp_putDown();
               m_rotateControl = true;
          }
          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               if (m_isPick == false && m_rotateControl == false)
               {
                    for (int i = 0; i < t_lights.Length; i++)
                    {
                         if (t_lights[i].m_lightObjType == E_LightObjType.e_pickUp)
                         {
                              if (_inOut)
                              {
                                   t_lights[i].fn_light();
                              }
                              else
                              {
                                   t_lights[i].fn_endLigth();
                              }
                         }
                    }
               }
          }

     }
     public interface I_pickUp
     {
          void fni_putDown();
     } 
}