using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     public class testvalue : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               string t_1 = "366|";
               string t_2 = "366|988|";
               string t_ = "366|988";

               Debug.Log("<color=blue>blue:</color>" + S_checkValue.fns_isArea(t_));
               string[] s_plit = t_.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
               for (int i = 0; i < s_plit.Length; i++)
               {

                    Debug.Log("<color=red>red:</color>" + s_plit[i]);

               }
          }

          // Update is called once per frame
          //void Update()
          //{

          //}
     }

}