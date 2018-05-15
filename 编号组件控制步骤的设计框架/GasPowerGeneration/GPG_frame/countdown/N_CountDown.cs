using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{

     /// <summary>
     /// 摇把上的倒计时UI的显示倒计时功能
     /// </summary>
     public class N_CountDown : AB_CountDown
     {
          public GameObject m_panel;
          public Image m_circle;
          //float m_time;
          float m_scaletime = 1f;
          protected override void Start()
          {
               base.Start();
               m_panel.SetActive(false);
          }
          public override void fn_startCountDown(float _time)
          {
               m_scaletime = 1f / _time;
               m_panel.SetActive(true);
               m_circle.fillAmount = 0f;
               m_counttime = 0f;
               S_update.Instance.M_update = fnp_update;
          }
          public override void fn_endCountDown()
          {
               S_update.Instance.fn_remove(fnp_update);
               m_panel.SetActive(false);
          }
          float m_counttime = 0f;
          protected void fnp_update()
          {
               m_counttime += Time.deltaTime;
               float t_timecall = m_counttime * m_scaletime;
               m_circle.fillAmount = t_timecall >= 1f ? 1f : t_timecall;
               if (t_timecall >= 1f)
               {
                    fn_endCountDown();
               }
          }
     }

}