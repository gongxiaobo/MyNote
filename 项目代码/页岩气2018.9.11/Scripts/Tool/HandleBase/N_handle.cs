using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_handle : N_Spanner
     {
          //开始结束点的位置
          public Transform m_start, m_end;
          public Transform m_hand;
          //开始到结束点的方向
          Vector3 direction;
          float length;
          protected AnimationClip m_animatorClip = null;
          protected override void Start()
          {
               base.Start();
               if (m_start == null || m_end == null)
               {
                    m_start = transform.FindSibling("start");
                    m_end = transform.FindSibling("end");
               }
               BoxCollider t_box = m_start.GetComponent<BoxCollider>();
               if (t_box != null)
               {
                    t_box.enabled = false;
               }
               t_box = m_end.GetComponent<BoxCollider>();
               if (t_box != null)
               {
                    t_box.enabled = false;
               }
               if (m_animator == null)
               {

                    Debug.Log("<color=red>m_animator==null:</color>");

               }
               else
               {
                    m_animatorClip = m_animator.GetCurrentAnimatorClipInfo(0)[0].clip;
                    m_animator.enabled = false;
               }


               direction = m_end.position - m_start.position;
               length = direction.magnitude;
               direction.Normalize();

               m_start.gameObject.fns_closeMeshRender(false);
               m_end.gameObject.fns_closeMeshRender(false);


          }
          //float m_playtimeNow = 0f;
          protected virtual void fn_playAniTo(float _time)
          {
               float t_playtime=_time > m_max ? m_max : _time;
               m_animator.Play(0, 0, t_playtime);
               //if (m_playtimeNow != t_playtime)
               //{
               //     m_playtimeNow = t_playtime;
                   
               //     fnp_handleRotate();
               //}
          }
          //protected virtual void fnp_handleRotate()
          //{

          //}
          protected virtual void fnp_update()
          {
               if (m_isControl == false)
               {
                    return;
               }
               if (m_animator != null)
               {
                    if (m_animator.enabled == false)
                    {
                         m_animator.enabled = true;
                         m_isHanding = true;
                    }

                    float t_thetime = fn_projectToLine(m_hand);
                    fnp_changePosAni(t_thetime);

#if UNITY_EDITOR
                    Debug.DrawLine(m_start.position, m_hand.position, Color.blue);
                    Debug.DrawLine(m_start.position, m_end.position, Color.red);
#endif
               }

          }
          protected virtual void fnp_changePosAni(float _time)
          {
               fn_playAniTo(_time);
          }
          /// <summary>
          /// 动画播放的位置
          /// </summary>
          public float m_lastTime = 0f;
          /// <summary>
          /// 误差
          /// </summary>
          public float m_offset = 0f;
          bool m_isHanding = false;
          /// <summary>
          /// 动画最大播放时间
          /// </summary>
          protected float m_max = 0.9999f;
          /// <summary>
          /// 动画开始位置
          /// </summary>
          protected float m_min = 0f;
          public virtual float fn_projectToLine(Transform _movehand)
          {
               direction = m_end.position - m_start.position;
               //length = direction.magnitude;
               direction.Normalize();
               //Vector3 displacement = tr.position - m_start.position;
               //修改为以手柄的开始位置作为起点
               Vector3 displacement = _movehand.position - m_start.position;
               //displacement.Normalize(); 
               float t_lastProject = Vector3.Dot(displacement, direction);
               //Debug.DrawRay(m_start.position,)
               t_lastProject = t_lastProject <= 0f ? 0f : t_lastProject;

               float t_time = (t_lastProject / length);
               //计算误差
               if (m_isHanding)
               {
                    m_isHanding = false;
                    if (m_lastTime != 0f && m_lastTime != m_max)
                    {
                         m_offset = t_time - m_lastTime;
                    }
                    else { m_offset = 0f; }
               }
               t_time -= m_offset > 0f ? m_offset : 0f;
               t_time -= m_offset < 0f ? m_offset : 0f;
               //限制值在【0，1】
               //t_time = (t_time <= 0f) ? m_min : t_time;
               //t_time = t_time >= 1f ? m_max : t_time;
               t_time = S_static.fns_clamp01(m_min, m_max, t_time);
               //t_time = Mathf.Clamp01(t_time);

               if (m_lastTime != t_time && S_handShake.Instance.HandShake != null)
               {
                    S_handShake.Instance.HandShake();
               }

               //记录动画时间点
               m_lastTime = t_time;
               //m_lastProject = t_time;
               return t_time;
               //return 0f;
          }
          public override void fn_setTo(float _angel)
          {
               base.fn_setTo(_angel);
               //fnp_changePosAni(_angel);
               fnp_setAni(_angel);
          }

          protected void fnp_setAni(float _angel)
          {
               float t_time = S_static.fns_clamp01(m_min, m_max, _angel);

               m_animatorClip.SampleAnimation(this.gameObject, t_time);
               m_lastTime = t_time;
          }
          protected bool m_isControl = false;
          public override void fn_startControl(Transform _movehand)
          {
               if (m_isControl)
               {
                    return;
               }
               m_isControl = true;
               m_isHanding = true;
               m_hand = _movehand;
               S_update.Instance.M_update = fnp_update;

          }
          public override void fn_endControl()
          {
               if (m_isControl == false)
               {
                    return;
               }
               if (m_animator != null)
               {
                    m_animator.enabled = false;
               }
               m_isControl = false;
               m_hand = null;
               S_update.Instance.fn_remove(fnp_update);
          }
     }

}