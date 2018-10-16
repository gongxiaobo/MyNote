using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGetHideBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
          BoxCollider t_bc = GetComponent<BoxCollider>();
          if (t_bc!=null)
          {
               
               Debug.Log("<color=red>red:</color>");
               t_bc.enabled = true;
     
          }
	}
	
	
}
