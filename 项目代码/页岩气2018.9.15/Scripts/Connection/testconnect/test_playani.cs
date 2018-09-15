using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_playani : MonoBehaviour {
     protected Animator m_ani = null;
	// Use this for initialization
	void Start () {
          m_ani = GetComponent<Animator>();
	}
     protected string m_order = "end";
	// Update is called once per frame
	void Update () {
          if (Input.GetKeyDown(KeyCode.P))
          {
               if (m_ani!=null)
               {
                    m_order = (m_order == "start") ? "end" : "start";
                    m_ani.SetTrigger(m_order);
               }
          }
	}
}
