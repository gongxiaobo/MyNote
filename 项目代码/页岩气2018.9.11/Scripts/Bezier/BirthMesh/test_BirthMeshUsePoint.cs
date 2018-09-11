using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
using Assets.Scripts.Bezier.BirthMesh.MyInterface;
namespace Assets.Scripts.Bezier.BirthMesh
{
     /// <summary>
     /// 测试生成管道使用的类
     /// </summary>
     public class test_BirthMeshUsePoint:MonoBehaviour
     {
          public Vector3[] m_KeyPoint;
          public Material m_pipeMat = null;
          void Start() { }
          void Update() {
               if (Input.GetKeyDown(KeyCode.G))
               {
                    AB_BirthMesh t_birthMesh = GetComponent<AB_BirthMesh>();
                    I_PutKeyPoint ti_putkeyPoint = GetComponent<I_PutKeyPoint>();
                    if (ti_putkeyPoint!=null)
                    {
                         ti_putkeyPoint.fni_putKeyPoint(m_KeyPoint);
                         if (t_birthMesh!=null)
                         {
                              t_birthMesh.fn_BirthMesh(() => { t_birthMesh.M_MeshObj.GetComponent<MeshRenderer>().material = m_pipeMat; });
                         }
                    }


               }
          }
         

     }
}
