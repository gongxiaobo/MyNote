using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 根据id来高亮这个item
     /// </summary>
     public interface I_LightItemID
     {
          /// <summary>
          /// 高亮
          /// </summary>
          void fni_lightOn(int _id);
          /// <summary>
          /// 关闭高亮
          /// </summary>
          void fni_endLight(int _id);

     } 
}
