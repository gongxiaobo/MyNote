using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class testyaobaUI : MonoBehaviour
     {

          //// Use this for initialization
          void Start()
          {
               m_panel.SetActive(false);
          }

          //// Update is called once per frame
          //void Update () {

          //}
          public GameObject m_panel;
          public Image m_circle;
          //float m_time;
          float m_scaletime = 1f;
          public void fn_startCountDown(float _time)
          {

               m_scaletime = 1f / _time;
               m_panel.SetActive(true);
               m_circle.fillAmount = 0f;
               m_counttime = 0f;
               S_update.Instance.M_update = fnp_update;
          }
          public void fn_hide()
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
               if (t_timecall > 1f)
               {
                    fn_hide();
               }
          }
     }

}