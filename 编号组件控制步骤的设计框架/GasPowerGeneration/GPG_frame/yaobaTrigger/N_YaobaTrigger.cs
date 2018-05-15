using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把类型的触发器，但是要同类型的触发器，才能工作
     /// </summary>
     public class N_YaobaTrigger : AB_YaobaTrigger
     {
          public GameObject m_handleTrigger;
          protected bool m_isPutIn = false;
          public virtual void OnTriggerEnter(Collider other)
          {
               if (m_isPutIn)
               {
                    return;
               }
               if (other.tag == "yaoba")
               {
                    AB_NameFlag t_nf = other.gameObject.GetComponent<AB_NameFlag>();
                    AB_NameFlag t_nf1 = GetComponent<AB_NameFlag>();
                    if (t_nf != null && t_nf1 != null)
                    {
                         if (t_nf.Me_Type != t_nf1.Me_Type)
                         {//如果类型不一样，那么不能操作
                              return;
                         }
                         t_nf1.M_nameID = t_nf.M_nameID;
                    }
                    else
                    {
                         return;
                    }
                    gameObject.transform.rotation = other.gameObject.transform.rotation;
                    gameObject.transform.position = other.gameObject.transform.position;
                    //
                    fnp_putIn();



               }
          }


          public override void fnp_reset()
          {
               m_isPutIn = false;
               m_handleTrigger.SetActive(false);
          }

          protected override void fnp_putIn()
          {
               m_isPutIn = true;

               Rigidbody t_rg = GetComponent<Rigidbody>();
               I_pickUp t_pickup = GetComponent<I_pickUp>();
               if (t_pickup != null)
               {
                    t_pickup.fni_putDown();
               }
               if (t_rg != null)
               {
                    t_rg.isKinematic = true;
               }
               MeshCollider t_mc = GetComponentInChildren<MeshCollider>();
               if (t_mc != null)
               {
                    t_mc.enabled = false;
               }
               m_handleTrigger.SetActive(true);
          }
     } 
}
