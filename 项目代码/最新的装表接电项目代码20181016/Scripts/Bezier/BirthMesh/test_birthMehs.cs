using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_birthMehs : MonoBehaviour {
     public float m_scale = 1f;
     public float m_sub = 10f;
     public List<GameObject> m_Points = new List<GameObject>();
     OrientedPoint[] m_orientedPoint;
     ExtrudeShape m_extrudeShape;
     CreatePipe m_createPipe;
     public Material m_mat;
     protected GameObject m_MeshObj = null;
	// Use this for initialization
	void Start () {
          m_MeshObj = new GameObject("wire");
          m_MeshObj.transform.position = Vector3.zero;
          MeshFilter t_meshfilter = m_MeshObj.AddComponent<MeshFilter>();
          Mesh t_mesh = new Mesh();
          t_meshfilter.mesh = t_mesh;
          m_MeshObj.AddComponent<MeshRenderer>();

          m_createPipe = gameObject.AddComponent<CreatePipe>();
          //fn_extrudeshape1();
          fnp_extrudeshape2();
          m_bezier = new N_BezierPoint();
          m_caculatePointHard = new N_CaculatePointHard();

          //
          //fnp_CaculateMeshPoint();
          fnp_CaculateHardMeshPoint();
	}

     private void fn_extrudeshape1()
     {
          m_extrudeShape = new ExtrudeShape();
          //m_extrudeShape.m_verts = new Vector3[5] { 
          //     new Vector3(0f, 0f, 0f), 
          //     new Vector3(0.5f*m_scale, 0.5f*m_scale, 0f), 
          //     new Vector3(0f, 1f*m_scale, 0f),
          //     new Vector3(-0.5f*m_scale, 0.5f*m_scale, 0f),
          //     new Vector3(0f, 0f, 0f)
          //     };
          Vector3 t_thisObj = m_MeshObj.transform.position;
          //m_extrudeShape.m_verts = new Vector3[5] { 
          //     t_thisObj, 
          //     new Vector3(t_thisObj.x-0.5f*m_scale,t_thisObj.y- 0.5f*m_scale, t_thisObj.z), 
          //     new Vector3(t_thisObj.x,t_thisObj.y- 1f*m_scale, t_thisObj.z),
          //     new Vector3(t_thisObj.x-(-0.5f*m_scale),t_thisObj.y- 0.5f*m_scale, t_thisObj.z),
          //     t_thisObj
          //     };
          m_extrudeShape.m_verts = new Vector3[5] { 
               new Vector3(t_thisObj.x,t_thisObj.y+ 0.5f*m_scale, t_thisObj.z), 
               new Vector3(t_thisObj.x-(0.5f*m_scale),t_thisObj.y, t_thisObj.z), 
               new Vector3(t_thisObj.x,t_thisObj.y- 0.5f*m_scale, t_thisObj.z),
               new Vector3(t_thisObj.x+(0.5f*m_scale),t_thisObj.y, t_thisObj.z),
               new Vector3(t_thisObj.x,t_thisObj.y+ 0.5f*m_scale, t_thisObj.z)
               };
          m_extrudeShape.m_normals = new Vector3[5] { 
               new Vector3(0, 1, 0), 
               new Vector3(0, 1, 0), 
                new Vector3(0, 1, 0), 
                new Vector3(0, 1, 0), 
                new Vector3(0, 1, 0)
              };
          m_extrudeShape.m_us = new float[5] { 0f, 0.2f, 0.5f, 0.8f, 1f };
          m_extrudeShape.m_lines = new int[8] { 0, 1, 1, 2, 2, 3, 3, 4 };
     }
     public float m_wireR = 0.005f;
     public int m_segment = 6;
     protected void fnp_extrudeshape2()
     {
          m_extrudeShape = new ExtrudeShape();

          AB_CirclePoint t_circle = gameObject.AddComponent<N_CirclePoint>();
          t_circle.Divid = (float)m_segment;
          t_circle.m_circleR = m_wireR;
          Vector3[] t_vectors = t_circle.fn_getCirclePoints();
          Destroy(t_circle);

          m_extrudeShape.m_verts =new Vector3[ t_vectors.Length];
          m_extrudeShape.m_verts = t_vectors;
          m_extrudeShape.m_normals = new Vector3[t_vectors.Length];
          m_extrudeShape.m_us = new float[t_vectors.Length];
          float t_offset=(1f / (t_vectors.Length-1));
          for (int i = 0; i < t_vectors.Length; i++)
          {
               //m_extrudeShape.m_normals[i] = new Vector3(0, 1, 0);
               //法线
               m_extrudeShape.m_normals[i] = (t_vectors[i]-Vector3.zero).normalized;
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
               m_extrudeShape.m_lines[i * 2+1] = i+1;

          }
          //for (int i = 0; i < m_extrudeShape.m_lines.Length; i++)
          //{

          //     Debug.Log("<color=red>red:</color>" + i.ToString() + ":" + m_extrudeShape.m_lines[i]);
     
          //}
          //for (int i = 0; i <((t_vectors.Length-1)*2) ; i++)
          //{
          //     if (i==0)
          //     {
          //          m_extrudeShape.m_lines[i] = 0;
          //     }
          //     if (i==((t_vectors.Length-1)*2-1))
          //     {
          //          break;
          //     }

          //}
          //m_extrudeShape.m_lines = new int[(t_vectors.Length-1)*2] { 0, 1, 1, 2, 2, 3, 3, 4 };
     }
     //转角时用几个管道半径
     public float m_bevel = 4f;
     AB_BezierPoint m_bezier = null;
     protected Vector3[] m_lastPointPos ;
     protected void fnp_CaculateMeshPoint()
     {

          if (m_Points==null)
          {
               return;
          }
          if (m_Points.Count<2)
          {
               return;
          }
          MeshCollider t_mc = m_MeshObj.GetComponent<MeshCollider>();
          if (t_mc != null)
          {
               Destroy(t_mc);
          }

          Vector3[] t_points = new Vector3[m_Points.Count];
          m_lastPointPos = new Vector3[m_Points.Count];
          for (int i = 0; i < m_Points.Count; i++)
          {
               t_points[i] = m_Points[i].transform.position;
               m_lastPointPos[i] = m_Points[i].transform.position;
          }

          m_orientedPoint = new OrientedPoint[(int)m_sub];
         

          for (int i = 0; i < m_sub; i++)
          {
               Vector3 t_now, t_normal;
               Quaternion t_rotate;
               m_bezier.fn_getBezierPoint(t_points, i * (1f / (m_sub)), Vector3.down, out t_now, out t_normal, out t_rotate);

               m_orientedPoint[i] = new OrientedPoint(t_now, t_rotate);
          }

          //生成模型
          m_createPipe.fn_Extrude(m_MeshObj.GetComponent<MeshFilter>().mesh,
                   m_extrudeShape, m_orientedPoint);
          MeshRenderer t_mr = m_MeshObj.GetComponent<MeshRenderer>();
          t_mr.material = m_mat;
          m_MeshObj.AddComponent<MeshCollider>();

     }
     AB_CaculatePointHard m_caculatePointHard = null;
     protected void fnp_CaculateHardMeshPoint()
     {
          if (m_Points == null)
          {
               return;
          }
          if (m_Points.Count < 2)
          {
               return;
          }
          MeshCollider t_mc = m_MeshObj.GetComponent<MeshCollider>();
          if (t_mc != null)
          {
               Destroy(t_mc);
          }
          List<Vector3> t_newPoints = new List<Vector3>();
          //根据关键点生成辅助点
          int t_morecount = m_Points.Count + (m_Points.Count - 2)*4;
          Vector3[] t_addPoints = new Vector3[t_morecount];

          Vector3[] t_points = new Vector3[m_Points.Count];
          m_lastPointPos = new Vector3[m_Points.Count];
          for (int i = 0; i < m_Points.Count; i++)
          {
               t_points[i] = m_Points[i].transform.position;
               m_lastPointPos[i] = m_Points[i].transform.position;
               if (i==0|| (i==m_Points.Count-1))
               {//首尾两点不添加点
                    t_newPoints.Add(t_points[i]);
               }
               else
               {//添加点前后两个点
                   
                    //第一个点
                    //Vector3 t_one = S_BezierTool.fnp_VectorLerp(t_points[i - 1], t_points[i], 0.95f);
                    Vector3 t_one = S_BezierTool.fnp_VectorLerp(t_points[i - 1], t_points[i], 1f - m_bevel * m_wireR / Vector3.Distance(t_points[i - 1], t_points[i]));
                    //Vector3 t_three = S_BezierTool.fnp_VectorLerp(t_points[i], m_Points[i + 1].transform.position, 1 - 0.95f);
                    Vector3 t_three = S_BezierTool.fnp_VectorLerp(t_points[i], m_Points[i + 1].transform.position, m_bevel * m_wireR / Vector3.Distance(t_points[i], m_Points[i + 1].transform.position));
                    Vector3 t_two_in = S_BezierTool.fnp_VectorLerp(t_one, t_three, 0.5f);
                    Vector3 t_two_out = t_points[i];
                    Vector3 t_two = S_BezierTool.fnp_VectorLerp(t_two_in, t_two_out, 0.3f);
                    //
                    Vector3 t_one_two = S_BezierTool.fnp_VectorLerp(t_one, t_two, 0.5f);
                    Vector3 t_two_three = S_BezierTool.fnp_VectorLerp(t_two, t_three, 0.5f);

                    //t_one = S_BezierTool.fnp_VectorLerp(t_points[i - 1], t_one_two, 0.95f);
                    //t_three = S_BezierTool.fnp_VectorLerp(t_two_three, m_Points[i + 1].transform.position, 1 - 0.95f);

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

     
          m_orientedPoint = new OrientedPoint[t_addPoints.Length];
          Quaternion[] t_rotate = new Quaternion[t_addPoints.Length];
          m_caculatePointHard.fn_caculate(t_addPoints, new Vector3(0, 1, 0), out t_rotate);


          for (int i = 0; i < t_addPoints.Length ; i++)
          {
               m_orientedPoint[i] = new OrientedPoint(t_addPoints[i], t_rotate[i]);
          }

          //生成模型
          //m_createPipe.fn_Extrude(m_MeshObj.GetComponent<MeshFilter>().mesh,
          //         m_extrudeShape, m_orientedPoint);
          s_birthMesh.fn_Extrude(m_MeshObj.GetComponent<MeshFilter>().mesh,
                   m_extrudeShape, m_orientedPoint);
          MeshRenderer t_mr = m_MeshObj.GetComponent<MeshRenderer>();
          t_mr.material = m_mat;
          m_MeshObj.AddComponent<MeshCollider>();

          m_orientedPoint = null;

     }
     //protected Vector3 fnp_VectorLerp(Vector3 _p0, Vector3 _p1, float _t)
     //{
     //     return (1f - _t) * _p0 + _t * _p1;
     //}
     bool m_refresh = false;
	// Update is called once per frame
	void Update () {
          if (m_lastPointPos != null && m_refresh == false)
          {
               for (int i = 0; i < m_lastPointPos.Length; i++)
               {
                    if (m_lastPointPos[i] != m_Points[i].transform.position)
                    {
                         m_refresh = true;
                         break;
                    }
                    //t_points[i] = m_Points[i].transform.position;
                    //;
               }
          }
          if (m_refresh)
          {
               //fnp_CaculateMeshPoint();
               fnp_CaculateHardMeshPoint();
               m_refresh = false;
          }
		
	}
}
