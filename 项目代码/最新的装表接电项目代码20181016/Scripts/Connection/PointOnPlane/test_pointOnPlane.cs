using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Bezier.BirthMesh;
using Assets.Scripts.Tool.GetPointOnDir;
using Assets.Scripts.Tool.PointOnPlane;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 测试一个点在一个面上的投影点
     /// </summary>
     class test_pointOnPlane:MonoBehaviour
     {
          public GameObject m_plane=null;
          public Transform m_planeForward = null;
          public Vector3 m_planeForwardDir;
          public Transform m_portA, m_portB;
          public test_BirthMeshUsePoint m_birthMesh = null;
          public float m_moveDis = 0.1f;
          void Start()
          {
               m_planeForwardDir = (m_planeForward.position - m_plane.transform.position).normalized;

               GetNormal t_planeNormal = m_plane.GetComponent<GetNormal>();

               Vector3 t_proA = s_pointOnPlane.fns_pointOnPlane(m_portA.position, m_plane.transform.position,t_planeNormal.fn_Normal());
               t_proA = s_getPointOnDir.fns_getPointOnDirLine(t_proA, m_planeForwardDir, m_moveDis);

               Vector3 t_proB = s_pointOnPlane.fns_pointOnPlane(m_portB.position, m_plane.transform.position, t_planeNormal.fn_Normal());
               t_proB = s_getPointOnDir.fns_getPointOnDirLine(t_proB, m_planeForwardDir, m_moveDis);


               Vector3[] t_points = new Vector3[4];
               t_points[0] = m_portA.position;
               t_points[1] = t_proA;
               t_points[2] = t_proB;
               t_points[3] = m_portB.position;

               m_birthMesh.m_KeyPoint = t_points;
          }
          protected void fnp_flag(Vector3 _pos)
          {
               GameObject t_new = new GameObject(_pos.z.ToString());
               t_new.transform.position = _pos;
               
          }
     }
}
