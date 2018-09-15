using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public abstract class AB_manager : MonoBehaviour
     {
          public string m_machineName = "";
          // Use this for initialization
          protected virtual void Start()
          {
               S_testSceneManager.Instance.fn_putin(this);
          }

          public abstract void fn_init();

     } 
}
