using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 主要是处理一个物体的移动，触发另一个物体的移动
     /// 播放不同点的声音播放
     /// </summary>
     public class Door_90_01 : Door_90
     {
          //上一次的记录值（0，1）
          protected float m_recordValue = 0f;
          protected float m_moveValue = 0f;
          protected override void fn_playAniTo(float _time)
          {
               base.fn_playAniTo(_time);
               m_moveValue = _time;
               fnp_triggerMove();
          }
          /// <summary>
          /// 类似撞击一个物体，撞击前要先回到起点，在移动到终点，完成一次撞击
          /// </summary>
          protected virtual void fnp_triggerMove()
          {

               //Debug.Log("<color=blue>blue:</color>" + m_moveValue);
     
               if (m_move==null)
               {
                    m_move = GetComponent<AB_MoveAxis>();
               }
               if (m_moveValue == m_max && m_recordValue == 0f)
               {//
                    m_recordValue = m_max;
                    if (m_move != null)
                    {//完成一次撞击
                         m_move.fn_move(1f);
                    }
                    //fnp_playSound(m_recordValue);
     
                    //return;
               }
               if (m_moveValue == 0f && m_recordValue == m_max)
               {//回到开始点
                    m_recordValue = 0f;
                    //fnp_playSound(m_recordValue);
                    //return;
               }
               fnp_playSound(m_moveValue);
          }
          protected AB_MoveAxis m_move = null;
          /// <summary>
          /// 根据不同位置，播放不同的声音
          /// </summary>
          /// <param name="_id"></param>
          protected virtual void fnp_playSound(float _id)
          {
               if (_id==m_min)
               {//碰撞
                    if (m_minHit)
                    {
                         return;
                    }
                    m_minHit = true;
                    S_SoundComSingle.Instance.fnp_sound("metal_hit");
               }
               else if (_id==m_max)
               {//开始位置
                    if (m_maxHit)
                    {
                         return;
                    }
                    m_maxHit = true;
                    S_SoundComSingle.Instance.fnp_sound("metal_hit");
               }
               else
               {
                    m_maxHit = false;
                    m_minHit = false;
                    S_SoundComSingle.Instance.fnp_soundPlaying("frictional01");
               }
               
          }
          bool m_maxHit = false;
          bool m_minHit = false;
          public override void fn_endControl()
          {
               base.fn_endControl();
               S_SoundComSingle.Instance.fnp_soundPlaying("frictional01",false);
          }
         

     } 
}
