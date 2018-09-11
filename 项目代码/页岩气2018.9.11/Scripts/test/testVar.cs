using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testVar : MonoBehaviour {
     public testStruct M_testStruct { get { return m_testStruct; } set { m_testStruct = value; } }
     protected testStruct m_testStruct;
	// Use this for initialization
     void Start()
     {
          m_testStruct = new testStruct();
          m_testStruct.m_struct = "struct";
          var t_x = new testnewclass();
          Debug.Log("<color=blue>1blue:</color>" + m_testStruct.m_struct);

          var t_tempclass=new {name="good",xx=123};
          
          Debug.Log("<color=blue>blue:</color>"+t_tempclass.name);
     

     }
	
	// Update is called once per frame
	void Update () {
          if (Input.GetKeyDown(KeyCode.A))
          {
               ParticleSystem t_par = GetComponent<ParticleSystem>();
               if (t_par!=null)
               {
                    var t_main= t_par.main;
                    t_main.startLifetime = 1f;
               }
          }
	}
}

public class testnewclass
{
     public string m_xx;
}
public struct testStruct
{
     public string m_struct;
}