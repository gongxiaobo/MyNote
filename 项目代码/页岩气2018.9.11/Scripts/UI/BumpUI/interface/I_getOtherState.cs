using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 泵组件需要找到同一个泵的其他参数
     /// </summary>
     public interface I_getOtherState 
     {
          /// <summary>
          /// 获取指定ID的主状态值
          /// </summary>
          /// <param name="_itemID"></param>
          /// <returns></returns>
          string fni_otherState(int _itemID);
       
     } 
}
