﻿using UnityEngine;
using System.Collections;

namespace GasPowerGeneration
{
     public class GenericDontDestroy<T> : MonoBehaviour where T : Component
     {
          private static T instance;
          public static T Instance
          {
               get
               {
                    if (instance == null)
                    {
                         instance = FindObjectOfType<T>();
                         if (instance == null)
                         {
                              GameObject obj = new GameObject(typeof(T).Name);
                              instance = obj.AddComponent<T>();
                         }
                    }
                    return instance;
               }
          }
          public virtual void Awake()
          {
               if (instance == null)
               {

                    instance = this as T;
                    DontDestroyOnLoad(this.gameObject);
               }
          }

     } 
}
