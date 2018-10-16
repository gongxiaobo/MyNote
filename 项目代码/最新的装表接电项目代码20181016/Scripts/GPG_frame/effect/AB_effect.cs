using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 物体的效果抽象，根据效果名称，处理相应的效果
     /// 主要处理灯光的开启
     /// 声音的播放
     /// </summary>
     public abstract class AB_effect : MonoBehaviour
     {
          /// <summary>
          /// 效果的名称
          /// </summary>
          public E_effectName m_effectName = E_effectName.e_light;
          /// <summary>
          /// 触发效果，输入消息的类型和参数
          /// </summary>
          /// <param name="_type">消息的类型</param>
          /// <param name="_para">消息的参数</param>
          public abstract void fn_effect(E_effectType _type, string _para = "");
          /// <summary>
          /// 效果对应的物体关联ID
          /// ID==-1表示没有没有关联任何物体
          /// 
          /// </summary>
          public int m_itemID = -1;
          protected virtual void Start()
          {
               S_SceneMagT1.Instance.fn_putEffect(m_itemID, this);
          }
     }
     /// <summary>
     /// 效果的类型
     /// </summary>
     public enum E_effectType
     {
          /// <summary>
          /// 空
          /// </summary>
          e_null = 0,
          /// <summary>
          /// 开
          /// </summary>
          e_on = 1,
          /// <summary>
          /// 关
          /// </summary>
          e_off = 2,
          /// <summary>
          /// 无电
          /// </summary>
          e_noelectric = 3,


     }
     /// <summary>
     /// 效果的名称
     /// </summary>
     public enum E_effectName
     {
          /// <summary>
          /// 灯
          /// </summary>
          e_light = 1,
          /// <summary>
          /// 声音
          /// </summary>
          e_sound = 2,
          /// <summary>
          /// 提示类型
          /// </summary>
          e_tips = 3,
     }

}