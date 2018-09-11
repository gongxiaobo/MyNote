using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Bezier.BirthMesh.MyInterface;
/// <summary>
/// 通过传入点序列来生成管道模型
/// </summary>
public class N_BirthMeshUsePoint : N_BirthMesh, I_PutKeyPoint
{
     #region Discarded func
     protected override void fnp_findChildPoint()
     {//取消找子节点
          //base.fnp_findChildPoint();
     }
     protected override void fnp_needRefresh(int i)
     {
          //base.fnp_needRefresh(i);
          //需要新的规则来判断关键点的刷新问题
          //if (m_lastPointPos[i] != m_Points[i].transform.position)
          //{
          //     m_refresh = true;
          //}
     }
     protected override void fnp_findKeyPoint()
     {
          //base.fnp_findKeyPoint();
          //需要新的规则来传入关键点

     } 
     #endregion
     public override void fn_init()
     {
          base.fn_init();
     }

     #region I_PutKeyPoint
     Vector3[] m_keys;
     /// <summary>
     /// 把新的点放入到关键点数值中,
     /// 在放入前比较新老数组的值是否不同，
     /// 如果不同就替换，就替换最新的数组
     /// </summary>
     /// <param name="_keys"></param>
     public void fni_putKeyPoint(Vector3[] _keys)
     {
          m_keys = _keys;
          if (m_lastPointPos!=null)
          {//已经生成过模型
               bool t_dif = false;
               if (m_lastPointPos.Length!=m_keys.Length)
               {
                    t_dif = true;
               }
               else
               {
                    
                    for (int i = 0; i < m_lastPointPos.Length; i++)
                    {
                         if (m_lastPointPos[i] != m_keys[i])
                         {
                              t_dif = true; break;
                         }
                    }
                   
               }
               if (t_dif)
               {
                    m_lastPointPos = m_keys;
                    //m_refresh = true;
                    //fn_refresh();
               }
          }
          else
          {
               m_lastPointPos = m_keys;
          }
          
     } 
     #endregion
}
