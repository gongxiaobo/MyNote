using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testYaoba : MonoBehaviour
     {

          //Quaternion m_rotate;
          //void Start()
          //{
          //     //m_rotate = transform.parent.rotation;
          //}
          public GameObject m_handleTrigger;
          public void OnTriggerEnter(Collider other)
          {
               if (m_isPutIn)
               {
                    return;
               }
               if (other.tag == "yaoba")
               {
                    gameObject.transform.rotation = other.gameObject.transform.rotation;
                    gameObject.transform.position = other.gameObject.transform.position;
                    fnp_putIn();
                    //Invoke("fnp_putIn", 2f);
                    Debug.Log("<color=blue>OnTriggerEnter:</color>");
                    //m_isCountDown = true;

               }




          }

          //public void OnTriggerExit(Collider other)
          //{
          //     //if (m_isPutIn)
          //     //{
          //     //     return;
          //     //}
          //     //if (other.name == "Yaobadot")
          //     //{
          //     //     CancelInvoke("fnp_putIn");
          //     //     m_isCountDown = false;
          //     //     Debug.Log("<color=blue>OnTriggerExit:</color>");
          //     //}

          //}
          //bool m_isCountDown = false;
          bool m_isPutIn = false;
          public void fnp_reset()
          {
               //m_isCountDown = false;
               m_isPutIn = false;
          }
          private void fnp_putIn()
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
               //transform.rotation = Quaternion.identity;
               //transform.parent.rotation = m_rotate;

          }


     }

}