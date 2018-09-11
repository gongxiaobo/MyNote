using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 工具可以碰触的触发器
     /// </summary>
     public class S_ToolTrigger : GenericSingletonClass<S_ToolTrigger>
     {
          #region 拿出零件使用工具的触发器
          /// <summary>
          /// 所有工具触发器集合
          /// </summary>
          protected Dictionary<int, AB_ToolTriggerInfo> m_toolTrigger = new Dictionary<int, AB_ToolTriggerInfo>();

          /// <summary>
          /// 注册工具的触发器集合
          /// </summary>
          /// <param name="_id">item id</param>
          /// <param name="_info">AB_ToolTriggerInfo</param>
          public void fn_logToolTrigger(int _id, AB_ToolTriggerInfo _info)
          {
               if (m_toolTrigger.ContainsKey(_id) || _info == null)
               {
                    Debug.Log("<color=red>m_toolTrigger.ContainsKey(_id)||_info==null</color>");
                    return;
               }
               m_toolTrigger.Add(_id, _info);

          }
          /// <summary>
          /// 通过item编号获取能够被工具触发的触发器
          /// </summary>
          /// <param name="_id">item id</param>
          /// <returns></returns>
          public AB_ToolTriggerInfo fn_getToolTrigger(int _id)
          {
               if (m_toolTrigger.ContainsKey(_id))
               {
                    return m_toolTrigger[_id];
               }
               return null;
          }
          /// <summary>
          /// 直接设置指定的item id 的触发器的打开和关闭
          /// </summary>
          /// <param name="_id">item id</param>
          /// <param name="_show">true 打开</param>
          public void fn_SetToolTrigger(int _id, bool _show)
          {
               if (m_toolTrigger.ContainsKey(_id))
               {
                    m_toolTrigger[_id].fn_HideToolTrigger(_show);
               }
               else
               {
                    Debug.Log("<color=red>m_toolTrigger.ContainsKey(_id)==false</color>");
               }
          } 
          #endregion
          #region 放入零件触发工具的触发器
          /// <summary>
          /// 这是放入零件时使用工具的触发器集合
          /// </summary>
          protected Dictionary<int, AB_ToolTriggerInfo> m_repushTrigger = new Dictionary<int, AB_ToolTriggerInfo>();
          /// <summary>
          /// 注册零件放入时使用工具的触发器
          /// </summary>
          /// <param name="_id"></param>
          /// <param name="_info"></param>
          public void fn_logToolPushTrigger(int _id, AB_ToolTriggerInfo _info)
          {
               if (m_repushTrigger.ContainsKey(_id) || _info == null)
               {
                    Debug.Log("<color=red>m_repushTrigger.ContainsKey(_id)||_info==null</color>");
                    return;
               }
               m_repushTrigger.Add(_id, _info);

          }
          /// <summary>
          /// 直接设置指定的item id 的触发器的打开和关闭
          /// </summary>
          /// <param name="_id">item id</param>
          /// <param name="_show">true 打开</param>
          public void fn_SetToolPushTrigger(int _id, bool _show)
          {
               if (m_repushTrigger.ContainsKey(_id))
               {
                    m_repushTrigger[_id].fn_HideToolTrigger(_show);
               }
               else
               {
                    Debug.Log("<color=red>m_repushTrigger.ContainsKey(_id)==false</color>");
               }
          } 
          #endregion
          
     } 
}
