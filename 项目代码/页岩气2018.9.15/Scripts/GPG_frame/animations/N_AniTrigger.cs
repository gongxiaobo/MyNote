using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// trigger类型的动画播放
     /// </summary>
     public class N_AniTrigger : AB_AniTrigger
     {
          protected Animator m_ani = null;
          protected string m_triggerName = "";
          public override void fn_setTrigger(string _trigger)
          {
               if (m_triggerName == _trigger)
               {
                    return;
               }
               if (m_triggerName != _trigger)
               {
                    m_triggerName = _trigger;
               }
               fnp_findAni();
               if (m_ani != null)
               {
                    m_ani.SetTrigger(_trigger);
               }

          }
          protected virtual void fnp_findAni()
          {
               m_ani = m_ani ?? GetComponent<Animator>();
          }
     } 
}
