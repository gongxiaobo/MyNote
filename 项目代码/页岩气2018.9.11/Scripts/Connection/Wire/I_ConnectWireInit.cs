using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 初始化电线的接口
     /// 主要用于电线使用程序链接接口的初始化
     /// </summary>
     public interface I_ConnectWireInit
     {
          /// <summary>
          /// 初始化电线
          /// </summary>
          /// <param name="_initString"></param>
          void fni_InitWire(string _initString);

     } 
}
