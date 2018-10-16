using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 一个投影平面的管理实现,实现两点投射到一个平面后找到合适位置返回新的两点
     /// </summary>
     public class N_ArrangeOnPlane : AB_ArrangeOnPlane
     {
          protected Dictionary<string, AB_Rectangle> m_rectangles = new Dictionary<string, AB_Rectangle>();
          protected Transform m_this = null;
          protected override void Start()
          {
               base.Start();
               if (m_this==null)
               {
                    m_this = gameObject.transform; 
               }
          }
          #region normal and forward dir
          GetNormal m_planeNormal;
          public override Vector3 fn_getNormal()
          {
               m_planeNormal = GetComponent<GetNormal>();
               if (m_planeNormal != null)
               {
                    return m_planeNormal.fn_Normal(true);
               }
               else
               {
                    return Vector3.up;
               }
          }
          public Transform m_forward = null;
          public override Vector3 fn_getForward()
          {
               if (m_this == null)
               {
                    m_this = gameObject.transform;
               }
               if (m_forward == null)
               {
                    m_forward = transform.FindInChild("forwardObj");
               }
               if (m_forward != null)
               {
                    return (m_forward.position - m_this.position).normalized;
               }
               return Vector3.forward;
          } 
          #endregion

          public override Vector3[] fn_project(Vector3[] _points, string _name, float _width = 0.0025f)
          {
               throw new NotImplementedException();
          }

          protected override void fnp_findPos(ref Vector3[] _rec)
          {
               throw new NotImplementedException();
          }

          public override void fn_remove(string _pipename)
          {
               if (m_rectangles.ContainsKey(_pipename))
               {
                    m_rectangles[_pipename] = null;
                    m_rectangles.Remove(_pipename);
               }
          }
     }
}
