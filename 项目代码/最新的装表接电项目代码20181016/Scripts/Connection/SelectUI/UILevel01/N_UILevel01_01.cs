using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 线的类型选择：软，硬
     /// </summary>
     public class N_UILevel01_01 : N_UILevel01
     {
          public List<E_ropeMode> m_ropes = new List<E_ropeMode>();
          public E_ropeMode m_ropemode = E_ropeMode.e_hard;
          public N_UIdata m_name;
          int m_modeId = 0;
          protected override void Start()
          {
               base.Start();
               if (m_txt == null)
               {
                    m_txt = GetComponentInChildren<Text>();
               }
               fnp_showSize();
          }
          public override void fni_receive(SMsg _reveive)
          {
               //base.fni_receive(_reveive);
               if (_reveive.m_ID == m_UIID)
               {//当消息是自己发出，不处理
                    return;
               }
               if (_reveive.m_ID==9)
               {
                    m_modeId--;
                    if (m_modeId<=0)
                    {
                         m_modeId = 0;
                    }
               }
               if (_reveive.m_ID==8)
               {
                    m_modeId++;
                    if (m_modeId >= (m_ropes.Count-1))
                    {
                         m_modeId = m_ropes.Count - 1;
                    }
               }
               m_ropemode = m_ropes[m_modeId];
               fnp_showSize();
          }
          Text m_txt = null;
          protected void fnp_showSize()
          {
               if (m_txt != null)
               {
                    string t_name = "xx";
                    if (m_name!=null)
                    {
                         t_name = m_name.m_datas[(int)m_ropemode].m_name;
                         S_selectUI.Instance.m_ropemode = 
                              m_name.m_datas[(int)m_ropemode].m_codeName;
                    }
                    else
                    {

                         Debug.Log("<color=red>m_name==null</color>");
     
                    }
                    m_txt.text = t_name;

               }
          }

     } 
}
