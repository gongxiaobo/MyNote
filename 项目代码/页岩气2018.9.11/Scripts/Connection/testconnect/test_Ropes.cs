using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class test_Ropes : MonoBehaviour
     {
          Dictionary<string, GameObject> m_ropes = new Dictionary<string, GameObject>();
          // Use this for initialization
          void Start()
          {
               Transform[] t_child = GetComponentsInChildren<Transform>();
               for (int i = 0; i < t_child.Length; i++)
               {
                    if (t_child[i].name==this.gameObject.name)
                    {
                        continue;
                    }
                    if (!m_ropes.ContainsKey(t_child[i].name))
                    {
                         m_ropes.Add(t_child[i].name, t_child[i].gameObject);
                    }
                    else
                    {

                         Debug.Log("<color=red>same name </color>" + t_child[i].name);
     
                    }
                    t_child[i].gameObject.SetActive(false);
                   
               }
          }
          public bool fn_showRope(string _name)
          {
               if (m_ropes.ContainsKey(_name))
               {
                    m_ropes[_name].SetActive(true);
                    return true;
               }
               return false;
          }

         
     } 
}
