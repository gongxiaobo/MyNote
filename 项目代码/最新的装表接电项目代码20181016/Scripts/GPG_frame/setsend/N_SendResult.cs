using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_SendResult : AB_SendResult
     {
          public override void fn_SendResult(string _name, AB_ResultAction _resultAction, AB_HandleEvent _HandleEvent)
          {
               if (_resultAction != null && _HandleEvent != null)
               {
                    _resultAction.fn_SendResultMsg(_name, _HandleEvent);

                    //Debug.Log("<color=red>产生的结果消息发送:</color>");

               }
               else
               {
                    throw new System.NotImplementedException();
                    //throw System.NullReferenceException.
               }
          }
     } 
}
