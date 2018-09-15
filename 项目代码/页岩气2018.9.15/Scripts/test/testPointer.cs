using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class testPointer : MonoBehaviour
     {
          AB_Pointer m_pointer;

          // Use this for initialization
          void Start()
          {
               m_pointer = GetComponent<AB_Pointer>();
               Invoke("fn_roate", 2f);
          }
          protected void fn_roate()
          {
               m_pointer.fn_inputValue(Random.Range(0f, 80f));
               Invoke("fn_roate", 2f);
          }
     } 
}
