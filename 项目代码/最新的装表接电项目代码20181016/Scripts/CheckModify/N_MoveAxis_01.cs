using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 根据输入比例值来移动一个物体
     /// </summary>
     public class N_MoveAxis_01 : N_MoveAxis
     {

          ////最开始的位置
          protected Vector3 m_defaultPos;
          public bool m_SetLocal = false;
          public override void fn_move(float _moveValue)
          {
               //base.fn_move(_moveValue);

               //使用比例值来换算
               if (m_moveLength == 0f)
               {
                    if (m_SetLocal==false)
                    {
                         m_defaultPos = m_move.position;
                    }
                    else
                    {
                         m_defaultPos = m_move.localPosition;
                    }
               }
               m_moveLength = m_canMoveLength * _moveValue;

               Vector3 t_pos = fnp_getNextPos(m_defaultPos, m_moveLength);
               if (m_SetLocal==false)
               {
                    m_move.position = t_pos;
               }
               else
               {
                    m_move.localPosition = t_pos;
               }
               if (_moveValue == 1f || _moveValue == -1f)
               {
                    m_isReachEnd = true;
               }
               else
               {
                    m_isReachEnd = false;
               }

               Debug.Log("<color=blue>使用比例值来换算:</color>" + _moveValue);


          }

          ///// <summary>
          ///// 输入值的范围
          ///// </summary>
          //public Vector2 m_inputValue = new Vector2(0f, 360f);
          ///// <summary>
          ///// 移动距离
          ///// </summary>
          //public float m_moveLength = 0.05f;

     }
}
