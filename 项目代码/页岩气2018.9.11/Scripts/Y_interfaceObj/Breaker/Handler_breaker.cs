using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class Handler_breaker : N_HandleEvent_init
     {


          //public override void fn_init(AB_MachineMag _msg)
          //{
          //    base.fn_init(_msg);

          //    machine_manager = GetComponentInParent<AB_MachineMag>();
          //    fnp_show();
          //}
          public override void fn_HandleMsg(AB_Message _msg)
          {
               base.fn_HandleMsg(_msg);

          }

     } 
}
