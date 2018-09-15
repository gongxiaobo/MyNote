using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.PointOnPlane;
namespace Assets.Scripts.Connection.Port
{
     [Serializable]
     /// <summary>
     /// 接口可能经过的路线
     /// </summary>
     public abstract class AB_PortPath : MonoBehaviour
     {
          protected virtual void Start() { }
          /// <summary>
          /// 接口的连线位置
          /// </summary>
          public abstract Transform M_PortPos { get; }
          /// <summary>
          /// 接口可能经过的路线
          /// </summary>
          public abstract PortPathData M_PortPath { get; }

         

     }
}
