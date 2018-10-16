using UnityEngine;
using System.Collections;

namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0309/ :长距离移动的控制
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public interface I_useTelePorter
     {
          /// <summary>
          /// 设置是否使用长距离移动
          /// true :不能使用
          /// false: 可以使用
          /// </summary>
          void fni_canUseToMove(bool _can);
     } 
}
