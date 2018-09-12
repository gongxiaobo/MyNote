using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     //namespace VRPT.Teaching
     //{
     ///<summary>
     ///@ version 1.0 /2017.0312/ :倒计时组件，时间到时自动销毁
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class N_countDownCP : A_countDownComponent
     {
          private bool m_isinit = false;

          public override void initial(float callSpace, TimeCount.callFunction call)
          {

               if (m_isinit)
               {
                    return;
               }
               if (call == null)
               {
                    Destroy(this);
                    return;
               }
               m_timecount1.SetCallSpace(callSpace, call);
               m_timecount1.M_CallEvent += Kill;
               m_isinit = true;


          }

          protected override void FixedUpdate()
          {
               //		base.FixedUpdate ();
               if (m_timecount1 != null)
               {
                    m_timecount1.CallTime(Time.deltaTime);
               }


          }

          public override void Kill()
          {
               m_timecount1.Reset();
               m_timecount1 = null;
               Destroy(this);
          }


     }
     //}

}