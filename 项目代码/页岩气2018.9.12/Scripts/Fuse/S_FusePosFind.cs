using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class S_FusePosFind : GenericSingletonClass<S_FusePosFind>
     {
          Dictionary<E_FusePosName, AB_FusePos> m_fusePos = new Dictionary<E_FusePosName, AB_FusePos>();
          public void fn_putin(AB_FusePos _fusePos)
          {
               if (_fusePos != null)
               {
                    if (!m_fusePos.ContainsKey(_fusePos.m_fusePosName))
                    {
                         m_fusePos.Add(_fusePos.m_fusePosName, _fusePos);
                    }
               }
          }
          public GameObject fn_getPosConnect(E_FusePosName _posName)
          {
               if (m_fusePos.ContainsKey(_posName))
               {
                    return m_fusePos[_posName].fn_getConnect(_posName);
               }

               return null;
          }

     } 
}
