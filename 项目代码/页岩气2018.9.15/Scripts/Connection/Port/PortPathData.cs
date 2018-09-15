using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Connection.PointOnPlane;
namespace Assets.Scripts.Connection.Port
{
     [Serializable]
     [CreateAssetMenu(fileName = "xx", menuName = "PortPathData/PortPathData1", order = 1)]
     public class PortPathData : ScriptableObject
     {
          public E_CabinetName m_CabinetName;
          /// <summary>
          /// 可链接电线的数量
          /// </summary>
          public short m_WireNumber = 1;
          [SerializeField]
          public List<PortPathData_list> m_pathname = new List<PortPathData_list>();
     }
}
