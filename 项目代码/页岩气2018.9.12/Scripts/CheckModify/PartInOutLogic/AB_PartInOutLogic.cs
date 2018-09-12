using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理零件拿出和放入的结果触发
     /// </summary>
     public abstract class AB_PartInOutLogic : MonoBehaviour
     {
          protected virtual void Start() { }
          /// <summary>
          /// 零件在机器和不再机器的结果触发
          /// </summary>
          /// <param name="_partState"></param>
          public abstract void fnp_PartPosChange(E_ThePartState _partState);

     } 
}
