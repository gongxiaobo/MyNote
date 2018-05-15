using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
public class testGetDicKey : MonoBehaviour {
     protected Dictionary<string, int> m_dic = new Dictionary<string, int>();
	// Use this for initialization
	void Start () {
          m_dic.Add("x", 1);
          m_dic.Add("y", 2);
          m_dic.Add("z", 3);
          m_dic.Add("w", 4);
          //foreach (KeyValuePair<string,string> item in m_dic)
          //{
               
          //     Debug.Log("<color=blue>key:</color>"+item.Key);
     
          //}
          //foreach (KeyValuePair<string, int> item in m_dic)
          //{

          //     Debug.Log("<color=blue>key:</color>" + item.Key+"->"+item.Value);

          //}

          FieldInfo[] t_info = typeof(testReflect).GetFields(
              BindingFlags.Instance | BindingFlags.Public);

          testReflect t_Obj = Activator.CreateInstance<testReflect>();
          for (int i = 0; i < t_info.Length; i++)
          {

               //Debug.Log("<color=blue>type:</color>" + t_info[i].FieldType);
               if (t_info[i].FieldType==typeof(string))
               {
                    t_info[i].SetValue(t_Obj, "x");
               }
               if (t_info[i].FieldType == typeof(int))
               {
                    t_info[i].SetValue(t_Obj, 19);
               }
                  
              
          }

          Debug.Log("<color=blue>blue:</color>" + t_Obj.m_name + "/" + t_Obj.m_age);
     

	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
public class testReflect
{
     public string m_name;
     public int m_age;
}
