using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 生成管道模型的
/// </summary>
public class N_BirthMesh : AB_BirthMesh
{


     public override void fn_init()
     {
          if (m_meshobj==null)
          {
               m_meshobj = new GameObject("wire");
               MeshFilter t_meshfilter = m_meshobj.AddComponent<MeshFilter>();
               Mesh t_mesh = new Mesh();
               t_meshfilter.mesh = t_mesh;
               m_meshobj.AddComponent<MeshRenderer>();
          }
          else
          {
               MeshCollider t_mc = m_meshobj.GetComponent<MeshCollider>();
               if (t_mc != null)
               {
                    Destroy(t_mc);
               }
          }
          m_meshobj.transform.position = Vector3.zero;
          if (m_caculatePointHard==null)
          {
               m_caculatePointHard = new N_CaculatePointHard();
          }
          m_Points = GetComponentsInChildren<Transform>();
         
         
     }
     AB_CaculatePointHard m_caculatePointHard = null;
     //找到关键点
     public Transform[] m_Points =null;
     //关键点的上一次位置
     protected Vector3[] m_lastPointPos;
     //转角时用几个管道半径
     public float m_bevel = 2f;
     //路径数据
     OrientedPoint[] m_orientedPoint;
     protected override void fn_birhtPath()
     {
          List<Vector3> t_newPoints = new List<Vector3>();
          //根据关键点生成辅助点
          int t_morecount = m_Points.Length + (m_Points.Length - 2) * 4;
          //加入转角后的点
          Vector3[] t_addPoints = new Vector3[t_morecount];

          Vector3[] t_points = new Vector3[m_Points.Length];
          m_lastPointPos = new Vector3[m_Points.Length];
          for (int i = 0; i < m_Points.Length; i++)
          {
               t_points[i] = m_Points[i].position;
               m_lastPointPos[i] = m_Points[i].position;
               if (i == 0 || (i == m_Points.Length - 1))
               {//首尾两点不添加点
                    t_newPoints.Add(t_points[i]);
               }
               else
               {//添加点前后两个点

                    //找到转角的3个点
                    Vector3 t_one = S_BezierTool.fnp_VectorLerp(t_points[i - 1], t_points[i], 
                         1f - m_bevel * m_wireR / Vector3.Distance(t_points[i - 1], t_points[i]));

                    Vector3 t_three = S_BezierTool.fnp_VectorLerp(t_points[i], m_Points[i + 1].transform.position,
                         m_bevel * m_wireR / Vector3.Distance(t_points[i], m_Points[i + 1].transform.position));

                    Vector3 t_two_in = S_BezierTool.fnp_VectorLerp(t_one, t_three, 0.5f);
                    Vector3 t_two_out = t_points[i];
                    Vector3 t_two = S_BezierTool.fnp_VectorLerp(t_two_in, t_two_out, 0.3f);
                    //在三个点之间加入两个点
                    Vector3 t_one_two = S_BezierTool.fnp_VectorLerp(t_one, t_two, 0.5f);
                    Vector3 t_two_three = S_BezierTool.fnp_VectorLerp(t_two, t_three, 0.5f);

                    t_newPoints.Add(t_one);
                    t_newPoints.Add(t_one_two);
                    t_newPoints.Add(t_two);
                    t_newPoints.Add(t_two_three);
                    t_newPoints.Add(t_three);
               }

          }

          if (t_newPoints.Count == t_points.Length)
          {//两个点的情况
               t_addPoints = t_points;
          }
          else
          {//给首尾点之间的所有点前后添加两个新点
               t_newPoints.CopyTo(t_addPoints);
          }

         
          Quaternion[] t_rotate = new Quaternion[t_addPoints.Length];
          m_caculatePointHard.fn_caculate(t_addPoints, new Vector3(0, 1, 0), out t_rotate);

          m_orientedPoint = null;
          m_orientedPoint = new OrientedPoint[t_addPoints.Length];
          for (int i = 0; i < t_addPoints.Length; i++)
          {
               m_orientedPoint[i] = new OrientedPoint(t_addPoints[i], t_rotate[i]);
          }
     }

     //切面数据
     ExtrudeShape m_extrudeShape=null;
     //基础形状圆的切分
     public int m_segment=6;
     //圆的半径
     public float m_wireR = 0.004f;
     protected override void fn_birthShape()
     {
          if (m_extrudeShape==null)
          {
               m_extrudeShape = new ExtrudeShape();
          }
          else
          {
               m_extrudeShape.fn_clear();
          }

          AB_CirclePoint t_circle = gameObject.GetComponent<N_CirclePoint>();
          if (t_circle==null)
          {
               t_circle = gameObject.AddComponent<N_CirclePoint>();
          }
          t_circle.Divid = (float)m_segment;
          t_circle.m_circleR = m_wireR;
          Vector3[] t_vectors = t_circle.fn_getCirclePoints();
          

          m_extrudeShape.m_verts = new Vector3[t_vectors.Length];
          m_extrudeShape.m_verts = t_vectors;
          m_extrudeShape.m_normals = new Vector3[t_vectors.Length];
          m_extrudeShape.m_us = new float[t_vectors.Length];
          float t_offset = (1f / (t_vectors.Length - 1));
          for (int i = 0; i < t_vectors.Length; i++)
          {
               //m_extrudeShape.m_normals[i] = new Vector3(0, 1, 0);
               //法线
               m_extrudeShape.m_normals[i] = (t_vectors[i] - Vector3.zero).normalized;
               //uv
               m_extrudeShape.m_us[i] = i * t_offset;
          }
          //for (int i = 0; i < t_vectors.Length; i++)
          //{

          //}
          m_extrudeShape.m_lines = new int[(t_vectors.Length - 1) * 2];
          for (int i = 0; i < ((t_vectors.Length - 1)); i++)
          {
               //m_extrudeShape.m_lines[i] = i;
               //m_extrudeShape.m_lines[i + 1] = i + 1;
               m_extrudeShape.m_lines[i * 2] = i;
               m_extrudeShape.m_lines[i * 2 + 1] = i + 1;

          }
     }

     protected override void fn_makeMesh()
     {
          s_birthMesh.fn_Extrude(m_meshobj.GetComponent<MeshFilter>().mesh,
                  m_extrudeShape, m_orientedPoint);
     }
     Action m_callback = null;
     public override void fn_BirthMesh(Action _callback)
     {
          fn_kill();
          fn_init();
          fn_birhtPath();
          fn_birthShape();
          fn_makeMesh();
          if (_callback!=null)
          {
               _callback();
               m_callback = _callback;
          }
     }
     protected GameObject m_meshobj = null;
     public override GameObject M_MeshObj
     {
          get { return m_meshobj; }
     }

     public override void fn_kill()
     {
          if (m_meshobj!=null)
          {
               Destroy(m_meshobj);
               m_meshobj = null;
          }
         
     }
     protected bool m_refresh = false;
     public override void fn_refresh()
     {
          if (m_lastPointPos != null && m_refresh == false)
          {
               for (int i = 0; i < m_lastPointPos.Length; i++)
               {
                    if (m_lastPointPos[i] != m_Points[i].transform.position)
                    {
                         m_refresh = true;
                         break;
                    }
                   
               }
          }
          if (m_refresh)
          {//有关键位置被移动，需要刷新

               fn_BirthMesh(m_callback);
               m_refresh = false;
          }
     }
}
