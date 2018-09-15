using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     public class N_ToolHavePart_01_01 : N_ToolHavePart_01
     {
          public Action m_havePartEvent = null;
          public override E_ToolHavePart M_tollHavePart
          {
               get
               {
                    return base.M_tollHavePart;
               }
               set
               {
                    base.M_tollHavePart = value;
                    if (base.M_tollHavePart== E_ToolHavePart.e_havePart)
                    {
                         if (m_havePartEvent!=null)
                         {
                              m_havePartEvent();
                         }
                    }
               }
          }

     } 
}
