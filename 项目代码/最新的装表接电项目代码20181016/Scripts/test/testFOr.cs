using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFOr : MonoBehaviour {

	// Use this for initialization
	void Start () {
          bool t_break = false;
          for (int i = 0; i < 5; i++)
          {
               Debug.Log("<color=blue>blue:</color>" + i);
               for (int j = 0; j < 5; j++)
               {
                    if (j == 2)
                    {
                         t_break = true;
                         break;
                    }
                    Debug.Log("<color=red>red:</color>" + j);

               }
               if (t_break)
               {
                    break;
               }
               
     

          }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
