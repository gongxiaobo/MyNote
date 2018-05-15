using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_changecolor : MonoBehaviour {
     public MeshRenderer m_mesh = null;
     public Material m_on = null;
     public Material m_off = null;
	// Use this for initialization
	void Start () {
          m_off = m_mesh.material;
	}
     public void fn_change(string _state)
     {

          //Debug.Log("<color=red>_state:</color>" + _state);
     
          switch (_state)
          {
               case "on":
                    m_mesh.material = m_on;
                    break;
               case "off":
                    m_mesh.material = m_off;
                    break;
               default:
                    break;
          }
     }

}
