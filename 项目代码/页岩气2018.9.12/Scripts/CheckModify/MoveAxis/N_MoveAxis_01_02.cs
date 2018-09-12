using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 主要是用来复位已经移动的子物体
     /// </summary>
     public class N_MoveAxis_01_02 : N_MoveAxis_01, I_RestMoveAxisPos
     {
          protected override void Start()
          {
               base.Start();
               if (m_SetLocal == false)
               {
                    m_theChildDefault = m_move.position;
               }
               else
               {
                    m_theChildDefault = m_move.localPosition;
               }
          }
          protected Vector3 m_theChildDefault;
          /// <summary>
          /// 为复位子物体
          /// </summary>
          public void fni_reset()
          {
               fn_reset();
               if (m_SetLocal == false)
               {
                    m_move.position = m_theChildDefault;
               }
               else
               {
                    m_move.localPosition = m_theChildDefault;
               }

          }
     }
}
