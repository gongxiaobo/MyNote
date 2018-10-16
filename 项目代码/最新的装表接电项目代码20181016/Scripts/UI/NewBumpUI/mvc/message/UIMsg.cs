using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// mvc模式下的消息基础类型
/// </summary>
public struct UIMsg  {
     public E_MsgType m_msgType;
     /// <summary>
     /// 界面ID
     /// </summary>
     public int m_panelID;
     /// <summary>
     /// itemID
     /// </summary>
     public int m_thisItemID;
     /// <summary>
     /// 协议名称
     /// </summary>
     public string m_MsgName;
     /// <summary>
     /// 内容名称和下面的内容一一对应
     /// </summary>
     public string[] m_contentName;
     /// <summary>
     /// 内容，和上面的内容名称一一对应
     /// </summary>
     public string[] m_contents;
     public void fn_putMsg(E_MsgType _msgtype,int _panel, int _item, string _msgname, string[] _conName, string[] _con)
     {
          m_msgType = _msgtype;
          m_panelID = _panel;
          m_thisItemID = _item;
          m_MsgName = _msgname;
          m_contentName = _conName;
          m_contents = _con;
     }
	
}
