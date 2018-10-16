//using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Connection.TableMode;
namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电下，完成，暂停，继续按钮的共用UI显示
     /// </summary>
     public class N_UILevel01_05_01 : N_UILevel01_05
     {
          public string m_Name1 = "完成";
          public string m_Name2 = "暂停";
          public string m_Name3 = "继续";
          public Text m_txt = null;
          protected override void Start()
          {
               base.Start();
               m_txt = GetComponent<Text>();
               if (m_txt ==null)
               {
                    m_txt = GetComponentInChildren<Text>();
               }
               switch (S_SceneMessage.Instance.m_TableMode)
               {
                    case E_TableMode.e_null:
                         fnp_fide();
                         break;
                    case E_TableMode.e_learn:
                         m_txt.text = m_Name2;
                         break;
                    case E_TableMode.e_test:
                    case E_TableMode.e_troubleshooting:
                         m_txt.text = m_Name1;
                         break;
                    case E_TableMode.e_newbird:
                         fnp_fide();
                         break;
                    default:
                         break;
               }
              
          }

          private void fnp_fide()
          {
               GetComponent<Image>().enabled = false;
               m_txt.enabled = false;
               GetComponent<BoxCollider>().enabled = false;
          }
          public override void fn_buttonHit()
          {
               base.fn_buttonHit();
               if (m_txt!=null)
               {
                    if (m_txt.text==m_Name2)
                    {
                         m_txt.text = m_Name3;
                         return;
                    }
                    if (m_txt.text == m_Name3)
                    {
                         m_txt.text = m_Name2;
                         return;
                    }
                    
               }
          }
     }
}
