using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.PointOnPlane;
using System;
namespace Assets.Scripts.Connection.Port
{
     [Serializable]
     [CreateAssetMenu(fileName = "setting", menuName = "PortPathData/PortPathDataSetting", order = 2)]
     public class PortPathSetting : ScriptableObject
     {
          public E_CabinetName m_CabinetName;
          [SerializeField]
          /// <summary>
          /// 相交平面
          /// </summary>
          public List<PortPathSettingData> mIntersect = new List<PortPathSettingData>();
     }
}
