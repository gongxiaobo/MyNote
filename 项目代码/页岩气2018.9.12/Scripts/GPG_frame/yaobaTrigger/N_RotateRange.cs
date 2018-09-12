using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     [DisallowMultipleComponent]
     public class N_RotateRange : AB_RotateRange
     {
          public Vector2 m_Range = new Vector2(0f, 90f);
          public override Vector2 M_getRange
          {
               get { return m_Range; }
          }

          public bool m_NeedBackZero = false;
          public override bool M_Back
          {
               get { return m_NeedBackZero; }
          }
          /// <summary>
          /// 在摇把摇到最小值时发送消息
          /// true为发送消息
          /// </summary>
          public bool m_smallSendMsg = false;
          public override bool M_ValueSmallSendMsg
          {
               get { return m_smallSendMsg; }
          }
          /// <summary>
          /// 在摇把摇到最大值时发送消息
          /// </summary>
          public bool m_bigSendMsg = true;
          public override bool M_ValueBigSendMsg
          {
               get { return m_bigSendMsg; }
          }
          /// <summary>
          /// 最大值发送on,最小值发送 off
          /// true为反转上面的消息发送
          /// </summary>
          public bool m_flipMsg = false;
          public override bool M_SendValueFlip
          {
               get { return m_flipMsg; }
          }
          public string m_rotateSound = "";
          public override string M_SoundName
          {
               get { return m_rotateSound; }
          }
          /// <summary>
          /// 暂时用于捶打器的捶打方向
          /// </summary>
          public Vector3 m_Dir = new Vector3(0f, 0f, 1f);
          /// <summary>
          /// 暂时用于捶打器的捶打方向
          /// </summary>
          public override Vector3 M_Dir
          {
               get
               {
                    return m_Dir;
               }
               set
               {
                    m_Dir=value;
               }
          }
          [Tooltip("1.设置工具的动画初始位置,现在用于阀座拉出器,2.设置拉出器的间隔和拉出距离")]
          public Vector2 m_aniTime=new Vector2(0f,1f) ;
          public override Vector2 M_AniTime
          {
               get
               {
                    return m_aniTime;
               }
               set
               {
                    m_aniTime = value;
               }
          }
          public float m_moveSpeed = 0.015f;
          public float m_moveLength = 0.117f;
          //public Vector2 m_moveSpeedLength = new Vector2(0f, 1f);
          public override Vector2 fn_getMoveSpeedAndLength()
          {
               return new Vector2(m_moveSpeed, m_moveLength);
          }
     } 
}
