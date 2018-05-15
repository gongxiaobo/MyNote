using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLine : MonoBehaviour {
     LineRenderer m_thisLine = null;
	// Use this for initialization
	void Start () {
          
          //Debug.Log("<color=blue>blue:</color>");
     
          m_thisLine = GetComponent<LineRenderer>();
          Vector3 t_parent = gameObject.transform.parent.position;
          Vector3 t_end = new Vector3(t_parent.x, t_parent.y + 1.5f, t_parent.z);
          m_thisLine.positionCount = 2;
          m_thisLine.SetPosition(0, t_parent);
          m_thisLine.SetPosition(1, t_end);

          
	}
	
	
}
