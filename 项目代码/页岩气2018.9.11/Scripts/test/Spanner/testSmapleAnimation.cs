using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class testSmapleAnimation : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               m_ani = GetComponent<Animator>();
          }

          // Update is called once per frame
          //void Update () {

          //}
          Animator m_ani = null;
          AnimationClip m_AniClip;
          public void fn_sample(float _time)
          {
               m_AniClip = m_AniClip ?? m_ani.GetCurrentAnimatorClipInfo(0)[0].clip;
               if (m_AniClip != null)
               {//设置拉杆位置
                    m_AniClip.SampleAnimation(this.gameObject, _time);
               }
          }
     } 
}
