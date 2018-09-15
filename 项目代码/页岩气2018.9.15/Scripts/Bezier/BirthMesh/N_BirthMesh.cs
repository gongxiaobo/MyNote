using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GasPowerGeneration;
/// <summary>
/// 生成管道模型的
/// </summary>
public class N_BirthMesh : AB_BirthMesh
{


     public override void fn_init()
     {
          if (m_meshobj==null)
          {
               fn_CreatMeshObj();
          }
          else
          {
               MeshCollider t_mc = m_meshobj.GetComponent<MeshCollider>();
               if (t_mc != null)
               {
                    DestroyImmediate(t_mc);
               }
          }
          m_meshobj.transform.position = Vector3.zero;
          if (m_caculatePointHard==null)
          {
               m_caculatePointHard = new N_CaculatePointHard();
          }
          fnp_findChildPoint();
         
         
     }
     /// <summary>
     /// 找到子节点下的点，如果有的话
     /// </summary>
     protected virtual void fnp_findChildPoint()
     {
          m_Points = null;
          m_Points = GetComponentsInChildren<Transform>();
     }
     AB_CaculatePointHard m_caculatePointHard = null;
     //找到关键点
     public Transform[] m_Points =null;
     //关键点的位置
     protected Vector3[] m_lastPointPos;
     //转角时用几个管道半径
     public float m_bevel = 2f;
     //路径数据，添加了转角处的点
     OrientedPoint[] m_orientedPoint;
     /// <summary>
     /// 是否找到关键点,如果没有找到，那就不能生成模型,没有找到为false
     /// </summary>
     protected bool m_FindKeyPoint = true;
     
     protected override void fn_birhtPath()
     {
          //把关键点记录下来
          fnp_findKeyPoint();
          if (m_lastPointPos==null)
          {
               m_FindKeyPoint = false;
               return;
          }
          if (m_lastPointPos.Length==0)
          {
               m_FindKeyPoint = false;
               return;
          }
          //关键点数量
          int t_keyNum = m_lastPointPos.Length;
          Vector3[] t_addPoints = new Vector3[t_keyNum]; 
          if (m_AddMorKeyPoits)
          {
               

               List<Vector3> t_newPoints = new List<Vector3>();
               //根据关键点生成辅助点
               int t_morecount = t_keyNum + (t_keyNum - 2) * 4;
               //int t_morecount = m_Points.Length ;
               //加入转角后的点
                t_addPoints = new Vector3[t_morecount];

               Vector3[] t_points = new Vector3[t_keyNum];

               for (int i = 0; i < m_lastPointPos.Length; i++)
               {
                    t_points[i] = m_lastPointPos[i];

                    if (i == 0 || (i == m_lastPointPos.Length - 1))
                    {//首尾两点不添加点
                         t_newPoints.Add(t_points[i]);
                    }
                    else
                    {//添加点前后两个点

                         //找到转角的3个点
                         Vector3 t_one = S_BezierTool.fnp_VectorLerp(t_points[i - 1], t_points[i],
                              1f - m_bevel * m_wireR / Vector3.Distance(t_points[i - 1], t_points[i]));

                         Vector3 t_three = S_BezierTool.fnp_VectorLerp(t_points[i], m_lastPointPos[i + 1],
                              m_bevel * m_wireR / Vector3.Distance(t_points[i], m_lastPointPos[i + 1]));

                         Vector3 t_two_in = S_BezierTool.fnp_VectorLerp(t_one, t_three, 0.5f);
                         Vector3 t_two_out = t_points[i];
                         Vector3 t_two = S_BezierTool.fnp_VectorLerp(t_two_in, t_two_out, 0.5f);
                         //在三个点之间加入两个点
                         Vector3 t_one_two = S_BezierTool.fnp_VectorLerp(t_one, t_two, 0.5f);
                         Vector3 t_two_three = S_BezierTool.fnp_VectorLerp(t_two, t_three, 0.5f);
                         //Vector3 t_two = S_BezierTool.fnp_VectorLerp(t_one, t_three, 0.5f);
                         t_newPoints.Add(t_one);
                         t_newPoints.Add(t_one_two);
                         t_newPoints.Add(t_two);
                         t_newPoints.Add(t_two_three);
                         t_newPoints.Add(t_three);


                         //t_newPoints.Add(t_points[i]);
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
          }
          else
          {
               t_addPoints = m_lastPointPos;
          }

         
          Quaternion[] t_rotate = new Quaternion[t_addPoints.Length];
          //Vector3 t_axis = new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
          m_caculatePointHard.fn_caculate(t_addPoints, m_MeshUpDir, out t_rotate);

          m_orientedPoint = null;
          m_orientedPoint = new OrientedPoint[t_addPoints.Length];
          for (int i = 0; i < t_addPoints.Length; i++)
          {
               m_orientedPoint[i] = new OrientedPoint(t_addPoints[i], t_rotate[i]);
          }
     }
     /// <summary>
     /// 找到关键点
     /// </summary>
     protected virtual void fnp_findKeyPoint()
     {
          m_lastPointPos = new Vector3[m_Points.Length];
          for (int i = 0; i < m_Points.Length; i++)
          {
               m_lastPointPos[i] = m_Points[i].position;
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
          if (!m_FindKeyPoint)
          {//没有关键点
               return;
          }
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
          if (!m_FindKeyPoint)
          {//没有找到关键点
               return;
          }
          s_birthMesh.fn_Extrude(m_meshobj.GetComponent<MeshFilter>().sharedMesh,
                  m_extrudeShape, m_orientedPoint);
           MeshCollider t_mc=m_meshobj.AddComponent<MeshCollider>();
           t_mc.cookingOptions = MeshColliderCookingOptions.None;
     }
     Action m_callback = null;
     public override void fn_BirthMesh(Action _callback)
     {
          //fn_kill();
          if (m_caculatePointHard == null)
          {
               m_caculatePointHard = new N_CaculatePointHard();
          }
          fn_init();
          fn_birhtPath();
          fn_birthShape();
          fn_makeMesh();
          if (_callback != null && m_FindKeyPoint)
          {
               _callback();
               m_callback = _callback;
          }
     }
     protected GameObject m_meshobj = null;
     public override GameObject M_MeshObj
     {
          get { return m_meshobj; }
          set {  m_meshobj = value; }
     }
     /// <summary>
     /// 注意，这里的销毁会把生成的线销毁,这个功能只是在编辑模式下使用
     /// </summary>
     public override void fn_kill()
     {
#if UNITY_EDITOR
          if (m_meshobj != null)
          {
               DestroyImmediate(m_meshobj);
               m_meshobj = null;
          } 
#endif
         
     }
     protected bool m_refresh = false;
     public override void fn_refresh()
     {
          if (m_lastPointPos != null && m_refresh == false)
          {
               for (int i = 0; i < m_lastPointPos.Length; i++)
               {
                    fnp_needRefresh(i);
                    if (m_refresh)
                    {
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
     /// <summary>
     /// 查看关键点是否有变化
     /// </summary>
     /// <param name="i"></param>
     protected virtual void fnp_needRefresh(int i)
     {
          if (m_lastPointPos[i] != m_Points[i].transform.position)
          {
               m_refresh = true;
          }
     }

     public override float M_WireRadius
     {
          get
          {
               return m_wireR;
          }
          set
          {
               m_wireR=Mathf.Clamp01( value);
          }
     }
     /// <summary>
     /// 生成放入mesh的物体
     /// </summary>
     public override void fn_CreatMeshObj()
     {
          if (m_meshobj == null)
          {
               m_meshobj = new GameObject(this.gameObject.name);
               MeshFilter t_meshfilter = m_meshobj.AddComponent<MeshFilter>();
               Mesh t_mesh = new Mesh();
               t_meshfilter.mesh = t_mesh;
               m_meshobj.AddComponent<MeshRenderer>();
               m_meshobj.AddComponent<N_LightOneObj_04>();
          }
     }
}
