using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Quit : MonoBehaviour
     {
          bool m_quit = true;
          // Use this for initialization
          void Start()
          {
#if UNITY_EDITOR
               m_quit = false;
#endif
          }


          // Update is called once per frame
          void Update()
          {

               if (Input.GetKeyDown(KeyCode.Escape) && m_quit)
               {

                    Application.Quit();

               }

          }

     }
}
