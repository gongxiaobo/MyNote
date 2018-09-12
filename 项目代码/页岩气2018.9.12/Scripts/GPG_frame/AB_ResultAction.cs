using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 获取触发消息的消息链
     /// </summary>
     [RequireComponent(typeof(AB_Name))]
     public abstract class AB_ResultAction : MonoBehaviour
     {
          /// <summary>
          /// 挂载按钮的编号
          /// </summary>
          protected int m_ID;
          protected AB_Name m_name = null;
          protected virtual void Start()
          {
               m_name = GetComponent<AB_Name>();
               if (m_name != null)
               {
                    m_ID = m_name.m_ID;
               }
               else
               {
                    Destroy(this);

               }
          }
          /// <summary>
          /// 根据配置，组装一个动作的触发消息
          /// </summary>
          /// <param name="_name">触发消息的名称</param>
          /// <returns></returns>
          public abstract List<AB_Message> fn_getReultMsg(string _name);
          /// <summary>
          /// 直接发送消息
          /// </summary>
          /// <param name="_name">触发结果的名称</param>
          /// <param name="_mac">要发送消息的机器</param>
          public abstract void fn_SendResultMsg(string _name, AB_HandleEvent _mac);


     } 
}
