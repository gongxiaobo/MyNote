using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 移动玩家位置
     /// </summary>
     public abstract class AB_MovePlayer : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 移动玩家到世界位置
          /// </summary>
          /// <param name="_worldpos"></param>
          public abstract void fn_movePlayerToWPos(Vector3 _worldpos);


     }

}