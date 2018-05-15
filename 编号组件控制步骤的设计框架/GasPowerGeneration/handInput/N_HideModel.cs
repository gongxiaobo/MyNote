using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 隐藏此物体下的所有子节点上的mesh
     /// </summary>
     public class N_HideModel : AB_HideModel
     {
          MeshRenderer[] m_childMeshed = null;
          public override void fn_hide(bool _isShow)
          {
               if (m_childMeshed == null)
               {
                    m_childMeshed = gameObject.GetComponentsInChildren<MeshRenderer>();
               }
               for (int i = 0; i < m_childMeshed.Length; i++)
               {
                    if (m_childMeshed[i].name == "ray")
                    {
                         continue;
                    }
                    if (m_childMeshed[i].name == "trigger")
                    {
                         continue;
                    }
                    m_childMeshed[i].enabled = _isShow;
                    //Debug.Log("<color=blue>隐藏模型</color>" + gameObject.name);
               }



          }

     } 
}
