using UnityEngine;
using System.Collections;


namespace GasPowerGeneration
{
     public class N_canMoveArea : AB_canMoveArea
     {
          MeshRenderer m_mesh = null;
          public override void fn_show(bool _show)
          {
               if (m_mesh == null)
               {
                    m_mesh = GetComponent<MeshRenderer>();
               }

               if (m_mesh == null)
               {
                    return;
               }
               m_mesh.enabled = _show;

          }


     } 
}

