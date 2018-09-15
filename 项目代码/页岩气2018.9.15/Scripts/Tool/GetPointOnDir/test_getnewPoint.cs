using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.Tool.GetPointOnDir
{
     class test_getnewPoint : MonoBehaviour
     {
          public Transform m_dirA,m_dirB;
          void Start()
          {
               Vector3 t_dir =m_dirB.position- m_dirA.position ;
               //gameObject.transform.position += t_dir.normalized;
               gameObject.transform.position = s_getPointOnDir.fns_getPointOnDirLine(gameObject.transform.position, t_dir.normalized);
          }
     }
}
