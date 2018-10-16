using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AB_CirclePoint : MonoBehaviour
{
     /// <summary>
     /// 圆半径
     /// </summary>
     public float m_circleR = 1f;//圆半径

     /// <summary>
     /// 拆分圆为几份
     /// </summary>
     private float m_divid = 4f;
     /// <summary>
     /// 拆分圆为几份,至少拆4份
     /// </summary>
     public float Divid
     {
          get { return m_divid; }
          set
          {
               if (value<=4)
               {
                    m_divid = 4;
               }
               else
               {
                    m_divid = value;
               }
          }
     }
     /// <summary>
     /// 把圆的弧度分为m_divid份后的弧度值
     /// </summary>
     /// <returns>一小段弧度值</returns>
     protected virtual float fnp_dis2angle()
     {
          return (Mathf.PI * 2f) / Divid;
     }
     /// <summary>
     /// 获取圆上的点
     /// </summary>
     /// <returns></returns>
     public abstract Vector3[] fn_getCirclePoints();
}
