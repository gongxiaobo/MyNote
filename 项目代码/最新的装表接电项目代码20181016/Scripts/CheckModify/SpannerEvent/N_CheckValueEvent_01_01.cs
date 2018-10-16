using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 旋钮的旋转事件带动工具的位移
     /// </summary>
     public class N_CheckValueEvent_01_01 : N_CheckValueEvent_01
     {
          public AB_MoveAxis m_moveAxis = null;
          
          public override void fn_ValueEvent(float _now, Vector2 _valuelimit)
          {
               base.fn_ValueEvent(_now, _valuelimit);
               if (_valuelimit.y == _valuelimit.x)
               {
                    return;
               }
               if (m_moveAxis==null)
               {
                    m_moveAxis = GetComponent<AB_MoveAxis>();
               }
               if (m_moveAxis!=null)
               {//传入比例值
                    
                    m_moveAxis.fn_move(_now / (_valuelimit.y - _valuelimit.x));
               }
               else
               {

                    Debug.Log("<color=blue>can not find AB_MoveAxis </color>");
     
               }

          }

     } 
}
