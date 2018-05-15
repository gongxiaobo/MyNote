using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_lightTarget : A_TriggerObj
     {
          //protected AB_LightOneObj m_lightObj = null;
          protected AB_LightOneObj[] t_lights = null;
          /// <summary>
          /// 高亮物体的查找深度值
          /// </summary>
          public byte m_LightOneObjDepth = 0;
          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               t_lights = m_LightOneObjDepth == 0 ? GetComponentsInChildren<AB_LightOneObj>() :
                    transform.FindInChlidArray<AB_LightOneObj>(m_LightOneObjDepth);
               for (int i = 0; i < t_lights.Length; i++)
               {
                    if (t_lights[i].m_lightObjType == E_LightObjType.e_normal)
                    {
                         if (_inOut)
                         {
                              t_lights[i].fn_light();
                         }
                         else
                         {
                              t_lights[i].fn_endLigth();
                         }
                    }
               }


          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {

          }
     }

}