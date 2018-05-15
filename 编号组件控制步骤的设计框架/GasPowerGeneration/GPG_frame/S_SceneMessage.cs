using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 场景之间的传输消息的全局类
     /// 以消息的形式
     /// </summary>
     public class S_SceneMessage : GenericDontDestroy<S_SceneMessage>
     {
          /// <summary>
          /// 场景的保存消息集合
          /// </summary>
          List<AB_Message> m_sceneMsg = new List<AB_Message>();
          /// <summary>
          /// 获取消息
          /// </summary>
          /// <param name="_msgName"></param>
          /// <returns></returns>
          public AB_Message fn_getMsg(string _msgName)
          {
               for (int i = 0; i < m_sceneMsg.Count; i++)
               {
                    if (m_sceneMsg[i].Name == _msgName)
                    {
                         return m_sceneMsg[i];

                    }
               }
               return null;
          }
          /// <summary>
          /// 获取场景的选择模式，考试，训练，自由
          /// </summary>
          /// <returns></returns>
          public string fn_getMode()
          {
               for (int i = 0; i < m_sceneMsg.Count; i++)
               {
                    if (m_sceneMsg[i].Name == "sceneMsg")
                    {
                         //return (m_sceneMsg[i].);
                         StateValueString t_ = m_sceneMsg[i].fn_getContent("sceneType") as StateValueString;
                         return t_.m_date;
                    }
               }
               return "free";
          }
          /// <summary>
          /// 获取当前选择的语言
          /// </summary>
          /// <returns></returns>
          public string fn_getLanguage()
          {
               for (int i = 0; i < m_sceneMsg.Count; i++)
               {
                    if (m_sceneMsg[i].Name == "sceneMsg")
                    {
                         //return (m_sceneMsg[i].);
                         StateValueString t_ = m_sceneMsg[i].fn_getContent("lg") as StateValueString;
                         return t_.m_date;
                    }
               }
               return "Chinese";
          }
          /// <summary>
          /// 加入消息
          /// </summary>
          /// <param name="_msg"></param>
          public void fn_addMsg(AB_Message _msg)
          {
               for (int i = 0; i < m_sceneMsg.Count; i++)
               {
                    if (m_sceneMsg[i].Name == _msg.Name)
                    {
                         m_sceneMsg[i] = _msg;
                         return;
                    }
               }
               m_sceneMsg.Add(_msg);

          }
          //当前场景的名称
          public E_sceneName me_thisSceneName;
     }
     /// <summary>
     /// 场景的名称
     /// </summary>
     public enum E_sceneName
     {
          e_null = 0,
          //开始场景
          e_start = 1,
          //选择场景
          e_select = 2,
          //操作场景
          e_step = 3,
     } 
}