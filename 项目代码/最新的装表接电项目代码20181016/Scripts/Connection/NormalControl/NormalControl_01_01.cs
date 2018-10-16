using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.NormalControl
{
     /// <summary>
     /// 表盖类型的状态变化反应
     /// </summary>
     class NormalControl_01_01 : NormalControl_01
     {
          public MeshRenderer m_mr = null;
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);
               if (m_mr != null)
               {
                    m_mr.enabled = false;
               }
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               if (m_mr != null)
               {
                    m_mr.enabled = true;
               }
          }

     }
}
