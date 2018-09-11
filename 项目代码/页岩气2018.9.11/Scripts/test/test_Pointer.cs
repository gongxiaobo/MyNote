using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
public class test_Pointer : MonoBehaviour {
     AB_Pointer m_pointer = null;
	// Use this for initialization
	void Start () {
          m_pointer = GetComponent<AB_Pointer>();
          //m_pointer.fn_inputValue(m_inputValue);
	}
     public float m_inputValue = 0f;
	// Update is called once per frame
	void Update () {
          if (Input.GetKeyDown(KeyCode.R))
          {
               m_pointer.fn_inputValue(m_inputValue);
          }
	}
}
