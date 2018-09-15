using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_FusePos : AB_FusePos
     {
          void Start()
          {
               S_FusePosFind.Instance.fn_putin(this);
          }

          public override GameObject fn_getConnect(E_FusePosName _name)
          {
               if (_name == m_fusePosName)
               {
                    return this.gameObject;
               }
               return null;
          }
     } 
}
