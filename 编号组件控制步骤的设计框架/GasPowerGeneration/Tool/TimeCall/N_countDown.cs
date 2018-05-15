using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     //namespace VRPT.Teaching
     //{
     ///<summary>
     ///@ version 1.0 /2017.0312/ :倒计时的类
     ///@ author gong
     ///@ version 1.1 /2017.0315/ :在reset中加入CallEvent = null;
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class N_countDown : TimeCount
     {
          private bool m_isinit = false;

          public override void CallTime(float calltime)
          {
               if (m_isinit == false)
               {
                    return;
               }
               if (counttime > 0f)
               {
                    counttime -= calltime;

               }
               else
               {

                    if (CallEvent != null)
                    {
                         CallEvent();
                         m_isinit = false;
                    }
               }
          }

          public override void SetCallSpace(float _fl, callFunction _cf)
          {
               if (m_isinit)
               {
                    return;
               }
               counttime = _fl;
               if (_cf == null)
               {
                    return;
               }
               CallEvent += _cf;
               m_isinit = true;
          }

          public override void Reset()
          {
               m_isinit = false;
               counttime = 0f;
               CallEvent = null;

          }
     }
     //}

}