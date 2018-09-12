//using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Tool.GetPointOnDir;
using Assets.Scripts.Tool.PointInRectangle;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 平面的基础实现，获取法线和前向向量
     /// 排序基础实现
     /// 生成矩形区域的实现
     /// </summary>
     public class N_Plane : AB_Plane
     {
          protected override void Start()
          {
               base.Start();
               S_Planes.Instance.fn_login(m_belongToCabinet, m_PlaneName, this);
          }
          /// <summary>
          /// 矩形区域
          /// </summary>
          protected Dictionary<string, AB_Rectangle> m_rectangles = new Dictionary<string, AB_Rectangle>();
          private Transform m_this;

          protected Transform M_this
          {
               get
               {
                    if (m_this == null)
                    {
                         m_this = gameObject.transform;
                    }
                    return m_this;
               }
               //set { m_this = value; }
          }
          #region normal and forward dir
          GetNormal m_planeNormal;
          protected Transform m_forward = null;
          public override Vector3 fn_getNormal()
          {
               m_planeNormal = GetComponent<GetNormal>();
               if (m_planeNormal != null)
               {
                    return m_planeNormal.fn_Normal(true);
               }
               else
               {
                    return Vector3.up;
               }
          }

          public override Vector3 fn_getForward()
          {
              
               if (m_forward == null)
               {
                    m_forward = transform.FindInChild("forwardObj");
               }
               if (m_forward != null)
               {
                    return (m_forward.position - M_this.position).normalized;
               }
               return Vector3.forward;
          }
         
         
          #endregion
          public override void fn_WireRomoved(string _wireName)
          {
               if (m_Arrange==false)
               {
                    return;
               }
               if (m_rectangles.ContainsKey(_wireName))
               {
                    m_rectangles[_wireName] = null;
                    m_rectangles.Remove(_wireName);
               }
          }
          protected Vector3 m_newPro_0, m_newPro_1;
          public override Vector3[] fn_project(Vector3[] _points, string _wireName, float _wireR = 0.0025f)
          {
               return _points;
          }
          /// <summary>
          /// 需要把矩形移动到不和其他已有的矩形相交区域
          /// </summary>
          /// <param name="_rec"></param>
          protected override void fnp_findPos(ref Vector3[] _rec)
          {
               if (m_rectangles.Count == 0)
               {//first value
                    return;
               }
               bool t_returnCheck = false;
               foreach (var item in m_rectangles.Values)
               {//
                    //fnp_check(ref _rec, _movedis*0.5f, item);
                    t_returnCheck = fnp_checkAndMove(ref _rec, item.fn_get4Point());
                    if (t_returnCheck)
                    {//检查到矩形相交，需要停止当前的检查
                         break;
                    }
               }
               if (t_returnCheck)
               {//检查到矩形相交，需要把矩形移动后再次进行检查
                    fnp_findPos(ref _rec);
               }
          }
          /// <summary>
          /// 判断矩形是否相交的最新办法,如果相交，移动矩形和两关键点
          /// </summary>
          /// <param name="_rec"></param>
          /// <param name="_oldVector"></param>
          /// <returns>true表示相交</returns>
          protected virtual bool fnp_checkAndMove(ref Vector3[] _rec, Vector3[] _oldVector)
          {
               //Vector3[] t_oldRec = _oldVector;
               float t_movedis = 0f;
               if (s_PointInRectangle.fns_RectInter(_rec, _oldVector, out t_movedis, false, 0.1f))
               {//表示矩形相交
                    s_getPointOnDir.fns_MovePointOnDir(ref _rec, fn_getForward(), t_movedis);
                    m_newPro_0 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_0, fn_getForward(), t_movedis);
                    m_newPro_1 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_1, fn_getForward(), t_movedis);
                    return true;
               }
               return false;

          }
          /// <summary>
          /// 输入两点间的线段不和排列方向垂直
          /// 那么就取这两点间的中心来重新放置两点位置
          /// </summary>
          protected virtual void fnp_2pLineNotStand()
          {
               if (Vector3.Dot(m_newPro_0 - m_newPro_1, fn_getForward()) == 0)
               {//是垂直状态，那么不用进行移动处理
                    return;
               }
               //求得两点连线中间点位置
               Vector3 t_center = Vector3.Lerp(m_newPro_0, m_newPro_1, 0.5f);
               //第一个点的移动位置计算
               Vector3 t_0 = m_newPro_0 - t_center;
               float t_0_dis = Vector3.Magnitude(Vector3.Project(t_0, fn_getForward()));
               m_newPro_0 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_0,
                    ((Vector3.Dot(t_0, fn_getForward()) > 0) ? -1f : 1f) * fn_getForward(), t_0_dis);

               Vector3 t_1 = m_newPro_1 - t_center;
               float t_1_dis = Vector3.Magnitude(Vector3.Project(t_1, fn_getForward()));
               m_newPro_1 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_1,
                    ((Vector3.Dot(t_1, fn_getForward()) > 0) ? -1f : 1f) * fn_getForward(), t_1_dis);



          }
     }
}
