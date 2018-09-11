using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBezier : MonoBehaviour
{
     public GameObject m_p1, m_p2, m_p3, m_p4;
     protected Vector3 m_p1Pos, m_p2Pos, m_p3Pos, m_p4Pos;
     public float m_scale = 1f;

     public List<GameObject> m_Points = new List<GameObject>();
     // Use this for initialization
     void Start()
     {
          MeshFilter t_meshfilter = gameObject.AddComponent<MeshFilter>();
          Mesh t_mesh = new Mesh();
          t_meshfilter.mesh = t_mesh;
          gameObject.AddComponent<MeshRenderer>();
          //fnp_birthCurveTwoPoint(m_p1.transform.position, m_p2.transform.position);
          //fnp_birthCurveThreePoint(m_p1.transform.position,
          //     m_p2.transform.position, m_p3.transform.position);
          //GameObject t_obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
          //t_obj.name = "xx";
          m_createPipe = gameObject.AddComponent<CreatePipe>();
          m_extrudeShape = new ExtrudeShape();
          m_extrudeShape.m_verts = new Vector3[5] { 
               new Vector3(0f, 0f, 0f), 
               new Vector3(0.5f*m_scale, 0.5f*m_scale, 0f), 
               new Vector3(0f, 1f*m_scale, 0f),
               new Vector3(-0.5f*m_scale, 0.5f*m_scale, 0f),
               new Vector3(0f, 0f, 0f)
               };
          m_extrudeShape.m_normals = new Vector3[5] { 
               new Vector3(0, 1, 0), 
               new Vector3(0, 1, 0), 
                new Vector3(0, 1, 0), 
                new Vector3(0, 1, 0), 
                new Vector3(0, 1, 0)
              };
          m_extrudeShape.m_us = new float[5] { 0f,0.2f,0.5f,0.8f,1f };
          m_extrudeShape.m_lines = new int[8] { 0, 1,1,2,2,3,3,4};

     }

     // Update is called once per frame
     void Update()
     {
          if (Input.GetKeyDown(KeyCode.R) ||
               m_p1.transform.position != m_p1Pos ||
               m_p2.transform.position != m_p2Pos ||
               m_p3.transform.position != m_p3Pos ||
               m_p4.transform.position != m_p4Pos)
          {
               Vector3[] t_v4 = new Vector3[4]{
                    m_p1.transform.position,
                    m_p2.transform.position,
                    m_p3.transform.position,
                    m_p4.transform.position};
               fnp_birthCurveThreePoint(t_v4);
               m_createPipe.fn_Extrude(gameObject.GetComponent<MeshFilter>().mesh,
                    m_extrudeShape, m_orientedPoint);
               MeshRenderer t_mr = gameObject.GetComponent<MeshRenderer>();
               t_mr.material = m_mat;
          }
     }
     public float m_segment = 2f;
     private void fnp_birthCurveTwoPoint(Vector3 _p1, Vector3 _p2)
     {
          for (int i = 0; i <= 10f; i++)
          {
               Vector3 t_now = fnp_BezierTwoPoint(_p1, _p2, i * 0.1f);
               GameObject t_obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
               t_obj.name = i.ToString();
               t_obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
               t_obj.transform.position = t_now;
          }
     }
     private Vector3 fnp_BezierTwoPoint(Vector3 _p1, Vector3 _p2, float _t)
     {
          _t = Mathf.Clamp01(_t);
          return _p1 + (_p2 - _p1) * _t;
     }

     protected List<GameObject> m_point = new List<GameObject>();
     private void fnp_birthCurveThreePoint(Vector3 _p1, Vector3 _p2, Vector3 _p3)
     {
          foreach (var obj in m_point)
          {
               Destroy(obj);
          }
          m_point.Clear();
          for (int i = 0; i <= 10f; i++)
          {
               Vector3 t_now = fnp_BezierThreePoint(_p1, _p2, _p3, i * 0.1f);
               GameObject t_obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
               t_obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
               t_obj.name = i.ToString();
               t_obj.transform.position = t_now;
               m_point.Add(t_obj);
          }
          m_p1Pos = _p1;
          m_p2Pos = _p2;
          m_p3Pos = _p3;
     }
     private Vector3 fnp_BezierThreePoint(Vector3 _p1, Vector3 _p2, Vector3 _p3, float _t)
     {
          _t = Mathf.Clamp01(_t);
          return (1 - _t) * (1 - _t) * _p1 + 2 * _t * (1 - _t) * _p2 + _t * _t * _p3;
     }

     private void fnp_birthCurveThreePoint(Vector3[] _v4)
     {
          //foreach (var obj in m_point)
          //{
          //     Destroy(obj);
          //}
          //m_point.Clear();
          m_orientedPoint = new OrientedPoint[10 * (int)m_segment];
          AB_BezierPoint t_bezier = new N_BezierPoint();
          
          for (int i = 0; i < 10f * m_segment; i++)
          {
              
               //Vector3 t_now = t_bezier.fn_getPoint(_v4, i * (1f / (10f * m_segment)));
               //Quaternion t_rotate = fn_getOrientation3D(_v4, i * (1f / (10f * m_segment)), Vector3.down);
               Vector3 t_now,t_normal;
               Quaternion t_rotate;
               t_bezier.fn_getBezierPoint(_v4, i * (1f / (10f * m_segment)), Vector3.down,out t_now,out t_normal,out t_rotate);

               m_orientedPoint[i] = new OrientedPoint(t_now, t_rotate);
          }
          m_p1Pos = _v4[0];
          m_p2Pos = _v4[1];
          m_p3Pos = _v4[2];
          m_p4Pos = _v4[3];
     }
     //获取bezier上的点
     private Vector3 fnp_getPoint(Vector3[] _pts, float _t)
     {
          _t = Mathf.Clamp01(_t);
          float _omt = 1f - _t;
          float _omt2 = _omt * _omt;
          float _t2 = _t * _t;
          return _pts[0] * (_omt2 * _omt) +
               _pts[1] * (3f * _omt2 * _t) +
               _pts[2] * (3f * _omt * _t2) +
               _pts[3] * (_t2 * _t);
     }
     //获取bezier点的切线
     Vector3 fn_getTangent(Vector3[] _pts, float _t)
     {
          _t = Mathf.Clamp01(_t);
          float _omt = 1f - _t;
          float _omt2 = _omt * _omt;
          float _t2 = _t * _t;

          Vector3 t_tangent = 
               _pts[0] * (-_omt2) +
               _pts[1] * (3f * _omt2 -2*_omt) +
               _pts[2] * (-3f * _t2 +2f*_t) +
               _pts[3] * (_t2);
          return t_tangent.normalized;
     }
     //找到法线
     Vector3 fn_getNormal3D(Vector3[] _pts, float _t, Vector3 _up)
     {
          Vector3 t_tangent = fn_getTangent(_pts, _t);
          Vector3 t_binormal = Vector3.Cross(_up, t_tangent).normalized;
          return Vector3.Cross(t_tangent, t_binormal);
     }
     //找到旋转
     Quaternion fn_getOrientation3D(Vector3[] _pts, float _t, Vector3 _up)
     {
          Vector3 t_tng = fn_getTangent(_pts, _t);
          Vector3 t_nrm = fn_getNormal3D(_pts, _t, _up);
          return Quaternion.LookRotation(t_tng, t_nrm);
     }
     OrientedPoint[] m_orientedPoint;
     ExtrudeShape m_extrudeShape;
     CreatePipe m_createPipe;
     public Material m_mat;
}
