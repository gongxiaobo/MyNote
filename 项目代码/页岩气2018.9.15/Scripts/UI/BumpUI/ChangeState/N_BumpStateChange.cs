using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_BumpStateChange : AB_BumpStateChange
     {


          public override void fn_itemChange(int _itemID)
          {
               I_StateChange[] t_sc = transform.GetComponentsInChildren<I_StateChange>();
               for (int i = 0; i < t_sc.Length; i++)
               {
                    t_sc[i].fni_itemChange(_itemID);
               }
          }
     } 
}
