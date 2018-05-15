using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 指针的动画版实现
     /// 修改指针的旋转精度
     /// </summary>
     public class N_Pointer : AB_Pointer
     {
          AnimationClip m_AniClip = null;
          /// <summary>
          /// 是否正在设置值
          /// </summary>
          bool m_isSetting = false;

          public float m_min = 0f, m_max = 180f;
          public float m_start = 0f;
          protected float m_factor = 0.1f;

          protected TimeCount1 m_timecall = new TimeCount1();
          protected override void Start()
          {
               base.Start();
               if (fnp_getClip() == false)
               {
                    Destroy(this);
               }
               fnp_cuclateFactor();
               m_timecall.SetCallSpace(0.08f, fnp_rotateSmooth);
          }
          protected virtual void fnp_cuclateFactor()
          {
               if (m_min > m_max)
               {
                    float t_max = m_min;
                    m_min = m_max;
                    m_max = t_max;
               }

               if (m_max < 0f)
               {
                    m_factor = 1f / (Mathf.Abs(m_max) - m_min);
               }
               else
               {
                    m_factor = 1f / (m_max - m_min);
               }
          }
          protected virtual bool fnp_getClip()
          {
               bool t_back = false;
               Animator t_animator = GetComponent<Animator>();
               if (t_animator != null)
               {
                    m_AniClip = t_animator.GetCurrentAnimatorClipInfo(0)[0].clip;
                    t_animator.enabled = false;
                    t_back = true;
                    m_AniClip.SampleAnimation(this.gameObject, m_start);
               }


               return t_back;
          }
          float m_valueNew = 0f, m_valueNow = 0f;
          public override void fn_inputValue(float _value)
          {
               m_valueNew = fnp_input(_value);
               m_valueNew *= m_factor;

               //Debug.Log("<color=blue>传入表的参数blue:</color>" + m_valueNew);

               if (m_isSetting == false)
               {
                    m_isSetting = true;
                    S_update.Instance.M_fixedupdate = fnp_FixedUpdate;
               }

          }
          protected virtual float fnp_input(float _inValue)
          {
               float t_out = 0f;
               t_out = _inValue;
               if (_inValue < m_min)
               {
                    t_out = m_min;
               }
               if (_inValue > m_max)
               {
                    t_out = m_max;
               }
               return t_out;

          }
          protected override void fnp_FixedUpdate()
          {

               //Debug.Log("<color=blue>blue:</color>");
               m_timecall.CallTime(Time.deltaTime);

          }
          protected float m_offset = 0.01f;
          protected virtual void fnp_rotateSmooth()
          {
               if (m_valueNow != m_valueNew)
               {
                    if (m_valueNow > m_valueNew)
                    {
                         if (m_valueNow - m_valueNew >= m_offset)
                         {
                              m_valueNow -= m_offset;
                         }

                         if (m_valueNow - m_valueNew < m_offset)
                         {
                              m_valueNow = m_valueNew;
                         }
                    }
                    if (m_valueNow < m_valueNew)
                    {
                         if (m_valueNew - m_valueNow >= m_offset)
                         {
                              m_valueNow += m_offset;
                         }

                         if (m_valueNew - m_valueNow < m_offset)
                         {
                              m_valueNow = m_valueNew;
                         }
                    }
                    m_AniClip.SampleAnimation(this.gameObject, m_valueNow);
               }
               else
               {
                    if (m_isSetting)
                    {
                         S_update.Instance.fn_removeFixed(fnp_FixedUpdate);
                         m_isSetting = false;
                    }

               }
          }
     }

}