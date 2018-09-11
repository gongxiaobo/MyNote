using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_Message : AB_Message
     {


          public override StateValue[] fn_getMessageValue()
          {
               return m_Content;
          }
          public override StateValue fn_getContent(string _name)
          {
               for (int i = 0; i < m_Content.Length; i++)
               {
                    if (m_Content[i].Name == _name)
                    {
                         return m_Content[i];
                    }
               }
               return null;
          }

          /// <summary>
          /// 对于消息的初始化
          /// </summary>
          /// <param name="_type">消息的类型</param>
          /// <param name="_content">消息的内容数组</param>
          /// <param name="_name">消息的名称</param>
          /// <param name="_fromID">来源ID</param>
          /// <param name="_ToId">影响的ID</param>
          public override void fn_init(E_MessageType _type, StateValue[] _content, string _name = "", int _fromID = 0, int _ToId = 0)
          {
               m_FromID = _fromID;
               m_ToId = _ToId;
               m_type = _type;
               m_Content = _content;
               m_name = _name;
          }

          public override void fn_setContent(StateValue[] _content)
          {
               if (_content != null)
               {
                    m_Content = _content;

               }
          }
     }

}