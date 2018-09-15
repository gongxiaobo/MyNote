using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理拿起物体是零件的物体
     /// 改变零件的位置状态，
     /// 
     /// </summary>
     public class N_PickUp_02 : N_PickUp
     {
          protected override void fnp_pickUp(I_HandButton _hand)
          {
               base.fnp_pickUp(_hand);
               //设置零件的状态
               AB_ThePart t_thepart = this.gameObject.GetComponent<AB_ThePart>();
               if (t_thepart != null)
               {
                    t_thepart.M_PartState = E_ThePartState.e_inHand;
               }
          }
          protected override void fnp_putDown()
          {
               base.fnp_putDown();
               //设置零件的状态
               AB_ThePart t_thepart = this.gameObject.GetComponent<AB_ThePart>();
               if (t_thepart != null)
               {
                    t_thepart.M_PartState = E_ThePartState.e_onGround;
               }
          }

     } 
}
