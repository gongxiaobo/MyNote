using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 动画机的跳转
     /// </summary>
     public class N_AnimatorControl : AB_AnimatorControl
     {
          protected Animator m_ani = null;
          protected override void Start()
          {
               base.Start();
               m_ani = GetComponent<Animator>();
          }
          public override void fn_Trigger(string _trigger)
          {
               if (m_ani != null)
               {
                    m_ani.SetTrigger(_trigger);
               }
          }

          public override void fn_Reset()
          {
               throw new System.NotImplementedException();
          }
     } 
}
