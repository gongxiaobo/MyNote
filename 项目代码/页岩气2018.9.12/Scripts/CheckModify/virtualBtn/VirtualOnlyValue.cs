using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 虚拟键的设置
     /// </summary>
     public class VirtualOnlyValue : N_OnlyValueLogic
     {
          protected AB_Rotater m_rotatePart = null;
          protected override void Start()
          {
               base.Start();
               m_rotatePart = GetComponent<AB_Rotater>();
          }
          AB_SetState t_setState = null;
          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_level(_level, _controlType);
               fnp_findCR();
               if (_controlType== E_ControlType.e_normal)
               {
                    if (t_setState == null)
                    {
                         t_setState = new N_SetState();
                    }
                    t_setState.fn_setState("floatvalue", _level.ToString(), m_handleEvent);

                    if (m_rotatePart != null)
                    {
                         m_rotatePart.fn_Rotate(_level);
                    }
                    fnp_callResult(_level);
               }
               else
               {
                    if (t_setState == null)
                    {
                         t_setState = new N_SetState();
                    }
                    t_setState.fn_setState("floatvalue", _level.ToString(), m_handleEvent);
               }
          }
          bool m_callresult = false;
          private  void fnp_callResult(float _level)
          {
               if (_level == 0f)
               {//打开，触发条件
                    if (m_callresult)
                    {
                         return;
                    }
                    m_callresult = true;
                    fnp_Result("outMac");
               }
               else
               {//关闭，关闭关联触发器
                    if (m_callresult==false)
                    {
                         return;
                    }
                    m_callresult = false;
                    fnp_Result("inMac");
               }
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //fnp_findCR();
               base.fni_stateChange(_statename, _value, _controlType);
               AB_Name t_name = GetComponent<AB_Name>();
               AB_Condition t_theCondition = GetComponent<AB_Condition>();
               
              
               //使用锁定"lock"来控制触发器的打开或者关闭
               if (_statename=="lock")
               {
                    if (_value=="lock")
                    {
                         S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);
                         ////关闭放入触发器，如果有的情况下
                         //S_ToolTrigger.Instance.fn_SetToolPushTrigger(t_name.m_ID, false);
                    }
                    else
                    {
                         if (t_theCondition != null)
                         {//检查条件
                              if (t_theCondition.fn_check("initTrigger"))
                              {
                                   //fnp_setLockState("lock", "unlock");
                                   if (t_name != null)
                                   {
                                        S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, true);
                                   }
                                   //return;
                              }
                         }
                         //S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, true);
                         ////关闭放入触发器，如果有的情况下
                         //S_ToolTrigger.Instance.fn_SetToolPushTrigger(t_name.m_ID, true);
                    }
               }
          }
          /// <summary>
          /// 发送在机器或者不再机器的位置消息反射情况
          /// </summary>
          /// <param name="_rname"></param>
          protected virtual void fnp_Result(string _rname)
          {
               if (m_resultAction != null)
               {
                    m_resultAction.fn_SendResultMsg(_rname, m_handleEvent);
               }

               Debug.Log("<color=red>虚拟零件的状态:</color>" + _rname);
     
          }
          


     } 
}
