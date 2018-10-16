using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.MainUI
{
     /// <summary>
     /// 18925:在装表接电模式下，去除自由模式
     /// </summary>
     class RemoveFreeModel : MonoBehaviour
     {
          public Transform m_freeModel = null;
          public Transform m_testModel = null;
          void Start()
          {
               if (S_SceneMessage.Instance.m_isTableModel)
               {
                    if (m_freeModel != null && m_testModel != null)
                    {
                         Vector3 t_freeLocal = m_freeModel.localPosition;
                         m_freeModel.gameObject.SetActive(false);
                         m_testModel.localPosition = t_freeLocal;
                    } 
               }
               Destroy(this);
          }
     }
}
