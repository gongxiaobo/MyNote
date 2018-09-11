using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 可以被拉出物体的
     /// </summary>
     public abstract class AB_CanPullOutObj : MonoBehaviour
     {
          protected virtual void Start() { }
          public abstract void fn_ToIndependent(GameObject _parent);
          public abstract void fn_ToAttach();

     }
}
