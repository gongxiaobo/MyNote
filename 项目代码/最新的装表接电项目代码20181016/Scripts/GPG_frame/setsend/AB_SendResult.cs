using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 产生触发结果的发送类
     /// </summary>
     public abstract class AB_SendResult
     {
          /// <summary>
          /// 发送对应名称的反射结果
          /// </summary>
          /// <param name="_name"></param>
          /// <param name="_resultAction"></param>
          /// <param name="_HandleEvent"></param>
          public abstract void fn_SendResult(string _name, AB_ResultAction _resultAction, AB_HandleEvent _HandleEvent);
     } 
}
