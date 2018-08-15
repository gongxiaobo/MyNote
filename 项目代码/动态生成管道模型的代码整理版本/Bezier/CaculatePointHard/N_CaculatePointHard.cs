using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_CaculatePointHard : AB_CaculatePointHard
{


     public override void fn_caculate(Vector3[] _points, Vector3 _axis, out Quaternion[] _roatation)
     {
          //每个点的切线和法线的旋转
          Quaternion[] t_roatation = new Quaternion[_points.Length];
          for (int i = 1; i < _points.Length; i++)
          {
             
               //切线,这里是计算一个点的前后两点的切线，然后求两切线的和，及取平均值
               Vector3 _tangent = (i != (_points.Length - 1))?((_points[i] - _points[i - 1]) + (_points[i + 1] - _points[i])).normalized:
                    (_points[i] - _points[i - 1]).normalized;
               
               //副切线
               Vector3 t_binormal = Vector3.Cross(_axis, _tangent).normalized;
               //法线
               Vector3 _nornal = Vector3.Cross(_tangent, t_binormal);
               //旋转
               t_roatation[i] = Quaternion.LookRotation(_tangent, _nornal);
             
          }
          ////开始点的旋转值
          Vector3 t_oneTangent = (_points[1] - _points[0]).normalized;
          Vector3 t_oneBinormal = Vector3.Cross(_axis, t_oneTangent).normalized;
          Vector3 t_onenormal = Vector3.Cross(t_oneTangent, t_oneBinormal);
          t_roatation[0] = Quaternion.LookRotation(t_oneTangent, t_onenormal);
          _roatation = t_roatation;
     }
}
