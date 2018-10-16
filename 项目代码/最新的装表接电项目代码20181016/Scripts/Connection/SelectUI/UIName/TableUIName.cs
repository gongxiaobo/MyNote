using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Connection.TableMode;
namespace GasPowerGeneration
{
     class TableUIName:MonoBehaviour
     {
          protected Text m_txt;
          void Start()
          {
               m_txt = GetComponent<Text>();
               if (m_txt==null)
               {
                    m_txt = GetComponentInChildren<Text>();
               }
               if (m_txt!=null)
               {
                    switch (S_SceneMessage.Instance.m_TableMode)
                    {
                         case E_TableMode.e_null:
                              break;
                         case E_TableMode.e_learn:
                              m_txt.text = "学习模式";
                              break;
                         case E_TableMode.e_test:
                              m_txt.text = "训练模式";
                              break;
                         case E_TableMode.e_troubleshooting:
                              m_txt.text = "故障模式";
                              break;
                         case E_TableMode.e_newbird:
                              m_txt.text = "新手引导";
                              break;
                         default:
                              break;
                    }
               }
          }
     }
}
