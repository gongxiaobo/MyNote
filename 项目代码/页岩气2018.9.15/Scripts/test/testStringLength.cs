using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
//using System.Net;
public class testStringLength : MonoBehaviour {

	// Use this for initialization
	void Start () {
          JsonDate t_jd = new JsonDate();
          t_jd.m_age = 20;
          t_jd.m_name = "gong xb";

          string t_testProtcal = JsonUtility.ToJson(t_jd);
          
          Debug.Log("<color=blue>blue:</color>"+t_testProtcal.Length);
          //char[] t_array = new char[t_testProtcal.Length];
          //t_testProtcal.CopyTo(0, t_array, 0, t_testProtcal.Length);
          //for (int i = 0; i < t_array.Length; i++)
          //{
               
          //     Debug.Log("<color=blue>blue:</color>"+t_array[i]);
     
          //}

          byte[] t_byte = Encoding.UTF8.GetBytes(t_testProtcal);

          Debug.Log("<color=blue>t_byte length= </color>"+t_byte.Length);
          //for (int i = 0; i < t_byte.Length; i++)
          //{
               
          //     Debug.Log("<color=blue>blue:</color>"+t_byte[i]);
     
          //}
          //byte[] t_tempbyte;
          
          //Debug.Log("<color=red>byte to string :</color>"+Encoding.UTF8.GetString(t_byte,0,3));
          
          //Debug.Log("<color=red>red:</color>"+(190%60));
     
		
	}
	
	// Update is called once per frame
     //void Update () {
		
     //}
}
[Serializable]
public class JsonDate
{
     public int m_age;
     public string m_name;
}
