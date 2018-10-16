using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tool.ShowLineInEditor;
namespace Assets.Scripts.Connection.PointOnPlane
{
     class test_1in1out : MonoBehaviour
     {
          public Transform m_inPoint1 = null;
          public Transform m_inPoint2 = null;
          AB_Plane m_plane;
          public string m_name="xx";
          void Start()
          {
               m_plane = GetComponent<AB_Plane>();

               if (m_plane.m_PlaneStyle == E_PlaneStyle.e_1IN1OUT)
               {
                    Vector3[] t_project = m_plane.fn_project(new Vector3[1] { m_inPoint1.position }, m_name);
                    //ShowLineInEditor.Instance.fn_PutInDot("1in1out", new Vector3[2] { m_inPoint.position, t_project[0] }, Color.red);
                    ShowLineInEditor.Instance.fn_PutInDot(m_name, new Vector3[2] { m_inPoint1.position, t_project[0] }, Color.red);
               }
               if (m_plane.m_PlaneStyle == E_PlaneStyle.e_1IN2OUT)
               {
                    Vector3[] t_project1 = m_plane.fn_project(new Vector3[1] { m_inPoint1.position }, m_name);
                    if (t_project1.Length==2)
                    {
                         ShowLineInEditor.Instance.fn_PutInDot(m_name, t_project1, Color.blue);
                    }
                    else
                    {
                         ShowLineInEditor.Instance.fn_PutInDot(m_name, new Vector3[2] { m_inPoint1.position, t_project1[0]}, Color.blue);
                    }
                    Vector3[] t_project2 = m_plane.fn_project(new Vector3[1] { m_inPoint2.position }, m_name + "1");
                    if (t_project2.Length==2)
                    {
                         ShowLineInEditor.Instance.fn_PutInDot(m_name + "1", t_project2, Color.blue);
                    }
                    else
                    {
                         ShowLineInEditor.Instance.fn_PutInDot(m_name + "1", new Vector3[2] { m_inPoint2.position, t_project2[0] }, Color.blue);
                    }
               }
          }

     }
}
