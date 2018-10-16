using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.SelectUI;
using GasPowerGeneration;

namespace Assets.Scripts.Connection.LearnModeConnect
{
     /// <summary>
     /// 9.18:在教学模式下的自动连接线的处理实现版本1
     /// 927：添加不是连线的自动操作组件，处理开关类型
     /// </summary>
     partial class N_LearnModeConnect_01 : N_LearnModeConnect
     {
          string m_thetableData = "";
          public float m_offset = 2f;
          public override void fn_callOneConnect(string _portID, string _portState, string _tableData, string _soundName)
          {
               base.fn_callOneConnect(_portID, _portState, _tableData, _soundName);
               m_thetableData = _tableData;
               if (m_checkOk)
               {
                    if (m_isIntroduce==false)
                    {
                         fnp_setWirePara(); 
                    }
                    //找到声音的时间长度
                    float t_soundlength = S_SoundComSingle.Instance.fn_soundLength(m_soundName);
                    t_soundlength += m_offset;
#if UNITY_EDITOR
                    t_soundlength = 0.3f;
#endif
                    Invoke("fnp_connectNow", t_soundlength);


               }

               Debug.Log("<color=blue>自动操作:</color>" + _portID);
     

          }
          protected override void fnp_Pause()
          {
               base.fnp_Pause();
               if (M_isPause)
               {
                    CancelInvoke("fnp_connectNow");
               }
               else
               {
                    if (m_connectNow != "")
                    {
                         if (m_isIntroduce==false)
                         {
                              fnp_setWirePara(); 
                         }
                         S_SoundComSingle.Instance.fnp_sound(m_soundName);
                         //找到声音的时间长度
                         float t_soundlength = S_SoundComSingle.Instance.fn_soundLength(m_soundName);
                         Invoke("fnp_connectNow", t_soundlength + m_offset);
                    }
                    if (m_isIntroduce)
                    {//不是连线的时候
                         //找到声音的时间长度
                         float t_soundlength = S_SoundComSingle.Instance.fn_soundLength(m_soundName);
                         Invoke("fnp_connectNow", t_soundlength + m_offset);

                    }
               }
          }
          /// <summary>
          /// 设置选中线的参数
          /// </summary>
          protected void fnp_setWirePara()
          {

               S_selectUI.Instance.fni_setWireSelect(m_connectNow);
          }
          /// <summary>
          /// 自动连接
          /// </summary>
          protected void fnp_connectNow()
          {
               if (m_isIntroduce==false)
               {
                    string[] t_co = S_ParseWirePara.fn_getPara(m_connectNow);
                    S_ConnectWire.Instance.fn_select(S_Ports.Instance.fn_getPort(t_co[0]).GetComponent<AB_Name>());
                    S_ConnectWire.Instance.fn_select(S_Ports.Instance.fn_getPort(t_co[1]).GetComponent<AB_Name>());
               }
               else
               {//开关类型在教学模式下自动赋值功能 
                    int t_id;
                    if (int.TryParse(m_portID, out t_id))
                    {
                         GameObject t_item = S_SceneMagT1.Instance.fn_getItemObj(t_id);
                         
                         if (t_item==null)
                         {
                              return;
                         }
                         AB_HandleEvent t_handle = t_item.GetComponent<AB_HandleEvent>();
                         AB_SetState t_set = new N_SetState();
                         t_set.fn_setState("onoff", m_thetableData, t_handle);
                         I_Control t_control = t_item.GetComponent<I_Control>();
                         if (t_control!=null)
                         {
                              if (m_thetableData=="off")
                              {
                                   t_control.fni_off();
                              }
                              else if (m_thetableData=="on")
                              {
                                   t_control.fni_on();
                              }
                         }
                    }

               }
              
               //m_connectNow = "";
               //m_checkOk = false;
               //m_soundName = "";
               //m_portID = "";
          }
     }
}
