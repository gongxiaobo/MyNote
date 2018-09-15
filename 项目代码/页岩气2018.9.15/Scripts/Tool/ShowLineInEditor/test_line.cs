using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tool.ShowLineInEditor
{
     class test_line:MonoBehaviour
     {

          void Start()
          {
               Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(0, 10, 0), Color.red,10f);
          }
          //void Update()
          //{
          //     Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(0, 10, 0), Color.red);
          //}
     }
}
