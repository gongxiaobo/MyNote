using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 旋塞阀和旋碟阀的初始化
     /// </summary>
     public class N_PartTriggerInit_1_4 : N_PartTriggerInit_1
     {
          public BoxCollider m_trigger = null;
          protected override void fnp_DoInit()
          {
               //base.fnp_DoInit();

               //AB_Name t_name = GetComponent<AB_Name>();
               AB_State t_state = GetComponent<AB_State>();

                if (t_state!=null)
               {
                    if (t_state.fn_getMainValue() == "on")
                    {

                    }
                    else
                    {//在关闭后
                         if (m_trigger!=null)
                         {
                              m_trigger.enabled = false;
                         }
                    }
               }



          }

     }
}
