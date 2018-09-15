using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_SetState : AB_SetState
     {
          public override void fn_setState(string _name, string _value, AB_HandleEvent _HandleEvent)
          {
               if (_HandleEvent == null)
               {
                    throw new System.NotImplementedException();
                    //return;
               }
               StateValue t_sv = _HandleEvent.fn_get(_name);
               if (t_sv != null)
               {
                    StateValueString t_s = t_sv as StateValueString;
                    t_s.m_date = _value;
                    _HandleEvent.fn_set(t_s);

               }
          }
     } 
}
