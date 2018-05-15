using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 机器的管理消息的转发和接收
     /// 2018.3.15:重新修改了对item的管理，新加入字典m_controlItemID，
     /// 可以准确定位消息的位置item,优化了代码的效率
     /// </summary>
     public class N_MachineMag : AB_MachineMag
     {


          public override void fn_addControlItem(AB_HandleEvent _item)
          {
               base.fn_addControlItem(_item);
               int t_itemID = _item.gameObject.GetComponent<AB_Name>().m_ID;

               if (!m_controlItemID.ContainsKey(t_itemID))
               {
                    m_controlItem.Add(_item);
                    m_controlItemID.Add(t_itemID, _item);
               }
               else
               {
                    Debug.Log("<color=red>Warning:</color>" + m_MachineName + " contain same ID " + t_itemID);
               }
          }
          public override void fn_init()
          {
               if (m_controlItem != null)
               {
                    for (int i = 0; i < m_controlItem.Count; i++)
                    {
                         m_controlItem[i].fn_init(this);
                    }
               }
          }

          public override void fn_ReceiveEvent(AB_Message _msg)
          {
               if (_msg == null)
               {
                    return;
               }
               //如果是收到其他机器发来的消息，转发给所有的管理物体
               fn_SendEventThis(_msg);
               if (_msg.Type == E_MessageType.e_outside)
               {

                    fn_SendEvent(_msg);
               }

          }
          /// <summary>
          /// 向机器外的物体发送消息
          /// </summary>
          /// <param name="_msg"></param>
          protected override void fn_SendEvent(AB_Message _msg)
          {
               if (_msg == null)
               {
                    return;
               }
               if (_msg.Type != E_MessageType.e_inside)
               {
                    _msg.m_MachineName = m_MachineName;
                    S_SceneMagT1.Instance.fn_ReceiveEvent(_msg);
               }
          }
          /// <summary>
          /// 机器内部的消息转发
          /// </summary>
          /// <param name="_msg"></param>
          protected override void fn_SendEventThis(AB_Message _msg)
          {
               if (_msg == null)
               {
                    return;
               }
               if (_msg.Type != E_MessageType.e_inside)
               {
                    return;
               }
               if (m_controlItemID.ContainsKey(_msg.ToId))
               {
                    m_controlItemID[_msg.ToId].fn_HandleMsg(_msg);
               }
               if (_msg.Name == "init")
               {
                    StateValueInt t_id = (StateValueInt)_msg.fn_getContent("m_id");
                    if (m_controlItemID.ContainsKey(t_id.m_date))
                    {
                         m_controlItemID[t_id.m_date].fn_HandleMsg(_msg);
                    }
               }
               //if (m_controlItem != null)
               //{
               //     for (int i = 0; i < m_controlItem.Count; i++)
               //     {
               //          if ( m_controlItem[i].ID.m_ID!=_msg.FromID)
               //          {
               //               m_controlItem[i].fn_HandleMsg(_msg); 
               //          }
               //     }
               //}
          }
     } 
}
