using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 开始就隐藏模型
     /// </summary>
     public class HideOnStart : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               MeshRenderer[] m_childMeshed = null;
               if (m_childMeshed == null)
               {
                    m_childMeshed = gameObject.GetComponentsInChildren<MeshRenderer>();
               }
               for (int i = 0; i < m_childMeshed.Length; i++)
               {

                    m_childMeshed[i].enabled = false;
               }
          }


     } 
}
