using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Assets.Scripts.Connection.PointOnPlane;
namespace Assets.Scripts.Connection.Port
{
     /// <summary>
     /// 根据路径，找到路径上的关键点，得到一系列有顺序的路径点，为生成管道模型作准备
     /// </summary>
     public static class s_PathVertexFinder
     {
          public static Vector3[] fns_pathVertex(AB_PortPath _port1, int _port1ID, AB_PortPath _port2, int _port2ID, string _wireName, float _wireR = 0.002f)
          {
               PortPathData t_pdA = _port1.M_PortPath;
               PortPathData t_pdB = _port2.M_PortPath;
               //_port1的路径平面
               List<E_PlaneName> m_path1 = t_pdA.m_pathname[_port1ID].m_path;

               List<Vector3> tPath1Vertex = new List<Vector3>();
               tPath1Vertex.Add(_port1.M_PortPos.position);
               AB_Plane t_lastPlane1 = null;
               Vector3 t_lastVertex1 = tPath1Vertex[0];
               //找到在每个平面上的投影点
               for (int i = 0; i < m_path1 .Count; i++)
               {
                    //找到平面
                    AB_Plane tcommon = S_Planes.Instance.fn_getPlane(t_pdA.m_CabinetName, m_path1[i]);
                    t_lastPlane1 = tcommon;
                    if (i==m_path1.Count-1)
                    {
                         if (t_lastPlane1.m_PlaneStyle== E_PlaneStyle.e_2IN2OUT)
                         {
                              break;
                         }
                    }
                    //点投影到平面
                    Vector3[] tproject = tcommon.fn_project(new Vector3[] { t_lastVertex1 }, _wireName, _wireR);
                    if (tproject.Length==1)
                    {
                         tPath1Vertex.Add(tproject[0]);
                         t_lastVertex1 = tproject[0];
                    }
                    else if (tproject.Length==2)
                    {
                         tPath1Vertex.Add(tproject[0]);
                         tPath1Vertex.Add(tproject[1]);
                         t_lastVertex1 = tproject[1];
                    }
                    
               }

               //_port2的路径平面
               List<E_PlaneName> m_path2 = t_pdB.m_pathname[_port2ID].m_path;
               List<Vector3> tPath2Vertex = new List<Vector3>();
               tPath2Vertex.Add(_port2.M_PortPos.position);
               AB_Plane t_lastPlane2 = null;
               Vector3 t_lastVertex2 = tPath2Vertex[0];
               //找到在每个平面上的投影点
               for (int i = 0; i < m_path2.Count; i++)
               {
                    //找到平面
                    AB_Plane tcommon = S_Planes.Instance.fn_getPlane(t_pdB.m_CabinetName, m_path2[i]);
                    t_lastPlane2 = tcommon;
                    if (i== m_path2.Count-1)
                    {//如果是最后一个平面
                         if (t_lastPlane2.m_PlaneStyle== E_PlaneStyle.e_2IN2OUT)
                         {
                              break;
                         }
                    }
                    //点投影到平面
                    Vector3[] tproject = tcommon.fn_project(new Vector3[] { t_lastVertex2 }, _wireName, _wireR);
                    if (tproject.Length == 1)
                    {
                         tPath2Vertex.Add(tproject[0]);
                         t_lastVertex2 = tproject[0];
                    }
                    else if (tproject.Length == 2)
                    {
                         tPath2Vertex.Add(tproject[0]);
                         tPath2Vertex.Add(tproject[1]);
                         t_lastVertex2 = tproject[1];
                    }
                    
               }

               //两段路径都找到投影点，需要把两段路径点链接起来

               //判断最后一个平面是哪种平面
               if (t_lastPlane1.m_PlaneStyle== E_PlaneStyle.e_2IN2OUT)
               {//如果是这个需要再次排序的平面，需要再次在平面排序
                    //点投影到平面
                    Vector3[] tproject = t_lastPlane1.fn_project(new Vector3[2] { t_lastVertex1, t_lastVertex2 }, _wireName, _wireR);
                    if (tproject.Length == 1)
                    {
                         tPath1Vertex.Add(tproject[0]);
                    }
                    else if (tproject.Length == 2)
                    {
                         tPath1Vertex.Add(tproject[0]);
                         tPath1Vertex.Add(tproject[1]);
                    }
                    //链接两条路径
                    for (int j = (tPath2Vertex.Count-1); j>=0; j--)
                    {
                         tPath1Vertex.Add(tPath2Vertex[j]);
                    }

               }
               else
               {//普遍的平面类型，判断一下两点的距离，如果太近就忽略一个点
                    if (Vector3.Distance(t_lastVertex1, t_lastVertex2)<=_wireR*10f)
                    {
                         Vector3 t_center = Vector3.Lerp(t_lastVertex1, t_lastVertex2, 0.5f);
                         tPath1Vertex[tPath1Vertex.Count - 1] = t_center;
                         //tPath2Vertex.RemoveAt(tPath1Vertex.Count - 1);
                         //链接两条路径
                         for (int j = (tPath2Vertex.Count - 2); j >= 0; j--)
                         {
                              tPath1Vertex.Add(tPath2Vertex[j]);
                         }
                    }
                    else
                    {
                         //链接两条路径
                         for (int j = (tPath2Vertex.Count - 1); j >= 0; j--)
                         {
                              tPath1Vertex.Add(tPath2Vertex[j]);
                         }
                    }
                    
               }

              
               return tPath1Vertex.ToArray();
          }





     }
}
