using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollisonSound : MonoBehaviour {
     public AudioSource m_ac = null;
	// Use this for initialization
	void Start () {
		m_ac=GetComponentInChildren<AudioSource>();
	}

     public void OnCollisionEnter(Collision collision)
     {
          
     
          if (m_ac!=null)
          {
               m_ac.Play();
          }
     }

    
}
