using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 机器的整体介绍的标签UI
     /// </summary>
     public class N_showIntroduceUI : N_HideShowNormal
     {
          void Start()
          {
               S_SceneMagT1.Instance.fn_putIntroduceMac(me_macName, this);
          }
          [EnumLabel("机器")]
          public E_MachineName me_macName = E_MachineName.e_null;
          public GameObject m_introduceUI = null;
          public GameObject m_voceUI = null;
          public override void fn_show()
          {
               base.fn_show();
               if (m_introduceUI != null)
               {
                    m_introduceUI.SetActive(true);
               }
               if (m_voceUI != null)
               {
                    m_voceUI.SetActive(true);
               }
          }
          public override void fn_hide()
          {
               base.fn_hide();
               fnp_hide();
               if (m_introduceUI != null)
               {
                    m_introduceUI.SetActive(false);
               }
               if (m_voceUI != null)
               {
                    m_voceUI.SetActive(false);
               }

          }
          /// <summary>
          /// 隐藏详细介绍和语音播放
          /// </summary>
          protected virtual void fnp_hide()
          {
               //隐藏文字框和语音播放
               AB_GetData t_introData = GetComponent<AB_GetData>();
               if (t_introData != null)
               {
                    t_introData.fn_hideDtae();
               }

          }

     }

}