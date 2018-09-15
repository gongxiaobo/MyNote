using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// birth bezier curve point
/// </summary>
public class N_BezierPoint : AB_BezierPoint
{
     public override Vector3 fn_getPoint(Vector3[] _controlPoint, float _tpos)
     {
          _tpos = Mathf.Clamp01(_tpos);
          Vector3[] t_rusult = fn_getPointArray(_controlPoint, _tpos);
          if (t_rusult!=null)
          {
               return fnp_VectorLerp(t_rusult[0], t_rusult[1], _tpos);
          }
          return Vector3.zero;
     }
     /// <summary>
     /// a vector lerp b
     /// </summary>
     /// <param name="_p0">a</param>
     /// <param name="_p1">b</param>
     /// <param name="_t">time[0-1]</param>
     /// <returns>(1-t)*a+t*b</returns>
     protected Vector3 fnp_VectorLerp(Vector3 _p0, Vector3 _p1,float _t)
     {
          return (1f - _t) * _p0 + _t * _p1;
     }
     /// <summary>
     /// caculate n control point bezeir 
     /// </summary>
     /// <param name="_controlPoint">array point</param>
     /// <param name="_tpos"></param>
     /// <returns>(n-1) array vector </returns>
     public Vector3[] fn_getPointArray(Vector3[] _controlPoint, float _tpos)
     {
          if (_controlPoint.Length<2)
          {
               return null;
          }
          if (_controlPoint.Length==2)
          {//just two point
               return _controlPoint;
          }
          else
          {
               Vector3[] t_vectors = new Vector3[_controlPoint.Length - 1];
               for (int i = 1; i < _controlPoint.Length; i++)
               {
                    t_vectors[i - 1] = fnp_VectorLerp(_controlPoint[i - 1], _controlPoint[i], _tpos);
               }

               return fn_getPointArray(t_vectors, _tpos);
          }
          
     }


     public override void fn_getBezierPoint(Vector3[] _controlPoint, float _tpos, Vector3 _axis, out Vector3 _pos, out Vector3 _nornal, out Quaternion _rotation)
     {
          Vector3[] t_rusult = fn_getPointArray(_controlPoint, _tpos);
          //位置
          _pos = fnp_VectorLerp(t_rusult[0], t_rusult[1], _tpos);
          //切线
          Vector3 _tangent = (t_rusult[1] - t_rusult[0]).normalized;
          //副切线
          Vector3 t_binormal = Vector3.Cross(_axis, _tangent).normalized;
          //法线
          _nornal = Vector3.Cross(_tangent, t_binormal);
          //旋转
          _rotation = Quaternion.LookRotation(_tangent, _nornal);
     }
}
