using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
public class test_bumpUIKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
          if (Input.GetKeyDown(KeyCode.S))
          {
               I_bumpTrigger t_bumpui = GetComponent<I_bumpTrigger>();
               if (t_bumpui!=null)
               {
                    t_bumpui.fni_btn_press(transform.FindInChild("enter").gameObject, true);
               }
               
          }
	}
}
