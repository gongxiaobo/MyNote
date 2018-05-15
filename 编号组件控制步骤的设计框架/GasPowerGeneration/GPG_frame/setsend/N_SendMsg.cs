using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_SendMsg : AB_SendMsg
     {

          public override void fn_sendmsg(E_MessageType _type, E_valueType _valueType,
               int _fromid, int _toID, string _value, AB_HandleEvent _sender)
          {
               if (_toID == 0 || _sender == null)
               {
                    throw new System.NotImplementedException();
                    //return;
               }
               AB_Message t_g = new N_Message();
               t_g.fn_init(
                    _type,
                    new StateValue[1] { 
                                   new StateValueString(
                                        S_initDate.fns_getStateValueName(_valueType),
                                        _value) },
                    "set",
                    _fromid,
                    _toID);
               _sender.fn_SendMsg(t_g);
          }
     } 
}
