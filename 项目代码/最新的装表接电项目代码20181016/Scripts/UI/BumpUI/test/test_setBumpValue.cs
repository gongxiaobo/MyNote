using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
public class test_setBumpValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
          if (Input.GetKeyDown(KeyCode.C))
          {
               AB_State t_thisState = GetComponent<AB_State>();

               I_Control ti_control = GetComponent<I_Control>();

               if (t_thisState.m_ItemValueType== E_valueType.e_inter_floatvalue)
               {
                    float t_rand = Random.Range(-20f, 100f);
                    ti_control.fni_level(t_rand); 
               }
               if (t_thisState.m_ItemValueType== E_valueType.e_inter_onoff)
               {
                    float t_rand = Random.Range(0f, 100f);
                    if (t_rand>=50f)
                    {
                         ti_control.fni_on();
                    }
                    else
                    {
                         ti_control.fni_off();
                    }
               }
          }
	}
}
