using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.test.Optimization
{
     public class N_HideRange : AB_HideRange
     {
          public float m_checkRange=2.5f;
          public override float M_range
          {
               get { return m_checkRange; }
          }
     }
}
