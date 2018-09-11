using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tool.ShowLineInEditor;
/// <summary>
/// 路径关键点根据指定方向，计算出点的副切线，法线和切线方向，得到切线到法线的旋转
/// </summary>
public class N_CaculatePointHard : AB_CaculatePointHard
{


     public override void fn_caculate(Vector3[] _points, Vector3 _axis, out Quaternion[] _roatation)
     {
          m_correctPara = Mathf.Clamp(m_correctPara, 0f, 0.9f);
          //每个点的切线和法线的旋转
          Quaternion[] t_roatation = new Quaternion[_points.Length];
          Vector3[] t_tangents = new Vector3[_points.Length];
          Vector3[] t_binormals = new Vector3[_points.Length];
          Vector3[] t_normals = new Vector3[_points.Length];
          //Debug.Log("<color=blue>blue:</color>" + _points.Length);
     
          for (int i = 1; i < _points.Length; i++)
          {
               
               //切线,这里是计算一个点的前后两点的切线，然后求两切线的和，及取平均值
               //Vector3 _tangent = (i != (_points.Length - 1))?((_points[i] - _points[i - 1]) + (_points[i + 1] - _points[i])).normalized:
               //     (_points[i] - _points[i - 1]).normalized;
               Vector3 _tangent = (_points[i] - _points[i - 1]).normalized;
               t_tangents[i] = _tangent;
               //副切线
               Vector3 t_binormal = Vector3.Cross(_axis, _tangent).normalized;
               t_binormals[i] = t_binormal;
               //Debug.Log("<color=blue>t_binormal:</color>" + t_binormal);
               //if (i == 22)
               //{
               //     t_binormals[i] *= -1f;
               //Debug.Log("<color=red>red:</color>" +i+":"+ t_binormal);

               //ShowLineInEditor.Instance.fn_PutInDot(i.ToString(), new Vector3[2] { _points[i],
               //     t_binormal*0.5f+_points[i] }, Color.yellow); 
               //}
              
               //法线
               Vector3 _nornal = Vector3.Cross(_tangent, t_binormal);
               t_normals[i] = _nornal;
               //if (i == 6)
               //{
               //     ShowLineInEditor.Instance.fn_PutInDot(i.ToString() + "normal", new Vector3[2] { _points[i],
               //     _nornal*0.2f+_points[i] }, Color.red); 
               //}
               //旋转
               t_roatation[i] = Quaternion.LookRotation(_tangent, _nornal);

          }
          ////开始点的旋转值
          Vector3 t_oneTangent = (_points[1] - _points[0]).normalized;
          t_tangents[0] = t_oneTangent;
          Vector3 t_oneBinormal = Vector3.Cross(_axis, t_oneTangent).normalized;
          t_binormals[0] = t_oneBinormal;
          Vector3 t_onenormal = Vector3.Cross(t_oneTangent, t_oneBinormal);
          t_normals[0] = t_onenormal;
          t_roatation[0] = Quaternion.LookRotation(t_oneTangent, t_onenormal);
          //t_roatation[0] = Quaternion.LookRotation(t_oneTangent, t_onenormal);
          
          //ShowLineInEditor.Instance.fn_PutInDot(0.ToString(), new Vector3[2] { _points[0],
          //          t_oneBinormal+_points[0] }, Color.yellow);
          //ShowLineInEditor.Instance.fn_PutInDot(0.ToString() + "normal", new Vector3[2] { _points[0],
          //          t_onenormal*0.2f+_points[0] }, Color.red);
          for (int i = 0; i <t_binormals.Length ; i++)
          {//找出切线和世界指定的坐标轴方向相同导致副切线方向任意
               if (t_binormals[i]==Vector3.zero)
               {
                    if (i==0)
                    {
                         for (int j = 1; j < t_binormals.Length; j++)
                         {
                              if (t_binormals[j]!=Vector3.zero)
                              {
                                   //t_binormals[i] = t_binormals[j];
                                   //t_normals[i] = Vector3.Cross(t_tangents[i], t_binormals[i]);
                                   //t_roatation[i] = Quaternion.LookRotation(t_tangents[i], t_normals[i]);
                                   fnp_getRotation(t_binormals[j], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                                   break;
                              }
                         }
                    }
                    else if (i==t_binormals.Length-1)
                    {
                         for (int j = t_binormals.Length-2; j >=0; j--)
                         {
                              if (t_binormals[j] != Vector3.zero)
                              {
                                   
                                   fnp_getRotation(t_binormals[j], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                                   break;
                              }
                         }
                    }
                    else
                    {
                         //Debug.Log("<color=red>t_binormals[i]==Vector3.zero </color>"+i);
                         t_binormals[i] = t_binormals[i - 1]+ t_binormals[i + 1];
                         fnp_getRotation(t_binormals[i], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                    }
                   

               }

            
               //判断上前一根副切线的方向和现在的副切线的方向情况，如果是相反，那么选择现在的副切线方向和前面的切线方向一致
               if (i >= 1)
               {
                   
                    while (Vector3.Dot(t_binormals[i], t_binormals[i - 1]) <= m_correctPara)
                    {//处理副切线角度在大于90度
                         //Debug.Log("<color=red>两副切线方向点乘 < 0.3f：</color>" + i);
                         t_binormals[i] += t_binormals[i - 1];
                         //t_binormals[i] += t_binormals[i - 1];
                         fnp_getRotation(t_binormals[i], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                    }

               }

               //ShowLineInEditor.Instance.fn_PutInDot(i.ToString(), new Vector3[2] { _points[i],
               //      t_binormals[i]*0.1f+_points[i] }, Color.yellow); 
          }

          _roatation = t_roatation;

          
     }
     protected virtual void fnp_getRotation(Vector3 _bional, Vector3 _tangent, int _id, ref Vector3[] _bins, ref Vector3[] _normals, ref Quaternion[] _rotations)
     {
          _bins[_id] = _bional;
          _normals[_id] = Vector3.Cross(_tangent, _bional);
          _rotations[_id] = Quaternion.LookRotation(_tangent, _normals[_id]);
     }
}
