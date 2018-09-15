using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 设置状态值的类型
     /// </summary>
     public abstract class AB_SetState
     {
          /// <summary>
          /// 设置自己的状态值
          /// </summary>
          /// <param name="_name"></param>
          /// <param name="_value"></param>
          /// <param name="_HandleEvent"></param>
          public abstract void fn_setState(string _name, string _value, AB_HandleEvent _HandleEvent);
     } 
}
