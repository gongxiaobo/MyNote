using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 适合使用工具才能拉出零件的拉出类
     /// 加入工具拔出物体后，隐藏能够触发工具的碰撞体
     /// </summary>
     public class N_PullOut_01_01 : N_PullOut_01, I_ToolObjToPart
     {
          protected override void Start()
          {
               base.Start();
               //如果是用工具拿出的物体，那么先隐藏碰撞体，使得不能拿出
               AB_UseTool t_usetool = GetComponent<AB_UseTool>();
               if (t_usetool != null)
               {
                    if (t_usetool.M_UseTool == E_UseTool.e_UseToolFirst||
                         t_usetool.M_UseTool == E_UseTool.e_UseToolAll)
                    {
                         m_MoveHanderTrigger.SetActive(false);
                    }
                    //if (t_usetool.M_UseTool == E_UseTool.e_UseToolAll)
                    //{
                    //     m_MoveHanderTrigger.SetActive(false);
                    //     //需要关闭工具的触发器，关闭后不响应工具的触发
                    //     AB_Name t_name = GetComponent<AB_Name>();
                    //     if (t_name != null)
                    //     {
                    //          S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);
                    //     }
                    //     else
                    //     {

                    //          Debug.Log("<color=red>not find AB_Name!</color>");

                    //     }
                    //}
               }
          }

          public override void fn_activation()
          {
               //只有当机器里有零件时才能激活拉出物体的功能
               AB_State t_state = GetComponent<AB_State>();

               if (t_state != null)
               {
                    if (t_state.fn_getMainValue() == "havepart")
                    {
                         base.fn_activation();
                         //使用工具时，不显示向外的指示箭头
                         fnp_showArrowTip(true, false, false);
                    }
                    else
                    {
                        
                    }
               }

          }
          public override void fn_PullOut()
          {
               //base.fn_PullOut();
               //物体脱离移动轨道
               if (m_controlObj != null)
               {
                    m_controlObj.transform.parent = null;
               }
               //父物体不能再被手柄触发，暂时关闭碰撞体
               fn_Trigger(false);

               //让物体自动连接到一个物体上，这里是链接到工具上
               AB_CanPullOutObj t_outObj = m_controlObj.GetComponent<AB_CanPullOutObj>();
               if (t_outObj != null)
               {
                    t_outObj.fn_ToIndependent(this.gameObject);
               }

               //发送消息给零件的管理类改变状态
               AB_SetState t_setState = new N_SetState();
               t_setState.fn_setState("string", "nopart", GetComponent<AB_HandleEvent>());

               //需要关闭工具的触发器，关闭后不响应工具的触发
               AB_Name t_name = GetComponent<AB_Name>();
               if (t_name != null)
               {
                    S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);
               }
               else
               {

                    Debug.Log("<color=red>not find AB_Name!</color>");

               }
               //设置零件的状态,在工具上
               AB_ThePart t_thepart = M_PullObj.GetComponent<AB_ThePart>();
               if (t_thepart != null)
               {
                    t_thepart.M_PartState = E_ThePartState.e_onTool;
               }
               fnp_showArrowTip(false);
               //Invoke("fnp_activate", 1f);
          }
          protected override void fnp_update()
          {
               //base.fnp_update();
               if (m_pullout)
               {
                    return;
               }
               if (m_spanner != null)
               {

                    //Debug.Log("<color=blue>check:</color>");

                    if (m_spanner.fni_valueToBig())
                    {//到达最大值
                         //工具结束控制
                         m_spanner.fn_endControl();

                         fn_PullOut();
                         m_pullout = true;
                         S_update.Instance.fn_remove(fnp_update);

                         //Debug.Log("<color=red>red:</color>");

                    }
                    if (m_spanner.fni_valueToSmall())
                    {//到达最小值时
                         if (m_isFlip)
                         {
                              fnp_showArrowTip(false);
                              m_isActive = false;
                         }
                    }
               }
          }
          public override void fn_Trigger(bool _onoff)
          {
               //base.fn_Trigger(_onoff);
               if (m_MoveHanderTrigger != null)
               {
                    m_MoveHanderTrigger.SetActive(_onoff);
               }
               if (_onoff)
               {
                    fnp_showArrowTip(true, true);
               }
               else
               {//在吧零件放入到机器后，关闭箭头指示
                    fnp_showArrowTip(false);
               }
          }
          public override void fni_SetPartTrigger(bool _bl)
          {
               //base.fni_SetPartTrigger(_bl);
               //如果要使用工具来操作，需要隐藏工具触发器
               if (GetComponent<AB_UseTool>() != null)
               {
                    AB_Name t_name = GetComponent<AB_Name>();
                    if (t_name != null)
                    {
                         S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, _bl);
                    }
                    else { Debug.Log("<color=red>not find AB_Name!</color>"); }



               }
               else
               {
                    base.fni_SetPartTrigger(_bl);
               }
          }


          public void fni_ToolObjToPart(GameObject _tool)
          {
               if (_tool == null)
               {
                    Debug.Log("<color=red>the tool object is null!</color>");
                    return;
               }
               //找到零件，然后设置现在的工具
               if (m_controlObj != null)
               {
                    I_ToolObjToPart t_partInterface = m_controlObj.GetComponent<I_ToolObjToPart>();
                    if (t_partInterface != null)
                    {
                         t_partInterface.fni_ToolObjToPart(_tool);
                    }
                    else
                    {
                         Debug.Log("<color=red>not find I_ToolObjToPart in part obj!</color>");
                    }

               }
               else
               {

                    Debug.Log("<color=red>m_controlObj==null</color>");

               }
          }
     }
}
