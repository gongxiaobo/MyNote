using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 获取item的获取冒泡信息的组件类接口
     /// </summary>
     public interface I_bubbleGetDetail
     {
          /// <summary>
          /// 获取冒泡的详细信息
          /// </summary>
          /// <param name="_itemID">item id</param>
          /// <returns>AB_BubbleKeyValue</returns>
          AB_BubbleKeyValue fni_bubbleGetDetail(int _itemID);
     } 
}
