using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_startMesh : MonoBehaviour {
     AB_BirthMesh m_birthMesh = null;
     public Material m_mat = null;
	// Use this for initialization
	void Start () {
          m_birthMesh = GetComponent<AB_BirthMesh>();
          if (m_birthMesh!=null)
          {
               m_birthMesh.fn_BirthMesh(fnp_callback);
          }
	}
     protected void fnp_callback()
     {
          m_birthMesh.M_MeshObj.GetComponent<MeshRenderer>().material=m_mat;
     }
	// Update is called once per frame
	void Update () {
          if (m_birthMesh!=null)
          {
               m_birthMesh.fn_refresh();
          }
	}
}
