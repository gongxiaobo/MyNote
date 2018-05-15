using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 通用操作事件类
     /// </summary>
     [DisallowMultipleComponent]
     public abstract class AB_HandleEvent : MonoBehaviour
     {
          protected AB_Name m_ID;

          public AB_Name ID
          {
               get { return m_ID; }
               //set { m_ID = value; }
          }
          protected AB_State m_state;
          /// <summary>
          /// 机器的名称
          /// </summary>
          [EnumLabel("机器")]
          public E_MachineName m_MachineName = E_MachineName.e_null;
          protected virtual void Start()
          {
               S_SceneMagT1.Instance.fn_MachineLogin(m_MachineName, this);
          }
          /// <summary>
          /// 处理收到的消息
          /// </summary>
          /// <param name="_msg"></param>
          public abstract void fn_HandleMsg(AB_Message _msg);
          /// <summary>
          /// 发出消息
          /// </summary>
          /// <param name="_send"></param>
          public abstract void fn_SendMsg(AB_Message _send);

          public abstract void fn_init(AB_MachineMag _mag);

          public virtual StateValue fn_get(string _name)
          {
               return null;
          }
          public virtual string fn_getValue(string _name)
          {
               return "";
          }
          public virtual string fn_getMainValue()
          {
               return "";
          }
          public virtual void fn_set(StateValue _value)
          {
               if (m_state != null)
               {
                    m_state.fn_setValue(_value);
               }
          }
          public virtual void fn_debugState()
          {
               if (m_state != null)
               {
                    m_state.fn_debugContent();
               }
          }

     }

}