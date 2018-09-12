using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 工具上有无零件的状态
     /// </summary>
     public class N_ToolHavePart_01 : AB_ToolHavePart
     {
          [Tooltip("工具上有无零件的状态")]
          public E_ToolHavePart m_toolhavePart = E_ToolHavePart.e_noPart;
          public override E_ToolHavePart M_tollHavePart
          {
               get
               {
                    if (gameObject.GetComponentInChildren<AB_ThePart>()!=null)
                    {
                         m_toolhavePart = E_ToolHavePart.e_havePart;
                    }
                    else
                    {
                         m_toolhavePart = E_ToolHavePart.e_noPart;
                    }
                    return m_toolhavePart;
               }
               set
               {
                    m_toolhavePart=value;
               }
          }
     }

}