using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 拉出器类型，在工具放到地面，隐藏拉出上的一个碰撞体
     /// </summary>
     public class N_YaobaControl01 : N_YaobaControl
     {
          public GameObject m_hideTrigger = null;
          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_level(_level, _controlType);
               if (_level==0)
               {//摇把在地上
                    if (m_hideTrigger!=null)
                    {
                         m_hideTrigger.SetActive(false);
                    }
               }
          }
     } 
}
