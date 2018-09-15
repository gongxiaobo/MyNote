using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_qmv : MonoBehaviour {


     public Vector3 relativeDirection = Vector3.forward;
     void Update()
     {
          //Vector3 absoluteDirection = transform.rotation * relativeDirection;
          //transform.position += absoluteDirection * Time.deltaTime;

          //
          //transform.rotation *= m_extraRotation.rotation;
          fn_createRotate();
     }
     //public Transform m_extraRotation;
     public Transform m_a, m_b,m_c;
     public GameObject m_move;
     protected void fn_createRotate()
     {
          Quaternion t_rotateion=
               Quaternion.LookRotation(m_b.position - m_a.position, m_c.position - m_a.position);
          m_move.transform.rotation = t_rotateion;
     }
}
