using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_SpAni : AB_SpAni
     {
          Animator m_ani = null;
          AnimationClip m_AniClip;

          protected override void Start()
          {
               base.Start();
               m_ani = GetComponent<Animator>();
               if (m_ani != null)
               {
                    m_AniClip = m_AniClip ?? m_ani.GetCurrentAnimatorClipInfo(0)[0].clip;
               }
          }
          public override void fn_setAniTime(float _time)
          {

               if (m_AniClip != null)
               {//设置拉杆位置
                    m_AniClip.SampleAnimation(this.gameObject, _time);
               }
          }
     }

}