using UnityEngine;
using System.Collections;
//using VRPT.Turntable;
namespace GasPowerGeneration
{
     public class SynPosition : MonoBehaviour
     {
          public Transform gotoP;
          private Transform myTransform;
          // Use this for initialization
          void Start()
          {
               myTransform = gameObject.transform;
               S_update.Instance.M_fixedupdate = MyUpdate;
          }

          // Update is called once per frame
          void MyUpdate()
          {
               if (gotoP != null)
               {
                    myTransform.position = new Vector3(gotoP.position.x, myTransform.position.y, gotoP.position.z);
               }

          }
     } 
}
