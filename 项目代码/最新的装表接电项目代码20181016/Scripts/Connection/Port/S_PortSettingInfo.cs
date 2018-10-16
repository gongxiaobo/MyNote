using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Connection.PointOnPlane;
namespace Assets.Scripts.Connection.Port
{
     /// <summary>
     /// 获取一个柜体相交平面的信息
     /// </summary>
     public class S_PortSettingInfo : GenericSingletonClass<S_PortSettingInfo>
     {
          protected Dictionary<E_CabinetName, PortPathSetting> mPortSetting = new Dictionary<E_CabinetName, PortPathSetting>();
          public void fn_loging(E_CabinetName _cabinet, PortPathSetting _setting)
          {
               if (!mPortSetting.ContainsKey(_cabinet) && _setting!=null)
               {
                    mPortSetting.Add(_cabinet, _setting);
               }
          }
          /// <summary>
          /// 输入柜体和柜体的两个平面，返回这个两个平面是否相交
          /// </summary>
          /// <param name="_cabinet"></param>
          /// <param name="_plane1"></param>
          /// <param name="_plane2"></param>
          /// <returns></returns>
          public bool fn_isSamePlane(E_CabinetName _cabinet, E_PlaneName _plane1, E_PlaneName _plane2)
          {
               if (mPortSetting.ContainsKey(_cabinet))
               {
                    List<PortPathSettingData> tIntersect = mPortSetting[_cabinet].mIntersect;
                    for (int i = 0; i < tIntersect.Count; i++)
                    {
                         if (tIntersect[i].mPlane1==_plane1 && tIntersect[i].mPlane2==_plane2)
                         {
                              return true;
                         }
                         if (tIntersect[i].mPlane1==_plane2 && tIntersect[i].mPlane2==_plane1)
                         {
                              return true;
                         }
                    }
               }
               return false;
          }
     }
}
