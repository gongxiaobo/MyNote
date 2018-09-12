using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testfindbox : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               //Transform[] t_r = transform.FindInChlidArray<Transform>(0);
               //for (int i = 0; i < t_r.Length; i++)
               //{

               //     Debug.Log("<color=blue>blue:</color>" + t_r[i].name);

               //}
               List<BoxCollider> t_r = transform.FindInChlid<BoxCollider>();
               for (int i = 0; i < t_r.Count; i++)
               {

                    Debug.Log("<color=blue>blue:</color>" + t_r[i].name);

               }
          }

          // Update is called once per frame
          //void Update () {

          //}
     }

}