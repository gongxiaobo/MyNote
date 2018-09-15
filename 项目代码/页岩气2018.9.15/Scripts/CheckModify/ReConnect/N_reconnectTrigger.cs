using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 零件再次放回到机器上的触发器
     /// </summary>
     public class N_reconnectTrigger : AB_reconnectTrigger
     {

          public override void fn_reconnect()
          {
               throw new System.NotImplementedException();
          }

          public virtual void OnTriggerEnter(Collider other)
          {

               //Debug.Log("<color=blue>other=</color>"+other.name);
     
               AB_CanPullOutObj t_canPullOutObj=other.transform.parent.GetComponent<AB_CanPullOutObj>();
               if (t_canPullOutObj==null)
               {
                    t_canPullOutObj = other.transform.parent.GetComponentInChildren<AB_CanPullOutObj>();
               }
               if (t_canPullOutObj!=null)
               {
                    t_canPullOutObj.fn_ToAttach();
                    gameObject.SetActive(false);
               }
          }

     } 
}
