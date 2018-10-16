using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 零件的统一标识类
     /// </summary>
     public abstract class AB_ThePart : MonoBehaviour
     {
          /// <summary>
          /// 是否是配对的零件，通过ID来区分
          /// </summary>
          /// <returns>true 为是配对零件</returns>
          public abstract bool fn_PairedPart(int _id);
          /// <summary>
          /// 零件的好坏情况
          /// </summary>
          public abstract bool M_GoodOrBad { get; set; }
          /// <summary>
          /// 零件当前的位置状态
          /// </summary>
          public abstract E_ThePartState M_PartState { get; set; }
          public Action<E_ThePartState> M_PartStateChangeEvent;

          //
          /// <summary>
          /// 零件的好坏状态
          /// </summary>
          public abstract E_PartUseState M_PartUseState { get; set; }
     } 
}
