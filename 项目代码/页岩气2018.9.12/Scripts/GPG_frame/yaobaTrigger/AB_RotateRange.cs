using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把类型的旋转角度设置
     /// </summary>
     public abstract class AB_RotateRange : MonoBehaviour
     {
          /// <summary>
          /// 获取范围
          /// </summary>
          public abstract Vector2 M_getRange { get; }
          /// <summary>
          /// 是否操作结束回到0位置
          /// </summary>
          public abstract bool M_Back { get; }
          /// <summary>
          /// 在最小值时发送消息
          /// </summary>
          public abstract bool M_ValueSmallSendMsg { get; }
          /// <summary>
          /// 在最大值时发送消息
          /// </summary>
          public abstract bool M_ValueBigSendMsg { get; }
          /// <summary>
          /// 最大值发送on,最小值发送 off
          /// true为反转上面的消息发送
          /// </summary>
          public abstract bool M_SendValueFlip { get; }
          /// <summary>
          /// 在摇把旋转时的声音名称
          /// </summary>
          public abstract string M_SoundName { get; }
          /// <summary>
          /// 设置工具的动画位置
          /// </summary>
          public abstract Vector2 M_AniTime { get; set; }
          /// <summary>
          /// 获取方向
          /// </summary>
          public abstract Vector3 M_Dir { get; set; }
          public abstract Vector2 fn_getMoveSpeedAndLength();
     } 
}
