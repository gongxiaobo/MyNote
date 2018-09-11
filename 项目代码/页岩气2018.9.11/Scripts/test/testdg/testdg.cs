using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testdg : MonoBehaviour {

	// Use this for initialization
	void Start () {
          fn_debug(0);
          //int i = 0;
          
          //Debug.Log("<color=blue>blue1:</color>"+(++i));
          
          //Debug.Log("<color=blue>blue2:</color>"+i);
     
     
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     int m_nameid = 10;
     int m_tempid=0;
     void fn_debug(int _id)
     {
          if (m_nameid==_id)
          {
               return;
          }
          else
          {
               fn_debug(m_tempid++);
          }
          Debug.Log("<color=blue></color>" + _id);
         
     

     }
}
