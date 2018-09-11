using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 普通零件在初始化时从机器脱离，放置在地面上的初始化
     /// 2018.5.28-零件在放入后也使用工具的情况
     /// </summary>
     public class N_PartTriggerInit_1_2 : N_PartTriggerInit_1
     {
          /// <summary>
          /// 开始是否停止使用碰撞器，关闭碰撞器的零件暂时不能被操作
          /// </summary>
          public bool m_CloseTriggerStart = true;
          protected override void fnp_DoInit()
          {
               //Debug.Log("<color=red>需要初始化把零件移动到地面</color>");
               //base.fnp_DoInit();
               AB_Name t_name = GetComponent<AB_Name>();
               AB_State t_state=GetComponent<AB_State>();
               //是否使用工具来操作这个零件
               AB_UseTool t_usetool = GetComponent<AB_UseTool>();
               if (t_state!=null)
               {
                    if (t_state.fn_getMainValue()=="nopart")
                    {//没有零件，需要初始化把零件移动到地面
                         fnp_setLockState("lock", "unlock");

                         //Debug.Log("<color=red>需要初始化把零件移动到地面</color>");
     
                         m_CloseTriggerStart = true;
                         //找到零件
                         AB_ThePart t_part = GetComponentInChildren<AB_ThePart>();
                         I_PullOutPart t_partBox = t_part.gameObject.GetComponent<I_PullOutPart>();

                         t_part.M_PartState = E_ThePartState.e_onGround;
                         t_part.gameObject.transform.parent = null;
                         t_part.gameObject.transform.position = S_PartOnGround.Instance.fn_getPos(t_name.m_ID);
                         t_part.gameObject.AddComponent<Rigidbody>();
                         t_part.gameObject.AddComponent<N_PickUp_01>();
                         t_partBox.fni_setTrigger(true);

                         //隐藏拿出零件的触发器
                         //fnp_hideTrigger(t_name, t_usetool);
                         //if (t_usetool != null)
                         //{
                         //     //主要是处理前后都使用工具的情况
                         //     if (t_usetool.M_UseTool == E_UseTool.e_UseToolAll)
                         //     {
                         //          S_ToolTrigger.Instance.fn_SetToolPushTrigger(t_name.m_ID, false);
                         //     }
                         //}
                         if (t_usetool != null)
                         {
                              //如果是前后都用用工具的初始化
                              if (t_usetool.M_UseTool == E_UseTool.e_UseToolAll)
                              {
                                   //隐藏拿出零件的触发器隐藏
                                   fnp_hideTrigger(t_name, t_usetool);
                              }
                         }
                    }
                    else
                    {//初始化机器里是损坏的零件
                         if (t_state.fn_getMainValue()=="badpart")
                         {//如果是放入坏的零件
                              fnp_setLockState("string", "havepart");
                              //找到零件
                              AB_ThePart t_part = GetComponentInChildren<AB_ThePart>();
                              if (t_part!=null)
                              {
                                   t_part.M_PartUseState = E_PartUseState.e_badPart;
                              }
                         }


                         if (t_usetool!=null)
                         {
                              //如果是前后都用用工具的初始化
                              if (t_usetool.M_UseTool == E_UseTool.e_UseToolAll)
                              {

                                   Debug.Log("<color=red>隐藏拿出零件的触发器隐藏</color>");
     
                                   //隐藏拿出零件的触发器隐藏
                                   S_ToolTrigger.Instance.fn_SetToolPushTrigger(t_name.m_ID, false);
                              } 
                         }
                    }
               }
               else
               {
                    return;
               }

               if (m_CloseTriggerStart)
               {
                    //如果前一个零件不再机器里，那么就显示触发器，让用户可以操作
                    AB_Condition t_theCondition = GetComponent<AB_Condition>();
                    if (t_theCondition!=null)
                    {//检查条件
                         if (t_theCondition.fn_check("initTrigger") &&
                              t_state.fn_getMainValue() != "nopart")
                         {
                              return;
                         }
                    }
                    //隐藏拿出零件的触发器
                    fnp_hideTrigger(t_name, t_usetool);
                    //如果是前后都用用工具的初始化,把放入零件的触发器也关闭
                    if (t_usetool!=null)
                    {
                         //主要是处理前后都使用工具的情况
                         if (t_usetool.M_UseTool == E_UseTool.e_UseToolAll)
                         {
                              S_ToolTrigger.Instance.fn_SetToolPushTrigger(t_name.m_ID, false);
                         } 
                    }
               } 
          
          
          }

          private void fnp_hideTrigger(AB_Name t_name, AB_UseTool t_usetool)
          {
               //是否使用工具来操作这个零件
               //AB_UseTool t_usetool = GetComponent<AB_UseTool>();
               if (t_usetool != null)
               {
                    //需要关闭工具的触发器，关闭后工具不能触发
                    //AB_Name t_name = GetComponent<AB_Name>();
                    if (t_name != null)
                    {
                         S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);
                    }
                    else
                    {
                         Debug.Log("<color=red>not find AB_Name!</color>");
                    }
               }
               else
               {
                    //从AB_PullOut类中实现的接口来隐藏零件的拉出触发器
                    I_PullOutTrigger t_pullTrigger = GetComponent<I_PullOutTrigger>();
                    if (t_pullTrigger != null)
                    {
                         t_pullTrigger.fni_SetPartTrigger(false);

                         Debug.Log("<color=blue> t_pullTrigger.fni_SetPartTrigger(false):</color>"+this.gameObject.name);
     
                    }
                    else
                    {
                         Debug.Log("<color=red>not find I_PullOutTrigger!</color>");
                    }
               }
          }
         
     } 
     
}
