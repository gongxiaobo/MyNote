using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 根据指定圆的参数，获取圆上的点集
/// 圆心在原点
/// </summary>
public class N_CirclePoint : AB_CirclePoint
{
     ///// <summary>
     ///// 开始画圆的开始点
     ///// </summary>
     //public Transform m_A = null;
     ///// <summary>
     ///// 结束点
     ///// </summary>
     //public Transform m_B = null;
     /////// <summary>
     /////// 圆心
     /////// </summary>

     Vector3 a=new Vector3(-1f,0f,0f);//单位向量a
     Vector3 b=new Vector3(0f,-1f,0f);//单位向量b

     //public Transform m_centre = null;
     private void fnp_findVector()
     {
          //m_A = transform.Find("m_A");
          //m_B = transform.Find("m_B");
          //Transform m_centre = this.gameObject.transform;
          //a = (m_A.position - m_centre.position).normalized;
          //b = (m_B.position - m_centre.position).normalized;
     }
     public override Vector3[] fn_getCirclePoints()
     {
          //fnp_findVector();
          Vector3[] t_out = new Vector3[(int)Divid + 1];

          float t_angle = fnp_dis2angle();
          int t_id = 0;
          Vector3 t_circleCentre = Vector3.zero;
          for (float i = 0; i < (2f * Mathf.PI); i = i + t_angle)
          {
               Vector3 circleXYZ = s_circle.fns_getPoint(t_circleCentre, a, b, m_circleR, i);
               t_out[t_id] = circleXYZ;
               t_id++;
#if UNITY_EDITOR
               //if (true)
               //{
               //     fnp_createcube(i, circleXYZ);
               //} 
#endif
          }
          return t_out;
     }
     private void fnp_createcube(float i, Vector3 _circleXYZ)
     {
          if (m_preObj == null)
          {
               m_preObj = new List<GameObject>();
          }
          else
          {
               for (int j = 0; j < m_preObj.Count; j++)
               {
                    Destroy(m_preObj[j]);
               }
               m_preObj = null;
               m_preObj = new List<GameObject>();
          }
          GameObject t_obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
          t_obj.name = i.ToString();
          t_obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
          t_obj.transform.position = _circleXYZ;
          m_preObj.Add(t_obj);
     }
     protected List<GameObject> m_preObj = null;

}
