using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotatePart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
     public float m_rotatevalue = 0f;
	// Update is called once per frame
	void Update () {
          if (Input.GetKey(KeyCode.R))
          {
               float t_angel = m_rotatevalue + 5f;
               //if (t_angel >= 180f) { 
               //     m_rotatevalue = t_angel - 180f;
               //     t_angel = m_rotatevalue;
               //}
               fnp_rotate(t_angel);
          }
          if (Input.GetKey(KeyCode.T))
          {
               float t_angel = m_rotatevalue - 5f;
               //if (t_angel >= 180f) { 
               //     m_rotatevalue = t_angel - 180f;
               //     t_angel = m_rotatevalue;
               //}
               fnp_rotate(t_angel);
          }
		
	}
     private void fnp_rotate(float _rotate)
     {
          this.gameObject.transform.Rotate(new Vector3(0f, 0f, 1f), _rotate);
     }
}
