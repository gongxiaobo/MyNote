using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 机器整体介绍的UI显示和声音播放
     /// </summary>
     public class N_showIntroduceOnUI : N_showIntroduceData, I_introduceVoice, I_introduceDetail
     {
          public Text m_title = null;
          public Text m_content = null;
          public GameObject m_introducePanel = null;
          public string m_soundname = "";
          public override void fn_showDate()
          {
               base.fn_showDate();

               if (m_info == null)
               {
                    return;
               }

               if (m_introducePanel != null)
               {
                    m_introducePanel.SetActive(true);
               }
               string t_language = S_SceneMessage.Instance.fn_getLanguage();
               if (m_title != null)
               {
                    m_title.text = (t_language == "Chinese") ? m_info.m_ch_name : m_info.m_o_name;
               }
               if (m_content != null)
               {
                    m_content.text = (t_language == "Chinese") ? m_info.m_ch_txt : m_info.m_o_txt;
               }
               m_soundname = (t_language == "Chinese") ? m_info.m_ch_voice : m_info.m_o_voice;
               fni_introduce(true);
               m_isShowDetail = true;
          }
          public override void fn_hideDtae()
          {
               base.fn_hideDtae();
               if (m_introducePanel != null)
               {
                    m_introducePanel.SetActive(false);
               }
               fni_introduce(false);
               m_isShowDetail = false;
          }

          bool m_isPlayingVoice = false;
          public void fni_introduce(bool _play)
          {
               S_SoundComSingle.Instance.fnp_sound(m_soundname, _play);
               if (_play == true)
               {
                    m_isPlayingVoice = true;
                    CancelInvoke("fnp_playOver");
                    Invoke("fnp_playOver", S_SoundComSingle.Instance.fn_soundLength(m_soundname));
                    fnp_controlAni("play");
               }
               else
               {
                    CancelInvoke("fnp_playOver");
                    fnp_playOver();
               }
          }
          protected void fnp_playOver()
          {
               m_isPlayingVoice = false;
               fnp_controlAni("stop");
          }
          protected void fnp_controlAni(string _trigger)
          {//喇叭动画的播放
               AB_AniTrigger t_ani = GetComponentInChildren<AB_AniTrigger>();
               if (t_ani != null)
               {
                    t_ani.fn_setTrigger(_trigger);
               }
          }

          public void fni_introduceTrigger()
          {
               fn_getDate();
               string t_language = S_SceneMessage.Instance.fn_getLanguage();
               m_soundname = (t_language == "Chinese") ? m_info.m_ch_voice : m_info.m_o_voice;
               if (m_isPlayingVoice)
               {
                    fni_introduce(false);
               }
               else
               {
                    fni_introduce(true);
               }
          }
          bool m_isShowDetail = false;
          public void fni_showTrigger()
          {
               if (m_isShowDetail)
               {
                    fn_hideDtae();
               }
               else
               {
                    fn_showDate();
               }
          }
     }
     /// <summary>
     /// 介绍机器的语音播放接口
     /// </summary>
     public interface I_introduceVoice
     {
          /// <summary>
          /// 播放和停止
          /// </summary>
          /// <param name="_play"></param>
          void fni_introduce(bool _play);
          /// <summary>
          /// 触发类型的开启和关闭声音播放
          /// </summary>
          void fni_introduceTrigger();
     }
     /// <summary>
     /// 机器介绍的显示触发开关
     /// </summary>
     public interface I_introduceDetail
     {
          void fni_showTrigger();
     } 
}