using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 可以在使用前动态更改旋转的限制
     /// </summary>
     public class CaculateAngelLimitSetRT : CaculateAngelLimit, I_RealtimeSetRange
     {

          public void fni_setRange(Vector2 _limitRange)
          {
               fnp_setRange(_limitRange);
          }
          public override void fn_endControl()
          {
               base.fn_endControl();
          }
     } 
}
