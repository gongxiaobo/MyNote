using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.synCamera
{
     class MoveCameraToVR : MonoBehaviour
     {
          public Transform m_vrCamera = null;
          void Update()
          {
               if (m_vrCamera!=null)
               {
                    this.transform.position = m_vrCamera.position;
                    this.transform.rotation = m_vrCamera.rotation;
               }
          }

     }
}
