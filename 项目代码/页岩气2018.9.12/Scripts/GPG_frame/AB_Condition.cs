using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 条件判断
     /// </summary>
     [RequireComponent(typeof(AB_Name))]
     public abstract class AB_Condition : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 给定条件名称后返回条件检查结果
          /// </summary>
          /// <param name="_what"></param>
          /// <returns></returns>
          public abstract bool fn_check(string _what);
     } 
}
