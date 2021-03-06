﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 设置工具的状态值的设置，主要处理工具在使用中，在地上，在手上的情况
     /// </summary>
     public class N_PickUpColumn_01_01 : N_PickUpColumn_01
     {
          I_Control mi_control = null;
          protected override void fnp_putDown()
          {
               base.fnp_putDown();
               //放下摇把
               fnp_setState(0);
          }
          public override void fni_putDown()
          {
               base.fni_putDown();
               //把摇把放入机器
               fnp_setState(2);
          }
          protected override void fnp_pickUp(I_HandButton _hand)
          {
               base.fnp_pickUp(_hand);
               //捡起把手
               fnp_setState(1);
          }
          protected override void fnp_Pull()
          {
               base.fnp_Pull();
               //从机器拔出把手
               fnp_setState(1);
          }
          /// <summary>
          /// 设置把手的状态值，0在地上，1在手上，2在机器上
          /// </summary>
          /// <param name="_level"></param>
          protected void fnp_setState(int _level)
          {
               fnp_findControl();
               if (mi_control != null)
               {
                    mi_control.fni_level(_level);
               }
          }
          protected void fnp_findControl()
          {
               if (mi_control == null)
               {
                    mi_control = GetComponent<I_Control>();
               }
          }

     } 
}
