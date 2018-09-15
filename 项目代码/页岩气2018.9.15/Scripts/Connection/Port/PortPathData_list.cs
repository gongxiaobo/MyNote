using System;
using System.Collections.Generic;
using Assets.Scripts.Connection.PointOnPlane;

namespace Assets.Scripts.Connection.Port
{
     [Serializable]
     public class PortPathData_list
     {
          public List<E_PlaneName> m_path = new List<E_PlaneName>();
     }
}
