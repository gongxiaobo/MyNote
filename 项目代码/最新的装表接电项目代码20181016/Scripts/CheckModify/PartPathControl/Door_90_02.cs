using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 用于零件的拉出放入的控制
     /// 在使用工具的零件，打开工具碰撞触发器
     /// </summary>
     public class Door_90_02 : Door_90
     {
          public override void fn_endControl()
          {
               base.fn_endControl();
               
               Debug.Log("<color=blue>结束操作旋钮</color>");
               AB_Name t_name = GetComponent<AB_Name>();
               if (m_lastTime==m_min)
               {//在最小值时，说明把零件放入到机器里的正确位置
                    //设置零件的状态
                    AB_ThePart t_thepart = GetComponentInChildren<AB_ThePart>();
                    if (t_thepart==null)
                    {//找到零件，只有旋转类型的物体，在把零件放入到机器内部的处理
                         
                         Debug.Log("<color=blue>没有在子节点下找到零件</color>");
                         AB_PullOut t_pullout = GetComponent<AB_PullOut>();
                         if (t_pullout!=null)
                         {//是旋转的工具类型，需要把零件从工具上取下，放入到机器
                              //先在工具上添加唤醒触发器的脚本类,方便在手柄拔出时，唤醒触发器
                              AB_activeTrigger t_at=
                                  t_pullout.M_PullObj.transform.parent.gameObject.AddComponent<N_activeTrigger>();
                              t_at.fn_setTriggerInfor(t_name.m_ID);


                              //再把零件放回到机器内部
                              t_thepart = t_pullout.M_PullObj.GetComponent<AB_ThePart>();
                              t_pullout.M_PullObj.transform.parent = this.gameObject.transform;
                              //在
                         }

                    }
                    if (t_thepart != null)
                    {    
                         //Debug.Log("<color=blue>放入零件</color>");
     
                        
                         //发送消息给零件的管理类改变状态
                         AB_SetState t_setState = new N_SetState();
                         t_setState.fn_setState("string", "havepart", GetComponent<AB_HandleEvent>());
                         t_thepart.M_PartState = E_ThePartState.e_inMachine;
                         //如果是需要使用工具拿出零件，那么手柄的触发器就直接关闭
                         AB_PullOut t_pull = GetComponent<AB_PullOut>();
                         if (t_pull!=null)
                         {
                              AB_UseTool t_usetool = GetComponent<AB_UseTool>();
                              if (t_usetool!=null)
                              {
                                   if (t_usetool.M_UseTool == E_UseTool.e_UseToolFirst)
                                   {//需要关闭触发器，防止手触发到这个零件
                                        t_pull.fn_Trigger(false);
                                   } 
                              }
                         }
                    }
                    //需要打开工具的触发器，在这个零件有使用工具的情况下
                    
                    if (t_name != null)
                    {
                         AB_UseTool t_usetool = GetComponent<AB_UseTool>();
                         if (t_usetool!=null)
                         {
                              if (t_usetool.M_UseTool== E_UseTool.e_UseToolAll)
                              {

                              }
                              else if (t_usetool.M_UseTool == E_UseTool.e_UseToolFirst)
                              {
                                   S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, true);
                              }
                         }
                        
                    }
                    else
                    {

                         Debug.Log("<color=red>not find AB_Name!</color>");

                    }
               }
          }
          public override void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_txt(_txt, _controlType);

               Debug.Log("<color=blue>blue:</color>" + _txt+"|"+_controlType);
     
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);
               
               //Debug.Log("<color=red>red:</color>"+_statename +_value);
     
               if (_statename == "lock")
               {//锁定状态的改变
                    I_PullOutTrigger t_pullTrigger = GetComponent<I_PullOutTrigger>();
                    if (_value == "unlock")
                    {//被解锁

                         fnp_setTrigger(t_pullTrigger);
                    }
                    else
                    {//被加锁
                         fnp_setTrigger(t_pullTrigger, false);
                    }
               }
          }

          protected  void fnp_setTrigger(I_PullOutTrigger t_pullTrigger,bool _show=true)
          {
               AB_Name t_name = GetComponent<AB_Name>();
               AB_State t_state = GetComponent<AB_State>();
               if (t_state.fn_getMainValue()=="nopart")
               {//如果这个零件被移动到外部，那么他自己的碰撞体就要隐藏
                    return;
               }
               AB_UseTool t_usetool = GetComponent<AB_UseTool>();
               if (t_usetool != null)
               {//要使用工具的零件
                    //需要打开工具的触发器，在这个零件有使用工具的情况下
                    
                    if (t_name != null)
                    {
                         S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, _show);
                    }
                    else
                    {

                         Debug.Log("<color=red>not find AB_Name!</color>");

                    }
               }
               else
               {
                    if (t_pullTrigger != null)
                    {
                         t_pullTrigger.fni_SetPartTrigger(_show);
                    }
                    else { Debug.Log("<color=red>not find I_PullOutTrigger !</color>"); }
               }
               
          }


         
     } 
}
