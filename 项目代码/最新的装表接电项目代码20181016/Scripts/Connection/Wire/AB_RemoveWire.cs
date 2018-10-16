using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.Wire
{
     /// <summary>
     /// 电线的拆卸功能
     /// </summary>
     public abstract class AB_RemoveWire : MonoBehaviour
     {
          /// <summary>
          /// 初始化数据，在拆线时，修改链接接口的类引用
          /// </summary>
          /// <param name="_handleEvent"></param>
          public abstract void fn_init(string _info, AB_HandleEvent[] _handleEvent);
          /// <summary>
          /// 拆线
          /// </summary>
          public abstract void fn_remove();
     }
}
