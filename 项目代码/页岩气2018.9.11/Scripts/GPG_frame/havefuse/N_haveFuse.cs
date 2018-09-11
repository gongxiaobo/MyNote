using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 是否放入熔断器
     /// </summary>
     public class N_haveFuse : AB_haveFuse
     {
          bool m_haveFuse = false;
          public override bool fn_HaveFuse()
          {
               return m_haveFuse;
          }

          public override void fn_connectFuse(bool _co)
          {
               m_haveFuse = _co;
          }
     } 
}
