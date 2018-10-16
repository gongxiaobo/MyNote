using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_viewItem : AB_viewItem
{
     Dictionary<string, AB_mvcTask> m_tasks = new Dictionary<string, AB_mvcTask>();
     protected override void Start()
     {
          base.Start();
          AB_mvcTask[] t_task = transform.GetComponents<AB_mvcTask>();
          for (int t = 0; t < t_task.Length; t++)
          {
               if (!m_tasks.ContainsKey(t_task[t].m_taskName))
               {
                    m_tasks.Add(t_task[t].m_taskName, t_task[t]);
               }
               else
               {
                    Debug.Log("<color=red>包含相同名称的任务</color>" + this.gameObject.name);
               }
          }
     }
     public override void fni_receive(UIMsg _get)
     {
          //找到详细中名称的任务
          if (m_tasks.ContainsKey(_get.m_MsgName))
          {//处理从发来消息
               m_tasks[_get.m_MsgName].fn_handle(_get);
          }
          else
          {
               Debug.Log("<color=red>not find task that is named </color>" + _get.m_MsgName);
          }
     }
     
	
}
