using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class test_findinchild : MonoBehaviour
     {

          // Use this for initialization
          void Start() {
               Transform[] t_t= transform.FindInChlidArray<Transform>();
               for (int i = 0; i < t_t.Length; i++)
               {
                    
                    Debug.Log("<color=blue>blue:</color>"+t_t[i].name);
     
               }
		
	}

          // Update is called once per frame
          void Update()
          {

          }
     } 
}
