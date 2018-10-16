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
          //一个物体触发的情况
          public GameObject m_handleTrigger;
           [Tooltip("碰触到可以操作后，需要显示的触发器")]
          //多个触发物体的情况
          public List<GameObject> m_listHandleTrigger = new List<GameObject>();
          [Tooltip("碰触到可以操作后，需要隐藏的触发器")]
          /// <summary>
          /// 碰触到可以操作后，需要隐藏的触发器
          /// </summary>
          public List<GameObject> m_listHandleTriggerOff = new List<GameObject>();
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
               if (m_handleTrigger!=null)
               {
                    m_handleTrigger.SetActive(false); 
               }
               if (m_listHandleTrigger.Count>0)
               {
                    for (int i = 0; i < m_listHandleTrigger.Count; i++)
                    {
                         m_listHandleTrigger[i].SetActive(false);
                    }
               }
               if (m_listHandleTriggerOff.Count > 0)
               {
                    for (int i = 0; i < m_listHandleTriggerOff.Count; i++)
                    {
                         m_listHandleTriggerOff[i].SetActive(true);
                    }
               }
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
               if (m_handleTrigger!=null)
               {
                    m_handleTrigger.SetActive(true); 
               }
               if (m_listHandleTrigger.Count > 0)
               {
                    for (int i = 0; i < m_listHandleTrigger.Count; i++)
                    {
                         m_listHandleTrigger[i].SetActive(true);
                    }
               }
               if (m_listHandleTriggerOff.Count > 0)
               {
                    for (int i = 0; i < m_listHandleTriggerOff.Count; i++)
                    {
                         m_listHandleTriggerOff[i].SetActive(false);
                    }
               }
          }
     } 
}
