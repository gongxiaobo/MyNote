using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 找到零件的位置接口
     /// </summary>
     public interface I_partPos
     {
          /// <summary>
          /// 找到零件位置
          /// </summary>
          /// <param name="_id"></param>
          /// <returns></returns>
          Transform fni_ItemPos(int _id);
     } 
}
