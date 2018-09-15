using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using GCode;

namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0724/ :可以移动地面的管理
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class S_canMoveMrg : MonoBehaviour
     {
          AB_canMoveArea[] m_canmove;
          // Use this for initialization
          void Start()
          {
               m_canmove = GetComponentsInChildren<AB_canMoveArea>();
               GlobalEventSystem<N_eventMove>.eventHappened += fnp_canShow;
          }

          protected void fnp_canShow(N_eventMove _eventMove)
          {

               if (_eventMove != null)
               {

                    for (int i = 0; i < m_canmove.Length; i++)
                    {
                         if (m_canmove[i] != null)
                         {
                              m_canmove[i].fn_show(_eventMove.m_show);
                         }
                    }

               }
          }


     } 
}

