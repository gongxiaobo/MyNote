using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_CloseLastUI : AB_CloseLastUI
     {

          A_TriggerObj m_lastUI=null;
          public override A_TriggerObj M_LastUI
          {
               get
               {
                    return m_lastUI;
               }
               set
               {
                    m_lastUI=value;
               }
          }
     } 
}
