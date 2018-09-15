using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public static class FindTarget
     {
          /// <summary>
          /// 在子类中查找指定名称的物体
          /// </summary>
          /// <param name="trans"></param>
          /// <param name="goName"></param>
          /// <returns></returns>
          public static Transform FindInChild(this Transform trans, string goName)
          {
               Transform[] t_all = trans.GetComponentsInChildren<Transform>();
               for (int i = 0; i < t_all.Length; i++)
               {
                    if (t_all[i].name == goName)
                    {
                         return t_all[i];
                    }
               }

               return null;
          }
          /// <summary>
          /// 获取子节点下类型为T的类型
          /// </summary>
          /// <typeparam name="T"></typeparam>
          /// <param name="_trans"></param>
          /// <param name="_depth">默认深度为所有子节点查找</param>
          /// <returns>返回一个list</returns>
          public static List<T> FindInChlid<T>(this Transform _trans, byte _depth = 0)
          {
               List<T> t_all = new List<T>();
               if (_depth == 0)
               {
                    T[] t_ = _trans.GetComponentsInChildren<T>();
                    for (int i = 0; i < t_.Length; i++)
                    {
                         //if (t_all[i].name == goName)
                         //{
                         //     return t_all[i];
                         //}
                         t_all.Add(t_[i]);
                    }




               }
               else
               {
                    for (int i = 0; i < _trans.childCount; i++)
                    {
                         T t_t = _trans.GetChild(i).GetComponent<T>();
                         if (t_t != null)
                         {
                              t_all.Add(t_t);
                         }
                    }

               }
               return t_all;
          }
          public static Transform FindFisrtChild(this Transform _trans, string _name)
          {
               List<Transform> t_firstchild = new List<Transform>();
               t_firstchild = _trans.FindInChlid<Transform>(1);
               for (int i = 0; i < t_firstchild.Count; i++)
               {
                    if (t_firstchild[i].name == _name)
                    {
                         return t_firstchild[i];
                    }
               }
               return null;
          }
          /// <summary>
          /// 获取子节点下T类型的数组
          /// </summary>
          /// <typeparam name="T"></typeparam>
          /// <param name="_trans"></param>
          /// <param name="_depth">深度值 0查找所有子节点，1为第一层子节点</param>
          /// <returns>T[]</returns>
          public static T[] FindInChlidArray<T>(this Transform _trans, byte _depth = 0)
          {
               if (_depth == 0)
               {
                    return _trans.GetComponentsInChildren<T>();
               }
               List<T> tlist = _trans.FindInChlid<T>(_depth);

               if (tlist != null)
               {
                    if (tlist.Count > 0)
                    {
                         T[] t_getall = new T[tlist.Count];
                         tlist.CopyTo(t_getall, 0);
                         //for (int i = 0; i < tlist.Count; i++)
                         //{
                         //     t_getall[i] = tlist[i];
                         //}
                         return t_getall;
                    }
               }
               return null;
          }
          /// <summary>
          /// 在同级中找到指定名称的物体
          /// </summary>
          /// <param name="_trans"></param>
          /// <param name="_name"></param>
          /// <returns></returns>
          public static Transform FindSibling(this Transform _trans, string _name)
          {
               if (_trans.parent == null)
               {
                    return _trans;
               }
               for (int i = 0; i < _trans.parent.childCount; i++)
               {
                    Transform t_child = _trans.parent.GetChild(i);
                    if (t_child.name == _name)
                    {
                         return t_child;
                    }

               }
               return null;
          }

     }

}