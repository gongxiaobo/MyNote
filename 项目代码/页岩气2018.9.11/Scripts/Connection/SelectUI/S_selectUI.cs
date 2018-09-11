using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电的消息转发类
     /// </summary>
     public class S_selectUI : GenericSingletonClass<S_selectUI>,I_handlemsg
     {
          /// <summary>
          /// 所有的UI组件集合
          /// </summary>
          protected List<AB_UILevel01> m_SelectUI = new List<AB_UILevel01>();
          protected Dictionary<int, AB_UILevel01> m_UIs = new Dictionary<int, AB_UILevel01>();
          /// <summary>
          /// 添加选择UI
          /// </summary>
          /// <param name="_uilevel"></param>
          public void fn_addSelectUI(AB_UILevel01 _uilevel)
          {
               m_SelectUI.Add(_uilevel);
               if (!m_UIs.ContainsKey(_uilevel.m_UIID))
               {
                    m_UIs.Add(_uilevel.m_UIID, _uilevel);
               }
               else
               {
                    Debug.Log("<color=red> same ui id!</color>");
               }
          }
          public AB_UILevel01 fn_getSelectUI(int _uiID)
          {
               if (m_UIs.ContainsKey(_uiID))
               {
                    return m_UIs[_uiID];
               }
               else
               {
                    return null;
               }
          }


          public void fni_receive(SMsg _reveive)
          {

               Debug.Log("<color=blue>_reveive:</color>" + _reveive.m_ID);
     
               for (int i = 0; i < m_SelectUI.Count; i++)
               {
                    m_SelectUI[i].fni_receive(_reveive);
               }
          }

          public void fni_send(SMsg _sendmsg)
          {
               //throw new System.NotImplementedException();
          }
          /// <summary>
          /// 绳子选择UI的位置
          /// </summary>
          public Transform m_RopeSelect = null;
          #region select rope para
          public string m_ropesize;
          public string m_ropemode;
          public string m_ropecolor;
          //断开电线
          public bool m_isDisLine; 
          #endregion
          /// <summary>
          /// 获取当前选择电线的参数
          /// </summary>
          /// <returns>&2&hard&red</returns>
          public string fn_getWirePara()
          {
               string t_para = "&" + m_ropesize + "&" + m_ropemode + "&" + m_ropecolor;
               return t_para;
          }

          public Transform m_StepDetail = null;
     } 
}
