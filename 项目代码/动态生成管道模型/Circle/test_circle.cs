using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_circle : MonoBehaviour {

     
     /// <summary>
     /// 开始画圆的开始点
     /// </summary>
     public Transform m_A = null;
     /// <summary>
     /// 结束点
     /// </summary>
     public Transform m_B = null;
     ///// <summary>
     ///// 圆心
     ///// </summary>
    
     Vector3 a;//单位向量a
     Vector3 b;//单位向量b
     public float m_circleR = 1f;//圆半径
	// Use this for initialization
	void Start () {

        //Vector3[] t_vertics=  fnp_caculateCircle();

        //Debug.Log("<color=blue>t_vertics:</color>" + t_vertics.Length);
     
	}

     private void fnp_findVector()
     {
          m_A = transform.Find("m_A");
          m_B = transform.Find("m_B");
          m_centre = this.gameObject.transform;
          a = (m_A.position - m_centre.position).normalized;
          b = (m_B.position - m_centre.position).normalized;
     }
	
	// Update is called once per frame
     //void Update () {
		
     //}
     public Transform m_centre = null;
     public Vector3[] fnp_caculateCircle()
     {
          fnp_findVector();
          List<Vector3> t_vectors = new List<Vector3>();
          Vector3[] t_out = new Vector3[(int)m_divid + 1];
         
          float t_angle = fnp_dis2angle();
          //Vector3 t_circleCentre = m_centre.position;
          Vector3 t_circleCentre = Vector3.zero;
          for (float i = 0; i < (2f * Mathf.PI); i =i+ t_angle)
          {
               Vector3 circleXYZ;
               circleXYZ.x = t_circleCentre.x + m_circleR * Mathf.Cos(i) * a.x +
                   m_circleR * Mathf.Sin(i) * b.x;
               circleXYZ.y = t_circleCentre.y + m_circleR * Mathf.Cos(i) * a.y +
                    m_circleR * Mathf.Sin(i) * b.y;
               circleXYZ.z = t_circleCentre.z + m_circleR * Mathf.Cos(i) * a.z +
                    m_circleR * Mathf.Sin(i) * b.z;
               //fnp_createcube(i, circleXYZ);
               t_vectors.Add( circleXYZ);

               //Debug.Log("<color=blue>circleXYZ:</color>" + circleXYZ);
     
          }
          t_vectors.CopyTo(t_out);
          return t_out;
     }

     private void fnp_createcube(float i,Vector3 _circleXYZ)
     {
          GameObject t_obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
          t_obj.name = i.ToString();
          t_obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
          t_obj.transform.position = _circleXYZ;
     }
     public float m_divid = 4f;
     float fnp_dis2angle()
     {

          //float t_c = 2f * Mathf.PI * m_circleR;//圆周长
          //float t_splitNum = t_c / m_divid;

          return (Mathf.PI * 2f) / m_divid;
     }
}
