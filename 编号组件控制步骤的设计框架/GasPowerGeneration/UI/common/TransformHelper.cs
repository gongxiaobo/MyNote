using System;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     /// <summary>
     /// Transform组件助手类
     /// </summary>
     public static class TransformHelper
     {
          /// <summary>
          /// 查找子物体（递归查找）
          /// </summary>
          /// <param name="trans">父物体</param>
          /// <param name="goName">子物体的名称</param>
          /// <returns>找到的相应子物体</returns>
          public static Transform FindChild(Transform trans, string goName)
          {
               Transform child = trans.Find(goName);
               if (child != null)
                    return child;

               Transform go = null;
               for (int i = 0; i < trans.childCount; i++)
               {
                    child = trans.GetChild(i);
                    go = FindChild(child, goName);
                    if (go != null)
                         return go;
               }
               //Debug.Log("未找到：" + goName);
               return null;
          }
          //public static Transform FindInChild(this Transform trans, string goName)
          //{
          //     Transform[] t_all = trans.GetComponentsInChildren<Transform>();
          //     for (int i = 0; i < t_all.Length; i++)
          //     {
          //          if (t_all[i].name==goName)
          //          {
          //               return t_all[i];
          //          }
          //     }

          //     return null;
          //}
     }


}