using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 在移动一个零件的时候旋转一个零件,
     /// </summary>
     public class N_MoveAxis_01_01 : N_MoveAxis_01
     {
          /// <summary>
          /// 零件旋转的轴
          /// </summary>
          //public Vector3 m_PartRotateAxis = new Vector3(1f, 1f, 1f);
          AB_ThePart t_thePart = null;
          /// <summary>
          /// 零件物体
          /// </summary>
          GameObject t_Part = null;
          //public Transform m_PartParent = null;
          public override void fn_move(float _moveValue)
          {
               fnp_FindPartToRotate();
               //if (m_moveLength == 0f &&m_isReachEnd==false)
               //{//把零件链接到动画节点下
               //     Debug.Log("<color=blue>找零件1</color>");
               //     fnp_FindPartToRotate();
                  

               //}
               AB_Spanner t_spanner = GetComponent<AB_Spanner>();
               base.fn_move(_moveValue);
               //if (t_spanner.fni_getRotateValue()<0f)
               //{
               //     //使用比例值来换算
               //     if (m_moveLength == 0f)
               //     {
               //          m_defaultPos = m_move.position;
               //     }
               //     m_moveLength = m_canMoveLength * _moveValue;

               //     Vector3 t_pos = fnp_getNextPos(m_defaultPos, m_moveLength);
               //     m_move.position = t_pos;
               //     if (_moveValue == 0f)
               //     {
               //          m_isReachEnd = true;
               //     }
               //     else
               //     {
               //          m_isReachEnd = false;
               //     }
               //}
               //else
               //{
               //     base.fn_move(_moveValue);
               //}
              

               //if (m_moveLength == m_canMoveLength && m_isReachEnd)
               //{//把零件链接到动画节点下
                    
               //     Debug.Log("<color=blue>找零件2</color>");
     
               //     t_thePart = m_move.gameObject.GetComponentInChildren<AB_ThePart>();
               //     if (t_thePart != null)
               //     {
               //          t_Part = t_thePart.gameObject;
               //          //m_PartParent = t_Part.transform.parent;
               //          AB_SpAni t_spani = GetComponentInChildren<AB_SpAni>();
               //          if (t_spani != null)
               //          {
               //               t_thePart.transform.parent = t_spani.gameObject.transform;
               //          }
               //     }


               //}
              
          }
          protected Transform m_animation = null;
          /// <summary>
          /// 在手柄碰触时刻检查父节点先有无链接零件，如果链接零件，放到旋转动画节点下
          /// </summary>
          private void fnp_FindPartToRotate()
          {
               if (t_Part != null && m_animation!=null)
               {
                    if (t_Part.transform.parent == m_animation)
                    {
                         return;
                    }
               }
               Debug.Log("<color=blue>fnp_FindPartToRotate</color>");
     
               t_thePart = m_move.gameObject.GetComponentInChildren<AB_ThePart>();
               if (t_thePart != null)
               {
                    t_Part = t_thePart.gameObject;
                    //m_PartParent = t_Part.transform.parent;
                    if (m_animation == null)
                    {
                         AB_SpAni t_spani = GetComponentInChildren<AB_SpAni>();
                         if (t_spani != null)
                         {
                              m_animation = t_spani.gameObject.transform;
                              //t_thePart.transform.parent = t_spani.gameObject.transform;
                         } 
                    }
                    t_Part.transform.parent = m_animation;

               }
          }
          public override void fn_reset()
          {
               base.fn_reset();
               //t_thePart = null;
               //t_Part.transform.parent = m_PartParent;
               //t_Part = null;
               //m_PartParent = null;

               Debug.Log("<color=blue>N_MoveAxis_01_01 reset!</color>");
     

          }

     } 
}
