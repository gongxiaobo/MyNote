using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using Assets.Scripts.Tool.ShowLineInEditor;
using UnityEngine;
namespace Assets.Scripts.Connection.PointOnPlane
{
     class test_getNormal:MonoBehaviour
     {
          public Transform m_A,m_B,m_C;
          void Update()
          {
               Vector3 t_ab = m_B.position - m_A.position;
               Vector3 t_ac = m_C.position - m_A.position;
               Vector3 t_cross = Vector3.Cross(t_ab, t_ac);
               Debug.Log("<color=blue>blue:</color>" + t_cross.normalized);
               ShowLineInEditor.Instance.fn_PutInDot("tst_normal", new Vector3[2] { gameObject.transform.position,
                    t_cross.normalized+gameObject.transform.position }, Color.yellow);
          }
     }
}
