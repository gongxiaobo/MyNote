using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 机器的管理类抽象，负责管理一定数量的可控物体
     /// 触发事件，转发事件，初始化
     /// </summary>
     public abstract class AB_MachineMag : MonoBehaviour
     {
          /// <summary>
          /// 机器的名称
          /// </summary>
          public E_MachineName m_MachineName = E_MachineName.e_null;
          /// <summary>
          /// 所有的管理item
          /// </summary>
          protected List<AB_HandleEvent> m_controlItem = new List<AB_HandleEvent>();
          /// <summary>
          /// 机器下的所有的item编号
          /// </summary>
          protected Dictionary<int, AB_HandleEvent> m_controlItemID = new Dictionary<int, AB_HandleEvent>();
          protected virtual void Start()
          {
               ////注册管理类
               //S_SceneMagT1.Instance.fn_MachineLogin(this);
               ////获取子管理item
               //m_controlItem = GetComponentsInChildren<AB_HandleEvent>();
          }
          public virtual void fn_addControlItem(AB_HandleEvent _item)
          {

          }
          public abstract void fn_init();
          /// <summary>
          /// 接收到外部发来的消息
          /// </summary>
          /// <param name="_msg"></param>
          public abstract void fn_ReceiveEvent(AB_Message _msg);
          /// <summary>
          /// 向场景管理类发送消息
          /// </summary>
          /// <param name="_msg"></param>
          protected abstract void fn_SendEvent(AB_Message _msg);
          /// <summary>
          /// 机器内部的消息分发
          /// </summary>
          /// <param name="_msg"></param>
          protected abstract void fn_SendEventThis(AB_Message _msg);
     }

}