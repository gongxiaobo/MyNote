using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 工具的初始化位置的设置
     /// </summary>
     public abstract class AB_ToolInitPos : MonoBehaviour
     {
          /// <summary>
          /// 设置工具的位置
          /// </summary>
          /// <param name="_pos"></param>
          public abstract void fn_setPos(float _pos);
          /// <summary>
          /// 设置已有位置
          /// </summary>
          /// <param name="_pos">位置编号</param>
          public abstract void fn_setLevelPos(int _pos);
     } 
}
