using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.MainUI
{
     class TableTitle : MonoBehaviour
     {
          void Start()
          {
               Invoke("fnp_showTitle", 0.85f);
          }
          public GameObject m_title = null;
          private void fnp_showTitle()
          {
               if (S_SceneMessage.Instance.m_isTableModel)
               {
                    if (m_title != null)
                    {
                         m_title.SetActive(true);
                    }
               }
               
          }
     }
}
