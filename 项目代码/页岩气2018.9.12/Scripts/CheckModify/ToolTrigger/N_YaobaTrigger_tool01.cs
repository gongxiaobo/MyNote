using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 工具模仿手去操作一个零件
     /// 用于泵的拆装操作
     /// </summary>
     public class N_YaobaTrigger_tool01 : N_YaobaTrigger_35kv
     {
          public override void OnTriggerEnter(Collider other)
          {
               AB_ToolHavePart t_toolhavepart = GetComponent<AB_ToolHavePart>();
               if (t_toolhavepart != null)
               {//在工具上没有链接零件的情况下，才能去操作其他零件

                    if (t_toolhavepart.M_tollHavePart== E_ToolHavePart.e_noPart)
                    {
                         base.OnTriggerEnter(other); 
                    }
               }
              
          }
          /// <summary>
          /// 控制零件移动的物体
          /// </summary>
          public Transform m_startControlTarget = null;
          /// <summary>
          /// 碰触就链接零件，这里主要是处理那种旋转的零件，
          /// 碰触后，零件就链接到工具下，方便工具对零件的旋转
          /// </summary>
          public bool m_TriggerAndConnect = false;
          protected override void fnp_Do(GameObject _collider)
          {
               base.fnp_Do(_collider);
               AB_Name t_name=null;
               //Debug.Log("<color=red>1red:</color>");
     
               //找到工具要操作的物体
               AB_ToolTriggerInfo t_toolTrigger =_collider.GetComponent<AB_ToolTriggerInfo>();
               if (t_toolTrigger!=null)
               {
                    Transform t_obj = t_toolTrigger.fn_GetControlObj();
                    if (t_obj!=null)
                    {//有可操作物体，这个物体对应的零件
                         AB_Spanner t_spanner = t_obj.gameObject.GetComponent<AB_Spanner>();
                         if (t_spanner!=null)
                         {
                              //Debug.Log("<color=red>2red:</color>");
                              if (m_startControlTarget==null)
                              {
                                   t_spanner.fn_startControl(this.gameObject.transform);
                              }
                              else
                              {
                                   t_spanner.fn_startControl(m_startControlTarget);
                              }
                         }

                         AB_PullOut t_pullOut = t_obj.gameObject.GetComponent<AB_PullOut>();
                         if (t_pullOut != null)
                         {//激活拉出物体的管理类
                              t_pullOut.fn_activation();
                         }
                         //零件就链接到工具下，方便工具对零件的旋转
                         m_obj = t_obj;
                         if (m_TriggerAndConnect)
                         {
                             Invoke("fnp_callLate",0.25f);
                         }

                    }
                    t_toolTrigger.M_ToolObj = this.gameObject;

                    //需要关闭工具的触发器，关闭后不响应工具的触发
                     t_name = t_obj.gameObject.GetComponent<AB_Name>();
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
                    //if (t_toolTrigger.animation)
                    //{
                         
                    //}
               }
               
               //工具碰触物体后，捶打器复位
               AB_MoveAxis t_moveAxis = GetComponentInChildren<AB_MoveAxis>();
               if (t_moveAxis!=null)
               {
                    t_moveAxis.fn_reset();
                    //捶打器的捶打方向设置
                    AB_RotateRange t_rt = _collider.GetComponent<AB_RotateRange>();
                    if (t_rt != null)
                    {
                         t_moveAxis.M_MoveDir = t_rt.M_Dir;
                         if (t_name!=null)
                         {//设置拉出器的拉出长度
                              if (t_name.m_ID==4023)
                              {
                                   I_SetMovePara ti_setmove = GetComponentInChildren<I_SetMovePara>();
                                   if (ti_setmove!=null)
                                   {

                                        ti_setmove.fni_set(t_rt.fn_getMoveSpeedAndLength().x,
                                             t_rt.fn_getMoveSpeedAndLength().y);

                                        Debug.Log("<color=blue>t_rt.M_AniTime:</color>" + t_rt.fn_getMoveSpeedAndLength());
     
                                   }
                              }
                         }
                    }
               }
               

          }
          /// <summary>
          /// 零件的总父节点
          /// </summary>
         protected Transform m_obj = null;
          /// <summary>
          /// 延迟链接到零件下
          /// </summary>
          private void fnp_callLate()
          {
               if (m_obj!=null)
               {
                    AB_ThePart t_thePart = m_obj.gameObject.GetComponentInChildren<AB_ThePart>();
                    if (t_thePart != null)
                    {

                         t_thePart.transform.parent = this.gameObject.transform;

                    }
                    m_obj = null; 
               }
          }

     } 
}
