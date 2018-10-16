using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
namespace Assets.Scripts.test.threadPool
{
    
     class test_ThreadPool : MonoBehaviour
     {
          public string m_txt1 = "good";
          public string m_txt2 = "very";
          void Start()
          {
               ThreadPool.QueueUserWorkItem((m) => fn_do1(m_txt1));
               ThreadPool.QueueUserWorkItem((m) => fn_do2(m_txt2));
               
               Debug.Log("<color=blue>main thread pass...</color>");

               Action<string> t_= new Action<string>(fn_do1);
          }
          void fn_do1(string _str)
          {

               for (int i = 0; i < 100000; i++)
               {
                    Debug.Log("<color=blue>blue:</color>" + _str);
                    if (m_closeThread)
                    {
                         break;
                    }
               }
     
          }
          void fn_do2(string _str)
          {
               for (int i = 0; i < 100000; i++)
               {
                    Debug.Log("<color=blue>red:</color>" + _str);
                    if (m_closeThread)
                    {
                         break;
                    }
               }
               
          }
          bool m_closeThread = false;
          void OnDisable()
          {
               m_closeThread = true;
          }
     }
}
