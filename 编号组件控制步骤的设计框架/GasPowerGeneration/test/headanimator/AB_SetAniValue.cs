using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 设置两个动画值
/// </summary>
public abstract class AB_SetAniValue : MonoBehaviour {
     /// <summary>
     /// 给动画融合传值
     /// </summary>
     /// <param name="_value1">[-2,2]</param>
     /// <param name="_value2">[-2,2]</param>
     public abstract void fn_set(float _value1, float _value2);
}
