using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.PointOnPlane;
using Assets.Scripts.Bezier.BirthMesh;
namespace Assets.Scripts.Connection.Port
{
     /// <summary>
     /// 测试使用新的接口方式来链接电线
     /// </summary>
     public class test_newConnect : MonoBehaviour
     {
          //Dictionary<int,>
          public Transform m_a, m_b;
          public Transform m_a1, m_b1;
          public Material mMat = null;
          public Vector3 m_meshAxis = new Vector3(0, 1, 0);
          public Transform m_c1, m_c2, m_c3;
          public Transform m_one1, m_one2, m_one3;
          //
          public Transform mSelect1, mSelect2;
          public Transform mSelect3, mSelect4;
          //public string
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.C))
               {//
                   
                    AB_PortPath t_portA = m_a.GetComponent<AB_PortPath>();
                    AB_PortPath t_portB = m_b.GetComponent<AB_PortPath>();

                    string t_wireName = m_a.name + m_b.name;
                    float t_wireR = 0.002f;
                    fnp_connect(t_portA, t_portB, t_wireName, t_wireR);
                     t_portA = m_a1.GetComponent<AB_PortPath>();
                     t_portB = m_b1.GetComponent<AB_PortPath>();

                     t_wireName = m_a1.name + m_b1.name;
                     t_wireR = 0.004f;
                     fnp_connect(t_portA, t_portB, t_wireName, t_wireR);

               }
               if (Input.GetKeyDown(KeyCode.V))
               {
                    AB_PortPath t_portA = m_c1.GetComponent<AB_PortPath>();
                    PortPathData t_pdA = t_portA.M_PortPath;
                    AB_Plane tcommon = S_Planes.Instance.fn_getPlane(t_pdA.m_CabinetName, t_pdA.m_pathname[0].m_path[0]);
                    Vector3[] tproject = tcommon.fn_project(new Vector3[1] { m_c1.position }, m_c1.name, 0.002f);
                    Vector3[] tpath = new Vector3[3] { m_c1.position, tproject[0], tproject[1] };
                    S_BirthPipeMesh.Instance.fn_BirthPipe(m_c1.name, tpath, 0.002f, mMat, m_meshAxis);
                    //
                    tproject = tcommon.fn_project(new Vector3[1] { m_c2.position }, m_c2.name, 0.004f);
                    tpath = new Vector3[3] { m_c2.position, tproject[0], tproject[1] };
                    S_BirthPipeMesh.Instance.fn_BirthPipe(m_c2.name, tpath, 0.004f, mMat, m_meshAxis);
                    //
                    tproject = tcommon.fn_project(new Vector3[1] { m_c3.position }, m_c3.name, 0.004f);
                    tpath = new Vector3[3] { m_c3.position, tproject[0], tproject[1] };
                    S_BirthPipeMesh.Instance.fn_BirthPipe(m_c3.name, tpath, 0.004f, mMat, m_meshAxis);
               }
               if (Input.GetKeyDown(KeyCode.B))
               {
                    AB_PortPath t_portA = m_one1.GetComponent<AB_PortPath>();
                    PortPathData t_pdA = t_portA.M_PortPath;
                    AB_Plane tcommon = S_Planes.Instance.fn_getPlane(t_pdA.m_CabinetName, t_pdA.m_pathname[0].m_path[0]);

                    Vector3[] tproject = tcommon.fn_project(new Vector3[1] { m_one1.position }, m_one1.name, 0.002f);
                    Vector3[] tpath = new Vector3[2] { m_one1.position, tproject[0] };
                    S_BirthPipeMesh.Instance.fn_BirthPipe(m_one1.name, tpath, 0.002f, mMat, m_meshAxis);

                    tproject = tcommon.fn_project(new Vector3[1] { m_one2.position }, m_one2.name, 0.002f);
                     tpath = new Vector3[2] { m_one2.position, tproject[0] };
                    S_BirthPipeMesh.Instance.fn_BirthPipe(m_one2.name, tpath, 0.002f, mMat, m_meshAxis);

                    tproject = tcommon.fn_project(new Vector3[1] { m_one3.position }, m_one3.name, 0.002f);
                    tpath = new Vector3[2] { m_one3.position, tproject[0] };
                    S_BirthPipeMesh.Instance.fn_BirthPipe(m_one3.name, tpath, 0.002f, mMat, m_meshAxis);
               }

               if (Input.GetKeyDown(KeyCode.N))
               {
                    AB_PortPath t_portA = mSelect1.GetComponent<AB_PortPath>();
                    AB_PortPath t_portB = mSelect2.GetComponent<AB_PortPath>();
                    string t_wireName=mSelect1.name+mSelect2.name;
                    float t_wireR=0.002f;
                   
                    fnp_connect(t_portA, t_portB, t_wireName, t_wireR);
                     t_portA = mSelect3.GetComponent<AB_PortPath>();
                     t_portB = mSelect4.GetComponent<AB_PortPath>();
                     t_wireName = mSelect3.name + mSelect4.name;
                     t_wireR = 0.004f;
                     fnp_connect(t_portA, t_portB, t_wireName, t_wireR);
               }
          }

          private void fnp_connect(AB_PortPath t_portA, AB_PortPath t_portB, string t_wireName, float t_wireR)
          {
               int t_portA_id = -1, t_portB_id = -1;
               //先确定接口间路径是否通
               if (s_PathFinder.fns_findPath(t_portA, t_portB, out t_portA_id, out t_portB_id))
               {
                    Vector3[] t_pathDot;
                    t_pathDot = s_PathVertexFinder.fns_pathVertex(t_portA, t_portA_id, t_portB, t_portB_id, t_wireName, t_wireR);
                    //生成模型
                    S_BirthPipeMesh.Instance.fn_BirthPipe(t_wireName, t_pathDot, t_wireR, mMat, m_meshAxis);
               }
          }
     }
}
