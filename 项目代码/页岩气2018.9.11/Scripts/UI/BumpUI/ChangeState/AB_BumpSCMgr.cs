using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 每个泵的管理参数分发
     /// </summary>
     public abstract class AB_BumpSCMgr : MonoBehaviour
     {

          protected virtual void Start() { }
          public abstract void fn_sendChange(int _itemID);
     } 
}
