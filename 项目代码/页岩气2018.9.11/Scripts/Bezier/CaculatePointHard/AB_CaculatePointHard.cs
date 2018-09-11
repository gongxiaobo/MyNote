﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 输入连续的点，和空间坐标系，得到切线到坐标系的法线的旋转
/// </summary>
public abstract class AB_CaculatePointHard {
     /// <summary>
     /// 传入连续的点，得到每个点的旋转
     /// </summary>
     /// <param name="_points"></param>
     /// <param name="_axis"></param>
     /// <param name="_roatation"></param>
     public abstract void fn_caculate(Vector3[] _points, Vector3 _axis,out Quaternion[] _roatation);
     /// <summary>
     /// 修正相临切线的偏移系数，参数在[0，0.9],参数越大，计算次数多
     /// </summary>
     public float m_correctPara = 0.3f;
}
