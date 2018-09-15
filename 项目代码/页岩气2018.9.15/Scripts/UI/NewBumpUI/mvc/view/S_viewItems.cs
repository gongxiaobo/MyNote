using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
/// <summary>
/// mvc的UI架构中，view item 的集合
/// </summary>
public class S_viewItems : GenericSingletonClass<S_viewItems>, I_uiHandleMsg
{
     Dictionary<int, AB_viewItem> m_panels = new Dictionary<int, AB_viewItem>();
     Dictionary<int, AB_viewItem> m_items = new Dictionary<int, AB_viewItem>();
     public void fn_putIn(AB_viewItem _view)
     {
          if (_view==null)
          {
               return;
          }
          if (_view.m_viewType == E_UITypeName.e_null || _view.m_viewID==-1)
          {
               return;
          }
          if (_view.m_viewType== E_UITypeName.e_panel)
          {
               if (!m_panels.ContainsKey(_view.m_viewID))
               {
                    m_panels.Add(_view.m_viewID, _view); 
                    m_panelNum++;
               }
               else
               {
                    Debug.Log("<color=red>出现重复的panel 编号--</color>" + _view.gameObject.name);
               }
          }
          if (_view.m_viewType == E_UITypeName.e_panel_1)
          {
               if (!m_items.ContainsKey(_view.m_viewID))
               {
                    m_items.Add(_view.m_viewID, _view); 
                    m_viewItemNum++;
               }
               else
               {
                    Debug.Log("<color=red>出现重复的 view item 编号--</color>" + _view.gameObject.name);
               }
          }
     }
     public int m_panelNum = 0;
     public int m_viewItemNum = 0;

     /// <summary>
     /// 发送给control
     /// </summary>
     /// <param name="_sendout"></param>
     public void fni_send(UIMsg _sendout)
     {
          S_controlmvc.Instance.fni_receive(_sendout);
     }
     /// <summary>
     /// 接收来自control的消息
     /// </summary>
     /// <param name="_get"></param>
     public void fni_receive(UIMsg _get)
     {
          if (_get.m_msgType== E_MsgType.e_normal)
          {

          }
          else if (_get.m_msgType== E_MsgType.e_panel)
          {
               if (m_panels.ContainsKey(_get.m_panelID))
               {
                    m_panels[_get.m_panelID].fni_receive(_get);
               }
          }
          else if (_get.m_msgType== E_MsgType.e_panelItem)
          {
               if (m_items.ContainsKey(_get.m_thisItemID))
               {
                    m_items[_get.m_thisItemID].fni_receive(_get);
               }
          }
     }
}
