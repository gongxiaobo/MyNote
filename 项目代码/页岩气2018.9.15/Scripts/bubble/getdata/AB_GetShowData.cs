using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 获取数据然后显示数据
     /// </summary>
     public abstract class AB_GetShowData : AB_GetData
     {

          /// <summary>
          /// 获取物体的ID编号
          /// </summary>
          public abstract int M_itemID { get; set; }

     } 
}
