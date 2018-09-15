using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     //using GCode;
     /// <summary>
     /// 玩家的位置
     /// </summary>
     public class S_Player : GenericSingletonClass<S_Player>
     {
          public Transform m_playerTran;
          public Transform m_playerhead;
          /// <summary>
          /// 玩家眼前的一个点
          /// </summary>
          public Transform m_playerEye_front;

          //移动玩家到指定的地方
          public AB_MovePlayer m_moveplayer;

     }

}