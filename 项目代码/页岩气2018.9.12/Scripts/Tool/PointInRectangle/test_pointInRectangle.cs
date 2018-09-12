using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tool.PointInRectangle
{
     class test_pointInRectangle:MonoBehaviour
     {
          public Transform[] m_rec = new Transform[4];
          public Transform m_point = null;
          void Start()
          {

          }
          void Update()
          {
               if (s_PointInRectangle.fns_InRectangle(new Vector3[4] { 
                    m_rec[0].position, m_rec[1].position, m_rec[2].position, m_rec[3].position }, 
                    m_point.position))
               {
                    
                    Debug.Log("<color=blue>in</color>");

               }
               else
               {
                    Debug.Log("<color=blue>out</color>");
               }
          }
     }
}
