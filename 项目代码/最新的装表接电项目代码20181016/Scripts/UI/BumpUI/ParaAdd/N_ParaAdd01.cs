using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 泵的开启按钮后，启动运行时间累加
     /// </summary>
     public class N_ParaAdd01 : N_ParaAdd, I_StateChange
     {

          I_getOtherState ti_getOtherState = null;
          public void fni_itemChange(int _itemID)
          {
               if (_itemID==3143)
               {//泵的开启按钮,开始计算运行时间
                    if (ti_getOtherState==null)
                    {
                         ti_getOtherState = transform.parent.GetComponent<I_getOtherState>();
                    }
                    if (ti_getOtherState != null)
                    {
                         if (ti_getOtherState.fni_otherState(_itemID) == "on")
                         {
                              fn_start();
                         }
                         else
                         {
                              fn_endToZero();
                         }
                    }
                    
               }
          }
          I_Control t_control = null;
          protected override void fnp_add()
          {
               base.fnp_add();
               if (t_control==null)
               {
                    t_control = GetComponent<I_Control>();
               }
               if (t_control!=null)
               {
                    t_control.fni_level(m_startvalue);

               }
          }
     } 
}
