using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_getNewDot : MonoBehaviour {
     public Transform m_movedot;
     public Transform m_vectorStart, m_vectorEnd;
	// Use this for initialization
	void Start () {
          //Vector3 t_dir = (m_vectorEnd.position - m_vectorStart.position).normalized;
          //Vector3 t_newdot = m_movedot.position + t_dir;
          //GameObject t_obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
          //t_obj.name = "newobj";
          //t_obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
          //t_obj.transform.position = t_newdot;
		
	}
     GameObject t_obj;
     protected Vector3 m_start, m_end;
	// Update is called once per frame
	void Update () {

          if (m_start!=m_vectorStart.position || m_end!=m_vectorEnd.position)
          {
               m_start = m_vectorStart.position;
               m_end = m_vectorEnd.position;
               if (t_obj!=null)
               {
                    Destroy(t_obj);
               }
               Vector3 t_dir = (m_vectorEnd.position - m_vectorStart.position).normalized;
               Vector3 t_newdot = m_movedot.position + t_dir;
               t_obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
               t_obj.name = "newobj";
               t_obj.transform.localScale = new Vector3(1f, 1f, 1f);
               t_obj.transform.position = t_newdot;
          }
	}
}
