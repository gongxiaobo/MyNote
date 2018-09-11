using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 在场景结束后调用
     /// </summary>
     public class S_sceneOver : GenericSingletonClass<S_sceneOver>
     {
          private Action me_over;
          /// <summary>
          /// 场景结束时调用
          /// </summary>
          public Action Over
          {
               get { return me_over; }
               set
               {
                    if (value != null)
                    {
                         me_over += value;
                    }
               }
          }

     } 
}
