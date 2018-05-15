using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Look_pointer : N_Pointer
     {
          public float animspeed;
          protected override void Start()
          {
               base.Start();
               //m_offset = animspeed*0.2f;
               m_offset *= 4f;
          }

     }

}