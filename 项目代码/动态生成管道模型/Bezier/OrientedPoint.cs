using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OrientedPoint  {

     public Vector3 m_position;
     public Quaternion m_rotation;
     public OrientedPoint(Vector3 _pos, Quaternion _rotateion)
     {
          this.m_position = _pos;
          this.m_rotation = _rotateion;
     }
     public Vector3 fn_localToWorld(Vector3 _point)
     {
          return m_position + m_rotation * _point;
     }
     public Vector3 fn_WorldToLocal(Vector3 _point)
     {
          return Quaternion.Inverse(m_rotation) * (_point - m_position);
     }
     public Vector3 fn_LocalToWorldDirection(Vector3 _dir)
     {
          return m_rotation * _dir;
     }
}
