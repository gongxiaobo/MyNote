using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 线选择面板的当前位置
     /// </summary>
     public abstract class AB_CloseLastUI : MonoBehaviour
     {

          public abstract A_TriggerObj M_LastUI { get; set; }
     } 
}
