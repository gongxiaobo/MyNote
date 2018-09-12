using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 手柄抖动的函数
     /// </summary>
     public class S_handShake : GenericSingletonClass<S_handShake>
     {
          Action m_handShake = null;

          public Action HandShake
          {
               get { return m_handShake; }
               set
               {
                    if (m_handShake == null)
                    {
                         m_handShake = value;
                    }
               }
          }

     } 
}
