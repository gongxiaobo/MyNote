using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;

namespace Assets.Scripts.GPG_frame._35kvAnimation
{
     public class test_getAnimations:MonoBehaviour
     {
          Animator m_thisAnimator = null;
          void Start()
          {
               m_thisAnimator = GetComponent<Animator>();
               m_thisAnimator.SetTrigger("go1");
               //Debug.Log("<color=blue>blue:</color>" + m_thisAnimator.GetCurrentAnimatorClipInfoCount(0));

               InvokeRepeating("fn_findAniClip", 0f, 1f);

          }

          private void fn_findAniClip()
          {
               AnimatorClipInfo[] t_clips = m_thisAnimator.GetCurrentAnimatorClipInfo(0);
               for (int i = 0; i < t_clips.Length; i++)
               {

                    Debug.Log("<color=blue>现在的动画blue:</color>" + t_clips[i].clip.name);

               }
          }
          void OnDisable()
          {
               CancelInvoke("fn_findAniClip");
          }
     }
}
