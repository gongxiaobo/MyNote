using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.SelectUI;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.LearnModeConnect
{
     /// <summary>
     /// 918:装表接电教学模式下的自动连线处理类
     /// </summary>
     public class N_LearnModeConnect : AB_LearnModeConnect
     {
          /// <summary>
          /// 现在需要链接的线信息
          /// </summary>
          protected string m_connectNow = "";
          /// <summary>
          /// 链接线的一个接口ID
          /// </summary>
          protected string m_portID="";
          /// <summary>
          /// 当前的提示语音名称
          /// </summary>
          protected string m_soundName = "";
          /// <summary>
          /// 链接条件是否都满足
          /// </summary>
          protected bool m_checkOk = false;
          /// <summary>
          /// true为不是连线类型的操作组件
          /// </summary>
          protected bool m_isIntroduce = false;
          public override void fn_callOneConnect(string _portID, string _portState, string _tableData, string _soundName)
          {
               if (_tableData=="on"||_tableData=="off")
               {//检查是否是介绍类型，不用操作的类型，等介绍完毕后，自动把状态改为 on
                    m_isIntroduce = true;
                    m_checkOk = true;
                    m_portID = _portID;
                    m_soundName = _soundName;
                    return;
               }
               //else
               //{
               //     m_isIntroduce = false;
               //}

               if (m_portID==_portID)
               {
                    return;
               }
               m_checkOk = false;
               m_portID = _portID;
               m_soundName = _soundName;
               if (_tableData == "" || _portID == "")
               {
                    return;
               }
               //检查一个接口多根连线的情况
               short t_num = S_ParseWirePara.fn_getParaNumber(_tableData);
               m_connectNow = "";
               if (t_num == 0)
               {
                    return;
               }
               if (t_num == 1)
               {
                    m_connectNow = _tableData;
               }
               else if (t_num == 2)
               {
                    string[] t_twoline = S_ParseWirePara.fn_SplitToTwo(_tableData);
                    //需要检查接口以及链接好的信息，取出还没有链接的线
                    for (int i = 0; i < t_twoline.Length; i++)
                    {
                         if (_portState != t_twoline[i])
                         {
                              m_connectNow = t_twoline[i];
                              break;
                         }
                    }
               }
               else if (t_num == 3)
               {
                    string[] t_twoline = S_ParseWirePara.fn_SplitToThree(_tableData);
                    //需要检查接口以及链接好的信息，取出还没有链接的线
                    for (int i = 0; i < t_twoline.Length; i++)
                    {
                         if (_portState != t_twoline[i])
                         {
                              m_connectNow = t_twoline[i];
                              break;
                         }
                    }
               }
               if (m_connectNow=="")
               {
                    return;
               }
               m_isIntroduce = false;
               m_checkOk = true ;

          }
          bool m_pause = false;
          public override bool M_isPause
          {
               get
               {
                    return m_pause;
               }
               set
               {
                    m_pause = value;
                    fnp_Pause();
               }
          }
          protected virtual void fnp_Pause()
          {
               if (M_isPause)
               S_SoundComSingle.Instance.fnp_sound(m_soundName, false);
          }
     }
}
