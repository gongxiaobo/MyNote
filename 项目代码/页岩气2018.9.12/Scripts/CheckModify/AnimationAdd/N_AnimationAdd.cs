using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_AnimationAdd : AB_AnimationAdd
     {

          protected float m_aniStartTime = 0f;
          public override float M_AniStartTime
          {
               get
               {
                    return m_aniStartTime;
               }
               set
               {
                    m_aniStartTime = value;
                    m_timeNow = value;
               }
          }
          public float m_addSpace = 0.01f;
          public override float M_AddSpace
          {
               get
               {
                    return m_addSpace;
               }
               set
               {
                    m_addSpace = value;
               }
          }
          AB_SpAni m_Ani = null;
          TimeComponent m_timeComponent = null;
          public override void fn_StartAddAni()
          {
               if (m_timeNow==1f)
               {
                    return;
               }
               if (fnp_findAni()==false)
               {
                    return;
               }
               if (m_timeComponent == null)
               {
                    m_timeComponent = gameObject.AddComponent<TimeComponent>();
                    m_timeComponent.initial(0.15f, fnp_Call);
               }
          }

          public override void fn_EndAddAni()
          {
               if (m_timeComponent != null)
               {
                    m_timeComponent.Kill();
                    m_timeComponent = null;
               }
          }
          private bool fnp_findAni()
          {
               if (m_Ani==null)
               {
                    m_Ani = GetComponent<AB_SpAni>(); 
               }
               return (m_Ani == null) ? false : true;
          }
         
          /// <summary>
          /// 间隔调用
          /// </summary>
          protected virtual void fnp_Call()
          {
               m_timeNow = M_AniStartTime += M_AddSpace;
               m_timeNow = m_timeNow >= M_SetEndAniTime ? M_SetEndAniTime : m_timeNow;
               m_Ani.fn_setAniTime(m_timeNow);
          }
          protected float m_timeNow = 0f;
          public override float M_AniTimeNow
          {
               get
               {
                    return m_timeNow;
               }
               set
               {
                    m_timeNow = value ;
               }
          }
          float m_setEndAniTime = 1f;
          /// <summary>
          /// 动画播放到结束位置
          /// </summary>
          public override float M_SetEndAniTime
          {
               get
               {
                    return m_setEndAniTime;
               }
               set
               {
                    m_setEndAniTime=value;
               }
          }
          /// <summary>
          /// 动画到达指定位置
          /// </summary>
          /// <returns>true 达到</returns>
          public override bool fn_MoveToEnd()
          {
               if (M_SetEndAniTime<1f)
               {
                    //处理如果指定位置不是1的情况，需要取出零件后才可以取下工具
                    if (gameObject.GetComponent<AB_ThePart>() != null)
                    {
                         return false;
                    } 
               }
               return (M_SetEndAniTime == M_AniTimeNow)?true:false;
          }
     }
}
