using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2016.1223/ :计算3点平面的法向量
     ///@ author gong
     ///@ version 1.1 /2016./ :
     ///@ author gong
     ///@ version 1.2 /2016./ :
     ///@ author gong
     ///@ version 1.3 /2016./ :
     ///@ author gong
     ///</summary>
     public class GetNormal : MonoBehaviour
     {
          public Transform m_obj1;
          public Transform m_obj2;
          public Transform m_obj3;
          Vector3 m_normal;
          public Vector3 Normal
          {
               get { return m_normal; }
               //set { m_normal = value; }
          }
          Vector3 m_normalone;
          public Vector3 Normalone
          {
               get { return m_normalone; }
               //set { m_normalone = value; }
          }
          void Start()
          {
               fn_getNormal();
          }
          protected void fn_getNormal()
          {
               if (m_obj1 != null && m_obj2 != null && m_obj3 != null)
               {
                    m_normal = Vector3.Cross(
                                        m_obj1.position - m_obj3.position,
                                        m_obj2.position - m_obj3.position);
                    m_normalone = Vector3.Normalize(m_normal);
               }

          }
          /// <summary>
          /// 获取平面的法线
          /// </summary>
          /// <param name="_normalize">true 单位法线</param>
          /// <returns></returns>
          public Vector3 fn_Normal(bool _normalize = false)
          {
               fn_getNormal();
               return _normalize ? m_normalone : m_normal;
          }


     }

}