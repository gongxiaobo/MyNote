using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 声音链的播放
     /// </summary>
     public abstract class AB_soundChain : MonoBehaviour
     {
          /// <summary>
          /// 开始播放声音链
          /// </summary>
          /// <param name="_chain"></param>
          public abstract void fn_startChain(string[] _chain);
          /// <summary>
          /// 停止声音链
          /// </summary>
          public abstract void fn_endChain();
          /// <summary>
          /// 声音链名称
          /// </summary>
          public string m_chainname;
     }

}