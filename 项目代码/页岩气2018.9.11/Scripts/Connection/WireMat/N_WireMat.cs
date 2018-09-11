using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 在电线被显示时，更新电线的颜色材质。
     /// </summary>
     public class N_WireMat : AB_WireMat
     {
          protected I_SetWireMat mi_SetWireMat = null;
          public MaterialObj m_materialObj;
          Material m_select=null;
          public override void fn_setMaterial(string _colorName)
          {
               if (m_materialObj==null)
               {
                    m_materialObj = S_WireMaterial.Instance.MaterialObj;
               }
               if (mi_SetWireMat==null)
               {
                    mi_SetWireMat = GetComponent<I_SetWireMat>();
               }
               m_select = m_materialObj.fn_get(_colorName);
               if (mi_SetWireMat!=null)
               {
                    mi_SetWireMat.fni_setWireDefaultMat(m_select);
               }
               //E_ropeColor t_colortype= WireColor.fns_wireColor(_colorName);
               //switch (t_colortype)
               //{
               //     case E_ropeColor.e_red:
               //          m_select=m_materialObj.fn_get()
               //          break;
               //     case E_ropeColor.e_green:
               //          break;
               //     case E_ropeColor.e_blue:
               //          break;
               //     case E_ropeColor.e_yellow:
               //          break;
               //     case E_ropeColor.e_black:
               //          break;
               //     case E_ropeColor.e_white:
               //          break;
               //     default:
               //          break;
               //}
          }
     }

}