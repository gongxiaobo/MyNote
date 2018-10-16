using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
using Assets.Scripts.Tool.PointOnPlane;
using Assets.Scripts.Tool.PointInRectangle;
using Assets.Scripts.Tool.GetPointOnDir;
using Assets.Scripts.Tool.ShowLineInEditor;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 实现投影上的矩形排列
     /// </summary>
     public class N_ArrangeOnPlane01 : N_ArrangeOnPlane
     {
          Vector3 m_newPro_0, m_newPro_1;
          public override Vector3[] fn_project(Vector3[] _points, string _name, float _width = 0.0025f)
          {
               if (m_this==null)
               {
                    m_this = gameObject.transform;
               }
               if (m_rectangles.ContainsKey(_name))
               {
                    return null;
               }
               //把点投射到平面
               m_newPro_0 = s_pointOnPlane.fns_pointOnPlane(_points[0], m_this.position, fn_getNormal());
               m_newPro_1 = s_pointOnPlane.fns_pointOnPlane(_points[1], m_this.position, fn_getNormal());
#if UNITY_EDITOR
               //ShowLineInEditor.Instance.fn_PutInDot(_name+"_pre", new Vector3[2] { m_newPro_0, m_newPro_1 }, Color.grey);
#endif
               //如两点投影后的向量不垂直排列方向，做优化处理
               fnp_2pLineNotStand();
               //根据宽度计算一个矩形
               Vector3[] t_rectangle = s_rectangleOnDir.fns_getRectangle(new Vector3[2] { m_newPro_0, m_newPro_1 }, fn_getForward(), _width);
               //
//#if UNITY_EDITOR
//               ShowLineInEditor.Instance.fn_PutInDot(_name + "_rec", new Vector3[4] {
//                    t_rectangle[0], t_rectangle[1], t_rectangle[2], t_rectangle[3] }, Color.cyan);
//#endif
               //for (int i = 0; i < t_rectangle.Length; i++)
               //{
               //     fnp_flag(t_rectangle[i], _name + "_" + i.ToString());
               //}
               //计算矩形是否在已占矩形中，如果占用，向外移动一个宽度单位后再检查
               if (m_Arrange)
               {
                    fnp_findPos(ref t_rectangle);
#if UNITY_EDITOR
                    //ShowLineInEditor.Instance.fn_PutInDot(_name, t_rectangle, Color.red);
#endif
               }
               //计算好位置后保存位置，新建区域
               m_rectangles.Add(_name, new N_Rectangle());
               Vector3[]t_return= new Vector3[2] { m_newPro_0, m_newPro_1 };
               m_rectangles[_name].fn_putIn2Point(t_return);
               m_rectangles[_name].fn_putIn4Point(t_rectangle);
#if UNITY_EDITOR
               //ShowLineInEditor.Instance.fn_PutInDot(_name+"_key", t_return, Color.blue);
#endif
               //返回移动后的位置,结束
               return t_return;
          }
          protected override void fnp_findPos(ref Vector3[] _rec)
          {
               //base.fnp_findPos();
               if (m_rectangles.Count==0)
               {//first value
                    return;
               }
               bool t_returnCheck = false;
               foreach (var item in m_rectangles.Values)
               {//
                    //fnp_check(ref _rec, _movedis*0.5f, item);
                    t_returnCheck=fnp_checkAndMove(ref _rec, item.fn_get4Point());
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

          #region Discarded func
          private void fnp_check(ref Vector3[] _rec, float _movedis, AB_Rectangle item)
          {
               Vector3[] t_oldRec = item.fn_get4Point();
               float t_half = _movedis;
               for (int i = 0; i < 4; i++)
               {
                    if (s_PointInRectangle.fns_InRectangle(t_oldRec, _rec[i]))
                    {//现在点在已有矩阵内部，需要向外移动
                         s_getPointOnDir.fns_MovePointOnDir(ref _rec, fn_getForward(), t_half);
                         m_newPro_0 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_0, fn_getForward(), t_half);
                         m_newPro_1 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_1, fn_getForward(), t_half);
                         fnp_check(ref _rec, t_half, item);

                         //return false;
                    }

               }
               for (int i = 0; i < 4; i++)
               {
                    if (s_PointInRectangle.fns_InRectangle(_rec, t_oldRec[i]))
                    {//已有矩阵点是否在现有矩阵内部
                         s_getPointOnDir.fns_MovePointOnDir(ref _rec, fn_getForward(), t_half);
                         m_newPro_0 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_0, fn_getForward(), t_half);
                         m_newPro_1 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_1, fn_getForward(), t_half);
                         fnp_check(ref _rec, t_half, item);
                    }

               }
          } 
          #endregion
          /// <summary>
          /// 判断矩形是否相交的最新办法
          /// </summary>
          /// <param name="_rec"></param>
          /// <param name="item"></param>
          protected virtual bool fnp_checkAndMove(ref Vector3[] _rec, Vector3[] _oldVector)
          {
               //Vector3[] t_oldRec = _oldVector;
               float t_movedis=0f;
               if (s_PointInRectangle.fns_RectInter(_rec, _oldVector, out t_movedis, false, 0.1f))
               {//表示矩形相交
                    s_getPointOnDir.fns_MovePointOnDir(ref _rec, fn_getForward(), t_movedis);
                    m_newPro_0 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_0, fn_getForward(), t_movedis);
                    m_newPro_1 = s_getPointOnDir.fns_getPointOnDirLine(m_newPro_1, fn_getForward(), t_movedis);
                    return true;
               }
               return false;

          }

          protected void fnp_flag(Vector3 _pos,string _name)
          {
               GameObject t_new = new GameObject(_name);
               t_new.transform.position = _pos;

          }
          /// <summary>
          /// 输入两点间的线段不和排列方向垂直
          /// 那么就取这两点间的中心来重新放置两点位置
          /// </summary>
          protected virtual void fnp_2pLineNotStand()
          {
               if (Vector3.Dot(m_newPro_0 - m_newPro_1, fn_getForward()) == 0)
               {//是垂直状态，那么不用进行移动处理
                    return ;
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
