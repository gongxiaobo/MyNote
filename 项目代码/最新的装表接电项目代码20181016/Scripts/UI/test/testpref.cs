using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.TableMode;
namespace GasPowerGeneration
{

     public class testpref : MonoBehaviour
     {

          public bool test;
          public Select_mode mode;

          public Project projecttype;
          public int chapterindex;
          public Language m_lg;
          public E_TableMode me_tableMode = E_TableMode.e_null;
          // Use this for initialization
          void Start()
          {
               if (test)
                    PlayerPrefs.SetInt("test", 1);
               else
                    PlayerPrefs.SetInt("test", 0);
               PlayerPrefs.SetInt("index", chapterindex);
               PlayerPrefs.SetString("project", projecttype.ToString().ToLower());
               PlayerPrefs.SetString("mode", mode.ToString());
               PlayerPrefs.SetString("language", m_lg.ToString());

               //装表 接电专用
               S_SceneMessage.Instance.m_TableMode = me_tableMode;
               if (me_tableMode!= E_TableMode.e_null)
               {
                    S_SceneMessage.Instance.m_isTableModel = true;
               }
          }

     }

}