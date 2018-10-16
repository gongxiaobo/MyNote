//using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 装表接电中的所有平面的集合管理类
     /// </summary>
     public class S_Planes : GenericSingletonClass<S_Planes>
     {
          protected Dictionary<E_CabinetName, Dictionary<E_PlaneName, AB_Plane>> m_allPlanes =
               new Dictionary<E_CabinetName, Dictionary<E_PlaneName, AB_Plane>>();
          /// <summary>
          /// 注册平面
          /// </summary>
          /// <param name="_cabinet">柜体名称</param>
          /// <param name="_planeName">平面名称</param>
          /// <param name="_thePlane">平面投影类的引用</param>
          public void fn_login(E_CabinetName _cabinet, E_PlaneName _planeName, AB_Plane _thePlane)
          {
               if (_thePlane == null || _cabinet== E_CabinetName.e_cabinet0 || _planeName== E_PlaneName.e_plane_0)
               {
                    return;
               }
               if (!m_allPlanes.ContainsKey(_cabinet))
               {
                    m_allPlanes.Add(_cabinet, new Dictionary<E_PlaneName, AB_Plane>());
                    
               }
               if (!m_allPlanes[_cabinet].ContainsKey(_planeName))
               {
                    m_allPlanes[_cabinet].Add(_planeName, _thePlane);
               }
               else
               {

                    Debug.Log("<color=red>a cabinet contains same name </color>" + _planeName);
     
               }

          }
          /// <summary>
          /// 获取指定的平面
          /// </summary>
          /// <param name="_cabinet">柜体名称</param>
          /// <param name="_planeName">平面名称</param>
          /// <returns>指定平面名称类的引用</returns>
          public AB_Plane fn_getPlane(E_CabinetName _cabinet, E_PlaneName _planeName)
          {
               if (m_allPlanes.ContainsKey(_cabinet))
               {
                    if (m_allPlanes[_cabinet].ContainsKey(_planeName))
                    {
                         return m_allPlanes[_cabinet][_planeName];
                    }
               }
               return null;
          }
          /// <summary>
          /// 当一根线删除时，移除平面排序矩形区域
          /// </summary>
          /// <param name="_wireName"></param>
          public void fn_removeWire(string _wireName)
          {
               foreach (var item in m_allPlanes.Values)
               {
                    foreach (var _plane in item.Values)
                    {
                         _plane.fn_WireRomoved(_wireName);
                    }
               }
          }
     }
}
