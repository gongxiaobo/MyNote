using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 效果触发的实现类
     /// </summary>
     public abstract class AB_TriggerEffect
     {
          /// <summary>
          /// 触发一重类型的效果
          /// </summary>
          /// <param name="_type"></param>
          /// <param name="_name"></param>
          /// <param name="_itemName"></param>
          public abstract void fn_effect(E_effectType _type, E_effectName _name, AB_Name _itemName);
     } 
}
