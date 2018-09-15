using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosSet : MonoBehaviour {
     bool m_work = true;
     public Vector3 m_startPos = new Vector3(0f, -10f, 0f);
	// Use this for initialization
	void Start () {
          if (m_work)
          {
               this.gameObject.transform.position = m_startPos; 
          }
          Destroy(this);
	}
	
	
}
