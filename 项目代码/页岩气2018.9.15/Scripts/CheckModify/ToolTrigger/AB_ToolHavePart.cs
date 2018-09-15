using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 工具上的状态类
     /// 表示工具上有无零件的状态
     /// </summary>
     public abstract class AB_ToolHavePart : MonoBehaviour
     {
          public abstract E_ToolHavePart M_tollHavePart { get; set; }
        
     } 
}
