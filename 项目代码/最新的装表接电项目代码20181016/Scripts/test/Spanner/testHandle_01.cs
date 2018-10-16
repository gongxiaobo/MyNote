using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testHandle_01 : testHandle
     {
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (S_SceneMessage.Instance.m_isTableModel)
               {
                    if (S_SceneMessage.Instance.m_TableMode!= Assets.Scripts.Connection.TableMode.E_TableMode.e_learn||
                         S_SceneMessage.Instance.m_TableMode != Assets.Scripts.Connection.TableMode.E_TableMode.e_null)
                    {
                         base.fn_trigger(_button, _hand);  
                    }
               }
          }
        
     } 
}
