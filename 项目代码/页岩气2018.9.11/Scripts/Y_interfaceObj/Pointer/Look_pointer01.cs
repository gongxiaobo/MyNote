using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理泵的参数表的指针在一个值的左右抖动功能
     /// </summary>
     public class Look_pointer01 : Look_pointer, I_StopWaveMotion
     {
          //是否打开波动功能,如果打开，那么指针会围绕一个值波动显示，不会影响正常值的获取。
          public bool m_OpenWaveMotion = false;

          protected override void fnp_newValueStartSet()
          {
               CancelInvoke("fnp_waveMotion");
               base.fnp_newValueStartSet();
               //开始一个新的值，需要停止参数的抖动显示
          }
          protected override void fnp_endValueSet()
          {
               base.fnp_endValueSet();
               //在新的值设置完成后，可以开始执行抖动显示
               if (m_valueNow == 0f || m_OpenWaveMotion==false)
               {//如果是最小值，那么就不波动参数了
                    return;
               }
               InvokeRepeating("fnp_waveMotion", 0.5f, Random.Range(0.8f, 1.35f));
          }
          public Vector2 m_range;
          public float m_randRange = 0.01f;
          I_ParaSet mi_paraset;
          protected void fnp_waveMotion()
          {
               if (m_OpenWaveMotion==false)
               {
                    return;
               }
               m_range = new Vector2(-(m_max - m_min) * m_randRange, (m_max - m_min) * m_randRange);
               float t_waveTime= m_valueNow + Random.Range(m_range.x, m_range.y)* m_factor;
               t_waveTime = Mathf.Clamp01(t_waveTime);
               fnp_SampleAni(t_waveTime);

               //把数字显示也同时设置
               if (mi_paraset==null)
               {
                    mi_paraset = transform.parent.GetComponent<I_ParaSet>(); 
               }
               if (mi_paraset!=null)
               {
                    mi_paraset.fni_newParaSet((m_min < 0f ? (t_waveTime / m_factor + m_min) : t_waveTime / m_factor)); 
               }
     
          }

          public void OnDisable()
          {
               CancelInvoke("fnp_waveMotion");
          }



          #region I_StopWaveMotion
          public void fni_StopMotion()
          {
               CancelInvoke("fnp_waveMotion");
               m_OpenWaveMotion = false;
               fnp_SampleAni(m_valueNow);
          }

          public void fni_StartMotion()
          {
               CancelInvoke("fnp_waveMotion");
               m_OpenWaveMotion = true;
               InvokeRepeating("fnp_waveMotion", 0.5f, Random.Range(0.8f, 1.35f));
          } 
          #endregion
     }
}
