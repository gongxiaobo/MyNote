using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_parsePara : MonoBehaviour {

	// Use this for initialization
	void Start () {
          string t_para = "10&20&2&hard&red";
          string[] t_paras = S_ParseWirePara.fn_getPara(t_para);
          for (int i = 0; i < t_paras.Length; i++)
          {
               
               Debug.Log("<color=blue>blue:</color>"+t_paras[i]);
     
          }
          
     
	}
	
     //// Update is called once per frame
     //void Update () {
		
     //}
}
