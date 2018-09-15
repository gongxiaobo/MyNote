using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tool.ShowLineInEditor;
/// <summary>
/// 路径关键点根据指定方向，计算出点的副切线，法线和切线方向，得到切线到法线的旋转
/// 912:需要观察法线的方向,在主要关键点的切线进行平滑处理
/// </summary>
public class N_CaculatePointHard : AB_CaculatePointHard
{


     public override void fn_caculate(Vector3[] _points, Vector3 _axis, out Quaternion[] _roatation)
     {
          m_correctPara = Mathf.Clamp(m_correctPara, 0f, 0.95f);
          //每个点的切线和法线的旋转
          Quaternion[] t_roatation = new Quaternion[_points.Length];
          Vector3[] t_tangents = new Vector3[_points.Length];
          Vector3[] t_binormals = new Vector3[_points.Length];
          Vector3[] t_normals = new Vector3[_points.Length];
          //Debug.Log("<color=blue>blue:</color>" + _points.Length);
          #region optimize tangent
          //临时切线
          Vector3[] t_firstTangent = new Vector3[_points.Length];
          for (int i = 1; i < _points.Length; i++)
          {//找到每一个点的切线单位向量
               t_firstTangent[i] = (_points[i] - _points[i - 1]).normalized;
               if (i == 1)
               {
                    t_firstTangent[0] = t_firstTangent[i];
                    t_tangents[0] = t_firstTangent[i];
               }

          }
          int t_findKeyID = 0;
          for (int i = 1; i < t_firstTangent.Length; i++)
          {//前后两切线的中间值


               t_tangents[i] = t_firstTangent[i];
               if (i == 3)
               {
                    t_findKeyID = i;
                    t_tangents[i] = (t_firstTangent[i - 1] + t_firstTangent[i + 1]).normalized;
               }
               if (i == t_findKeyID + 5)
               {
                    t_findKeyID = i;
                    t_tangents[i] = (t_firstTangent[i - 1] + t_firstTangent[i + 1]).normalized;
               }
               //if (i == t_findKeyID + 2)
               //{
               //     t_tangents[i] = (t_firstTangent[i - 1] + t_firstTangent[i + 1]).normalized;
               //}


          }
          #endregion
          #region style1
          //for (int i = 1; i < _points.Length; i++)
          //{

          //     //切线,这里是计算一个点的前后两点的切线，然后求两切线的和，及取平均值
          //     //Vector3 _tangent = (i != (_points.Length - 1))?((_points[i] - _points[i - 1]) + (_points[i + 1] - _points[i])).normalized:
          //     //     (_points[i] - _points[i - 1]).normalized;
          //     Vector3 _tangent = (_points[i] - _points[i - 1]).normalized;
          //     t_tangents[i] = _tangent;
          //     //副切线
          //     Vector3 t_binormal = Vector3.Cross(_axis, t_tangents[i]).normalized;
          //     t_binormals[i] = t_binormal;
          //     //ShowLineInEditor.Instance.fn_PutInDot(i.ToString(), new Vector3[2] { _points[i],
          //     //     t_binormal*0.5f+_points[i] }, Color.yellow); 
          //     //}

          //     //法线
          //     Vector3 _nornal = Vector3.Cross(t_tangents[i], t_binormals[i]);
          //     t_normals[i] = _nornal;
          //     //旋转
          //     t_roatation[i] = Quaternion.LookRotation(t_tangents[i], _nornal);

          //}
          //////开始点的旋转值
          //Vector3 t_oneTangent = (_points[1] - _points[0]).normalized;
          //t_tangents[0] = t_oneTangent;
          //Vector3 t_oneBinormal = Vector3.Cross(_axis, t_oneTangent).normalized;
          //t_binormals[0] = t_oneBinormal;
          //Vector3 t_onenormal = Vector3.Cross(t_oneTangent, t_oneBinormal);
          //t_normals[0] = t_onenormal;
          //t_roatation[0] = Quaternion.LookRotation(t_oneTangent, t_onenormal); 
          #endregion
          #region style2
          for (int i = 0; i < t_tangents.Length; i++)
          {

               //切线,这里是计算一个点的前后两点的切线，然后求两切线的和，及取平均值

               //Vector3 _tangent = (_points[i] - _points[i - 1]).normalized;
               //t_tangents[i] = _tangent;
               //副切线
               Vector3 t_binormal = Vector3.Cross(_axis, t_tangents[i]).normalized;
               //t_binormals[i] = t_binormal * (i >= (t_tangents.Length - 4) ? -1f : 1f);
               t_binormals[i] = t_binormal;
               //法线
               Vector3 _nornal = Vector3.Cross(t_tangents[i], t_binormals[i]).normalized;
               t_normals[i] = _nornal;
               //旋转
               t_roatation[i] = Quaternion.LookRotation(t_tangents[i], t_normals[i]);

          }

          #endregion
          //t_roatation[0] = Quaternion.LookRotation(t_oneTangent, t_onenormal);

          //ShowLineInEditor.Instance.fn_PutInDot(0.ToString(), new Vector3[2] { _points[0],
          //          t_oneBinormal+_points[0] }, Color.yellow);
          //ShowLineInEditor.Instance.fn_PutInDot(0.ToString() + "normal", new Vector3[2] { _points[0],
          //          t_onenormal*0.2f+_points[0] }, Color.red);

          Vector3 t_checkNormalStart = Vector3.up;
          int t_CheckNormalID = -1;
          for (int i = 0; i < t_binormals.Length; i++)
          {//找出切线和世界指定的坐标轴方向相同导致副切线方向任意
               #region Binormal check
               if (t_binormals[i] == Vector3.zero)
               {
                    if (i == 0)
                    {
                         for (int j = 1; j < t_binormals.Length; j++)
                         {
                              if (t_binormals[j] != Vector3.zero)
                              {
                                   //t_binormals[i] = t_binormals[j];
                                   //t_normals[i] = Vector3.Cross(t_tangents[i], t_binormals[i]);
                                   //t_roatation[i] = Quaternion.LookRotation(t_tangents[i], t_normals[i]);
                                   fnp_getRotation(t_binormals[j], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                                   break;
                              }
                         }
                    }
                    else if (i == t_binormals.Length - 1)
                    {
                         for (int j = t_binormals.Length - 2; j >= 0; j--)
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
                         t_binormals[i] = (t_binormals[i - 1] + t_binormals[i + 1]).normalized;
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
                         t_binormals[i] = t_binormals[i].normalized;
                         //t_binormals[i] += t_binormals[i - 1];
                         fnp_getRotation(t_binormals[i], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                    }

               }
               #endregion

               #region check normal dir
               //需要观察法线的方向
               if (i == 1)
               {
                    t_CheckNormalID = i;
                    t_checkNormalStart = t_normals[i];
               }
               if (i == (t_CheckNormalID + 5))
               {//下一阶段的开点的法线
                    //在跳转到下一个阶段检查时，要检查现在的法线方向和上一个阶段的法线是否反向，如果反向，旋转当前的副切线
                    if (Vector3.Dot(t_checkNormalStart, t_normals[i]) <= -1f)
                    {//法线反向了,需要把这个点的副切线反向,再计算法线，旋转
                         t_binormals[i] *= -1f;
                         fnp_getRotation(t_binormals[i], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                    }
                    t_CheckNormalID = i;
                    t_checkNormalStart = t_normals[i];
               }
               if (i >= 2 && i < (t_binormals.Length - 1) && (i != (t_CheckNormalID + 5)))
               {//除了开始点，结束点，和一组点的开始
                    if (Vector3.Dot(t_checkNormalStart, t_normals[i]) <= -1f)
                    {//法线反向了,需要把这个点的副切线反向,再计算法线，旋转
                         t_binormals[i] *= -1f;
                         fnp_getRotation(t_binormals[i], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                    }
               }
               if (i == (t_binormals.Length - 1))
               {//最后一个点
                    if (Vector3.Dot(t_normals[i - 1], t_normals[i]) <= -1f)
                    {//法线反向了,需要把这个点的副切线反向,再计算法线，旋转
                         t_binormals[i] *= -1f;
                         fnp_getRotation(t_binormals[i], t_tangents[i], i, ref t_binormals, ref t_normals, ref t_roatation);
                    }
               }
               #endregion


               //ShowLineInEditor.Instance.fn_PutInDot(i.ToString(), new Vector3[2] { _points[i],
               //      t_binormals[i]*0.1f+_points[i] }, Color.yellow);
               //ShowLineInEditor.Instance.fn_PutInDot(i.ToString() + "tang", new Vector3[2] { _points[i],
               //     t_tangents[i]*0.1f+_points[i] }, Color.red);
               //ShowLineInEditor.Instance.fn_PutInDot(i.ToString() + "normal", new Vector3[2] { _points[i],
               //     t_normals[i]*0.1f+_points[i] }, Color.blue);
          }

          _roatation = t_roatation;


     }
     /// <summary>
     /// 修改副切线后，重新计算法线和旋转
     /// </summary>
     /// <param name="_bional"></param>
     /// <param name="_tangent"></param>
     /// <param name="_id"></param>
     /// <param name="_bins"></param>
     /// <param name="_normals"></param>
     /// <param name="_rotations"></param>
     protected virtual void fnp_getRotation(Vector3 _bional, Vector3 _tangent, int _id, ref Vector3[] _bins, ref Vector3[] _normals, ref Quaternion[] _rotations)
     {
          _bins[_id] = _bional;
          _normals[_id] = Vector3.Cross(_tangent, _bional).normalized;
          _rotations[_id] = Quaternion.LookRotation(_tangent, _normals[_id]);
     }
}
