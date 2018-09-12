using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tool.ShowLineInEditor;
using Assets.Scripts.Bezier.BirthMesh;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 测试一点在多个平面上的投影结果
     /// </summary>
     class test_pointsOnLotsPlanes:MonoBehaviour
     {
          public Transform m_start = null;
          public List<AB_Plane> m_planes = new List<AB_Plane>();
          public Material m_color;
          public Vector3 m_meshAxis;
          void Start()
          {
               //获得投影点
               List<Vector3> t_path = new List<Vector3>();
               t_path.Add(m_start.position);
               for (int i = 0; i < m_planes.Count; i++)
               {
                    Vector3[] t_new = m_planes[i].fn_project(new Vector3[1] { t_path[t_path.Count - 1] }, "xx");
                    if (t_new==null)
                    {
                         continue;
                    }
                    if (t_new.Length==1)
                    {
                         t_path.Add(t_new[0]);
                         continue;
                    }
                    if (t_new.Length==2)
                    {
                         t_path.Add(t_new[0]);
                         t_path.Add(t_new[1]);
                         continue;
                    }
               }
               Vector3[] t_result=t_path.ToArray();
               Debug.Log("<color=blue>point cout = </color>" + t_result.Length);

               //ShowLineInEditor.Instance.fn_PutInDot("xx", t_result, Color.blue);
               S_BirthPipeMesh.Instance.fn_BirthPipe("xx", t_result, 0.0025f*4f, m_color, m_meshAxis);

          }
     }
}
