using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     [DisallowMultipleComponent]
     public class N_ColliderSound : AB_ColliderSound
     {
          public override void OnTriggerEnter(Collider other)
          {
               //base.OnTriggerEnter(other);
               if (other.gameObject.layer == S_Layer.Instance.m_cannotmove)
               {
                    S_SoundComSingle.Instance.fnp_sound("metal_hit");
               }
          }
          public override void OnCollisionEnter(Collision collision)
          {
               if (S_SceneMagT1.Instance.m_finishInit==false)
               {
                    return;
               }
               //base.OnCollisionEnter(collision);
               if (collision.gameObject.layer == S_Layer.Instance.m_cannotmove)
               {
                    S_SoundComSingle.Instance.fnp_sound("PipeColider");
               }
          }

     } 
}
