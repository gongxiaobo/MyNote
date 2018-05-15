using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 获取位置，通过名称
     /// </summary>
     public abstract class AB_GetPos : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          public abstract Vector3 fn_getPos(string _name);

     } 
}
