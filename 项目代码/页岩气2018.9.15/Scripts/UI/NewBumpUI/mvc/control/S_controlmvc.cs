using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
/// <summary>
/// mvc模式下的控制器集合
/// </summary>
public class S_controlmvc : GenericSingletonClass<S_controlmvc>, I_uiHandleMsg
{
     public int m_controlsNum = 0;
     Dictionary<string, AB_controlmvc> m_controls = new Dictionary<string, AB_controlmvc>();
     public void fn_putIn(AB_controlmvc _control)
     {
          if (_control == null)
          {
               return;
          }
          if (!m_controls.ContainsKey(_control.gameObject.name))
          {
               m_controls.Add(_control.gameObject.name, _control);
               m_controlsNum++;
          }
     }


     public void fni_send(UIMsg _sendout)
     {//control to view
          S_viewItems.Instance.fni_receive(_sendout);
     }

     public void fni_receive(UIMsg _get)
     {// view to control or (model to control)
          string t_name = "";
          switch (_get.m_msgType)
          {
               case E_MsgType.e_normal:
                    t_name = "normal";
                    break;
               case E_MsgType.e_panel:
                    t_name = _get.m_panelID.ToString();
                    break;
               case E_MsgType.e_panelItem:
                    t_name = _get.m_thisItemID.ToString();
                    break;
               default:
                    break;
          }
          if (m_controls.ContainsKey(t_name))
          {
               m_controls[t_name].fni_receive(_get);
          }


     }
}
