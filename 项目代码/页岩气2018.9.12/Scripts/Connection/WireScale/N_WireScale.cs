using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 设置线的size
     /// </summary>
     public class N_WireScale : AB_WireScale
     {
          /// <summary>
          /// 粗细的基础设置值
          /// </summary>
          public float m_sizeFactor = 0.25f;
          protected Transform m_thisWire=null;
          protected Vector3 m_defaultSize;
          public Vector3 m_Axis = new Vector3(1f, 0f, 1f);
          /// <summary>
          /// 设置电线的size
          /// </summary>
          /// <param name="_size">string size </param>
          public override void fn_setWireSize(string _size)
          {
               if (m_thisWire==null)
               {
                    m_thisWire = this.gameObject.transform;
                    m_defaultSize = m_thisWire.localScale;
               }
               float t_temp = float.Parse(_size);
               t_temp *= m_sizeFactor;
               Vector3 t_size = new Vector3(
                    m_defaultSize.x * (m_Axis.x == 1f ? t_temp : 1f),
                    m_defaultSize.y * (m_Axis.y == 1f ? t_temp : 1f),
                    m_defaultSize.z * (m_Axis.z == 1f ? t_temp : 1f));
               m_thisWire.localScale = t_size;

          }
     } 
}
