using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testStructcall : MonoBehaviour {

	// Use this for initialization
	void Start () {
          //fnp_latercall();
          Invoke("fnp_latercall", 2f);
	}

     private void fnp_latercall()
     {
          testVar t_testvar = GetComponent<testVar>();
          var t_ = t_testvar.M_testStruct;
          t_.m_struct = "sdfsfs";
          t_testvar.M_testStruct = t_;
          Debug.Log("<color=blue>blue:</color>" + t_.m_struct);
          Debug.Log("<color=blue>blue:</color>" + t_testvar.M_testStruct.m_struct);
     
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
