using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testCDP : MonoBehaviour
     {
          public I_CDPSet m_testCDPSet;
          // Use this for initialization
          void Start()
          {
               m_testCDPSet = GetComponent<I_CDPSet>();
          }

          // Update is called once per frame
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.A))
               {
                    m_testCDPSet.fni_UpArrow_start(fn_debug);
               }
               if (Input.GetKeyDown(KeyCode.S))
               {
                    m_testCDPSet.fni_UpArrow_end();
               }
          }
          protected void fn_debug(string _str)
          {

               Debug.Log("<color=blue>blue:</color>" + _str);

          }
     }

}