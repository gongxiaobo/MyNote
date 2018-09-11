using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 测试盖帽的放入问题
     /// 1s钟检查一次到达位置
     /// 在使用工具放入零件，一直没有调用fn_endcontrol,所有
     /// 没有当值接近限制值时的设置最大最小值的设置。
     /// </summary>
     public class Door_90_02_02 : Door_90_02
     {
          TimeCount1 m_time = null;
          public override void fn_startControl(Transform _movehand)
          {
               base.fn_startControl(_movehand);
               if (m_time==null)
               {
                    m_time = new TimeCount1();
                    m_time.SetCallSpace(1f, fnp_checkLastTime);
               }
          }
          protected override void fnp_update()
          {
               base.fnp_update();
              
               //fnp_checkLastTime();
               if (m_time!=null)
               {
                    m_time.CallTime(Time.deltaTime);
               }
          }
          public override void fn_endControl()
          {
               base.fn_endControl();
               if (m_time!=null)
               {
                    m_time.Reset();
                    m_time = null;
               }
          }

     } 
}
