using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGetMeshCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
         
		
	}
	
	// Update is called once per frame
	void Update () {
          if (Input.GetKeyDown(KeyCode.A))
          {
               MeshCollider t_mc = GetComponent<MeshCollider>();
               if (t_mc != null)
               {

                    Debug.Log("<color=blue>find mesh collider</color>");

               }
          }
          if (Input.GetKeyDown(KeyCode.D))
          {
               MeshCollider t_mc = GetComponent<MeshCollider>();
               if (t_mc != null)
               {

                   Destroy(t_mc);

               }
          }
	}
}
