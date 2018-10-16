using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 消息的统一功能抽象类
     /// </summary>
     public abstract class AB_Message
     {
          /// <summary>
          /// 机器的名称
          /// </summary>
          public E_MachineName m_MachineName = E_MachineName.e_null;
          /// <summary>
          /// 是否是内部消息
          /// </summary>
          protected E_MessageType m_type = E_MessageType.e_inside;
          /// <summary>
          /// 是否是内部消息
          /// </summary>
          public E_MessageType Type
          {
               get { return m_type; }
               set { m_type = value; }
          }
          /// <summary>
          /// 消息的来源ID
          /// value ==0 表示无效参数
          /// </summary>
          protected int m_FromID = 0;
          /// <summary>
          ///  消息的来源ID
          /// </summary>
          public int FromID
          {
               get { return m_FromID; }
               //set { m_FromID = value; }
          }
          protected int m_ToId = 0;
          /// <summary>
          /// 影响哪个编号的按钮
          ///  value ==0 表示无效参数
          /// </summary>
          public int ToId
          {
               get { return m_ToId; }
               //set { m_ToId = value; }
          }

          protected string m_name = "";
          /// <summary>
          /// 消息的名称
          /// </summary>
          public string Name
          {
               get { return m_name; }
               set { m_name = value; }
          }
          /// <summary>
          /// 获取当前消息的内容
          /// </summary>
          /// <returns></returns>
          public abstract StateValue[] fn_getMessageValue();
          /// <summary>
          /// 对于消息的初始化
          /// </summary>
          /// <param name="_type">消息的类型</param>
          /// <param name="_content">消息的内容数组</param>
          /// <param name="_name">消息的名称</param>
          /// <param name="_fromID">来源ID</param>
          /// <param name="_ToId">影响的ID</param>
          public abstract void fn_init(E_MessageType _type, StateValue[] _content, string _name = "", int _fromID = 0, int _ToId = 0);
          ///// <summary>
          ///// 消息的内容
          ///// </summary>
          protected StateValue[] m_Content;
          /// <summary>
          /// 只设置内容
          /// </summary>
          /// <param name="_content"></param>
          public abstract void fn_setContent(StateValue[] _content);
          /// <summary>
          /// 回调
          /// </summary>
          public Action<AB_Message> m_CallBack = null;
          /// <summary>
          /// 获取具体的消息内容
          /// </summary>
          /// <param name="_name"></param>
          /// <returns></returns>
          public abstract StateValue fn_getContent(string _name);
     }
     /// <summary>
     /// 消息的类型
     /// </summary>
     public enum E_MessageType
     {
          /// <summary>
          /// 无类型
          /// </summary>
          e_null = 0,
          /// <summary>
          /// 内部消息类型
          /// </summary>
          e_inside = 1,
          /// <summary>
          /// 外部消息
          /// </summary>
          e_outside = 2,
          /// <summary>
          /// 改变内部的状态值
          /// </summary>
          e_changeState = 3,
          /// <summary>
          /// 场景消息类型
          /// </summary>
          e_sceneMsg = 4,


     } 
}