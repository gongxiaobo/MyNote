using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.testconnect
{
     /// <summary>
     /// 测试代码
     /// </summary>
     class test_removeDic : MonoBehaviour
     {
          Dictionary<string, GameObject> m_dic = new Dictionary<string, GameObject>();
          void Start()
          {
               m_dic.Add("1", new GameObject("1"));
               m_dic.Add("2", new GameObject("2"));
               m_dic.Add("3", new GameObject("3"));

          }
          int m_removeID = 0;
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.D))
               {
                    m_removeID++;
                    if (m_removeID > 3)
                    {
                         return;
                    }
                    Destroy(m_dic[m_removeID.ToString()]);
                    m_dic.Remove(m_removeID.ToString());

                    Debug.Log("<color=blue>m_dic length : </color>" + m_dic.Count);
     
               }

          }
     }
}
