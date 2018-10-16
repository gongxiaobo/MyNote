using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_hms : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
     void Update()
     {
          if (Input.GetKeyDown(KeyCode.R))
          {
               fn_add();
          }
     }
     public float m_second = 100f;
     protected void fn_add()
     {
          float t_h,t_m,t_s;
          s_secondToH.fns_SecondToSMH(m_second, out t_h, out t_m, out t_s);

          Debug.Log("<color=blue>blue: </color>" + t_h+":"+t_m+":"+t_s);
     
     }
}
