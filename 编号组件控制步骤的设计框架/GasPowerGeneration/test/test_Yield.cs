using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Yield : MonoBehaviour {

	// Use this for initialization
	void Start () {
          foreach (var item in fn_yield1())
          {
               Debug.Log("<color=blue>blue:</color>"+item);
     
          }
		
	}

     IEnumerable<string> fn_yield()
     {
          yield return "1";
          yield return "2";
          yield return "3";

     }
     IEnumerable<string> fn_yield1()
     {
          for (int i = 0; i < 3; i++)
          {
               yield return i.ToString();
               
               Debug.Log("<color=blue>blue:</color>"+i+"_");
     
          }
          
          Debug.Log("<color=red>red:</color>");
     

     }
	// Update is called once per frame
	void Update () {
		
	}
}
