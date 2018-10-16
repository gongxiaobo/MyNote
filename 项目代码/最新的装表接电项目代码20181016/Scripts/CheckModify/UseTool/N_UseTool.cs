using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_UseTool : AB_UseTool
     {

          public E_UseTool m_SelectUseTool = E_UseTool.e_noUseTool;
          public override E_UseTool M_UseTool
          {
               get { return m_SelectUseTool; }
          }
     } 
}
