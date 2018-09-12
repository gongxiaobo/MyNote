using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 35kv手车的控制
     /// </summary>
     public class N_HandCarControl : N_OnlyValueLogic
     {
          protected override void Start()
          {
               base.Start();
               fnp_findAnimator();
          }
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //base.fni_on(_controlType);
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //base.fni_off(_controlType);
          }
          float m_lastTime = -1f;
          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_findAnimator();
               float t_valueAni = _level;
               if (m_lastTime == t_valueAni)
               {
                    return;
               }
               m_lastTime = t_valueAni;

               N_SetState t_setstate = new N_SetState();
               t_setstate.fn_setState("floatvalue", t_valueAni.ToString(), m_handleEvent);
               //m_handleEvent.fn_debugState();
               //base.fni_level(_level, _controlType);
               if (_controlType == E_ControlType.e_init)
               {

               }
               if (_controlType == E_ControlType.e_normal)
               {
                    if (m_animatorClip != null)
                    {
                         m_animatorClip.SampleAnimation(this.gameObject, t_valueAni);
                    }
               }
          }
          Animator m_theCarAni = null;
          AnimationClip m_animatorClip = null;
          protected void fnp_findAnimator()
          {
               m_theCarAni = m_theCarAni ?? GetComponent<Animator>();
               if (m_theCarAni == null)
               {
                    m_theCarAni = GetComponentInChildren<Animator>();
               }
               if (m_theCarAni != null)
               {
                    m_animatorClip = m_theCarAni.GetCurrentAnimatorClipInfo(0)[0].clip;
                    m_theCarAni.enabled = false;
               }
          }

     }

}