using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 直接使用工具去操作一个零件的值(T型工具)
     /// </summary>
     public class N_YaobaTrigger_tool02 : N_YaobaTrigger_35kv
     {
          public override void OnTriggerEnter(Collider other)
          {
               AB_ToolHavePart t_toolhavepart = GetComponent<AB_ToolHavePart>();
               if (t_toolhavepart != null)
               {//在工具上没有链接零件的情况下，才能去操作其他零件

                    if (t_toolhavepart.M_tollHavePart == E_ToolHavePart.e_noPart)
                    {
                         base.OnTriggerEnter(other);
                    }
               }

          }
          /// <summary>
          /// 碰触就链接零件，这里主要是处理那种旋转的零件，
          /// 碰触后，零件就链接到工具下，方便工具对零件的旋转
          /// </summary>
          public bool m_TriggerAndConnect = false;
          protected override void fnp_Do(GameObject _collider)
          {
               base.fnp_Do(_collider);


               //找到工具要操作的物体
               AB_ToolTriggerInfo t_toolTrigger = _collider.GetComponent<AB_ToolTriggerInfo>();
               if (t_toolTrigger != null)
               {
                    Transform t_obj = t_toolTrigger.fn_GetControlObj();
                   
                    t_toolTrigger.M_ToolObj = this.gameObject;

                    //需要关闭工具的触发器，关闭后不响应工具的触发
                    AB_Name t_name = t_obj.gameObject.GetComponent<AB_Name>();
                    if (t_name != null)
                    {
                         S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);
                         //关闭放入触发器，如果有的情况下
                         S_ToolTrigger.Instance.fn_SetToolPushTrigger(t_name.m_ID, false);
                    }
                    else
                    {

                         Debug.Log("<color=red>not find AB_Name!</color>");

                    }

                    //当工具碰触一个触发器后，对目标物体进行锁定
                    AB_Name t_thiNname = GetComponent<AB_Name>();
                    AB_SendMsg t_send = new N_SendMsg();
                    t_send.fn_sendmsg(E_MessageType.e_outside,E_StateValueType.e_lock,
                         t_thiNname.m_ID, t_name.m_ID, "lock", 
                         GetComponent<AB_HandleEvent>());

               }
               //主要作用是在工具碰触到零件触发器时就通知实现接口类在那个位置是可以拔出手柄的，
               //如果开始是在最小位置，那么在最大位置可以拿出，反之亦然
               I_ToolPullOutLogic ti_logic = GetComponent<I_ToolPullOutLogic>();
               if (ti_logic!=null)
               {
                    ti_logic.fni_PullOutPos();
               }
               

          }
        
         
        
     } 
}
